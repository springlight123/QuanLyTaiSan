using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QLTS.CORE
{
    /// <summary>
    /// Tạo property NotEmpty
    /// </summary>
    /// CreatedBy:Nguyễn Xuân Quang(23/01/2022)
    [AttributeUsage(AttributeTargets.Property)]
    public class NotEmpty:Attribute
    {
    }
    /// <summary>
    /// Tạo property PrimaryKey
    /// </summary>
    /// CreatedBy:Nguyễn Xuân Quang(23/01/2022)
    [AttributeUsage(AttributeTargets.Property)]
    public class PrimaryKey: Attribute
    {
    }
    /// <summary>
    /// Tạo property EntityCode
    /// </summary>
    /// CreatedBy:Nguyễn Xuân Quang(23/01/2022)
    [AttributeUsage(AttributeTargets.Property)]
    public class EntityCode : Attribute
    {
    }
    /// <summary>
    /// Tạo property PropertyName 
    /// </summary>
    /// CreatedBy:Nguyễn Xuân Quang(23/01/2022)
    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyName : Attribute
    {
        public string Name=string.Empty;
        public PropertyName(string name)
        {
            Name = name;    
        }
    }
}
