using lab_1_asd.Enums;

namespace lab_1_asd;

class Program
{
    public static Sorter Sorter = new Sorter();
    static void Main(string[] args)
    {
        while(true)
        {
            Menu.PrintMenu();
            int option = Menu.GetOption();

            switch (option)
            {
                case 1:
                    AddResult();
                    break;
                case 2:
                    RemoveResult();
                    break;
                case 3:
                    Program.Sorter.PrintCollection();
                    break;
                case 4:
                    Program.Sorter.AddControlDataToCollection();
                    break;
                case 5:
                    Program.Sorter.Sort();
                    break;
                case 6:
                    Program.Sorter.PrintStatistics();
                    break;
                case 7:
                    Console.WriteLine("Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
    static StudentResult GetResult()
    {
        string surname = GetStringInputWithConstraints(StringInputEnum.Surname);
        string discipline = GetStringInputWithConstraints(StringInputEnum.Discipline);
        int score = GetScoreInputWithConstraints();

        return new StudentResult(surname, discipline, score);
    }
    static string GetStringInputWithConstraints(StringInputEnum enumType)
    {
        while (true)
        {
            switch (enumType)
            {
                case StringInputEnum.Surname:
                    Console.Write("Enter surname: ");
                    break;
                case StringInputEnum.Discipline:
                    Console.Write("Enter discipline: ");
                    break;
                default:
                    Console.Write("Enter unknown: ");
                    break;
            }

            string input = Console.ReadLine();

            if (ValidateStringInput(input, enumType))
            {
                        
                return input;
            }
            
            Console.WriteLine("Invalid input. Please try again.");
        }
    }
    static bool ValidateStringInput(string input, StringInputEnum enumType)
    {
        if (string.IsNullOrWhiteSpace(input)) return false;
        
        return enumType switch
        {
            StringInputEnum.Surname => input.Length is > 3 and < 50,
            StringInputEnum.Discipline => input.Length is > 5 and < 70,
            _ => false
        };
    }
    static bool ValidateIntInput(int input)
    {
        return input >= 0 && input <= 100;
    }
    static int GetScoreInputWithConstraints()
    {
        while (true)
        {
            Console.Write("Enter score: ");
            bool isInt = int.TryParse(Console.ReadLine(), out int score);

            if (isInt && ValidateIntInput(score))
            {
                return score;
            }
            
            Console.WriteLine("Invalid input. Please try again.");
        }
        
    }
    static void AddResult()
    {
        Sorter.AddResult(GetResult());
    }
    static void RemoveResult()
    {
        Sorter.RemoveResult(GetStringInputWithConstraints(StringInputEnum.Surname));
    }
}