﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tags.aspx.cs" Inherits="Longmao.Web.Sites.tags" %><!DOCTYPE html>
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

<div class="span9">     
<div class="topic-list">
<div class="wishBody">
<div id="tagBall" class="tagBall" runat="server"></div>
</div>
</div>
</div>
</div>

</div>

<UserControls:PageFooter runat="server" id="footer" />

<script type="text/javascript" src="js/wish.js"></script>
</body>
</html>