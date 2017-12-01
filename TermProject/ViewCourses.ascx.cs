using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

namespace TermProject
{
    public partial class ViewCourses : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [Category("Misc")]
        public string Title { get; set; }

        public void gvBind(DataSet datasource)
        {
            title.Text = Title;
            gvCourses.DataSource = datasource;
            gvCourses.DataBind();

        }

        protected void gvCourses_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void gvCourses_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }
    }
}