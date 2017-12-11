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
        string key = "zuhdi";

        protected void Page_Load(object sender, EventArgs e)
        {

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
                }
                else
                {
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

        protected void btnCreate_Click(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            AddAssignmentFunc();
            //GetAssignmentFunc();
        }
    }
}