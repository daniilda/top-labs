using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseEntity.Entities;

[Table("groups")]
public class Group
{
    [Key]
    [Column("id")]
    public long Id { get; set; }
    [Required]
    [Column("title")]
    public string Title { get; init; } = null!;
    [Required]
    [Column("start_year")]
    public int StartYear { get; set; }
    [Required]
    [Column("end_year")]
    public int EndYear { get; set; }
    [Required]
    [Column("department_id")]
    public int DepartmentId { get; set; }
}