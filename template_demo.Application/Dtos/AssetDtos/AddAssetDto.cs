using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace template_demo.Application.Dtos.AssetDtos
{
    public class AddAssetDto
    {
        public string? Description { get; set; }        
        public string? CreateUserId { get; set; }        
        public string? ModifyUserId { get; set; }
    }
}
