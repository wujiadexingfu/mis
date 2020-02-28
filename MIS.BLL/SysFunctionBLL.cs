using MIS.IBLL;
using MIS.IDAL;
using MIS.Model.Account;
using MIS.Model.Page;
using MIS.Model.Result;
using MIS.Model.Sys.SysFunction;
using MIS.Model.Tree;
using MIS.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.BLL
{
    public class SysFunctionBLL : ISysFunctionBLL
    {
        private ISysFunctionDAL _sysFunctionDAL;
        public SysFunctionBLL(ISysFunctionDAL sysFunctionDAL)
        {
            _sysFunctionDAL = sysFunctionDAL;
        }

        /// <summary>
        /// 根据登录的用户获取到菜单数据
        /// </summary>
        /// <returns></returns>
        public RequestResult GetFunctionTreeByAccount()
        {
            // var accountId = ((Account)System.Web.HttpContext.Current.Session[Constant.Account]).UniqueId;

            var accountId = "5BE2DAD8-BA8C-480C-95FD-FD5CA26BDE28";

            return _sysFunctionDAL.GetFunctionTreeByAccount(accountId);
        }

        /// <summary>
        /// 根据操作的唯一编码获取到菜单数据
        /// </summary>
        /// <param name="operationUnqiueId"></param>
        /// <returns></returns>

        public List<LayuiTreeNode> GetFunctionTreeByOperationUniqueId(string operationUnqiueId)
        {
            return _sysFunctionDAL.GetFunctionTreeByOperationUniqueId(operationUnqiueId);
        }


        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        public RequestResult Edit(SysFunctionInputForm inputForm)
        {
            return _sysFunctionDAL.Edit(inputForm);
        }



        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        public  RequestResult Add(SysFunctionInputForm inputForm)
        {
            return _sysFunctionDAL.Add(inputForm);
        }


        /// <summary>
        /// 根据唯一编码获取数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public SysFunctionInputForm GetItemByUniqueId(string Id)
        {
            return _sysFunctionDAL.GetItemByUniqueId(Id);
        }


        /// <summary>
        ///  删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public RequestResult Delete(string Id)
        {
            return _sysFunctionDAL.Delete(Id);
        }


        /// <summary>
        /// 菜单树
        /// </summary>
        /// <returns></returns>
        public List<TreeNode> InitTree()
        {
            return _sysFunctionDAL.InitTree();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public PageData Query(SysFunctionParameter parameter)
        {
            return _sysFunctionDAL.Query(parameter);
        }

        /// <summary>
        /// 获取菜单树信息
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public List<TreeNode> GetFunctionTreeNodes(string parentId)
        {
            return _sysFunctionDAL.GetFunctionTreeNodes(parentId);
        }

    }
}
