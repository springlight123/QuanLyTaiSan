using Dapper;
using MISA.QLTS.CORE;
using MISA.QLTS.CORE.Interface.Infrastructure;
using MySqlConnector;
using System.Text;
using System.Collections.Generic;
namespace MISA.QLTS.INFRASTRUCTURE.Repository
{
    public class BaseRepository<MISAEntity>:IBaseRepository<MISAEntity>
    {
        //Thông tin database
      protected readonly string _connectionString = ""
              + "Server = 13.229.200.157;" +
              "Port = 3306;" +
              " Database = MISA.WEB12.DCDINH;" +
              "User Id = dev;" +
              " Password = 12345678";
        //Khởi tạo kết nối
       protected MySqlConnection _mySqlConnection;
        /// <summary>
        /// Repository Thêm dữ liệu
        /// </summary>
        /// <typeparam name="MISAEntity"></typeparam> 
        /// <returns>Integer </returns>
        /// CreatedBy:Nguyễn Xuân Quang(23/01/2022)
        public int Insert(MISAEntity entity)
        {
            using (_mySqlConnection = new MySqlConnection(_connectionString))
            {
                //Khỏi tạo parameters
                DynamicParameters parameters = new DynamicParameters();
                //Lấy tên class
                var className = typeof(MISAEntity).Name;
                //Tạo biến chứa tên các cột
                var sqlColumnNames = new StringBuilder();
                //Tạo biến chứa value các cột
                var sqlColumnValues = new StringBuilder();
                //Lấy các prop của object
                var props = entity.GetType().GetProperties();
                //Tạo biến chứa dấu phẩy
                string delimeter = "";
                //Duyệt từng prop
                foreach (var prop in props)
                {
                    //Lấy tên property
                    var propName = prop.Name;
                    //Lấy giá trị property
                    var propVal = prop.GetValue(entity);
                    var primaryKey = Attribute.IsDefined(prop, typeof(PrimaryKey));
                    //Sinh mới Id
                    if (propName == $"{className}Id" && primaryKey==true)
                        if(prop.PropertyType== typeof(Guid))
                        propVal = Guid.NewGuid();
                    
                    //Thêm param tương ứng với mỗi prop
                    var paramName=$"@{propName}";
                    //Thêm tên cột vào StringBuilder
                    sqlColumnNames.Append($"{delimeter}{propName}");
                    //Thêm value cột vào StringBuilder
                    sqlColumnValues.Append($"{delimeter}{paramName}");
                    parameters.Add(paramName, propVal);
                    delimeter = ",";
                }
                //Tạo câu lệnh sql
                var sqlCommand = $"INSERT INTO {className}({sqlColumnNames}) value ({sqlColumnValues})";
                //Thực hiện thêm mới
                var res = _mySqlConnection.Execute(sqlCommand, param: parameters);
                //Trả dữ liệu 
                return res;
            }
        }
        /// <summary>
        /// Repository Sửa dữ liệu
        /// </summary>
        /// <typeparam name="MISAEntity,Guid"></typeparam> 
        /// <returns>Integer</returns>
        /// CreatedBy:Nguyễn Xuân Quang(23/01/2022)
        public int Update(MISAEntity entity, Guid entityId)
        {
            using (_mySqlConnection = new MySqlConnection(_connectionString))
            {
                //Khỏi tạo parameters
                DynamicParameters parameters = new DynamicParameters();
                //Lấy tên class
                var className = typeof(MISAEntity).Name;
                //Tạo biến chứa các thành phần của set
                var sqlColumn = new StringBuilder();
                //Lấy các prop của object
                var props = entity.GetType().GetProperties();
                //Tạo biến chứa dấu phẩy
                string delimeter = "";
                //Duyệt từng prop
                foreach (var prop in props)
                {
                    //Lấy tên property
                    var propName = prop.Name;
                    //Lấy giá trị property
                    var propVal = prop.GetValue(entity);
                    //Thêm param tương ứng với mỗi prop
                    var paramName=$"@{propName}";
                    //Thêm các thành phần của set vào StringBuilder
                    sqlColumn.Append($"{delimeter}{propName}={paramName}");              
                    parameters.Add(paramName, propVal);
                    delimeter = ",";
                }
                //Tạo câu lệnh sql
                var sqlCommand = $"UPDATE {className} SET {sqlColumn}  WHERE {className}Id=@{className}Id";
                parameters.Add($"@{className}Id", entityId);
                //Thực hiện thêm mới
                var res = _mySqlConnection.Execute(sqlCommand, param: parameters);
                //Trả dữ liệu 
                return res;
            }
        }
        /// <summary>
        /// Xóa dữ liệu
        /// </summary>
        /// <typeparam name="String"></typeparam> 
        /// <returns>Integer</returns>
        /// CreatedBy:Nguyễn Xuân Quang(23/01/2022)
        public int Delete(string? entityIds)
        {
            using (_mySqlConnection = new MySqlConnection(_connectionString))
            {
                //Lấy tên của class
                var className = typeof(MISAEntity).Name;
                var res = 0;
                var ids=entityIds.Split(',');
                foreach (var id in ids)
                {
                    var sqlCommand = $"DELETE FROM {className} WHERE {className}Id = @{className}Id";
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add($"@{className}Id", id);
                    //Thực hiện xóa
                    res += _mySqlConnection.Execute(sqlCommand, param: parameters);
                }
          
                return res;
            }
        }
        /// <summary>
        /// Lấy dữ liệu theo Id
        /// </summary>
        /// <typeparam name="List MISAEntities">type của object</typeparam> 
        /// <returns>Object</returns>
        /// CreatedBy:Nguyễn Xuân Quang(23/01/2022)
        public IEnumerable<MISAEntity> GetAll()
        {
            using (_mySqlConnection = new MySqlConnection(_connectionString))
            {
                //Lấy tên của class
                var className = typeof(MISAEntity).Name;
                //Thực hiện truy vấn dữ liệu trong DATABASE
                var entities = _mySqlConnection.Query<MISAEntity>($"select * from {className} ORDER BY ModifiedDate DESC ");
                //Trả dữ liệu
                return entities;
            }
        }
        /// <summary>
        /// Lấy dữ liệu theo Id
        /// </summary>
        /// <typeparam name="MISAEntity">type của object</typeparam> 
        /// <returns>Object</returns>
        /// CreatedBy:Nguyễn Xuân Quang(23/01/2022)
        public MISAEntity GetById(Guid entityId)
        {
            using (_mySqlConnection = new MySqlConnection(_connectionString))
            {
                //Lấy tên của class
                var className = typeof(MISAEntity).Name;
                //Thực hiện truy vấn dữ liệu trong DATABASE
                var sqlCommand = $"select * from {className} where {className}Id=@{className}Id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add($"@{className}Id", entityId);
                //Thực hiện truy vấn dữ liệu trong DATABASE
                var entity = _mySqlConnection.QueryFirstOrDefault<MISAEntity>(sqlCommand, param: parameters);
                //Trả dữ liệu
                return entity;
            }
        }
        /// <summary>
        /// Kiểm tra trùng mã 
        /// </summary>
        /// <typeparam name="bool">type trả về</typeparam> 
        /// <returns>Boolean<returns>
        /// CreatedBy:Nguyễn Xuân Quang(23/01/2022)
        public bool CheckDuplicateCode(string entityCode,MISAEntity entity)
        {
            using (_mySqlConnection = new MySqlConnection(_connectionString))
            {
                //Lấy tên của class
                
                var className = typeof(MISAEntity).Name;
                //Lấy property id
                var propId = entity.GetType().GetProperties().Where(p => Attribute.IsDefined(p, typeof(PrimaryKey))).FirstOrDefault();
                //Lấy giá trị của id
                var propIdValue = propId.GetValue(entity);
                //Khai báo truy vấn 
                var sqlCheck = $"SELECT {className}Code from {className} where {className}Code=@{className}Code and {className}Id!=@{className}Id";
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add($"@{className}Code", entityCode);
                parameters.Add($"@{className}Id", propIdValue);
                //Thực hiện truy vấn dữ liệu trong DATABASE
                var entityCodeDuplicate = _mySqlConnection.QueryFirstOrDefault<string>(sqlCheck, param: parameters);
                //Nếu có mã trùng thì trả về false, không thì true
                if (entityCodeDuplicate != null)
                {
                
                    return true;
                }
                return false;
            }
        }
    }
}
