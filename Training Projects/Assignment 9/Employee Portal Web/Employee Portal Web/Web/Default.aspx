<%@ Page AutoEventWireup="true" Codebehind="Default.aspx.cs" Inherits="Web.Default"
    Language="C#" MasterPageFile="~/PortalTemplate.Master" Theme="MainTheme" Title="Home" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="mainContentPlaceHolder">
    <h2>
        Home</h2>
    <div align="left">
        <!-- Page Content Here-->
        <h3>Notice Board</h3>
        <div>
            <i>Current notices will be displayed here.<br />
            </i>
        &nbsp;
            <asp:DataList ID="DataList1" runat="server" DataSourceID="ObjectDataSource1">
                <ItemTemplate>
                    NoticeId:
                    <asp:Label ID="NoticeIdLabel" runat="server" Text='<%# Eval("NoticeId") %>' />
                    <br />
                    Title:
                    <asp:Label ID="TitleLabel" runat="server" Text='<%# Eval("Title") %>' />
                    <br />
                    Description:
                    <asp:Label ID="DescriptionLabel" runat="server" Text='<%# Eval("Description") %>' />
                    <br />
                    StartDate:
                    <asp:Label ID="StartDateLabel" runat="server" Text='<%# Eval("StartDate") %>' />
                    <br />
                    ExpirationDate:
                    <asp:Label ID="ExpirationDateLabel" runat="server" Text='<%# Eval("ExpirationDate") %>' />
                    <br />
                    PostedById:
                    <asp:Label ID="PostedByIdLabel" runat="server" Text='<%# Eval("PostedById") %>' />
                    <br />
                    PostedByName:
                    <asp:Label ID="PostedByNameLabel" runat="server" Text='<%# Eval("PostedByName") %>' />
                    <br />
<br />
                </ItemTemplate>
            </asp:DataList>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetActiveNotices" TypeName="BLL.NoticeList"></asp:ObjectDataSource>
            <br />
        </div>
        
        <h3>
            My Open Issues</h3>
        <div>
            <i>Currently opened issues will be displayed here.</i>
            <br />
            <asp:GridView ID="UserOpenIssues" runat="server" AutoGenerateColumns="False" Visible="True">
                <Columns>
                    <asp:BoundField DataField="IssueId" HeaderText="IssueId" SortExpression="IssueId" />
                    <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                    <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                    <asp:BoundField DataField="DatePosted" HeaderText="DatePosted" SortExpression="DatePosted" />
                    <asp:BoundField DataField="AssignedTo" HeaderText="AssignedTo" SortExpression="AssignedTo" />
                    <asp:BoundField DataField="StatusName" HeaderText="StatusName" SortExpression="StatusName" />
                    <asp:BoundField DataField="Priority" HeaderText="Priority" SortExpression="Priority" />
                    <asp:BoundField DataField="EmployeeName" HeaderText="EmployeeName" SortExpression="EmployeeName" />
                </Columns>
            </asp:GridView>
           
            <br />
        </div>
    </div>
</asp:Content>
