using MIS.EFDataSource;
using MIS.IDAL;
using MIS.Model.Page;
using MIS.Model.Result;
using MIS.Model.WorkFlow.WorkFlowChart;
using MIS.Model.WorkFlow.WorkFlowStep;
using MIS.Utility;
using MIS.Utility.DateUtility;
using MIS.Utility.GuidUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.DAL
{
    public class WorkFlowChartDAL: IWorkFlowChartDAL
    {
        private ISysLogDAL _sysLogDAL;
        public WorkFlowChartDAL(ISysLogDAL sysLogDAL)
        {
            _sysLogDAL = sysLogDAL;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public PageData Query(WorkFlowChartParameter parameter)
        {
            using (MISEntities db = new MISEntities())
            {
                var query = db.WorkFlow_Chart.AsQueryable();
                if (!string.IsNullOrEmpty(parameter.KeyWord))
                {
                    query = query.Where(x => x.Name.Contains(parameter.KeyWord));
                }

                var count = query.Count();
                var list = query.OrderBy(x => x.CreateTime).Skip((parameter.Page - 1) * parameter.Limit).Take(parameter.Limit).Select(x => new 
                {
                     x.UniqueId,
                     x.Name,
                     x.CreateTime,
                     x.CreateUser

                }).ToList();

                var userList = db.Sys_User.ToList();
                List<WorkFlowChartGrid> result = new List<WorkFlowChartGrid>();
                foreach (var item in list)
                {
                    WorkFlowChartGrid workFlowChartGrid = new WorkFlowChartGrid();
                    workFlowChartGrid.UniqueId = item.UniqueId;
                    workFlowChartGrid.Name = item.Name;
                    workFlowChartGrid.CreateUser = userList.Where(x => x.UniqueId == item.CreateUser).FirstOrDefault().Name;
                    workFlowChartGrid.CreateTime = item.CreateTime.Value.ToString(DateTimeFormatter.YYYY_MM_DD);
                    result.Add(workFlowChartGrid);
                }

                PageData pageData = new PageData(count, result);
                return pageData;
            }
        }



        /// <summary>
        /// 根据UniqueId获取流程图信息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public WorkFlowChartInputForm GetItemByUniqueId(Guid uniqueId)
        {
            MISEntities db = new MISEntities();
            var item = db.WorkFlow_Chart.Where(x => x.UniqueId == uniqueId).FirstOrDefault();
            WorkFlowChartInputForm inputForm = new WorkFlowChartInputForm()
            {
                UniqueId = item.UniqueId,
                Name = item.Name,
                FlowChartContent=item.FlowChartContent
            };

            return inputForm;

        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        public RequestResult Add(WorkFlowChartInputForm inputForm)
        {
            RequestResult result = new RequestResult();

            try
            {
                MISEntities db = new MISEntities();
                if (db.WorkFlow_Chart.Any(x => x.Name == inputForm.Name))
                {
                    result.ReturnFailedMessage("名称重复");
                }
                else
                {
                    WorkFlow_Chart item = new WorkFlow_Chart();
                    item.UniqueId = GuidUtils.NewGuid();
                    item.Name = inputForm.Name;
                    item.CreateTime = DateTime.Now;
                    item.CreateUser = SessionUtils.GetAccountUnqiueId();
                    db.WorkFlow_Chart.Add(item);
                    db.SaveChanges();
                    result.Success();
                }

            }
            catch (Exception ex)
            {
                _sysLogDAL.WriteLog(ex);
                result.ReturnFailedMessage(ex.Message);
            }
            return result;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        public RequestResult Edit(WorkFlowChartInputForm inputForm)
        {
            RequestResult result = new RequestResult();

            try
            {
                MISEntities db = new MISEntities();
                if (db.WorkFlow_Chart.Any(x => x.Name == inputForm.Name))
                {
                    result.ReturnFailedMessage("名称重复");
                }
                else
                {
                    WorkFlow_Chart item = db.WorkFlow_Chart.Where(x => x.UniqueId == inputForm.UniqueId).FirstOrDefault();
                    item.Name = inputForm.Name;
                    item.ModifyTime = DateTime.Now;
                    item.ModifyUser = SessionUtils.GetAccountUnqiueId();
                    db.SaveChanges();
                    result.Success();
                }

            }
            catch (Exception ex)
            {
                _sysLogDAL.WriteLog(ex);
                result.ReturnFailedMessage(ex.Message);
            }
            return result;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="uniqueId"></param>
        /// <returns></returns>
        public RequestResult Delete(Guid uniqueId)
        {
            RequestResult result = new RequestResult();

            try
            {
                MISEntities db = new MISEntities();
                var item = db.WorkFlow_Chart.Where(x => x.UniqueId == uniqueId).FirstOrDefault();
                db.WorkFlow_Chart.Remove(item);
                db.SaveChanges();
                result.Success();
            }
            catch (Exception ex)
            {
                _sysLogDAL.WriteLog(ex);
                result.ReturnFailedMessage(ex.Message);
            }
            return result;
        }


        /// <summary>
        /// 保存节点，不存在则新增，存在则修改
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        public RequestResult SaveWorkFlowStep(WorkFlowStepInputForm inputForm)
        {
            RequestResult result = new RequestResult();

            try
            {
                MISEntities db = new MISEntities();
                var workFlowStep = db.WorkFlow_Step.Where(x => x.StepId == inputForm.StepId).FirstOrDefault();
                if (workFlowStep == null)  //为空，则新增
                {
                    workFlowStep = new WorkFlow_Step();
                    workFlowStep.UniqueId = GuidUtils.NewGuid();
                    workFlowStep.WorkFlowChartUniqueId = inputForm.WorkFlowChartUniqueId;
                    workFlowStep.Name = inputForm.Name;
                    workFlowStep.StepId = inputForm.StepId;
                    workFlowStep.StepLeft = inputForm.StepLeft;
                    workFlowStep.StepTop = inputForm.StepTop;
                    workFlowStep.StepState = inputForm.StepState;
                    workFlowStep.AuditingType = inputForm.AuditingType;
                    workFlowStep.IsBegin = inputForm.IsBegin;
                    workFlowStep.ActionUrl = inputForm.ActionUrl;
                    workFlowStep.StepRole = inputForm.StepRole;

                    workFlowStep.SaveFunction = inputForm.SaveFunction;
                    workFlowStep.TableName = inputForm.TableName;
                    workFlowStep.CreateTime = DateTime.Now;
                    workFlowStep.CreateUser = SessionUtils.GetAccountUnqiueId();
                    db.WorkFlow_Step.Add(workFlowStep);
                }
                else  //不为空，则修改
                {
                    workFlowStep.Name = inputForm.Name;
                    workFlowStep.StepId = inputForm.StepId;
                    workFlowStep.StepLeft = inputForm.StepLeft;
                    workFlowStep.StepTop = inputForm.StepTop;
                    workFlowStep.StepState = inputForm.StepState;
                    workFlowStep.AuditingType = inputForm.AuditingType;
                    workFlowStep.IsBegin = inputForm.IsBegin;
                    workFlowStep.ActionUrl = inputForm.ActionUrl;
                    workFlowStep.StepRole = inputForm.StepRole;
                    workFlowStep.SaveFunction = inputForm.SaveFunction;
                    workFlowStep.TableName = inputForm.TableName;
                    workFlowStep.ModifyTime = DateTime.Now;
                    workFlowStep.ModifyUser = SessionUtils.GetAccountUnqiueId();
                }
                db.SaveChanges();
                result.Success();
            }
            catch (Exception ex)
            {
                _sysLogDAL.WriteLog(ex);
                result.ReturnFailedMessage(ex.Message);
            }
            return result;
        }



    }
}
