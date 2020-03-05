using MIS.Model.Result;
using MIS.Model.Sys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MIS.IBLL
{
    public interface ISysAttachmentBLL
    {
        /// <summary>
        /// 上传文件，保存记录到数据库中
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        RequestResult Add(HttpPostedFile file);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        RequestResult Edit(SysAttachmentInputForm inputForm);

        /// 删除
        /// </summary>
        /// <param name="uniqueId"></param>
        /// <returns></returns>
        RequestResult Delete(Guid uniqueId);

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <param name="uniqueId"></param>
        /// <returns></returns>
        SysAttachmentInputForm GetItemByUnqiueId(Guid uniqueId);
    }
        
}
