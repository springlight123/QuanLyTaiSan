using MISA.QLTS.CORE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QLTS.CORE.Interface.Infrastructure
{
    public interface IBaseRepository<MISAEnity>
    {
        /// <summary>
        /// Lấy toàn bộ dữ liệu
        /// </summary>
        /// <typeparam name="List MISAEnity">type của object</typeparam> 
        /// <returns>Danh sách Object</returns>
        /// CreatedBy:Nguyễn Xuân Quang(23/01/2022)
        IEnumerable<MISAEnity> GetAll();
        /// <summary>
        /// Lấy dữ liệu theo Id
        /// </summary>
        /// <typeparam name="Employee">type của object</typeparam> 
        /// <returns>Object</returns>
        /// CreatedBy:Nguyễn Xuân Quang(23/01/2022)
        MISAEnity GetById(Guid enityId);
        /// <summary>
        /// Thêm dữ liệu
        /// </summary>
        /// <typeparam name="int">type của object</typeparam> 
        /// <returns>Integer</returns>
        /// CreatedBy:Nguyễn Xuân Quang(23/01/2022)
        int Insert(MISAEnity enity);
        /// <summary>
        /// Sửa dữ liệu
        /// </summary>
        /// <typeparam name="int">type của object</typeparam> 
        /// <returns>Integer</returns>
        /// CreatedBy:Nguyễn Xuân Quang(23/01/2022)
        int Update(MISAEnity enity, Guid enityId);
        /// <summary>
        /// Xóa dữ liệu
        /// </summary>
        /// <typeparam name="int">type trả về</typeparam> 
        /// <returns>Integer</returns>
        /// CreatedBy:Nguyễn Xuân Quang(23/01/2022)
        int Delete(string? entityIds);
        /// <summary>
        /// Kiểm tra trùng mã 
        /// </summary>
        /// <typeparam name="bool">type trả về</typeparam> 
        /// <returns>Boolean<returns>
        /// CreatedBy:Nguyễn Xuân Quang(23/01/2022)
        bool CheckDuplicateCode(string enityCode, MISAEnity entity);
 
       
    }
}
