#### [EficazFramework.Utilities](EficazFrameworkUtilities.md 'EficazFramework Utilities')
### [EficazFramework.Services](EficazFrameworkUtilities.md#EficazFramework.Services 'EficazFramework.Services')

## HubClient Class

```csharp
public abstract class HubClient :
System.IAsyncDisposable
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; HubClient

Implements [System.IAsyncDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IAsyncDisposable 'System.IAsyncDisposable')

| Constructors | |
| :--- | :--- |
| [HubClient(string, string, string, Func&lt;Task&lt;string&gt;&gt;)](EficazFramework.Services/HubClient/HubClient(string,string,string,Func_Task_string__).md 'EficazFramework.Services.HubClient.HubClient(string, string, string, System.Func<System.Threading.Tasks.Task<string>>)') | |

| Fields | |
| :--- | :--- |
| [_group](EficazFramework.Services/HubClient/_group.md 'EficazFramework.Services.HubClient._group') | |
| [_hubConnection](EficazFramework.Services/HubClient/_hubConnection.md 'EficazFramework.Services.HubClient._hubConnection') | |
| [_hubUrl](EficazFramework.Services/HubClient/_hubUrl.md 'EficazFramework.Services.HubClient._hubUrl') | |
| [_receiveMessageCallBack](EficazFramework.Services/HubClient/_receiveMessageCallBack.md 'EficazFramework.Services.HubClient._receiveMessageCallBack') | |
| [_started](EficazFramework.Services/HubClient/_started.md 'EficazFramework.Services.HubClient._started') | |
| [_username](EficazFramework.Services/HubClient/_username.md 'EficazFramework.Services.HubClient._username') | |

| Properties | |
| :--- | :--- |
| [ReceiveMessageCallBack](EficazFramework.Services/HubClient/ReceiveMessageCallBack.md 'EficazFramework.Services.HubClient.ReceiveMessageCallBack') | |
| [TokenProvider](EficazFramework.Services/HubClient/TokenProvider.md 'EficazFramework.Services.HubClient.TokenProvider') | |

| Methods | |
| :--- | :--- |
| [DisposeAsync()](EficazFramework.Services/HubClient/DisposeAsync().md 'EficazFramework.Services.HubClient.DisposeAsync()') | |
| [ExitGroupAsync()](EficazFramework.Services/HubClient/ExitGroupAsync().md 'EficazFramework.Services.HubClient.ExitGroupAsync()') | |
| [JoinGroupAsync()](EficazFramework.Services/HubClient/JoinGroupAsync().md 'EficazFramework.Services.HubClient.JoinGroupAsync()') | |
| [SendAsync(string)](EficazFramework.Services/HubClient/SendAsync(string).md 'EficazFramework.Services.HubClient.SendAsync(string)') | |
| [StartAsync(bool)](EficazFramework.Services/HubClient/StartAsync(bool).md 'EficazFramework.Services.HubClient.StartAsync(bool)') | |
| [StopAsync()](EficazFramework.Services/HubClient/StopAsync().md 'EficazFramework.Services.HubClient.StopAsync()') | |
