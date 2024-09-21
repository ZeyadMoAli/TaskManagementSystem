using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Context;
using TaskManagementSystem.DTOs.Priority;
using TaskManagementSystem.Interfaces;
using TaskManagementSystem.Models;

namespace TaskManagementSystem.Repositories;

public class PriorityRepository:IPriorityRepository
{
    private readonly MyDbContext _context;

    public PriorityRepository(MyDbContext context)
    {
        _context = context; 
    }
    public async Task<List<Priority>> GetPrioritiesAsync()
    {
        return await _context.Priorities.ToListAsync();
    }

    public async Task<Priority?> GetPriorityByIdAsync(int priorityId)
    {
        return await _context.Priorities.FirstOrDefaultAsync(x => x.Id == priorityId);
    }

    public async Task<Priority?> GetPriorityByNameAsync(string priorityName)
    {
        return await _context.Priorities.FirstOrDefaultAsync(x => x.Name.ToLower() == priorityName.ToLower());
    }

    public async Task<Priority?> CreatePriorityAsync(Priority priority)
    {
        var newPriority = await GetPriorityByNameAsync(priority.Name);
        if (newPriority != null)
            return null;
        await _context.Priorities.AddAsync(priority);
        await _context.SaveChangesAsync();
        return priority;
    }

    public async Task<Priority?> UpdatePriorityAsync(int id , UpdatePriorityRequestDto priorityDto)
    {
        var priority = await GetPriorityByIdAsync(id);
        if(priority == null)
            return null;
        var checkedPriority = await GetPriorityByNameAsync(priority.Name);
        if (checkedPriority != null)
            return null;
        priority.Name = priorityDto.Name;
        await _context.SaveChangesAsync();
        return priority;
    }

    public async Task<Priority?> DeletePriorityAsync(int id)
    {
        var priority = await GetPriorityByIdAsync(id);
        if(priority == null)
            return null;
        _context.Remove(priority);
        await _context.SaveChangesAsync();
        return priority;
    }
}