Option Explicit On
Option Strict On

Public Class Jimaku
    Private mousePoint As Point
    Private formPair As Jimaku
    Private formParent As Form1

    Public Sub setFormPair(ByRef form As Jimaku)
        Me.formPair = form
    End Sub

    Public Sub setFormParent(ByRef form As Form1)
        Me.formParent = form
    End Sub


    Private Sub Jimaku_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
        'Me.formParent.RePaintFlg = True
    End Sub
    Private Sub Jimaku_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Left = Me.formPair.Left
        Me.Top = Me.formPair.Top
    End Sub

    Private Sub Jimaku_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If (e.Button And Windows.Forms.MouseButtons.Left) = Windows.Forms.MouseButtons.Left Then
            Me.formPair.Hide()
            Me.formPair.Tag = "hide"
            'ˆÊ’u‚ð‹L‰¯‚·‚é
            mousePoint = New Point(e.X, e.Y)
        End If

    End Sub

    Private Sub Jimaku_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If (e.Button And Windows.Forms.MouseButtons.Left) = Windows.Forms.MouseButtons.Left Then
            Me.Left += e.X - mousePoint.X
            Me.Top += e.Y - mousePoint.Y

        End If

    End Sub

    Private Sub Jimaku_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        Me.formPair.Left = Me.Left
        Me.formPair.Top = Me.Top
        Me.formPair.Show()
        Me.formPair.Tag = ""
    End Sub
End Class