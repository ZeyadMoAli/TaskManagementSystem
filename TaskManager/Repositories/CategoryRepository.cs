using Microsoft.EntityFrameworkCore;
using TaskManager.Context;
using TaskManager.DTOs.Category;
using TaskManager.Interfaces;
using TaskManager.Models;

namespace TaskManager.Repositories;

public class CategoryRepository: ICategoryRepository
{
    private readonly MyDbContext _context;

    public CategoryRepository(MyDbContext context)
    {
        _context = context;
    }
    public async Task<Category?> GetCategoryByNameAsync(string categoryName)
    {
        if(string.IsNullOrEmpty(categoryName))
            return null;
        
        categoryName = categoryName.ToLower();

        return await _context.Categories.FirstOrDefaultAsync(c => c.Name.ToLower() == categoryName);

    }

    public async Task<Category?> GetCategoryByIdAsync(int categoryId)
    {
        return await _context.Categories.FirstOrDefaultAsync(c => c.Id == categoryId);
    }

    public async Task<List<Category>> GetCategoriesAsync()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task<Category?> CreateCategoryAsync(Category category)
    {
        var checkedCategory = await GetCategoryByNameAsync(category.Name);
        if (checkedCategory != null)
            return null;
        
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
        return category;
    }

    public async Task<Category?> UpdateCategoryAsync(int id , UpdateCategoryRequestDto request)
    {
        var category = await GetCategoryByIdAsync(id);
        
        if(category == null)
            return null;
        
        var checkedCategory = await GetCategoryByNameAsync(request.Name);
        
        if(checkedCategory != null)
            return null;
        
        category.Name = request.Name;
        await _context.SaveChangesAsync();
        return category;
    }

    public async Task<Category?> DeleteCategoryAsync(int id)
    {
        var category = await GetCategoryByIdAsync(id);
        if(category == null)
            return null;
        _context.Categories.Remove(category);
        await _context.SaveChangesAsync();
        return category;
        
    }
}