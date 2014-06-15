using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace Longmao.Web.Sites.lib
{
    public class config
    {
        /// <summary>
        /// 数据库链接
        /// </summary>
        public static string DBConn;

        static config()
        {
            DBConn = ConfigurationManager.ConnectionStrings["LongmaoDB"].ConnectionString;
        }
    }
}