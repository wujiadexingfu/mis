using MIS.Model.Page;
using MIS.Model.Result;
using MIS.Model.WorkFlow.WorkFlowChart;
using MIS.Model.WorkFlow.WorkFlowStep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.IDAL
{
    public interface IWorkFlowChartDAL
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



    }
}
