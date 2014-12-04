<%@ Page Title="" Language="C#" MasterPageFile="~/PortalTemplate.Master" AutoEventWireup="true"
    CodeBehind="AddNewIssue.aspx.cs" Inherits="Web.AddNewIssue" Theme="MainTheme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceHolder" runat="server">

  
        <br />
       <h2> Add
        Issue </h2>
    <br />


        <br />
    <center>
        Title&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBoxTitle" runat="server" Height="23px" Width="254px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="TextBoxTitle" ErrorMessage="Enter Title">*</asp:RequiredFieldValidator>
        <br />
        <br />
        <div style="vertical-align:central">
        Description&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBoxIssueDesc" runat="server" Height="113px" TextMode="MultiLine" Width="318px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="TextBoxIssueDesc" ErrorMessage="Enter Description">*</asp:RequiredFieldValidator>
        </div>
        <br />
        <br />
        <br />
        Priority&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="DropDownListPriority" runat="server">
            <asp:ListItem Value="1">Normal</asp:ListItem>
            <asp:ListItem Value="2">Urgent</asp:ListItem>
            <asp:ListItem Value="3">Immediate</asp:ListItem>
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="DropDownListPriority" ErrorMessage="Enter Priority">*</asp:RequiredFieldValidator>
        <br />
        <br />
        <asp:Button ID="ButtonUpdate" runat="server" Text="Update" OnClick="ButtonUpdate_Click" />
&nbsp;&nbsp;
        <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" OnClick="ButtonCancel_Click" CausesValidation="false" />
        </center>
        <br />


</asp:Content>
