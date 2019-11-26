/*************************************************************************************
* CLR版本：        4.0.30319.42000
* 类 名 称：       ZipFileHelper
* 命名空间：       MIS.Utility.Zip
* 文 件 名：       ZipFileHelper
* 创建时间：       2019/11/26 11:47:39
* 作    者：       zhangyang
* 说   明：
* 修改时间：
* 修 改 人：
*************************************************************************************/

using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Utility.Zip
{
    /// <summary>
    /// using System.IO.Compression;
    /// using System.IO.Compression.FileSystem
    /// </summary>
   public class ZipFileHelper
    {
        public static bool ZipFiles(string SourceDirectory, string DestionFile)
        {
            bool result = false;
            try
            {
                ZipFile.CreateFromDirectory(SourceDirectory, DestionFile);
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }


        public static bool ZipFiles(string SourceDirectory, string DestionFile, CompressionLevel Level, bool IncludeBaseDirectory)
        {
            bool result = false;
            try
            {
                ZipFile.CreateFromDirectory(SourceDirectory, DestionFile, Level, IncludeBaseDirectory);
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }




        public static bool UnZipFiles(string SourceZipFile, string DestionDirectory)
        {
            bool result = false;

            try
            {
                ZipFile.ExtractToDirectory(SourceZipFile, DestionDirectory);
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }
    }
}
