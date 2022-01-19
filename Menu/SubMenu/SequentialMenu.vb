Public Class SequentialMenu : Inherits BaseMenu

    Private SequentialProcessor As New SequentialProcessor("users_sequential.txt")

    Sub New()
        MyBase.New({
            "1. Read from file",
            "2. Write to file",
            "3. Get email from name",
            "4. Back to main menu"
        })
    End Sub

    Public Overloads Sub Display()
        MyBase.Display("Sequential Processor")
    End Sub

    Public Overloads Sub SelectOption()
        Dim MenuOption As Integer = MyBase.SelectOption()

        Select Case MenuOption
            Case 1 : SequentialProcessor.ReadFile()
            Case 2 : WriteToFile()
            Case 3 : GetEmailFromName()
            Case 4
                With New MainMenu()
                    .Display()
                    .SelectOption()
                End With
        End Select

        Console.WriteLine() ' Blank line for spacing
        Console.WriteLine("Press any key to continue...")
        Console.ReadKey()

        Me.Display()
        Me.SelectOption()
    End Sub

    Sub WriteToFile()
        Console.Write("Name: ")
        Dim Name As String = Console.ReadLine

        Console.Write("Email: ")
        Dim Email As String = Console.ReadLine

        SequentialProcessor.WriteLine(SequentialProcessor.FormatData(Name, Email), True)
    End Sub

    Sub GetEmailFromName()
        Console.Write("Name: ")
        Dim Name As String = Console.ReadLine()

        Dim FileData = SequentialProcessor.GetFileData()
        Dim UserData = FileData.GetValueOrDefault(Name, New DataStructure With {.Email = "Not Found"})

        Console.WriteLine("Email for {0}: {1}", Name, UserData.Email)
    End Sub

End Class
