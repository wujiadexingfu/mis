﻿using MIS.EFDataSource;
using MIS.IDAL;
using MIS.Model.Page;
using MIS.Model.Result;
using MIS.Model.Sys.SysOperation;
using MIS.Utility;
using MIS.Utility.GuidUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.DAL
{
   public  class SysOperationDAL: ISysOperationDAL
    {
        private ISysLogDAL _sysLogDAL;
        public SysOperationDAL(ISysLogDAL sysLogDAL)
        {
            _sysLogDAL = sysLogDAL;
        }

        /// <summary>
        /// 查询操作信息
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public PageData Query(SysOperationParameter parameter)
        {
            using (MISEntities db = new MISEntities())
            {
                var query = db.Sys_Operation.AsQueryable();
                if (!string.IsNullOrEmpty(parameter.KeyWord))
                {
                    query = query.Where(x => x.Name.Contains(parameter.KeyWord) || x.Id.Contains(parameter.KeyWord));
                }

                var count = query.Count();
                var list = query.OrderBy(x => x.Id).Skip((parameter.Page - 1) * parameter.Limit).Take(parameter.Limit).Select(x=>new SysOperationGrid(){
                     UniqueId=x.UniqueId,
                      Id=x.Id,
                      Name=x.Name
                }).ToList();
  
                PageData pageData = new PageData(count, list);
                return pageData;
            }
        }



        /// <summary>
        /// 根据UniqueId获取操作信息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public SysOperationInputForm GetOperationByUniqueId(Guid uniqueId)
        {
            MISEntities db = new MISEntities();
            var item = db.Sys_Operation.Where(x => x.UniqueId == uniqueId).Select(x=>new SysOperationInputForm() {
                UniqueId=x.UniqueId,
                 Id=x.Id,
                 Name=x.Name

            }).FirstOrDefault();
            return item;

        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        public RequestResult Add(SysOperationInputForm inputForm)
        {
            RequestResult result = new RequestResult();

            try
            {
                MISEntities db = new MISEntities();
                if (db.Sys_Operation.Any(x => x.Id == inputForm.Id))
                {
                    result.ReturnFailedMessage("编号重复");
                }
                else
                {

                    Sys_Operation operation = new Sys_Operation();
                    operation.UniqueId = GuidUtils.NewGuid();
                    operation.Id = inputForm.Id;
                    operation.Name = inputForm.Name;
                    operation.CreateTime = DateTime.Now;
                    operation.CreateUser = SessionUtils.GetAccountUnqiueId();
                    db.Sys_Operation.Add(operation);
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
        public RequestResult Edit(SysOperationInputForm inputForm)
        {
            RequestResult result = new RequestResult();

            try
            {
                MISEntities db = new MISEntities();
                if (db.Sys_Operation.Any(x => x.Id == inputForm.Id && x.UniqueId != inputForm.UniqueId))
                {
                    result.ReturnFailedMessage("编号重复");
                }
                else
                {
                    var  item = db.Sys_Operation.Where(x => x.UniqueId == inputForm.UniqueId).FirstOrDefault();
                    item.Id = inputForm.Id;
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
                var item = db.Sys_Operation.Where(x => x.UniqueId == uniqueId).FirstOrDefault();
                db.Sys_Operation.Remove(item);
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
        /// 新增操作和菜单的关联
        /// </summary>
        /// <param name="inputForm"></param>
        /// <returns></returns>
        public RequestResult AddOperationFunction(SysOperationFunctionInputForm inputForm)
        {
            RequestResult result = new RequestResult();

            try
            {
                MISEntities db = new MISEntities();
                var existsOperationFunctionList = db.Sys_OperationFunction.Where(x => x.OperationUniqueId == inputForm.OperationUnqiueId).ToList();
                //db.Sys_OperationFunction.RemoveRange(deleteOperationFunctionList); //首先删除原来的操作和菜单的数据
                //  var functionList = db.Sys_Function.ToList();
                var deleteOperationFunctionList = new List<Sys_OperationFunction>();


                foreach (var item in inputForm.FunctionList)
                {

                    if (existsOperationFunctionList.Any(x =>  x.FunctionId == item))  //存在，无视
                    {

                    }
                    else {
                        Sys_OperationFunction operationFunction = new Sys_OperationFunction();
                        operationFunction.UniqueId = GuidUtils.NewGuid();
                        operationFunction.OperationUniqueId = inputForm.OperationUnqiueId;
                        operationFunction.FunctionId = item;
                        operationFunction.CreateUser = SessionUtils.GetAccountUnqiueId();
                        operationFunction.CreateTime = DateTime.Now;
                        db.Sys_OperationFunction.Add(operationFunction);
                    }

                }

                foreach (var item in existsOperationFunctionList)
                {
                    if (inputForm.FunctionList.Any(x => x.Contains(item.FunctionId)))
                    {

                    }
                    else
                    {
                        deleteOperationFunctionList.Add(item);
                    }




                }

                db.Sys_OperationFunction.RemoveRange(deleteOperationFunctionList);

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
