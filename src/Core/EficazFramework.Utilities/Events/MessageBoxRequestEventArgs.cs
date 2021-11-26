using EficazFramework.Threading;
using System;
using System.Diagnostics.CodeAnalysis;

namespace EficazFramework.Events;

[ExcludeFromCodeCoverage]
public class MessageEventArgs : EventArgs
{
    public string DialogResourceKey { get; set; }

    public string Title { get; set; } = Resources.Strings.Events.MessageBox_DefaultTitle;
    public MessageIcon IconReference { get; set; } = MessageIcon.None;
    public object Content { get; set; } = null;
    public bool EnableReporting { get; set; } = false;
    public string StackTrace { get; set; } = null;
    public MessageButtons Buttons { get; set; } = MessageButtons.OK;
    public MessageType Type { get; set; } = MessageType.Default;
    public object Tag { get; set; }
    public ModalAssist ModalAssist { get; } = new ModalAssist();
}

public delegate void MessageEventHandler(object sender, MessageEventArgs e);

public enum MessageIcon
{
    None = 0,
    Exclamation = 1,
    Warning = 2,
    Error = 3,
    Certificate = 11,
    Like = 21
}

public enum MessageButtons
{
    // 
    // Summary:
    // The message box displays an OK button.
    OK = 0,
    // 
    // Summary:
    // The message box displays OK and Cancel buttons.
    OKCancel = 1,
    // 
    // Summary:
    // The message box displays Yes, No, and Cancel buttons.
    YesNoCancel = 3,
    // 
    // Summary:
    // The message box displays Yes and No buttons.
    YesNo = 4
}

public enum MessageType
{
    Default = 0,
    SnackBar = 1
}
public enum MessageResult
{
    // 
    // Summary:
    // The message box returns 'OK'.
    OK = 0,
    // 
    // Summary:
    // The message box returns 'Cancel'.
    Cancel = 1,
    // 
    // Summary:
    // The message box returns 'Yes'.
    Yes = 3,
    // 
    // Summary:
    // The message box returns 'No'.
    No = 4,
    // 
    // Summary:
    // The message box returns 'Custom'.
    Custom = 5,
    // 
    // Summary:
    // The user didn't answer the dialog yet, or it's not applicable.
    NotSet = 99
}
