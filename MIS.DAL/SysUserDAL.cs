using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MIS.Utility.EnumUtility;
using MIS.EFDataSource;
using MIS.IDAL;
using MIS.Model.Result;
using MIS.Model.Account;
using MIS.Model.Page;
using MIS.Model.Sys.SysUser;
using MIS.Utility.DateUtility;
using MIS.Utility;
using static MIS.Utility.EnumUtility.SystemEnums;
using MIS.Utility.BoolUtility;


/********************************************************************************

** 类名称：  SysUserDAL

** 描述：********

** 作者： zhangyang

** Version: 1.0

** 创建时间：2019-11-24 19:21:04

** 最后修改人：（无）

** 最后修改时间：（无）

** CLR版本：4.0.30319.42000      

** 版权所有 (C) :zhangyang

*********************************************************************************/

namespace MIS.DAL
{
  public    class SysUserDAL:ISysUserDAL
    {
       /// <summary>
       /// 登录
       /// </summary>
       /// <param name="Id">用户编号</param>
       /// <param name="password">密码</param>
       /// <returns></returns>
      public SystemEnums.LoginStatus Login(string Id, string password)
      {

            MISEntities db = new MISEntities();
            var result = SystemEnums.LoginStatus.NotExists;

            var user = db.Sys_User.Where(x => x.Id == Id).FirstOrDefault();
            if (user == null)  //用户不存在
            {
                result = SystemEnums.LoginStatus.NotExists;
                return result;
            }

            if (!user.IsLogin) //不允许登录
            {
                result = SystemEnums.LoginStatus.NotLogin;
                return result;
            }

            if (user.StartExpiryDate!=null&&user.StartExpiryDate<DateTime.Now|| user.EndExpiryDate != null && user.EndExpiryDate >DateTime.Now)//时间超过有效期时间
            {
                result = SystemEnums.LoginStatus.ExpiryDateWrong;
                return result;
            }

            if (user.PassWord != password)  ///密码不正确
            {
                result = SystemEnums.LoginStatus.PasswordWrong;
                return result;
            }

            return SystemEnums.LoginStatus.Normal;  ///正常
      }

        /// <summary>
        /// 根据Id获取登录人员的信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Account GetAccountById(string Id)
        {

            Account account = new Account();
            MISEntities db = new MISEntities();
            account = db.Sys_User.Where(x => x.Id == Id).Select(x => new Account()
            {
                 UniqueId=x.UniqueId,
                 Id=x.Id,
                 Name=x.Name,
                 OrganizationUniqueId=x.OrganizationUniqueId,
                 Title=x.Title
            }).FirstOrDefault();

            return account;
        }


        public PageData Query(SysUserParameter parameter)
        {
            using (MISEntities db = new MISEntities())
            {
                var query = db.Sys_User.AsQueryable();
                if (!string.IsNullOrEmpty(parameter.KeyWord))
                {
                    query = query.Where(x => x.Name.Contains(parameter.KeyWord) || x.Id.Contains(parameter.KeyWord));
                }

                var count = query.Count();
                var data = query.OrderBy(x => x.Id).Skip((parameter.Page - 1) * parameter.Limit).Take(parameter.Limit).ToList();
                List<SysUserGrid> list = new List<SysUserGrid>();
                var organizationList = db.Sys_Organization.ToList();


                foreach (var item in data)
                {
                    SysUserGrid model = new SysUserGrid();
                    model.UniqueId = item.UniqueId;
                    model.Id = item.Id;
                    model.Name = item.Name;
                    model.Organization = organizationList.Where(x => x.UniqueId == item.OrganizationUniqueId).FirstOrDefault().Name;
                    model.Email = item.Email;
                    model.BirthDay= item.BirthDay == null ? "" : item.BirthDay.Value.ToString(DateTimeFormatter.YYYYMMDD);
                    model.Title = item.Title;
                    model.MobilePhone = item.MobilePhone;
                    model.Status = item.Status;
                    model.Remark = item.Remark;
                    model.StartExpiryDate = item.StartExpiryDate==null?"": item.StartExpiryDate.Value.ToString(DateTimeFormatter.YYYYMMDD);
                    model.EndExpiryDate = item.EndExpiryDate == null ? "" : item.EndExpiryDate.Value.ToString(DateTimeFormatter.YYYYMMDD);
                    model.IsLogin = item.IsLogin==true?"true":"";
                    list.Add(model);
                }
                PageData pageData = new PageData(count, list);
                return pageData;
            }
        }



