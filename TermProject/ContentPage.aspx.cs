using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.IO;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using Utilities;


namespace TermProject
{
    public partial class ContentPage : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getContentPageDetails();
                lblPageName.Text = Session["PageName"].ToString();
                lblName.Text = Session["CourseName"].ToString();
            }
        }

        protected void rptContentPage_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "download")
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();
                int rowIndex = e.Item.ItemIndex;

                Label fileName = (Label)rptContentPage.Items[rowIndex].FindControl("lblFileName");
                Label lblId = (Label)rptContentPage.Items[rowIndex].FindControl("lblId");
                int id = Convert.ToInt32(lblId.Text);
                string FileName = Convert.ToString(fileName.Text);

                objCommand.Parameters.Clear();

                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.CommandText = "TP_GetFile";

                objCommand.Parameters.AddWithValue("@id", Convert.ToInt32(id));

                DataSet ds = objDB.GetDataSetUsingCmdObj(objCommand);

                byte[] FileData;
                FileData = (byte[])objDB.GetField("FileData", 0);
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = objDB.GetField("FileType", 0).ToString();
                Response.AddHeader("content-disposition", "attachment;filename="
                + FileName);
                Response.BinaryWrite(FileData);
                Response.Flush();
                Response.End();

            }
        }
        public void getContentPageDetails()
        {
            DataSet myDs = GetContentPageDetails(Session["PageId"].ToString());

            if (myDs.Tables[0].Rows.Count == 0)
            {
                lblError.Visible = true;
                lblError.Text = "No posts made!";
            }
            else
            {
                rptContentPage.DataSource = myDs;
                rptContentPage.DataBind();
            }
        }

        public DataSet GetContentPageDetails(string pageID)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.CommandType = System.Data.CommandType.StoredProcedure;
            objCommand.CommandText = "TP_RetrieveContentPageDetails";

            objCommand.Parameters.AddWithValue("@ContentPageID", Convert.ToInt32(pageID));

            DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);
            objCommand.Parameters.Clear();
            return myDataSet;
        }

        protected void txtBack_Click(object sender, EventArgs e)
        {
            string user = Session["User"] as string;
            string CourseID = Session["CourseID"] as string;
            string cbID = Session["cbID"] as string;
            Session["CourseName"] = lblName.Text;
            Response.Redirect("CBMain.aspx");
        }
    }
}