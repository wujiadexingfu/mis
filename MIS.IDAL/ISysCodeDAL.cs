﻿using MIS.Model.Page;
using MIS.Model.Result;
using MIS.Model.Sys.SysCode;
using MIS.Model.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.IDAL
{
   public  interface ISysCodeDAL
    {  
        /// <summary>
       /// 初始化参数树
       /// </summary>
       /// <returns></returns>
        List<TreeNode> InitTree();


        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        RequestResult Edit(SysCodeInputForm inputForm);


        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        RequestResult Add(SysCodeInputForm inputForm);


        /// <summary>
        /// 获取参数树的信息
        /// </summary>
        /// <param name="parentUnqiueId"></param>
        /// <returns></returns>
        List<TreeNode> GetSysCodeTreeNodes(string parentUnqiueId);

        /// <summary>
        /// 根据唯一编码获取数据
        /// </summary>
        /// <param name="uniqueId"></param>
        /// <returns></returns>
        SysCodeInputForm GetItemByUniqueId(string uniqueId);


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="uniqueId"></param>
        /// <returns></returns>
        RequestResult Delete(string uniqueId);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        PageData Query(SysCodeParameter parameter);
    }
}
