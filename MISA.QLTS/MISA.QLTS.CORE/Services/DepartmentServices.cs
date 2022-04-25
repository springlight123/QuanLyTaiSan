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
    public class DepartmentServices : BaseServices<Department>, IDepartmentService
    {
        // Tạo dependency injection
        IDepartmentRepository _departmentRepository;
        public DepartmentServices(IDepartmentRepository departmentRepository) : base(departmentRepository)
        {

            _departmentRepository = departmentRepository;
        }
    }
}
