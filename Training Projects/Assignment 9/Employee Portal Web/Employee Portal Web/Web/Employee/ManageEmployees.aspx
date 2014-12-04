<%@ Page Title="" Language="C#" MasterPageFile="~/PortalTemplate.Master" AutoEventWireup="true"
    CodeBehind="ManageEmployees.aspx.cs" Inherits="Web.ManageEmployees" Theme="MainTheme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceHolder" runat="server">

    
       <h2> Manage Employees </h2>
    <div>
         <asp:Button ID="AddNewEmployee" runat="server" OnClick="AddNewEmployee_Click" Text="Add New Employee" />
        <br />
        <br />
        <asp:GridView ID="GridViewManageEmployee" runat="server" 
            AutoGenerateColumns="False" Width ="99%"
            DataKeyNames="EmployeeId" 
            OnRowDataBound ="GridViewManageEmployee_RowDataBound"
            OnRowCommand="GridViewManageEmployee_RowCommand" CellPadding="4" 
            ForeColor="#333333" GridLines="None" style="margin-right: 0px" > 
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="EmployeeCode" HeaderText="Employee Code" SortExpression="EmployeeCode" />
                <asp:TemplateField HeaderText ="Name">
                    <ItemTemplate>
                        <%#Eval("FirstName") %> <%#Eval("LastName")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="DateOfJoining" DataFormatString="{0:dd-MMM-yyyy}" HeaderText="Date Of Joining" SortExpression="DateOfJoining" />
                <asp:BoundField DataField="Department.DepartmentName" HeaderText="Department" SortExpression="Department" />
                <asp:TemplateField>
                    <ItemTemplate>
                <asp:HyperLink ID="HyperLink2" runat="server" Text="Edit" NavigateUrl ='<%# "~/Employee/EditEmployee.aspx?EmployeeId=" + Eval("EmployeeId").ToString() %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Delete">
	                <ItemTemplate>
	            	<asp:Button ID="deleteButton" runat="server" CommandName="DeleteButton" CommandArgument='<%# Eval("EmployeeId") %>' Text="Delete"
                    OnClientClick="return confirm('Are you sure you want to delete this user?');" />
	            </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EditRowStyle BackColor="#2461BF"  />
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
    </div>
</asp:Content>
