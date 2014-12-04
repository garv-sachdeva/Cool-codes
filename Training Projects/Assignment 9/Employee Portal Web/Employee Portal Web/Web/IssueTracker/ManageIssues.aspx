<%@ Page Title="" Language="C#" MasterPageFile="~/PortalTemplate.Master" AutoEventWireup="true"
    CodeBehind="ManageIssues.aspx.cs" Inherits="Web.ManageIssues" Theme="MainTheme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceHolder" runat="server">

    <h2>
        Manage Issues </h2>
       <asp:Button ID="ButtonAddIssue" runat="server" Text="Add Issue" onclick="ButtonAddIssue_Click" />
        <br />
        <br/>
        <asp:GridView ID="GridViewManageIssue" runat="server" AutoGenerateColumns="False"
         DataKeyNames="IssueId" OnRowDeleting="GridViewManageIssue_RowDeleting" AllowPaging="true"
           CellPadding="4" ForeColor="#333333" GridLines="None" Width="764px" >
            <AlternatingRowStyle BackColor="White" />
        <Columns>
        <asp:BoundField DataField="IssueId" HeaderText="Issue Id" />
        <asp:BoundField DataField="Title" HeaderText="Title" />
        <asp:BoundField DataField="DatePosted" HeaderText="Date Of Posted On" DataFormatString="{0:dd-MMM-yyyy}"/>
        <asp:BoundField DataField="PostedBy" HeaderText="Posted By" />
        <asp:BoundField DataField="Status" HeaderText="Status" />
        <asp:HyperLinkField HeaderText="Edit" Text = "Edit" DataNavigateUrlFields = "IssueId" DataNavigateUrlFormatString="~/IssueTracker/EditIssue.aspx?IssueId={0}" />
        <asp:CommandField HeaderText="Delete" ShowDeleteButton="true" ButtonType="Link" />
        </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
       </asp:GridView>

</asp:Content>
