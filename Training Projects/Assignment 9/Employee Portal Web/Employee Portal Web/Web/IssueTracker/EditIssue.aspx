<%@ Page Title="" Language="C#" MasterPageFile="~/PortalTemplate.Master" AutoEventWireup="true" CodeBehind="EditIssue.aspx.cs" Inherits="Web.EditIssue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceHolder" runat="server">

    

    <table style="width: 100%">
        <tr>
            <td style="width: 82px; text-align: right; color: #000000">
                Issue Id</td>
            <td>
                <asp:Label ID="LabelIssuecode" runat="server" Text="Issue Code"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 82px; text-align: right">
                Title</td>
            <td>
                <asp:TextBox ID="TextBoxTitle" runat="server" 
                    ontextchanged="TextBoxTitle_TextChanged"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 82px; text-align: right">
                Description</td>
            <td>
                <asp:TextBox ID="Description" runat="server" TextMode="MultiLine" 
                    ontextchanged="Description_TextChanged" Height="83px" Width="270px"></asp:TextBox>
                </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 82px; text-align: right">
                Priority</td>
            <td>
                <asp:DropDownList ID="DropDownListPriority" runat="server" 
                    AppendDataBoundItems="True" 
                    onselectedindexchanged="DropDownListPriority_SelectedIndexChanged" >
                <asp:ListItem Value="" Text="Select Priority" />
                <asp:ListItem Value="1" Text="Normal" />
                <asp:ListItem Value = "2" Text ="Urgent" />
                <asp:ListItem Value="3" Text = "Immediate" />
                </asp:DropDownList>
            
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 82px; text-align: right">
                Comments</td>
            <td>
                <asp:TextBox ID="TextBoxComments" runat="server" 
                    ontextchanged="TextBoxComments_TextChanged" Height="70px" TextMode="MultiLine" Width="267px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 82px; text-align: right; height: 38px;">
                </td>
            <td style="height: 38px">
                <asp:Button ID="Button1" runat="server" Text="Submit" onclick="Button1_Click" />
&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button2" runat="server" Text="Cancel" OnClick="Button2_Click" />
            </td>
            <td style="height: 38px">
                </td>
            <td style="height: 38px">
                </td>
        </tr>
        <tr>
            <td style="width: 82px; text-align: right">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>


</asp:Content>
