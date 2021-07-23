using Newtonsoft.Json;
using SmartSoft.common.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SmartSoft.common.Utils.update
{
    public class UpdateUtil
    {
        #region checckUpdate
        /// <summary>
        /// checckUpdate
        /// </summary>
        /// <param name="fileName"></param>
        public void checckUpdate(string fileName, string url)
        {
            var md5 = GetMD5(fileName);
            using HttpClient httpclient = new HttpClient();
            var param = new
            {
                md5 = md5
            };
            StringContent content = new StringContent(JsonConvert.SerializeObject(param), Encoding.UTF8, "application/json");
            var httpResponse = httpclient.PostAsync($"{url}/api/AppInfo/CheckUpdate", content).Result;
            httpResponse.EnsureSuccessStatusCode();
            if (httpResponse.IsSuccessStatusCode)
            {
                var apiResult = JsonConvert.DeserializeObject<CoreVO<AppInfo>>(httpResponse.Content.ReadAsStringAsync().Result);
                if (apiResult.Msg == "检测到新版本")
                {
                    string currentVersion = GetVersion(fileName);
                    string lastVersion = apiResult?.Data?.AppVersion;
                    string logHtml = "http://cloudapps.life:9003/";
                    string updateUrl = $"{url}{apiResult?.Data?.AppFullName}";
                    string installPath = AppDomain.CurrentDomain.BaseDirectory;
                    string updateZipMD5 = apiResult?.Data.AppMD5;
                    if (File.Exists("Update.exe"))
                    {
                        Process.Start("Update.exe", $"{currentVersion}|{lastVersion}|{logHtml}|{updateUrl}|{installPath}|{updateZipMD5}");
                    }
                    Process.GetCurrentProcess().Kill();
                }

            }
        }
        #endregion

        #region GetMD5
        /// <summary>
        /// GetMD5
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public String GetMD5(string fileName)
        {
            try
            {
                string tempmd5 = null;
                FileStream appmd5filestream = new FileStream($"{fileName}.exe", FileMode.Open, FileAccess.Read, FileShare.Read);
                FileStream dllmd5filestream = new FileStream($"{fileName}.dll", FileMode.Open, FileAccess.Read, FileShare.Read);
                MD5 mD5 = MD5.Create();
                tempmd5 = Convert.ToBase64String(mD5.ComputeHash(appmd5filestream));
                tempmd5 += Convert.ToBase64String(mD5.ComputeHash(dllmd5filestream));
                appmd5filestream.Close();
                dllmd5filestream.Close();
                return Convert.ToBase64String(mD5.ComputeHash(Encoding.UTF8.GetBytes(tempmd5)));
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region GetVersion
        /// <summary>
        /// GetVersion
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public string GetVersion(string filename)
        {
            try
            {
                FileVersionInfo file = System.Diagnostics.FileVersionInfo.GetVersionInfo(filename);
                return file.ProductVersion;
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion
    }
}
