Public Class MainMenu : Inherits BaseMenu

    Sub New()
        MyBase.New({
            "1. Serial File Processor",
            "2. Sequential File Processor",
            "3. Exit"
        })
    End Sub

    Public Overloads Sub Display()
        MyBase.Display("File Processor")
    End Sub

    Public Overloads Sub SelectOption()
        Dim MenuOption As Integer = MyBase.SelectOption()

        Select Case MenuOption
            Case 1
                With New SerialMenu()
                    .Display()
                    .SelectOption()
                End With
            Case 2
                With New SequentialMenu()
                    .Display()
                    .SelectOption()
                End With
            Case Else
                Environment.Exit(0)
        End Select
    End Sub
End Class
