using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace EficazFramework.Services;

/// <summary>
/// </summary>
/// <exclude/>
[ExcludeFromCodeCoverage]
public abstract class HubClient : IAsyncDisposable
{
    private readonly string _hubUrl;
    private HubConnection _hubConnection;
    private readonly string _username;
    private readonly string _group;
    private bool _started;
    public Func<Task<string>> TokenProvider { get; }


    protected HubClient(string username, string group, string url, Func<Task<string>> tokenProvider)
    {
        if (string.IsNullOrWhiteSpace(username))
            throw new ArgumentNullException(nameof(username));
        if (string.IsNullOrWhiteSpace(url))
            throw new ArgumentNullException(nameof(url));
        _username = username;
        _group = group;
        _hubUrl = url;
        TokenProvider = tokenProvider;
    }

    public async Task StartAsync(bool autoReconnect = false)
    {
        if (!_started)
        {
            IHubConnectionBuilder builder = new HubConnectionBuilder().WithUrl(_hubUrl, options =>
            {
                options.AccessTokenProvider = TokenProvider;
            });
            if (autoReconnect)
                builder.WithAutomaticReconnect();
            _hubConnection = builder.Build();
            Console.WriteLine("ChatClient: calling Start()");
            await _hubConnection.StartAsync();
            Console.WriteLine("ChatClient: Start returned");
            _started = true;
            await _hubConnection.SendAsync(Messages.REGISTER, _username);
            if (!(string.IsNullOrEmpty(_group) | string.IsNullOrWhiteSpace(_group)))
                await JoinGroupAsync();
        }
    }

    private Action<string, string, string> _receiveMessageCallBack;
    public Action<string, string, string> ReceiveMessageCallBack
    {
        get => _receiveMessageCallBack;
        set
        {
            _receiveMessageCallBack = value;
            _hubConnection.On<string, string, string>(Messages.RECEIVE, ReceiveMessageCallBack);
        }

    }

    public async Task SendAsync(string message)
    {
        if (!_started)
            throw new InvalidOperationException("Client not started");
        await _hubConnection.SendAsync(Messages.SEND, _username, _group, message);
        Console.WriteLine($"ChatClient: User {_username} sent message to group {_group}. Content: {message}");
    }

    public async Task JoinGroupAsync() // As Task
    {
        if (!_started)
            throw new InvalidOperationException("Client not started");
        await _hubConnection.SendAsync("AddToGroup", _group);
        Console.WriteLine($"ChatClient: {_username} joined on group {_group}");
    }

    public async Task ExitGroupAsync() // As Task
    {
        if (!_started)
            return; // Throw New InvalidOperationException("Client not started")
        await _hubConnection.SendAsync("RemoveFromGroup", _group);
        Console.WriteLine($"ChatClient: {_username} exited from group {_group}");
    }

    public async Task StopAsync()
    {
        if (_started)
        {
            await _hubConnection.StopAsync();
            _started = false;
            Console.WriteLine("ChatClient: Stop returned");
        }
    }

    public async ValueTask DisposeAsync()
    {
        Console.WriteLine("ChatClient: Disposing");
        await StopAsync();
        GC.SuppressFinalize(this);
    }
}

internal static class Messages
{
    public const string RECEIVE = "ReceiveMessage";
    public const string REGISTER = "Register";
    public const string SEND = "SendMessageToGroup";
}

public class HubsList
{
    public const string SUPPORT = "supporthub";
    public const string NOTIFYSYSTEM = "notifyhub";
    public const string NOTIFYSYSTEMEFMEMBERS = "internalhub";
}
