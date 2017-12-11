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
    public partial class CourseAssignments : System.Web.UI.Page
    {
        BlackboardSvcPxy.BlackBoardService pxy = new BlackboardSvcPxy.BlackBoardService();
        string key = "zuhdi";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAssignmentFunc();
                lblName.Text = Session["CourseName"].ToString();
            }
        }

        //public DataTable GetAssignmentByIDSvc(string key, Assignment assignment)
        //{
        //    if (key == "zuhdi")
        //    {
        //        DBConnect objDB = new DBConnect();
        //        SqlCommand objCommand = new SqlCommand();

        //        objCommand.CommandType = System.Data.CommandType.StoredProcedure;
        //        objCommand.CommandText = "TP_GetAssignmentByID";
        //        objCommand.Parameters.AddWithValue("@ID", assignment.ID);

        //        DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);
        //        DataTable dt = myDataSet.Tables[0];
        //        objCommand.Parameters.Clear();
        //        return dt;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        protected void gvAssignmentStudent_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            if (e.CommandName == "Download")
            {
                lblStudentAssgnID.Text = gvAssignmentStudent.DataKeys[rowIndex]["AssignmentID"].ToString();
                BlackboardSvcPxy.Assignment assignment = new BlackboardSvcPxy.Assignment();
                assignment.ID = int.Parse(lblStudentAssgnID.Text);
                download(pxy.GetAssignmentByIDSvc(key, assignment));
                GetAssignmentFunc();
            }
            if (e.CommandName == "Submit")
            {
                lblStudentAssgnID.Text = gvAssignmentStudent.DataKeys[rowIndex]["AssignmentID"].ToString();
                Panel1.Visible = true;

            }
        }

        protected void gvAssignmentStudent_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnSubmitAssgn_Click(object sender, EventArgs e)
        {
            if(Session["User"].ToString() == "1")
            {
                SubmitGradeFunc();
            }
            else
            {
                lblUpload2.Text = "Only students can submit";
            }
        }

        public void SubmitGradeFunc()
        {
            //BlackboardSvcPxy.Student student = new BlackboardSvcPxy.Student();
            Grade grade = new Grade();

            grade.FK_StudentID = Convert.ToInt32(Session["StudentID"]);
            grade.FK_AssignmentID = int.Parse(lblStudentAssgnID.Text); //Get Session[CourseID]


            if (FileUpload2.HasFile)
            {
                int fileSize = FileUpload2.PostedFile.ContentLength;
                byte[] fileData = new byte[fileSize];

                FileUpload2.PostedFile.InputStream.Read(fileData, 0, fileSize);
                string fileName = FileUpload2.PostedFile.FileName;
                string fileType = FileUpload2.PostedFile.ContentType;
                string fileExtension = fileName.Substring(fileName.LastIndexOf("."));
                fileExtension = fileExtension.ToLower();
                if (fileExtension == ".docx" || fileExtension == ".xlsx" || fileExtension == ".pptx" || fileExtension == ".pdf")
                {
                    grade.FileTitle = fileName;
                    grade.FileData = fileData;
                    grade.FileType = fileType;
                    grade.FileLength = fileData.Length;
                }
                else
                {
                    lblUpload2.Text = "Only docx, xlsx, pptx and pdf file formats supported.";
                }
            }


            if (AddGradeSvc(key, grade))
            {
                lblUpload2.Text = "Assignment is submitted";

            }
            else
            {
                lblUpload2.Text = "Assignment failed to submit";
            }
        }
        public bool AddGradeSvc(string key, Grade grade)
        {
            if (grade != null && key == "zuhdi" && grade.FileData != null) //grade with Files
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.CommandText = "TP_Addgrade";
                objCommand.Parameters.AddWithValue("@FK_StudentID", grade.FK_StudentID);
                objCommand.Parameters.AddWithValue("@FK_AssignmentID", grade.FK_AssignmentID);
                objCommand.Parameters.AddWithValue("@fileTitle", grade.FileTitle);
                objCommand.Parameters.AddWithValue("@fileData", grade.FileData);
                objCommand.Parameters.AddWithValue("@fileType", grade.FileType);
                objCommand.Parameters.AddWithValue("@fileLength", grade.FileLength);

                objDB.DoUpdateUsingCmdObj(objCommand);
                objCommand.Parameters.Clear();

                return true;
            }
            else
            {
                return false;
            }
        }

        private void download(DataTable dt) //need to get DataTable Based on ID
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

        public void GetAssignmentFunc()
        {
            BlackboardSvcPxy.Assignment assignment = new BlackboardSvcPxy.Assignment();
            //Assignment assignment = new Assignment();
            assignment.FK_CourseID = Convert.ToInt32(Session["CourseID"]);

            if (pxy.GetAssignmentSvc(key, assignment) != null)
            {
                gvAssignmentStudent.DataSource = pxy.GetAssignmentSvc(key, assignment);
                gvAssignmentStudent.DataBind();
            }
            else
            {
                //lblInvalidKey.Text = "Please provide correct API Key";
                //lblInvalidKey.Visible = true;
            }
        }

        //public DataTable GetAssignmentSvc(string key, Assignment assignment)
        //{
        //    if (key == "zuhdi")
        //    {
        //        DBConnect objDB = new DBConnect();
        //        SqlCommand objCommand = new SqlCommand();

        //        objCommand.CommandType = System.Data.CommandType.StoredProcedure;
        //        objCommand.CommandText = "TP_GetAssignmentByCourseID";
        //        objCommand.Parameters.AddWithValue("@FK_CourseID", assignment.FK_CourseID);

        //        DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);
        //        DataTable dt = myDataSet.Tables[0];
        //        objCommand.Parameters.Clear();
        //        return dt;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
        public void sessionPass()
        {
            string user = Session["User"] as string;
            string courseID = Session["CourseID"] as string;
            string cbID = Session["cbID"] as string;
            string courseName = Session["CourseName"] as string;
            string StudentID = Session["StudentID"] as string;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            sessionPass();
            Response.Redirect("CBMain.aspx");
        }
    }
}