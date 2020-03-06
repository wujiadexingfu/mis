using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.IDAL
{
   public interface ISysLogDAL
    {
        /// <summary>
        /// 向数据库中写入异常日志
        /// </summary>
        /// <param name="ex"></param>
        void WriteLog(Exception ex);

    }
}
