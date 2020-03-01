﻿using MIS.IBLL;
using MIS.IDAL;
using MIS.Model.Page;
using MIS.Model.Result;
using MIS.Model.Sys.SysCode;
using MIS.Model.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.BLL
{
  public   class SysCodeBLL: ISysCodeBLL
    {
        public ISysCodeDAL _sysCodeDAL;

        public SysCodeBLL(ISysCodeDAL sysCodeDAL)
        {
            _sysCodeDAL = sysCodeDAL;
        }


        /// <summary>
        /// 初始化参数树
        /// </summary>
        /// <returns></returns>
        public List<TreeNode> InitTree()
        {
            return _sysCodeDAL.InitTree();
        }


        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
         public  RequestResult Edit(SysCodeInputForm inputForm)
        {
            return _sysCodeDAL.Edit(inputForm);

        }


        /// <summary>
        /// 获取参数树的信息
        /// </summary>
        /// <param name="parentUnqiueId"></param>
        /// <returns></returns>
        public List<TreeNode> GetSysCodeTreeNodes(string parentUnqiueId)
        {
            return _sysCodeDAL.GetSysCodeTreeNodes(parentUnqiueId);
        }


        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        public RequestResult Add(SysCodeInputForm inputForm)
        {
            return _sysCodeDAL.Add(inputForm);
        }


        /// <summary>
        /// 根据唯一编码获取数据
        /// </summary>
        /// <param name="uniqueId"></param>
        /// <returns></returns>
        public SysCodeInputForm GetItemByUniqueId(string uniqueId)
        {
            return _sysCodeDAL.GetItemByUniqueId(uniqueId);
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="uniqueId"></param>
        /// <returns></returns>
        public  RequestResult Delete(string uniqueId)
        {
            return _sysCodeDAL.Delete(uniqueId);

        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public PageData Query(SysCodeParameter parameter)
        {
            return _sysCodeDAL.Query(parameter);
        }


    }
}
