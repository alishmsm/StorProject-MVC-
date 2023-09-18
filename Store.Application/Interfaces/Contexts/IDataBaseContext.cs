﻿using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities.Users;

namespace Store.Application.Interfaces.Contexts;

public interface IDataBaseContext
{
    DbSet<User> Users { get; set; }
    DbSet<Role> Roles { get; set; }
    DbSet<UserInRole> UserInRoles { get; set; }
    
    int SaveChanges(bool acceptAllChangesOnSuccess);
    int SaveChanges();
    Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
}