using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Utilities;
using System.Data;
using System.Data.SqlClient;
using TermProjectClassLibrary;
using System.Collections;

namespace TermProject
{
    public partial class CBMain : System.Web.UI.Page
    {
        BlackboardSvcPxy.BlackBoardService pxy = new BlackboardSvcPxy.BlackBoardService();
        string key = "zuhdi";
        protected void Page_Load(object sender, EventArgs e)
        {
            viewCourseButton.Click += new EventHandler(Click_Event);

            if (!IsPostBack)
            {
                lblName.Text = bindName();

                if (Session["User"] != null && Session["User"].ToString() == "1")
                {
                    DBConnect objDB = new DBConnect();
                    int count = 0;

                    DataSet myDS = objDB.GetDataSet("SELECT AnnoucementID, FK_CourseID FROM TP_Announcement WHERE FK_CourseID = " + Session["CourseID"].ToString(), out count);

                    if (myDS.Tables[0].Rows.Count == 0)
                    {
                        lblError.Text = "No annoucements!";
                    }
                    else
                    {
                        // Create a Custom User Control (ASCX) object for each record in the dataset
                        for (int recordNumber = 0; recordNumber < count; recordNumber++)
                        {
                            ViewCourses ctrl = (ViewCourses)LoadControl("ViewCourses.ascx");

                            // Set properties for the ProductDisplay object
                            ctrl.CourseID = objDB.GetField("FK_CourseID", recordNumber).ToString();
                            ctrl.User = Session["User"].ToString();
                            ctrl.UserID = Session["StudentID"].ToString();


                            // Register the ASCX control with the page and typecast it to the appropriate class ProductDisplay


                            ctrl.DataBind();

                            // Add the control object to the WebForm's Controls collection
                            Form.Controls.Add(ctrl);
                        }
                    }
                }
                if (Session["User"] != null && Session["User"].ToString() == "3")
                {
                    btnAddAnnoucment.Visible = true;    
                    DBConnect objDB = new DBConnect();
                    int count = 0;

                    objDB.GetDataSet("SELECT DISTINCT CourseID FROM TP_Course WHERE FK_CBID = " + Session["cbID"].ToString() + "", out count);

                    // Create a Custom User Control (ASCX) object for each record in the dataset
                    for (int recordNumber = 0; recordNumber < count; recordNumber++)
                    {
                        ViewCourses ctrl = (ViewCourses)LoadControl("ViewCourses.ascx");

                        // Set properties for the ProductDisplay object
                        ctrl.CourseID = objDB.GetField("CourseID", recordNumber).ToString();
                        ctrl.User = Session["User"].ToString();
                        ctrl.UserID = Session["cbID"].ToString();


                        // Register the ASCX control with the page and typecast it to the appropriate class ProductDisplay

                        ctrl.DataBind();

                        // Add the control object to the WebForm's Controls collection
                        Form.Controls.Add(ctrl);
                    }
                }
                else
                {
                    //lblSuccess.Visible = true;
                    //lblSuccess.Text = "Access Denied";
                }
            }

        }

        protected string bindName()
        {
            DataSet courseName = addNameFromCourseID(Session["CourseID"].ToString());
            string name = courseName.Tables[0].Rows[0]["Name"].ToString();
            return name;
        }
        protected void Click_Event(object sender, EventArgs e)
        {
            Response.Redirect("ManageStudents.aspx");
        }

        protected DataSet addNameFromCourseID(string courseID)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.Parameters.Clear();

            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.CommandText = "TP_addNameFromCourseID";

            objCommand.Parameters.AddWithValue("@CourseID", Convert.ToInt32(courseID));

            return objDB.GetDataSetUsingCmdObj(objCommand);
        }

        protected void lblAddAnnoucment_Click(object sender, EventArgs e)
        {
            string user = Session["User"] as string;
            string courseID = Session["CourseID"] as string;
            string cbID = Session["cbID"] as string;
            Session["CourseName"] = lblName.Text;
            Response.Redirect("NewAnnouncement.aspx");
        }
    }
}