
<%@ Page Language="C#" MasterPageFile="~/PortalTemplate.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Web.Login" Title="Employee Portal - Login" Theme="MainTheme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceHolder" runat="server">
<h2>Login</h2>
<div align="center">
    <asp:Login ID="mainLogin" runat="server" SkinID="loginSkin" TitleText="" InstructionText="Enter your User Name and Password to login &nbsp;"
        DisplayRememberMe="False" OnAuthenticate="mainLogin_Authenticate">
        
    </asp:Login>
</div>
</asp:Content>