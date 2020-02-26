using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Utility.BoolUtility
{
   public  class BoolUtils
    {
        /// <summary>
        /// 将string类型变为bool型
        /// </summary>
        /// <param name="str">参数为on和off</param>
        /// <returns></returns>
        public static bool StringToBool(string str) {

            if (string.IsNullOrEmpty(str))
            {
                return false;
            }else if (str.Trim().ToUpper() == "ON")
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /// <summary>
        /// 将bool类型变为string类型
        /// </summary>
        /// <param name="bol">参数</param>
        /// <returns></returns>
        public static string BoolToString(bool? bol)
        {
            if (bol == null)
            {
                return "";
            }
            else if (bol.Value == false)
            {
                return "";
            }
            else
            {
                return "on";
            }


        }

    }
}
