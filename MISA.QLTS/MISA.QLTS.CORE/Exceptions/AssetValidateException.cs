using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.QLTS.CORE.Exceptions
{
    public class AssetValidateException : Exception
    {
        /// <summary>
        /// Tạo biến thông báo lỗi
        /// </summary>
        string? MsgErroValidate = null;
        /// <summary>
        /// Khởi tạo hàm thông báo lỗi
        /// </summary>
        /// <param name="msg"></param>
        public AssetValidateException(string msg)
        {
            this.MsgErroValidate = msg;
        }
        /// <summary>
        /// Ghi đè phương thức Message
        /// </summary>
        public override string Message
        {
            get
            {
                return MsgErroValidate;
            }
        }
    }
}
