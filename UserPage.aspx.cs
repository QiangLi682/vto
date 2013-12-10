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
    private test9.mobilewebserviceSoapClient ws;

    public static int user_accoutnID; 
    public static string selected_framename; // do not know why only private does not work

    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user"] == null)
        {
            Response.Redirect("Home.aspx");
        }

        DataSet dsUser = (DataSet)Session["user"];

        user_accoutnID = Convert.ToInt32(dsUser.Tables[0].Rows[0]["user_accountID"]);
   
        ws = new test9.mobilewebserviceSoapClient();

        if (!IsPostBack)
        {
            BindData();


        }

     
    }

    private void BindData()
    {

       // DataSet dsUser = (DataSet)Session["user"];
        //Response.Write(Convert.ToString(dsUser.Tables[0].Rows[0]["user_name"]) + Convert.ToString(dsUser.Tables[0].Rows[0]["user_accountID"]));

        //DataSet ds = ws.VTOGetBrandInfoByAccountID(Convert.ToInt32(dsUser.Tables[0].Rows[0]["user_accountID"]));

        DataSet ds = ws.VTOGetBrandInfoByAccountID(user_accoutnID);
        
        UserView.DataSource = ds;
        UserView.DataBind();

    }

    protected void DeleteAllBrand(object sender, EventArgs e)
    {
        int a = 0;
        
    }

    private void BindThumbnailData(int user_accoutnID, string selected_framename)
    {
         DataSet ds = ws.VTOSelectThumbnail(user_accoutnID, selected_framename);

        
        DataTable dt = new DataTable();
        // define the table's schema
        dt.Columns.Add(new DataColumn("PictureURL", typeof(string)));
        dt.Columns.Add(new DataColumn("Name", typeof(string)));
        dt.Columns.Add(new DataColumn("ImageFileName", typeof(string)));
        dt.Columns.Add(new DataColumn("FrameID", typeof(Int32)));
        
        // Create the four records
        
        for (int i=0; i < ds.Tables[0].Rows.Count; i++)
        {
            DataRow dr = dt.NewRow();
            Int32 FrameID = Convert.ToInt32(ds.Tables[0].Rows[i]["FrameID"]);
           
            string framename = Convert.ToString(ds.Tables[0].Rows[i]["Name"]);
            string thumbnailName = Convert.ToString(ds.Tables[0].Rows[i]["ImageNameThumbnail"]);
           // https://test9.optisuite.mobi/ShowFrameImagesForBrand.aspx?imageName=testxyz_frames_[t]_[0]_[][]_[][].jpg
            string url = "https://test9.optisuite.mobi/ShowFrameImagesForBrand.aspx?imageName=" + thumbnailName;
            dr["PictureURL"] = ResolveUrl(url);
            dr["Name"] = framename;
            dr["ImageFileName"] = thumbnailName;
            dr["FrameID"] = FrameID; 
            
            dt.Rows.Add(dr);

        }


        ThumbNailView.DataSource = dt;
        ThumbNailView.DataBind();
    }
    protected void ShowAllImage(object sender, EventArgs e)
    {
        ws = new test9.mobilewebserviceSoapClient();

        LinkButton lnkShowAllImage = (LinkButton)sender;

        selected_framename = Convert.ToString(lnkShowAllImage.CommandArgument);

        BindThumbnailData(user_accoutnID, selected_framename);

    }

   
    protected void DeleteSelectedBrand(object sender, EventArgs e)
    {


        LinkButton lnkRemoveBrand = (LinkButton)sender;

        //DataSet dsUser = (DataSet)Session["user"];
        //Response.Write(Convert.ToString(dsUser.Tables[0].Rows[0]["user_name"]) + Convert.ToString(dsUser.Tables[0].Rows[0]["user_accountID"]));

        ws = new test9.mobilewebserviceSoapClient();


        if (ws.VTODeleteSelectedBrand(user_accoutnID, Convert.ToString(lnkRemoveBrand.CommandArgument)))

            BindData();



    }



    protected void OnUserPaging(object sender, GridViewPageEventArgs e)
    {
        BindData();

        UserView.PageIndex = e.NewPageIndex;
        UserView.DataBind();
    }
    
    protected void OnThumbNailPaging(object sender, GridViewPageEventArgs e)
    {
        BindThumbnailData(user_accoutnID, selected_framename);
        ThumbNailView.PageIndex = e.NewPageIndex;
        ThumbNailView.DataBind();
    }

    protected void DeleteFrame(object sender, EventArgs e)
    {

        LinkButton lnkremoveframe = (LinkButton)sender;

        Int32 frameID = Convert.ToInt32(lnkremoveframe.CommandArgument);
        // ws to remove this frameID

               
        BindThumbnailData(user_accoutnID, selected_framename);
   

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Session["user"] = null;

        Response.Redirect("Home.aspx");
    }
}