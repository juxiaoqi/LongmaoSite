<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="myfav.aspx.cs" Inherits="Longmao.Web.Sites.myfav" %><!DOCTYPE html>
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
        <li class="active"><a href="myfav.aspx">我的收藏</a></li>
        <li class=""><a href="myadd.aspx">添加网址</a></li>
    </ul>
  </div>
  <div class="span9">     
    <div class="topic-list">

      <div id="chfeeds" runat="server">
         <div class="setting_layout">
	<div>	
	<ul class="nav nav-tabs">
		<li class="active"><a href="myfav.aspx">我的收藏</a></li>
        <li><a href="myadd.aspx">添加网址</a></li>
	</ul>	
    </div>
	
    <div id="myfavsite" class="setting_notify" runat="server"></div>

</div>
      
    </div>
  </div>
</div>

</div>

</div>

<div id="ConfigErrorModal" class="modal hide fade in" aria-hidden="false" style="display:none;">
<div class="modal-header">
<a class="close" data-dismiss="modal">×</a>
<h3>修改网址</h3>
</div>
<div class="modal-body">该网址属于公共网址，禁止普通用户修改。</div>
</div>

<div id="ConfigModal" class="modal hide fade in" aria-hidden="false" style="display:none;">
<div class="modal-header">
<a class="close" data-dismiss="modal">×</a>
<h3>修改网址</h3>
</div>
<div class="modal-body">
<div class="form-horizontal">
<div class="control-group">
				<span class="control-label">名称</span>
				<div class="login-controls">
                    <input class="input-medium" id="siteid" type="hidden" />
					<input class="input-medium" id="sitename" type="text" />
				</div>
			</div>
<div class="control-group">
				<span class="control-label">网址</span>
				<div class="login-controls">
					<input  id="siteurl" class="input-medium" type="text" style="width:300px;">
				</div>
			</div>
<div class="control-group">
				<span class="control-label">标签</span>
				<div id="sitetags" class="login-controls" runat="server">
					
				</div>
			</div>
<div class="form-actions">
<button class="btn btn-primary" onclick="config_submit();">&nbsp;&nbsp;保&nbsp;&nbsp;&nbsp;存&nbsp;&nbsp;</button>
</div>
</div>
</div>
</div>

<UserControls:PageFooter runat="server" id="footer" />

</body>
</html>