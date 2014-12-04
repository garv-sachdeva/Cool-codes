<%@ Page Title="View Issue Detail" Language="C#" MasterPageFile="~/PortalTemplate.Master"
    AutoEventWireup="true" CodeBehind="ViewIssueDetail.aspx.cs" Inherits="Web.ViewIssueDetail" Theme="MainTheme" %>

    <asp:Content ID="Content1" runat="server" ContentPlaceHolderID="mainContentPlaceHolder">
       
        <br /><h2>
        
        Issue Detail</h2><br />
        <div align="right"> 
            <asp:Button ID="Button1" runat="server" BorderStyle="Outset" OnClick="Button1_Click" Text="Back" />
&nbsp;</div>
        <br />
    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataSourceID="ObjectDataSource3" Height="50px" Width="575px">
            <Fields>
                <asp:BoundField DataField="IssueId" HeaderText="IssueId" SortExpression="IssueId" />
                <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                <asp:BoundField DataField="DatePosted" HeaderText="DatePosted" SortExpression="DatePosted" />
                <asp:BoundField DataField="PostedBy" HeaderText="PostedBy" SortExpression="PostedBy" />
                <asp:BoundField DataField="AssignedTo" HeaderText="AssignedTo" SortExpression="AssignedTo" />
                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
                <asp:BoundField DataField="Priority" HeaderText="Priority" SortExpression="Priority" />
            </Fields>
        </asp:DetailsView>
            <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" SelectMethod="GetIssue" TypeName="BLL.Issue">
                <SelectParameters>
                    <asp:QueryStringParameter DefaultValue="1" Name="issueId" QueryStringField="issueId" Type="Int32" />
                </SelectParameters>
            </asp:ObjectDataSource>


</asp:Content>
