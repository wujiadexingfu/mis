/*************************************************************************************
* CLR版本：        4.0.30319.42000
* 类 名 称：       SHA1Helper
* 命名空间：       MIS.Utility.Encrypt
* 文 件 名：       SHA1Helper
* 创建时间：       2019/11/26 14:41:25
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
  public  class SHA1Helper
    {
        public static string SHA1Encrypt(string Value)
        {
            string result = string.Empty;
            try
            {
                var bytes = Encoding.Default.GetBytes(Value);
                var SHA = new SHA1CryptoServiceProvider();
                var encryptbytes = SHA.ComputeHash(bytes);
                result = Convert.ToBase64String(encryptbytes);
            }
            catch
            {
                result = string.Empty;
            }
            return result;
        }

        public static string SHA256Encrypt(string Value)
        {
            string result = string.Empty;
            try
            {
                var bytes = Encoding.Default.GetBytes(Value);
                var SHA256 = new SHA256CryptoServiceProvider();
                var encryptbytes = SHA256.ComputeHash(bytes);
                result = Convert.ToBase64String(encryptbytes);
            }
            catch
            {
                result = string.Empty;
            }
            return result;

        }
        public static string SHA384Encrypt(string Value)
        {
            string result = string.Empty;
            try
            {
                var bytes = Encoding.Default.GetBytes(Value);
                var SHA384 = new SHA384CryptoServiceProvider();
                var encryptbytes = SHA384.ComputeHash(bytes);
                result = Convert.ToBase64String(encryptbytes);
            }
            catch
            {
                result = string.Empty;
            }
            return result;
        }
        public static string SHA512Encrypt(string Value)
        {
            string result = string.Empty;
            try
            {
                var bytes = Encoding.Default.GetBytes(Value);
                var SHA512 = new SHA512CryptoServiceProvider();
                var encryptbytes = SHA512.ComputeHash(bytes);
                result = Convert.ToBase64String(encryptbytes);
            }
            catch
            {
                result = string.Empty;
            }
            return result;
        }  
    }
}
