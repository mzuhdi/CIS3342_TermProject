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

        

        public void studentsInClass()
        {
            BlackboardSvcPxy.BlackBoardService pxy = new BlackboardSvcPxy.BlackBoardService();
            DataSet myDS = pxy.populateStudentsInCourse(key, Session["CourseID"].ToString());
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
                objCommand.Parameters.AddWithValue("@CourseID", Convert.ToInt32(Session["CourseID"]));

                objDB.DoUpdateUsingCmdObj(objCommand);
                objCommand.Parameters.Clear();
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

        public void popStudents()
        {
            DBConnect objDB = new DBConnect();

            string strSQL = "SELECT * FROM dbo.TP_Student";
            gvSearch.DataSource = objDB.GetDataSet(strSQL);
            gvSearch.DataBind();

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            BlackboardSvcPxy.BlackBoardService pxy = new BlackboardSvcPxy.BlackBoardService();
            addStudentsToCourse(packageStudents(), Session["CourseID"].ToString());
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
            //ArrayList studentEmails = new ArrayList();

            //foreach (GridViewRow row in gvStudents.Rows)
            //{
                
            //    string email = gvStudents.Rows.ToString();
            //    studentEmails.Add(email);
            //}

            //arrayTest(studentEmails);

            

            //String[] values = new String[this.gvStudents.Rows.Count];
            ArrayList valuess = new ArrayList(gvStudents.Rows.Count); 
            //for (int index = 0; index < gvStudents.Rows.Count; index++)
            //{
            //    valuess.Add(gvStudents.Rows[index].Cells[0].Text);
            //}
            //Session["StudentEmails"] = valuess;
            Response.Redirect("E-Mail.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("AddCourse.aspx");
        }
    }
}
