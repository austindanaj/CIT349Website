<%@ Page Title="Downloads" Language="C#" Debug="true" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Downloads.aspx.cs" Inherits="CIT349Website.Downloads" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Download Instructions</h1>
        <p class="tab">
            1) 
            <asp:Button ID="btnDownload1" runat="server" OnClick="didCheckDownload1" Text="Download Forge" />
        </p>

        <p class="tab">2) Install Forge</p>
        <p class="tab">3) Once installed, launch Minecraft</p>
        <p class="tab">4) Look in the profiles drop-down menu, you should see a profile called forge. Log in with that profile</p>
        <p class="tab">5) Wait for the green bar to fully load, and you should have an option call Mods</p>
        <p class="tab">6) Exit Minecraft</p>
        <p class="tab">
            7) 
             <asp:Button ID="btnDownload2" runat="server" OnClick="didCheckDownload2" Text="Download Mods" />
        </p>
        <p class="tab">8) Copy the mods in the downloaded folder, into the mods folder that Forge has created in the /minecraft folder</p>
        <h2>Help Locating Mods Folder - Windows</h2>
        <p class="tab">1) Click windows key </p>
        <p class="tab">2) Type run and click enter </p>
        <p class="tab">3) Type in: appdata </p>
        <p class="tab">4) Open Roaming Folder</p>
        <p class="tab">5) You should see a .minecraft folder, open that </p>
        <p class="tab">6) Then place the files into the mods folder </p>
        <h2>Help Locating Mods Folder - Mac</h2>
        <p class="tab">1) Open Finder </p>
        <p class="tab">2) Click Go, then scroll down to Go to Folder </p>
        <p class="tab">3) Type in: ~/Library/</p>
        <p class="tab">4) Navigate to Application Support </p>
        <p class="tab">5) Then select the Minecraft folder </p>
        <p class="tab">6) Then place the files into the mods folder </p>
    </div>




</asp:Content>
