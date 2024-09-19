using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Context;
using TaskManagementSystem.Interfaces;
using TaskManagementSystem.Models;
using TaskManagementSystem.DTOs.User;

namespace TaskManagementSystem.Repositories;

public class UserRepository: IUserRepository
{
    private readonly MyDbContext _context;

    public UserRepository(MyDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<User>> GetAllUsersAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User?> GetUserByIdAsync(int id)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
    }
    
    public async Task<bool> IsEmailTakenAsync(string email)
    {
        if(string.IsNullOrEmpty(email) )
            return true;
        return await _context.Users.AnyAsync(u => u.Email == email);
    }
    

    public async Task<User> CreateUserAsync(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();

        return user;
    }

    public async Task<User?> UpdateUserAsync(int id, UpdateUserRequestDto userDto)
    {
        var userModel = await GetUserByIdAsync(id);

        if (userModel == null)
            return null;
        
        if(userDto.Email != userModel.Email && await  IsEmailTakenAsync(userDto.Email))
            return null;
        
        userModel.FirstName = userDto.FirstName;
        userModel.LastName = userDto.LastName;
        userModel.Email = userDto.Email;
        
        await _context.SaveChangesAsync();
        
        return userModel;
    }

    public async Task<User?> DeleteUserAsync(int id)
    {
        var user = await GetUserByIdAsync(id);
        if (user == null)
            return null;
        
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        
        return user;
    }
}