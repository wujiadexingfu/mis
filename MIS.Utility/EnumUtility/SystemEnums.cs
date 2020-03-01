using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/********************************************************************************

** 类名称：  SystemEnums

** 描述：********

** 作者： zhangyang

** Version: 1.0

** 创建时间：2019-11-24 19:40:51

** 最后修改人：（无）

** 最后修改时间：（无）

** CLR版本：4.0.30319.42000      

** 版权所有 (C) :zhangyang

*********************************************************************************/

namespace MIS.Utility.EnumUtility
{
 public   class SystemEnums
    {
        public enum LoginStatus
        {
            /// <summary>
            /// 正常
            /// </summary>
            Normal,

            /// <summary>
            /// 不存在
            /// </summary>
            NotExists,

            /// <summary>
            /// 不允许登录
            /// </summary>
            NotLogin,

            /// <summary>
            ///密码错误
            /// </summary>
            PasswordWrong,
            /// <summary>
            /// 有效期超期
            /// </summary>
            ExpiryDateWrong

        }
        /// <summary>
        /// 用户状态
        /// </summary>

        public enum UserStatus
        {
            /// <summary>
            /// 新建
            /// </summary>
            New,

            /// <summary>
            /// 删除
            /// </summary>
            Delete

        }

        public enum Status
        {
            /// <summary>
            /// 新建
            /// </summary>
            New,

            /// <summary>
            /// 删除
            /// </summary>
            Delete

        }


        public enum TreeNodeType
        {
            /// <summary>
            /// 操作
            /// </summary>
            Operation

        }

    }
}
