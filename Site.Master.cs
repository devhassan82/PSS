﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PSS
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblHeaderUser.Text = Session["UserName"].ToString();
                lblHeaderDesignation.Text = Session["Designation"].ToString();
            }
        }
    }
}