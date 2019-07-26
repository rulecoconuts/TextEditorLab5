'AUTHOR: OGHENEFEJIRO THEODORE ABOHWEYERE
'DATE: 25TH JULY 2019
'DESCRIPTION: THIS CLASS SIMPLY ENCAPSULATES THE FUNCTIONALITY OF SAVING A FILE.
Option Strict On
Public Class Save
    Private stream As System.IO.FileStream
    Private writer As System.IO.StreamWriter
    Private result As DialogResult
    Private dialog As SaveFileDialog = New SaveFileDialog()

    ''' <summary>
    ''' This  function loads the openFile dialog and reads from the file
    ''' </summary>
    Public Sub New(content As String, Optional openDialog As Boolean = False)
        If openDialog Then
            Load(content)
        End If
    End Sub

    ''' <summary>
    ''' Loads the form and defines the values of the variables in the class
    ''' </summary>
    Public Sub Load(content As String)
        result = dialog.ShowDialog()
        If result = DialogResult.OK Then
            Write(content, dialog.FileName)
            writer.Close()
        End If
    End Sub

    ''' <summary>
    ''' Reads the content of the file
    ''' </summary>
    Public Sub Write(content As String, Optional filename As String = "newFile.txt")
        stream = New System.IO.FileStream(filename, System.IO.FileMode.Create, System.IO.FileAccess.Write)
        writer = New System.IO.StreamWriter(stream)
        writer.Write(content)
        writer.Close()
    End Sub

    ''' <summary>
    ''' Close the the streams and stream writers
    ''' </summary>
    Public Sub Close()
        stream.Close()
        writer.Close()
    End Sub

    ''' <summary>
    ''' This function gets the dialog result i.e the DialogResult.enum of the dialog
    ''' e.g DialogResult.OK, DialogResult.Cancel
    ''' </summary>
    ''' <returns>DialogResult.enum</returns>
    Public Function GetResult() As DialogResult
        Return result
    End Function

    Public Function GetFileName() As String
        Return dialog.FileName
    End Function

End Class
