using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TermProject
{
    public partial class Registration : System.Web.UI.Page
    {
        BlackboardSvcPxy.BlackBoardService pxy = new BlackboardSvcPxy.BlackBoardService();
        string key = "zuhdi";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getUserType();
                getDepartment();
            }
        }
        public void AddStudent()
        {
            BlackboardSvcPxy.Student student = new BlackboardSvcPxy.Student();

            student.FirstName = txtSFirstName.Text;
            student.LastName = txtSLastName.Text;
            student.Major = txtMajor.Text;
            student.Username = txtSUsername.Text;
            student.Password = txtSPassword.Text;


            if (pxy.addStudent(student, key))
            {
                lblSuccess.Text = "The student is created.";
                
            }
            else
            {
                lblSuccess.Text = "A problem occured. Data is not recorded";
            }
        }
        public void AddCourseBuilder()
        {
            BlackboardSvcPxy.CourseBuilder cb = new BlackboardSvcPxy.CourseBuilder();

            cb.FirstName = txtCFirstName.Text;
            cb.LastName = txtCLastName.Text;
            cb.FK_DeptID = int.Parse(ddlDepartment.SelectedValue.ToString());
            cb.Username = txtCUserName.Text;
            cb.Password = txtCPassword.Text;


            if (pxy.addCourseBuilder(cb, key))
            {
                lblSuccess.Text = "The course builder is created.";

            }
            else
            {
                lblSuccess.Text = "A problem occured. Data is not recorded";
            }
        }
        public void getUserType()
        {
            if (pxy.GetUserType(key) != null)
            {
                ddlUserType.DataSource = pxy.GetUserType(key);
                ddlUserType.DataValueField = "UserTypeID";
                ddlUserType.DataTextField = "Name";
                ddlUserType.DataBind();
            }
            else
            {
                lblInvalidKey.Text = "Please provide correct API Key";
                lblInvalidKey.Visible = true;
            }
        }
        public void getDepartment()
        {
            if (pxy.GetDepartment(key) != null)
            {
                ddlDepartment.DataSource = pxy.GetDepartment(key);
                ddlDepartment.DataValueField = "DepartmentID";
                ddlDepartment.DataTextField = "Name";
                ddlDepartment.DataBind();
            }
            else
            {
                lblInvalidKey.Text = "Please provide correct API Key";
                lblInvalidKey.Visible = true;
            }
        }

        protected void ddlUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUserType.SelectedValue.ToString() == "1")
            {
                studentRegister.Visible = true;
                courseBuilderRegister.Visible = false;
                adminRegister.Visible = false;
            }
            if (ddlUserType.SelectedValue.ToString() == "2")
            {
                studentRegister.Visible = false;
                courseBuilderRegister.Visible = true;
                adminRegister.Visible = false;
            }
            if (ddlUserType.SelectedValue.ToString() == "3")
            {
                studentRegister.Visible = false;
                courseBuilderRegister.Visible = false;
                adminRegister.Visible = true;
            }
        }

        protected void btnStudentSubmit_Click(object sender, EventArgs e)
        {
            AddStudent();
        }

        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnCBSubmit_Click(object sender, EventArgs e)
        {
            AddCourseBuilder();
        }
    }
}