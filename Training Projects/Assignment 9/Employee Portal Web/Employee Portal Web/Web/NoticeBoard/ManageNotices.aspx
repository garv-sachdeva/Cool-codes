<%@ Page Title="" Language="C#" MasterPageFile="~/PortalTemplate.Master" AutoEventWireup="true"
     CodeBehind="ManageNotices.aspx.cs" Inherits="Web.ManageNotices" Theme="MainTheme" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainContentPlaceHolder" runat="server">

    
        <h2>
            Manage Notices
        </h2>
        <asp:Button ID="AddNewNoticeButton" runat="server" Text="Add Notice" OnClick="ButtonAddNotice_Click" />            
            <br/>
            <br/>
          <asp:GridView ID="AllNoticeGridView" runat="server" AllowPaging="True" 
            DataKeyNames="NoticeId" OnRowDeleting ="AllNoticeGridView_RowDeleting" 
            AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" style="margin-right: 26px" Width="747px">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="NoticeId" HeaderText="NoticeId" />
                <asp:BoundField DataField="Title" HeaderText="Title"/>
                <asp:BoundField DataField="StartDate" HeaderText="StartDate" DataFormatString="{0:dd-MMM-yyyy}"/>
                <asp:BoundField DataField="ExpirationDate" HeaderText="ExpirationDate" DataFormatString="{0:dd-MMM-yyyy}" />
                <asp:BoundField DataField="PostedById" HeaderText="PostedBy"  />
                <asp:HyperLinkField HeaderText="  Edit" DataNavigateUrlFields ="NoticeId" DataNavigateUrlFormatString="~/NoticeBoard/EditNotice.aspx?NoticeId={0}" Text="Edit" />
                <asp:CommandField HeaderText="  Delete" ShowDeleteButton="True" ButtonType="Link" />
            </Columns>
           
              <EditRowStyle BackColor="#2461BF" />
              <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
              <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
              <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
              <RowStyle BackColor="#EFF3FB"  HorizontalAlign="Center" />
              <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
              <SortedAscendingCellStyle BackColor="#F5F7FB" />
              <SortedAscendingHeaderStyle BackColor="#6D95E1" />
              <SortedDescendingCellStyle BackColor="#E9EBEF" />
              <SortedDescendingHeaderStyle BackColor="#4870BE" />
           
        </asp:GridView>

</asp:Content>
