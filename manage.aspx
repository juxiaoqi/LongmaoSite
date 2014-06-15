<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="manage.aspx.cs" Inherits="Longmao.Web.Sites.manage" %><!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
<title>龙猫网址</title>  
<link href="css/style.css" rel="stylesheet" />
<script type="text/javascript" src="js/application.js"></script>
<script type="text/javascript" src="js/ajaxfileupload.js"></script>
</head>
<body>
  
<UserControls:PageHeader runat="server" id="header" />

<div class="container-fluid">

<div class="row-fluid hot-site">
  <div>     
    <div class="topic-list">

      <div id="chfeeds" runat="server">
         <div class="setting_layout">
	<div>	
	<ul class="nav nav-tabs">
		<li class="active"><a href="manage.aspx">网址管理</a></li>
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
<div style="margin-right:20px;position: absolute;top: 20px;left: 450px;"><img id="siteimg" src="" style="width:50px;height:50px;"></div>
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
				<span class="control-label">网址图片</span>
				<div class="login-controls">
					<input id="siteimgurl" class="input-medium" type="text" style="width:300px;">&nbsp;
                 </div>
			</div>
<div class="control-group">
				<span class="control-label">更改图片</span>
				<div class="login-controls">
					<input id="imgfilepath" class="input-medium" type="file" name="imgfilepath"  />
                    <button class="btn btn-primary" onclick="manage_upload();">上传</button>
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