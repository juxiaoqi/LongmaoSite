using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Fund.Core;
using System.Text.RegularExpressions;

namespace Longmao.Web.Sites.ajax
{
    public partial class title : System.Web.UI.Page
    {
        #region 网站地址
        /// <summary>
        /// 网站地址
        /// </summary>
        public string SiteURL
        {
            get
            {
                try
                {
                    return Request["url"];
                }
                catch
                {
                    return "";
                }
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            string str = Httper.GetHTTPInfo(SiteURL, "utf-8");

            Response.Write(GetTitleContent(str, "title"));
        }

        #region 获取网页源码里的标题Title
        /// <summary>
        /// 获取网页源码里的标题Title
        /// </summary>
        /// <param name="str"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public static string GetTitleContent(string str, string title)
        {
            string tmpStr = string.Format("<{0}[^>]*?>(?<Text>[^<]*)</{1}>", title, title); //获取<title>之间内容  

            Match TitleMatch = Regex.Match(str, tmpStr, RegexOptions.IgnoreCase);

            string result = TitleMatch.Groups["Text"].Value;

            return result;
        }  
        #endregion
    }
}