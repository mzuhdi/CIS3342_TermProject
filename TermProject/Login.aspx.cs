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

                string[] user = pxy.verifyLogin(txtUsername.Text, txtPassword.Text);

                //int returnValue = pxy.verifyLogin(txtUsername.Text, txtPassword.Text);

                if (user[0] == "1")
                {
                    //go to student page with session 
                    Session["User"] = user[0];
                    Session["StudentID"] = user[1];
                    // swithc to studentuser
                    if (chkRememberMe.Checked == true)
                    {
                        HttpCookie myCookie = new HttpCookie("theCookie");
                        myCookie.Value = "Student";
                        myCookie.Expires = new DateTime(2018, 1, 1);
                        myCookie.Values["Username"] = txtUsername.Text;
                        Response.Cookies.Add(myCookie);
                    }
                    Response.Redirect("StudentClasses.aspx");
                }
                else if (user[0] == "2")
                {
                    Session["User"] = user[0];
                    Session["AdminID"] = user[1];
                    //go to Admin page with session
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
                else if (user[0] == "3")
                {
                    Session["User"] = user[0];
                    Session["cbID"] = user[1];
                    ////go to CourseBuilder page with session
                    if (chkRememberMe.Checked == true)
                    {
                        HttpCookie myCookie = new HttpCookie("theCookie");
                        myCookie.Value = "CourseBuilder";
                        myCookie.Expires = new DateTime(2018, 1, 1);
                        myCookie.Values["Username"] = txtUsername.Text;
                        Response.Cookies.Add(myCookie);
                    }
                    Response.Redirect("CourseBuilderClasses.aspx");
                }
                if (user[0] == "0")
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
