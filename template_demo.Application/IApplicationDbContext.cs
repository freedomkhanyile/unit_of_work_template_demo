using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using template_demo.Domain.Models;

namespace template_demo.Application
{
    public interface IApplicationDbContext
    {
        DbSet<User> Users { get; set; }      
        DbSet<Asset> Assets { get; set; }
        DbSet<T> Set<T>() where T : class;
        Task<int> SaveChangesAsync();
    }
}
