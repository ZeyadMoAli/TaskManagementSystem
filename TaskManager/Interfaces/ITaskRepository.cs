using TaskManager.DTOs.Priority;
using TaskManager.DTOs.Task;

namespace TaskManager.Interfaces;
using Task = TaskManager.Models.Task;

public interface ITaskRepository
{
    public Task<List<Task>> GetTasksAsync();
    public Task<Task?> GetTaskByTitleAsync(string title);
    public Task<Task?> GetTaskByIdAsync(int id);
    public Task<Task?> CreateTaskAsync(Task task);
    public Task<Task?> UpdateTaskAsync(int id, UpdateTaskRequestDto taskDto);
    public Task<Task?> DeleteTaskAsync(int id);
    public Task<bool> IsTaskAttributesValid(Task task);
    
}