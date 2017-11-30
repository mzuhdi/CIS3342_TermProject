using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TermProjectClassLibrary;


namespace TermProject
{
    public partial class AddCourse : System.Web.UI.Page
    {
        BlackboardSvcPxy.BlackBoardService pxy = new BlackboardSvcPxy.BlackBoardService();
        string key = "zuhdi";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getTerm();
            }
        }
        public void getTerm()
        {
            if (pxy.GetUserType(key) != null)
            {
                ddlTerm.DataSource = pxy.GetTerm(key);
                ddlTerm.DataValueField = "TermID";
                ddlTerm.DataTextField = "TermName";
                ddlTerm.DataBind();
            }
            else
            {
                lblInvalidKey.Text = "Please provide correct API Key";
                lblInvalidKey.Visible = true;
            }
        }
        public void GetCourseByTerm()
        {
            if (pxy.GetCourseByTerm(ddlTerm.SelectedValue.ToString(), key) != null)
            {
                gvCourses.DataSource = pxy.GetCourseByTerm(ddlTerm.SelectedValue.ToString(), key);
                gvCourses.DataBind();
            }
            else
            {
                lblInvalidKey.Text = "Please provide correct API Key";
                lblInvalidKey.Visible = true;
            }
        }

        public void addCourseMethod()
        {
            BlackboardSvcPxy.Course course = new BlackboardSvcPxy.Course();

            course.CourseCode = txtCCode.Text;
            course.Name = txtName.Text;
            course.FK_TermID = ddlTerm.SelectedValue.ToString();
            course.FK_CBID = 1; // will get CBID using session


            if (pxy.addCourse(course, key))
            {
                lblSuccess.Text = "The course is created.";

            }
            else
            {
                lblSuccess.Text = "A problem occured. Data is not recorded";
            }
        }

        public void UpdateCourse()
        {
            BlackboardSvcPxy.Course course = new BlackboardSvcPxy.Course();

            course.CourseID = lblCourseID.Text;
            course.CourseCode = txtCCodeUpdate.Text;
            course.Name = txtNameUpdate.Text;
            course.FK_TermID = ddlTerm.SelectedValue.ToString();
            course.FK_CBID = 1; // will get CBID using session

            if (pxy.UpdateCourse(course, key))
            {
                lblSuccess.Text = "The course is updated.";
            }
            else
            {
                lblSuccess.Text = "A problem occured. Data is not recorded";
            }
        }


        protected void btnAddCourse_Click(object sender, EventArgs e)
        {
            addCourseMethod();
            GetCourseByTerm();
        }

        protected void gvCourses_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            if (e.CommandName == "Update")
            {
                ManageCourseFormDiv.Visible = true;
                lblCourseID.Text = (string)gvCourses.DataKeys[rowIndex]["CourseID"];
                txtCCodeUpdate.Text = gvCourses.Rows[rowIndex].Cells[1].Text;
                txtNameUpdate.Text = gvCourses.Rows[rowIndex].Cells[2].Text;
            }
            else if (e.CommandName == "Delete")
            {

                BlackboardSvcPxy.BlackBoardService pxy = new BlackboardSvcPxy.BlackBoardService();
                int rowInd = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvCourses.Rows[rowIndex];
                if (pxy.DeleteCourse(Convert.ToString(gvCourses.DataKeys[rowInd]["CourseID"]), key))

                {
                    lblSuccess.Text = "The course is deleted.";
                }
                else
                {
                    lblSuccess.Text = "A problem occured. Data is not recorded";
                }

                GetCourseByTerm();


            }
            else if (e.CommandName == "Manage Students")
            {
             
                int rowInd = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvCourses.Rows[rowIndex];
                lblCourseID.Text = Convert.ToString(gvCourses.DataKeys[rowInd]["CourseID"]);
                Session["CourseID"] = lblCourseID.Text;
                Response.Redirect("ManageStudents.aspx");

            }

        }

        protected void gvCourses_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            GetCourseByTerm();
            addCourseDiv.Visible = true;
            ManageCourseDiv.Visible = true;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateCourse();
            GetCourseByTerm();
        }

        protected void gvCourses_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}