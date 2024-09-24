using Microsoft.EntityFrameworkCore;
using TaskManager.Context;
using TaskManager.DTOs.Status;
using TaskManager.Interfaces;
using TaskManager.Models;

namespace TaskManager.Repositories;

public class StatusRepository: IStatusRepository
{
    private readonly MyDbContext _context;

    public StatusRepository(MyDbContext context)
    {
        _context =context;
    }
    public async Task<List<Status>> GetStatusesAsync()
    {
        var statuses = await _context.Statuses.ToListAsync();
        return statuses;
    }

    public async Task<Status?> GetStatusByIdAsync(int id)
    {
        return await _context.Statuses.FirstOrDefaultAsync(s=>s.Id==id);
        
    }

    public async Task<Status?> GetStatusByNameAsync(string name)
    {
        return await _context.Statuses.FirstOrDefaultAsync(s=>s.Name.Equals(name,StringComparison.OrdinalIgnoreCase));
    }

    public async Task<Status?> CreateStatusAsync(Status status)
    {

        if (await GetStatusByNameAsync(status.Name) != null)
            return null;
        
        await _context.Statuses.AddAsync(status);
        
        await _context.SaveChangesAsync();
        return status;

    }

    public async Task<Status?> UpdateStatusAsync(int id, UpdateStatusRequestDto status)
    {
        var statusToUpdate = await GetStatusByIdAsync(id);
        if(statusToUpdate == null)
            return null;
        
        var checkName = await GetStatusByNameAsync(status.Name);
        if( statusToUpdate.Name!=status.Name &&  checkName != null)
            return null;
        statusToUpdate.Name = status.Name;
        await _context.SaveChangesAsync();
        return statusToUpdate;
    }

    public async Task<Status?> DeleteStatusAsync(int id)
    {
        var status = await GetStatusByIdAsync(id);
        if(status == null)
            return null;
        _context.Statuses.Remove(status);
        await _context.SaveChangesAsync();
        return status;
    }
}