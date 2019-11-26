/*************************************************************************************
* CLR版本：        4.0.30319.42000
* 类 名 称：       SharpZipHelper
* 命名空间：       MIS.Utility.Zip
* 文 件 名：       SharpZipHelper
* 创建时间：       2019/11/26 11:47:22
* 作    者：       zhangyang
* 说   明：
* 修改时间：
* 修 改 人：
*************************************************************************************/

using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Utility.Zip
{
  public  class SharpZipHelper
    {
        /// <summary>
        /// 压缩单个文件
        /// </summary>
        /// <param name="SourceFile">源文件</param>
        /// <param name="DestionFile">目的文件</param>
        /// <param name="Password">密码</param>
        /// <param name="Comment">备注</param>
        /// <param name="Level">压缩等级 0-9 0不压缩，9压缩比最高</param>
        /// <returns></returns>
        public static bool ZipSimpleFile(string SourceFile, string DestionFile, string Password, String Comment, int Level = 5)
        {
            bool result = false;
            try
            {
                string fileName = Path.GetFileName(SourceFile);//文件名
                using (var inputFileStream = new FileStream(SourceFile, FileMode.Open, FileAccess.Read))//源文件输入流
                {
                    using (var zipOuputStream = new ZipOutputStream(File.Create(DestionFile)))//目的文件输出流
                    {
                        if (!string.IsNullOrEmpty(Password)) //设置密码
                        {
                            zipOuputStream.Password = Password;
                        }

                        if (!string.IsNullOrEmpty(Comment))//设置备注
                        {
                            zipOuputStream.SetComment(Comment);
                        }

                        var zipEntry = new ZipEntry(fileName); //每一个文件代表了ZipEntry
                        zipOuputStream.PutNextEntry(zipEntry);
                        zipOuputStream.SetLevel(Level); //压缩等级

                        var buffer = new byte[4 * 1024];//缓存
                        int bytesRead = 0;

                        while ((bytesRead = inputFileStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            zipOuputStream.Write(buffer, 0, bytesRead);
                        }
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }

        public bool ZipSimpleFile(string SourceFile, string DestionFile)
        {
            return ZipSimpleFile(SourceFile, DestionFile, null, null);
        }



        /// <summary>
        /// 压缩某一目录下的文件，子文件夹不会被压缩
        /// </summary>
        /// <param name="SourceDirectory"></param>
        /// <param name="DestionFile"></param>
        /// <param name="Level"></param>
        /// <returns></returns>
        public static bool ZipDirectory(string SourceDirectory, string DestionFile, int Level = 5)
        {
            bool result = false;
            try
            {
                using (ZipOutputStream zipOutputStream = new ZipOutputStream(File.Create(DestionFile)))
                {
                    zipOutputStream.SetLevel(6);
                    var fileList = Directory.GetFiles(SourceDirectory);//获取目标目录下的文件

                    foreach (var file in fileList)
                    {
                        using (FileStream fileStream = File.OpenRead(file))
                        {
                            byte[] buffer = new byte[4 * 1024];
                            ZipEntry entry = new ZipEntry(Path.GetFileName(file));
                            entry.DateTime = DateTime.Now;
                            zipOutputStream.PutNextEntry(entry);

                            int bytesRead = 0;
                            while ((bytesRead = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                zipOutputStream.Write(buffer, 0, bytesRead);
                            }
                            fileStream.Close();
                        }
                    }
                    zipOutputStream.Finish();
                    zipOutputStream.Close();
                    result = true;

                }
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;
        }


        /// <summary>
        /// 文件解压
        /// </summary>
        /// <param name="SourceFile">压缩文件</param>
        /// <param name="DestionDirectory">解压文件目录</param>
        /// <returns></returns>
        public static bool UnZipFile(string SourceFile, string DestionDirectory)
        {

            bool result = false;
            try
            {
                using (var zipInputStream = new ZipInputStream(File.OpenRead(SourceFile)))
                {
                    ZipEntry zipEntry;
                    while ((zipEntry = zipInputStream.GetNextEntry()) != null)
                    {
                        string directoryName = Path.GetDirectoryName(zipEntry.Name);//获取需要解压文件的目录
                        string fileName = Path.GetFileName(zipEntry.Name); //文件名
                        if (!string.IsNullOrEmpty(directoryName))    //如果文件目录存在，则创建确保和压缩文件的目录结构一样
                        {
                            Directory.CreateDirectory(Path.Combine(DestionDirectory, directoryName));
                        }

                        if (fileName != String.Empty)
                        {
                            using (FileStream streamWriter = File.Create(DestionDirectory + zipEntry.Name))
                            {
                                byte[] buffer = new byte[4 * 1024];

                                int bytesRead = 0;
                                while ((bytesRead = zipInputStream.Read(buffer, 0, buffer.Length)) > 0)
                                {
                                    streamWriter.Write(buffer, 0, bytesRead);
                                }
                                streamWriter.Close();
                            }
                        }
                    }

                    zipInputStream.Flush();
                    zipInputStream.Close();
                }
                result = false;
            }
            catch (Exception ex)
            {
                result = true;
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SourceDirectory"></param>
        /// <param name="DestionFile"></param>
        /// <param name="Password"></param>
        /// <param name="Comment"></param>
        /// <param name="Level"></param>
        /// <returns></returns>
        public static bool ZipDirectoryWithSon(string SourceDirectory, string DestionFile, string Password, String Comment, int Level = 5)
        {
            bool result = false;

            try
            {
                using (ZipOutputStream zipOutStream = new ZipOutputStream(File.Create(DestionFile)))
                {
                    if (!string.IsNullOrEmpty(Password)) //设置密码
                    {
                        zipOutStream.Password = Password;
                    }

                    if (!string.IsNullOrEmpty(Comment))//设置备注
                    {
                        zipOutStream.SetComment(Comment);
                    }
                    zipOutStream.SetLevel(Level);
                    Compress(SourceDirectory, SourceDirectory, zipOutStream); //递归压缩文件
                    zipOutStream.Finish();
                    zipOutStream.Close();
                    result = true;
                }
            }
            catch (Exception ex)
            {
                result = false;
            }
            return result;

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="OriginalSourceDirectory"></param>
        /// <param name="SourceDirectory"></param>
        /// <param name="ZipOutputFileStream"></param>
        public static void Compress(string OriginalSourceDirectory, string SourceDirectory, ZipOutputStream ZipOutputFileStream)
        {
            string[] fileNames = Directory.GetFileSystemEntries(SourceDirectory); //获取改目录的所有文件和目录
            foreach (string file in fileNames)
            {
                if (Directory.Exists(file))
                {
                    Compress(OriginalSourceDirectory, file, ZipOutputFileStream);  //递归压缩子文件夹
                }
                else
                {
                    using (FileStream zipInputStream = File.OpenRead(file))
                    {
                        byte[] buffer = new byte[4 * 1024];
                        ZipEntry entry = new ZipEntry(file.Replace(OriginalSourceDirectory, ""));      //清除掉最初级的目录，使得压缩的文件和未压缩的文件结构一致
                        entry.DateTime = DateTime.Now;
                        ZipOutputFileStream.PutNextEntry(entry);
                        int bytesRead = 0;
                        while ((bytesRead = zipInputStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            ZipOutputFileStream.Write(buffer, 0, bytesRead);
                        }
                    }
                }
            }
        }
    }
}
