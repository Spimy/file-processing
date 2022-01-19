Imports System.IO

Public MustInherit Class FileProcessor

    Protected _FileName As String
    Protected _FilePath As String

    Public ReadOnly Property FileName
        Get
            Return Me._FileName
        End Get
    End Property

    Sub New(FileName As String)
        Me._FileName = FileName
        ' Ideally use installation path instead of hard coding it in
        Me._FilePath = "F:\School\Computer Science\Visual Basic Projects\File Processing\" & FileName
    End Sub

    Function FormatData(ParamArray Data As String()) As String
        Return String.Join(" | ", Data)
    End Function

    Sub ReadFile()
        If Not File.Exists(Me._FilePath) Then
            Console.WriteLine("File not found.")
            Exit Sub
        End If

        Dim FileReader As New StreamReader(Me._FilePath)

        While Not FileReader.EndOfStream
            Console.WriteLine(FileReader.ReadLine)
        End While

        FileReader.Close()
    End Sub

    MustOverride Sub Write(Data As String, Append As Boolean)
    MustOverride  Sub WriteLine(Data As String, Append As Boolean)

    Public Function GetRawFileData() As String()
        If Not File.Exists(Me._FilePath) Then
            Return Array.Empty(Of String)
        End If

        Dim RawFileData As String() = Array.Empty(Of String)
        Dim FileReader As New StreamReader(Me._FilePath)

        While Not FileReader.EndOfStream
            Array.Resize(RawFileData, RawFileData.Length + 1)
            RawFileData(RawFileData.Length - 1) = FileReader.ReadLine
        End While

        FileReader.Close()
        Return RawFileData
    End Function

    Public Function GetFileData() As Dictionary(Of String, DataStructure)
        Dim FileData As New Dictionary(Of String, DataStructure)
        Dim FileReader As New StreamReader(Me._FilePath)

        While Not FileReader.EndOfStream
            Dim CurrentData As String() = FileReader.ReadLine.Split(" | ")

            Dim StructuredData As DataStructure
            StructuredData.Name = CurrentData(0)
            StructuredData.Email = CurrentData(1)

            FileData.Add(StructuredData.Name, StructuredData)
        End While

        FileReader.Close()
        Return FileData
    End Function

End Class
