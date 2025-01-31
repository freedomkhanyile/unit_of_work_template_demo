using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using template_demo.Application.Repositories;

namespace template_demo.Application.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IAssetRepository Assets { get; }
        Task<int> CompleteAsync();
    }
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IApplicationDbContext _context;

        public UnitOfWork(IApplicationDbContext context,
            IUserRepository users, IAssetRepository assets)
        {
            _context = context;
            Users = users;
            Assets = assets;
        }

        public IUserRepository Users { get; }

        public IAssetRepository Assets { get; }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
