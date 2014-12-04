using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace Web
{
    public partial class ManageNotices : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AllNoticeGridView.DataSource = NoticeList.GetAllNotices();
            AllNoticeGridView.DataBind();
        }
        protected void ButtonAddNotice_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddNewNotice.aspx");
        }
       
        protected void AllNoticeGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            BLL.Notice.DeleteNotice(int.Parse(this.AllNoticeGridView.DataKeys[e.RowIndex]["NoticeId"].ToString()));
            Response.Redirect("ManageNotices.aspx");
        }

    }
}