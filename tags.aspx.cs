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
    public partial class tags : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        strTagInfo += "<a href=\"default.aspx?id=" + dt.Rows[i]["tag_id"].ToString() + "\" class=\"tag\" target=\"_blank\">" + dt.Rows[i]["tag_name"].ToString() + "</a>";
                    }
                }

                dbh.Dispose();
                dt.Dispose();
            }
            catch (Exception ex)
            {
                strTagInfo = ex.ToString();
            }

            this.tagBall.InnerHtml = strTagInfo;

            #endregion
        }
    }
}