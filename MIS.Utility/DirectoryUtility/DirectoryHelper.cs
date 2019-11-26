/*************************************************************************************
* CLR版本：        4.0.30319.42000
* 类 名 称：       DirectoryHelper
* 命名空间：       MIS.Utility.DirectoryUtility
* 文 件 名：       DirectoryHelper
* 创建时间：       2019/11/26 13:37:45
* 作    者：       zhangyang
* 说   明：
* 修改时间：
* 修 改 人：
*************************************************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Utility.DirectoryUtility
{
   public class DirectoryHelper
    {
        /// <summary>
        /// 递归拷贝文件夹
        /// </summary>
        /// <param name="sourcePath"></param>
        /// <param name="destinationPath"></param>
        public static void CopyDirectory(string sourcePath, string destinationPath)
        {
            try
            {
                if (!Directory.Exists(destinationPath))
                {
                    Directory.CreateDirectory(destinationPath);
                }
                string[] files = Directory.GetFiles(sourcePath);
                foreach (string file in files)
                {
                    string pFilePath = destinationPath + "\\" + Path.GetFileName(file);
                    if (File.Exists(pFilePath))
                        continue;
                    File.Copy(file, pFilePath, true);
                }

                string[] dirs = Directory.GetDirectories(sourcePath);
                foreach (string dir in dirs)
                {
                    CopyDirectory(dir, destinationPath + "\\" + Path.GetFileName(dir));
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 递归删除文件夹
        /// </summary>
        /// <param name="dirPath"></param>
        public static void DeleteDirectory(string sourcePath)
        {
            if (Directory.Exists(sourcePath)) //如果存在这个文件夹删除之 
            {
                foreach (string d in Directory.GetFileSystemEntries(sourcePath))
                {
                    if (File.Exists(d))
                        File.Delete(d); //直接删除其中的文件                        
                    else
                        DeleteDirectory(d); //递归删除子文件夹 
                }
                Directory.Delete(sourcePath, true); //删除已空文件夹                 
            }
        }
    }
}
