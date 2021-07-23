using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SmartSoft.common.Utils.solution
{
    public class SolutionUtil
    {
        #region initialize
        public string _solutionName { get; set; }
        public SolutionUtil(string solutionName)
        {
            _solutionName = solutionName;
        }
        #endregion

        #region parse
        /// <summary>
        /// SlnParse
        /// </summary>
        /// <returns></returns>
        public List<SolutionInfo> SlnParse(){
            List<SolutionInfo> list = new List<SolutionInfo>();
            using FileStream fileStream = new FileStream(_solutionName, FileMode.Open, FileAccess.Read);
            using StreamReader streamReader = new StreamReader(fileStream, Encoding.UTF8);
            string linedata = null;
            while ((linedata = streamReader.ReadLine()) != null)
            {
                if (linedata.Contains("Project(\""))
                {
                    string temp = linedata.Split(",")[1].Replace("\"", "").Replace("\\", "/").Trim();
                    list.Add(new SolutionInfo {
                        projName=temp.Substring(temp.LastIndexOf("/")).Substring(1),
                        projFullName=temp
                    });
                }
                else if (linedata.Contains("Global"))
                {
                    break;
                }
            }
            return list;
        }
        #endregion

    }
}
