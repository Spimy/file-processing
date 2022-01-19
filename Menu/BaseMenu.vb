Public MustInherit Class BaseMenu

    Protected ReadOnly MenuContext As String()

    Sub New(MenuContext As String())
        Me.MenuContext = MenuContext
    End Sub

    Protected Sub Display(Optional MenuTitle As String = Nothing)
        Console.Clear()

        If Not MenuTitle Is Nothing Then
            Console.WriteLine("-= {0} =-", MenuTitle)
        End If

        Console.WriteLine(String.Join(Environment.NewLine, MenuContext))
    End Sub
    Protected Function SelectOption() As Integer
        Dim MenuOption As Integer = 0

        While MenuOption < 1 Or MenuOption > Me.MenuContext.Length
            Console.Write("Option: ")
            MenuOption = Console.ReadLine
        End While

        Console.Clear()
        Return MenuOption
    End Function

End Class
