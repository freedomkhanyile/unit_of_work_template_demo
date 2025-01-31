using dotnet_verify.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace template_demo.Domain.Models
{
    public class User : AuditEntity<Guid>
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? StaffNumber { get; set; }
    }
}
