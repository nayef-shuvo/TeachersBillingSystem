using Microsoft.EntityFrameworkCore;
using TeachersBillingSystem.Server.Models;

namespace TeachersBillingSystem.Server.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Auth> Auths { get; set; }
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
        
    }
}
