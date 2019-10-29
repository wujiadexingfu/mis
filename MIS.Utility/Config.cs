/*************************************************************************************
* CLR版本：        4.0.30319.42000
* 类 名 称：       Config
* 命名空间：       MIS.Utility
* 文 件 名：       Config
* 创建时间：       2019/10/26 21:11:59
* 作    者：       zhangyang
* 说   明：
* 修改时间：
* 修 改 人：
*************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace MIS.Utility
{
  public   class Config
    {
        /// <summary>
        /// 获取xml根节点
        /// </summary>
        private static XElement Root
        {
            get
            {
                return XDocument.Load(Constant.ConfigFile).Root;
            }
        }


    }
}
