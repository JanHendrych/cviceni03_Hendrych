namespace DelegateLib;

public class Student
{
    public string? Name { get; set; }
    public int Number { get; init; }
    public Faculty? Faculty { get; set; }

    public Student()
    {
    }
    public Student(string? name, int number, Faculty faculty)
    {
        Name = name;
        Number = number;
        Faculty = faculty;
    }

    public override string? ToString()
    {
        return $"{Name} ({Number}, {Faculty})";
    }
}
