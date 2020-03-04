using MIS.Model.Page;
using MIS.Model.Result;
using MIS.Model.Sys.SysFunction;
using MIS.Model.Sys.SysOrganization;
using MIS.Model.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.IBLL
{
   public  interface ISysOrganizationBLL
    {

        /// <summary>
        /// 组织树
        /// </summary>
        /// <returns></returns>
        List<TreeNode> InitTree();

        /// <summary>
        ///根据父节点查询组织
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        List<TreeNode> GetOrganizationTreeNodes(Guid parentId);


        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        RequestResult Edit(SysOrganizationInputForm inputForm);

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        RequestResult Add(SysOrganizationInputForm inputForm);

        /// <summary>
        ///  根据唯一编码获取数据
        /// </summary>
        /// <param name="uniqueId"></param>
        /// <returns></returns>
        SysOrganizationInputForm GetItemByUniqueId(Guid uniqueId);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="uniqueId"></param>
        /// <returns></returns>
        RequestResult Delete(Guid uniqueId);


        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        PageData Query(SysOrganizationParameter parameter);


     
    }
}
