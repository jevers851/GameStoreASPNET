﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategoryList.ascx.cs" Inherits="GamesStore.Controls.CategoryList" %>

<%=CreateHomeLinkHtml() %>

<% foreach (string cat in GetCategories())
    {
        Response.Write(CreateLinkHtml(cat));
    }%>