<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CIT349Website.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   <br />
    <div class="login-page">
        <div class="login">
            <div class="login-form">
                <asp:Label ID="lblSignIn" runat="server" Text="Sign In" CssClass="login-title"></asp:Label>
                <br />
                <br />
                <asp:TextBox ID="txtUser" runat="server" placeholder="username"></asp:TextBox>
                <asp:TextBox ID="txtPass" runat="server" placeholder="password" TextMode="Password"></asp:TextBox>
                <asp:Button ID="btnSignIn" runat="server" OnClick="SignIn_Clicked" Text="Sign In" />
                <br />
                <asp:LinkButton ID="lnkButton" OnClick="NeedAccount_Clicked" runat="server">Need an account, click here!</asp:LinkButton>
            </div>
        </div>
    </div>

</asp:Content>
