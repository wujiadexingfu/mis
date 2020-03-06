using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Utility.LogUtility
{
    public class LogUtils
    {
        private Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public void Trace(Exception ex)
        {

        }

        public void Debug(Exception ex)
        {

        }


        public void Info(Exception ex)
        {

        }


        public void Warn(Exception ex)
        {

        }


        public void Error(Exception ex)
        {

        }


        public void Fatal(Exception ex)
        {

        }

        private void WriteLog(Exception ex, LogLevel logLevel)
        {

        }



    }
}
