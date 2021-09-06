using DevExpress.Mvvm;
using MessageBoxServiceCodeExample.ViewModel;
using System.Windows.Input;

namespace MessageBoxServiceCodeExample {
    public class MainViewModel : ViewModelBase {
        public ICommand ShowMessageBoxCommand { get; private set; }
        public ICommand ShowDialogCommand { get; private set; }

        protected DialogViewModel DialogViewModel { get; private set; }
        
        protected IDialogService DialogService { get { return GetService<IDialogService>(); } }
        protected IMessageBoxService MessageService { get { return GetService<IMessageBoxService>(); } }
        public MainViewModel() {
            ShowMessageBoxCommand = new DelegateCommand(OnShowMessageBoxCommandExecute);
            ShowDialogCommand = new DelegateCommand(OnShowDialogCommandExecute);
            DialogViewModel = new DialogViewModel();
        }
        void OnShowMessageBoxCommandExecute() {
            MessageService.Show("This is a message box", "DXMessageBoxService", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information);
        }
        void OnShowDialogCommandExecute() {
            UICommand resCommand = DialogService.ShowDialog(DialogViewModel.DialogCommands, "DialogWindow", DialogViewModel);
            if(resCommand != null)
                MessageService.Show("Dialog Clicked Button: " + resCommand.Caption);
        }
    }
}
