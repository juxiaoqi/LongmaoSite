using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Fund.Core;
using System.Data;
using Longmao.Web.Sites.lib;

namespace Longmao.Web.Sites.ajax
{
    public partial class site : System.Web.UI.Page
    {
        #region 站点编号
        /// <summary>
        /// 站点编号
        /// </summary>
        public string SiteID
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

        #region 操作类型
        /// <summary>
        /// 操作类型
        /// </summary>
        public string ControlType
        {
            get
            {
                try
                {
                    if (Request["t"] != null && Request["t"] != "")
                    {
                        return Request["t"];
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
            string strInfo = "";
            string sql = "";

            if (ControlType == "manage")
            {
                if (!Class_UserLogin.IsManageUser())
                {
                    Response.Write("no");
                    Response.End();
                }
                else
                {
                    sql = "select * from [tb_site] where site_id='" + SiteID + "'";
                }

            }
            else
            {
                sql = "select * from [tb_site] where site_id='" + SiteID + "' and site_ispublic=0";
            }

            try
            {
                DataTable dt = new DataTable();
                DBHelper dbh = new DBHelper(config.DBConn);
                dt = dbh.ExecuteDataTable("", sql);

                if (dt.Rows.Count > 0)
                {
                    strInfo += "{";
                    strInfo += "'siteid':" + dt.Rows[0]["site_id"].ToString() + ",";
                    strInfo += "'sitename':'" + dt.Rows[0]["site_name"].ToString() + "',";
                    strInfo += "'siteurl':'" + dt.Rows[0]["site_url"].ToString() + "',";
                    strInfo += "'siteimg':'" + dt.Rows[0]["site_img"].ToString() + "',";
                    strInfo += "'sitetag':[";
                    strInfo += GetSiteTags("" + SiteID + "");
                    strInfo += "]";
                    strInfo += "}";
                }

                dt.Dispose();
                dbh.Dispose();

                Response.Write(strInfo);
            }
            catch
            {
                Response.Write("no");
            }
        }


        #region 获取网站目前的标签信息
        /// <summary>
        /// 获取网站目前的标签信息
        /// </summary>
        /// <param name="strSiteID">网址编号</param>
        /// <returns></returns>
        protected string GetSiteTags(string strSiteID)
        {
            string strInfo = "";

            try
            {
                string sql_tag = "select a.st_siteid,b.tag_id,b.tag_name from [tb_site_tag] a,[tb_tag] b where a.st_tagid=b.tag_id and a.st_siteid='" + strSiteID + "'";

                DataTable dt_tag = new DataTable();
                DBHelper dbh_tag = new DBHelper(config.DBConn);
                dt_tag = dbh_tag.ExecuteDataTable("", sql_tag);

                if (dt_tag.Rows.Count > 0)
                {
                    for (int i = 0; i < dt_tag.Rows.Count; i++)
                    {
                        strInfo += "{'tagid':" + dt_tag.Rows[i]["tag_id"].ToString() + "},";
                    }
                }

                dt_tag.Dispose();
                dbh_tag.Dispose();

                strInfo = strInfo.Substring(0, strInfo.Length - 1);
            }
            catch
            {
                strInfo = "0";
            }

            return strInfo;
        } 
        #endregion
    }
}