        /// <summary>
        /// 根据UniqueId获取用户信息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public SysUserInputForm GetUserByUniqueId(string uniqueId)
        {
            MISEntities db = new MISEntities();
            var item = db.Sys_User.Where(x => x.UniqueId == uniqueId).FirstOrDefault();
            SysUserInputForm inputForm = new SysUserInputForm()
            {
                UniqueId = item.UniqueId,
                BirthDay = DateTimeUtils.GetDateToStringYYYY_MM_DD(item.BirthDay),
                Email = item.Email,
                EndExpiryDate = DateTimeUtils.GetDateToStringYYYY_MM_DD(item.EndExpiryDate),
                Id = item.Id,
                IsLogin = BoolUtils.BoolToString(item.IsLogin),
                MobilePhone = item.MobilePhone,
                Name = item.Name,
                OrganizationUniqueId = item.OrganizationUniqueId,
                Remark = item.Remark,
                StartExpiryDate = DateTimeUtils.GetDateToStringYYYY_MM_DD(item.StartExpiryDate),
                Title = item.Title

            };

            return inputForm;

        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        public RequestResult Add(SysUserInputForm inputForm)
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
                    item.Id = inputForm.Id;
                    item.Name = inputForm.Name;
                    item.PassWord = Constant.DefaultPassword;
                    item.OrganizationUniqueId = inputForm.OrganizationUniqueId;
                    item.Email = inputForm.Email;
                    item.BirthDay = DateTimeUtils.StringToDateTime(inputForm.BirthDay);
                    item.Title = inputForm.Title;
                    item.MobilePhone = inputForm.MobilePhone;
                    item.Email = inputForm.Email;
                    item.Status = UserStatus.New.ToString() ;
                    item.Remark = inputForm.Remark;
                    item.StartExpiryDate = DateTimeUtils.StringToDateTime(inputForm.StartExpiryDate);
                    item.EndExpiryDate = DateTimeUtils.StringToDateTime(inputForm.EndExpiryDate);
                    item.IsLogin = BoolUtils.StringToBool(inputForm.IsLogin);
                    item.CreateTime = DateTime.Now;
                    item.CreateUser = SessionUtils.GetAccountUnqiueId();
                    db.Sys_User.Add(item);
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
        public RequestResult Edit(SysUserInputForm inputForm)
        {
            RequestResult result = new RequestResult();

            try
            {
                MISEntities db = new MISEntities();
                if (db.Sys_User.Any(x => x.Id == inputForm.Id&&x.UniqueId!=inputForm.UniqueId))
                {
                    result.ReturnFailedMessage("编号重复");
                }
                else
                {
                    Sys_User item = db.Sys_User.Where(x => x.UniqueId == inputForm.UniqueId).FirstOrDefault();
                    item.Id = inputForm.Id;
                    item.Name = inputForm.Name;
                    item.OrganizationUniqueId = inputForm.OrganizationUniqueId;
                    item.Email = inputForm.Email;
                    item.BirthDay = DateTimeUtils.StringToDateTime(inputForm.BirthDay);
                    item.Title = inputForm.Title;
                    item.MobilePhone = inputForm.MobilePhone;
                    item.Email = inputForm.Email;
                    item.Remark = inputForm.Remark;
                    item.StartExpiryDate = DateTimeUtils.StringToDateTime(inputForm.StartExpiryDate);
                    item.EndExpiryDate = DateTimeUtils.StringToDateTime(inputForm.EndExpiryDate);
                    item.IsLogin = BoolUtils.StringToBool(inputForm.IsLogin);
                    item.ModifyTime = DateTime.Now;
                    item.ModifyUser = SessionUtils.GetAccountUnqiueId();
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
                item.Status = UserStatus.Delete.ToString();
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

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="model">需要修改的人员信息</param>
        /// <returns></returns>
        public RequestResult ResetPassword(SysUserResetModel model)
        {
            RequestResult result = new RequestResult();

            try
            {
                MISEntities db = new MISEntities();
                var userList = db.Sys_User.Where(x => model.selected.Contains(x.UniqueId)).ToList();
                foreach (var item in userList)
                {
                    item.PassWord = Constant.DefaultPassword;
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
        /// 获取所有人员信息
        /// </summary>
        /// <returns></returns>
        public List<UserSelectItem> QueryUserSelectItemList()
        {
            MISEntities db = new MISEntities();
            return db.Sys_User.Where(x=>x.Status!=Status.Delete.ToString()).Select(x => new UserSelectItem() { Text = x.Id + "-" + x.Name, Value = x.UniqueId }).ToList();
        }

        /// <summary>
        /// 根据角色的唯一编码找到已经选中的人员信息
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public PageData QueryUserByRoleUniqueId(SysUserRoleParameter parameter)
        {
            using (MISEntities db = new MISEntities())
            {
                var query = (from x in db.Sys_User
                             join x1 in db.Sys_UserRole on x.UniqueId equals x1.UserUniqueId
                             where x1.RoleUniqueId == parameter.RoleUniqueId
                             select new  SysUserGrid {
                                UniqueId= x1.UniqueId,
                                Name= x.Name,
                                Id= x.Id
                             }).AsQueryable();

                var count = query.Count();
                var list = query.OrderBy(x => x.Id).Skip((parameter.Page - 1) * parameter.Limit).Take(parameter.Limit).ToList();
                PageData pageData = new PageData(count, list);
                return pageData;
            }
        }

      /// <summary>
      /// 根据角色的唯一编码查询到没有选中的人员信息
      /// </summary>
      /// <param name="parameter"></param>
      /// <returns></returns>
        public PageData QueryNotSelectedUserByRoleUniqueId(SysUserRoleParameter parameter)
        {
            using (MISEntities db = new MISEntities())
            {

                var selectedUserUniqueIdList = db.Sys_UserRole.Where(x => x.RoleUniqueId == parameter.RoleUniqueId).Select(x => x.UserUniqueId).ToList();  //角色对应的选中人员

                var query = (from x in db.Sys_User
                            where !selectedUserUniqueIdList.Contains(x.UniqueId)
                             select new SysUserGrid
                             {
                                 UniqueId = x.UniqueId,
                                 Name = x.Name,
                                 Id = x.Id
                             }).AsQueryable();

                if (!string.IsNullOrEmpty(parameter.KeyWord))
                {
                    query = query.Where(x => parameter.KeyWord.Contains(x.Id) || parameter.KeyWord.Contains(x.Name));
                }

                var count = query.Count();
                var list = query.OrderBy(x => x.Id).Skip((parameter.Page - 1) * parameter.Limit).Take(parameter.Limit).ToList();
                PageData pageData = new PageData(count, list);
                return pageData;
            }
        }




    }
}
