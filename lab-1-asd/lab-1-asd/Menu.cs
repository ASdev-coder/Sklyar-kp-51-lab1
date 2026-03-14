namespace lab_1_asd;

public static class Menu
{
    public static string[] MenuItems =
    [
        "Add Student Result", "Remove Student Result",
        "Print Collection", "Add Control Data", "Sort",
        "Print Statistics", "Exit"
    ];

    public static void PrintMenu()
    {
        Console.WriteLine();
        
        for (int i = 0; i < MenuItems.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {MenuItems[i]}");
        }
        Console.Write("\nSelect an option: ");
    }
    
    public static int GetOption()
    {
        bool isInt = int.TryParse(Console.ReadLine(), out int option);

        if (isInt && option <= MenuItems.Length && option > 0)
        {
            return option;
        }
        
        return -1;
    }
}