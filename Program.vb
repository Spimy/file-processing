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

        'Dim Data = SerialProcessor.GetFileData()
        'Dim EmailOfSpimy As String = Data.GetValueOrDefault(
        '    "Spimy",
        '    New DataStructure With {.Email = "Does Not Exist"}
        ').Email
        'Console.WriteLine(EmailOfSpimy)

        Console.ReadKey()
    End Sub
End Module
