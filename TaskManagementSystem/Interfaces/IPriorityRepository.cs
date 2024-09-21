using TaskManagementSystem.DTOs.Priority;
using TaskManagementSystem.Models;
using Task = TaskManagementSystem.Models.Task;

namespace TaskManagementSystem.Interfaces;

public interface IPriorityRepository
{
    public Task<List<Priority>> GetPrioritiesAsync();
    public Task<Priority?> GetPriorityByIdAsync(int priorityId);
    public Task<Priority?> GetPriorityByNameAsync(string priorityName);
    public Task<Priority?> CreatePriorityAsync(Priority priority);
    public Task<Priority?> UpdatePriorityAsync(int id, UpdatePriorityRequestDto priorityDto);
    public Task<Priority?> DeletePriorityAsync(int id);
    
}