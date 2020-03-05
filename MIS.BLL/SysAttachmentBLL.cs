using MIS.IBLL;
using MIS.IDAL;
using MIS.Model.Result;
using MIS.Model.Sys;
using MIS.Utility;
using MIS.Utility.DateUtility;
using MIS.Utility.GuidUtility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using static MIS.Utility.EnumUtility.SystemEnums;

namespace MIS.BLL
{
    public class SysAttachmentBLL: ISysAttachmentBLL
    {
        private ISysAttachmentDAL _sysAttachmentDAL;

        public SysAttachmentBLL(ISysAttachmentDAL sysAttachmentDAL)
        {
            this._sysAttachmentDAL = sysAttachmentDAL;
        }

      /// <summary>
      /// 上传文件，保存记录到数据库中
      /// </summary>
      /// <param name="file"></param>
      /// <returns></returns>
        public RequestResult Add(HttpPostedFile file)
        {
            RequestResult result = new RequestResult();
            try
            {

                var rootFileDirectory = Config.GetFileDirectory; //保存文件的根路径

                var saveFilePath = Path.Combine(rootFileDirectory, DateTime.Now.ToString(DateTimeFormatter.yyyyMMdd));

                if (!Directory.Exists(saveFilePath))
                {
                    Directory.CreateDirectory(saveFilePath);
                }
                var fileExtension = Path.GetExtension(file.FileName);
                var fileName = GuidUtils.NewGuid().ToString()+ fileExtension;
                var saveFileName = Path.Combine(rootFileDirectory, DateTime.Now.ToString(DateTimeFormatter.yyyyMMdd), fileName);
                var path= Path.Combine( DateTime.Now.ToString(DateTimeFormatter.yyyyMMdd), fileName);


                file.SaveAs(saveFileName);



                SysAttachmentInputForm inputForm = new SysAttachmentInputForm();
                inputForm.FileName = file.FileName;
                inputForm.FileExtension = Path.GetExtension(file.FileName);
                inputForm.FileSize = file.ContentLength / 2014;
                inputForm.Path = path;
                inputForm.FileType = FileType.Invalidation.ToString(); //文件先属于失效的状态，待确认后再更改回来
                result = _sysAttachmentDAL.Add(inputForm);
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
            return _sysAttachmentDAL.Edit(inputForm);

        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="uniqueId"></param>
        /// <returns></returns>
        public RequestResult Delete(Guid uniqueId)
        {
            return _sysAttachmentDAL.Delete(uniqueId);
        }


        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="uniqueId"></param>
        /// <returns></returns>
        public SysAttachmentInputForm GetItemByUnqiueId(Guid uniqueId)
        {
            return _sysAttachmentDAL.GetItemByUniqueId(uniqueId);
        }

    }
}
