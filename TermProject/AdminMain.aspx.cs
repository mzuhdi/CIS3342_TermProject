using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using Utilities;
using TermProjectClassLibrary;

namespace TermProject
{
    public partial class AdminMain : System.Web.UI.Page
    {
        BlackboardSvcPxy.BlackBoardService pxy = new BlackboardSvcPxy.BlackBoardService();
        string key = "zuhdi";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["AdminID"] != null)
                {
                    lblSuccess.Text = "Login Successful";
                    Admin.Visible = true;
                    getTerm();
                    GetCourseBuilder();
                }
                else
                {
                    lblSuccess.Text = "Access Denied";
                }
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
        //WebMehod
        public DataSet WebGetCourseBuilder(string key)
        {
            if (key == "zuhdi")
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.CommandText = "TP_GetCourseBuilder";

                DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);
                objCommand.Parameters.Clear();
                return myDataSet;
            }
            else
            {
                return null;
            }
        }

        public void GetCourseBuilder()
        {
            if (WebGetCourseBuilder(key) != null) //if (pxy.GetCourseBuilder(key) != null)
            {
                ddlCB.DataSource = WebGetCourseBuilder(key);
                ddlCB.DataValueField = "CBID";
                ddlCB.DataTextField = "Username";
                ddlCB.DataBind();
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
            course.FK_CBID = int.Parse(ddlCB.SelectedValue.ToString());


            if (pxy.addCourse(course, key))
            {
                lblCreated.Text = "The course is created.";

            }
            else
            {
                lblCreated.Text = "A problem occured. Data is not recorded";
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

        protected void btnAddCourse_Click(object sender, EventArgs e)
        {
            addCourseMethod();
            GetCourseByTerm();
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            GetCourseByTerm();
            addCourseDiv.Visible = true;
            ManageCourseDiv.Visible = true;
        }
        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}