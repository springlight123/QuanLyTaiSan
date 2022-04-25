using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.QLTS.CORE.Entities;
using MISA.QLTS.CORE.Exceptions;
using MISA.QLTS.CORE.Interface.Infrastructure;
using MISA.QLTS.CORE.Interface.Services;

namespace MISA.QLTS.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class MISABaseController<MISAEnity> : ControllerBase
    {
        #region Fields
        IBaseService<MISAEnity> _baseService;
        IBaseRepository<MISAEnity> _baseRepository;
        #endregion
        /// <summary>
        /// Khởi tạo
        /// </summary>
        #region Constructor
        public MISABaseController(IBaseRepository<MISAEnity> baseRepository, IBaseService<MISAEnity> baseService)
        {
            _baseService = baseService;
            _baseRepository = baseRepository;
        }
        #endregion
        /// <summary>
        /// Lấy danh sách dữ liệu 
        /// </summary>
        /// <returns>
        /// 200-Danh sách tài sản
        /// 204-Không có dữ liệu
        /// 400-Dữ liệu đầu vào không hợp lệ
        /// 500-Exception
        /// </returns>
        /// CreatedBy:Nguyễn Xuân Quang(23/01/2022)
        #region methos
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //Lấy dữ liệu
                var data = _baseRepository.GetAll();
                //Trả về trạng thái và dữ liệu
                return Ok(data);
            }
            //Trả về lỗi validate
            catch (AssetValidateException ex)
            {
                var response = new
                {
                    devMSG = ex.Message,
                    userMSG = ex.Message,
                    data = ex.Data,
                };
                return BadRequest(response);
            }
            //Trả về lỗi không có trong validate
            catch (Exception ex)
            {
                var response = new
                {
                    devMSG = ex.Message,
                    userMSG = CORE.Resources.ResourceVN.ErrorException,
                    data = ex.Data,
                };
                return StatusCode(500, response);
            }
        }
        /// <summary>
        /// Lấy  dữ liệu theo Id
        /// </summary>
        /// <returns>
        /// 200-Nhân viên
        /// 204-Không có dữ liệu
        /// 400-Dữ liệu đầu vào không hợp lệ
        /// 500-Exception
        /// </returns>
        /// CreatedBy:Nguyễn Xuân Quang(23/01/2022)
        [HttpGet("{enityId}")]
        public IActionResult Get(Guid enityId)
        {
            try
            {
                //Lấy dữ liệu
                var data = _baseRepository.GetById(enityId);
                //Trả về trạng thái và dữ liệu
                return Ok(data);
            }
            //Trả về lỗi validate
            catch (AssetValidateException ex)
            {
                var response = new
                {
                    devMSG = ex.Message,
                    userMSG = ex.Message,
                    data = ex.Data,
                };
                return BadRequest(response);
            }
            //Trả về lỗi không có trong validate
            catch (Exception ex)
            {
                var response = new
                {
                    devMSG = ex.Message,
                    userMSG = CORE.Resources.ResourceVN.ErrorException,
                    data = ex.Data,
                };
                return StatusCode(500, response);
            }
        }
        /// <summary>
        /// Thêm dữ liệu
        /// </summary>
        /// <returns>
        /// 200-Số bản nghi bị ảnh hưởng
        /// 204-Không có dữ liệu
        /// 400-Dữ liệu đầu vào không hợp lệ
        /// 500-Exception
        /// </returns>
        /// CreatedBy:Nguyễn Xuân Quang(23/01/2022)
        [HttpPost]
        public IActionResult Post(MISAEnity enity)
        {
            try
            {
                //Thêm dữ liệu
                var data = _baseService.InsertService(enity);
                //Trả về trạng thái và dữ liệu
                return StatusCode(201, data);
            }
            //Trả về lỗi validate
            catch (AssetValidateException ex)
            {
                var response = new
                {
                    devMSG = ex.Message,
                    userMSG = ex.Message,
                    data = ex.Data,
                };
                return BadRequest(response);
            }
            //Trả về lỗi không có trong validate
            catch (Exception ex)
            {
                //Xóa dữ liệu
                var response = new
                {
                    devMSG = ex.Message,
                    userMSG = CORE.Resources.ResourceVN.ErrorException,
                    data = ex.Data,
                };
                return StatusCode(500, response);
            }
        }
        /// <summary>
        /// Sủa dữ liệu
        /// </summary>
        /// <returns>
        /// 200-Số bản nghi bị ảnh hưởng
        /// 204-Không có dữ liệu
        /// 400-Dữ liệu đầu vào không hợp lệ
        /// 500-Exception
        /// </returns>  
        /// CreatedBy:Nguyễn Xuân Quang(23/01/2022)
        [HttpPut("{enityId}")]
        public IActionResult Put(MISAEnity enity, Guid enityId)
        {
            try
            {
                //Sủa dữ liệu

                var data = _baseService.UpdateService(enity, enityId);
                //Trả về trạng thái và dữ liệu
                return Ok(data);
            }
            //Trả về lỗi validate
            catch (AssetValidateException ex)
            {
                var response = new
                {
                    devMSG = ex.Message,
                    userMSG = ex.Message,
                    data = ex.Data,
                };
                return BadRequest(response);
            }
            //Trả về lỗi không có trong validate
            catch (Exception ex)
            {
                var response = new
                {
                    devMSG = ex.Message,
                    userMSG = CORE.Resources.ResourceVN.ErrorException,
                    data = ex.Data,
                };
                return StatusCode(500, response);
            }
        }
        /// <summary>
        ///Xóa dữ liệu
        /// </summary>
        /// <returns>
        /// 200-Số bản nghi bị ảnh hưởng
        /// 204-Không có dữ liệu
        /// 400-Dữ liệu đầu vào không hợp lệ
        /// 500-Exception
        /// </returns>
        /// CreatedBy:Nguyễn Xuân Quang(23/01/2022)
        [HttpDelete("{entityIds}")]
        public IActionResult Delete(string? entityIds)
        {
            try
            {
                //Xóa dữ liệu
                var data = _baseRepository.Delete(entityIds);
                //Trả về trạng thái và dữ liệu
                return Ok(data);
            }
            //Trả về lỗi validate
            catch (AssetValidateException ex)
            {
                var response = new
                {
                    devMSG = ex.Message,
                    userMSG = ex.Message,
                    data = ex.Data,
                };
                return BadRequest(response);
            }
            //Trả về lỗi không có trong validate
            catch (Exception ex)
            {
                var response = new
                {
                    devMSG = ex.Message,
                    userMSG = CORE.Resources.ResourceVN.ErrorException,
                    data = ex.Data,
                };
                return StatusCode(500, response);
            }
        }
        #endregion
    }
}