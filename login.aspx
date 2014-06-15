<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Longmao.Web.Sites.login" %><!DOCTYPE html>
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

<div class="center_container" style="padding-top: 60px;">
	<form accept-charset="UTF-8" action="login.aspx" class="form-horizontal" method="post">
        <div style="margin:0;padding:0;display:inline">
            <input name="_Post" type="hidden" value="yes" />
        </div>
		<fieldset class="login">
			<legend  class="form_legend">登录</legend>
            	
			<div class="control-group">
				<span class="control-label">账号</span>
				<div class="login-controls"><input class="medium" id="username" name="username" size="30" type="text" /></div>
			</div>
			<div class="control-group">
				<span class="control-label">密码</span>
				<div class="login-controls"><input id="userpass" name="userpass" class="medium" size="5" type="password" /></div>
			</div>
            <div id="loginerror" class="alert alert-error" style="display:none;" runat="server"></div>

			<div class="control-group">
				<span class="control-label">
				</span>
				<div class="login-controls"><input type="checkbox" name="remember" value="1" checked="checked"/>记住我</div>
			</div>
			<div class="form-actions">
				<button type="submit" class="btn btn-primary">&nbsp;登&nbsp;录&nbsp;</button>
			</div>
		</fieldset>
</form></div>




</div>

<UserControls:PageFooter runat="server" id="footer" />

</body>
</html>