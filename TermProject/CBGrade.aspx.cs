using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Utilities;
using TermProjectClassLibrary;
using System.Data;
using System.Data.SqlClient;

namespace TermProject
{
    public partial class CBGrade : System.Web.UI.Page
    {
        string key = "zuhdi";
        protected void Page_Load(object sender, EventArgs e)
        {
            GetAssignmentFunc();
            GetGradeByAssgnIDFunc();
        }
        public DataTable GetAssignmentSvc(string key, Assignment assignment)
        {
            if (key == "zuhdi")
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.CommandText = "TP_GetAssignmentByID";
                objCommand.Parameters.AddWithValue("@ID", assignment.ID);

                DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);
                DataTable dt = myDataSet.Tables[0];
                objCommand.Parameters.Clear();
                return dt;
            }
            else
            {
                return null;
            }
        }
        public void GetAssignmentFunc()
        {
            //BlackboardSvcPxy.Student student = new BlackboardSvcPxy.Student();
            Assignment assignment = new Assignment();
            assignment.ID = 13; //Get Session[AssignmentID]

            if (GetAssignmentSvc(key, assignment) != null)
            {
                gvAssignmentCB.DataSource = GetAssignmentSvc(key, assignment);
                gvAssignmentCB.DataBind();
            }
            else
            {
                //lblInvalidKey.Text = "Please provide correct API Key";
                //lblInvalidKey.Visible = true;
            }
        }
        public DataTable GetGradeByAssgnIDSvc(string key, Grade grade)
        {
            if (key == "zuhdi")
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.CommandText = "TP_GetGradeByAssgnID";
                objCommand.Parameters.AddWithValue("@FK_AssignmentID", grade.FK_AssignmentID);

                DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);
                DataTable dt = myDataSet.Tables[0];
                objCommand.Parameters.Clear();
                return dt;
            }
            else
            {
                return null;
            }
        }
        public void GetGradeByAssgnIDFunc()
        {
            //BlackboardSvcPxy.Student student = new BlackboardSvcPxy.Student();
            Grade grade = new Grade();
            grade.FK_AssignmentID = 13; //Get Session[AssignmentID]

            if (GetGradeByAssgnIDSvc(key, grade) != null)
            {
                gvCBGrade.DataSource = GetGradeByAssgnIDSvc(key, grade);
                gvCBGrade.DataBind();
            }
            else
            {
                //lblInvalidKey.Text = "Please provide correct API Key";
                //lblInvalidKey.Visible = true;
            }
        }

        public DataTable GetGradeByIDSvc(string key, Grade grade)
        {
            if (key == "zuhdi")
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.CommandText = "TP_GetGradeByID";
                objCommand.Parameters.AddWithValue("@ID", grade.ID);

                DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);
                DataTable dt = myDataSet.Tables[0];
                objCommand.Parameters.Clear();
                return dt;
            }
            else
            {
                return null;
            }
        }

        public void submitGradeFunc()
        {
            //BlackboardSvcPxy.Student student = new BlackboardSvcPxy.Student();
            Grade grade = new Grade();

            grade.ID = int.Parse(lblGradeID.Text);
            grade.theGrade = int.Parse(txtGrade.Text);


            if (submitGradeSvc(key, grade))
            {
                lblSuccess.Text = "The grade is stored.";

            }
            else
            {
                lblSuccess.Text = "A problem occured. Data is not recorded";
            }
        }

        public bool submitGradeSvc(string key, Grade grade)
        {
            if (grade != null && key == "zuhdi") 
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.CommandText = "TP_UpdateGrade";
                objCommand.Parameters.AddWithValue("@ID", grade.ID);
                objCommand.Parameters.AddWithValue("@Grade", grade.theGrade);

                objDB.DoUpdateUsingCmdObj(objCommand);
                objCommand.Parameters.Clear();
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void gvCBGrade_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            if (e.CommandName == "Download")
            {
                lblGradeID.Text = gvCBGrade.DataKeys[rowIndex]["GradeID"].ToString();
                Grade grade = new Grade();
                grade.ID = int.Parse(lblGradeID.Text);
                download(GetGradeByIDSvc(key, grade));
                GetAssignmentFunc();
            }
            if (e.CommandName == "Grade")
            {
                lblGradeID.Text = gvCBGrade.DataKeys[rowIndex]["GradeID"].ToString();
                GradeForm.Visible = true;
            }
        }
        private void download(DataTable dt)
        {
            byte[] bytes = (byte[])dt.Rows[0]["FileData"];
            Response.Buffer = true;
            Response.Charset = "";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.ContentType = dt.Rows[0]["FileType"].ToString();
            Response.AddHeader("content-disposition", "attachment;filename="
            + dt.Rows[0]["FileTitle"].ToString());
            Response.BinaryWrite(bytes);
            //Response.OutputStream.Write(bytes, 0, bytes.Length);
            Response.Flush();
            Response.End();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            submitGradeFunc();
            GetGradeByAssgnIDFunc();

        }
    }
}