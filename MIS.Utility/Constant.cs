using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/********************************************************************************

** 类名称：  Constant

** 描述：********

** 作者： zhangyang

** Version: 1.0

** 创建时间：2019-11-24 19:37:50

** 最后修改人：（无）

** 最后修改时间：（无）

** CLR版本：4.0.30319.42000      

** 版权所有 (C) :zhangyang

*********************************************************************************/

namespace MIS.Utility
{
    public class Constant
    {
        /// <summary>
        /// xml文件名称
        /// </summary>
        private const string ConfigFileName = "Utility.Config.xml";  //xml文件的文件名

        /// <summary>
        /// 版本号
        /// </summary>
        public const int VerionCode = 1;

        /// <summary>
        /// 版本名称
        /// </summary>
        public const string VersionName = "2019.8.8";

        public const string Account = "Account";

        public const string GuidEmpty = "00000000-0000-0000-0000-000000000000";


        #region  配置文件的目录
        public static string ConfigFile
        {
            get
            {
                string exePath = System.AppDomain.CurrentDomain.BaseDirectory;

                string filePath = Path.Combine(exePath, ConfigFileName);

                if (File.Exists(filePath))
                {
                    return filePath;
                }
                else
                {
                    filePath = Path.Combine(exePath, "bin", ConfigFileName);

                    if (File.Exists(filePath))
                    {
                        return filePath;
                    }
                    else
                    {
                        return ConfigFileName;
                    }
                }
            }
        }
        #endregion

        /// <summary>
        /// 默认密码
        /// </summary>
        public const string DefaultPassword = "123456";

      

    }
}
