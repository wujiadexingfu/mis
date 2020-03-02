using MIS.IBLL;
using MIS.IDAL;
using MIS.Model.Page;
using MIS.Model.Result;
using MIS.Model.Sys.SysAnnouncement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.BLL
{
  public  class SysAnnouncementBLL: ISysAnnouncementBLL
    {
        private ISysAnnouncementDAL _sysAnnouncementDAL;
        public SysAnnouncementBLL(ISysAnnouncementDAL sysAnnouncementDAL)
        {
            _sysAnnouncementDAL = sysAnnouncementDAL;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public PageData Query(SysAnnouncementParameter parameter)
        {
            return _sysAnnouncementDAL.Query(parameter);
        }


        /// <summary>
        /// 根据UniqueId获取公告信息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
       public  SysAnnouncementInputForm GetItemByUniqueId(string uniqueId)
        {
            return _sysAnnouncementDAL.GetItemByUniqueId(uniqueId);
        }


        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
         public  RequestResult Add(SysAnnouncementInputForm inputForm)
        {
            return _sysAnnouncementDAL.Add(inputForm);
        }


        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        public   RequestResult Edit(SysAnnouncementInputForm inputForm)
        {
            return _sysAnnouncementDAL.Edit(inputForm);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="uniqueId"></param>
        /// <returns></returns>
        public   RequestResult Delete(string uniqueId)
        {
            return _sysAnnouncementDAL.Delete(uniqueId);
        }
    }
}
