<%@ Page Title="" Language="C#" MasterPageFile="~/PortalTemplate.Master" AutoEventWireup="true"
    CodeBehind="AddEmployee.aspx.cs" Inherits="Web.AddEmployee" Theme="MainTheme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceHolder" runat="server">

    <table style="width: 100%">
        <tr>
            <td style="text-align: right; width: 158px">
                Employee Code</td>
            <td style="width: 244px">
                <asp:TextBox ID="TextBoxEmployeeCode" runat="server" Width="136px" 
                    ></asp:TextBox>
  
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                    ControlToValidate="TextBoxEmployeeCode" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator2" runat="server" 
                    ControlToValidate="TextBoxEmployeeCode" ErrorMessage="CompareValidator" 
                    Operator="DataTypeCheck" Type="Integer">*</asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 158px">
                Date Of Joining</td>
            <td style="width: 244px">
                <asp:TextBox ID="TextBoxDateOfJoining" runat="server" Width="136px" 
                   ></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                    ControlToValidate="TextBoxDateOfJoining" ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 158px">
                First Name</td>
            <td style="width: 244px">
                <asp:TextBox ID="TextBoxFirstName" runat="server" Width="136px" 
                    ></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="TextBoxFirstName" ErrorMessage="EnterFirstName"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 158px">
                Last Name</td>
            <td style="width: 244px">
                <asp:TextBox ID="TextBoxLastName" runat="server" Width="136px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="TextBoxLastName" ErrorMessage="EnterLastName"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 158px">
                Date Of Birth</td>
            <td style="width: 244px">
                <asp:TextBox ID="TextBoxDateOfBirth" runat="server" Width="136px"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="TextBoxDateOfBirth" ErrorMessage="EnterDOB"></asp:RequiredFieldValidator>
                <br />
                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ControlToValidate="TextBoxDateOfBirth" ErrorMessage="EnterValidDate" 
                    Operator="DataTypeCheck" Type="Date"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 158px">
                EmailId</td>
            <td style="width: 244px">
                <asp:TextBox ID="TextBoxEmail" runat="server" Width="136px" TextMode="Email"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="TextBoxEmail" ErrorMessage="EnterEmailId"></asp:RequiredFieldValidator>
                <br />
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="TextBoxEmail" ErrorMessage="Email Should be in valid form" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 158px">
                Department</td>
            <td style="width: 244px">
                <asp:DropDownList ID="DropDownListDepartment" runat="server" 
                     AppendDataBoundItems="True" DataSourceID="ObjectDataSource7" DataTextField="DepartmentName" DataValueField="DepartmentId" >
                    
           
                </asp:DropDownList>
                <asp:ObjectDataSource ID="ObjectDataSource7" runat="server" SelectMethod="GetAllDept" TypeName="BLL.DepartmentList"></asp:ObjectDataSource>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ControlToValidate="DropDownListDepartment" 
                    ErrorMessage="EnterDepartmentName"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="text-align: right; width: 158px">
                Password</td>
            <td style="width: 244px">
                <asp:TextBox ID="TextBoxPassword" runat="server" Width="136px" 
                    TextMode="Password"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                    ControlToValidate="TextBoxPassword" ErrorMessage="EnterPassword"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 158px">
                &nbsp;</td>
            <td style="width: 244px">
                <asp:Button ID="ButtonAddUpdate" runat="server" Text="Update" onclick="ButtonAddUpdate_Click" />
                &nbsp;
                <input id="Reset1" style="width: 64px" type="reset" value="Reset" />&nbsp;
                <asp:Button ID="Button1" runat="server" OnClick="Cancel_Click" Text="Cancel" CausesValidation="false" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 158px">
                &nbsp;</td>
            <td style="width: 244px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 158px">
                &nbsp;</td>
            <td style="width: 244px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 158px">
                &nbsp;</td>
            <td style="width: 244px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>

</asp:Content>
