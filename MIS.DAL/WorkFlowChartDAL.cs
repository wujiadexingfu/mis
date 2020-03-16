using MIS.EFDataSource;
using MIS.IDAL;
using MIS.Model.Page;
using MIS.Model.Result;
using MIS.Model.WorkFlow.WorkFlowChart;
using MIS.Model.WorkFlow.WorkFlowInstanceLog;
using MIS.Model.WorkFlow.WorkFlowLine;
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


        /// <summary>
        /// 保存连线，不存在则新增，存在则修改
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        public RequestResult SaveWorkFlowLine(WorkFlowLineInputForm inputForm)
        {
            RequestResult result = new RequestResult();

            try
            {
                MISEntities db = new MISEntities();
                var workFlowLine = db.WorkFlow_Line.Where(x => x.LineId == inputForm.LineId).FirstOrDefault();
                if (workFlowLine == null)  //为空，则新增
                {
                    workFlowLine= new WorkFlow_Line();
                    workFlowLine.UniqueId = GuidUtils.NewGuid();
                    workFlowLine.WorkFlowChartUniqueId = inputForm.WorkFlowChartUniqueId;
                    workFlowLine.Name = inputForm.LineName;
                    workFlowLine.LineId = inputForm.LineId;
                    workFlowLine.ToStepId = inputForm.ToStepId;
                    workFlowLine.FromStepId = inputForm.FromStepId;
                    workFlowLine.LineType = inputForm.LineType;
                    workFlowLine.CreateTime = DateTime.Now;
                    workFlowLine.CreateUser = SessionUtils.GetAccountUnqiueId();
                    db.WorkFlow_Line.Add(workFlowLine);
                }
                else  //不为空，则修改
                {
                    workFlowLine.WorkFlowChartUniqueId = inputForm.WorkFlowChartUniqueId;
                    workFlowLine.Name = inputForm.LineName;
                    workFlowLine.ToStepId = inputForm.ToStepId;
                    workFlowLine.FromStepId = inputForm.FromStepId;
                    workFlowLine.LineType = inputForm.LineType;
                    workFlowLine.ModifyTime = DateTime.Now;
                    workFlowLine.ModifyUser = SessionUtils.GetAccountUnqiueId();
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

        /// <summary>
        /// 保存流程图信息
        /// </summary>
        /// <param name="inputForm"></param>
        /// <param name="workFlowChartStepNodes"></param>
        /// <param name="workFlowLineNodes"></param>
        /// <returns></returns>
        public RequestResult SaveWorkFlowChartContent(WorkFlowChartInputForm inputForm,List<WorkFlowStepNode> workFlowChartStepNodes ,List<WorkFlowLineNode> workFlowLineNodes)
        {
            RequestResult result = new RequestResult();

            try
            {
                MISEntities db = new MISEntities();
                var workFlowChart = db.WorkFlow_Chart.Where(x => x.UniqueId == inputForm.UniqueId).FirstOrDefault();
                workFlowChart.FlowChartContent = inputForm.FlowChartContent;
                workFlowChart.ModifyTime = DateTime.Now;
                workFlowChart.ModifyUser = SessionUtils.GetAccountUnqiueId();


                bool checStep = false;
                bool checkLine = false;
                string message = "";


                var savedWorkFlowSteps = db.WorkFlow_Step.Where(x => x.WorkFlowChartUniqueId == inputForm.UniqueId).ToList(); //获取所有的节点信息
                var saveWorkFlowLines = db.WorkFlow_Line.Where(x => x.WorkFlowChartUniqueId == inputForm.UniqueId).ToList(); //获取所有的连线信息

                foreach (var item in workFlowChartStepNodes)
                {
                    if (!savedWorkFlowSteps.Any(x => x.StepId == item.Id)) //判断，有节点尚未保存
                    {
                        checStep = true;
                        message += string.Format("{0}节点尚未保存！<br/>", item.Name);
                        break;
                    }
                }


                foreach (var item in workFlowLineNodes)
                {
                    if (!saveWorkFlowLines.Any(x => x.LineId == item.Id)) //判断，有连线尚未保存
                    {
                        checkLine = true;
                        message += string.Format("连线尚未保存！");
                        break;
                    }
                }

                if (checkLine || checStep)
                {
                    result.ReturnFailedMessage(message);
                }
                else
                {

                    foreach (var item in workFlowLineNodes)
                    {
                        var formStep = savedWorkFlowSteps.Where(x => x.StepId == item.From).FirstOrDefault(); //连线的开始节点
                        var toStep = savedWorkFlowSteps.Where(x => x.StepId == item.To).FirstOrDefault(); //连线的结束节点
                        var line = saveWorkFlowLines.Where(x => x.LineId == item.Id).FirstOrDefault();  //连线

                        line.FromStepUniqueId = formStep.UniqueId;
                        line.ToStepUnqiueId = toStep.UniqueId;
                    }


                    var deleteWorkFlowNodeStepIdList= savedWorkFlowSteps.Select(x=>x.StepId).Except(workFlowChartStepNodes.Select(x=>x.Id)).ToList();  //之前保存，后来删除的节点

                    var deleteWorkFlowNodeLineIdList = saveWorkFlowLines.Select(x => x.LineId).Except(workFlowLineNodes.Select(x => x.Id)).ToList();  //之前保存，后来删除的连线

                    var deleteWorkFlowNodeStepList = savedWorkFlowSteps.Where(x => deleteWorkFlowNodeStepIdList.Contains(x.StepId)).ToList();

                    var deleteWorkFlowNodeLineList = saveWorkFlowLines.Where(x => deleteWorkFlowNodeLineIdList.Contains(x.LineId)).ToList();


                    db.WorkFlow_Line.RemoveRange(deleteWorkFlowNodeLineList);
                    db.WorkFlow_Step.RemoveRange(deleteWorkFlowNodeStepList);


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
        /// 获取节点的信息
        /// </summary>
        /// <param name="stepId"></param>
        /// <returns></returns>
        public WorkFlowStepInputForm GetWorkFlowStepByStepId(string stepId)
        {
            MISEntities db = new MISEntities();

            var item= db.WorkFlow_Step.Where(x => x.StepId == stepId).Select(x => new WorkFlowStepInputForm()
            {
                 WorkFlowChartUniqueId=x.WorkFlowChartUniqueId,
                 Name=x.Name,
                 StepId=x.StepId,
                 StepLeft=x.StepLeft,
                 StepTop=x.StepTop,
                 StepState=x.StepState,
                 AuditingType=x.AuditingType,
                 IsBegin=x.IsBegin,
                 ActionUrl=x.ActionUrl,
                 StepRole=x.StepRole,
                 SaveFunction=x.SaveFunction,
                 TableName=x.TableName

            }).FirstOrDefault();


            if (item == null)
            {
                item = new WorkFlowStepInputForm();
                item.Name = "";
                item.StepId = "";
                item.StepState = "";
                item.AuditingType = "";
                item.ActionUrl = "";
                item.StepRole =null;
                item.SaveFunction = "";
                item.TableName = "";

            }
            return item;
        }

        /// <summary>
        ///   获取连线的信息
        /// </summary>
        /// <param name="lineId"></param>
        /// <returns></returns>
        public WorkFlowLineInputForm GetWorkFlowLineByLineId(string lineId)
        {
            MISEntities db = new MISEntities();

            var item = db.WorkFlow_Line.Where(x => x.LineId == lineId).Select(x => new WorkFlowLineInputForm()
            {
                WorkFlowChartUniqueId = x.WorkFlowChartUniqueId,
                LineType = x.LineType,
                LineName=x.Name
            }).FirstOrDefault();


            if (item == null)
            {
                item = new WorkFlowLineInputForm();
                item.LineType = "";
                item.LineName = "";

            }
            return item;
        }

        /// <summary>
        /// 获取流程日志
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public PageData GetWorkFlowInstanceLogs(WorkFlowInstanceLogParameter parameter)
        {

     

            using (MISEntities db = new MISEntities())
            {
                var query = db.WorkFlow_InstanceLog.Where(x => x.WorkFlowInstanceUniqueId == parameter.WorkFlowInstanceUniqueId).AsQueryable();

                var count = query.Count();
                var list = query.OrderByDescending(x => x.CreateTime).Skip((parameter.Page - 1) * parameter.Limit).Take(parameter.Limit).Select(x => x).ToList();


                var workFlowInstance = db.WorkFlow_Instance.Where(x => x.UniqueId == parameter.WorkFlowInstanceUniqueId).FirstOrDefault();

                var stepList = db.WorkFlow_Step.Where(x => x.WorkFlowChartUniqueId == workFlowInstance.WorkFlowChartUniqueId).ToList();
                var lineList = db.WorkFlow_Line.Where(x => x.WorkFlowChartUniqueId == workFlowInstance.WorkFlowChartUniqueId).ToList();
                var userList = db.Sys_User.ToList();


                List<WorkFlowInstanceLogGrid> result = new List<WorkFlowInstanceLogGrid>();
                foreach (var item in list)
                {
                    WorkFlowInstanceLogGrid workFlowInstanceLogGrid = new WorkFlowInstanceLogGrid();
                    workFlowInstanceLogGrid.UniqueId = item.UniqueId;
                    workFlowInstanceLogGrid.FromStepName = stepList.Where(x => x.UniqueId == item.FromStepUniqueId).FirstOrDefault().Name; 
                    workFlowInstanceLogGrid.LineName = lineList.Where(x=>x.UniqueId==item.LineUniqueId).FirstOrDefault().Name;
                    workFlowInstanceLogGrid.CreateUser = userList.Where(x => x.UniqueId == item.CreateUser).FirstOrDefault().Name;
                    workFlowInstanceLogGrid.Remark = item.Remark;
                    workFlowInstanceLogGrid.CreateTime = item.CreateTime.Value.ToString(DateTimeFormatter.YYYYMMDDHHMMSS);

                    result.Add(workFlowInstanceLogGrid);
                }

                PageData pageData = new PageData(count, result);
                return pageData;
            }


        }



    }
}
