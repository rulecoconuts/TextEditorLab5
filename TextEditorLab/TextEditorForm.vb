'AUTHOR: OGHENEFEJIRO THEODORE ABOHWEYERE
'DATE: 25TH JULY 2019
'DESCRIPTION: THIS IS A SIMPLE TEXT EDITOR CREATED FOR THE NETD COURSE IN DURHAM COLLEGE.
Option Strict On
Public Class frmTextEditor

    Const DEFAULT_TITLE = "Text Editor v1.0"
    Const info As String = "THIS IS A TEXT EDITOR CREATED BY THEODORE" + vbNewLine + "ABOHWEYERE FOR THE NETD LAB05."
    Dim openInstance As Open = New Open()
    Dim saveInstance As Save = New Save("")
    Dim fileName As String = ""
    Dim modified As Boolean = False
    Dim content As String = ""

    ''' <summary>
    ''' Open the Dialog and display the contents
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub OpenToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OpenToolStripMenuItem.Click
        openInstance.Load()
        If openInstance.GetResult() = DialogResult.OK Then
            content = txtContent.Text
            txtContent.Text = openInstance.GetContent()
            fileName = openInstance.GetFileName()
            Me.Text = DEFAULT_TITLE + "  " + fileName
        End If
    End Sub

    ''' <summary>
    ''' This allows you to create a new document.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        txtContent.Text = ""
        fileName = ""
        modified = False
        Me.Text = DEFAULT_TITLE
    End Sub

    ''' <summary>
    ''' This method saves the text document
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click
        Dim successful As Boolean = False
        If fileName = "" Then
            saveInstance.Load(txtContent.Text)
            If saveInstance.GetResult() = DialogResult.OK Then
                successful = True
            End If
        ElseIf modified Then
            saveInstance.Write(txtContent.Text, fileName)
            If saveInstance.GetResult() = DialogResult.OK Then
                successful = True
            End If
        End If
        If successful Then
            modified = False
            fileName = saveInstance.GetFileName()
            content = txtContent.Text
            Me.Text = DEFAULT_TITLE + "  " + fileName
        End If
    End Sub

    ''' <summary>
    ''' Save the fule as a new name
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub SaveAsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveAsToolStripMenuItem.Click
        saveInstance.Load(txtContent.Text)
        If saveInstance.GetResult() = DialogResult.OK Then
            modified = False
            fileName = saveInstance.GetFileName()
            content = txtContent.Text
            Me.Text = DEFAULT_TITLE + "  " + fileName
        End If
    End Sub

    ''' <summary>
    ''' Stop displaying the current file
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs, Optional exitP As Boolean = False) Handles CloseToolStripMenuItem.Click
        Dim close = True
        If modified Then
            Dim result As MsgBoxResult = MsgBox("Save file " + fileName + "before closing?", MsgBoxStyle.YesNoCancel)
            If result = MsgBoxResult.Yes Then
                SaveToolStripMenuItem_Click(sender, e)
            ElseIf result = MsgBoxResult.Cancel Then
                close = False
            End If
        End If
        If close Then
            txtContent.Text = ""
            fileName = ""
            Me.Text = DEFAULT_TITLE
            If exitP Then
                Application.Exit()
            End If
            content = ""
            modified = True
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        CloseToolStripMenuItem_Click(sender, e, True)
    End Sub

    ''' <summary>
    ''' Check if the text has been modified
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub txtContent_TextChanged(sender As Object, e As EventArgs) Handles txtContent.TextChanged
        If content = txtContent.Text Then
            modified = False
            Me.Text = DEFAULT_TITLE + "  " + fileName
        Else
            modified = True
            Me.Text = DEFAULT_TITLE + "  *" + fileName
        End If
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        MessageBox.Show(info)
    End Sub

    Private Sub CutCtrlXToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CutCtrlXToolStripMenuItem.Click
        My.Computer.Clipboard.SetText(txtContent.SelectedText)
        txtContent.SelectedText = ""
    End Sub

    Private Sub CopyCtrlCToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyCtrlCToolStripMenuItem.Click
        My.Computer.Clipboard.SetText(txtContent.SelectedText)
    End Sub

    Private Sub PasteCtrlVToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PasteCtrlVToolStripMenuItem.Click
        My.Computer.Clipboard.GetText()
    End Sub
End Class
