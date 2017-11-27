using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Utilities;
using System.Data.SqlClient;
using System.Collections;

namespace TermProject
{
    public partial class ManageStudents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                DBConnect objDB = new DBConnect();
                String strSQL = "SELECT DISTINCT Major FROM TP_Student";
                ddlMajor.DataSource = objDB.GetDataSet(strSQL);
                ddlMajor.DataTextField = "Major";
                ddlMajor.DataValueField = "Major";
                ddlMajor.DataBind();

                popStudents();
            }
        }

        public void popStudents()
        {
            //DataSet myDS = populateByMajor(major);
            //gvSearch.DataSource =  myDS;
            //gvSearch.DataBind();
            DBConnect objDB = new DBConnect();

            string strSQL = "SELECT * FROM dbo.TP_Student";
            gvSearch.DataSource = objDB.GetDataSet(strSQL);
            gvSearch.DataBind();

        }

        public void popByMajor(string major)
        {
            DataSet myDS = populateByMajor(major); // pxy.searchAccounts(txtSearch.Text);
            gvSearch.DataSource = myDS;
            gvSearch.DataBind();
        }

        public DataSet populateByMajor(string major)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            //objCommand.Parameters.Clear();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "PopulateStudentsInCourse";     // identify the name of the stored procedure to execute
            //SqlParameter inputParameter = new SqlParameter("@major", major);
            //inputParameter.Direction = ParameterDirection.Input;
            //inputParameter.SqlDbType = SqlDbType.NVarChar;
            objCommand.Parameters.AddWithValue("@CourseID", 1);
            //objCommand.Parameters.Add(inputParameter);
            return objDB.GetDataSetUsingCmdObj(objCommand);
        }

        public DataSet populateStudentsInCourse(string major)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            //objCommand.Parameters.Clear();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_SearchByMajor";     // identify the name of the stored procedure to execute
            //SqlParameter inputParameter = new SqlParameter("@major", major);
            //inputParameter.Direction = ParameterDirection.Input;
            //inputParameter.SqlDbType = SqlDbType.NVarChar;
            objCommand.Parameters.AddWithValue("@major", major);
            //objCommand.Parameters.Add(inputParameter);
            return objDB.GetDataSetUsingCmdObj(objCommand);
        }

        protected void ddlMajor_SelectedIndexChanged(object sender, EventArgs e)
        {
            populateByMajor(ddlMajor.SelectedValue.ToString());
        }

        public List<string> packageStudents()
        {
            List<string> packageStudents = new List<string>();

            //int count = 0;
            //for (int row = 0; row < gvSearch.Rows.Count; row++)
            //{
            //    CheckBox cbox;
            //    cbox = (CheckBox)gvSearch.Rows[row].FindControl("chkSelect");
            //    if (cbox.Checked)
            //    {
            //        string studentID = "";

            //        studentID = gvSearch.DataKeys[0]["StudentID"].ToString();
            //        packageStudents.Add(studentID);

            //    }
            //}
            //return packageStudents;
            foreach (GridViewRow row in gvSearch.Rows)
            {
                // Access the CheckBox
                CheckBox cb = (CheckBox)row.FindControl("chkSelect");
                if (cb != null && cb.Checked)
                {
                    string StudentID = gvSearch.DataKeys[0]["StudentID"].ToString();
                    packageStudents.Add(StudentID);
                }
            }
            return packageStudents;
        }

        public void addStudentsToCourse(ArrayList arrStudents, string courseID)
        {
            for (int i = 0; i < arrStudents.Count; i++)
            {

                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();


                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_AddStudentsToCourse";

                objCommand.Parameters.AddWithValue("@StudentID", Convert.ToInt32(arrStudents[i]));
                objCommand.Parameters.AddWithValue("@CourseID", courseID);//Convert.ToInt32(Session["CourseID"]));

                objDB.DoUpdateUsingCmdObj(objCommand);
                objCommand.Parameters.Clear();
            }
        }

        public string arrayTest(List<string> arrStudents)
        {
            string ID = "";
            for (int i = 0; i < arrStudents.Count; i++)
            {
                string Student = "";

                ID = arrStudents[i].ToString() + ", ";
            }
            return ID;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            // addStudentsToCourse(packageStudents(), "1");
            lblSearchError.Text = arrayTest(packageStudents());
        }
    }
}