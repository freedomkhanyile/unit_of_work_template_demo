using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using template_demo.Domain.Models;

namespace template_demo.Application.Repositories
{
    public interface IUserRepository: IGenericRepository<User> { }
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(IApplicationDbContext context) : base(context) { }

    }
}
