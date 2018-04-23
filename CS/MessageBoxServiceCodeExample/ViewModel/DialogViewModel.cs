using DevExpress.Xpf.Mvvm;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;

namespace MessageBoxServiceCodeExample.ViewModel {
    public class DialogViewModel : ViewModelBase {
        bool allowCloseDialog = false;
        public bool AllowCloseDialog {
            get { return allowCloseDialog; }
            set { SetProperty(ref allowCloseDialog, value, () => AllowCloseDialog); }
        }
        string userName;
        public string UserName {
            get { return userName; }
            set { SetProperty(ref userName, value, () => UserName); }
        }

        public List<UICommand> DialogCommands { get; private set; }
        protected UICommand RegisterUICommand { get; private set; }
        protected UICommand CancelUICommand { get; private set; }
        public DialogViewModel() {
            DialogCommands = new List<UICommand>();
            RegisterUICommand = new UICommand() {
                Caption = "Register",
                Command = new DelegateCommand<CancelEventArgs>(OnRegisterCommandExecute, OnRegisterCommandCanExecute),
                IsDefault = true,
                Id = MessageBoxResult.OK,
            };
            CancelUICommand = new UICommand() {
                 Caption = "Cancel",
                 Command = new DelegateCommand<CancelEventArgs>(OnCancelCommandExecute, OnCancelCommandCanExecute),
                 IsCancel = true,
                 Id = MessageBoxResult.Cancel,
            };
            DialogCommands.Add(RegisterUICommand);
            DialogCommands.Add(CancelUICommand);
        }
        void OnRegisterCommandExecute(CancelEventArgs parameter) {
            if(!AllowCloseDialog) {
                parameter.Cancel = true;
            }
        }
        bool OnRegisterCommandCanExecute(CancelEventArgs parameter) {
            return !string.IsNullOrEmpty(UserName);
        }
        void OnCancelCommandExecute(CancelEventArgs parameter) {
            if(!AllowCloseDialog) {
                parameter.Cancel = true;
            }
        }
        bool OnCancelCommandCanExecute(CancelEventArgs parameter) {
            return true;
        }
    }
}
