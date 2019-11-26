/*************************************************************************************
* CLR版本：        4.0.30319.42000
* 类 名 称：       MD5Helper
* 命名空间：       MIS.Utility.Encrypt
* 文 件 名：       MD5Helper
* 创建时间：       2019/11/26 11:25:02
* 作    者：       zhangyang
* 说   明：
* 修改时间：
* 修 改 人：
*************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Utility.Encrypt
{
   public class MD5Helper
    {
       public static string GetMD5(string Value)
       {
           string result = string.Empty;
           try
           {
               var bytes = Encoding.Default.GetBytes(Value);//求Byte[]数组  
               var Md5 = new MD5CryptoServiceProvider().ComputeHash(bytes);//求哈希值  
               result = Convert.ToBase64String(Md5);//将Byte[]数组转为净荷明文(其实就是字符串)  
           }
           catch
           {
               result = string.Empty;
           }
           return result;
       }
    }
}
