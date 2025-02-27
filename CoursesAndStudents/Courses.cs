using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Packt.Shared;

public class Course
{
    public int CourseId { get; set; }

    [Required]
    [StringLength(60)] // For SQL Server.
    [Column(TypeName = "text(60)")] // For SQLite.
    public string? Title { get; set; }

    public ICollection<Student>? Students { get; set; }
}