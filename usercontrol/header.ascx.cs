using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Longmao.Web.Sites.lib;

namespace Longmao.Web.Sites.usercontrol
{
    public partial class header : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Class_UserLogin.IsLogin())
                {
                    this.userinfo.InnerHtml = "<li class=\"dropdown\">";
                    this.userinfo.InnerHtml += "<a href=\"#\" class=\"dropdown-toggle\" data-toggle=\"dropdown\"><img alt=\"" + Class_UserLogin.UserName() + "\" src=\"images/avatar/" + Class_UserLogin.UserID() + ".png\"> " + Class_UserLogin.UserName() + " <b class=\"caret\"></b></a>";
                    this.userinfo.InnerHtml += "<ul class=\"dropdown-menu\">";
                    this.userinfo.InnerHtml += "<li><a href=\"myfav.aspx\">我的收藏</a></li>";
                    this.userinfo.InnerHtml += "<li><a href=\"myadd.aspx\">添加网址</a></li>";

                    if (Class_UserLogin.IsManageUser())
                    {
                        this.userinfo.InnerHtml += "<li><a href=\"manage.aspx\">★网址管理</a></li>";
                    }

                    this.userinfo.InnerHtml += "<li><a href=\"logout.aspx\">退出</a></li>";
                    this.userinfo.InnerHtml += "</ul>";
                    this.userinfo.InnerHtml += "</li>";
                }
            }
            catch
            {
            }
        }
    }
}