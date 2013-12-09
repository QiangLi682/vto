using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
   
    
    protected void Page_Load(object sender, EventArgs e)
    {

 
    }
    protected void ValidateLogin(string username, string password)
    {

        test9.mobilewebserviceSoapClient ws = new test9.mobilewebserviceSoapClient();

        DataSet dsUser = ws.VTOUserLogin(username, password);

        if (dsUser != null && dsUser.Tables[0].Rows.Count > 0)
        {
            if (Convert.ToBoolean(dsUser.Tables[0].Rows[0]["user_isenabled"]))
            {
                Session["User"] = dsUser;
                DataRow drUser = dsUser.Tables[0].Rows[0];
               txtUserName.Text = string.Empty;
               txtPassword.Text = string.Empty;
               if (Convert.ToString(dsUser.Tables[0].Rows[0]["user_type"]).Equals("ADMIN", StringComparison.OrdinalIgnoreCase))
                        Response.Redirect("AdminPage.aspx");
                    else
                        Response.Redirect("UserPage.aspx");
                //RedirectByAccess();
            }
            else
            {
                lblError.Text = "Incorrect password.";
                lblError.Enabled = true;
                lblError.Visible = true;
            }
        }
        else
        {
            
            lblError.Text = "Invalid username or password.";
            lblError.Enabled = true;
            lblError.Visible = true;
            //Response.Redirect("home.aspx");
        }
        
    }

    protected void btlogin_Click(object sender, EventArgs e)
    {
        ValidateLogin(txtUserName.Text.Trim(), txtPassword.Text.Trim());
    }


}
/*
using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

public partial class how_to_login_with_sql_server_c : System.Web.UI.Page
{
    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        string username = Login1.UserName;
        string pwd = Login1.Password;

         test9.mobilewebserviceSoapClient ws = new test9.mobilewebserviceSoapClient();

          DataSet ds = ws.VTOGetAllAccount();
       

      string strConn;
        strConn = WebConfigurationManager.ConnectionStrings["ConnectionASPX"].ConnectionString;
        SqlConnection Conn = new SqlConnection(strConn);
        Conn.Open();

        string sqlUserName;
        sqlUserName = "SELECT UserName,Password FROM UserName ";
        sqlUserName += " WHERE (UserName ='" + username + "')";
        sqlUserName += " AND (Password ='" + pwd + "')";
        SqlCommand com = new SqlCommand(sqlUserName, Conn);
      
        string CurrentName;
        CurrentName = (string)com.ExecuteScalar();

        if (CurrentName != null)
        {
            Session["UserAuthentication"] = username;
            Session.Timeout = 1;
            Response.Redirect("how-to-StartPage.aspx");
        }
        else
        {
            Session["UserAuthentication"] = "";
        }
    }
}*/
