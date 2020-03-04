using MIS.IDAL;
using MIS.Model.Result;
using MIS.Model.Sys;
using MIS.Utility;
using MIS.Utility.DateUtility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MIS.BLL
{
    public class SysAttachmentBLL
    {
        private ISysAttachmentDAL _sysAttachmentDAL;

        public SysAttachmentBLL(ISysAttachmentDAL sysAttachmentDAL)
        {
            this._sysAttachmentDAL = sysAttachmentDAL;
        }


       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public RequestResult Add(HttpPostedFile file)
        {
            var rootFileDirectory = Config.GetFileDirectory; //保存文件的根路径

            var saveFilePath = Path.Combine(rootFileDirectory, DateTime.Now.ToString(DateTimeFormatter.yyyyMMdd));

            if (Directory.Exists(saveFilePath))
            {
                Directory.CreateDirectory(saveFilePath);
            }

            var saveFileName= Path.Combine(rootFileDirectory, DateTime.Now.ToString(DateTimeFormatter.yyyyMMdd));


            file.SaveAs(saveFileName);



            SysAttachmentInputForm inputForm = new SysAttachmentInputForm();
            inputForm.FileName = file.FileName;
            inputForm.FileExtension = Path.GetExtension(file.FileName);
            inputForm.FileSize = file.ContentLength / 2014;
            inputForm.FileType = "";
            inputForm.Path = "";


            var requestResult= _sysAttachmentDAL.Add(inputForm);

       





            return _sysAttachmentDAL.Add(inputForm);
        }

    }
}
