using TaskManager.DTOs.Status;
using TaskManager.Models;

namespace TaskManager.Interfaces;

public interface IStatusRepository
{
    public Task<List<Status>> GetStatusesAsync();
    public Task<Status?> GetStatusByIdAsync(int id);
    public Task<Status?> GetStatusByNameAsync(string name);
    public Task<Status?> CreateStatusAsync(Status status);
    public Task<Status?> UpdateStatusAsync(int id, UpdateStatusRequestDto status);
    public Task<Status?> DeleteStatusAsync(int id);
}