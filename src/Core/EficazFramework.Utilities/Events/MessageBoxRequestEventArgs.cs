using EficazFramework.Threading;
using System;

namespace EficazFramework.Events;

public class MessageEventArgs : EventArgs
{
    public string DialogResourceKey { get; set; }

    public string Title { get; set; } = Resources.Strings.Events.MessageBox_DefaultTitle;
    public eMessageIcon IconReference { get; set; } = eMessageIcon.None;
    public object Content { get; set; } = null;
    public bool EnableReporting { get; set; } = false;
    public string StackTrace { get; set; } = null;
    public eMessageButtons Buttons { get; set; } = eMessageButtons.OK;
    public eMessageType Type { get; set; } = eMessageType.Default;
    public object Tag { get; set; }
    public ModalAssist ModalAssist { get; } = new ModalAssist();
}

public delegate void MessageEventHandler(object sender, MessageEventArgs e);

public enum eMessageIcon
{
    None = 0,
    Exclamation = 1,
    Warning = 2,
    Error = 3,
    Certificate = 11,
    Like = 21
}

public enum eMessageButtons
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

public enum eMessageType
{
    Default = 0,
    SnackBar = 1
}
public enum eMessageResult
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
