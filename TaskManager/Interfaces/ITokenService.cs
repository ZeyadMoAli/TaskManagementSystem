using TaskManager.Models;

namespace TaskManager.Interfaces;

public interface ITokenService
{
    string CreateToken(User user);
}