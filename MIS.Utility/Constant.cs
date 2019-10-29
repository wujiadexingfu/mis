/*************************************************************************************
* CLR版本：        4.0.30319.42000
* 类 名 称：       Constant
* 命名空间：       MIS.Utility
* 文 件 名：       Constant
* 创建时间：       2019/10/26 19:14:16
* 作    者：       zhangyang
* 说   明：
* 修改时间：
* 修 改 人：
*************************************************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

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

    }
}
