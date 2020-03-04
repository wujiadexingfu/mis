using MIS.IBLL;
using MIS.IDAL;
using MIS.Model.Page;
using MIS.Model.Result;
using MIS.Model.Sys.SysOrganization;
using MIS.Model.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.BLL
{
    public class SysOrganizationBLL : ISysOrganizationBLL
    {
        private ISysOrganizationDAL _sysOrganizationDAL;

      

        public SysOrganizationBLL(ISysOrganizationDAL sysOrganizationDAL)
        {
            this._sysOrganizationDAL = sysOrganizationDAL;
        }


        public List<TreeNode> InitTree()
        {
            return _sysOrganizationDAL.InitTree();
        }

        public List<TreeNode> GetOrganizationTreeNodes(Guid parentId)
        {
            return _sysOrganizationDAL.GetOrganizationTreeNodes(parentId);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        public RequestResult Edit(SysOrganizationInputForm inputForm)
        {
            return _sysOrganizationDAL.Edit(inputForm);
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
       public RequestResult Add(SysOrganizationInputForm inputForm)
        {
            return _sysOrganizationDAL.Add(inputForm);
        }

        /// <summary>
        ///  根据唯一编码获取数据
        /// </summary>
        /// <param name="uniqueId"></param>
        /// <returns></returns>
        public SysOrganizationInputForm GetItemByUniqueId(Guid uniqueId)
        {
            return _sysOrganizationDAL.GetItemByUniqueId(uniqueId);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="uniqueId"></param>
        /// <returns></returns>
        public RequestResult Delete(Guid uniqueId)
        {
            return _sysOrganizationDAL.Delete(uniqueId);
        }


        public PageData Query(SysOrganizationParameter parameter)
        {
            return _sysOrganizationDAL.Query(parameter);
        }
    }
}
