using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QLTS.CORE.Entities
{
    public class Department
    {
        #region Constructor
        /// <summary>
        /// Khởi tạo
        /// </summary>
        /// CreatedBy:Nguyễn Xuân Quang(23/01/2022)
        public Department()
        {

        }
        #endregion
        #region Property
        /// <summary>
        /// Id phòng ban
        /// </summary>
        /// CreatedBy:Nguyễn Xuân Quang(23/01/2022)
        public Guid DepartmentId { get; set; }
        /// <summary>
        /// Mã phòng ban
        /// </summary>
        /// CreatedBy:Nguyễn Xuân Quang(23/01/2022)
        public string? DepartmentCode { get; set; }
        /// <summary>
        /// Tên phòng ban
        /// </summary>
        /// CreatedBy:Nguyễn Xuân Quang(23/01/2022)
        public string? DepartmentName { get; set; }
        /// <summary>
        /// Ghi chú
        /// </summary>
        /// CreatedBy:Nguyễn Xuân Quang(23/01/2022)
        public string? Description { get; set; }
        /// <summary>
        /// Có phải là cha không
        /// </summary>
        /// CreatedBy:Nguyễn Xuân Quang(23/01/2022)
        public Boolean? IsParent { get; set; }
        /// <summary>
        /// Id phòng ban cha
        /// </summary>
        /// CreatedBy:Nguyễn Xuân Quang(23/01/2022)
        public Guid? ParentId { get; set; }
        /// <summary>
        /// Id của đơn vị
        /// </summary>
        /// CreatedBy:Nguyễn Xuân Quang(23/01/2022)
        public Guid? OrganizationId { get; set; }
        /// <summary>
        /// Người tạo
        /// </summary>
        /// CreatedBy:Nguyễn Xuân Quang(23/01/2022)
        public string? CreatedBy { get; set; }
        /// <summary>
        /// Ngày tạo
        /// </summary>
        /// CreatedBy:Nguyễn Xuân Quang(23/01/2022)
        public DateTime? CreatedDate { get; set; }
        /// <summary>
        /// Người sửa
        /// </summary>
        /// CreatedBy:Nguyễn Xuân Quang(23/01/2022)
        public string? ModifiedBy { get; set; }
        /// <summary>
        /// Ngày sửa
        /// </summary>
        /// CreatedBy:Nguyễn Xuân Quang(23/01/2022)
        public DateTime? ModifiedDate { get; set; }
        #endregion
    }
}
