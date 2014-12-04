<%@ Control AutoEventWireup="true" Codebehind="MenuControl.ascx.cs" Inherits="Web.Controls.MenuControl"
    Language="C#" %>
<div align="left">
    <asp:Menu ID="mainMenu" runat="server" DataSourceID="siteMapSource"
        StaticDisplayLevels="10" Width="150px">
        <StaticSelectedStyle CssClass="menuNodeSelected" />
        <LevelMenuItemStyles>
            <asp:MenuItemStyle Font-Bold="True" Font-Underline="False" />
        </LevelMenuItemStyles>
        <StaticMenuItemStyle CssClass="menuNode" />
    </asp:Menu>
    <asp:SiteMapDataSource ID="siteMapSource" runat="server" ShowStartingNode="False" />
</div>
