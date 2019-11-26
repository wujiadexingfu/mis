/*************************************************************************************
* CLR版本：        4.0.30319.42000
* 类 名 称：       AESHelper
* 命名空间：       MIS.Utility.Encrypt
* 文 件 名：       AESHelper
* 创建时间：       2019/11/26 11:23:40
* 作    者：       zhangyang
* 说   明：
* 修改时间：
* 修 改 人：
*************************************************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Utility.Encrypt
{
   public class AESHelper
    {
        private static byte[] Keys = {  0x41, 0x72, 0x65, 0x79, 0x6F, 0x75, 0x6D, 0x79,
                                             0x53,0x6E, 0x6F, 0x77, 0x6D, 0x61, 0x6E, 0x3F};

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="Value">需要加密的字符串</param>
        /// <param name="Key">加密密钥</param>
        /// <returns></returns>
        public static string EncryptString(string Value, string Key)
        {
            byte[] byteKey = GetKeyByte(Key);  //获取32位加密字节
            byte[] byteValue = UTF8Encoding.UTF8.GetBytes(Value);

            RijndaelManaged rManager = new RijndaelManaged();
            rManager.Key = byteKey;
            rManager.IV = Keys;
            rManager.Mode = CipherMode.ECB;
            rManager.Padding = PaddingMode.PKCS7;

            using (ICryptoTransform cTransform = rManager.CreateEncryptor())
            {
                byte[] resultArray = cTransform.TransformFinalBlock(byteValue, 0, byteValue.Length);
                return Convert.ToBase64String(resultArray, 0, resultArray.Length);
            }
        }



        /// <summary>
        /// 解密字符串
        /// </summary>
        /// <param name="EncryptValue">加密的数据</param>
        /// <param name="Key">加密密钥</param>
        /// <returns></returns>
        public static string DecryptString(string EncryptValue, string Key)
        {
            try
            {
                byte[] byteKey = GetKeyByte(Key);
                byte[] toEncryptArray = Convert.FromBase64String(EncryptValue);

                RijndaelManaged rManager = new RijndaelManaged();
                rManager.Key = byteKey;
                rManager.Mode = CipherMode.ECB;
                rManager.Padding = PaddingMode.PKCS7;

                using (ICryptoTransform cTransform = rManager.CreateDecryptor())
                {
                    byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

                    return UTF8Encoding.UTF8.GetString(resultArray);
                }
            }
            catch
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// AES加解密钥必须32位
        /// </summary>
        /// <param name="key">密匙字符串</param>
        /// <returns></returns>
        public static byte[] GetKeyByte(string key)
        {
            if (key.Length < 32)
            {
                // 不足32补全
                key = key.PadRight(32, '0');
            }
            if (key.Length > 32)
            {
                key = key.Substring(0, 32);
            }
            return Encoding.UTF8.GetBytes(key);
        }

        /// <summary>
        /// 加密文件
        /// </summary>
        /// <param name="SourceFile">源文件</param>
        /// <param name="EncryptFile">加密后的文件</param>
        /// <param name="Key">加密秘钥</param>
        public static void EncryptFile(string SourceFile, string EncryptFile, string Key)
        {
            using (FileStream inputFileStream = new FileStream(SourceFile, FileMode.Open))
            {
                using (FileStream outputFileStream = new FileStream(EncryptFile, FileMode.Create))
                {
                    RijndaelManaged rManaged = new RijndaelManaged();
                    rManaged.Key = GetKeyByte(Key);
                    rManaged.IV = Keys;

                    ICryptoTransform crypTransForm = rManaged.CreateEncryptor();
                    using (CryptoStream crypStream = new CryptoStream(outputFileStream, crypTransForm, CryptoStreamMode.Write))
                    {
                        var buffer = new byte[4 * 1024];//缓存
                        int bytesRead = 0;

                        while ((bytesRead = inputFileStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            crypStream.Write(buffer, 0, bytesRead);
                        }
                        crypStream.Close();
                    }
                    inputFileStream.Close();
                    outputFileStream.Close();
                }
            }
        }

        /// <summary>
        /// 解密文件
        /// </summary>
        /// <param name="EncryptFile">加密源文件</param>
        /// <param name="DecryptFile">解密文件</param>
        /// <param name="Key">加密秘钥</param>
        public static void DecryptFile(string EncryptFile, string DecryptFile, string Key)
        {
            using (FileStream inputFileStream = new FileStream(EncryptFile, FileMode.Open))
            {
                using (FileStream outputFileStream = new FileStream(DecryptFile, FileMode.Create))
                {
                    RijndaelManaged Rmanaged = new RijndaelManaged();
                    Rmanaged.Key = GetKeyByte(Key);
                    Rmanaged.IV = Keys;
                    ICryptoTransform Decrypto = Rmanaged.CreateDecryptor();
                    using (CryptoStream crypStream = new CryptoStream(inputFileStream, Decrypto, CryptoStreamMode.Read))
                    {
                        var buffer = new byte[4 * 1024];//缓存
                        int bytesRead = 0;

                        while ((bytesRead = crypStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            outputFileStream.Write(buffer, 0, bytesRead);
                        }
                        crypStream.Close();
                        inputFileStream.Close();
                        outputFileStream.Close();
                    }
                }
            }
        }
    }
}
