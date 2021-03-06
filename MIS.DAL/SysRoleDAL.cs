﻿using MIS.EFDataSource;
using MIS.IDAL;
using MIS.Model.Page;
using MIS.Model.Result;
using MIS.Model.Sys.SysRole;
using MIS.Model.Tree;
using MIS.Utility;
using MIS.Utility.GuidUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.DAL
{
   public class SysRoleDAL:ISysRoleDAL
    {

        private ISysLogDAL _sysLogDAL;
        public SysRoleDAL(ISysLogDAL sysLogDAL)
        {
            _sysLogDAL = sysLogDAL;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public PageData Query(SysRoleParameter parameter)
        {
            using (MISEntities db = new MISEntities())
            {
                var query = db.Sys_Role.AsQueryable();
                if (!string.IsNullOrEmpty(parameter.KeyWord))
                {
                    query = query.Where(x => x.Name.Contains(parameter.KeyWord) || x.Id.Contains(parameter.KeyWord));
                }

                var count = query.Count();
                var list = query.OrderBy(x => x.Id).Skip((parameter.Page - 1) * parameter.Limit).Take(parameter.Limit).Select(x=>new SysRoleGrid(){
                     UniqueId=x.UniqueId,
                     Id=x.Id,
                     Name=x.Name
                }).ToList();
              
                PageData pageData = new PageData(count, list);
                return pageData;
            }
        }



        /// <summary>
        /// 根据UniqueId获取角色信息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public SysRoleInputForm GetItemByUniqueId(Guid uniqueId)
        {
            MISEntities db = new MISEntities();
            var item = db.Sys_Role.Where(x => x.UniqueId == uniqueId).FirstOrDefault();
            SysRoleInputForm inputForm = new SysRoleInputForm()
            {
                UniqueId = item.UniqueId,
                Id=item.Id,
                Name=item.Name
            };

            return inputForm;

        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        public RequestResult Add(SysRoleInputForm inputForm)
        {
            RequestResult result = new RequestResult();

            try
            {
                MISEntities db = new MISEntities();
                if (db.Sys_Role.Any(x => x.Id == inputForm.Id))
                {
                    result.ReturnFailedMessage("编号重复");
                }
                else
                {
                    Sys_Role item = new Sys_Role();
                    item.UniqueId = GuidUtils.NewGuid();
                    item.Id = inputForm.Id;
                    item.Name = inputForm.Name;
                    item.CreateTime = DateTime.Now;
                    item.CreateUser = SessionUtils.GetAccountUnqiueId();
                    db.Sys_Role.Add(item);
                    db.SaveChanges();
                    result.Success();
                }

            }
            catch (Exception ex)
            {
                _sysLogDAL.WriteLog(ex);
                result.ReturnFailedMessage(ex.Message);
            }
            return result;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        public RequestResult Edit(SysRoleInputForm inputForm)
        {
            RequestResult result = new RequestResult();

            try
            {
                MISEntities db = new MISEntities();
                if (db.Sys_Role.Any(x => x.Id == inputForm.Id && x.UniqueId != inputForm.UniqueId))
                {
                    result.ReturnFailedMessage("编号重复");
                }
                else
                {
                    Sys_Role item = db.Sys_Role.Where(x => x.UniqueId == inputForm.UniqueId).FirstOrDefault();
                    item.Id = inputForm.Id;
                    item.Name = inputForm.Name;
                    item.ModifyTime = DateTime.Now;
                    item.ModifyUser = SessionUtils.GetAccountUnqiueId();
                    db.SaveChanges();
                    result.Success();
                }

            }
            catch (Exception ex)
            {
                _sysLogDAL.WriteLog(ex);
                result.ReturnFailedMessage(ex.Message);
            }
            return result;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="uniqueId"></param>
        /// <returns></returns>
        public RequestResult Delete(Guid uniqueId)
        {
            RequestResult result = new RequestResult();

            try
            {
                MISEntities db = new MISEntities();
                var item = db.Sys_Role.Where(x => x.UniqueId == uniqueId).FirstOrDefault();
                db.Sys_Role.Remove(item);
                db.SaveChanges();
                result.Success();
            }
            catch (Exception ex)
            {
                _sysLogDAL.WriteLog(ex);
                result.ReturnFailedMessage(ex.Message);
            }
            return result;
        }


     



        /// <summary>
        /// 添加用户菜单和操作权限的关联
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        public RequestResult AddRoleOperationFunction(SysRoleOperationFunctionInputForm inputForm)
        {
            RequestResult result = new RequestResult();

            try
            {
                MISEntities db = new MISEntities();


                var list = db.Sys_RoleOperationFunction.Where(x => x.RoleUniqueId == inputForm.RoleUnqiueId).ToList();
                db.Sys_RoleOperationFunction.RemoveRange(list);

                foreach (var item in inputForm.OperationFunctionList)
                {

                    Sys_RoleOperationFunction roleOperationFunction = new Sys_RoleOperationFunction();
                    roleOperationFunction.UniqueId = GuidUtils.NewGuid();
                    roleOperationFunction.RoleUniqueId = inputForm.RoleUnqiueId;
                    roleOperationFunction.OperationFunctionUniqueId = item;
                    roleOperationFunction.CreateTime = DateTime.Now;
                    roleOperationFunction.CreateUser = SessionUtils.GetAccountUnqiueId();
                    db.Sys_RoleOperationFunction.Add(roleOperationFunction);
                }

                db.SaveChanges();
                result.Success();
            }
            catch (Exception ex)
            {
                _sysLogDAL.WriteLog(ex);
                result.ReturnFailedMessage(ex.Message);
            }
            return result;
        }






        /// <summary>
        /// 添加角色和用户的关联
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        public RequestResult AddRoleUser(SysRoleUserInputForm inputForm)
        {
            RequestResult result = new RequestResult();

            try
            {
                MISEntities db = new MISEntities();

                foreach (var item in inputForm.UserList)
                {
                    Sys_UserRole userRole = new Sys_UserRole();
                    userRole.UniqueId = GuidUtils.NewGuid();
                    userRole.RoleUniqueId = inputForm.RoleUniqueId;
                    userRole.UserUniqueId = item;
                    userRole.CreateTime = DateTime.Now;
                    userRole.CreateUser = SessionUtils.GetAccountUnqiueId();
                    db.Sys_UserRole.Add(userRole);
                }

                db.SaveChanges();
                result.Success();
            }
            catch (Exception ex)
            {
                _sysLogDAL.WriteLog(ex);
                result.ReturnFailedMessage(ex.Message);
            }
            return result;
        }


        /// <summary>
        /// 删除角色用户的关联
        /// </summary>
        /// <param name="uniqueId"></param>
        /// <returns></returns>
        public RequestResult DeleteRoleUser(Guid uniqueId)
        {
            RequestResult result = new RequestResult();

            try
            {
                MISEntities db = new MISEntities();


                var list = db.Sys_UserRole.Where(x => x.UniqueId == uniqueId).ToList();
                db.Sys_UserRole.RemoveRange(list);
                db.SaveChanges();
                result.Success();
            }
            catch (Exception ex)
            {
                _sysLogDAL.WriteLog(ex);
                result.ReturnFailedMessage(ex.Message);
            }
            return result;
        }


        /// <summary>
        /// 获取所有的角色信息
        /// </summary>
        /// <returns></returns>
        public  List<SysRoleGrid> GetRoleList()
        {
            MISEntities db = new MISEntities();
            return db.Sys_Role.Select(x=>new SysRoleGrid()
            {
                Id =x.Id,
                UniqueId=x.UniqueId,
                Name =x.Name
            }).ToList();
        }

    }
}
