using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Security.Cryptography;
using System.Xml.Linq;
using System.Text;

namespace Longmao.Web.Sites.lib
{
    public class Class_MD5
    {        
        #region MD5加密

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="ConvertString">原始字符串</param>
        /// <param name="intLength">加密长度</param>
        /// <returns></returns>
        public static string GetStrMd5(string ConvertString, int intLength)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            string strMD5 = "";
            if (intLength == 16)
            {
                strMD5 = BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(ConvertString)), 4, 8);
                strMD5 = strMD5.Replace("-", "");
                strMD5 = strMD5.ToLower();
            }
            else
            {
                strMD5 = BitConverter.ToString(md5.ComputeHash(UTF8Encoding.Default.GetBytes(ConvertString)));
                strMD5 = strMD5.Replace("-", "");
            }
            return strMD5;
        }


        /// <summary>
        /// 32位MD5加密
        /// </summary>
        /// <param name="ConvertString">原始字符串</param>
        /// <returns></returns>
        public static string GetStrMd5(string ConvertString)
        {
            return GetStrMd5(ConvertString, 32);
        }

        #endregion
    }
}