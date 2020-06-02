using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace xfLab.Helpers.Storages
{
    /// <summary>
    /// Storage 相關的 API
    /// http://www.nudoq.org/#!/Packages/PCLStorage/PCLStorage/FileSystem
    /// </summary>
    public class StorageUtility
    {
        /// <summary>
        /// 存取 Resource URI
        /// </summary>
        public static readonly string BaseUri = "ms-appx:///";
        /// <summary>
        /// 存取 Local Data URI
        /// </summary>
        public static readonly string LocalUri = "ms-appdata:///local/";

        /// <summary>
        /// 將所指定的字串寫入到指定目錄的檔案內
        /// </summary>
        /// <param name="folderName">目錄名稱</param>
        /// <param name="filename">檔案名稱</param>
        /// <param name="content">所要寫入的文字內容</param> 
        /// <returns></returns>
        public static async Task WriteToDataFileAsync(string folderPath, string folderName, string filename, string content, bool 需要加解密 = true)
        {
            string rootFolder = FileSystem.AppDataDirectory;

            if (string.IsNullOrEmpty(folderName))
            {
                throw new ArgumentNullException(nameof(folderName));
            }

            if (string.IsNullOrEmpty(filename))
            {
                throw new ArgumentNullException(nameof(filename));
            }

            if (string.IsNullOrEmpty(content))
            {
                throw new ArgumentNullException(nameof(content));
            }

            #region 建立與取得指定路徑內的資料夾
            try
            {
                string[] fooPaths = folderName.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
                string tempRootFolder = rootFolder;
                foreach (var item in fooPaths)
                {
                    tempRootFolder = Path.Combine(tempRootFolder, item);
                    var info = Directory.CreateDirectory(tempRootFolder);
                }

                tempRootFolder = Path.Combine(tempRootFolder, filename);
                await Task.Run(() =>
                {
                    File.WriteAllText(tempRootFolder, content);
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            #endregion
        }

        /// <summary>
        /// 從指定目錄的檔案內將文字內容讀出
        /// </summary>
        /// <param name="folderName">目錄名稱</param>
        /// <param name="filename">檔案名稱</param>
        /// <returns>文字內容</returns>
        public static async Task<string> ReadFromDataFileAsync(string folderPath, string folderName, string filename, bool 需要加解密 = true)
        {
            string content = "";

            string rootFolder = FileSystem.AppDataDirectory;

            if (string.IsNullOrEmpty(folderName))
            {
                throw new ArgumentNullException(nameof(folderName));
            }

            if (string.IsNullOrEmpty(filename))
            {
                throw new ArgumentNullException(nameof(filename));
            }

            #region 建立與取得指定路徑內的資料夾
            try
            {
                string[] fooPaths = folderName.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
                string tempRootFolder = rootFolder;
                foreach (var item in fooPaths)
                {
                    tempRootFolder = Path.Combine(tempRootFolder, item);
                    var info = Directory.CreateDirectory(tempRootFolder);
                }

                tempRootFolder = Path.Combine(tempRootFolder, filename);
                if(File.Exists(tempRootFolder))
                {
                    await Task.Run(() =>
                    {
                        content = File.ReadAllText(tempRootFolder);
                    });
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            #endregion

            return content.Trim();
        }
    }
}
