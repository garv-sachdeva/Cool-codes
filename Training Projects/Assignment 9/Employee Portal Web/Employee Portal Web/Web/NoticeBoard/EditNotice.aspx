<%@ Page Title="" Language="C#" MasterPageFile="~/PortalTemplate.Master" AutoEventWireup="true"
    CodeBehind="EditNotice.aspx.cs" Inherits="Web.EditNotice" Theme="MainTheme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceHolder" runat="server">

    <h2 style="font-size: large; color: #FF6600">
        Edit Notice
        </h2>
        <div align="right">
            <asp:Button ID="BackLinkButton" runat="server" 
                PostBackUrl="~/NoticeBoard/ManageNotices.aspx" 
                onclick="BackLinkButton_Click" Text="Back" BorderStyle="Outset" Height="33px" Width="54px" />
        </div>
        <br />
        <br />
        <table style="width: 100%">
            <tr>
                <td style="width: 152px; height: 26px;">
                    Notice Id</td>
                <td style="height: 26px">
                    <asp:Label ID="NoticeIdLabel" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 152px">
                    <asp:Label ID="TitleLabel" runat="server" Text="Title"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TitleTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 152px">
                    <asp:Label ID="StartDateLabel" runat="server" Text="Start Date"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="StartDateTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 152px">
                    <asp:Label ID="DescriptionLabel" runat="server" Text="Description"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="DescriptionTextBox" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 152px">
                    <asp:Label ID="ExpirationDateLabel" runat="server" Text="Expiration Date"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="ExpDateTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 152px">
                    Posted By</td>
                <td>
                    <asp:Label ID="PostedByLabel" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 152px; height: 23px;">
                    </td>
                <td style="height: 23px">
                    <asp:Button ID="UpdateButton" runat="server" onclick="UpdateButton_Click" 
                        PostBackUrl="~/NoticeBoard/EditNotice.aspx" Text="Update" BorderStyle="Outset" />
                    &nbsp;
                    <asp:Button ID="CancelButton" runat="server" onclick="CancelButton_Click" 
                        Text="Reset" BorderStyle="Outset" />
                </td>
            </tr>
            </table>

</asp:Content>
