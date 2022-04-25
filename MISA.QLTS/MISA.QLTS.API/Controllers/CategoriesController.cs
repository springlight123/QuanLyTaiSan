using MISA.QLTS.CORE.Entities;
using MISA.QLTS.CORE.Interface.Infrastructure;
using MISA.QLTS.CORE.Interface.Services;

namespace MISA.QLTS.API.Controllers
{
    public class CategoriesController : MISABaseController<FixedAssetCategory>
    {
        ICategoryRepository _categoryRepository;
        ICategoryService _categoryServices;
        /// <summary>
        /// Khởi tạo
        /// </summary>
        public CategoriesController(ICategoryRepository categoryRepository, ICategoryService categoryServices) : base(categoryRepository, categoryServices)
        {
            _categoryRepository = categoryRepository;
            _categoryServices = categoryServices;
        }
    }
}
