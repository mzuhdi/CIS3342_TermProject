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
    public partial class ManageAssignments : System.Web.UI.Page
    {
        BlackboardSvcPxy.BlackBoardService pxy = new BlackboardSvcPxy.BlackBoardService();
        string key = "zuhdi";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAssignmentFunc();
                //GetGradeByAssgnIDFunc();
                ddlBind();
            }
        }

        //public bool AddAssignmentSvc(string key, Assignment assignment)
        //{
        //    if (assignment != null && key == "zuhdi" && assignment.FileData != null) //Assignment with Files
        //    {
        //        DBConnect objDB = new DBConnect();
        //        SqlCommand objCommand = new SqlCommand();

        //        objCommand.CommandType = System.Data.CommandType.StoredProcedure;
        //        objCommand.CommandText = "TP_AddAssignment";
        //        objCommand.Parameters.AddWithValue("@Name", assignment.Name);
        //        objCommand.Parameters.AddWithValue("@DueDate", assignment.DueDate);
        //        objCommand.Parameters.AddWithValue("@MaximumGrade", assignment.MaximumGrade);
        //        objCommand.Parameters.AddWithValue("@FK_CourseID", assignment.FK_CourseID);
        //        objCommand.Parameters.AddWithValue("@Description", assignment.Description);
        //        objCommand.Parameters.AddWithValue("@fileTitle", assignment.FileTitle);
        //        objCommand.Parameters.AddWithValue("@fileData", assignment.FileData);
        //        objCommand.Parameters.AddWithValue("@fileType", assignment.FileType);
        //        objCommand.Parameters.AddWithValue("@fileLength", assignment.FileLength);

        //        objDB.DoUpdateUsingCmdObj(objCommand);
        //        objCommand.Parameters.Clear();
        //        lblUpload.Text = "file is uploaded";
        //        return true;
        //    }
        //    else if (assignment != null && key == "zuhdi") //Assignment without files
        //    {
        //        DBConnect objDB = new DBConnect();
        //        SqlCommand objCommand = new SqlCommand();

        //        objCommand.CommandType = System.Data.CommandType.StoredProcedure;
        //        objCommand.CommandText = "TP_AddAssignment";
        //        objCommand.Parameters.AddWithValue("@Name", assignment.Name);
        //        objCommand.Parameters.AddWithValue("@DueDate", assignment.DueDate);
        //        objCommand.Parameters.AddWithValue("@MaximumGrade", assignment.MaximumGrade);
        //        objCommand.Parameters.AddWithValue("@FK_CourseID", assignment.FK_CourseID);
        //        objCommand.Parameters.AddWithValue("@Description", assignment.Description);

        //        objDB.DoUpdateUsingCmdObj(objCommand);
        //        objCommand.Parameters.Clear();
        //        return true;
        //    }
        //    return false;
        //}
        public void AddAssignmentFunc()
        {
            BlackboardSvcPxy.Assignment assignment = new BlackboardSvcPxy.Assignment();
            //Assignment assignment = new Assignment();

            assignment.Name = txtName.Text;
            assignment.Description = txtDescription.Text;
            assignment.DueDate = calendarDueDate.SelectedDate.ToShortDateString();
            assignment.FK_CourseID = Convert.ToInt32(Session["CourseID"]);
            assignment.MaximumGrade = int.Parse(txtGrade.Text);


            if (FileUpload1.HasFile)
            {
                int fileSize = FileUpload1.PostedFile.ContentLength;
                byte[] fileData = new byte[fileSize];

                FileUpload1.PostedFile.InputStream.Read(fileData, 0, fileSize);
                string fileName = FileUpload1.PostedFile.FileName;
                string fileType = FileUpload1.PostedFile.ContentType;
                string fileExtension = fileName.Substring(fileName.LastIndexOf("."));
                fileExtension = fileExtension.ToLower();
                if (fileExtension == ".docx" || fileExtension == ".xlsx" || fileExtension == ".pptx" || fileExtension == ".pdf")
                {
                    assignment.FileTitle = fileName;
                    assignment.FileData = fileData;
                    assignment.FileType = fileType;
                    assignment.FileLength = fileData.Length;
                }
                else
                {
                    lblUpload.Text = "Only docx, xlsx, pptx and pdf file formats supported.";
                }
            }


            if (pxy.AddAssignmentSvc(key, assignment))
            {
                lblSuccess.Text = "The assignment is created.";

            }
            else
            {
                lblSuccess.Text = "A problem occured. Data is not recorded";
            }
        }
        public DataTable GetAssignmentByCourseIDSvc(string key, Assignment assignment)
        {
            if (key == "zuhdi")
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.CommandText = "TP_GetAssignmentByCourseID";
                objCommand.Parameters.AddWithValue("@FK_CourseID", assignment.FK_CourseID);

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
            //BlackboardSvcPxy.Student student = new BlackboardSvcPxy.Student();
            Assignment assignment = new Assignment();
            assignment.FK_CourseID = Convert.ToInt32(Session["CourseID"]);

            if (GetAssignmentByCourseIDSvc(key, assignment) != null)
            {
                gvAssignmentCB.DataSource = GetAssignmentByCourseIDSvc(key, assignment);
                gvAssignmentCB.DataBind();
            }
            else
            {
                //lblInvalidKey.Text = "Please provide correct API Key";
                //lblInvalidKey.Visible = true;
            }
        }
        protected void btnCreate_Click(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            AddAssignmentFunc();
            GetAssignmentFunc();
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
        public void GetGradeByAssgnIDFunc(string ID)
        {
            //BlackboardSvcPxy.Student student = new BlackboardSvcPxy.Student();
            Grade grade = new Grade();
            grade.FK_AssignmentID = Convert.ToInt32(ID);

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


        protected void gvAssignmentCB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (DropDownList1.SelectedIndex != 0)
            {
                GetGradeByAssgnIDFunc(DropDownList1.SelectedValue);
            }
        }

        public void ddlBind()
        {
            Assignment assignment = new Assignment();
            assignment.FK_CourseID = Convert.ToInt32(Session["CourseID"]);
            DropDownList1.DataSource = GetAssignmentByCourseIDSvc(key, assignment);
            DropDownList1.DataValueField = "AssignmentID";
            DropDownList1.DataTextField = "Name";
            DropDownList1.DataBind();
            ListItem li = new ListItem();
            li.Text = "--Assignments--";
            li.Value = "-1";
            DropDownList1.Items.Insert(0, li);
            DropDownList1.SelectedIndex = 0;

        }

        protected void gvAssignment_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //int rowIndex = int.Parse(e.CommandArgument.ToString());
            //if (e.CommandName == "Delete")
            //{
            //    lblAssgnID.Text = gvAssignmentCB.DataKeys[rowIndex]["AssignmentID"].ToString();
            //    DeleteAssigmentFunc();
            //    GetAssignmentFunc();
            //}
        }

        protected void gvAssignment_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void btnSubmit0_Click1(object sender, EventArgs e)
        {
            submitGradeFunc();
            GetGradeByAssgnIDFunc(DropDownList1.SelectedValue);
        }
    }
}