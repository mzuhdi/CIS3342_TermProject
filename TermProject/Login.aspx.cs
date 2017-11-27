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
            if (!IsPostBack)
            {
                HttpCookie objCookie = Request.Cookies["theCookie"];
                if (objCookie != null)
                {
                    txtUsername.Text = objCookie.Values["Username"];
                }
            }
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
                    //lblLoginError.Visible = true;
                    lblLoginError.Text = returnValue.ToString();
                    Session["StudentID"] = 1; // swithc to studentuser
                    if(chkRememberMe.Checked == true)
                    {
                        HttpCookie myCookie = new HttpCookie("theCookie");
                        myCookie.Value = "Student";
                        myCookie.Expires = new DateTime(2018, 1, 1);
                        myCookie.Values["Username"] = txtUsername.Text;
                        Response.Cookies.Add(myCookie);
                    }
                    Response.Redirect("StudentMain.aspx");
                }
                if (returnValue == 2)
                {
                    //lblLoginError.Visible = false;
                    //go to Admin page with session
                    //lblLoginError.Visible = true;
                    //lblLoginError.Text = "admin";
                    Session["AdminID"] = 1;
                    if (chkRememberMe.Checked == true)
                    {
                        HttpCookie myCookie = new HttpCookie("theCookie");
                        myCookie.Value = "admin";
                        myCookie.Expires = new DateTime(2018, 1, 1);
                        myCookie.Values["Username"] = txtUsername.Text;
                        Response.Cookies.Add(myCookie);
                    }
                    Response.Redirect("AdminMain.aspx");
                }
                if (returnValue == 3)
                {
                    //lblLoginError.Visible = false;
                    ////go to CourseBuilder page with session
                    //lblLoginError.Visible = true;
                    //lblLoginError.Text = "coursebuilder";
                    Session["CBID"] = 1;
                    if (chkRememberMe.Checked == true)
                    {
                        HttpCookie myCookie = new HttpCookie("theCookie");
                        myCookie.Value = "CourseBuilder";
                        myCookie.Expires = new DateTime(2018, 1, 1);
                        myCookie.Values["Username"] = txtUsername.Text;
                        Response.Cookies.Add(myCookie);
                    }
                    Response.Redirect("CBMain.aspx");
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