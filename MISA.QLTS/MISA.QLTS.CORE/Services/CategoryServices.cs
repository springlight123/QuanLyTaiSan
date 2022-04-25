using MISA.QLTS.CORE.Entities;
using MISA.QLTS.CORE.Interface.Infrastructure;
using MISA.QLTS.CORE.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QLTS.CORE.Services
{
    public class CategoryServices : BaseServices<FixedAssetCategory>, ICategoryService
    {
        // Tạo dependency injection
        ICategoryRepository _categoryRepository;
        public CategoryServices(ICategoryRepository categoryRepository) : base(categoryRepository)
        {

            _categoryRepository = categoryRepository;
        }
    }
}
