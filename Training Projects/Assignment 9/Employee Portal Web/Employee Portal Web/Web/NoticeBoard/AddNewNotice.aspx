<%@ Page Title="" Language="C#" MasterPageFile="~/PortalTemplate.Master" AutoEventWireup="true"
    CodeBehind="AddNewNotice.aspx.cs" Inherits="Web.AddNewNotice" Theme="MainTheme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceHolder" runat="server">

    <h2>
        Add New Notice
        </h2>
        <div align="right">
        <asp:Button ID="BackLinkButton" runat="server" BorderStyle="Outset"  onclick="BackLinkButton_Click" Text="Back" CausesValidation="False" />
           
        </div>
        <br />
        <table style="width: 100%">
            <tr>
                <td style="width: 152px">
                    <asp:Label ID="TitleLabel" runat="server" Text="Title"></asp:Label>
                </td>
                <td style="width: 196px">
                    <asp:TextBox ID="TitleTextBox" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="TitleTextBox" ErrorMessage="Enter Notice Title">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 152px">
                    <asp:Label ID="StartDateLabel" runat="server" Text="Start Date"></asp:Label>
                </td>
                <td style="width: 196px">
                    <asp:TextBox ID="StartDateTextBox" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="StartDateTextBox" ErrorMessage="Enter Start Date">*</asp:RequiredFieldValidator>
                    <br />
                    <asp:CompareValidator ID="CompareValidator1" runat="server" 
                        ControlToValidate="StartDateTextBox" ErrorMessage="Enter Valid Date" 
                        Operator="DataTypeCheck" Type="Date">*</asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 152px; height: 48px;">
                    <asp:Label ID="DescriptionLabel" runat="server" Text="Description"></asp:Label>
                </td>
                <td style="width: 196px; height: 48px;">
                    <asp:TextBox ID="DescriptionTextBox" runat="server" TextMode="MultiLine" Height="87px" Width="254px"></asp:TextBox>
                </td>
                <td style="height: 48px">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="DescriptionTextBox" ErrorMessage="Enter Notice Description">*</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 152px">
                    <asp:Label ID="ExpirationDateLabel" runat="server" Text="Expiration Date"></asp:Label>
                </td>
                <td style="width: 196px">
                    <asp:TextBox ID="ExpDateTextBox" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="ExpDateTextBox" ErrorMessage="Enter Expiration Date">*</asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator2" runat="server" 
                        ControlToValidate="ExpDateTextBox" ErrorMessage="Enter Valid Date" 
                        Operator="DataTypeCheck" Type="Date">*</asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 152px; height: 23px;">
                    &nbsp;</td>
                <td style="height: 23px; width: 196px;">
                    <br />
                    <asp:Button ID="UpdateButton" runat="server" onclick="UpdateButton_Click" 
                        PostBackUrl="~/NoticeBoard/AddNewNotice.aspx" Text="Update" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="CancelButton" runat="server" onclick="CancelButton_Click" 
                        Text="Cancel" />
                </td>
                <td style="height: 23px">
                    &nbsp;</td>
            </tr>
        </table>

</asp:Content>
