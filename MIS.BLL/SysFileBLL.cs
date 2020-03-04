using MIS.IBLL;
using MIS.IDAL;
using MIS.Model.Page;
using MIS.Model.Result;
using MIS.Model.Sys.SysFile;
using MIS.Model.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.BLL
{
    public class SysFileBLL : ISysFileBLL
    {

        public ISysFileDAL _sysFileDAL;

        public SysFileBLL(ISysFileDAL sysFileDAL)
        {
            this._sysFileDAL = sysFileDAL;
        }


        /// <summary>
        /// 获取文件树的信息
        /// </summary>
        /// <param name="parentUnqiueId"></param>
        /// <returns></returns>
        public List<TreeNode> GetSysFileTreeNodes(Guid parentUnqiueId)
        {
            return _sysFileDAL.GetSysFileTreeNodes(parentUnqiueId);
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        public RequestResult Add(SysFileInputForm inputForm)
        {
            return _sysFileDAL.Add(inputForm);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="uniqueId"></param>
        /// <returns></returns>
        public RequestResult Delete(Guid uniqueId)
        {
            return _sysFileDAL.Delete(uniqueId);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        public RequestResult Edit(SysFileInputForm inputForm)
        {
            return _sysFileDAL.Edit(inputForm);
        }

        /// <summary>
        /// 根据唯一编码获取数据
        /// </summary>
        /// <param name="uniqueId"></param>
        /// <returns></returns>
        public SysFileInputForm GetItemByUniqueId(Guid uniqueId)
        {
            return _sysFileDAL.GetItemByUniqueId(uniqueId);
        }

        /// <summary>
        /// 初始化文件树
        /// </summary>
        /// <returns></returns>
        public List<TreeNode> InitTree()
        {
            return _sysFileDAL.InitTree();
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public PageData Query(SysFileParameter parameter)
        {
            return _sysFileDAL.Query(parameter);
        }
    }
}
