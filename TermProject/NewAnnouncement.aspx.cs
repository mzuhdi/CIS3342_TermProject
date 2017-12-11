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
        BlackboardSvcPxy.BlackBoardService pxy = new BlackboardSvcPxy.BlackBoardService();
        string key = "zuhdi";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblName.Text = Session["CourseName"].ToString();
                lblID.Text = Session["CourseID"].ToString();
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            BlackboardSvcPxy.Annoucement newAnnoucement = new BlackboardSvcPxy.Annoucement();
            //Annoucement newAnnoucement = new Annoucement();
            newAnnoucement.Title = txtTitle.Text;
            newAnnoucement.Description = txtDescription.Text;
            newAnnoucement.Date = DateTime.Now;
            newAnnoucement.FK_CourseID = Convert.ToInt32(lblID.Text);

           bool message = pxy.AddAnnoucementSvc("zuhdi", newAnnoucement);

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

        //public bool AddAnnoucementSvc(string key, Annoucement annoucement)
        //{
        //    if (annoucement != null && key == "zuhdi")
        //    {
        //        DBConnect objDB = new DBConnect();
        //        SqlCommand objCommand = new SqlCommand();

        //        objCommand.CommandType = System.Data.CommandType.StoredProcedure;
        //        objCommand.CommandText = "TP_AddAnnoucement";
        //        objCommand.Parameters.AddWithValue("@Title", annoucement.Title);
        //        objCommand.Parameters.AddWithValue("@Description", annoucement.Description);
        //        objCommand.Parameters.AddWithValue("@Date", annoucement.Date);
        //        objCommand.Parameters.AddWithValue("@FK_CourseID", annoucement.FK_CourseID);

        //        DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);
        //        objCommand.Parameters.Clear();
        //        return true;
        //    }
        //    return false;
        //}

        //public bool AddAnnoucement(Annoucement newAnnoucement, string key)
        //{
        //    if (newAnnoucement != null && key == "zuhdi")
        //    {
        //        DBConnect objDB = new DBConnect();
        //        SqlCommand objCommand = new SqlCommand();

        //        objCommand.Parameters.Clear();

        //        objCommand.CommandType = System.Data.CommandType.StoredProcedure;
        //        objCommand.CommandText = "TP_AddAnnoucement";
        //        objCommand.Parameters.AddWithValue("@Title", newAnnoucement.Title);
        //        objCommand.Parameters.AddWithValue("@Description", newAnnoucement.Description);
        //        objCommand.Parameters.AddWithValue("@Date", newAnnoucement.Date);
        //        objCommand.Parameters.AddWithValue("@FK_CourseID", newAnnoucement.FK_CourseID);

        //        return true;
        //    }
        //    return false;
        //}

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