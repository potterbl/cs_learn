using REST_API.Data.Interfaces;
using REST_API.Data.Models;

namespace REST_API.Data.Services;

public class EfUserService : IUser
{
    private readonly ApplicationDbContext _context;

    public EfUserService(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<User> AllUsers => _context.Users.ToList();

    public User CreateUser(User user)
    {
        var newUser = new User
        {
            Login = user.Login,
            Username = user.Username,
            Password = user.Password
        };

        _context.Users.Add(newUser);
        _context.SaveChanges();
        
        return newUser;
    }
}