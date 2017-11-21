using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TermProject
{
    public partial class AddCourse : System.Web.UI.Page
    {
        BlackboardSvcPxy.BlackBoardService pxy = new BlackboardSvcPxy.BlackBoardService();
        string key = "zuhdi";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getTerm();
            }
        }
        public void getTerm()
        {
            if (pxy.GetUserType(key) != null)
            {
                ddlTerm.DataSource = pxy.GetTerm(key);
                ddlTerm.DataValueField = "TermID";
                ddlTerm.DataTextField = "TermName";
                ddlTerm.DataBind();
            }
            else
            {
                lblInvalidKey.Text = "Please provide correct API Key";
                lblInvalidKey.Visible = true;
            }
        }
    }
}