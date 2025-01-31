using dotnet_verify.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace template_demo.Domain.Models
{
    public class Asset : AuditEntity<Guid>
    {
        public string? Description { get; set; }
    }
}
