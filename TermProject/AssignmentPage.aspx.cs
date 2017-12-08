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
    public partial class AssignmentPage : System.Web.UI.Page
    {
        string key = "zuhdi";
        protected void Page_Load(object sender, EventArgs e)
        {
            GetAssignmentFunc();
        }
        public bool AddAssignmentSvc(string key, Assignment assignment)
        {
            if (assignment != null && key == "zuhdi" && assignment.FileData != null) //Assignment with Files
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.CommandText = "TP_AddAssignment";
                objCommand.Parameters.AddWithValue("@Name", assignment.Name);
                objCommand.Parameters.AddWithValue("@DueDate", assignment.DueDate);
                objCommand.Parameters.AddWithValue("@MaximumGrade", assignment.MaximumGrade);
                objCommand.Parameters.AddWithValue("@FK_CourseID", assignment.FK_CourseID);
                objCommand.Parameters.AddWithValue("@Description", assignment.Description);
                objCommand.Parameters.AddWithValue("@fileTitle", assignment.FileTitle);
                objCommand.Parameters.AddWithValue("@fileData", assignment.FileData);
                objCommand.Parameters.AddWithValue("@fileType", assignment.FileType);
                objCommand.Parameters.AddWithValue("@fileLength", assignment.FileLength);

                objDB.DoUpdateUsingCmdObj(objCommand);
                objCommand.Parameters.Clear();
                lblUpload.Text = "file is uploaded";
                return true;
            }
            else if (assignment != null && key == "zuhdi") //Assignment without files
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.CommandText = "TP_AddAssignment";
                objCommand.Parameters.AddWithValue("@Name", assignment.Name);
                objCommand.Parameters.AddWithValue("@DueDate", assignment.DueDate);
                objCommand.Parameters.AddWithValue("@MaximumGrade", assignment.MaximumGrade);
                objCommand.Parameters.AddWithValue("@FK_CourseID", assignment.FK_CourseID);
                objCommand.Parameters.AddWithValue("@Description", assignment.Description);

                objDB.DoUpdateUsingCmdObj(objCommand);
                objCommand.Parameters.Clear();
                return true;
            }
            return false;
        }
        public void AddAssignmentFunc()
        {
            //BlackboardSvcPxy.Student student = new BlackboardSvcPxy.Student();
            Assignment assignment = new Assignment();

            assignment.Name = txtName.Text;
            assignment.Description = txtDescription.Text;
            assignment.DueDate = calendarDueDate.SelectedDate.ToShortDateString();
            assignment.FK_CourseID = 1; //Get Session[CourseID]
            assignment.MaximumGrade = int.Parse(txtMaxGrade.Text);


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
                } else {
                    lblUpload.Text = "Only docx, xlsx, pptx and pdf file formats supported.";
                }
            }


            if (AddAssignmentSvc(key, assignment))
            {
                lblSuccess.Text = "The assignment is created.";

            }
            else
            {
                lblSuccess.Text = "A problem occured. Data is not recorded";
            }
        }

        public DataTable GetAssignmentSvc(string key, Assignment assignment)
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
            Byte[] bytes = (Byte[])dt.Rows[0]["FileData"];
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
            assignment.FK_CourseID = 1; //Get Session[CourseID]

            if (GetAssignmentSvc(key, assignment) != null)
            {
                gvAssignment.DataSource = GetAssignmentSvc(key, assignment);
                gvAssignment.DataBind();
            }
            else
            {
                //lblInvalidKey.Text = "Please provide correct API Key";
                //lblInvalidKey.Visible = true;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            AddAssignmentFunc();
            GetAssignmentFunc();
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            int result = 0, fileSize;
            string fileExtension, fileType, fileName, fileTitle, strSQL;

            try
            {
                // Use the FileUpload control to get the uploaded data
                if (FileUpload1.HasFile)
                {
                    fileSize = FileUpload1.PostedFile.ContentLength;
                    //fileSize = Convert.ToInt32(FileUpload1.PostedFile.InputStream.Length);
                    byte[] fileData = new byte[fileSize];

                    FileUpload1.PostedFile.InputStream.Read(fileData, 0, fileSize);
                    fileName = FileUpload1.PostedFile.FileName;
                    fileType = FileUpload1.PostedFile.ContentType;



                    fileExtension = fileName.Substring(fileName.LastIndexOf("."));
                    fileExtension = fileExtension.ToLower();

                    if (fileExtension == ".docx" || fileExtension == ".xlsx" || fileExtension == ".pptx" || fileExtension == ".pdf")
                    {

                        // INSERT an file (BLOB) into the database using a stored procedure 'storeProductfile'
                        strSQL = "TP_AddAssignment";
                        objCommand.CommandText = strSQL;
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@Name", "test5");
                        objCommand.Parameters.AddWithValue("@DueDate", "test5");
                        objCommand.Parameters.AddWithValue("@MaximumGrade", 100);
                        objCommand.Parameters.AddWithValue("@FK_CourseID", 103);
                        objCommand.Parameters.AddWithValue("@Description", "test5");
                        //objCommand.Parameters.AddWithValue("@fileTitle", null);
                        //objCommand.Parameters.AddWithValue("@fileData", null);
                        //objCommand.Parameters.AddWithValue("@fileType", null);
                        //objCommand.Parameters.AddWithValue("@fileLength", null);
                        result = objDB.DoUpdateUsingCmdObj(objCommand);

                        lblSuccess.Text = "file was successully uploaded.";
                    }
                    else
                    {
                        lblSuccess.Text = "Only docx, xlsx, pptx and pdf file formats supported.";
                    }
                }
            }
            catch (Exception ex)
            {
                lblSuccess.Text = "Error ocurred: [" + ex.Message + "] cmd=" + result;
            }
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            Assignment assignment = new Assignment();
            assignment.FK_CourseID = 104; //Get Session[CourseID]
            download(GetAssignmentSvc(key, assignment));
        }

        public bool DeleteCourseSvc(Assignment assignment, string key)
        {
            if (assignment != null && key == "zuhdi")
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.CommandText = "TP_DeleteAssignment";
                objCommand.Parameters.AddWithValue("@assignmentID", assignment.ID);

                objDB.DoUpdateUsingCmdObj(objCommand);
                objCommand.Parameters.Clear();
                return true;
            }
            return false;
        }
        public void DeleteAssigmentFunc()
        {
            //BlackboardSvcPxy.Student student = new BlackboardSvcPxy.Student();
            Assignment assignment = new Assignment();
            assignment.FK_CourseID = int.Parse(lblAssgnID.Text);

            if (DeleteCourseSvc(assignment, key))
            {
                lblSuccess.Text = "Course is deleted";
            }
            else
            {
                lblSuccess.Text = "Error: Course is not deleted";
                //lblInvalidKey.Text = "Please provide correct API Key";
                //lblInvalidKey.Visible = true;
            }
        }


        protected void gvAssignment_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            if (e.CommandName == "Delete")
            {
                lblAssgnID.Text = gvAssignmentCB.DataKeys[rowIndex]["AssignmentID"].ToString();
                DeleteAssigmentFunc();
                GetAssignmentFunc();
            }
        }

        protected void gvAssignment_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void gvAssignmentStudent_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            if (e.CommandName == "Download")
            {
                lblAssgnID.Text = gvAssignmentStudent.DataKeys[rowIndex]["AssignmentID"].ToString();
                download(,row);
                GetAssignmentFunc();
            }
        }
    }
}