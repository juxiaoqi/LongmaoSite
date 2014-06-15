using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Longmao.Web.Sites
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                HttpCookie longmao_userinfo = new HttpCookie("longmao_userinfo");
                longmao_userinfo.Value = "";
                longmao_userinfo.Expires = DateTime.Now.AddDays(-1);
                Response.AppendCookie(longmao_userinfo);

                Response.Redirect("default.aspx");
            }
            catch
            {
                Response.Redirect("default.aspx");
            }
        }
    }
}