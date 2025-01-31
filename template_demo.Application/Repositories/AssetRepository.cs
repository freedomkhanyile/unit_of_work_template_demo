using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using template_demo.Domain.Models;

namespace template_demo.Application.Repositories
{
    public interface IAssetRepository : IGenericRepository<Asset> { }
    public class AssetRepository : GenericRepository<Asset>, IAssetRepository
    {
        public AssetRepository(IApplicationDbContext context) : base(context) { }
    }
}
