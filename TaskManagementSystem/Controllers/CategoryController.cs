using Microsoft.AspNetCore.Mvc;
using TaskManagementSystem.DTOs.Category;
using TaskManagementSystem.Interfaces;
using TaskManagementSystem.Mappers;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryController(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    [HttpGet("ByID/{id}")]
    public async Task<IActionResult> GetCategoryById(int id)
    {
        var category = await _categoryRepository.GetCategoryByIdAsync(id);
        if (category == null)
            return NotFound();
        return Ok(category.ToDto());
    }

    [HttpGet("AllCategories")]
    public async Task<IActionResult> GetAllCategories()
    {
        var categories = await _categoryRepository.GetCategoriesAsync();
        var categoriesDto = categories.Select(c => c.ToDto());
        return Ok(categoriesDto);
    }


    [HttpGet("ByName/{name}")]
    public async Task<IActionResult> GetCategoryByName(string name)
    {
        var category = await _categoryRepository.GetCategoryByNameAsync(name);
        if (category == null)
            return NotFound();
        return Ok(category.ToDto());
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryRequestDto categoryRequestDto)
    {
        var category = categoryRequestDto.ToCategory();
        var result = await _categoryRepository.CreateCategoryAsync(category);
        if (result == null)
            return BadRequest();

        return CreatedAtAction(nameof(GetCategoryById), new { id = category.Id }, category.ToDto());

    }

    [HttpPut("UpdateCategory/{id}")]
    public async Task<IActionResult> UpdateCategory([FromRoute]int id ,[FromBody] UpdateCategoryRequestDto categoryRequestDto)
    {
        var category = await _categoryRepository.UpdateCategoryAsync(id, categoryRequestDto);
        if(category == null)
            return NotFound();
        
        return Ok(category.ToDto());
    }

    [HttpDelete("DeleteCategory/{id}")]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        var category = await _categoryRepository.DeleteCategoryAsync(id);
        if(category == null)
            return NotFound();
        return NoContent();
    }



}