﻿
Public Class ChatSettingsDialog

    Private Sub ChatSettingsDialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ThemeHandler.ApplyTheme(Me)
        'Me.HeaderPanel.BackgroundImage = ThemeHandler.HeaderImage
        'Me.HeaderPanel.ForeColor = ThemeHandler.BarForeColor
        'Me.BackColor = ThemeHandler.FormBackgroundColor
        'Me.ForeColor = ThemeHandler.FormForeColor

        sayColor.Color = My.Settings.Say
        shoutColor.Color = My.Settings.Shout
        tellColor.Color = My.Settings.Tell
        EmoteColor.Color = My.Settings.Emote
        lblFont.Font = My.Settings.ChatFont
        ckFlash.Checked = My.Settings.FlashWindow
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        My.Settings.Say = sayColor.Color
        My.Settings.Shout = shoutColor.Color
        My.Settings.Tell = tellColor.Color
        My.Settings.Emote = EmoteColor.Color
        My.Settings.FlashWindow = ckFlash.Checked
        My.Settings.ChatFont = lblFont.Font
        My.Settings.Save()
        DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub cmdCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancel.Click
        DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub cmdFont_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFont.Click
        Using fd As New FontDialog() With {.Font = My.Settings.ChatFont}
            If fd.ShowDialog = Windows.Forms.DialogResult.OK Then
                lblFont.Font = fd.Font
            End If
        End Using
    End Sub

    Private Sub lblFont_FontChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lblFont.FontChanged
        lblFont.Text = String.Format("{0} {1}pt", lblFont.Font.Name, lblFont.Font.SizeInPoints)
    End Sub
End Class