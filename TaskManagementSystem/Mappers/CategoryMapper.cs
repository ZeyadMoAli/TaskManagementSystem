using TaskManagementSystem.DTOs.Category;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Mappers;

public static class CategoryMapper
{
    public static CategoryDto ToDto(this Category category)
    {
        return new CategoryDto() { Id = category.Id, Name = category.Name };
    }



    public static Category ToCategory(this CreateCategoryRequestDto category)
    {
        return new Category() { Name = category.Name };
    }
}