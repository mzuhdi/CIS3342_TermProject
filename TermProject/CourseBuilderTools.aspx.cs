using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TermProject
{
    public partial class CourseBuiderTools : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblName.Text = Session["CourseName"].ToString();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            sessionPass();
            Response.Redirect("ManageContentPages.aspx");
        }

        public void sessionPass()
        {
            string user = Session["User"] as string;
            string courseID = Session["CourseID"] as string;
            string cbID = Session["cbID"] as string;
            string courseName = Session["CourseName"] as string;
        }

        protected void btnManageAssignments_Click(object sender, EventArgs e)
        {
            sessionPass();
            Response.Redirect("ManageAssignmentPage.aspx");

        }

        protected void btnManageAnnouncements_Click(object sender, EventArgs e)
        {
            sessionPass();
            Response.Redirect("ManageAnnouncement.aspx");
        }

        protected void btnManageStudents_Click(object sender, EventArgs e)
        {
            sessionPass();
            Response.Redirect("ManageStudents.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            sessionPass();
            Response.Redirect("CBMain.aspx");
        }
    }
}