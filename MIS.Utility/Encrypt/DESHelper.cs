/*************************************************************************************
* CLR版本：        4.0.30319.42000
* 类 名 称：       DESHelper
* 命名空间：       MIS.Utility.Encrypt
* 文 件 名：       DESHelper
* 创建时间：       2019/11/26 11:24:27
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
   public class DESHelper
    {
        private static byte[] Keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF, 0xEF };


        /// DES加密字符串  

        /// </summary>  

        /// <param name="Value">待加密的字符串</param>  

        /// <param name="Key">加密密钥,要求为8位</param>  

        /// <returns>加密成功返回加密后的字符串，失败返回空</returns>  

        public static string EncryptString(string Value, string Key)
        {

            try
            {
                byte[] byteKey = GetKeyByte(Key);

                byte[] rgbIV = Keys;

                byte[] inputByteArray = Encoding.UTF8.GetBytes(Value);

                DESCryptoServiceProvider DESProvider = new DESCryptoServiceProvider();

                using (MemoryStream mStream = new MemoryStream())
                {
                    using (CryptoStream cStream = new CryptoStream(mStream, DESProvider.CreateEncryptor(byteKey, rgbIV), CryptoStreamMode.Write))
                    {
                        cStream.Write(inputByteArray, 0, inputByteArray.Length);

                        cStream.FlushFinalBlock();

                        return Convert.ToBase64String(mStream.ToArray());
                    }
                }
            }
            catch
            {
                return null;
            }

        }


        /// DES解密字符串  

        /// </summary>  

        /// <param name="EncryptValue">待解密的字符串</param>  

        /// <param name="Key">解密密钥,要求为8位,和加密密钥相同</param>  

        /// <returns>解密成功返回解密后的字符串,失败返回空</returns>  

        public static string DecryptString(string EncryptValue, string Key)
        {

            try
            {

                byte[] byteKey = GetKeyByte(Key);

                byte[] rgbIV = Keys;

                byte[] inputByteArray = Convert.FromBase64String(EncryptValue);

                DESCryptoServiceProvider DCSP = new DESCryptoServiceProvider();

                using (MemoryStream mStream = new MemoryStream())
                {
                    using (CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(byteKey, rgbIV), CryptoStreamMode.Write))
                    {
                        cStream.Write(inputByteArray, 0, inputByteArray.Length);

                        cStream.FlushFinalBlock();

                        return Encoding.UTF8.GetString(mStream.ToArray());
                    }
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary> 
        /// 加密文件
        /// 注意：密钥必须是8位
        /// </summary> 
        /// <param name="SourceFile">加密文件的路径</param> 
        /// <param name="EncryptFile">输出文件,加密后的文件</param> 
        /// <param name="Key">加密秘钥</param> 
        public static void EncryptFile(string SourceFile, string EncryptFile, string Key)
        {
            byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
            byte[] byteKey = GetKeyByte(Key);
            using (FileStream inputFileStream = new FileStream(SourceFile, FileMode.Open, FileAccess.Read))
            {
                using (FileStream outPutFileStream = new FileStream(EncryptFile, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    DES des = new DESCryptoServiceProvider();
                    using (CryptoStream crpyStream = new CryptoStream(outPutFileStream, des.CreateEncryptor(byteKey, IV), CryptoStreamMode.Write))
                    {
                        var buffer = new byte[4 * 1024];//缓存
                        int bytesRead = 0;

                        while ((bytesRead = inputFileStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            crpyStream.Write(buffer, 0, bytesRead);
                        }
                        crpyStream.Close();
                        inputFileStream.Close();
                        outPutFileStream.Close();
                    }
                }
            }

        }



        /// <summary> 
        /// 解密文件
        /// 注意：密钥必须是8位
        /// </summary> 
        /// <param name="EncryptFile">解密文件路径</param> 
        /// <param name="DecryptFile">输出文件路径</param> 
        /// <param name="Key">key</param> 
        public static void DecryptFile(string EncryptFile, string DecryptFile, string Key)
        {
            byte[] byKey = null;
            byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };

            byKey = GetKeyByte(Key);
            using (FileStream inputFileStream = new FileStream(EncryptFile, FileMode.Open, FileAccess.Read))
            {
                using (FileStream outputFileStream = new FileStream(DecryptFile, FileMode.OpenOrCreate, FileAccess.Write))
                {
                    DES des = new DESCryptoServiceProvider();
                    using (CryptoStream encStream = new CryptoStream(outputFileStream, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write))
                    {
                        var buffer = new byte[4 * 1024];//缓存
                        int bytesRead = 0;

                        while ((bytesRead = inputFileStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            encStream.Write(buffer, 0, bytesRead);
                        }
                        encStream.Close();
                        outputFileStream.Close();
                        inputFileStream.Close();
                    }
                }
            }
        }
        /// <summary>
        /// 获取8位加密密匙，不够的话自动补全
        /// </summary>
        /// <param name="Key">加密字符串</param>
        /// <returns></returns>
        public static byte[] GetKeyByte(string Key)
        {
            if (Key.Length < 8)
            {
                // 不足8补全
                Key = Key.PadRight(8, '0');
            }
            if (Key.Length > 8)
            {
                Key = Key.Substring(0, 8);
            }
            return Encoding.UTF8.GetBytes(Key);
        }
    }
}
