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
        BlackboardSvcPxy.BlackBoardService pxy = new BlackboardSvcPxy.BlackBoardService();
        string key = "zuhdi";
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                studentsInClass();
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

        public void studentsInClass()
        {
            DataSet myDS = populateStudentsInCourse(key, "2");//Session["CourseID].ToString());
            if (myDS.Tables[0].Rows.Count == 0)
            {
                lblStudentError.Visible = true;
                lblStudentError.Visible = false;
                lblStudentError.Text = "No students found.";
            }
            else
            {
                gvStudents.DataSource = myDS;
                gvStudents.DataBind();
            }
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

        public DataSet pop(string major)
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
        }

        protected void gvStudents_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            if (e.CommandName == "Email")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvStudents.Rows[index];
                string email = gvStudents.Rows[index].Cells[0].Text + "@school.edu";
                Session["StudentEmail"] = email;
                Response.Redirect("E-Mail.aspx");
            }
        }
        protected void gvStudents_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        public ArrayList packageStudents()
        {
            ArrayList packageStudents = new ArrayList();

            foreach (GridViewRow row in gvSearch.Rows)
            {
                CheckBox cb = (CheckBox)row.FindControl("chkSelect");
                if (cb != null && cb.Checked)
                {
                    GridViewRow index = gvStudents.SelectedRow;
                    int rowid = row.RowIndex;
                    string StudentID = gvSearch.DataKeys[rowid]["StudentID"].ToString();
                    packageStudents.Add(StudentID);
                }
            }
            return packageStudents;
        }

        public void addStudentsToCourse(ArrayList arrStudents, string courseID)
        {

            foreach (string stdID in arrStudents)
            {

                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();


                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.CommandText = "TP_AddStudentsToCourse";

                objCommand.Parameters.AddWithValue("@StudentID", Convert.ToInt32(stdID));
                objCommand.Parameters.AddWithValue("@CourseID", courseID);//Convert.ToInt32(Session["CourseID"]));

                objDB.DoUpdateUsingCmdObj(objCommand);
                objCommand.Parameters.Clear();
            }
        }

        public DataSet populateStudentsInCourse(string key, string courseID)
        {
            if (key == "zuhdi")
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();
                objCommand.Parameters.Clear();
                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.CommandText = "TP_PopulateStudentsInCourse";
                objCommand.Parameters.AddWithValue("@CourseID", Convert.ToInt32(courseID));
                //objCommand.Parameters.AddWithValue("@CourseID", courseID);
                DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);

                return myDataSet;
            }
            else
            {
                return null;
            }
        }

        public string arrayTest(ArrayList arrStudents)
        {

            string str = string.Empty;

            foreach (string strName in arrStudents)
            {
                str += strName + ", ";
            }
            return str;
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            addStudentsToCourse(packageStudents(), "2"); //Session["CourseID'].ToString());
        }

        protected void btnAddStudents_Click(object sender, EventArgs e)
        {
            btnAddStudents.Enabled = false;
            PanelAddStudents.Visible = true;
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            btnAddStudents.Enabled = true;
            PanelAddStudents.Visible = false;
        }

        protected void gvStudents_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ArrayList studentEmails = new ArrayList();

            foreach (GridViewRow row in gvStudents.Rows)
            {
                string emails = row.Cells[0].Text + "@school.edu;";
                studentEmails.Add(emails);
            }

            arrayTest(studentEmails);

            //Session["StudentEmails"] = studentEmails;
            //Response.Redirect("E-Mail.aspx");
        }

    }
}
