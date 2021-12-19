using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseEntity.Entities;

[Table("student")]
public class Student
{
    [Key]
    [Column("id")]
    public long Id { get; set; }
    
    [Required]
    [Column("name")]
    public string Name { get; set; } = null!;
    [Required]
    [Column("surname")]
    public string Surname { get; set; } = null!;
    [Column("group_id")]
    public long GroupId { get; set; }
    public Group Group { get; set; } = null!;
}