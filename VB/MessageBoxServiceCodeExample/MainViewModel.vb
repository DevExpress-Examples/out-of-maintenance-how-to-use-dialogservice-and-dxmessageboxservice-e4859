Imports DevExpress.Mvvm
Imports MessageBoxServiceCodeExample.ViewModel
Imports System.Windows.Input

Namespace MessageBoxServiceCodeExample

    Public Class MainViewModel
        Inherits ViewModelBase

        Private _ShowMessageBoxCommand As ICommand, _ShowDialogCommand As ICommand, _DialogViewModel As DialogViewModel

        Public Property ShowMessageBoxCommand As ICommand
            Get
                Return _ShowMessageBoxCommand
            End Get

            Private Set(ByVal value As ICommand)
                _ShowMessageBoxCommand = value
            End Set
        End Property

        Public Property ShowDialogCommand As ICommand
            Get
                Return _ShowDialogCommand
            End Get

            Private Set(ByVal value As ICommand)
                _ShowDialogCommand = value
            End Set
        End Property

        Protected Property DialogViewModel As DialogViewModel
            Get
                Return _DialogViewModel
            End Get

            Private Set(ByVal value As DialogViewModel)
                _DialogViewModel = value
            End Set
        End Property

        Protected ReadOnly Property DialogService As IDialogService
            Get
                Return GetService(Of IDialogService)()
            End Get
        End Property

        Protected ReadOnly Property MessageService As IMessageBoxService
            Get
                Return GetService(Of IMessageBoxService)()
            End Get
        End Property

        Public Sub New()
            ShowMessageBoxCommand = New DelegateCommand(AddressOf OnShowMessageBoxCommandExecute)
            ShowDialogCommand = New DelegateCommand(AddressOf OnShowDialogCommandExecute)
            DialogViewModel = New DialogViewModel()
        End Sub

        Private Sub OnShowMessageBoxCommandExecute()
            MessageService.Show("This is a message box", "DXMessageBoxService", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Information)
        End Sub

        Private Sub OnShowDialogCommandExecute()
            Dim resCommand As UICommand = DialogService.ShowDialog(DialogViewModel.DialogCommands, "DialogWindow", DialogViewModel)
            If resCommand IsNot Nothing Then MessageService.Show("Dialog Clicked Button: " & resCommand.Caption)
        End Sub
    End Class
End Namespace
