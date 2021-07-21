using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSoft.common.Entities
{
    public class CoreBaseEntity
    {
        /// <summary>
        /// 业务主键
        /// </summary>
        public string SeqNo { get; set; }

        /// <summary>
        /// 关联键
        /// </summary>
        public string RefSeqNo { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public string CreateUser { get; set; }

        /// <summary>
        /// 创建人名称
        /// </summary>
        public string CreateUserName { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 更新人
        /// </summary>
        public string UpdateUser { get; set; }

        /// <summary>
        /// 更新人名称
        /// </summary>
        public string UpdateUserName { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime? UpdateTime { get; set; }
    }
}
