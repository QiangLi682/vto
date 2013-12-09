using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class UserPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
        {
            Response.Redirect("Home.aspx");
        }

      //  DataSet dsUser = (DataSet)Session["user"];
       // Response.Write(Convert.ToString(dsUser.Tables[0].Rows[0]["user_name"] + Convert.ToString(dsUser.Tables[0].Rows[0]["user_accountID"])
    }
}