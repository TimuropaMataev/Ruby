namespace Ruby.DAL.Objects;

public class User
{
    public int Id { get; set; }

    public int Number { get; set; }

    public string? Name { get; set; }

    public int Age { get; set; }

    public string? Phone { get; set; }

    public string? Skill { get; set; }

    public int Salary { get; set; }

    public DateTime DateTime { get; set; } = DateTime.Now;
}