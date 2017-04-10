<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="write.aspx.cs" Inherits="CIT349Website.write" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div>
            <br />
            <asp:Label ID="lblTitle" runat="server" Text="Write Post" CssClass="login-title"></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="txbxTitle" runat="server" placeholder="Title" CssClass="txt-descrip"></asp:TextBox>
        </div>
        <br />
        <div>
            <asp:TextBox ID="txbxAuthor" runat="server" placeholder="Author" CssClass="txt-descrip"></asp:TextBox>
        </div>
        <br />
        <div>

            <asp:TextBox ID="txbxContent" runat="server" TextMode="MultiLine" placeholder="Blog post" CssClass="txt-descrip"></asp:TextBox>
        </div>
        <asp:Button ID="Button1" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="Button1_Click" />
    </div>
</asp:Content>
