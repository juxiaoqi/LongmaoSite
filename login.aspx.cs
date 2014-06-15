using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Fund.Core;
using System.Data;
using Longmao.Web.Sites.lib;

namespace Longmao.Web.Sites
{
    public partial class login : System.Web.UI.Page
    {
        #region 是否登录
        /// <summary>
        /// 是否登录
        /// </summary>
        public string strPost
        {
            get
            {
                try
                {
                    if (Request["_Post"] != null && Request["_Post"] != "")
                    {
                        return Request["_Post"];
                    }
                    else
                    {
                        return "no";
                    }
                }
                catch
                {
                    return "no";
                }
            }
        }
        #endregion

        #region 用户账号
        /// <summary>
        /// 用户账号
        /// </summary>
        public string UserName
        {
            get
            {
                try
                {
                        return Request["username"];
                }
                catch
                {
                    return "";
                }
            }
        }
        #endregion

        #region 用户密码
        /// <summary>
        /// 用户密码
        /// </summary>
        public string UserPass
        {
            get
            {
                try
                {
                        return Request["userpass"];
                }
                catch
                {
                    return "";
                }
            }
        }
        #endregion

        #region 记住密码
        /// <summary>
        /// 记住密码
        /// </summary>
        public string UserIsRemember
        {
            get
            {
                try
                {
                    return Request["remember"];
                }
                catch
                {
                    return "0";
                }
            }
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            #region 提交登录
            if (strPost == "yes")
            {
                try
                {
                    string sql = "select * from [tb_user] where user_name='" + UserName + "' and user_pass='" + Class_MD5.GetStrMd5(UserPass) + "'";
                    DataTable dt = new DataTable();
                    DBHelper dbh = new DBHelper(config.DBConn);
                    dt = dbh.ExecuteDataTable("", sql);

                    if (dt.Rows.Count > 0)
                    {
                        HttpCookie longmao_userinfo = new HttpCookie("longmao_userinfo");
                        longmao_userinfo.Value = Class_UserLogin.CreatLoginMD5Info(dt.Rows[0]["user_id"].ToString(), dt.Rows[0]["user_name"].ToString());
                        if (UserIsRemember == "1")
                        {
                            longmao_userinfo.Expires = DateTime.Now.AddDays(30);
                        }
                        Response.AppendCookie(longmao_userinfo);

                        Response.Redirect("default.aspx?loginisok");
                    }
                    else
                    {
                        this.loginerror.InnerHtml = "账号或密码错误！";
                        this.loginerror.Style.Remove("display");
                    }

                    dbh.Dispose();
                    dt.Dispose();
                }
                catch (Exception ex)
                {
                    Response.Write(ex.ToString());
                }
            } 
            #endregion
        }
    }
}