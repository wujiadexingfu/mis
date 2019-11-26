/*************************************************************************************
* CLR版本：        4.0.30319.42000
* 类 名 称：       ListHepler
* 命名空间：       MIS.Utility.ListHelper
* 文 件 名：       ListHepler
* 创建时间：       2019/11/26 11:28:40
* 作    者：       zhangyang
* 说   明：
* 修改时间：
* 修 改 人：
*************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Utility.ListHelper
{
   public  class ListHepler
    {
       /// <summary>
       /// 将list集合变为字符串
       /// </summary>
       /// <param name="List"></param>
       /// <param name="Separator"></param>
       /// <returns></returns>
       public static string ListToString(List<String> List, string Separator = ",")
       {
           string result = string.Join(Separator, List.ToArray());
           return result;
       }
    }
}
