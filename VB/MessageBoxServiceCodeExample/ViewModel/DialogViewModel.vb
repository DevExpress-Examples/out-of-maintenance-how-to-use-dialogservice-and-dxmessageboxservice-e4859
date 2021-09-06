Imports Microsoft.VisualBasic
Imports DevExpress.Mvvm
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Windows

Namespace MessageBoxServiceCodeExample.ViewModel
	Public Class DialogViewModel
		Inherits ViewModelBase
		Private allowCloseDialog_Renamed As Boolean = False
		Public Property AllowCloseDialog() As Boolean
			Get
				Return allowCloseDialog_Renamed
			End Get
			Set(ByVal value As Boolean)
				SetProperty(allowCloseDialog_Renamed, value, Function() AllowCloseDialog)
			End Set
		End Property
		Private userName_Renamed As String
		Public Property UserName() As String
			Get
				Return userName_Renamed
			End Get
			Set(ByVal value As String)
				SetProperty(userName_Renamed, value, Function() UserName)
			End Set
		End Property

		Private privateDialogCommands As List(Of UICommand)
		Public Property DialogCommands() As List(Of UICommand)
			Get
				Return privateDialogCommands
			End Get
			Private Set(ByVal value As List(Of UICommand))
				privateDialogCommands = value
			End Set
		End Property
		Private privateRegisterUICommand As UICommand
		Protected Property RegisterUICommand() As UICommand
			Get
				Return privateRegisterUICommand
			End Get
			Private Set(ByVal value As UICommand)
				privateRegisterUICommand = value
			End Set
		End Property
		Private privateCancelUICommand As UICommand
		Protected Property CancelUICommand() As UICommand
			Get
				Return privateCancelUICommand
			End Get
			Private Set(ByVal value As UICommand)
				privateCancelUICommand = value
			End Set
		End Property
		Public Sub New()
			DialogCommands = New List(Of UICommand)()
			RegisterUICommand = New UICommand() With {.Caption = "Register", .Command = New DelegateCommand(Of CancelEventArgs)(AddressOf OnRegisterCommandExecute, AddressOf OnRegisterCommandCanExecute), .IsDefault = True, .Id = MessageBoxResult.OK}
			CancelUICommand = New UICommand() With {.Caption = "Cancel", .Command = New DelegateCommand(Of CancelEventArgs)(AddressOf OnCancelCommandExecute, AddressOf OnCancelCommandCanExecute), .IsCancel = True, .Id = MessageBoxResult.Cancel}
			DialogCommands.Add(RegisterUICommand)
			DialogCommands.Add(CancelUICommand)
		End Sub
		Private Sub OnRegisterCommandExecute(ByVal parameter As CancelEventArgs)
			If (Not AllowCloseDialog) Then
				parameter.Cancel = True
			End If
		End Sub
		Private Function OnRegisterCommandCanExecute(ByVal parameter As CancelEventArgs) As Boolean
			Return Not String.IsNullOrEmpty(UserName)
		End Function
		Private Sub OnCancelCommandExecute(ByVal parameter As CancelEventArgs)
			If (Not AllowCloseDialog) Then
				parameter.Cancel = True
			End If
		End Sub
		Private Function OnCancelCommandCanExecute(ByVal parameter As CancelEventArgs) As Boolean
			Return True
		End Function
	End Class
End Namespace
