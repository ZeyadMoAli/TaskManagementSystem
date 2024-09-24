using System.ComponentModel.DataAnnotations;

namespace TaskManager.DTOs.Category;

public class CategoryDto
{
    [Required]
    public int Id { get; set; }
    [Required][MaxLength(50)]
    public string Name { get; set; } = null!;

}