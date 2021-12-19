using DatabaseEntity.Entities;
using Microsoft.EntityFrameworkCore;

namespace DatabaseEntity.Context;

public sealed class ApplicationContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Group> Groups { get; set; }

    public ApplicationContext()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(SqlHelperExtension.GetPostgresConnectionString());
}