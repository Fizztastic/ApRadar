﻿Imports System.Net

Public Class BrowserForm
    Inherits ResizableForm

    Private _sof As FormAnimator
    Private _dock As DockingClass
    Private _adsRemoved As Boolean = False
    Private _isResizing As Boolean = False
    Private _originPoint As Point

    Public WriteOnly Property Url() As String
        Set(ByVal value As String)
            Me.Browser.Navigate(value)
            Me.txtUrl.Text = value
        End Set
    End Property

    Private Sub Browser_CanGoBackChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Browser.CanGoBackChanged
        Me.cmdBack.Enabled = Browser.CanGoBack
    End Sub

    Private Sub Browser_CanGoForwardChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Browser.CanGoForwardChanged
        Me.cmdForward.Enabled = Browser.CanGoForward
    End Sub

    Private Sub Browser_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles Browser.DocumentCompleted
        Me.Browser.Visible = True
        Me.picLoading.Visible = False
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles blnClose.Click
        Me.Close()
    End Sub

    Private Sub BrowserForm_ForeColorChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ForeColorChanged
        UpdateControlColors(Me)
    End Sub

    Private Sub BrowserForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'Hide the browser
        Browser.Visible = False
        'Roll up the form
        If _dock.DockedLocation.Contains(DockingClass.DockPosition.Top) Then
            _sof.RollUp(150, SlideDirection.Down)
        Else
            _sof.FadeOut(500)
        End If
    End Sub

    Private Sub BrowserForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
       ThemeHandler.ApplyTheme(Me)
        _sof = New FormAnimator(Me)
        _dock = New DockingClass(Me)
        _dock.UseDocking = True
        If ThemeHandler.ActiveTheme.DockPosition = DockMode.Top Then
            _sof.SlideOut(150, SlideDirection.Down)
        Else
            _sof.SlideOut(150, SlideDirection.Up)
        End If
    End Sub

    Private Sub cmdForward_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdForward.Click
        Me.Browser.GoForward()
    End Sub

    Private Sub cmdBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBack.Click
        Me.Browser.GoBack()
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

    Private Sub Browser_DocumentTitleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Browser.DocumentTitleChanged
        Me.picLoading.Visible = True
        Me.lblHeder.Text = Me.Browser.DocumentTitle
        Me.txtUrl.Text = Me.Browser.Document.Url.AbsoluteUri
    End Sub

    Private Sub Browser_Navigated(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserNavigatedEventArgs) Handles Browser.Navigated
    End Sub

    Private Sub Browser_Navigating(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserNavigatingEventArgs) Handles Browser.Navigating
        Me.picLoading.Visible = True

    End Sub

    Private Sub txtUrl_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtUrl.KeyUp
        If e.KeyCode = Keys.Enter Then
            e.Handled = True
            Navigate()
        End If
    End Sub

    Private Sub Navigate()
        If Me.txtUrl.Text <> String.Empty Then
            If Not Me.txtUrl.Text.StartsWith("http://") Then
                Me.txtUrl.Text = String.Format("http://{0}", Me.txtUrl.Text)
            End If
            Me.Browser.Navigate(Me.txtUrl.Text)
        End If
    End Sub

    Private Sub BrowserForm_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            'Dim resizeRegion As New Rectangle(Me.Width - 15, Me.Height - 15, 15, 15)
            'If resizeRegion.Contains(e.Location) Then
            '    _isResizing = True
            '    Me.SuspendLayout()
            '    _originPoint = e.Location
            'End If
        End If
    End Sub

    Private Sub BrowserForm_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        'If _isResizing Then
        '    Me.Width += e.Location.X - _originPoint.X
        '    Me.Height += e.Location.Y - _originPoint.Y
        '    _originPoint = e.Location
        'Else
        '    Dim resizeRegion As New Rectangle(Me.Width - 15, Me.Height - 15, 15, 15)
        '    If resizeRegion.Contains(e.Location) Then
        '        Me.Cursor = Cursors.SizeNWSE
        '    Else
        '        Me.Cursor = Cursors.Default
        '    End If
        'End If
    End Sub

    Private Sub BrowserForm_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        'If _isResizing Then
        '    Me.ResumeLayout()
        '    _isResizing = False
        'End If
    End Sub
End Class