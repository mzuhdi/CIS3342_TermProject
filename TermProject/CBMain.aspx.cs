using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TermProject
{
    public partial class CBMain : System.Web.UI.Page
    {
        BlackboardSvcPxy.BlackBoardService pxy = new BlackboardSvcPxy.BlackBoardService();
        string key = "zuhdi";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["CBID"] != null)
                {
                    lblSuccess.Text = "Login Successful";
                    getCourses();
                } else
                {
                    lblSuccess.Text = "Access Denied";
                }
            }
        }
        public void getCourses()
        {
            if (pxy.GetCourseByCBID((int)Session["CBID"], key) != null) 
            {
                ViewCourses viewCourses = (ViewCourses)LoadControl("ViewCourses.ascx");
                viewCourses.Title = "Course Builder View Course";
                viewCourses.gvBind(pxy.GetCourseByCBID((int)Session["CBID"], key));
                Form.Controls.Add(viewCourses);
            }
            else
            {
            }

        }
    }
}