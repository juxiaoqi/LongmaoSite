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
    public partial class myfav : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region 判断用户是否登录
            if (!Class_UserLogin.IsLogin())
            {
                Response.Redirect("login.aspx?url=myfav.aspx");
            } 
            #endregion

            #region 站点信息

            string strSiteInfo = "";
            try
            {
                string sql = "select a.* from [tb_site] a,[tb_site_user] b where a.site_id=b.su_siteid and b.su_userid='" + Class_UserLogin.UserID().ToString() + "'";

                DataTable dt = new DataTable();
                DBHelper dbh = new DBHelper(config.DBConn);
                dt = dbh.ExecuteDataTable("", sql);

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        strSiteInfo += "<div class=\"topic_hot_list span5\"><a target=\"_blank\" href=\"" + dt.Rows[i]["site_url"].ToString() + "\" class=\"icon pull-left\"><img src=\"" + dt.Rows[i]["site_img"].ToString() + "\"></a><a target=\"_blank\" class=\"title\" href=\"" + dt.Rows[i]["site_url"].ToString() + "\">" + dt.Rows[i]["site_name"].ToString() + "</a>";

                        if (dt.Rows[i]["site_ispublic"].ToString() == "0")
                        {
                            strSiteInfo += "<a href=\"javascript:config_control('" + dt.Rows[i]["site_id"].ToString() + "');\" data-id=\"" + dt.Rows[i]["site_id"].ToString() + "\" class=\"config\"></a>";
                        }

                        strSiteInfo += "<a href=\"javascript:fav_control('" + dt.Rows[i]["site_id"].ToString() + "');\" data-id=\"" + dt.Rows[i]["site_id"].ToString() + "\" class=\"followed follow\"></a>";

                        strSiteInfo += "</div>";
                    }
                }
                else
                {
                }

                dbh.Dispose();
                dt.Dispose();
            }
            catch (Exception ex)
            {
                strSiteInfo = ex.ToString();
            }

            this.myfavsite.InnerHtml = strSiteInfo;
            #endregion

            #region 标签信息
            string strTagInfo = "";

            try
            {
                string sql = "select * from [tb_tag] where tag_ispublic=1";
                DataTable dt = new DataTable();
                DBHelper dbh = new DBHelper(config.DBConn);
                dt = dbh.ExecuteDataTable("", sql);

                if (dt.Rows.Count > 0)
                {
                    strTagInfo += "<ul>";
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        strTagInfo += "<li style=\"float:left;margin-right:15px;\"><input id=\"tag" + dt.Rows[i]["tag_id"].ToString() + "\" name=\"tagcheck\" value=\"" + dt.Rows[i]["tag_id"].ToString() + "\" class=\"input-medium\" type=\"checkbox\"> <label for=\"tag" + dt.Rows[i]["tag_id"].ToString() + "\">" + dt.Rows[i]["tag_name"].ToString() + "</label><li>";
                    }
                    strTagInfo += "</ul>";
                }

                dbh.Dispose();
                dt.Dispose();
            }
            catch (Exception ex)
            {
                strTagInfo = ex.ToString();
            }

            this.sitetags.InnerHtml = strTagInfo;

            #endregion
        }
    }
}