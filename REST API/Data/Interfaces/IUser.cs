using REST_API.Data.Models;

namespace REST_API.Data.Interfaces;

public interface IUser 
{
    IEnumerable<User> AllUsers { get; }
    // User ById { get; }
    User CreateUser(User user);
}