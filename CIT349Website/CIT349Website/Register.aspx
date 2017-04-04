<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="CIT349Website.Register" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

   <br />
    <div class="login-page">
        <div class="login">
            <div class="login-form">
                <asp:Label ID="lblSignIn" runat="server" Text="Register" CssClass="login-title"></asp:Label>
                <br />
                <br />
                <asp:TextBox ID="txtFName" runat="server" placeholder="First Name"></asp:TextBox>
                <asp:TextBox ID="txtLName" runat="server" placeholder="Last Name"></asp:TextBox>               
                <asp:TextBox ID="txtUser" runat="server" placeholder="username"></asp:TextBox>
                <asp:TextBox ID="txtPass" runat="server" placeholder="password" TextMode="Password"></asp:TextBox>
                <asp:TextBox ID="txtConfirm" runat="server" placeholder="confirm password" TextMode="Password"></asp:TextBox> 
                <asp:Button ID="btnRegister" runat="server" OnClick="Register_Clicked" Text="Register" CssClass="btn-login"/>
                <br />
               
            </div>
        </div>
    </div>
</asp:Content>
