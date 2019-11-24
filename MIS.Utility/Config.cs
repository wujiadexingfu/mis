using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


/********************************************************************************

** 类名称：  Config

** 描述：********

** 作者： zhangyang

** Version: 1.0

** 创建时间：2019-11-24 19:38:38

** 最后修改人：（无）

** 最后修改时间：（无）

** CLR版本：4.0.30319.42000      

** 版权所有 (C) :zhangyang

*********************************************************************************/

namespace MIS.Utility
{
    public class Config
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
