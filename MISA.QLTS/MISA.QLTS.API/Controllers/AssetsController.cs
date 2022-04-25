using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.QLTS.CORE.Entities;
using MISA.QLTS.CORE.Exceptions;
using MISA.QLTS.CORE.Interface.Infrastructure;
using MISA.QLTS.CORE.Interface.Services;
namespace MISA.QLTS.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AssetsController : MISABaseController<FixedAsset>
    {
        IAssetRepository _assetRepository;
        IAssetService _assetServices;
        /// <summary>
        /// Khởi tạo
        /// </summary>
        public AssetsController(IAssetRepository assetRepository, IAssetService assetServices) : base(assetRepository, assetServices)
        {
            _assetRepository = assetRepository;
            _assetServices = assetServices;
        }     
    }
}
