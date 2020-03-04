using MIS.Model.Page;
using MIS.Model.Result;
using MIS.Model.Sys.SysFile;
using MIS.Model.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.IBLL
{
    public interface ISysFileBLL
    {
        /// <summary>
        /// 初始化文件树
        /// </summary>
        /// <returns></returns>
        List<TreeNode> InitTree();


        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        RequestResult Edit(SysFileInputForm inputForm);


        /// <summary>
        /// 获取文件树的信息
        /// </summary>
        /// <param name="parentUnqiueId"></param>
        /// <returns></returns>
        List<TreeNode> GetSysFileTreeNodes(Guid parentUnqiueId);


        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        RequestResult Add(SysFileInputForm inputForm);



        /// <summary>
        /// 根据唯一编码获取数据
        /// </summary>
        /// <param name="uniqueId"></param>
        /// <returns></returns>
        SysFileInputForm GetItemByUniqueId(Guid uniqueId);


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
        PageData Query(SysFileParameter parameter);
    }
}
