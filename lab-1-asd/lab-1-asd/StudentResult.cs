namespace lab_1_asd;

public class StudentResult
{
    public Guid StudentId { get; set; }
    public string Surname { get; set; }
    public string Discipline { get; set; }
    public int Score { get; set; }

    public StudentResult(string surname, string discipline, int score)
    {
        StudentId = Guid.NewGuid();
        Surname = surname;
        Discipline = discipline;
        Score = score;
    }
    
    public override string ToString()
    {
        return $"{Surname} {Discipline} {Score}";
    }
}