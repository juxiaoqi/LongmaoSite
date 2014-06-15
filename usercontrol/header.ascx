<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="header.ascx.cs" Inherits="Longmao.Web.Sites.usercontrol.header" %>
<div id="header" class="navbar-fixed-top">
    <div class="container">
      <div class="navbar">
        <div class="navbar-inner">
          <a class="btn btn-navbar" data-toggle="collapse" data-target=".nav-collapse"> 
            <span class="icon-bar"></span> 
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span> 
          </a>
          <a href="http://www.14190.com/" class="brand"><img src="images/logo.png" alt="龙猫网址" /></a>        
		      <nav class="nav-collapse collapse">
            <ul class="nav navbar primary-nav">
                <li class="active"><a href="/longmao">网址</a></li>
            </ul>
            <form class="navbar-search pull-left" action="search.aspx">
              <input type="text" class="search-query span2" name="kw" placeholder="搜索">
            </form>
            <ul id="userinfo" class="nav pull-right" runat="server">
                <li><a href="login.aspx">登录</a></li>
            </ul>
          </nav>
        </div>
      </div>
	   </div>
	</div>

<div id ="flash_container" class="noPrint"></div>