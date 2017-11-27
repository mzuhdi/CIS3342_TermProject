﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TermProject
{
    public partial class CBMain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["CBID"] != null)
                {
                    lblSuccess.Text = "Login Successful";
                } else
                {
                    lblSuccess.Text = "Access Denied";
                }
            }
        }
    }
}