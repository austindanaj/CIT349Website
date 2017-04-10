<%@ Page Title="Downloads" Language="C#" Debug="true" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Downloads.aspx.cs" Inherits="CIT349Website.Downloads" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>CIT349 Project</h1>
        <p class="lead">Want to post to the blog, click the button below. Want to comment on a blog post, click the blog from below.</p>
       <asp:Button ID="btnPost" runat="server" CssClass="btn btn-primary btn-lg" Text="Write Blog" /> 
    </div>

        <asp:Button ID="btnDownload1" runat="server" OnClick="didCheckDownload1" Text="Download Forge" />
      <asp:Button ID="btnDownload2" runat="server" OnClick="didCheckDownload2" Text="Download Mods" />
   
</asp:Content>
