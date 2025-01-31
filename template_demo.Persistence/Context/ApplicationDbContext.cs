using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using template_demo.Application;
using template_demo.Domain.Models;

namespace template_demo.Persistence.Context
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Asset> Assets { get; set; }
        DbSet<T> IApplicationDbContext.Set<T>() => base.Set<T>();
        public async Task<int> SaveChangesAsync() => await base.SaveChangesAsync();
    }
}
