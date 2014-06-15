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
    public partial class _default : System.Web.UI.Page
    {

        #region 标签编号
        /// <summary>
        /// 标签编号
        /// </summary>
        public string TagID
        {
            get
            {
                try
                {
                    if (Request["id"] != null && Request["id"] != "")
                    {
                        return Request["id"];
                    }
                    else
                    {
                        return "0";
                    }
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

            #region 标签信息
            string strTagInfo = "";
            string strTagID = "0";
            strTagID = TagID;

            strTagInfo += "<ul class=\"nav nav-tabs nav-stacked\">";

            if (Class_UserLogin.IsLogin())
            {
                if (strTagID == "0" || strTagID == null)
                {
                    strTagInfo += "<li class=\"active\"><a href=\"myfav.aspx\">我的收藏</a></li>";
                }
                else
                {
                    strTagInfo += "<li><a href=\"myfav.aspx\">我的收藏</a></li>";
                }
            }
            else
            {
                if (strTagID == "0" || strTagID == null)
                {
                    strTagID = "8";
                }
            }

            try
            {
                string sql = "select top 10 * from [tb_tag] where tag_ispublic=1 order by tag_order desc";
                DataTable dt = new DataTable();
                DBHelper dbh = new DBHelper(config.DBConn);
                dt = dbh.ExecuteDataTable("", sql);

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["tag_id"].ToString() == strTagID)
                        {
                            strTagInfo += "<li class=\"active\"><a href=\"default.aspx?id=" + dt.Rows[i]["tag_id"].ToString() + "\">" + dt.Rows[i]["tag_name"].ToString() + "</a></li>";
                        }
                        else
                        {
                            strTagInfo += "<li><a href=\"default.aspx?id=" + dt.Rows[i]["tag_id"].ToString() + "\">" + dt.Rows[i]["tag_name"].ToString() + "</a></li>";
                        }

                    }
                }

                dbh.Dispose();
                dt.Dispose();
            }
            catch (Exception ex)
            {
                strTagInfo = ex.ToString();
            }

            strTagInfo += "<li><a href=\"tags.aspx\">全部标签</a></li>";

            strTagInfo += "</ul>";
            #endregion

            #region 站点信息

            string strSiteInfo = "";
            try
            {
                string sql = "select * from [tb_site]";

                if (Class_UserLogin.IsLogin())
                {
                    if (strTagID == "0" || strTagID == null)
                    {
                        sql = "select a.*,b.* from [tb_site] a,[tb_site_user] b where a.site_id=b.su_siteid and b.su_userid='" + Class_UserLogin.UserID().ToString() + "'";
                    }
                    else
                    {
                        sql = "select e.* from (select a.*,d.su_id  from [tb_site] a left join  [tb_site_user] d on d.su_userid='" + Class_UserLogin.UserID().ToString() + "' and a.site_id=d.su_siteid) as e,[tb_site_tag] b,[tb_tag] c where e.site_id=b.st_siteid and c.tag_id=b.st_tagid and e.site_ispublic=1 and c.tag_ispublic=1 and c.tag_id='" + strTagID + "' order by e.su_id desc,e.site_id asc";
                    }
                }
                else
                {
                    sql = "select a.* from [tb_site] a,[tb_site_tag] b,[tb_tag] c where a.site_id=b.st_siteid and c.tag_id=b.st_tagid and a.site_ispublic=1 and c.tag_ispublic=1 and c.tag_id='" + strTagID + "' order by a.site_id asc";
                }


                DataTable dt = new DataTable();
                DBHelper dbh = new DBHelper(config.DBConn);
                dt = dbh.ExecuteDataTable("", sql);

                if (dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        strSiteInfo += "<div class=\"topic_hot_list span5\"><a target=\"_blank\" href=\"" + dt.Rows[i]["site_url"].ToString() + "\" class=\"icon pull-left\"><img src=\"" + dt.Rows[i]["site_img"].ToString() + "\"></a><a target=\"_blank\" class=\"title\" href=\"" + dt.Rows[i]["site_url"].ToString() + "\">" + dt.Rows[i]["site_name"].ToString() + "</a>";
                        if (Class_UserLogin.IsLogin())
                        {
                            if (dt.Rows[i]["su_id"].ToString() == null || dt.Rows[i]["su_id"].ToString() == "")
                            {
                                strSiteInfo += "<a href=\"javascript:fav_control('" + dt.Rows[i]["site_id"].ToString() + "');\" data-id=\"" + dt.Rows[i]["site_id"].ToString() + "\" class=\"unfollowed follow\"><i></i></a>";
                            }
                            else
                            {
                                strSiteInfo += "<a href=\"javascript:fav_control('" + dt.Rows[i]["site_id"].ToString() + "');\" data-id=\"" + dt.Rows[i]["site_id"].ToString() + "\" class=\"followed follow\"><i></i></a>";
                            }
                        }
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
            #endregion


            this.hottags.InnerHtml = strTagInfo;
            this.chfeeds.InnerHtml = strSiteInfo;

        }
    }
}