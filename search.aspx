<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="search.aspx.cs" Inherits="Longmao.Web.Sites.search" %><!DOCTYPE html>
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
<div id="hottags" class="span3" runat="server"></div>
<div class="span9">     
<div class="topic-list"><div id="chfeeds" runat="server"></div>
</div>
</div>
</div>

</div>

<UserControls:PageFooter runat="server" id="footer" />

</body>
</html>