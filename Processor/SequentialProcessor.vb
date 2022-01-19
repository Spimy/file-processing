Imports System.IO

Public Class SequentialProcessor : Inherits FileProcessor

    Public Sub New(FileName As String)
        MyBase.New(FileName)
    End Sub

    Overrides Sub Write(Data As String, Append As Boolean)
        Me.WriteLine(Data, Append)
    End Sub

    Public Overrides Sub WriteLine(Data As String, Append As Boolean)
        If Append Then
            Dim RawFileData As String() = Me.GetRawFileData()
            Array.Resize(RawFileData, RawFileData.Length + 1)

            RawFileData(RawFileData.Length - 1) = Data
            Me.BubbleSort(RawFileData)

            Dim FileWriter As New StreamWriter(Me._FilePath, False)
            FileWriter.WriteLine(String.Join(Environment.NewLine, RawFileData))
            FileWriter.Close()
        Else
            Dim FileWriter As New StreamWriter(Me._FilePath, True)
            FileWriter.WriteLine(Data)
            FileWriter.Close()
        End If
    End Sub

    Public Sub BubbleSort(DataArray As String())
        Dim Swapped As Boolean = True

        While Swapped
            Swapped = False
            For i As Integer = 0 To DataArray.Length - 2
                If DataArray(i) > DataArray(i + 1) Then
                    Dim Temp = DataArray(i)
                    DataArray(i) = DataArray(i + 1)
                    DataArray(i + 1) = Temp
                    Swapped = True
                End If
            Next
        End While
    End Sub

End Class
