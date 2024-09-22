using Microsoft.EntityFrameworkCore;
using TaskManager.Context;
using TaskManager.DTOs.Task;
using TaskManager.Interfaces;
using Task = TaskManager.Models.Task;

namespace TaskManager.Repositories;

public class TaskRepository:ITaskRepository
{
    private readonly MyDbContext _context;
    private readonly IStatusRepository _statusRepository;
    private readonly IPriorityRepository _priorityRepository;
    private readonly ICategoryRepository _categoryRepository;

    public TaskRepository(MyDbContext context,  IStatusRepository statusRepository,IPriorityRepository priorityRepository, ICategoryRepository categoryRepository)
    {
        _context = context;
        _statusRepository = statusRepository;
        _priorityRepository = priorityRepository;
        _categoryRepository = categoryRepository;
    }
    public async Task<List<Task>> GetTasksAsync()
    {
        return await _context.Tasks.ToListAsync();
    }

    public async Task<Task?> GetTaskByTitleAsync(string title)
    {
        return await _context.Tasks.FirstOrDefaultAsync(t => t.Title.ToLower() == title.ToLower());
    }

    public async Task<Task?> GetTaskByIdAsync(int id)
    {
        return await _context.Tasks.FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<Task?> CreateTaskAsync(Task task)
    {
        var newTask = await GetTaskByTitleAsync(task.Title);
        if (newTask != null)
            return null;
        
        if(await IsTaskAttributesValid(task)==false)
            return null;
        
        await _context.Tasks.AddAsync(task);
        await _context.SaveChangesAsync();
        return task;
    }

    public async Task<Task?> UpdateTaskAsync(int id, UpdateTaskRequestDto taskDto)
    {
        var task = await GetTaskByIdAsync(id);
        
        if (task == null)
            return null;
        
        if (await GetTaskByTitleAsync(taskDto.Title) != null)
            return null;
        
        if(await IsTaskAttributesValid(taskDto) == false)
            return null;
        
        
        task.Title = taskDto.Title;
        task.Description = taskDto.Description;
        task.DeadLine = taskDto.DeadLine;
        task.CategoryId = taskDto.CategoryId;
        task.StatusId = taskDto.StatusId;
        task.CategoryId = taskDto.CategoryId;
        task.PriorityId = taskDto.PriorityId;

        await _context.SaveChangesAsync();
        return task;
        
    }

    public async Task<Task?> DeleteTaskAsync(int id)
    {
        var task = await  GetTaskByIdAsync(id);
        if(task == null)
            return null;
        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();
        return task;
    }

    public async Task<bool> IsTaskAttributesValid(Task task)
    {

        
        if(await _statusRepository.GetStatusByIdAsync(task.StatusId) == null)
            return false;
        
        if(await _priorityRepository.GetPriorityByIdAsync(task.PriorityId) == null)
            return false;
        
        if(await _categoryRepository.GetCategoryByIdAsync(task.CategoryId) == null)
            return false;
        
        return true;    }

    public async Task<bool> IsTaskAttributesValid(UpdateTaskRequestDto task)
    {
        if(await _statusRepository.GetStatusByIdAsync(task.StatusId) == null)
            return false;
        
        if(await _priorityRepository.GetPriorityByIdAsync(task.PriorityId) == null)
            return false;
        
        if(await _categoryRepository.GetCategoryByIdAsync(task.CategoryId) == null)
            return false;
        
        return true;
    }
}