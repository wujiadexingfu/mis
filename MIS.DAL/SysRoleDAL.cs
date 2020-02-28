using MIS.EFDataSource;
using MIS.IDAL;
using MIS.Model.Page;
using MIS.Model.Result;
using MIS.Model.Sys.SysRole;
using MIS.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.DAL
{
   public class SysRoleDAL:ISysRoleDAL
    {
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
        public SysRoleInputForm GetItemByUniqueId(string uniqueId)
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
                    item.UniqueId = Guid.NewGuid().ToString();
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
                var item = db.Sys_Role.Where(x => x.UniqueId == uniqueId).FirstOrDefault();
                db.Sys_Role.Remove(item);
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
