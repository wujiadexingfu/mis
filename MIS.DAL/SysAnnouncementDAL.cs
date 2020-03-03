using MIS.EFDataSource;
using MIS.IDAL;
using MIS.Model.Page;
using MIS.Model.Result;
using MIS.Model.Sys.SysAnnouncement;
using MIS.Utility;
using MIS.Utility.DateUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.DAL
{
   public class SysAnnouncementDAL: ISysAnnouncementDAL
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public PageData Query(SysAnnouncementParameter parameter)
        {
            using (MISEntities db = new MISEntities())
            {
                var query = db.Sys_Announcement.AsQueryable();
                if (!string.IsNullOrEmpty(parameter.KeyWord))
                {
                    query = query.Where(x => x.Title.Contains(parameter.KeyWord));
                }

                var count = query.Count();
                var data = query.OrderBy(x => x.CreateTime).Skip((parameter.Page - 1) * parameter.Limit).Take(parameter.Limit).ToList();

                SysCodeDAL sysCodeDAL = new SysCodeDAL();
                var codeList = sysCodeDAL.GetSysCodeByCodeValue("AnnouncementLevels");

                foreach (var item in data)
                {
                    var sysCodeItem = codeList.Where(x => x.CodeValue == item.Levels).FirstOrDefault();
                    item.Levels = sysCodeItem==null? "":sysCodeItem.CodeText;
                }

             
                PageData pageData = new PageData(count, data);
                return pageData;
            }
        }



        /// <summary>
        /// 根据UniqueId获取公告信息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public SysAnnouncementInputForm GetItemByUniqueId(string uniqueId)
        {
            MISEntities db = new MISEntities();
            var item = db.Sys_Announcement.Where(x => x.UniqueId == uniqueId).FirstOrDefault();

            var selectedUserUniqueId = db.Sys_AnnouncementUser.Where(x => x.AnnouncementUniqueId == item.UniqueId).Select(x => x.UserUniqueId).ToList();
            SysAnnouncementInputForm inputForm = new SysAnnouncementInputForm()
            {

                UniqueId = item.UniqueId,
                Contents = item.Contents,
                EndDate=item.EndDate==null?"": item.EndDate.Value.ToString(DateTimeFormatter.YYYY_MM_DD),
                StartDate=item.StartDate == null ? "" : item.StartDate.Value.ToString(DateTimeFormatter.YYYY_MM_DD),
                Levels =item.Levels,
                Title=item.Title ,
                SelectedUserUniqueId= selectedUserUniqueId

            };

            return inputForm;

        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        public RequestResult Add(SysAnnouncementInputForm inputForm)
        {
            RequestResult result = new RequestResult();

            try
            {
                MISEntities db = new MISEntities();
               
                Sys_Announcement item = new Sys_Announcement();
                item.UniqueId = Guid.NewGuid().ToString();
                item.Title = inputForm.Title;
                item.Contents = inputForm.Contents;
                item.StartDate = DateTimeUtils.StringToDateTime(inputForm.StartDate);
                item.EndDate = DateTimeUtils.StringToDateTime(inputForm.EndDate);
                item.Levels = inputForm.Levels;
                item.CreateTime = DateTime.Now;
                item.CreateUser = SessionUtils.GetAccountUnqiueId();
                db.Sys_Announcement.Add(item);


                foreach (var itemDetail in inputForm.SelectedUserUniqueId)
                {
                    Sys_AnnouncementUser sysAnnouncementUser = new Sys_AnnouncementUser();
                    sysAnnouncementUser.UniqueId = Guid.NewGuid().ToString();
                    sysAnnouncementUser.AnnouncementUniqueId = item.UniqueId;
                    sysAnnouncementUser.UserUniqueId = itemDetail;
                    sysAnnouncementUser.CreateTime= DateTime.Now;
                    sysAnnouncementUser.CreateUser= SessionUtils.GetAccountUnqiueId();

                    db.Sys_AnnouncementUser.Add(sysAnnouncementUser);
                }
                db.SaveChanges();
                result.Success();
                    
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
        public RequestResult Edit(SysAnnouncementInputForm inputForm)
        {
            RequestResult result = new RequestResult();

            try
            {
                MISEntities db = new MISEntities();


                Sys_Announcement item = db.Sys_Announcement.Where(x => x.UniqueId == inputForm.UniqueId).FirstOrDefault();
                item.Title = inputForm.Title;
                item.Contents = inputForm.Contents;
                item.StartDate = DateTimeUtils.StringToDateTime(inputForm.StartDate);
                item.EndDate = DateTimeUtils.StringToDateTime(inputForm.EndDate); 
                item.Levels = inputForm.Levels;
                item.ModifyTime = DateTime.Now;
                item.ModifyUser = SessionUtils.GetAccountUnqiueId();


                var sysAnnouncementUserList = db.Sys_AnnouncementUser.Where(x => x.AnnouncementUniqueId == inputForm.UniqueId).ToList();
                db.Sys_AnnouncementUser.RemoveRange(sysAnnouncementUserList);


                foreach (var itemDetail in inputForm.SelectedUserUniqueId)
                {
                    Sys_AnnouncementUser sysAnnouncementUser = new Sys_AnnouncementUser();
                    sysAnnouncementUser.UniqueId = Guid.NewGuid().ToString();
                    sysAnnouncementUser.AnnouncementUniqueId = item.UniqueId;
                    sysAnnouncementUser.UserUniqueId = itemDetail;
                    sysAnnouncementUser.CreateTime = DateTime.Now;
                    sysAnnouncementUser.CreateUser = SessionUtils.GetAccountUnqiueId();
                    db.Sys_AnnouncementUser.Add(sysAnnouncementUser);

                }




                db.SaveChanges();
                result.Success();

            }
            catch (Exception ex)
            {
                result.ReturnFailedMessage(ex.Message);
            }
            return result;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="uniqueId"></param>
        /// <returns></returns>
        public RequestResult Delete(string uniqueId)
        {
            RequestResult result = new RequestResult();

            try
            {
                MISEntities db = new MISEntities();
                var item = db.Sys_Announcement.Where(x => x.UniqueId == uniqueId).FirstOrDefault();
                db.Sys_Announcement.Remove(item);

                var sysAnnouncementUserList = db.Sys_AnnouncementUser.Where(x => x.AnnouncementUniqueId == uniqueId).ToList();
                db.Sys_AnnouncementUser.RemoveRange(sysAnnouncementUserList);

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
