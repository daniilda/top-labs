using DatabaseEntity.Context;
using DatabaseEntity.Entities;

namespace DatabaseEntity;

public static class Program
{
    public static async Task Main(string[] args)
    {
        await using var db = new ApplicationContext();
        db.Students.Add(new Student { Name = "Kek", Surname = "Bel", Group = new Group{DepartmentId = 10, EndYear = 11, StartYear = 12, Title = "LOL"}});
        var a = db.Students.FirstOrDefault(x => x.Id == 1);
        a!.Name = "POP";
        await db.SaveChangesAsync();
    }
} 