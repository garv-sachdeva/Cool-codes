using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace Web
{
    public partial class EditNotice : System.Web.UI.Page
    {

        int employeeId;
        protected void Page_Load(object sender, EventArgs e)
        {
            EPPrincipal principal = Session["CurrentPrincipal"] as EPPrincipal;
            EPIdentity identity = principal.Identity as EPIdentity;
            employeeId = identity.EmployeeId;

            Notice noticeData = new Notice();
            if (!IsPostBack)
            {
                noticeData = Notice.GetNotice(Int32.Parse(Request.QueryString["NoticeId"]));

                NoticeIdLabel.Text = Convert.ToString(noticeData.NoticeId);
                TitleTextBox.Text = noticeData.Title;
                StartDateTextBox.Text = Convert.ToString(noticeData.StartDate);
                PostedByLabel.Text = "ADMIN";               //Convert.ToString(noticeData.PostedByName);
                ExpDateTextBox.Text = Convert.ToString(noticeData.ExpirationDate);
                DescriptionTextBox.Text = noticeData.Description;
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            TitleTextBox.Text = "";
            DescriptionTextBox.Text = "";
            StartDateTextBox.Text = "";
            ExpDateTextBox.Text = "";
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            Notice notice = new Notice();
            notice.NoticeId = int.Parse(NoticeIdLabel.Text);
            notice.Title = TitleTextBox.Text;
            notice.Description = DescriptionTextBox.Text;
            notice.StartDate = DateTime.Parse(StartDateTextBox.Text);
            notice.ExpirationDate = DateTime.Parse(ExpDateTextBox.Text);
            notice.PostedById = employeeId;
            notice.Save();
            Response.Redirect("ManageNotices.aspx");
        }

        protected void BackLinkButton_Click(object sender, EventArgs e)
        {
            Server.TransferRequest("~/ManageNotices.aspx");
            //Response.Redirect("ManageNotices.aspx");
        }
    }
}