using MISA.QLTS.CORE.Entities;
using MISA.QLTS.CORE.Interface.Infrastructure;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
namespace MISA.QLTS.INFRASTRUCTURE.Repository
{
    public class AssetRepository : BaseRepository<FixedAsset>,IAssetRepository
    {
    }
}
