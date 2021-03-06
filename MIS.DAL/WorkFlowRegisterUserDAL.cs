﻿using MIS.EFDataSource;
using MIS.IDAL;
using MIS.Model.Page;
using MIS.Model.Result;
using MIS.Model.WorkFlowInstance.WorkFlowRegisterUser;
using MIS.Utility;
using MIS.Utility.DateUtility;
using MIS.Utility.GuidUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MIS.Utility.EnumUtility.SystemEnums;

namespace MIS.DAL
{
   public class WorkFlowRegisterUserDAL: IWorkFlowRegisterUserDAL
    {
        private ISysLogDAL _sysLogDAL;
        private IWorkFlowInstanceDAL _workFlowInstanceDAL;


        public WorkFlowRegisterUserDAL(ISysLogDAL sysLogDAL, IWorkFlowInstanceDAL workFlowInstanceDAL)
        {
            _sysLogDAL = sysLogDAL;
            _workFlowInstanceDAL = workFlowInstanceDAL;
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public PageData Query(WorkFlowRegisterUserParameter parameter)
        {
            using (MISEntities db = new MISEntities())
            {
                var query = db.WorkFlow_ReginsterUser.AsQueryable();
                if (!string.IsNullOrEmpty(parameter.KeyWord))
                {
                    query = query.Where(x => x.Name.Contains(parameter.KeyWord) || x.Id.Contains(parameter.KeyWord));
                }

                var count = query.Count();
                var list = query.OrderBy(x => x.Id).Skip((parameter.Page - 1) * parameter.Limit).Take(parameter.Limit).Select(x => new 
                {
                     x.UniqueId,
                     x.Id,
                     x.Name,
                     x.BirthDay,
                     x.Remark,
                    x.WorkFlowInstanceUniqueId
                }).ToList();


                List<WorkFlowRegisterUserGrid> workFlowRegisterUserGrids = new List<WorkFlowRegisterUserGrid>();
                foreach (var item in list)
                {
                    WorkFlowRegisterUserGrid model = new WorkFlowRegisterUserGrid();
                    model.UniqueId = item.UniqueId;
                    model.Id = item.Id;
                    model.Name = item.Name;
                    model.Remark = item.Remark;
                    model.BirthDay = item.BirthDay.Value.ToString(DateTimeFormatter.YYYYMMDD);
                    model.WorkFlowStep = (from x in db.WorkFlow_Instance join x1 in db.WorkFlow_Step on x.CurrentStepUniqueId equals x1.UniqueId where x.UniqueId == item.WorkFlowInstanceUniqueId select x1).FirstOrDefault().Name;
                    model.WorkFlowInstanceUniqueId = item.WorkFlowInstanceUniqueId;


                    workFlowRegisterUserGrids.Add(model);

                }
                PageData pageData = new PageData(count, workFlowRegisterUserGrids);
                return pageData;
            }
        }



        /// <summary>
        /// 根据UniqueId获取角色信息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public WorkFlowRegisterUserInputForm GetItemByUniqueId(Guid workFlowInstanceUniqueId)
        {
            MISEntities db = new MISEntities();
            var item = db.WorkFlow_ReginsterUser.Where(x => x.WorkFlowInstanceUniqueId == workFlowInstanceUniqueId).FirstOrDefault();
            WorkFlowRegisterUserInputForm inputForm = new WorkFlowRegisterUserInputForm()
            {
                UniqueId = item.UniqueId,
                Id = item.Id,
                Name = item.Name,
                BirthDay=item.BirthDay,
                Remark=item.Remark
            };

            return inputForm;

        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        public RequestResult Add(WorkFlowRegisterUserInputForm inputForm)
        {
            RequestResult result = new RequestResult();

            try
            {
                MISEntities db = new MISEntities();
                if (db.WorkFlow_ReginsterUser.Any(x => x.Id == inputForm.Id))
                {
                    result.ReturnFailedMessage("编号重复");
                }
                else
                {
                    var addInstanceDraftStepResult = _workFlowInstanceDAL.AddInstanceDraftStep(inputForm.Name + "申请流程", WorkFlowChartType.WorkFlow_ReginsterUser);
;
                    if (addInstanceDraftStepResult.IsSuccess)
                    {
                        WorkFlow_ReginsterUser item = new WorkFlow_ReginsterUser();
                        item.UniqueId = GuidUtils.NewGuid();
                        item.Id = inputForm.Id;
                        item.Name = inputForm.Name;
                        item.Remark = inputForm.Remark;
                        item.BirthDay = inputForm.BirthDay;
                        item.CreateTime = DateTime.Now;
                        item.CreateUser = SessionUtils.GetAccountUnqiueId();
                        item.WorkFlowInstanceUniqueId =new Guid(addInstanceDraftStepResult.Data.ToString());
                        db.WorkFlow_ReginsterUser.Add(item);
                        db.SaveChanges();
                        result.ReturnData(addInstanceDraftStepResult.Data.ToString());
                    }
                    else {
                        result = addInstanceDraftStepResult;
                    }
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
        public RequestResult Edit(WorkFlowRegisterUserInputForm inputForm)
        {
            RequestResult result = new RequestResult();

            try
            {
                MISEntities db = new MISEntities();
                if (db.WorkFlow_ReginsterUser.Any(x => x.Id == inputForm.Id && x.UniqueId != inputForm.UniqueId))
                {
                    result.ReturnFailedMessage("编号重复");
                }
                else
                {
                    WorkFlow_ReginsterUser item = db.WorkFlow_ReginsterUser.Where(x => x.UniqueId == inputForm.UniqueId).FirstOrDefault();
                    item.Id = inputForm.Id;
                    item.Name = inputForm.Name;
                    item.ModifyTime = DateTime.Now;
                    item.BirthDay = inputForm.BirthDay;
                    item.Remark = inputForm.Remark;


                    if (inputForm.ResisterUserType == ResisterUserType.SupervisorAudit.ToString())
                    {
                        item.SupervisorAudit= SessionUtils.GetAccountUnqiueId();
                        item.SupervisorAuditTime = DateTime.Now;

                    }

                    if (inputForm.ResisterUserType == ResisterUserType.SupervisorReview.ToString())
                    {
                        item.SupervisorAudit = SessionUtils.GetAccountUnqiueId();
                        item.SupervisorReviewTime = DateTime.Now;
                    }

                    if (inputForm.ResisterUserType == ResisterUserType.FinalAudit.ToString())
                    {
                        item.FinalAudit = SessionUtils.GetAccountUnqiueId();
                        item.FinalAuditTime = DateTime.Now;
                    }


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
                var item = db.WorkFlow_ReginsterUser.Where(x => x.UniqueId == uniqueId).FirstOrDefault();
                db.WorkFlow_ReginsterUser.Remove(item);

                var workFlowInstance = db.WorkFlow_Instance.Where(x => x.ObjectUniqueId == item.UniqueId).FirstOrDefault();
                db.WorkFlow_Instance.Remove(workFlowInstance);

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
