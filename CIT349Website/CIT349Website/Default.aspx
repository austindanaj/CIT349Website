<%@ Page Title="Home Page" Language="C#" Debug="true" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CIT349Website._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>CIT349 Project</h1>
        <p class="lead">Want to post to the blog, click the button below. Want to comment on a blog post, click the blog from below.</p>
       <asp:Button ID="btnPost" runat="server" OnClick="Post_clicked" CssClass="btn btn-primary btn-lg" Text="Write Blog" /> 
    </div>

    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" class="gridview" ShowHeader="false" GridLines="None">
            <Columns>
                <asp:TemplateField ShowHeader="false">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <div class="BlogHead">
                                    <h2><a href='<%# Eval("BLOG_ID", "details.aspx?Id={0}") %>' class="BlogHead">
                                        <asp:Label ID="Label1" runat="server" Text='<%#Eval("BLOG_TITLE") %>'></asp:Label></a></h2>

                                </div>
                                <div class="post_meta">
                                    <span class="post_author blackLink nocursor">
                                        <asp:Label ID="Label2" runat="server" Text='<%#Eval("BLOG_AUTHOR") %>'></asp:Label>,</span>
                                    <span class="date blackLink nocursor">
                                        <asp:Label ID="Label11" runat="server" Text='<%#Eval("BLOG_DATE") %>'></asp:Label></span>
                                </div>
                                <br />
                                <div id="blbodythumb" style="text-align: justify;">
                                    <p>
                                        <asp:Label ID="Label100" runat="server" Text='<%#Eval("BLOG_CONTENT") %>'></asp:Label>
                                    </p>
                                </div>
                                <hr class="style-one" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                No data
            </EmptyDataTemplate>
        </asp:GridView>
    </div>

</asp:Content>
