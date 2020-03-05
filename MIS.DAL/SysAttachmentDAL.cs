using MIS.EFDataSource;
using MIS.IDAL;
using MIS.Model.Result;
using MIS.Model.Sys;
using MIS.Utility;
using MIS.Utility.GuidUtility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.DAL
{
   public class SysAttachmentDAL: ISysAttachmentDAL
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
                attachment.Path = inputForm.Path;
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

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        public RequestResult Edit(SysAttachmentInputForm inputForm)
        {
            RequestResult result = new RequestResult();

            try
            {
                MISEntities db = new MISEntities();
                var attachment = db.Sys_Attachment.Where(x => x.UniqueId == inputForm.AttachmentUniqueId).FirstOrDefault();

                attachment.FileType = inputForm.FileType;
                attachment.FileName = inputForm.FileName+attachment.FileExtension;
                attachment.Remark = inputForm.Remark;
                attachment.ModifyTime = DateTime.Now;
                attachment.ModifyUser= SessionUtils.GetAccountUnqiueId();


                var removeObjectAttachment = db.Sys_ObjectAttachment.Where(x => x.AttachmentUniqueId == inputForm.AttachmentUniqueId).FirstOrDefault();
                if (removeObjectAttachment != null)
                {
                    db.Sys_ObjectAttachment.Remove(removeObjectAttachment);

                }
           


                Sys_ObjectAttachment objectAttachment = new Sys_ObjectAttachment();
                objectAttachment.UniqueId= GuidUtils.NewGuid(); 
                objectAttachment.AttachmentUniqueId = inputForm.AttachmentUniqueId;
                objectAttachment.ObjectUniqueId = inputForm.ObjectUniqueId;
                db.Sys_ObjectAttachment.Add(objectAttachment);

                db.SaveChanges();
                result.ReturnData(attachment.UniqueId);
            }
            catch (Exception ex)
            {
                result.ReturnFailedMessage(ex.Message);
            }
            return result;
        }

        /// <summary>
        /// 删除文件记录
        /// </summary>
        /// <param name="uniqueId"></param>
        /// <returns></returns>
        public RequestResult Delete(Guid uniqueId)
        {
            RequestResult result = new RequestResult();

            try
            {
                MISEntities db = new MISEntities();
                var attachment = db.Sys_Attachment.Where(x => x.UniqueId == uniqueId).FirstOrDefault();
                var objectAttachment = db.Sys_ObjectAttachment.Where(x => x.AttachmentUniqueId == uniqueId).FirstOrDefault();

                db.Sys_Attachment.Remove(attachment);
                if (objectAttachment != null)
                {
                    db.Sys_ObjectAttachment.Remove(objectAttachment);
                }
              

                db.SaveChanges();
                result.ReturnData(attachment.UniqueId);
            }
            catch (Exception ex)
            {
                result.ReturnFailedMessage(ex.Message);
            }
            return result;
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="uniqueId"></param>
        /// <returns></returns>
        public SysAttachmentInputForm GetItemByUniqueId(Guid uniqueId)
        {
            MISEntities db = new MISEntities();
            var item=db.Sys_Attachment.Where(x => x.UniqueId == uniqueId).Select(x => new SysAttachmentInputForm()
            {
                UniqueId = x.UniqueId,
                AttachmentUniqueId=x.UniqueId,
                Remark=x.Remark,
                FileType=x.FileType,
                FileName=x.FileName,
                Path=x.Path,
                FileExtension=x.FileExtension
            }).FirstOrDefault();

            item.FileName = Path.GetFileNameWithoutExtension(item.FileName);
            item.Path = Path.Combine(Config.GetFileDirectory, item.Path);

            return item;
        }


    }
}
