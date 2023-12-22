using Microsoft.EntityFrameworkCore;
using REST_API.Data.Models;

namespace REST_API.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<User> Users { get; set; }
}