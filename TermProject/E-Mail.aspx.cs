using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Utilities;
using System.Data.SqlClient;
using System.Collections;

namespace TermProject
{
    public partial class E_Mail : System.Web.UI.Page
    {
        BlackboardSvcPxy.BlackBoardService pxy = new BlackboardSvcPxy.BlackBoardService();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtEmailFROM.Text = "Professor@school.edu";
                if (Session["StudentEmail"] != null)
                {
                    txtEmailTO.Text = Convert.ToString(Session["StudentEmail"]);
                }
                else
                {
                    txtEmailTO.Text = "All Students";
                    //txtEmailTO.Text = breakArray((ArrayList)Session["StudentEmail"]);
                } 
            }
        }

        public string breakArray(ArrayList emails)
        {
            string str = "";

            foreach (string stdEmail in emails)
            {
                str = stdEmail;
            }
            return str;
        }

        protected void btnSendMail_Click(object sender, EventArgs e)
        {
            BlackboardSvcPxy.Email email = new BlackboardSvcPxy.Email();
            email.Recipient = txtEmailTO.Text;
            email.Sender = txtEmailFROM.Text;
            email.Subject = txtSubject.Text;
            email.Message = txtMessage.Text;

            try
            {
                pxy.SendMail(email);
                lblDisplay.Text = "The email was sent.";
            }
            catch (Exception ex)
            {
                lblDisplay.Text = "The email wasn't sent because one of the required fields was missing.";
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("ManageStudents.aspx");
        }
    }
}