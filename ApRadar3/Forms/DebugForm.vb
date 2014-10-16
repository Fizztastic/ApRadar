﻿Public Class DebugForm
    Private _sof As FormAnimator
    Private _dock As DockingClass

    Private Sub DebugForm_ForeColorChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ForeColorChanged
        UpdateControlColors(Me)
    End Sub

    Private Sub DebugForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'Roll up the form
        _sof.FadeOut(500)
    End Sub

    Private Sub DebugForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ThemeHandler.ApplyTheme(Me)
        _sof = New FormAnimator(Me)
        _dock = New DockingClass(Me)
        _dock.UseDocking = True
        _sof.FadeIn(500)
    End Sub

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

    Friend Sub AppendMessage(ByVal Message As String, ByVal NewLineAfter As Boolean)
        Me.rtbDebug.AppendText(Message)
        If NewLineAfter Then
            Me.rtbDebug.AppendText(ControlChars.NewLine)
        End If
    End Sub

    Friend Sub AddDebugMessage(ByVal Message As String)
        AddDebugMessage(Color.FromKnownColor(KnownColor.Info), "Info", Message, True)
    End Sub

    Friend Sub AddDebugMessage(ByVal Message As String, ByVal NewLineAfter As Boolean)
        AddDebugMessage(Color.FromKnownColor(KnownColor.Info), "Info", Message, NewLineAfter)
    End Sub

    Friend Sub AddDebugMessage(ByVal ErrorType As String, ByVal Message As String)
        AddDebugMessage(Color.FromKnownColor(KnownColor.Info), ErrorType, Message, True)
    End Sub

    Friend Sub AddDebugMessage(ByVal ErrorType As String, ByVal Message As String, ByVal NewLineAfter As Boolean)
        AddDebugMessage(Color.FromKnownColor(KnownColor.Info), ErrorType, Message, NewLineAfter)
    End Sub

    Friend Sub AddDebugMessage(ByVal Color As Color, ByVal ErrorType As String, ByVal Message As String, ByVal NewLineAfter As Boolean)
        Me.rtbDebug.SelectionStart = Me.rtbDebug.TextLength
        Me.rtbDebug.SelectionColor = Color
        If NewLineAfter Then
            Me.rtbDebug.AppendText(String.Format("{0} : {1}{2}", ErrorType, Message, ControlChars.NewLine))
        Else
            Me.rtbDebug.AppendText(String.Format("{0} : {1}", ErrorType, Message))
        End If

    End Sub
End Class