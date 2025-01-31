using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using template_demo.Application.Dtos.AssetDtos;
using template_demo.Domain.Models;

namespace template_demo.Application.Helpers.Extensions
{
    public static class AssetExtensions
    {
        public static AssetDto ToModel(this Asset model)
        {
            return new AssetDto
            {
                AssetId = model.Id,
                Description = model.Description,
                CreateDate = model.CreateDate,
                CreateUserId = model.CreateUserId,
                ModifyDate = model.ModifyDate,
                ModifyUserId = model.ModifyUserId,
                IsActive = model.IsActive,
                StatusId = model.StatusId
            };
        }

        public static Asset ToEntity(this AddAssetDto model)
        {
            return new Asset
            {
                Description = model.Description,
                CreateDate = DateTime.Now,
                CreateUserId = model.CreateUserId!,
                ModifyDate = DateTime.Now,
                ModifyUserId = model.ModifyUserId!,
                IsActive = true,
                StatusId = 1
            };
        }
        public static Asset ToEntity(this EditAssetDto model, Asset entity)
        {
            entity.Description = model.Description;
            entity.ModifyDate = DateTime.Now;
            entity.ModifyUserId = model.ModifyUserId!;
            entity.IsActive = model.IsActive;
            entity.StatusId = model.StatusId;
            return entity;
        }
    }
}
