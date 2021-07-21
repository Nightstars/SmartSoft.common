using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSoft.common.Entities
{
    public class AppInfo : CoreBaseEntity
    {

        /// <summary>
        /// 应用名称
        /// </summary>
        public string AppName { get; set; }

        /// <summary>
        /// 应用版本
        /// </summary>
        public string AppVersion { get; set; }

        /// <summary>
        /// 应用MD5
        /// </summary>
        public string AppMD5 { get; set; }

        /// <summary>
        /// 应用大小
        /// </summary>
        public long AppSize { get; set; }

        /// <summary>
        /// 应用类型
        /// </summary>
        public string AppType { get; set; }

        /// <summary>
        /// 应用完整路径
        /// </summary>
        public string AppFullName { get; set; }

        /// <summary>
        /// 应用业务类型
        /// </summary>
        public string AppBusinessType { get; set; }

        /// <summary>
        /// 应用业务编号
        /// </summary>
        public string AppBusinessNo { get; set; }

    }
}
