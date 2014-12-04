<%@ Page Title="" Language="C#" MasterPageFile="~/PortalTemplate.Master" AutoEventWireup="true"
    CodeBehind="ViewEmployeeDetail.aspx.cs" Inherits="Web.ViewEmployeeDetail" Theme="MainTheme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceHolder" runat="server">

    <br /><h2>
        
            Employee Detail</h2><br />
        <div align="right"> 
            
            <asp:Button ID="ButtonBackToSearch" runat="server" OnClick="ButtonBackToSearch_Click" Text="Back" />
            
&nbsp;</div>
        
        <br />
    <div align="center">
    <asp:DetailsView ID="DetailsView2" runat="server" AutoGenerateRows="False" DataSourceID="ObjectDataSource6" Height="50px" Width="476px" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
        <EditRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
        <Fields>
            <asp:BoundField DataField="EmployeeId" HeaderText="EmployeeId" SortExpression="EmployeeId" />
            <asp:BoundField DataField="EmployeeCode" HeaderText="EmployeeCode" SortExpression="EmployeeCode" />
            <asp:BoundField DataField="FirstName" HeaderText="FirstName" SortExpression="FirstName" />
            <asp:BoundField DataField="LastName" HeaderText="LastName" SortExpression="LastName" />
            <asp:BoundField DataField="DateOfBirth" HeaderText="DateOfBirth" SortExpression="DateOfBirth" />
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
            <asp:BoundField DataField="DateOfJoining" HeaderText="DateOfJoining" SortExpression="DateOfJoining" />
            <asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password" />
        </Fields>
        <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
        <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
    </asp:DetailsView>
    <asp:ObjectDataSource ID="ObjectDataSource6" runat="server" SelectMethod="GetEmployee" TypeName="BLL.Employee">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="1" Name="employeeId" QueryStringField="EmployeeId" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
        
        <br />
        </div>
</asp:Content>
