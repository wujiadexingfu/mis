using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Utility.DateUtility
{
   public  class DateTimeUtils
    {
        /// 将datetime 类型变为string类型
        /// </summary>
        /// <param name="date">日期</param>
        /// <param name="formatter">转换格式</param>
        /// <returns></returns>
        public static string GetDateToString(DateTime? date, string formatter)
        {
            return date == null ? "" : date.Value.ToString(formatter);
        }

        /// <summary>
        /// 将datetime 类型变为yyyy-MM-dd的格式
        /// </summary>
        /// <param name="date">日期</param>
        /// <returns></returns>
        public static string GetDateToStringYYYY_MM_DD(DateTime? date)
        {
            return GetDateToString(date, DateTimeFormatter.YYYY_MM_DD);
        }


        public static DateTime? StringToDateTime(string date)
        {
            if (string.IsNullOrEmpty(date))
            {
                return null;
            }
            else {
              return    Convert.ToDateTime(date);
            }
        }

    }
}
