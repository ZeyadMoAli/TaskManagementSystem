using System.ComponentModel.DataAnnotations;

namespace TaskManager.DTOs.Status;

public class UpdateStatusRequestDto
{
    [Required][MaxLength(50)]
    public string Name { get; set; } = null!;

}