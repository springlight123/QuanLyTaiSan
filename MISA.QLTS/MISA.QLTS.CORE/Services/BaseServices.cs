using MISA.QLTS.CORE.Exceptions;
using MISA.QLTS.CORE.Interface.Infrastructure;
using MISA.QLTS.CORE.Interface.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QLTS.CORE.Services
{
    public class BaseServices<MISAEntity> : IBaseService<MISAEntity>
    {
        // Tạo dependency injection
        IBaseRepository<MISAEntity> _baseRepository;
        public BaseServices(IBaseRepository<MISAEntity> baseRepository)
        {
            _baseRepository=baseRepository;
        }
        public int InsertService(MISAEntity entity)
        {
             //Validata dữ liệu chung
            ValidateDate(entity);
            //Thực hiện thêm mới
            var res = _baseRepository.Insert(entity);
            //Trả về kết quả
            return res;
        }
        public int UpdateService(MISAEntity entity, Guid entityId)
        {       
            //Validate chung
            ValidateDate(entity);
            //Thực hiện sửa
            var res = _baseRepository.Update(entity, entityId);
            //Trả về kết quả
            return res;
        }
        protected void ValidateDate(MISAEntity entity)
        {              
            //Kiem tra cac property duoc danh dau khong duoc phep de trong-co attribute la NotEmpty 
            var propNotEmpty = entity.GetType().GetProperties().Where(p => Attribute.IsDefined(p,typeof(NotEmpty)));
            foreach (var prop in propNotEmpty)
            {
                //Lấy tên bảng
                var propName = prop.Name;
                //Tạo tên
                var nameDisplay = string.Empty;
                //Lấy ra tên của property 
                var propertyNames = prop.GetCustomAttributes(typeof(PropertyName), true);
                if (propertyNames.Length > 0)
                {
                    nameDisplay = (propertyNames[0] as PropertyName).Name;            
                }
                //Lấy giá trị của property
                var propVal=prop.GetValue(entity);
                //Nếu không có giá trị của property thì báo lỗi
                if (propVal == null || string.IsNullOrEmpty(propVal.ToString()))
                {
                    //Lấy tên 
                    nameDisplay = (nameDisplay == string.Empty ? propName : nameDisplay);
                    //Trả về lỗi
                    throw new AssetValidateException(String.Format(CORE.Resources.ResourceVN.InfoNotEmpty,nameDisplay));
                }
            }
            // check trùng mã
            var propCode = entity.GetType().GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(EntityCode)));
            foreach (var prop in propCode)
            {
                //Lấy tên bảng
                var propName = prop.Name;
                //Tạo tên
                var nameDisplay = string.Empty;
                //Lay ra ten cua property 
                var propertyNames = prop.GetCustomAttributes(typeof(PropertyName), true);
                if (propertyNames.Length > 0)
                {
                    nameDisplay = (propertyNames[0] as PropertyName).Name;
                }
                //Lấy tên
                nameDisplay = nameDisplay == string.Empty ? propName : nameDisplay;
                //Kiểm tra trùng code
                var res = _baseRepository.CheckDuplicateCode(prop.GetValue(entity).ToString(),entity);
                //Báo lỗi
                if(res)
                    throw new AssetValidateException(String.Format(CORE.Resources.ResourceVN.DuplicateCode, nameDisplay));
            }

        }
    }
}
