﻿Public Class NewsViewerForm
    Private _sof As FormAnimator
    Private _dock As DockingClass

    Private _news As String
    Public Property News() As String
        Get
            Return _news
        End Get
        Set(ByVal value As String)
            _news = value
            Me.rtbNews.Text = value
        End Set
    End Property

    Private Sub HeaderPanel_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles HeaderPanel.MouseDown, lblHeder.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            _dock.StartDockDrag(e.X, e.Y)
        End If
    End Sub

    Private Sub HeaderPanel_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles HeaderPanel.MouseMove, lblHeder.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then
            _dock.UpdateDockDrag(New UpdateDockDragArgs(e.X, e.Y))
        End If
    End Sub

    Private Sub blnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles blnClose.Click
        Me.Close()
    End Sub

    Private Sub NewsViewerForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        _sof.FadeOut(1000)
    End Sub

    Private Sub NewsViewerForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ThemeHandler.ApplyTheme(Me)
        _sof = New FormAnimator(Me)
        _dock = New DockingClass(Me)
        _dock.UseDocking = True
        _sof.FadeIn(500)
    End Sub
End Class