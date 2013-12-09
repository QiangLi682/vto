using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class AdminHome : System.Web.UI.Page
{
    private test9.mobilewebserviceSoapClient ws;
    static int nSelected_account_id = 1; // this is MINT
     
    protected void Page_Load(object sender, EventArgs e)
    {


        if (Session["user"] == null)
        {
            Response.Redirect("Home.aspx");
        }
        
        ws = new test9.mobilewebserviceSoapClient();
        if (!IsPostBack)
        {
            BindData();

           
        }
    }

    private void BindData()
    {


        DataSet ds = ws.VTOGetAllAccount();
        GridView1.DataSource = ds;
        GridView1.DataBind();

    }
      

    protected void DeleteAccount(object sender, EventArgs e)
    {
        LinkButton lnkRemove = (LinkButton)sender;

        bool result = lnkRemove.CommandArgument.Equals("1", StringComparison.OrdinalIgnoreCase);

        if (result)
        {
            lblmsg.Text = "Can not delete MINT ADMIN account";
            return;

        }
        DataSet ds = ws.VTODeleteAccountByID(Convert.ToInt32(lnkRemove.CommandArgument));
        if (ds == null)
        {
            lblmsg.Text = "exeption happend in sql detele";
            return;
        }

        GridView1.DataSource = ds;
        GridView1.DataBind();

        lblmsg.Text = "Delete accountID " + lnkRemove.CommandArgument ;

    }

    protected void AddNewAccount(object sender, EventArgs e)
    {
      

        string bname = ((TextBox)GridView1.FooterRow.FindControl("txtaccount_bname")).Text;
        if (string.IsNullOrEmpty(bname)) { lblmsg.Text = "empty account_bname"; return; }

        string fname = ((TextBox)GridView1.FooterRow.FindControl("txtaccount_fname")).Text;
        if (string.IsNullOrEmpty(bname)) { lblmsg.Text = "empty account_fname"; return; }

        string lname = ((TextBox)GridView1.FooterRow.FindControl("txtaccount_lname")).Text;
        if (string.IsNullOrEmpty(bname)) { lblmsg.Text = "empty account_lname"; return; }

        string phone = ((TextBox)GridView1.FooterRow.FindControl("txtaccount_phone")).Text;
        if (string.IsNullOrEmpty(bname)) { lblmsg.Text = "empty account_phone"; return; }

        string email = ((TextBox)GridView1.FooterRow.FindControl("txtaccount_email")).Text;
        if (string.IsNullOrEmpty(bname)) { lblmsg.Text = "empty account_email"; return; }

        string icon = ((TextBox)GridView1.FooterRow.FindControl("txtaccount_icon")).Text;
        if (string.IsNullOrEmpty(bname)) { lblmsg.Text = "empty account_icon"; return; }

        string url = ((TextBox)GridView1.FooterRow.FindControl("txtaccount_url")).Text;
        if (string.IsNullOrEmpty(bname)) { lblmsg.Text = "empty account_url"; return; }

        // do not know why I can not read the datastring
        // string startdate = ((TextBox)GridView1.FooterRow.FindControl("lblaccount_startdate")).Text;
        string enabled = ((TextBox)GridView1.FooterRow.FindControl("txtaccount_enabled")).Text;
        if (string.IsNullOrEmpty(bname)) { lblmsg.Text = "empty account_enalbed"; return; }

        
        bool result = enabled.Equals("true", StringComparison.OrdinalIgnoreCase);


        DataSet ds = ws.VTOAddNewAccountDefaultUser(bname, fname, lname, phone, email, icon, url, result);
        GridView1.DataSource = ds;
        GridView1.DataBind();


        lblmsg.Text = "add new account for " + bname;
      }

    protected void OnPaging(object sender, GridViewPageEventArgs e)
    {
        BindData();
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataBind();
        lblmsg.Text = "";
    }

    protected void EditAccount(object sender, GridViewEditEventArgs e)
    {
        GridView1.EditIndex = e.NewEditIndex;
        BindData();
        lblmsg.Text = "";
    }
    protected void CancelEdit(object sender, GridViewCancelEditEventArgs e)
    {
        GridView1.EditIndex = -1;
        BindData();
        lblmsg.Text = "";
    }
    protected void UpdateAccount(object sender, GridViewUpdateEventArgs e)
    {

       
       string account_id = ((Label)GridView1.Rows[e.RowIndex].FindControl("lblaccount_id")).Text;
       string bname = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtaccount_bname")).Text;
       string fname = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtaccount_fname")).Text;
       string lname = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtaccount_lname")).Text;
       string phone = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtaccount_phone")).Text;
       string email = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtaccount_email")).Text;
       string icon = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtaccount_icon")).Text;
       string url = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtaccount_url")).Text;
        // do not know why I can not read the datastring
      // string startdate = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("lblaccount_startdate")).Text;
       string enabled = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("txtaccount_enabled")).Text;

        int id = Convert.ToInt32(account_id);

        bool result = enabled.Equals("true", StringComparison.OrdinalIgnoreCase);
        
   
       
        GridView1.EditIndex = -1;
        DataSet ds = ws.VTOUpdateAccount(id, bname, fname, lname, phone, email, icon, url, result);
        GridView1.DataSource = ds;
        GridView1.DataBind();

        lblmsg.Text = "update accountID " + account_id + " successfully";
    }


    protected void ManageUsers(object sender, EventArgs e)
    {


        LinkButton lnkUsers = (LinkButton)sender;
        

        nSelected_account_id  = Convert.ToInt32(lnkUsers.CommandArgument);

        BindDataUser(nSelected_account_id);




    }

    private void BindDataUser(int account_id)
    {

        DataSet ds = ws.VTOSelectUersByAccountId(account_id);
        GridView2.DataSource = ds;

        //lbluser.Text = Convert.ToString(ds.Tables[0].Rows[0]["user_type"]);

        //lbluser.Text = Convert.ToString(ds.Tables[0].Rows[0]["user_password"]);
        try
        {
            GridView2.DataBind();
        }
        catch (Exception e)
        {
            int a = 1; // some exception for the password;
        }
       
    }
    protected void OnPagingUser(object sender, GridViewPageEventArgs e)
    {
        BindDataUser(nSelected_account_id);
        GridView2.PageIndex = e.NewPageIndex;
        GridView2.DataBind();

    }

     protected void EditUser(object sender, GridViewEditEventArgs e)
    {
        GridView2.EditIndex = e.NewEditIndex;
        BindDataUser(nSelected_account_id);

        ((TextBox)GridView2.Rows[GridView2.EditIndex].FindControl("txtuser_password")).Text = "new password";
        
    }
    protected void CancelEditUser(object sender, GridViewCancelEditEventArgs e)
    {
        GridView2.EditIndex = -1;
        BindDataUser(nSelected_account_id);
      
    }
    protected void UpdateUser(object sender, GridViewUpdateEventArgs e)
    {

        string user_id = ((Label)GridView2.Rows[e.RowIndex].FindControl("lbluser_id")).Text;
        string username = ((TextBox)GridView2.Rows[e.RowIndex].FindControl("txtuser_name")).Text;
        string enabled = ((TextBox)GridView2.Rows[e.RowIndex].FindControl("txtuser_isenabled")).Text;
        string password = ((TextBox)GridView2.Rows[e.RowIndex].FindControl("txtuser_password")).Text;
        string type = ((TextBox)GridView2.Rows[e.RowIndex].FindControl("txtuser_type")).Text;


        int id = Convert.ToInt32(user_id);

        bool result = enabled.Equals("true", StringComparison.OrdinalIgnoreCase);

        // public DataSet VTOUpdateUserByID(int user_id, string user_name, string user_password, string user_type, bool user_isenabled,int account_id)

        GridView2.EditIndex = -1;
        DataSet ds;
      
        ds = ws.VTOUpdateUserByID(id, username, password, type, result, nSelected_account_id);
        GridView2.DataSource = ds;
  try
        {
       
            GridView2.DataBind();
        }
        catch (Exception ex)
        {
            int a = 1; // some exception for the password;
        }

       

    }

    protected void DeleteUser(object sender, EventArgs e)
    {
        LinkButton lnkRemoveUser = (LinkButton)sender;


        DataSet ds = ws.VTODeleteUserByID(Convert.ToInt32(lnkRemoveUser.CommandArgument),nSelected_account_id);
        if (ds == null)
        {
            lblmsg.Text = "can not delete the only user for the account";
            return;
        }
        GridView2.DataSource = ds;

        try
        {
            GridView2.DataBind();
        }
        catch (Exception ex)
        {
            int a = 1; // some exception for the password;
        }


    }

    protected void AddNewUser(object sender, EventArgs e)
    {
        //  public DataSet VTOAddNewUserByAccountID(string user_name, string user_password, string user_type, bool  user_isenabled, int user_accountID)
   
        string username = ((TextBox)GridView2.FooterRow.FindControl("txtuser_name")).Text;
        if (string.IsNullOrEmpty(username)) { lblmsg.Text = "empty username"; return; }

        string userpassword = ((TextBox)GridView2.FooterRow.FindControl("txtuser_password")).Text;
        if (string.IsNullOrEmpty(userpassword)) { lblmsg.Text = "empty password"; return; }

        string usertype = ((TextBox)GridView2.FooterRow.FindControl("txtuser_type")).Text;
        if (string.IsNullOrEmpty(usertype)) { lblmsg.Text = "empty user_type"; return; }

        string enabled = ((TextBox)GridView2.FooterRow.FindControl("txtuser_isenabled")).Text;
        if (string.IsNullOrEmpty(enabled)) { lblmsg.Text = "empty enalbed"; return; }


    

        bool result = enabled.Equals("true", StringComparison.OrdinalIgnoreCase);

        DataSet ds = ws.VTOAddNewUserByAccountID(username, userpassword, usertype, result, nSelected_account_id);
        GridView2.DataSource = ds;

        try
        {
            GridView2.DataBind();
        }
        catch (Exception ex)
        {
            int a = 1; // some exception for the password;
        }

        GridView2.DataBind();


    }
    protected void Button1_Click(object sender, EventArgs e)
    {
            Session["user"] = null;

            Response.Redirect("Home.aspx");

    }
}