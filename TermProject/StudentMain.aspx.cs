using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Utilities;
using System.Data;
using System.Data.SqlClient;


namespace TermProject
{
    public partial class StudentMain : System.Web.UI.Page
    {
        string key = "zuhdi";
        int num = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (num == 1) //Session["StudentID"] != null
                {
                    lblSuccess.Text = "Login Successful";
                    bindGV();
                }
                else
                {
                    lblSuccess.Text = "Access Denied";
                }
            }
        }

        public DataSet getAssignmentByCourseStudentID(string key, int fk_StudentID, int fk_CourseID)
        {
            if (key == "zuhdi")
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.CommandText = "TP_GetAssigmentByCourseStudentID";
                objCommand.Parameters.AddWithValue("@FK_StudentID", fk_StudentID);
                objCommand.Parameters.AddWithValue("@FK_CourseID", fk_CourseID);

                DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);
                objCommand.Parameters.Clear();
                return myDataSet;
            }
            else
            {
                return null;
            }
        }

        public void bindGV()
        {
            gvGrades.DataSource = getAssignmentByCourseStudentID(key, 1, 1);
            gvGrades.DataBind();
        }

    }
}
