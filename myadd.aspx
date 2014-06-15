<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="myadd.aspx.cs" Inherits="Longmao.Web.Sites.myadd" %><!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
<title>龙猫网址</title>  
<link href="css/style.css" rel="stylesheet" />
<script type="text/javascript" src="js/application.js"></script>
</head>
<body>
  
<UserControls:PageHeader runat="server" id="header" />

<div class="container-fluid">  

<div class="row-fluid hot-site">
  <div id="hottags" class="span3" runat="server">
    <ul class="nav nav-tabs nav-stacked">
        <li class=""><a href="myfav.aspx">我的收藏</a></li>
        <li class="active"><a href="myadd.aspx">添加网址</a></li>
    </ul>
  </div>
  <div class="span9">     
    <div class="topic-list">

      <div id="chfeeds" runat="server">
         <div class="setting_layout">
	<div>	
	<ul class="nav nav-tabs">
		<li><a href="myfav.aspx">我的收藏</a></li>
        <li class="active"><a href="myadd.aspx">添加网址</a></li>
	</ul>	
    </div>
	
    <div class="setting_notify">
		<form accept-charset="UTF-8" action="myadd.aspx" class="form-horizontal" method="post">
            <div style="margin:0;padding:0;display:inline">
                <input name="_Post" type="hidden" value="yes" />
            </div>
		<fieldset>
			<div class="control-group">
				<span style="width:60px;">网址</span>
				<div class="login-controls">
					<input class="large" name="siteurl" value="http://" type="text" style="width:400px" /> <input type="button" class="btn btn-primary" value="Get">
				</div>
			</div>
			<div class="control-group">
				<span>网站名称</span>
				<div class="login-controls">
					<input class="large" name="sitename" value="" type="text" style="width:200px" />
				</div>
			</div>
            <div id="addinfo" style="margin-top:10px;display:none;" class="alert alert-info" runat="server"></div>
			<div class="form-actions">
				<input type="submit" class="btn btn-primary" value="  提  交  ">
			</div>
		</fieldset>
</form>	</div>

</div>
      
    </div>
  </div>
</div>

</div>

</div>

<UserControls:PageFooter runat="server" id="footer" />

</body>
</html>