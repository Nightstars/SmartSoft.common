using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartSoft.common.Entities
{
    //
    // Summary:
    //     请求响应实体
    //
    // Type parameters:
    //   T:
    public class CoreVO<T> where T : class
    {
        public CoreVO()
        {

        }
        public CoreVO(string code, string message, T data)
        {

        }

        //
        // Summary:
        //     请求处理结果
        public string Code { get; set; }
        //
        // Summary:
        //     业务处理结果
        public bool Success { get; set; }
        //
        // Summary:
        //     处理信息
        public string Msg { get; set; }
        //
        // Summary:
        //     返回数据
        public T Data { get; set; }
        //
        // Summary:
        //     复制对象值
        //
        // Parameters:
        //   result:
        //     被复制的对象
        public void GetPointer(CoreVO<T> result)
        {

        }

    }
}
