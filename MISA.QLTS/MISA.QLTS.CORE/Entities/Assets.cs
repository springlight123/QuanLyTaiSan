using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QLTS.CORE.Entities
{
    public class FixedAsset
    {
        #region Constructor
        /// <summary>
        /// Khởi tạo
        /// </summary>
        /// CreatedBy:Nguyễn Xuân Quang(23/01/2022)
        public FixedAsset()
        {

        }
        #endregion

        #region Property
        /// <summary>
        /// Khóa chính
        /// </summary>
        /// CreatedBy:Nguyễn Xuân Quang(23/01/2022)
        [PrimaryKey]
        public Guid FixedAssetId { get; set; }
        /// <summary>
        /// Mã tài sản
        /// </summary>
        /// CreatedBy:Nguyễn Xuân Quang(23/01/2022)
        [EntityCode]
        [PropertyName("Mã tài sản")]
        public string FixedAssetCode { get; set; }
        /// <summary>
        /// Tên tài sản
        /// </summary>
        /// CreatedBy:Nguyễn Xuân Quang(23/01/2022)
        [PropertyName("Tên tài sản")]
        public string FixedAssetName { get; set; }
        /// <summary>
        /// ID đơn vị
        /// </summary>
        /// CreatedBy:Nguyễn Xuân Quang(23/01/2022)
        public Guid? OrganizationId { get; set; }
        /// <summary>
        /// Mã đơn vị
        /// </summary>
        /// CreatedBy:Nguyễn Xuân Quang(23/01/2022)
        public string? OrganizationCode { get; set; }
        /// <summary>
        /// Tên của đơn vị
        /// </summary>
        /// CreatedBy:Nguyễn Xuân Quang(23/01/2022)
        public string? OrganizationName { get; set; }
        /// <summary>
        /// Id phòng ban
        /// </summary>
        /// CreatedBy:Nguyễn Xuân Quang(23/01/2022)
        public Guid? DepartmentId { get; set; }
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
        /// Id loại tài sản
        /// </summary>
        /// CreatedBy:Nguyễn Xuân Quang(23/01/2022)
        public Guid? FixedAssetCategoryId { get; set; }
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
        /// Ngày mua
        /// </summary>
        /// CreatedBy:Nguyễn Xuân Quang(23/01/2022)
        public DateTime? PurchaseDate { get; set; }
        /// <summary>
        /// Nguyên giá
        /// </summary>
        /// CreatedBy:Nguyễn Xuân Quang(23/01/2022)
        public Decimal? Cost { get; set; }
        /// <summary>
        /// Số lượng
        /// </summary>
        /// CreatedBy:Nguyễn Xuân Quang(23/01/2022)
        public int? Quantity { get; set; }
        /// <summary>
        /// Tỷ lệ hao mòn (%)
        /// </summary>
        /// CreatedBy:Nguyễn Xuân Quang(23/01/2022)
        public float? DepreciationRate { get; set; }
        /// <summary>
        /// Năm bắt đầu theo dõi tài sản trên phần mềm
        /// </summary>
        /// CreatedBy:Nguyễn Xuân Quang(23/01/2022)
        public int? TrackedYear { get; set; }
        /// <summary>
        /// Số năm sử dụng
        /// </summary>
        /// CreatedBy:Nguyễn Xuân Quang(23/01/2022)
        public int? LifeTime { get; set; }
        /// <summary>
        /// Năm sử dụng
        /// </summary>
        /// CreatedBy:Nguyễn Xuân Quang(23/01/2022)
        public int? ProductionYear { get; set; }
        /// <summary>
        /// Sử dụng
        /// </summary>
        /// CreatedBy:Nguyễn Xuân Quang(23/01/2022)
        public bool? Active { get; set; } = false;
        /// <summary>
        /// Người tạo
        /// </summary>
        /// CreatedBy:Nguyễn Xuân Quang(23/01/2022)
        public string? CreatedBy { get; set; }
        /// <summary>
        /// Ngày tạo
        /// </summary>
        /// CreatedBy:Nguyễn Xuân Quang(23/01/2022)
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        /// <summary>
        /// Người sửa
        /// </summary>
        /// CreatedBy:Nguyễn Xuân Quang(23/01/2022)
        public string? ModifiedBy { get; set; }
        /// <summary>
        /// Ngày sửa
        /// </summary>
        /// CreatedBy:Nguyễn Xuân Quang(23/01/2022)
        public DateTime? ModifiedDate { get; set; } = DateTime.Now;
            #endregion
        }
}
