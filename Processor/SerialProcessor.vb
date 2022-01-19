Imports System.IO

Public Class SerialProcessor : Inherits FileProcessor

    Sub New(FileName As String)
        MyBase.New(FileName)
    End Sub

    Overrides Sub Write(Data As String, Append As Boolean)
        Dim FileWriter As New StreamWriter(Me._FilePath, Append)
        FileWriter.Write(Data)
        FileWriter.Close()
    End Sub

    Overrides Sub WriteLine(Data As String, Append As Boolean)
        Dim FileWriter As New StreamWriter(Me._FilePath, Append)
        FileWriter.WriteLine(Data)
        FileWriter.Close()
    End Sub

End Class
