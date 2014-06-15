using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

using Fund.Core;
using System.Data;

namespace Longmao.Web.Sites.lib
{
    public class Class_UserLogin
    {
        #region 检查是否是管理员
        /// <summary>
        /// 检查是否是管理员
        /// </summary>
        /// <returns></returns>
        public static bool IsManageUser()
        {
            bool boolIsManageUser = false;

            if (UserID() == 1 || UserID() == 2)
            {
                boolIsManageUser = true;
            }

            return boolIsManageUser;
        } 
        #endregion

        #region 创建登录MD5信息
        /// <summary>
        /// 创建登录MD5信息
        /// </summary>
        /// <param name="strUserID">用户编号</param>
        /// <param name="strUserName">用户账号</param>
        public static string CreatLoginMD5Info(string strUserID, string strUserName)
        {
            string strInfo = "";
            strInfo = "userinfo|" + strUserID + "|" + strUserName + "|" + Class_MD5.GetStrMd5("longmao" + strUserName + "|" + strUserID);
            return strInfo;
        }
        #endregion

        #region 验证用户是否登录
        /// <summary>
        /// 验证用户是否登录
        /// </summary>
        /// <returns></returns>
        public static bool IsLogin()
        {
            bool boolIsLogin = false;
            string strCookies = "";
            try
            {
                strCookies = HttpContext.Current.Request.Cookies["longmao_userinfo"].Value;
                string strUserID = strCookies.Split('|')[1].ToString();
                string strUserName = strCookies.Split('|')[2].ToString();
                if (strCookies == CreatLoginMD5Info(strUserID, strUserName))
                {
                    boolIsLogin = true;
                }

                //写日志
                //StreamWriter f = new StreamWriter("E:/Develop/Log/" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".log", true);
                //f.WriteLine("strUserID：" + strUserID + "|strUserName：" + strUserName + "|strCookies：" + strCookies);
                //f.Close();

            }
            catch (Exception ex)
            {
                //写日志
                //StreamWriter f = new StreamWriter("E:/Develop/Log/" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + ".log", true);
                //f.WriteLine(strCookies);
                //f.WriteLine(ex.ToString());
                //f.Close();
            }
            return boolIsLogin;
        }
        #endregion

        #region 当前登录用户编号
        /// <summary>
        /// 当前登录用户编号
        /// </summary>
        /// <returns></returns>
        public static int UserID()
        {
            int intUserID = 0;
            string strCookies = "";
            try
            {
                strCookies = HttpContext.Current.Request.Cookies["longmao_userinfo"].Value;
                string strUserID = strCookies.Split('|')[1].ToString();
                intUserID = Convert.ToInt16(strUserID);
            }
            catch
            {
            }
            return intUserID;
        }  
        #endregion

        #region 当前登录用户账号
        /// <summary>
        /// 当前登录用户账号
        /// </summary>
        /// <returns></returns>
        public static string UserName()
        {
            string strUserName = "";
            string strCookies = "";
            try
            {
                strCookies = HttpContext.Current.Request.Cookies["longmao_userinfo"].Value;
                strUserName = strCookies.Split('|')[2].ToString();
            }
            catch
            {
            }
            return strUserName;
        }
        #endregion
    }
}