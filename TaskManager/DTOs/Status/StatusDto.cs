using System.ComponentModel.DataAnnotations;

namespace TaskManager.DTOs.Status;

public class StatusDto
{
    [Required]
    public int Id { get; set; }
    [Required][MaxLength(50)]
    public string Name { get; set; } = null!;
}