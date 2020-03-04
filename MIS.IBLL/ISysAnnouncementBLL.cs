using MIS.Model.Page;
using MIS.Model.Result;
using MIS.Model.Sys.SysAnnouncement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.IBLL
{
   public interface ISysAnnouncementBLL
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        PageData Query(SysAnnouncementParameter parameter);


        /// <summary>
        /// 根据UniqueId获取公告信息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        SysAnnouncementInputForm GetItemByUniqueId(Guid uniqueId);


        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        RequestResult Add(SysAnnouncementInputForm inputForm);


        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        RequestResult Edit(SysAnnouncementInputForm inputForm);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="uniqueId"></param>
        /// <returns></returns>
        RequestResult Delete(Guid uniqueId);
    }
}
