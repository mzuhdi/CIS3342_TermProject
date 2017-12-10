using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using Utilities;

namespace TermProject
{
    public partial class ViewCourses : System.Web.UI.UserControl
    {
        String user;
        String userId;
        String courseId;
        public event EventHandler Click;


        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
             
            }
        }

        [Category("Misc")]
        public String User
        {
            get { return user; }
            set { user = value; }
        }

        [Category("Misc")]
        public String UserID
        {
            get { return userId; }
            set { userId = value; }
        }

        [Category("Misc")]
        public String CourseID
        {
            get { return courseId; }
            set { courseId = value; }
        }

        public override void DataBind()
        {
          if (User == "1")
            {
                DataSet myDs = populateAnnouncments(CourseID);

                if (myDs.Tables[0].Rows.Count == 0)
                {
                    lblError.Visible = true;
                    lblError.Text = "No Announcments!";
                }
                else
                {
                    rptAnnouncements.DataSource = myDs;
                    rptAnnouncements.DataBind();
                }
            } 
           else if (User == "3")
            {
                DataSet myDs = populateAnnouncments(CourseID);

                if (myDs.Tables[0].Rows.Count == 0)
                {
                    lblError.Visible = true;
                    lblError.Text = "No Announcments! Click below to add one.";
                }
                rptAnnouncements.DataSource = myDs;
                    rptAnnouncements.DataBind();
            }
        }

        public DataSet populateStudentClasses(string cID)
        {
            DBConnect objDB = new DBConnect();
            String strSQL = "SELECT DISTINCT C.Name, C.CourseID, C.CourseCode, B.CBID, B.FirstName, B.LastName FROM TP_Course C JOIN TP_CourseBuilder B ON C.FK_CBID = B.CBID WHERE C.CourseID = " + Convert.ToInt32(cID) + ";";

            return objDB.GetDataSet(strSQL);
        }



        public DataSet populateAnnouncments(string cID)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.Parameters.Clear();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_GetAnnoucementByCourseID";
            objCommand.Parameters.AddWithValue("@FK_CourseID", Convert.ToInt32(cID));


            return objDB.GetDataSetUsingCmdObj(objCommand);
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            //lblProfessor.Text = lblCourseID.Text;
            if (Click != null)
            {
                Click(sender, e);
            }
        }

        protected void rptAnnouncements_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }
    }
}