<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchEmployee.aspx.cs"
    Inherits="Web.Employee.SearchEmployee" MasterPageFile="~/PortalTemplate.Master" Theme="MainTheme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceHolder" runat="server">

    <br />
     <h2>Search Employee</h2>
      <table style="width: 100%">
          <tr>
              <td>Employee code</td>
              <td>
        <asp:TextBox ID="TextBoxEmpCode" runat="server"></asp:TextBox>
        &nbsp;<asp:CompareValidator ID="CompareValidator2" runat="server" 
                            ControlToValidate="TextBoxEmpCode" 
                            ErrorMessage="Employee Code Not in correct form" Operator="DataTypeCheck" 
                            Type="Integer">*</asp:CompareValidator>
              </td>
              <td>&nbsp; Date of Joining</td>
              <td>
        <asp:TextBox ID="TextBoxDoj" runat="server" TextMode="Date" ></asp:TextBox>
        <asp:CompareValidator ID="CompareValidator1" runat="server" 
                            ErrorMessage="Enter Valid Date" Display="Dynamic" cultureinvariantvalues="true"
             Operator="LessThan" ControlToValidate="TextBoxDoj" >*</asp:CompareValidator>
              </td>
          </tr>
          <tr>
              <td style="height: 34px">First Name&nbsp;&nbsp;</td>
              <td style="height: 34px"><asp:TextBox ID="TextBoxFName" runat="server"></asp:TextBox>
                  &nbsp;&nbsp;&nbsp;</td>
              <td style="height: 34px">&nbsp;Last Name</td>
              <td style="height: 34px">
        <asp:TextBox ID="TextBoxLName" runat="server"></asp:TextBox>
              </td>
          </tr>
          <tr>
              <td>Department</td>
              <td>
        <asp:DropDownList ID="DropDownListDept" runat="server" DataSourceID="ObjectDataSource5" DataTextField="DepartmentName" DataValueField="DepartmentId" Width="101px">
        </asp:DropDownList>
                  <asp:ObjectDataSource ID="ObjectDataSource5" runat="server" SelectMethod="GetAllDept" TypeName="BLL.DepartmentList"></asp:ObjectDataSource>
              </td>
              <td>&nbsp;</td>
              <td>&nbsp;</td>
          </tr>
    </table>
    <br />
      <br />
    <div align = "center">

        &nbsp;
        <br />
        <asp:Button ID="Button1" runat="server" BorderStyle="Outset" OnClick="Button1_Click" Text="Search" />
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="550px" >
            <Columns>
                <asp:BoundField DataField="EmployeeCode" HeaderText="EmployeeCode" SortExpression="EmployeeCode" />
                 <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                             <%#Eval("FirstName") %>&nbsp;<%#Eval("LastName") %>
                        </ItemTemplate>                       
                    </asp:TemplateField>
                <asp:BoundField DataField="DateOfJoining" dataformatstring="{0:MMMM d, yyyy}" HeaderText="DateOfJoining" htmlencode="false" SortExpression="DateOfJoining" />
                <asp:BoundField DataField="Department.DepartmentName" HeaderText="DepartmentName" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:HyperLink ID="HyperLink1" runat="server" Text="View Detail" 
                            NavigateUrl='<%# "~/Employee/ViewEmployeeDetail.aspx?employeeId=" + Eval("EmployeeId").ToString() %>'></asp:HyperLink>
                    </ItemTemplate>
                    </asp:TemplateField> 
              </Columns>
        </asp:GridView>
    
        <br />
        <br />



        </div>
</asp:Content>