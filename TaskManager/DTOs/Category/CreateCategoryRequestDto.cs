using System.ComponentModel.DataAnnotations;

namespace TaskManager.DTOs.Category;

public class CreateCategoryRequestDto
{
    [Required][MaxLength(50)]
    public string Name { get; set; } = null!;

}