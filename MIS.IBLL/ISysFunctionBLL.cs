using MIS.Model.Page;
using MIS.Model.Result;
using MIS.Model.Sys.SysFunction;
using MIS.Model.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.IBLL
{
   public interface ISysFunctionBLL
    {
        /// <summary>
        /// 根据登录的用户获取到菜单数据
        /// </summary>
        /// <returns></returns>
        RequestResult GetFunctionTreeByAccount();

        /// <summary>
        /// 根据操作的唯一编码获取到菜单数据
        /// </summary>
        /// <param name="operationUnqiueId"></param>
        /// <returns></returns>
        List<LayuiTreeNode> GetFunctionTreeByOperationUniqueId(string operationUnqiueId);


        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        RequestResult Edit(SysFunctionInputForm inputForm);



        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        RequestResult Add(SysFunctionInputForm inputForm);


        /// <summary>
        /// 根据唯一编码获取数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        SysFunctionInputForm GetItemByUniqueId(string Id);


        /// <summary>
        ///  删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        RequestResult Delete(string Id);


        /// <summary>
        /// 菜单树
        /// </summary>
        /// <returns></returns>
        List<TreeNode> InitTree();

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        PageData Query(SysFunctionParameter parameter);


        /// <summary>
        /// 获取菜单树信息
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        List<TreeNode> GetFunctionTreeNodes(string parentId);
    }
}
