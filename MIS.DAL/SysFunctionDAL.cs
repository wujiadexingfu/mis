using MIS.EFDataSource;
using MIS.IDAL;
using MIS.Model.Account;
using MIS.Model.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.DAL
{
   public class SysFunctionDAL:ISysFunctionDAL
    {
        /// <summary>
        /// 根据当前登录用户获取到菜单目录
        /// </summary>
        /// <returns></returns>
        public RequestResult GetFunctionTreeByAccount(string accountId)
        {
            RequestResult result = new RequestResult();
            MISEntities db = new MISEntities();
            var allFunctionList = db.Sys_Function.ToList();

            var functionList = GetFunctionTree("root", allFunctionList);
            result.ReturnData(functionList);
            return result;

        }

        /// <summary>
        /// 获取菜单树结构（递归）
        /// </summary>
        /// <param name="parentId"></param>
        /// <param name="allFunctionList"></param>
        /// <returns></returns>
        private List<AccountFuntion> GetFunctionTree(string parentId, List<Sys_Function> allFunctionList)
        {
            List<Sys_Function> childFunctionList = allFunctionList.Where(x => x.ParentId == parentId).ToList();
            List<AccountFuntion> result = new List<AccountFuntion>();


            if (childFunctionList.Count == 0)
            {
                return null;
            }
            else
            {
                foreach (var item in childFunctionList)
                {
                    var model = new AccountFuntion();
                    model.Id = item.Id;
                    model.ParentId = item.ParentId;
                    model.Area = item.Area;
                    model.Controller = item.Controller;
                    model.Action = item.Action;
                    model.Icon = item.Icon;
                    model.Sort = item.Sort;
                    model.Description = item.Description;
                    var childAccountFuntion = GetFunctionTree(item.Id, allFunctionList);
                    model.ChildAccountFuntion = childAccountFuntion != null ? childAccountFuntion.OrderBy(x => x.Sort).ToList():null;
                    result.Add(model);
                }
                return result;

            }






        }
    }
}
