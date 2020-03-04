using MIS.EFDataSource;
using MIS.Model.Result;
using MIS.Model.Sys;
using MIS.Utility;
using MIS.Utility.GuidUtility;
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

                Sys_Attachment attachment = new Sys_Attachment();
                attachment.UniqueId = GuidUtils.NewGuid();
                attachment.FileName = inputForm.FileName;
                attachment.FileExtension = inputForm.FileExtension;
                attachment.FileSize = inputForm.FileSize;
                attachment.FileType = inputForm.FileType;
                attachment.CreateTime = DateTime.Now;
                attachment.CreateUser = SessionUtils.GetAccountUnqiueId();

                db.Sys_Attachment.Add(attachment);
             
                db.SaveChanges();
                result.ReturnData(attachment.UniqueId);
            }
            catch (Exception ex)
            {
                result.ReturnFailedMessage(ex.Message);
            }
            return result;
        }
    }
}
