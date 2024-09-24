using System.ComponentModel.DataAnnotations;

namespace TaskManager.DTOs.Status;

public class CreateStatusRequestDto
{
    [Required][MaxLength(50)]
    public string Name { get; set; } = null!;

}