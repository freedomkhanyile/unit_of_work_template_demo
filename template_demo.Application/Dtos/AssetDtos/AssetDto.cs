using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace template_demo.Application.Dtos.AssetDtos
{
    public class AssetDto
    {
        public Guid AssetId { get; set; }
        public string? Description { get; set; }
        public DateTime CreateDate { get; set; }
        public string? CreateUserId { get; set; }
        public DateTime ModifyDate { get; set; }
        public string? ModifyUserId { get; set; }
        public bool IsActive { get; set; }
        public int StatusId { get; set; }

    }
}
