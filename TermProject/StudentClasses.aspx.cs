using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using Utilities;

namespace TermProject
{
    public partial class StudentClasses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindName();
                BindData();
            }
        }
        
        public DataSet findNameByStudentID(string studentID)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.Parameters.Clear();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "findNameByStudentID";

            objCommand.Parameters.AddWithValue("@StudentID", Convert.ToInt32(studentID));

            return objDB.GetDataSetUsingCmdObj(objCommand);
        }

        public void BindName()
        {
            DataSet myDs = findNameByStudentID(Session["StudentID"].ToString());
            lblName.Text = myDs.Tables[0].Rows[0]["FirstName"].ToString() +" "+ myDs.Tables[0].Rows[0]["LastName"].ToString();
        }

        public void BindData()
        {
            if (Session["User"].ToString() == "1")
            {
                DataSet myDs = populateStudent(Session["StudentID"].ToString());

                if (myDs.Tables[0].Rows.Count == 0)
                {
                    lblError.Visible = true;
                    lblError.Text = "No classes found";
                }
                else
                {
                    rptClasses.DataSource = myDs;
                    rptClasses.DataBind();
                }

            }
        }


        public DataSet populateStudent(string studentID)
        {

            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.Parameters.Clear();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_RetrieveStudentClasses";

            objCommand.Parameters.AddWithValue("@StudentID", Convert.ToInt32(studentID));

            return objDB.GetDataSetUsingCmdObj(objCommand);
        }

        protected void rptClasses_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "view")
            {
                int rowIndex = e.Item.ItemIndex;
                Label myLabel = (Label)rptClasses.Items[rowIndex].FindControl("lblCourseID");
                Label myLabel2 = (Label)rptClasses.Items[rowIndex].FindControl("lblCourse");
                String courseID = myLabel.Text;
                String courseName = myLabel.Text;

                string user = Session["User"] as string;
                string studentID = Session["StudentID"] as string;
                Session["CourseID"] = courseID;
                Session["CourseName"] = courseName;
                Response.Redirect("CBMain.aspx");

                //Data.Contacts.RemoveAt(e.Item.ItemIndex);
            }
            if (e.CommandName == "grades")
            {
                int rowIndex = e.Item.ItemIndex;
                Label myLabel = (Label)rptClasses.Items[rowIndex].FindControl("lblCourseID");
                Label myLabel2 = (Label)rptClasses.Items[rowIndex].FindControl("lblCourse");
                String courseID = myLabel.Text;
                String courseName = myLabel.Text;

                string user = Session["User"] as string;
                string studentID = Session["StudentID"] as string;
                Session["CourseID"] = courseID;
                Session["CourseName"] = courseName;
                Response.Redirect("StudentGrades.aspx");

                //Data.Contacts.RemoveAt(e.Item.ItemIndex);
            }
        }

        protected void btnSignOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}