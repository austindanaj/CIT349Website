<%@ Page Title="Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="details.aspx.cs" Inherits="CIT349Website.details" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="false" Width="100%" GridLines="None">
            <Fields>
                <asp:TemplateField ShowHeader="false">
                    <ItemTemplate>
                        <tr>
                            <div>
                                <h2>
                                    <asp:Label ID="lblBlogPostTitle" runat="server" Text='<%#Eval("BLOG_TITLE") %>'></asp:Label></h2>
                                <div>
                                    <span>
                                        <asp:Label ID="lblAuthor" runat="server" Text='<%#Eval("BLOG_AUTHOR") %>'></asp:Label></span>
                                    <span>
                                        <asp:Label ID="lblBlogDate" runat="server" Text='<%#Eval("BLOG_DATE") %>'></asp:Label></span>
                                </div>
                                <div style="text-align: justify;">
                                    <p>
                                        <asp:Label ID="lblMessage" runat="server" Text='<%#Eval("BLOG_CONTENT") %>'></asp:Label>
                                    </p>
                                </div>
                            </div>
                        </tr>
                    </ItemTemplate>
                </asp:TemplateField>
            </Fields>
        </asp:DetailsView>
    </div>
    <div>
        <hr />
        comments:
        <br />
        <asp:GridView ID="GridViewcomment" runat="server" AutoGenerateColumns="false" ShowHeader="false" GridLines="None" Width="100%" CellSpacing="10">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <div>
                                    <asp:Label ID="lblauthor" runat="server" Text='<%#Eval("COM_NAME") %>' Font-Bold="true" Font-Italic="true" Font-Size="Large"></asp:Label>
                                    <asp:Label ID="LabelCommentDate" runat="server" Text='<%# Eval("COM_DATE") %>' Font-Size="Smaller"></asp:Label>
                                </div>
                                <div>
                                    <p>
                                        <asp:Label ID="Lblcomment" runat="server" Text='<%#Eval("COM_COMMENT") %>'></asp:Label>
                                    </p>
                                </div>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:Label ID="LabelNoComment" runat="server" Text="No comments yet." Visible="false"></asp:Label>
    </div>
    <div id="comment_form">
        <h3>Post a comment</h3>
      
        <asp:TextBox ID="txbxcommentauthor" placeholder="Name" CssClass="txt-descrip" runat="server" MaxLength="30"></asp:TextBox>
        <br />
        <asp:TextBox ID="txbxcomment" runat="server" placeholder="Comment" CssClass="txt-descrip" TextMode="MultiLine"></asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="Button1_Click" />
    </div>
</asp:Content>
