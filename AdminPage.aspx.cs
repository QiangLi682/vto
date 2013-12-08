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
     
    protected void Page_Load(object sender, EventArgs e)
    {
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
        /*LinkButton lnkRemove = (LinkButton)sender;
        SqlConnection con = new SqlConnection(strConnString);
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "delete from  customers where " +
        "CustomerID=@CustomerID;" +
         "select CustomerID,ContactName,CompanyName from customers";
        cmd.Parameters.Add("@CustomerID", SqlDbType.VarChar).Value = lnkRemove.CommandArgument;
        GridView1.DataSource = GetData(cmd);
        GridView1.DataBind(); */
        LinkButton lnkRemove = (LinkButton)sender;
        DataSet ds = ws.VTODeleteAccountByID(Convert.ToInt32(lnkRemove.CommandArgument));
        if (ds == null)
        {
            lblmsg.Text = "Delete Users under this account first";
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


        DataSet ds = ws.VTOAddNewAccount(bname, fname, lname, phone, email, icon, url, result);
        GridView1.DataSource = ds;
        GridView1.DataBind();


        lblmsg.Text = "add new account for " + bname;
      }

    protected void ManageUsers(object sender, EventArgs e)
    {

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


    
}