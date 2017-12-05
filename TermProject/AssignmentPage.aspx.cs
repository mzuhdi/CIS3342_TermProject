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

        }
        public bool AddAssignmentSvc(string key, Assignment assignment)
        {
            if (assignment != null && key == "zuhdi")
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

                DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);
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
            assignment.DueDate = calendarDueDate.SelectedDate;
            assignment.FK_CourseID = 1; //Get Session[CourseID]
            assignment.MaximumGrade = int.Parse(txtMaxGrade.Text);


            if (AddAssignmentSvc(key, assignment))
            {
                lblSuccess.Text = "The student is created.";

            }
            else
            {
                lblSuccess.Text = "A problem occured. Data is not recorded";
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            AddAssignmentFunc();
        }
    }
}