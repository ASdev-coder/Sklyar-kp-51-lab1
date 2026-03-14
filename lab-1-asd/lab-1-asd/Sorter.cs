namespace lab_1_asd;

public class Sorter
{
    public List<StudentResult> StudentResults;
    
    private SortStatistics _sortStatistics;
    private List<StudentResult> _controlData = new List<StudentResult>
    {
        new StudentResult("Anton", "Matan", 41),
        new StudentResult("Olena", "Algebra", 95),
        new StudentResult("Ihor", "Geometry", 12),
        new StudentResult("Maria", "Physics", 78),
        new StudentResult("Dmytro", "Matan", 55),
        new StudentResult("Svitlana", "Discrete Math", 88),
        new StudentResult("Oleh", "Algorithms", 34),
        new StudentResult("Yana", "Calculus", 100),
        new StudentResult("Viktor", "Linear Algebra", 67),
        new StudentResult("Anna", "Statistics", 49),
        new StudentResult("Max", "Matan", 0),
        new StudentResult("Julia", "Probability", 82),
        new StudentResult("Artem", "Optimization", 21),
        new StudentResult("Sofia", "Numerical Methods", 91),
        new StudentResult("Denys", "Logic", 59),
        new StudentResult("Kateryna", "Game Theory", 74)
    };
    public Sorter()
    {
        InitCollection();
    }
    public void AddResult(StudentResult result)
    {
        StudentResults.Add(result);
        Console.WriteLine($"Result for {result.Surname} added\n");
    }
    
    public void RemoveResult(string surname)
    {
        if (StudentResults.Count == 0)
        {
            Console.WriteLine("Collection is empty\n");
            return;
        }

        for (int i = 0; i < StudentResults.Count; i++)
        {
            if (StudentResults[i].Surname == surname)
            {
                StudentResults.Remove(StudentResults[i]);
                
                Console.WriteLine($"Result for {surname} removed\n");
                return;
            }
        }
        
        Console.WriteLine($"Result for {surname} not found\n");
    }

    public void PrintCollection()
    {
        foreach (var studentResult in StudentResults)
        {
            Console.WriteLine(studentResult);
        }
    }

    public void AddControlDataToCollection()
    {
        foreach (var studentResult in _controlData)
        {
            StudentResults.Add(studentResult);
        }

        Console.WriteLine("Control data successfully added\n");
    }
    
    public void Sort()
    {
        Console.WriteLine("Empty\n");   
    }
    
    public void PrintIntermediateResults()
    {
        Console.WriteLine("Empty\n");
    }
    
    public void PrintStatistics()
    {
        Console.WriteLine("Empty\n");   
    }
    
    private void InitCollection()
    {
        StudentResults = new List<StudentResult>();
    }
}