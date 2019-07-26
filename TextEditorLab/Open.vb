'AUTHOR: OGHENEFEJIRO THEODORE ABOHWEYERE
'DATE: 25TH JULY 2019
'DESCRIPTION: THIS CLASS SIMPLY ENCAPSULATES THE FUNCTIONALITY OF OPENING A FILE.
Option Strict On
Public Class Open
    Private stream As System.IO.FileStream
    Private reader As System.IO.StreamReader
    Private result As DialogResult
    Private dialog As OpenFileDialog = New OpenFileDialog()
    Private content As String

    ''' <summary>
    ''' This  function loads the openFile dialog and reads from the file
    ''' </summary>
    Public Sub New(Optional openDialog As Boolean = False)
        If openDialog Then
            Load()
        End If
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

    ''' <summary>
    ''' This function returns the content of the file
    ''' </summary>
    ''' <returns></returns>
    Public Function GetContent() As String
        Return content
    End Function

    ''' <summary>
    ''' Loads the form and defines the values of the variables in the class
    ''' </summary>
    Public Sub Load()
        result = dialog.ShowDialog()
        If result = DialogResult.OK Then
            Read()
            reader.Close()
        End If
    End Sub

    ''' <summary>
    ''' Reads the content of the file
    ''' </summary>
    Public Sub Read()
        stream = New System.IO.FileStream(dialog.FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read)
        reader = New System.IO.StreamReader(stream)
        content = reader.ReadToEnd()
    End Sub

    ''' <summary>
    ''' Close the streams and stream readers
    ''' </summary>
    Public Sub Close()
        stream.Close()
        reader.Close()
    End Sub
End Class
