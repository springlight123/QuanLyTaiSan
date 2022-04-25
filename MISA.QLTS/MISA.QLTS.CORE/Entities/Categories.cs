using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QLTS.CORE.Entities
{
    public class FixedAssetCategory
    {
        #region Constructor
        /// <summary>
        /// Khởi tạo
        /// </summary>
        /// CreatedBy:Nguyễn Xuân Quang(23/01/2022)
        public FixedAssetCategory()
        {

        }
        #endregion
        #region Property
        /// <summary>
        /// Id loại tài sản
        /// </summary>
        /// CreatedBy:Nguyễn Xuân Quang(23/01/2022)
        public Guid FixedAssetCategoryId { get; set; }
        /// <summary>
        /// Mã loại tài sản
        /// </summary>
        /// CreatedBy:Nguyễn Xuân Quang(23/01/2022)
        public string? FixedAssetCategoryCode { get; set; }
        /// <summary>
        /// Tên loại tài sản
        /// </summary>
        /// CreatedBy:Nguyễn Xuân Quang(23/01/2022)
        public string? FixedAssetCategoryName { get; set; }
        /// <summary>
        /// Id của đơn vị
        /// </summary>
        /// CreatedBy:Nguyễn Xuân Quang(23/01/2022)
        public Guid? OrganizationId { get; set; }
        /// <summary>
        /// Tỷ lệ hao mòn (%)
        /// </summary>
        /// CreatedBy:Nguyễn Xuân Quang(23/01/2022)
        public float? DepreciationRate { get; set; }
        /// <summary>
        /// Số năm sử dụng
        /// </summary>
        /// CreatedBy:Nguyễn Xuân Quang(23/01/2022)
        public int? LifeTime { get; set; }
        /// <summary>
        /// Ghi chú
        /// </summary>
        /// CreatedBy:Nguyễn Xuân Quang(23/01/2022)
        public string? Description { get; set; }
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
