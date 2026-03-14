using lab_1_asd.Enums;

namespace lab_1_asd;

public class Sorter
{
    public List<StudentResult> StudentResults;
    public bool IsSorted { get; set; } = false;
    
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
        IsSorted = false;
        Console.WriteLine($"Result for: {result.Surname} - added\n");
    }
    
    public void RemoveResult(string surname)
    {
        if (StudentResults.Count == 0)
        {
            Console.WriteLine("\nCollection is empty\n");
            return;
        }

        for (int i = 0; i < StudentResults.Count; i++)
        {
            if (StudentResults[i].Surname == surname)
            {
                StudentResults.Remove(StudentResults[i]);
                
                Console.WriteLine($"\nResult for: {surname} - removed\n");
                return;
            }
        }
        
        Console.WriteLine($"\nResult for: {surname} - not found\n");
    }

    public void PrintCollection()
    {
        if(StudentResults.Count == 0) 
        {
            Console.WriteLine("\nCollection is empty\n");
            return;
        }
        
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

        IsSorted = false;
        
        Console.WriteLine("\nControl data successfully added\n");
    }
    
    public void Sort()
    {
        if(StudentResults.Count == 0) 
        {
            Console.WriteLine("\nCollection is empty\n");
            return;
        }
        
        if (IsSorted)
        {
            Console.WriteLine("\nCollection is already sorted\n");
            return;
        }
        
        _sortStatistics = new SortStatistics();
        DateTime startTime = DateTime.Now;
        
        int max = FindMaxScore();
        _sortStatistics.Passes++;
        PrintIntermediateSteps(1, $"Found max score: {max}");
        
        List<List<StudentResult>> countList = GetCountList(max);
        _sortStatistics.Passes++;
        PrintIntermediateSteps(2, $"Initialized {max + 1} empty counting list");
        
        FillCountList(countList);
        _sortStatistics.Passes++;
        PrintIntermediateSteps(3, "Distributed all students into buckets based on their scores", countList);
        
        int collectionCounter = 0;
        for (int i = max; i >= 0; i--)
        {
            _sortStatistics.LoopIterations++;
            int counter = countList[i].Count;
            while (counter > 0)
            {
                _sortStatistics.LoopIterations++;
                StudentResults[collectionCounter] = countList[i][counter - 1];
                _sortStatistics.Copies++;
                collectionCounter++;
                counter--;
            }
        }
        _sortStatistics.Passes++;
        PrintIntermediateSteps(4, "Reassembled the main collection from countin list");

        DateTime endTime = DateTime.Now;
        IsSorted = true;
        _sortStatistics.ExecutionTimeMs = (endTime - startTime).TotalMilliseconds;
    }
    
    public void PrintIntermediateSteps(int stepNumber, string description, List<List<StudentResult>>? countList = null)
    {
        Console.Write("------------------------------------------------");
        Console.WriteLine($"\n>> STEP {stepNumber}: {description}");
    

        if (countList != null)
        {
            Console.WriteLine("Current counting list state:");
            for (int i = 0; i < countList.Count; i++)
            {
                if (countList[i].Count > 0)
                {
                    string students = "";
    
                    foreach (var s in countList[i])
                    {

                        students += s.Surname + ", ";
                    }
                    
                    if (students.Length > 0)
                    {
                        students = students.Substring(0, students.Length - 2);
                    }

                    Console.WriteLine($"  [Score {i:D3}]: {students}");
                }
            }
        }
        Console.WriteLine("------------------------------------------------");
    }
    
    public void PrintStatistics()
    {
        if (_sortStatistics == null)
        {
            Console.WriteLine("\nNo statistics available.\n Run Sort first\n");
            return;
        }
        _sortStatistics.Print();
    }  
    
    private void InitCollection()
    {
        StudentResults = new List<StudentResult>();
    }

    private int FindMaxScore()
    {
        if (StudentResults.Count == 0) return 0;

        int maxScore = StudentResults[0].Score;

        for (int i = 1; i < StudentResults.Count; i++)
        {
            _sortStatistics.LoopIterations++;
            _sortStatistics.Comparisons++;
            if (StudentResults[i].Score > maxScore)
            {
                maxScore = StudentResults[i].Score;
            }
        }

        return maxScore;
    }
    
    private List<List<StudentResult>> GetCountList(int max)
    {
        List<List<StudentResult>> countList = new List<List<StudentResult>>();
        
        for (int i = 0; i < max+1; i++)
        {
            _sortStatistics.LoopIterations++;
            countList.Add(new List<StudentResult>());
        }

        return countList;
    }
    
    private void FillCountList(List<List<StudentResult>> countList)
    {
        foreach (var studentResult in StudentResults)
        {
            FillPassResults(studentResult);
            _sortStatistics.LoopIterations++;
            countList[studentResult.Score].Add(studentResult);
            _sortStatistics.Copies++;
        }
    }
    
    private void FillPassResults(StudentResult studentResult)
    {
        if (studentResult.Score >= (int)PassResult.PassedExcellent)
        {
            _sortStatistics.PassResults[3]++;
        }
        else if (studentResult.Score >= (int)PassResult.PassedWell &&
                 studentResult.Score < (int)PassResult.PassedExcellent)
        {
            _sortStatistics.PassResults[2]++;
        }
        else if (studentResult.Score >= (int)PassResult.PassedSatisfactorily &&
                 studentResult.Score < (int)PassResult.PassedWell)
        {
            _sortStatistics.PassResults[1]++;
        }
        else
        {
            _sortStatistics.PassResults[0]++;
        }
        
    }
}