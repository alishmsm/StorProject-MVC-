using Bugeto_Store.Common.Roles;
using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexts;
using Store.Domain.Entities.Users;

namespace Store.Persistence.Contexts;

public class DataBaseContext : DbContext,IDataBaseContext
{
    public DataBaseContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {
    }
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserInRole> UserInRoles { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>().HasData(new Role { Id = 1, RoleName = nameof(UserRoles.Admin) });
        modelBuilder.Entity<Role>().HasData(new Role { Id = 2, RoleName = nameof(UserRoles.Operator) });
        modelBuilder.Entity<Role>().HasData(new Role { Id = 3, RoleName = nameof(UserRoles.Customer) });
    }
    
}