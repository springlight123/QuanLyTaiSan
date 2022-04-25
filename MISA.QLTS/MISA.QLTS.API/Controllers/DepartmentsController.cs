using MISA.QLTS.CORE.Entities;
using MISA.QLTS.CORE.Interface.Infrastructure;
using MISA.QLTS.CORE.Interface.Services;

namespace MISA.QLTS.API.Controllers
{
    public class DepartmentsController: MISABaseController<Department>
    {
        IDepartmentRepository _departmentRepository;
        IDepartmentService _departmentServices;
        /// <summary>
        /// Khởi tạo
        /// </summary>
        public DepartmentsController(IDepartmentRepository departmentRepository, IDepartmentService departmentServices) : base(departmentRepository, departmentServices)
        {
            _departmentRepository = departmentRepository;
            _departmentServices = departmentServices;
        }
    }
}
