/*************************************************************************************
* CLR版本：        4.0.30319.42000
* 类 名 称：       SystemEnums
* 命名空间：       MIS.Utility
* 文 件 名：       SystemEnums
* 创建时间：       2019/10/26 21:09:41
* 作    者：       zhangyang
* 说   明：
* 修改时间：
* 修 改 人：
*************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MIS.Utility
{
   public  class SystemEnums
    {
       public enum LoginStatus
       {
          
           Correct,

        
           AccountNoExist,

        
           PasswordError,


           /// <summary>
           /// 不允许登录
           /// </summary>
           CanNotLogin,

       }
    }
}
