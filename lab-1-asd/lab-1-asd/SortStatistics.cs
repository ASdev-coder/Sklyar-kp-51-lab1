using lab_1_asd.Enums;

public class SortStatistics
{
    public int Comparisons { get; set; }
    public int Passes { get; set; }
    public int LoopIterations { get; set; }
    public int Copies { get; set; }
    public double ExecutionTimeMs { get; set; }
    public int[] PassResults = new int[4];

    public void Print()
    {
        Console.WriteLine("=== Sort Statistics (Algorithm part) ===");
        Console.WriteLine($"Time taken: {ExecutionTimeMs:F4} ms");
        Console.WriteLine($"Passes was - main steps: {Passes}");
        Console.WriteLine($"Loop iterations was passed: {LoopIterations}");
        Console.WriteLine($"Copies: {Copies}");
        Console.WriteLine($"Comparisons: {Comparisons} - not primary for this algorithm");
        Console.WriteLine("=== Sort Statistics (Data part) ===");
        Console.WriteLine($"Count of not passed students: {PassResults[0]}");
        Console.WriteLine($"Count of passed satisfactorily students: {PassResults[1]}");
        Console.WriteLine($"Count of passed well students: {PassResults[2]}");
        Console.WriteLine($"Count of passed excellent students: {PassResults[3]}");
        Console.WriteLine($"Count of all passed: {PassResults[1] + PassResults[2] + PassResults[3]}");
        Console.WriteLine("=======================\n");
    }
}