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
    public partial class ManageContentPages : System.Web.UI.Page
    {
        string key = "zuhdi";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblName.Text = Session["CourseName"].ToString();
                getContentPages();
                getAllContentPages();
            }
        }

        public void createPage(string contentpagetitle, string title, string description, string date, string courseID, FileUpload fileupload1)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            int result = 0, fileSize;
            string fileExtension, fileType, fileName, fileTitle, strSQL;

            try
            {
                // Use the FileUpload control to get the uploaded data
                if (fileupload1.HasFile)
                {
                    fileSize = fileupload1.PostedFile.ContentLength;
                    //fileSize = Convert.ToInt32(FileUpload1.PostedFile.InputStream.Length);
                    byte[] fileData = new byte[fileSize];

                    fileupload1.PostedFile.InputStream.Read(fileData, 0, fileSize);
                    fileName = fileupload1.PostedFile.FileName;
                    fileType = fileupload1.PostedFile.ContentType;



                    fileExtension = fileName.Substring(fileName.LastIndexOf("."));
                    fileExtension = fileExtension.ToLower();

                    if (fileExtension == ".docx" || fileExtension == ".xlsx" || fileExtension == ".pptx" || fileExtension == ".pdf")
                    {

                        // INSERT an file (BLOB) into the database using a stored procedure 'storeProductfile'
                        strSQL = "TP_CreateContentPage";
                        objCommand.CommandText = strSQL;
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@ContentPageTitle", contentpagetitle);
                        objCommand.Parameters.AddWithValue("@Title", title);
                        objCommand.Parameters.AddWithValue("@Description", description);
                        objCommand.Parameters.AddWithValue("@DateCreated", date);
                        objCommand.Parameters.AddWithValue("@FK_CourseID", courseID);
                        objCommand.Parameters.AddWithValue("@fileTitle", fileName);
                        objCommand.Parameters.AddWithValue("@fileData", fileData);
                        objCommand.Parameters.AddWithValue("@fileType", fileType);
                        objCommand.Parameters.AddWithValue("@fileLength", fileData.Length);
                        result = objDB.DoUpdateUsingCmdObj(objCommand);

                        lblMessage.ForeColor = System.Drawing.Color.Green;
                        lblMessage.Text = "file was successully uploaded.";
                    }
                    else
                    {
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        lblMessage.Text = "Only docx, xlsx, pptx and pdf file formats supported.";
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Error ocurred: [" + ex.Message + "] cmd=" + result;
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            createPage(txtPageName.Text, txtPostTitle.Text, txtDescription.Text, System.DateTime.Now.ToString(), Session["CourseID"].ToString(), FileUpload1);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string user = Session["User"] as string;
            string CourseID = Session["CourseID"] as string;
            string cbID = Session["cbID"] as string;
            Session["CourseName"] = lblName.Text;
            Response.Redirect("CBMain.aspx");
        }

        public void getContentPages()
        {
            //if (pxy.GetUserType(key) != null)
            {
                ddlContentPages.DataSource = GetContentPages(Session["CourseID"].ToString());
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

        protected void ddlContentPages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlContentPages.SelectedIndex != 0)
            {

                gvContentPages.Visible = true;
                getContentPageDetails(ddlContentPages.SelectedValue);
                btnAddPost.Enabled = true;
            }
        }

        public void getContentPageDetails(string Id)
        {
            DataSet myDs = GetContentPageDetails(Id);//Session["PageId"].ToString());

            //if (myDs.Tables[0].Rows.Count == 0)
            //{
            //    lblError.Visible = true;
            //    lblError.Text = "No posts made!";
            //}
            //else
            {
                gvContentPages.DataSource = myDs;
                gvContentPages.DataBind();
            }
        }

        public void getAllContentPages()
        {
            DataSet myDs = GetContentPages(Session["CourseID"].ToString());
            gvContent.DataSource = myDs;
            gvContent.DataBind();
        }

        public void getContentPages(string Id)
        {

        }

        public DataSet GetContentPages(string courseID)
        {
            if (key == "zuhdi")
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.CommandText = "TP_GetContentPages";

                objCommand.Parameters.AddWithValue("@FK_CourseID", Convert.ToInt32(courseID));

                DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);
                objCommand.Parameters.Clear();
                return myDataSet;
            }
            else
            {
                return null;
            }
        }

        public DataSet GetContentPageDetails(string courseID)
        {
            if (key == "zuhdi")
            {
                DBConnect objDB = new DBConnect();
                SqlCommand objCommand = new SqlCommand();

                objCommand.CommandType = System.Data.CommandType.StoredProcedure;
                objCommand.CommandText = "TP_RetrieveContentPageDetails";

                objCommand.Parameters.AddWithValue("@ContentPageID", Convert.ToInt32(courseID));

                DataSet myDataSet = objDB.GetDataSetUsingCmdObj(objCommand);
                objCommand.Parameters.Clear();
                return myDataSet;
            }
            else
            {
                return null;
            }
        }

        protected void gvContentPages_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
        protected void gvContent_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void gvContentPages_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            if (e.CommandName == "Change")
            {
                Panel3.Visible = true;
                Panel2.Enabled = false;
                lblId.Text = gvContentPages.DataKeys[rowIndex]["Id"].ToString();
                txtEditTitle.Text = gvContentPages.Rows[rowIndex].Cells[1].Text;
                txtEditDescription.Text = gvContentPages.Rows[rowIndex].Cells[2].Text;
                lblEditFileName.Text = gvContentPages.Rows[rowIndex].Cells[3].Text;
            }
            if (e.CommandName == "Remove")
            {
                string id = gvContentPages.DataKeys[rowIndex]["Id"].ToString();
                removePost(id);
                getContentPageDetails(ddlContentPages.SelectedValue);
            }
        }

        protected void gvContentPages_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void gvContent_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = int.Parse(e.CommandArgument.ToString());
            
            if (e.CommandName == "Remove")
            {
                string id = gvContent.DataKeys[rowIndex]["ContentPageID"].ToString();
                deleteContentPage(id);
                getAllContentPages();
            }
        }

        protected void deleteContentPage(string contentPageID)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.Parameters.Clear();

            string strSQL = "TP_RemoveContentPage";
            objCommand.CommandText = strSQL;
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@contentPageID", Convert.ToInt32(contentPageID));

            objDB.DoUpdateUsingCmdObj(objCommand);
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            editPage(txtEditTitle.Text, txtEditDescription.Text, lblId.Text, FileUpload2);
            getContentPageDetails(ddlContentPages.SelectedValue);
            Panel3.Visible = false;
            Panel2.Enabled = true;
        }

        public void removePost(string contentPageID)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.Parameters.Clear();

            string strSQL = "TP_RemoveContentPostDetail";
            objCommand.CommandText = strSQL;
            objCommand.CommandType = CommandType.StoredProcedure;
            objCommand.Parameters.AddWithValue("@Id", Convert.ToInt32(contentPageID));

            objDB.DoUpdateUsingCmdObj(objCommand);
        }

        public DataSet ContentPagesFromCiD(string courseID)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();

            objCommand.Parameters.Clear();


            objCommand.CommandType = System.Data.CommandType.StoredProcedure;
            objCommand.CommandText = "TP_ContentPagesFromCourseID";
            objCommand.Parameters.AddWithValue("@Id", Convert.ToInt32(courseID));

            return objDB.GetDataSetUsingCmdObj(objCommand);
         }

        public void editPage(string Title, string Description, string contentPageID, FileUpload fileupload2)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            int result = 0, fileSize;
            string fileExtension, fileType, fileName, fileTitle, strSQL;

            if (fileupload2.HasFile)
            {
                fileSize = fileupload2.PostedFile.ContentLength;
                //fileSize = Convert.ToInt32(FileUpload1.PostedFile.InputStream.Length);
                byte[] fileData = new byte[fileSize];

                fileupload2.PostedFile.InputStream.Read(fileData, 0, fileSize);
                fileName = fileupload2.PostedFile.FileName;
                fileType = fileupload2.PostedFile.ContentType;



                fileExtension = fileName.Substring(fileName.LastIndexOf("."));
                fileExtension = fileExtension.ToLower();

                if (fileExtension == ".docx" || fileExtension == ".xlsx" || fileExtension == ".pptx" || fileExtension == ".pdf")
                {

                    // INSERT an file (BLOB) into the database using a stored procedure 'storeProductfile'
                    objCommand.Parameters.Clear();

                    strSQL = "TP_UpdateContentPageDetail";
                    objCommand.CommandText = strSQL;
                    objCommand.CommandType = CommandType.StoredProcedure;
                    objCommand.Parameters.AddWithValue("@Title", Title);
                    objCommand.Parameters.AddWithValue("@Description", Description);
                    objCommand.Parameters.AddWithValue("@FileTitle", fileName);
                    objCommand.Parameters.AddWithValue("@FileData", fileData);
                    objCommand.Parameters.AddWithValue("@FileType", fileType);
                    objCommand.Parameters.AddWithValue("@FileLength", fileData.Length);
                    objCommand.Parameters.AddWithValue("@ContentPageDetailID", Convert.ToInt32(contentPageID));
                    result = objDB.DoUpdateUsingCmdObj(objCommand);

                    lblEditMessage.ForeColor = System.Drawing.Color.Green;
                    lblEditMessage.Text = "file was successully uploaded.";
                }
                else
                {
                    lblEditMessage.ForeColor = System.Drawing.Color.Red;
                    lblEditMessage.Text = "Only docx, xlsx, pptx and pdf file formats supported.";
                }
            }
            else
            {
                objCommand.Parameters.Clear();

                strSQL = "TP_UpdateContentPageDetail";
                objCommand.CommandText = strSQL;
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@Title", Title);
                objCommand.Parameters.AddWithValue("@Description", Description);
                objCommand.Parameters.AddWithValue("@FileTitle", "0");
                objCommand.Parameters.AddWithValue("@FileData", "0");
                objCommand.Parameters.AddWithValue("@FileType", "");
                objCommand.Parameters.AddWithValue("@FileLength", "0");
                objCommand.Parameters.AddWithValue("@ContentPageDetailID", Convert.ToInt32(contentPageID));
                objDB.DoUpdateUsingCmdObj(objCommand);
            }
            //}
            //catch (Exception ex)
            //{
            //    lblEditMessage.ForeColor = System.Drawing.Color.Red;
            //    lblEditMessage.Text = "Error ocurred: [" + ex.Message + "] cmd=" + result;
            //}
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Button3.Enabled = false;
            btnManage.Enabled = true;
            btnDelete.Enabled = true;
            Panel1.Visible = true;
            Panel2.Visible = false;
            Panel3.Visible = false;
        }

        protected void btnEditCancel_Click(object sender, EventArgs e)
        {
            getContentPageDetails(ddlContentPages.SelectedValue);
            Panel3.Visible = false;
            Panel2.Enabled = true;
        }

        protected void btnManage_Click(object sender, EventArgs e)
        {
            btnManage.Enabled = false;
            Button3.Enabled = true;
            btnDelete.Enabled = true;
            Panel1.Visible = false;
            Panel2.Visible = true;
            Panel3.Visible = false;
        }

        protected void btnAddPost_Click(object sender, EventArgs e)
        {
            Panel3.Visible = false;
            Panel4.Visible = true;
            Panel2.Enabled = false;
            lblAddID.Text = ddlContentPages.SelectedValue.ToString();

        }

        protected void btnAdOK_Click(object sender, EventArgs e)
        {

        }

        protected void btnAdCancel_Click(object sender, EventArgs e)
        {

        }

        protected void btnAddOK_Click(object sender, EventArgs e)
        {
            createPost(txtAddTitle.Text, txtAddDescription.Text, System.DateTime.Now.ToString(), lblAddID.Text, FileUpload3);
            getContentPageDetails(ddlContentPages.SelectedValue);
            Panel4.Visible = false;
            Panel2.Enabled = true;
        }

        public void createPost(string title, string description, string date, string pageID, FileUpload fileupload3)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand objCommand = new SqlCommand();
            int result = 0, fileSize;
            string fileExtension, fileType, fileName, fileTitle, strSQL;

            try
            {
                // Use the FileUpload control to get the uploaded data
                if (fileupload3.HasFile)
                {
                    fileSize = fileupload3.PostedFile.ContentLength;
                    //fileSize = Convert.ToInt32(FileUpload1.PostedFile.InputStream.Length);
                    byte[] fileData = new byte[fileSize];

                    fileupload3.PostedFile.InputStream.Read(fileData, 0, fileSize);
                    fileName = fileupload3.PostedFile.FileName;
                    fileType = fileupload3.PostedFile.ContentType;



                    fileExtension = fileName.Substring(fileName.LastIndexOf("."));
                    fileExtension = fileExtension.ToLower();

                    if (fileExtension == ".docx" || fileExtension == ".xlsx" || fileExtension == ".pptx" || fileExtension == ".pdf")
                    {

                        // INSERT an file (BLOB) into the database using a stored procedure 'storeProductfile'
                        strSQL = "TP_AddContentPageDetail";
                        objCommand.CommandText = strSQL;
                        objCommand.CommandType = CommandType.StoredProcedure;
                        objCommand.Parameters.AddWithValue("@Id", pageID);
                        objCommand.Parameters.AddWithValue("@Title", title);
                        objCommand.Parameters.AddWithValue("@Description", description);
                        objCommand.Parameters.AddWithValue("@Date", date);
                        objCommand.Parameters.AddWithValue("@FileTitle", fileName);
                        objCommand.Parameters.AddWithValue("@FileData", fileData);
                        objCommand.Parameters.AddWithValue("@FileType", fileType);
                        objCommand.Parameters.AddWithValue("@FileLength", fileData.Length);
                        result = objDB.DoUpdateUsingCmdObj(objCommand);

                        lblEditMessage0.ForeColor = System.Drawing.Color.Green;
                        lblEditMessage0.Text = "file was successully uploaded.";
                    }
                    else
                    {
                        lblEditMessage0.ForeColor = System.Drawing.Color.Red;
                        lblEditMessage0.Text = "Only docx, xlsx, pptx and pdf file formats supported.";
                    }
                }
            }
            catch (Exception ex)
            {
                lblEditMessage0.ForeColor = System.Drawing.Color.Red;
                lblEditMessage0.Text = "Error ocurred: [" + ex.Message + "] cmd=" + result;
            }
        }

        protected void btnAddCanel_Click(object sender, EventArgs e)
        {
            getContentPageDetails(ddlContentPages.SelectedValue);
            Panel4.Visible = false;
            Panel2.Enabled = true;
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            string user = Session["User"] as string;
            string CourseID = Session["CourseID"] as string;
            string cbID = Session["cbID"] as string;
            Session["CourseName"] = lblName.Text;
            Response.Redirect("CBMain.aspx");
        }
    }
}