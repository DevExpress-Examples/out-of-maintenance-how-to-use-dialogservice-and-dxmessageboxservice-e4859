Imports DevExpress.Mvvm
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Windows

Namespace MessageBoxServiceCodeExample.ViewModel

    Public Class DialogViewModel
        Inherits ViewModelBase

        Private _DialogCommands As List(Of DevExpress.Mvvm.UICommand), _RegisterUICommand As UICommand, _CancelUICommand As UICommand

        Private allowCloseDialogField As Boolean = False

        Public Property AllowCloseDialog As Boolean
            Get
                Return allowCloseDialogField
            End Get

            Set(ByVal value As Boolean)
                SetProperty(allowCloseDialogField, value, Function() AllowCloseDialog)
            End Set
        End Property

        Private userNameField As String

        Public Property UserName As String
            Get
                Return userNameField
            End Get

            Set(ByVal value As String)
                SetProperty(userNameField, value, Function() UserName)
            End Set
        End Property

        Public Property DialogCommands As List(Of UICommand)
            Get
                Return _DialogCommands
            End Get

            Private Set(ByVal value As List(Of UICommand))
                _DialogCommands = value
            End Set
        End Property

        Protected Property RegisterUICommand As UICommand
            Get
                Return _RegisterUICommand
            End Get

            Private Set(ByVal value As UICommand)
                _RegisterUICommand = value
            End Set
        End Property

        Protected Property CancelUICommand As UICommand
            Get
                Return _CancelUICommand
            End Get

            Private Set(ByVal value As UICommand)
                _CancelUICommand = value
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
            If Not AllowCloseDialog Then
                parameter.Cancel = True
            End If
        End Sub

        Private Function OnRegisterCommandCanExecute(ByVal parameter As CancelEventArgs) As Boolean
            Return Not String.IsNullOrEmpty(UserName)
        End Function

        Private Sub OnCancelCommandExecute(ByVal parameter As CancelEventArgs)
            If Not AllowCloseDialog Then
                parameter.Cancel = True
            End If
        End Sub

        Private Function OnCancelCommandCanExecute(ByVal parameter As CancelEventArgs) As Boolean
            Return True
        End Function
    End Class
End Namespace
