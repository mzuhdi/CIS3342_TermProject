using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using Utilities;

namespace TermProject
{
    public partial class StudentGrades : System.Web.UI.Page
    {
        BlackboardSvcPxy.BlackBoardService pxy = new BlackboardSvcPxy.BlackBoardService();
        string key = "zuhdi";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblName.Text = Session["CourseName"].ToString();
            }

        }

        protected void rptContentPage_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        public void getGrades()
        {
            DataSet myDs = pxy.GetCourseGrades(Session["CourseID"].ToString(), Session["StudentID"].ToString());

            if (myDs.Tables[0].Rows.Count == 0)
            {
                lblError.Visible = true;
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Text = "No grades posted!";
            }
            else
            {
                rptGrades.DataSource = myDs;
                rptGrades.DataBind();
            }
        }

        //public DataSet GetCourseGrades(string courseID, string studentID)
        //{
        //    DBConnect objDB = new DBConnect();
        //    SqlCommand objCommand = new SqlCommand();

        //    objCommand.CommandType = System.Data.CommandType.StoredProcedure;
        //    objCommand.CommandText = "TP_GetStudentCourseGrades";

        //    objCommand.Parameters.AddWithValue("@StudentID", Convert.ToInt32(studentID));
        //    objCommand.Parameters.AddWithValue("@CourseID", Convert.ToInt32(courseID));

        //    DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);
        //    objCommand.Parameters.Clear();
        //    return myDataSet;
        //}

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            string user = Session["User"] as string;
            string studentID = Session["StudentID"] as string;
            Response.Redirect("StudentClasses.aspx");
        }
    }
}