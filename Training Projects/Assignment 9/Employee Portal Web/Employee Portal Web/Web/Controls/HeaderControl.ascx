<%@ Control AutoEventWireup="true" Codebehind="HeaderControl.ascx.cs" Inherits="Web.Controls.HeaderControl"
    Language="C#" %>
<div class="header">
    <table cellpadding="4" cellspacing="0" width="100%">
        <tr>
            <td align="left">
                <asp:Image ID="logoImage" runat="server" ImageUrl="~/App_Themes/MainTheme/Images/nagarrologo.gif" />
            </td>
            <td valign="bottom">
                <div align="right" runat="server" id="welcomeDiv" visible="false">                                   
                    Welcome <asp:Label ID="userInfoLabel" runat="server"></asp:Label>
                    <br />
                    <asp:LoginStatus ID="loginStatus" runat="server" LogoutAction="RedirectToLoginPage" OnLoggingOut="loginStatus_LoggingOut" />
                </div>
            </td>
        </tr>
    </table>
</div>
<div align="left" class="navPathDiv">
    <asp:SiteMapPath ID="SiteMapPath1" runat="server" RenderCurrentNodeAsLink="True">
        <NodeStyle CssClass="navPathNode" />
    </asp:SiteMapPath>&nbsp;
</div>
