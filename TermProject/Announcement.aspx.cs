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
    public partial class AddAnnouncement : System.Web.UI.Page
    {
        string key = "zuhdi";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAnnoucementFunc();
            }
        }

        public bool AddAnnoucementSvc(string key, Annoucement annoucement)
        {
            if (annoucement != null && key == "zuhdi")
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.CommandText = "TP_AddAnnoucement";
                objCommand.Parameters.AddWithValue("@Title", annoucement.Title);
                objCommand.Parameters.AddWithValue("@Description", annoucement.Description);
                objCommand.Parameters.AddWithValue("@Date", annoucement.Date);
                objCommand.Parameters.AddWithValue("@FK_CourseID", annoucement.FK_CourseID);

                DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);
                objCommand.Parameters.Clear();
                return true;
            }
            return false;
        }
        public void AddAnnoucementFunc()
        {
            //BlackboardSvcPxy.Student student = new BlackboardSvcPxy.Student();
            Annoucement annoucement = new Annoucement();

            annoucement.Title = txtTitle.Text;
            annoucement.Description = txtDescription.Text;
            annoucement.Date = DateTime.Now;
            annoucement.FK_CourseID = 1; //Get Session[CourseID]


            if (AddAnnoucementSvc(key, annoucement))
            {
                lblSuccess.Text = "The student is created.";

            }
            else
            {
                lblSuccess.Text = "A problem occured. Data is not recorded";
            }
        }
        public DataSet GetAnnoucement(string key, Annoucement annoucement)
        {
            if (key == "zuhdi")
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.CommandText = "TP_GetAnnoucementByCourseID";
                objCommand.Parameters.AddWithValue("@FK_CourseID", annoucement.FK_CourseID);

                DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);
                objCommand.Parameters.Clear();
                return myDataSet;
            }
            else
            {
                return null;
            }
        }
        public void GetAnnoucementFunc()
        {
            //BlackboardSvcPxy.Student student = new BlackboardSvcPxy.Student();
            Annoucement annoucement = new Annoucement();
            annoucement.FK_CourseID = 1; //Get Session[CourseID]

            if (GetAnnoucement(key, annoucement) != null)
            {
                gvAnnoucement.DataSource = GetAnnoucement(key, annoucement);
                gvAnnoucement.DataBind();
            }
            else
            {
                //lblInvalidKey.Text = "Please provide correct API Key";
                //lblInvalidKey.Visible = true;
            }
        }

        public bool UpdateAnnoucementSvc(string key, Annoucement annoucement)
        {
            if (annoucement != null && key == "zuhdi")
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.CommandText = "TP_UpdateAnnoucement";
                objCommand.Parameters.AddWithValue("@ID", annoucement.ID );
                objCommand.Parameters.AddWithValue("@Title", annoucement.Title );
                objCommand.Parameters.AddWithValue("@Description", annoucement.Description);
                objCommand.Parameters.AddWithValue("@FK_CourseID", annoucement.FK_CourseID);
                objCommand.Parameters.AddWithValue("@Date", annoucement.Date);

                objDB.DoUpdateUsingCmdObj(objCommand);
                objCommand.Parameters.Clear();
                return true;
            }
            return false;
        }
        public void UpdateAnnoucementFunc()
        {
            //BlackboardSvcPxy.Student student = new BlackboardSvcPxy.Student();
            Annoucement annoucement = new Annoucement();

            annoucement.ID = int.Parse(lblAnnoucementID.Text);
            annoucement.Title = txtTitle.Text;
            annoucement.Description = txtDescription.Text;
            annoucement.Date = DateTime.Now;
            annoucement.FK_CourseID = 1; //Get Session[CourseID]


            if (UpdateAnnoucementSvc(key, annoucement))
            {
                lblSuccess.Text = "The annoucement is updated.";

            }
            else
            {
                lblSuccess.Text = "A problem occured. Data is not recorded";
            }
        }
        public bool DeleteAnnoucementSvc(string key, int id)
        {
            if (id != 0 && key == "zuhdi")
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.CommandText = "TP_DeleteAnnoucement";
                objCommand.Parameters.AddWithValue("@ID", id);

                objDB.DoUpdateUsingCmdObj(objCommand);
                objCommand.Parameters.Clear();
                return true;
            }
            return false;
        }

        //public void DeleteAnnoucementFunc()
        //{
        //    //BlackboardSvcPxy.Student student = new BlackboardSvcPxy.Student();
        //    Annoucement annoucement = new Annoucement();

        //    annoucement.ID = int.Parse(lblAnnoucementID.Text);


        //    if (DeleteAnnoucementSvc(key, annoucement))
        //    {
        //        lblSuccess.Text = "The annoucement is updated.";

        //    }
        //    else
        //    {
        //        lblSuccess.Text = "A problem occured. Data is not recorded";
        //    }
        //}

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            AddAnnoucementFunc();
            GetAnnoucementFunc();
        }

        protected void gvAnnoucement_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            if (e.CommandName == "Update")
            {
                h1Add.Visible = false;
                h1Manage.Visible = true;
                btnSubmit.Visible = false;
                btnUpdate.Visible = true;
                lblAnnoucementID.Text = gvAnnoucement.DataKeys[rowIndex]["AnnoucementID"].ToString();
                txtTitle.Text = gvAnnoucement.Rows[rowIndex].Cells[2].Text;
                txtDescription.Text = gvAnnoucement.Rows[rowIndex].Cells[3].Text;
            }
            else if (e.CommandName == "Delete")
            {

                //BlackboardSvcPxy.BlackBoardService pxy = new BlackboardSvcPxy.BlackBoardService();
                
                if (DeleteAnnoucementSvc(key, (int)gvAnnoucement.DataKeys[rowIndex]["AnnoucementID"]))

                {
                    lblSuccess.Text = "The course is deleted.";
                }
                else
                {
                    lblSuccess.Text = "A problem occured. Data is not recorded";
                }

                GetAnnoucementFunc();


            }
        }

        protected void gvAnnoucement_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void gvAnnoucement_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateAnnoucementFunc();
            GetAnnoucementFunc();
        }
    }
}