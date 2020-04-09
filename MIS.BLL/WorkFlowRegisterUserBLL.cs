using MIS.IBLL;
using MIS.IDAL;
using MIS.Model.Page;
using MIS.Model.Result;
using MIS.Model.WorkFlowInstance.WorkFlowRegisterUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.BLL
{
   public class WorkFlowRegisterUserBLL:IWorkFlowRegisterUserBLL
    {
        private IWorkFlowRegisterUserDAL _workFlowRegisterUserDAL;
        public WorkFlowRegisterUserBLL(IWorkFlowRegisterUserDAL workFlowRegisterUserDAL)
        {
            this._workFlowRegisterUserDAL = workFlowRegisterUserDAL;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public PageData Query(WorkFlowRegisterUserParameter parameter)
        {
            return _workFlowRegisterUserDAL.Query(parameter);
        }


        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        public RequestResult Add(WorkFlowRegisterUserInputForm inputForm)
        {
            return _workFlowRegisterUserDAL.Add(inputForm);
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="uniqueId"></param>
        /// <returns></returns>
        public RequestResult Delete(Guid uniqueId)
        {
            return _workFlowRegisterUserDAL.Delete(uniqueId);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        public RequestResult Edit(WorkFlowRegisterUserInputForm inputForm)
        {
            return _workFlowRegisterUserDAL.Edit(inputForm);
        }

        /// <summary>
        /// 根据UniqueId获取角色信息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public WorkFlowRegisterUserInputForm GetItemByUniqueId(Guid workFlowInstanceUniqueId)
        {
            return _workFlowRegisterUserDAL.GetItemByUniqueId(workFlowInstanceUniqueId);
        }


       
    }
}
