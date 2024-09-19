using TaskManagementSystem.Models;
using TaskManagementSystem.DTOs.User;

namespace TaskManagementSystem.Interfaces;

public interface IUserRepository
{
    public Task<List<User>> GetAllUsersAsync();
    
    public Task<User?> GetUserByIdAsync(int id);
    
    public Task<bool> IsEmailTakenAsync(string email);
    
    public Task<User> CreateUserAsync(User user);
    
    public Task<User?> UpdateUserAsync(int id, UpdateUserRequestDto userDto);
    public Task<User?> DeleteUserAsync(int id);
    
    
    
}