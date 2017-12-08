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
    public partial class NewAnnouncement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblName.Text = Session["CourseName"].ToString();
                lblMessage.Text = Session["CourseID"].ToString();
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {

            Annoucement newAnnoucement = new Annoucement();
            newAnnoucement.Title = txtTitle.Text;
            newAnnoucement.Description = txtDescription.Text;
            newAnnoucement.FK_CourseID = Convert.ToInt32(Session["CourseID"]);

           bool message = AddAnnoucement(newAnnoucement, "zuhdi");

            if(message == true)
            {
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Announcement created!";
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "ERROR: Announcement not created!";
            }
        }

        public bool AddAnnoucement(Annoucement newAnnoucement, string key)
        {
            if (newAnnoucement != null && key == "zuhdi")
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.Parameters.Clear();

                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.CommandText = "TP_AddAnnoucement";
                objCommand.Parameters.AddWithValue("@Title", newAnnoucement.Title);
                objCommand.Parameters.AddWithValue("@Description", newAnnoucement.Description);
                objCommand.Parameters.AddWithValue("@Date", newAnnoucement.Date);
                objCommand.Parameters.AddWithValue("@FK_CourseID", newAnnoucement.FK_CourseID);

                return true;
            }
            return false;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            string user = Session["User"] as string;
            string CourseID = Session["CourseID"] as string;
            string cbID = Session["cbID"] as string;
            Session["CourseName"] = lblName.Text;
            Response.Redirect("CBMain.aspx");
            
        }
    }
}