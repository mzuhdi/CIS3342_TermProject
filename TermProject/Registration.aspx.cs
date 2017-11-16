using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TermProject
{
    public partial class Registration : System.Web.UI.Page
    {
        BlackboardSvcPxy.BlackBoardService pxy = new BlackboardSvcPxy.BlackBoardService();
        string key = "zuhdi";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getUserType();
            }
        }
        public void getUserType()
        {
            if (pxy.GetUserType(key) != null)
            {
                ddlUserType.DataSource = pxy.GetUserType(key);
                ddlUserType.DataValueField = "UserTypeID";
                ddlUserType.DataTextField = "Name";
                ddlUserType.DataBind();
            }
            else
            {
                lblInvalidKey.Text = "Please provide correct API Key";
                lblInvalidKey.Visible = true;
            }
        }

        protected void ddlUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlUserType.SelectedValue.ToString() == "1")
            {
                studentRegister.Visible = true;
                courseBuilderRegister.Visible = false;
                adminRegister.Visible = false;
            }
            if (ddlUserType.SelectedValue.ToString() == "2")
            {
                studentRegister.Visible = false;
                courseBuilderRegister.Visible = true;
                adminRegister.Visible = false;
            }
            if (ddlUserType.SelectedValue.ToString() == "3")
            {
                studentRegister.Visible = false;
                courseBuilderRegister.Visible = false;
                adminRegister.Visible = true;
            }
        }
    }
}