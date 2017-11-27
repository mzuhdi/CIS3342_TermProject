using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace TermProject
{
    public partial class Login : System.Web.UI.Page
    {
        BlackboardSvcPxy.BlackBoardService pxy = new BlackboardSvcPxy.BlackBoardService();
        string key = "zuhdi";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text != "" && txtPassword.Text != "")
            {
                BlackboardSvcPxy.BlackBoardService pxy = new BlackboardSvcPxy.BlackBoardService();

                int returnValue = pxy.verifyLogin(txtUsername.Text, txtPassword.Text);

                //int returnValue = pxy.verifyLogin(txtUsername.Text, txtPassword.Text);

                if (returnValue == 1)
                {
                    //lblLoginError.Visible = false;
                    //go to student page with session 
                    lblLoginError.Visible = true;
                    lblLoginError.Text = "student";
                }
                if (returnValue == 2)
                {
                    //lblLoginError.Visible = false;
                    //go to Admin page with session
                    lblLoginError.Visible = true;
                    lblLoginError.Text = "admin";
                }
                if (returnValue == 3)
                {
                    //lblLoginError.Visible = false;
                    ////go to CourseBuilder page with session
                    lblLoginError.Visible = true;
                    lblLoginError.Text = "coursebuilder";
                }
                if (returnValue == 0)
                {
                    lblLoginError.Text = "Username/password is incorrect.";
                    lblLoginError.Visible = true;
                }
            }
            else
            {
                lblLoginError.Text = "Please fill in all fields.";
                lblLoginError.Visible = true;
            }
        }
    }
}