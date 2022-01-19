Imports System

Public Structure DataStructure
    Dim Name As String
    Dim Email As String
End Structure

Module Program
    Sub Main(args As String())
        With New MainMenu()
            .Display()
            .SelectOption()
        End With
    End Sub
End Module
