using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            if (pxy.GetCourseByTerm(ddlTerm.SelectedValue.ToString(),key) != null)
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

            course.CourseID = txtID.Text;
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

        protected void btnAddCourse_Click(object sender, EventArgs e)
        {
            addCourseMethod();
        }

        protected void gvCourses_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            if (e.CommandName == "Update")
            {
                ManageCourseFormDiv.Visible = true;
                txtIDUpdate.Text = gvCourses.Rows[rowIndex].Cells[0].Text;
                txtNameUpdate.Text = gvCourses.Rows[rowIndex].Cells[1].Text;
            }
            else if (e.CommandName == "Delete")
            {
                //AddEditForm.Visible = false;
                //balance.Visible = false;
                //btnAddCreditCard.Visible = false;
                //btnCreateCC.Visible = false;
                //btnUpdateCC.Visible = false;
                //Payment.Visible = true;
                //lblCCID.Text = gvCreditCard.Rows[rowIndex].Cells[0].Text.ToString();
                //txtCurrentBalance.Text = gvCreditCard.Rows[rowIndex].Cells[5].Text;

            }
            else if (e.CommandName == "Transaction")
            {
                //AddEditForm.Visible = false;
                //balance.Visible = false;
                //btnAddCreditCard.Visible = false;
                //btnCreateCC.Visible = false;
                //btnUpdateCC.Visible = false;
                //transactionsDiv.Visible = true;
                //GetCreditPurchaseByCCID(int.Parse(gvCreditCard.Rows[rowIndex].Cells[0].Text.ToString()));

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

        }
    }
}