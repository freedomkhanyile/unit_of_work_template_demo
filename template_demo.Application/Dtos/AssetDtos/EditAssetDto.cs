using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace template_demo.Application.Dtos.AssetDtos
{
    public class EditAssetDto
    {
        public Guid AssetId { get; set; }
        public string? Description { get; set; }
        public string? ModifyUserId { get; set; }
        public bool IsActive { get; set; }
        public int StatusId { get; set; }
    }
}
