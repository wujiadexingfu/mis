using MIS.IBLL;
using MIS.IDAL;
using MIS.Model.Page;
using MIS.Model.Result;
using MIS.Model.Sys.SysOperation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.BLL
{
   public  class SysOperationBLL:ISysOperationBLL
    {
        private ISysOperationDAL _sysOperationDAL;

        public SysOperationBLL(ISysOperationDAL sysOperationDAL)
        {
            this._sysOperationDAL = sysOperationDAL;
        }

        /// <summary>
        /// 查询操作信息
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public PageData Query(SysOperationParameter parameter)
        {
            return _sysOperationDAL.Query(parameter);
        }

        /// <summary>
        /// 根据UniqueId获取操作信息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public SysOperationInputForm GetOperationByUniqueId(string uniqueId)
        {
            return _sysOperationDAL.GetOperationByUniqueId(uniqueId);
        }


        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        public RequestResult Add(SysOperationInputForm inputForm)
        {
            return _sysOperationDAL.Add(inputForm);
        }


        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        public  RequestResult Edit(SysOperationInputForm inputForm)
        {
            return _sysOperationDAL.Edit(inputForm);
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="uniqueId"></param>
        /// <returns></returns>
        public RequestResult Delete(string uniqueId)
        {
            return _sysOperationDAL.Delete(uniqueId);
        }


        /// <summary>
        /// 新增操作和菜单的关联
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        public RequestResult AddOperationFunction(SysOperationFunctionInputForm inputForm)
        {
            return _sysOperationDAL.AddOperationFunction(inputForm);
        }

    }
}
