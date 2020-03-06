using MIS.EFDataSource;
using MIS.IDAL;
using MIS.Utility;
using MIS.Utility.GuidUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MIS.Utility.EnumUtility.SystemEnums;

namespace MIS.DAL
{
   public class SysLogDAL:ISysLogDAL
    {
        /// <summary>
        /// 向数据库中写入异常日志
        /// </summary>
        /// <param name="ex"></param>
        public void WriteLog(Exception ex)
        {
            MISEntities db = new MISEntities();
            Sys_ExceptionLog exceptionLog = new Sys_ExceptionLog();

            exceptionLog.UniqueId = GuidUtils.NewGuid();
            exceptionLog.LogLevel = LogLevel.Error.ToString();
            exceptionLog.Message = ex.Message;
            exceptionLog.TargetSite = ex.TargetSite.ToString();
            exceptionLog.StackTrace = ex.StackTrace;
            exceptionLog.CreateUser= SessionUtils.GetAccountUnqiueId();
            exceptionLog.CreateTime = DateTime.Now;

            db.Sys_ExceptionLog.Add(exceptionLog);
            db.SaveChanges();
        }

        public static void WriteLogToDb(Exception ex)
        {
            MISEntities db = new MISEntities();
            Sys_ExceptionLog exceptionLog = new Sys_ExceptionLog();

            exceptionLog.UniqueId = GuidUtils.NewGuid();
            exceptionLog.LogLevel = LogLevel.Error.ToString();
            exceptionLog.Message = ex.Message;
            exceptionLog.TargetSite = ex.TargetSite.ToString();
            exceptionLog.StackTrace = ex.StackTrace;
            exceptionLog.CreateUser = SessionUtils.GetAccountUnqiueId();
            exceptionLog.CreateTime = DateTime.Now;

            db.Sys_ExceptionLog.Add(exceptionLog);
            db.SaveChanges();
        }

    }
}
