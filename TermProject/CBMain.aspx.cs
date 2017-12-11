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
            if (!IsPostBack)
            {
                lblName.Text = bindName();
                getContentPages();

                if (Session["User"] != null && Session["User"].ToString() == "1")
                {
                    ViewCourses ctrl = (ViewCourses)LoadControl("ViewCourses.ascx");

                    btnAddAnnoucment.Visible = false;
                    btnCourseBuilderTools.Visible = false;

                    // Set properties for the ProductDisplay object
                    ctrl.CourseID = Session["CourseID"].ToString();
                    ctrl.User = Session["User"].ToString();
                    ctrl.UserID = Session["StudentID"].ToString();

                    ctrl.DataBind();
                    Form.Controls.Add(ctrl);
                }
                if (Session["User"] != null && Session["User"].ToString() == "3")
                {
                    btnAddAnnoucment.Visible = true;
                    btnCourseBuilderTools.Visible = true;

                    ViewCourses ctrl = (ViewCourses)LoadControl("ViewCourses.ascx");

                    // Set properties for the ProductDisplay object
                    ctrl.CourseID = Session["CourseID"].ToString();
                    ctrl.User = Session["User"].ToString();
                    ctrl.UserID = Session["cbID"].ToString();

                    ctrl.DataBind();
                    Form.Controls.Add(ctrl);
                }
                else
                {
                    //lblError.Visible = true;
                    //lblError.Text = "Access Denied";
                }
            }

        }

        protected string bindName()
        {
            DataSet courseName = pxy.addNameFromCourseID(Session["CourseID"].ToString());
            string name = courseName.Tables[0].Rows[0]["Name"].ToString();
            return name;
        }


        protected void Click_Event(object sender, EventArgs e)
        {
            Response.Redirect("ManageStudents.aspx");
        }

        //protected DataSet addNameFromCourseID(string courseID)
        //{
        //    DBConnect objDB = new DBConnect();
        //    SqlCommand objCommand = new SqlCommand();

        //    objCommand.Parameters.Clear();

        //    objCommand.CommandType = CommandType.StoredProcedure;
        //    objCommand.CommandText = "TP_addNameFromCourseID";

        //    objCommand.Parameters.AddWithValue("@CourseID", Convert.ToInt32(courseID));

        //    return objDB.GetDataSetUsingCmdObj(objCommand);
        //}

        protected void lblAddAnnoucment_Click(object sender, EventArgs e)
        {
            string user = Session["User"] as string;
            string courseID = Session["CourseID"] as string;
            string cbID = Session["cbID"] as string;
            Session["CourseName"] = lblName.Text;
            Response.Redirect("NewAnnouncement.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            sessionPass();
            Response.Redirect("CourseBuilderTools.aspx");
        }

        public void sessionPass()
        {
            string user = Session["User"] as string;
            string courseID = Session["CourseID"] as string;
            string cbID = Session["cbID"] as string;
            Session["CourseName"] = lblName.Text;
        }

        public void getContentPages()
        {
            //if (pxy.GetUserType(key) != null)
            {
                ddlContentPages.DataSource = pxy.GetContentPages(Session["CourseID"].ToString(), key);
                ddlContentPages.DataValueField = "ContentPageID";
                ddlContentPages.DataTextField = "Title";
                ddlContentPages.DataBind();
                ListItem li = new ListItem();
                li.Text = "--Content Pages--";
                li.Value = "-1";
                ddlContentPages.Items.Insert(0, li);
                ddlContentPages.SelectedIndex = 0;
            }
        }

        //public DataSet GetContentPages(string courseID)
        //{
        //    if (key == "zuhdi")
        //    {
        //        DBConnect objDB = new DBConnect();
        //        SqlCommand objCommand = new SqlCommand();

        //        objCommand.CommandType = System.Data.CommandType.StoredProcedure;
        //        objCommand.CommandText = "GetContentPages";

        //        objCommand.Parameters.AddWithValue("@FK_CourseID", Convert.ToInt32(courseID));

        //        DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);
        //        objCommand.Parameters.Clear();
        //        return myDataSet;
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}

        protected void ddlContentPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlContentPages.SelectedIndex != 0)
            {
                string pageId = ddlContentPages.SelectedValue;
                string pageName = ddlContentPages.SelectedItem.Text;
                sessionPass();
                Session["PageId"] = pageId;
                Session["PageName"] = pageName;
                Response.Redirect("ContentPage.aspx");
            }
            else
            {
                //return false;
            }
        }

        protected void btnSignOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }

        protected void btnMyClasses_Click(object sender, EventArgs e)
        {
            if(Session["User"].ToString() == "1")
            {
                sessionPass();
                Response.Redirect("StudentClasses.aspx");
            }
            else if(Session["User"].ToString() == "3")
            {
                sessionPass();
                Response.Redirect("CourseBuilderClasses.aspx");
            }
        }

        protected void btnAssignments_Click(object sender, EventArgs e)
        {
            sessionPass();
            string id = Session["StudentID"] as string;
            Response.Redirect("CourseAssignments.aspx");
        }
    }
}