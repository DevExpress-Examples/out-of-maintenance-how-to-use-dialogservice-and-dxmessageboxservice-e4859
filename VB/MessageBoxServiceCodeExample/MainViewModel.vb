Imports DevExpress.Mvvm
Imports MessageBoxServiceCodeExample.ViewModel
Imports System.Windows.Input

Namespace MessageBoxServiceCodeExample
	Public Class MainViewModel
		Inherits ViewModelBase

		Private privateShowMessageBoxCommand As ICommand
		Public Property ShowMessageBoxCommand() As ICommand
			Get
				Return privateShowMessageBoxCommand
			End Get
			Private Set(ByVal value As ICommand)
				privateShowMessageBoxCommand = value
			End Set
		End Property
		Private privateShowDialogCommand As ICommand
		Public Property ShowDialogCommand() As ICommand
			Get
				Return privateShowDialogCommand
			End Get
			Private Set(ByVal value As ICommand)
				privateShowDialogCommand = value
			End Set
		End Property

		Private privateDialogViewModel As DialogViewModel
		Protected Property DialogViewModel() As DialogViewModel
			Get
				Return privateDialogViewModel
			End Get
			Private Set(ByVal value As DialogViewModel)
				privateDialogViewModel = value
			End Set
		End Property

		Protected ReadOnly Property DialogService() As IDialogService
			Get
				Return GetService(Of IDialogService)()
			End Get
		End Property
		Protected ReadOnly Property MessageService() As IMessageBoxService
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
			If resCommand IsNot Nothing Then
				MessageService.Show("Dialog Clicked Button: " & resCommand.Caption)
			End If
		End Sub
	End Class
End Namespace
