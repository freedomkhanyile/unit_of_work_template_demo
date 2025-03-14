using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using template_demo.Application.Dtos.AssetDtos;
using template_demo.Application.Helpers.Extensions;
using template_demo.Application.UnitOfWork;

namespace template_demo.Api.Controllers
{
    [Route("api/assets")]
    [ApiController]
    public class AssetsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AssetsController> _logger;
        public AssetsController(IUnitOfWork unitOfWork, ILogger<AssetsController> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<AssetDto>>> GetAssetsAsync(int pageNumber = 1, int pageSize = 10000)
        {
            try
            {
                var assets = await _unitOfWork.Assets.GetAllAsync(pageNumber, pageSize);
                var model = assets.Select(x => x.ToModel()).ToList();
                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ERR: Failed to fetch list of assets, msg: {Message}, ex: {Ex}", ex.Message, ex);
                throw new ApplicationException(ex.Message, ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AssetDto>> GetByIdAsync(Guid id)
        {
            try
            {
                var asset = await _unitOfWork.Assets.GetByIdAsync(id);
                var model = asset.ToModel();
                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ERR: Failed to fetch asset by id, msg: {Message}, ex: {Ex}", ex.Message, ex);
                throw new ApplicationException(ex.Message, ex);
            }
        }

        [HttpPost("add")]
        public async Task<ActionResult<AssetDto>> AddAssetAsync([FromBody] AddAssetDto model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var addAsset = model.ToEntity();
                await _unitOfWork.Assets.AddAsync(addAsset);
                await _unitOfWork.CompleteAsync();
                var response = await _unitOfWork.Assets.GetByIdAsync(addAsset.Id);

                return Ok(response?.ToModel());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ERR: Failed to create asset, msg: {Message}, ex: {Ex}", ex.Message, ex);
                throw new ApplicationException(ex.Message, ex);
            }
        }

        [HttpPut("update")]
        public async Task<ActionResult<AssetDto>> UpdateAssetAsync([FromBody] EditAssetDto model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var asset = await _unitOfWork.Assets.GetByIdAsync(model.AssetId);
                if (asset == null) return NotFound($"Asset with id: {model.AssetId} not found");
                var assetToUpdate = model.ToEntity(asset);
                await _unitOfWork.Assets.UpdateAsync(assetToUpdate);
                await _unitOfWork.CompleteAsync();
                var response = await _unitOfWork.Assets.GetByIdAsync(assetToUpdate.Id);
                return Ok(response?.ToModel());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "ERR: Failed to update asset, msg: {Message}, ex: {Ex}", ex.Message, ex);
                throw new ApplicationException(ex.Message, ex);
            }
        }
    }
}
