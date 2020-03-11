using MIS.IBLL;
using MIS.IDAL;
using MIS.Model.Page;
using MIS.Model.Result;
using MIS.Model.WorkFlow.WorkFlowChart;
using MIS.Model.WorkFlow.WorkFlowStep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.BLL
{
  public   class WorkFlowChartBLL: IWorkFlowChartBLL
    {
        IWorkFlowChartDAL _workFlowChartDAL;
        public WorkFlowChartBLL(IWorkFlowChartDAL workFlowChartDAL)
        {
            _workFlowChartDAL = workFlowChartDAL;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public PageData Query(WorkFlowChartParameter parameter)
        {
            return _workFlowChartDAL.Query(parameter);
        }


        /// 根据UniqueId获取流程图信息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public WorkFlowChartInputForm GetItemByUniqueId(Guid uniqueId)
        {
            return _workFlowChartDAL.GetItemByUniqueId(uniqueId);
        }


        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        public RequestResult Add(WorkFlowChartInputForm inputForm)
        {
            return _workFlowChartDAL.Add(inputForm);
        }


        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        public RequestResult Edit(WorkFlowChartInputForm inputForm)
        {
            return _workFlowChartDAL.Edit(inputForm);
        }


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="uniqueId"></param>
        /// <returns></returns>
        public RequestResult Delete(Guid uniqueId)
        {
            return _workFlowChartDAL.Delete(uniqueId);
        }

        /// <summary>
        /// 保存节点，不存在则新增，存在则修改
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        public RequestResult SaveWorkFlowStep(WorkFlowStepInputForm inputForm)
        {
            return _workFlowChartDAL.SaveWorkFlowStep(inputForm);
        }
    }
}
