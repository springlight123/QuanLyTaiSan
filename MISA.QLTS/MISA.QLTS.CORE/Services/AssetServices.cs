using MISA.QLTS.CORE.Entities;
using MISA.QLTS.CORE.Exceptions;
using MISA.QLTS.CORE.Interface.Infrastructure;
using MISA.QLTS.CORE.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QLTS.CORE.Services
{
    public class AssetServices : BaseServices<FixedAsset>,IAssetService
    {
        // Tạo dependency injection
        IAssetRepository _assetRepository;
        public AssetServices(IAssetRepository assetRepository):base(assetRepository)
        {

            _assetRepository = assetRepository;
        }
    }
}
