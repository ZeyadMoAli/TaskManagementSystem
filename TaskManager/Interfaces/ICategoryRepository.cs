using TaskManager.DTOs.Category;
using TaskManager.Models;

namespace TaskManager.Interfaces;

public interface ICategoryRepository
{
    public Task<Category?> GetCategoryByNameAsync(string categoryName);
    public Task<Category?> GetCategoryByIdAsync(int categoryId);
    public Task<List<Category>> GetCategoriesAsync();
    public Task<Category?> CreateCategoryAsync(Category category);
    public Task<Category?> UpdateCategoryAsync(int id , UpdateCategoryRequestDto request);
    public Task<Category?> DeleteCategoryAsync(int id);
    
    
}