using MIS.EFDataSource;
using MIS.Model.Result;
using MIS.Model.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.DAL
{
   public class SysAttachmentDAL
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        public RequestResult Add(SysAttachmentInputForm inputForm)
        {
            RequestResult result = new RequestResult();

            try
            {
                MISEntities db = new MISEntities();






                db.SaveChanges();
                result.Success();
            }
            catch (Exception ex)
            {
                result.ReturnFailedMessage(ex.Message);
            }
            return result;
        }
    }
}
