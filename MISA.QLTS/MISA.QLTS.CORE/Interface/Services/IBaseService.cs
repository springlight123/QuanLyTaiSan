using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QLTS.CORE.Interface.Services
{
    public interface IBaseService<MisaEnity>
    {
        /// <summary>
        /// Service thêm dữ liệu
        /// </summary>
        /// <typeparam name="int">type trả về</typeparam> 
        /// <returns>Integer</returns>
        /// CreatedBy:Nguyễn Xuân Quang(23/01/2022)
        int InsertService(MisaEnity enity);
        /// <summary>
        /// Service sửa  dữ liệu
        /// </summary>
        /// <typeparam name="int">type trả về</typeparam> 
        /// <returns>Integer</returns>
        /// CreatedBy:Nguyễn Xuân Quang(23/01/2022)
        int UpdateService(MisaEnity enity, Guid enityId);
    }
}
