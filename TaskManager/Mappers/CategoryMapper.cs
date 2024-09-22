using TaskManager.DTOs.Category;
using TaskManager.Models;

namespace TaskManager.Mappers;

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