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
                    txtEmailTO.Text = breakArray((ArrayList)Session["StudentEmail"]);
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
            Email objEmail = new Email();
            String strTO = txtEmailTO.Text;
            String strFROM = txtEmailFROM.Text;
            String strSubject = txtSubject.Text;
            String strMessage = txtMessage.Text;

            try
            {
                objEmail.SendMail(strTO, strFROM, strSubject, strMessage);
                lblDisplay.Text = "The email was sent.";
            }
            catch (Exception ex)
            {
                lblDisplay.Text = "The email wasn't sent because one of the required fields was missing.";
            }
        }
    }
}