using MIS.EFDataSource;
using MIS.Model.Page;
using MIS.Model.Result;
using MIS.Model.Sys.SysAnnouncement;
using MIS.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.DAL
{
   public class SysAnnouncementDAL
    {
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
             
                PageData pageData = new PageData(count, "");
                return pageData;
            }
        }



        /// <summary>
        /// 根据UniqueId获取用户信息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public SysAnnouncementInputForm GetItemByUniqueId(string uniqueId)
        {
            MISEntities db = new MISEntities();
            var item = db.Sys_User.Where(x => x.UniqueId == uniqueId).FirstOrDefault();
            SysAnnouncementInputForm inputForm = new SysAnnouncementInputForm()
            {
                //UniqueId = item.UniqueId,
                //BirthDay = DateTimeUtils.GetDateToStringYYYY_MM_DD(item.BirthDay),
                //Email = item.Email,
                //EndExpiryDate = DateTimeUtils.GetDateToStringYYYY_MM_DD(item.EndExpiryDate),
                //Id = item.Id,
                //IsLogin = BoolUtils.BoolToString(item.IsLogin),
                //MobilePhone = item.MobilePhone,
                //Name = item.Name,
                //OrganizationUniqueId = item.OrganizationUniqueId,
                //Remark = item.Remark,
                //StartExpiryDate = DateTimeUtils.GetDateToStringYYYY_MM_DD(item.StartExpiryDate),
                //Title = item.Title

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
                if (db.Sys_User.Any(x => x.Id == inputForm.Id))
                {
                    result.ReturnFailedMessage("编号重复");
                }
                else
                {
                    Sys_User item = new Sys_User();
                    item.UniqueId = Guid.NewGuid().ToString();
                    //item.Id = inputForm.Id;
                    //item.Name = inputForm.Name;
                    //item.PassWord = Constant.DefaultPassword;
                    //item.OrganizationUniqueId = inputForm.OrganizationUniqueId;
                    //item.Email = inputForm.Email;
                    //item.BirthDay = DateTimeUtils.StringToDateTime(inputForm.BirthDay);
                    //item.Title = inputForm.Title;
                    //item.MobilePhone = inputForm.MobilePhone;
                    //item.Email = inputForm.Email;
                    //item.Status = UserStatus.New.ToString();
                    //item.Remark = inputForm.Remark;
                    //item.StartExpiryDate = DateTimeUtils.StringToDateTime(inputForm.StartExpiryDate);
                    //item.EndExpiryDate = DateTimeUtils.StringToDateTime(inputForm.EndExpiryDate);
                    //item.IsLogin = BoolUtils.StringToBool(inputForm.IsLogin);
                    //item.CreateTime = DateTime.Now;
                    //item.CreateUser = SessionUtils.GetAccountUnqiueId();
                    //db.Sys_User.Add(item);
                    db.SaveChanges();
                    result.Success();
                }

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
                if (db.Sys_User.Any(x => x.Id == inputForm.Id && x.UniqueId != inputForm.UniqueId))
                {
                    result.ReturnFailedMessage("编号重复");
                }
                else
                {
                    //Sys_User item = db.Sys_User.Where(x => x.UniqueId == inputForm.UniqueId).FirstOrDefault();
                    //item.Id = inputForm.Id;
                    //item.Name = inputForm.Name;
                    //item.OrganizationUniqueId = inputForm.OrganizationUniqueId;
                    //item.Email = inputForm.Email;
                    //item.BirthDay = DateTimeUtils.StringToDateTime(inputForm.BirthDay);
                    //item.Title = inputForm.Title;
                    //item.MobilePhone = inputForm.MobilePhone;
                    //item.Email = inputForm.Email;
                    //item.Remark = inputForm.Remark;
                    //item.StartExpiryDate = DateTimeUtils.StringToDateTime(inputForm.StartExpiryDate);
                    //item.EndExpiryDate = DateTimeUtils.StringToDateTime(inputForm.EndExpiryDate);
                    //item.IsLogin = BoolUtils.StringToBool(inputForm.IsLogin);
                    //item.ModifyTime = DateTime.Now;
                    //item.ModifyUser = SessionUtils.GetAccountUnqiueId();
                    db.SaveChanges();
                    result.Success();
                }

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
                var item = db.Sys_User.Where(x => x.UniqueId == uniqueId).FirstOrDefault();
               // item.Status = UserStatus.Delete.ToString();
                item.ModifyTime = DateTime.Now;
                item.ModifyUser = SessionUtils.GetAccountUnqiueId();
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
