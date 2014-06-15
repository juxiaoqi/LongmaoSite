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
    public partial class myadd : System.Web.UI.Page
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

        #region 站点链接
        /// <summary>
        /// 站点链接
        /// </summary>
        public string SiteURL
        {
            get
            {
                try
                {
                    return Request["siteurl"];
                }
                catch
                {
                    return "";
                }
            }
        }
        #endregion

        #region 站点名称
        /// <summary>
        /// 站点名称
        /// </summary>
        public string SiteName
        {
            get
            {
                try
                {
                    return Request["sitename"];
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
            if (!Class_UserLogin.IsLogin())
            {
                Response.Redirect("login.aspx?url=myadd.aspx");
            }

            if (strPost == "yes")
            {
                try
                {
                    string sql = "declare @newid as int;insert into tb_site(site_name,site_url,site_img,site_isopen,site_ispublic,site_createtime)values('" + SiteName + "','" + SiteURL + "','',1,0,'" + DateTime.Now.ToString() + "');set @newid=@@IDENTITY;insert into tb_site_user(su_siteid,su_userid,su_createtime)values(@newid," + Class_UserLogin.UserID() + ",'" + DateTime.Now.ToString() + "');SELECT @@IDENTITY;";
                    DataTable dt = new DataTable();
                    DBHelper dbh = new DBHelper(config.DBConn);
                    dt = dbh.ExecuteDataTable("", sql);
                    dbh.Dispose();
                    dt.Dispose();
                    this.addinfo.InnerHtml = "提交成功！";
                    this.addinfo.Style.Remove("display");
                }
                catch { }
            }
        }
    }
}