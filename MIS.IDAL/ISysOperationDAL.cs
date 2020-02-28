using MIS.Model.Page;
using MIS.Model.Result;
using MIS.Model.Sys.SysOperation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.IDAL
{
   public  interface ISysOperationDAL
    {
        /// <summary>
        /// 查询操作信息
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        PageData Query(SysOperationParameter parameter);

        /// <summary>
        /// 根据UniqueId获取操作信息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        SysOperationInputForm GetOperationByUniqueId(string uniqueId);


        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        RequestResult Add(SysOperationInputForm inputForm);


        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        RequestResult Edit(SysOperationInputForm inputForm);


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="uniqueId"></param>
        /// <returns></returns>
        RequestResult Delete(string uniqueId);


        /// <summary>
        /// 新增操作和菜单的关联
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        RequestResult AddOperationFunction(SysOperationFunctionInputForm inputForm);
    }
}
