using MIS.IBLL;
using MIS.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.BLL
{
   public class SysLogBLL: ISysLogBLL
    {
        private ISysLogDAL _sysLogDAL;

        public SysLogBLL(ISysLogDAL sysLogDAL)
        {
            _sysLogDAL = sysLogDAL;
        }

        public void WriteLog(Exception ex)
        {
             _sysLogDAL.WriteLog(ex);
        }
    }
}
