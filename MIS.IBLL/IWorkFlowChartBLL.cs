using MIS.Model.Page;
using MIS.Model.Result;
using MIS.Model.WorkFlow.WorkFlowChart;
using MIS.Model.WorkFlow.WorkFlowLine;
using MIS.Model.WorkFlow.WorkFlowStep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.IBLL
{
    public interface IWorkFlowChartBLL
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        PageData Query(WorkFlowChartParameter parameter);


        /// 根据UniqueId获取流程图信息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        WorkFlowChartInputForm GetItemByUniqueId(Guid uniqueId);


        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        RequestResult Add(WorkFlowChartInputForm inputForm);


        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        RequestResult Edit(WorkFlowChartInputForm inputForm);


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="uniqueId"></param>
        /// <returns></returns>
        RequestResult Delete(Guid uniqueId);


        /// <summary>
        /// 保存节点，不存在则新增，存在则修改
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        RequestResult SaveWorkFlowStep(WorkFlowStepInputForm inputForm);


        /// <summary>
        /// 保存连线，不存在则新增，存在则修改
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        RequestResult SaveWorkFlowLine(WorkFlowLineInputForm inputForm);


        /// <summary>
        /// 保存流程图信息
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        RequestResult SaveWorkFlowChartContent(WorkFlowChartInputForm inputForm);


        /// <summary>
        /// 获取节点的信息
        /// </summary>
        /// <param name="stepId"></param>
        /// <returns></returns>
        WorkFlowStepInputForm GetWorkFlowStepByStepId(string stepId);


        /// <summary>
        ///   获取连线的信息
        /// </summary>
        /// <param name="lineId"></param>
        /// <returns></returns>
        WorkFlowLineInputForm GetWorkFlowLineByLineId(string lineId);
    }
}
