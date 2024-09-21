using TaskManagementSystem.DTOs.Category;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Interfaces;

public interface ICategoryRepository
{
    public Task<Category?> GetCategoryByNameAsync(string categoryName);
    public Task<Category?> GetCategoryByIdAsync(int categoryId);
    public Task<List<Category>> GetCategoriesAsync();
    public Task<Category?> CreateCategoryAsync(Category category);
    public Task<Category?> UpdateCategoryAsync(int id , UpdateCategoryRequestDto request);
    public Task<Category?> DeleteCategoryAsync(int id);
    
    
}