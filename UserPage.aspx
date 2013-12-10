<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserPage.aspx.cs" Inherits="UserPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>User Page</title>
    <script type = "text/javascript" src = "scripts/jquery-1.3.2.min.js"></script>
<script type = "text/javascript" src = "scripts/jquery.blockUI.js"></script>
<script type = "text/javascript">
    function BlockUserUI(elementID) {
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_beginRequest(function () {
            $("#" + elementID).block({
                message: '<table align = "center"><tr><td>' +
                 '<img src="images/loadingAnim.gif"/></td></tr></table>',
                css: {},
                overlayCSS: {
                    backgroundColor: '#000000', opacity: 0.6, border: '3px solid #63B2EB'
                }
            });
        });
        prm.add_endRequest(function () {
            $("#" + elementID).unblock();
        });
    }
    $(document).ready(function () {

        BlockUserUI("dvGridUser");

        $.blockUI.defaults.css = {};
    });
</script> 


</head>
<body>



    

    <form id="form1" runat="server">
    
       
        
         <asp:ScriptManager ID="ScriptManagerUser" runat="server">
        </asp:ScriptManager>
        <!--  

   make a certain part of my website without postback when the user click a button
            -->
 
      <div id = "dvGridUser" style ="padding:10px;width:550px">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Logout" />
       <asp:GridView ID="UserView" runat="server"  Width = "550px"
        AutoGenerateColumns = "false" Font-Names = "Arial" 
        Font-Size = "11pt" AlternatingRowStyle-BackColor = "#C2D69B"  
        HeaderStyle-BackColor = "white" AllowPaging ="true"  ShowFooter = "true"  
             PageSize = "10"
        OnPageIndexChanging = "OnUserPaging"
         
        >
      <Columns>
            <asp:TemplateField ItemStyle-Width = "30px"  HeaderText = "Customer">
            <ItemTemplate>
                <asp:Label ID="lblCustermer" runat="server" Text='<%# Eval("Framemanufacturer")%>'></asp:Label>
            </ItemTemplate>
            </asp:TemplateField> 

          
          
           <asp:TemplateField ItemStyle-Width = "30px"  HeaderText = "BrandName">
            <ItemTemplate>
                <asp:Label ID="lbBrandName" runat="server" Text='<%# Eval("BrandName")%>'></asp:Label>
            </ItemTemplate>
            </asp:TemplateField> 


             <asp:TemplateField ItemStyle-Width = "30px"  HeaderText = "NumOfFrames">
            <ItemTemplate>
                <asp:Label ID="lblNumOfFrames" runat="server" Text='<%# Eval("NumOfFrames")%>'></asp:Label>
            </ItemTemplate>
            </asp:TemplateField> 

          
            <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton ID="lnkShowAllImage" runat="server" CommandArgument = '<%# Eval("BrandName")%>' 
                Text = "ShowAllImage" OnClick = "ShowAllImage"></asp:LinkButton>
            </ItemTemplate>
                </asp:TemplateField>

            <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton ID="lnkRemoveBrand" runat="server" CommandArgument = '<%# Eval("BrandName")%>' 
                 OnClientClick = "return confirm('Do you want to delete this brand?')"
                Text = "Delete" OnClick = "DeleteSelectedBrand"></asp:LinkButton>
            </ItemTemplate>
             <FooterTemplate>
                <asp:Button ID="btnDeleteAllBrand" runat="server" OnClientClick = "return confirm('Do you want to delete?')" Text="DeleteAll" OnClick = "DeleteAllBrand" />
            </FooterTemplate> 
        </asp:TemplateField> 
       </Columns> 
       <AlternatingRowStyle BackColor="#C2D69B"  />
    </asp:GridView> 
    <asp:Label ID="lbluser" runat="server" CssClass="bold" ForeColor="#0033CC"></asp:Label>
    </ContentTemplate> 
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID = "UserView" /> 
    </Triggers> 
    </asp:UpdatePanel> 
  </div>
     


        <div id = "Div1" style ="padding:10px;width:550px">
        <asp:UpdatePanel ID="UpdatePanelThumbnail" runat="server">
        <ContentTemplate>
       <asp:GridView ID="ThumbNailView" runat="server"  Width = "550px"
        AutoGenerateColumns = "false" Font-Names = "Arial" 
        Font-Size = "11pt" AlternatingRowStyle-BackColor = "#C2D69B"  
        HeaderStyle-BackColor = "white" AllowPaging ="true"  ShowFooter = "true"  
             PageSize = "10"        OnPageIndexChanging = "OnThumbNailPaging"
        >
      <Columns>
          
          <asp:BoundField HeaderText="FrameID" DataField="FrameID"></asp:BoundField>
        
          <asp:BoundField HeaderText="FrameName" DataField="Name"></asp:BoundField>
        
          <asp:BoundField HeaderText="ImageFileName" DataField="ImageFileName"></asp:BoundField>
        
          <asp:ImageField DataImageUrlField="PictureURL"></asp:ImageField>

            <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton ID="lnkRemoveFrame" runat="server" CommandArgument = '<%# Eval("FrameID")%>' 
                 OnClientClick = "return confirm('Do you want to delete this frame?')"
                Text = "Delete" OnClick = "DeleteFrame"></asp:LinkButton>
            </ItemTemplate>
             
        </asp:TemplateField> 

          
       </Columns> 
       <AlternatingRowStyle BackColor="#C2D69B"  />
    </asp:GridView> 
    <asp:Label ID="Label1" runat="server" CssClass="bold" ForeColor="#0033CC"></asp:Label>
    </ContentTemplate> 
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID = "ThumbNailView" /> 
    </Triggers> 
    </asp:UpdatePanel> 
  </div>
          
   
    </form>
</body>
</html>