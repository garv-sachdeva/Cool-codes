<%@ Page Title="" Language="C#" MasterPageFile="~/PortalTemplate.Master" AutoEventWireup="true"
    CodeBehind="EditEmployee.aspx.cs" Inherits="Web.EditEmployee" Theme="MainTheme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceHolder" runat="server">
    
        <br />
     <br /><h2>
        Edit Employee</h2>
        <br />
          <br />
    <div align = "center" style="width: 690px">
        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" DataSourceID="ObjectDataSource4" Height="50px" Width="314px" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal">
            <EditRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <Fields>
                
                <asp:BoundField DataField="EmployeeId" HeaderText="EmployeeId" SortExpression="EmployeeId" />
                <asp:BoundField DataField="EmployeeCode" HeaderText="EmployeeCode" SortExpression="EmployeeCode" />
                <asp:BoundField DataField="DateOfJoining" DataFormatString="{0:dd/MMM/yyyy}" HeaderText="DateOfJoining" SortExpression="DateOfJoining" />
            </Fields>
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
        </asp:DetailsView>
        <asp:ObjectDataSource ID="ObjectDataSource4" runat="server" SelectMethod="GetEmployee" TypeName="BLL.Employee">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="1" Name="employeeId" SessionField="UserId" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <br />
       
&nbsp;<table class="auto-style1">
            <tr>
                <td class="auto-style3" style="width: 374px; height: 29px;" align="center">First Name</td>
                <td class="auto-style3" style="height: 29px; text-align: left; width: 312px;">
                    <asp:TextBox ID="TextBoxFName" runat="server" AutoCompleteMode="CustomSource" ></asp:TextBox>
                </td>
                <td style="width: 215px">
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="TextBoxFName" ErrorMessage="EnterFirstName"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2" style="width: 374px" align="center">Last Name</td>
                <td class="auto-style2" style="text-align: left; width: 312px;">
                    <asp:TextBox ID="TextBoxLName" runat="server"></asp:TextBox>
                </td>
                <td style="width: 215px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="TextBoxLName" ErrorMessage="EnterLastName"></asp:RequiredFieldValidator>
            </td>
            </tr>
            
            <tr>
                <td style="width: 374px" align="center">Email ID</td>
                <td style="text-align: left; width: 312px;">
                    <asp:TextBox ID="TextBoxEmail" runat="server"></asp:TextBox>
                </td>
                <td style="width: 215px" >
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="TextBoxEmail" ErrorMessage="EnterEmailId"></asp:RequiredFieldValidator>
                <br />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="TextBoxEmail" ErrorMessage="Email Should be in valid form" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </td>
            </tr>
            <tr>
                <td class="auto-style3" style="width: 374px" align="center">DOB</td>
                <td class="auto-style3" style="text-align: left; width: 312px;">
                    <asp:TextBox ID="TextBoxDOB" runat="server" TextMode="Date" Text='<%# Bind("dobReal","{0: dd-MMM-yyyy}") %>' Visible="true" OnDataBinding="Page_Load"></asp:TextBox>
                </td>
                <td style="width: 215px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="TextBoxDOB" ErrorMessage="EnterDOB"></asp:RequiredFieldValidator>
                <br />
                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ControlToValidate="TextBoxDOB" ErrorMessage="EnterValidDate" 
                    Operator="DataTypeCheck" Type="Date"></asp:CompareValidator>
            </td>
            </tr>
            <tr>
                <td style="width: 374px" align="center">Department Name</td>
                <td style="text-align: left; width: 312px;">
                    <asp:DropDownList ID="DropDownListDepartment" runat="server" DataSourceID="ObjectDataSource8" DataTextField="DepartmentName" DataValueField="DepartmentId">
                    </asp:DropDownList>
                    <asp:ObjectDataSource ID="ObjectDataSource8" runat="server" SelectMethod="GetAllDept" TypeName="BLL.DepartmentList"></asp:ObjectDataSource>
                </td>
                <td style="width: 215px">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ControlToValidate="DropDownListDepartment" 
                    ErrorMessage="EnterDepartmentName"></asp:RequiredFieldValidator>
            </td>
            </tr>
     <tr>
                <td style="width: 374px" align="center">Password</td>
                <td style="text-align: left; width: 312px;">
                    <asp:TextBox ID="TextBoxPswd" runat="server" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
        </table>

        <br />
       
        <asp:Button ID="UpdateButton" runat="server" BorderStyle="Outset" OnClick="UpdateB" Text="Update" OnDataBinding="UpdateB" />
        &nbsp;
        <asp:Button ID="CancelButton" runat="server" BorderStyle="Outset" OnClick="CancelButton_Click" Text="Cancel" CausesValidation="False"/>
        <br />

        <br />

    </div>
</asp:Content>
