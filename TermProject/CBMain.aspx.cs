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
                if (Session["User"] != null && Session["User"].ToString() == "1")
                {
                    DBConnect objDB = new DBConnect();
                    int count = 0;

                    objDB.GetDataSet("SELECT DISTINCT FK_CourseID FROM TP_CourseStudent WHERE FK_StudentID = " + Session["StudentID"].ToString() + "", out count);

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
                if (Session["User"] != null && Session["User"].ToString() == "3")
                {
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
        protected void Click_Event(object sender, EventArgs e)
        {
            Response.Redirect("ManageStudents.aspx");
        }


    }
}