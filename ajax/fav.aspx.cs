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
    public partial class fav : System.Web.UI.Page
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
                    if (Request["name"] != null && Request["name"] != "")
                    {
                        return Request["name"];
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
                    if (Request["url"] != null && Request["url"] != "")
                    {
                        return Request["url"];
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

        #region 站点图片链接
        /// <summary>
        /// 站点图片链接
        /// </summary>
        public string SiteImgURL
        {
            get
            {
                try
                {
                    if (Request["imgurl"] != null && Request["imgurl"] != "")
                    {
                        return Request["imgurl"];
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

        #region 标签编号
        /// <summary>
        /// 标签编号
        /// </summary>
        public string SiteTags
        {
            get
            {
                try
                {
                    if (Request["tags"] != null && Request["tags"] != "")
                    {
                        return Request["tags"];
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
            try
            {
                string sql = "";

                switch (ControlType)
                {
                    case "1":
                        sql = "delete from [tb_site_user] where su_siteid='" + SiteID + "' and su_userid=" + Class_UserLogin.UserID() + ";insert into [tb_site_user] (su_siteid,su_userid)values('" + SiteID + "'," + Class_UserLogin.UserID() + ") ";
                        break;
                    case "2":
                        sql = "delete from [tb_site_user] where su_siteid='" + SiteID + "' and su_userid=" + Class_UserLogin.UserID() + "";
                        break;
                    case "3":
                        if (Class_UserLogin.IsManageUser())
                        {
                            if (SiteImgURL != "" && SiteImgURL != null)
                            {
                                sql = "update [tb_site] set site_name='" + SiteName + "',site_url='" + SiteURL + "',site_img='" + SiteImgURL + "' where site_id='" + SiteID + "'";
                            }
                        }
                        else
                        {
                            sql = "update [tb_site] set site_name='" + SiteName + "',site_url='" + SiteURL + "' where site_id='" + SiteID + "' and site_ispublic=0";
                        }

                        sql += "delete from [tb_site_tag] where st_siteid='" + SiteID + "';";

                        if (SiteTags.Length > 0)
                        {
                            for (int i = 0; i < SiteTags.Split(',').Count() - 1; i++)
                            {
                                sql += "insert into [tb_site_tag] (st_siteid,st_tagid)values('" + SiteID + "','" + SiteTags.Split(',')[i].ToString() + "');";
                            }
                        }
                        break;
                }

                DataTable dt = new DataTable();
                DBHelper dbh = new DBHelper(config.DBConn);
                dt = dbh.ExecuteDataTable("", sql);

                Response.Write("yes");
            }
            catch
            {
                Response.Write("no");
            }
        }
    }
}