using MIS.Model.Page;
using MIS.Model.Result;
using MIS.Model.WorkFlowInstance.WorkFlowRegisterUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.IBLL
{
  public  interface IWorkFlowRegisterUserBLL
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        PageData Query(WorkFlowRegisterUserParameter parameter);


        /// <summary>
        /// 根据UniqueId获取角色信息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        WorkFlowRegisterUserInputForm GetItemByUniqueId(Guid uniqueId);


        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        RequestResult Add(WorkFlowRegisterUserInputForm inputForm);


        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        RequestResult Edit(WorkFlowRegisterUserInputForm inputForm);


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="uniqueId"></param>
        /// <returns></returns>
        RequestResult Delete(Guid uniqueId);
    }
}
