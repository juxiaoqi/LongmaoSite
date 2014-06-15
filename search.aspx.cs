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
    public partial class search : System.Web.UI.Page
    {

        #region 关键词
        /// <summary>
        /// 关键词
        /// </summary>
        public string KeyWord
        {
            get
            {
                try
                {
                    if (Request["kw"] != null && Request["kw"] != "")
                    {
                        return Request["kw"];
                    }
                    else
                    {
                        return "";
                    }
                }
                catch
                {
                    return "";
                }
            }
        }
        #endregion

        #region 搜索标签
        /// <summary>
        /// 搜索标签
        /// </summary>
        public string IsTag
        {
            get
            {
                try
                {
                    if (Request["tag"] != null && Request["tag"] != "")
                    {
                        return Request["tag"];
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

        protected void Page_Load(object sender, EventArgs e)
        {
           
                #region 标签信息
                string strTagInfo = "";

                strTagInfo += "<ul class=\"nav nav-tabs nav-stacked\">";

                if (IsTag == "yes")
                {
                    strTagInfo += "<li><a href=\"search.aspx?kw=" + KeyWord + "\">搜索网址</a></li>";
                    strTagInfo += "<li class=\"active\"><a href=\"search.aspx?kw=" + KeyWord + "&tag=yes\">搜索标签</a></li>";
                }
                else
                {
                    strTagInfo += "<li class=\"active\"><a href=\"search.aspx?kw=" + KeyWord + "\">搜索网址</a></li>";
                    strTagInfo += "<li><a href=\"search.aspx?kw=" + KeyWord + "&tag=yes\">搜索标签</a></li>";
                }

                strTagInfo += "</ul>";
                #endregion

                #region 站点信息

                string strSiteInfo = "";
                try
                {
                    if (KeyWord != null || KeyWord != "")
                    {
                        string sql = "";

                        if (IsTag == "yes")
                        {
                            sql = "select * from [tb_tag] where tag_name like '%" + KeyWord + "%'";
                        }
                        else
                        {
                            if (Class_UserLogin.IsLogin())
                            {
                                sql = "select e.* from (select a.*,d.su_id  from [tb_site] a left join  [tb_site_user] d on d.su_userid='" + Class_UserLogin.UserID().ToString() + "' and a.site_id=d.su_siteid) as e where e.site_name like '%" + KeyWord + "%' and e.site_ispublic=1  order by e.su_id desc,e.site_id asc";
                            }
                            else
                            {
                                sql = "select * from [tb_site] where site_name like '%" + KeyWord + "%' and site_ispublic=1";
                            }
                        }

                        DataTable dt = new DataTable();
                        DBHelper dbh = new DBHelper(config.DBConn);
                        dt = dbh.ExecuteDataTable("", sql);

                        if (dt.Rows.Count > 0)
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                if (IsTag == "yes")
                                {
                                    strSiteInfo += "<div class=\"topic_hot_list span5\"><a target=\"_blank\" href=\"default.aspx?id=" + dt.Rows[i]["tag_id"].ToString() + "\" class=\"icon pull-left\"><img src=\"images/logo.png\"></a><a target=\"_blank\" class=\"title\" href=\"default.aspx?id=" + dt.Rows[i]["tag_id"].ToString() + "\">" + dt.Rows[i]["tag_name"].ToString() + "</a>";
                                    strSiteInfo += "</div>";
                                }
                                else
                                {
                                    strSiteInfo += "<div class=\"topic_hot_list span5\"><a target=\"_blank\" href=\"" + dt.Rows[i]["site_url"].ToString() + "\" class=\"icon pull-left\"><img src=\"" + dt.Rows[i]["site_img"].ToString() + "\"></a><a target=\"_blank\" class=\"title\" href=\"" + dt.Rows[i]["site_url"].ToString() + "\">" + dt.Rows[i]["site_name"].ToString() + "</a>";
                                    strSiteInfo += "</div>";
                                }
                            }
                        }
                        else
                        {
                            strSiteInfo = "没有搜索到任何信息……";
                        }

                        dbh.Dispose();
                        dt.Dispose();
                    }
                    else
                    {
                        strSiteInfo = "请输入关键词……";
                    }
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