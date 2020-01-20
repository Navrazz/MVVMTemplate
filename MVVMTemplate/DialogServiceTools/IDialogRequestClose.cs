using System;

namespace MVVMTemplate.DialogServiceTools
{
    public interface IDialogRequestClose
    {
        event EventHandler<DialogCloseRequestedEventArgs> RequestClose;
    }
}
