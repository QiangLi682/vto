<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminPage.aspx.cs" Inherits="AdminHome" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mint Admin Page</title>
    <script type = "text/javascript" src = "scripts/jquery-1.3.2.min.js"></script>
<script type = "text/javascript" src = "scripts/jquery.blockUI.js"></script>
<script type = "text/javascript">
    function BlockUI(elementID) {
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

        BlockUI("dvGrid");
        $.blockUI.defaults.css = {};
    });
</script> 
</head>
<body>
    <form id="form1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <!--  

   make a certain part of my website without postback when the user click a button
            -->
 <div id = "dvGrid" style ="padding:10px;width:550px">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
       <asp:GridView ID="GridView1" runat="server"  Width = "550px"
        AutoGenerateColumns = "false" Font-Names = "Arial" 
        Font-Size = "11pt" AlternatingRowStyle-BackColor = "#C2D69B"  
        HeaderStyle-BackColor = "green" AllowPaging ="true"  ShowFooter = "true"  
        PageSize = "10"
        OnPageIndexChanging = "OnPaging" onrowediting="EditAccount"
        onrowupdating="UpdateAccount"  onrowcancelingedit="CancelEdit">
      <Columns>

             <asp:TemplateField ItemStyle-Width = "30px"  HeaderText = "account_id">
            <ItemTemplate>
                <asp:Label ID="lblaccount_id" runat="server" Text='<%# Eval("account_id")%>'></asp:Label>
            </ItemTemplate>
            </asp:TemplateField> 

        <asp:TemplateField ItemStyle-Width = "30px"  HeaderText = "account_bname">
            <ItemTemplate>
                <asp:Label ID="lblaccount_bname" runat="server" Text='<%# Eval("account_bname")%>'></asp:Label>
            </ItemTemplate> 
            <EditItemTemplate>
                <asp:TextBox ID="txtaccount_bname" runat="server" Text='<%# Eval("account_bname")%>'></asp:TextBox>
            </EditItemTemplate>  
            <FooterTemplate>
                <asp:TextBox ID="txtaccount_bname" runat="server"></asp:TextBox>
            </FooterTemplate> 

        </asp:TemplateField> 
        <asp:TemplateField ItemStyle-Width = "100px"  HeaderText = "account_fname">
            <ItemTemplate>
                <asp:Label ID="lblaccount_fname" runat="server" Text='<%# Eval("account_fname")%>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtaccount_fname" runat="server" Text='<%# Eval("account_fname")%>'></asp:TextBox>
            </EditItemTemplate>  
            <FooterTemplate>
                <asp:TextBox ID="txtaccount_fname" runat="server"></asp:TextBox>
            </FooterTemplate> 
        </asp:TemplateField>
        <asp:TemplateField ItemStyle-Width = "150px"  HeaderText = "account_lname">
            <ItemTemplate>
                <asp:Label ID="lblaccount_lname" runat="server" Text='<%# Eval("account_lname")%>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtaccount_lname" runat="server" Text='<%# Eval("account_lname")%>'></asp:TextBox>
            </EditItemTemplate>  
            <FooterTemplate>
                <asp:TextBox ID="txtaccount_lname" runat="server"></asp:TextBox>
            </FooterTemplate> 
        </asp:TemplateField>
           <asp:TemplateField ItemStyle-Width = "150px"  HeaderText = "account_phone">
            <ItemTemplate>
                <asp:Label ID="lblaccount_phone" runat="server" Text='<%# Eval("account_phone")%>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtaccount_phone" runat="server" Text='<%# Eval("account_phone")%>'></asp:TextBox>
            </EditItemTemplate>  
            <FooterTemplate>
                <asp:TextBox ID="txtaccount_phone" runat="server"></asp:TextBox>
            </FooterTemplate> 
        </asp:TemplateField>
           <asp:TemplateField ItemStyle-Width = "150px"  HeaderText = "account_email">
            <ItemTemplate>
                <asp:Label ID="lblaccount_email" runat="server" Text='<%# Eval("account_email")%>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtaccount_email" runat="server" Text='<%# Eval("account_email")%>'></asp:TextBox>
            </EditItemTemplate>  
            <FooterTemplate>
                <asp:TextBox ID="txtaccount_email" runat="server"></asp:TextBox>
            </FooterTemplate> 
        </asp:TemplateField>
           <asp:TemplateField ItemStyle-Width = "150px"  HeaderText = "account_icon">
            <ItemTemplate>
                <asp:Label ID="lblaccount_icon" runat="server" Text='<%# Eval("account_icon")%>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtaccount_icon" runat="server" Text='<%# Eval("account_icon")%>'></asp:TextBox>
            </EditItemTemplate>  
            <FooterTemplate>
                <asp:TextBox ID="txtaccount_icon" runat="server"></asp:TextBox>
            </FooterTemplate> 
        </asp:TemplateField>

               <asp:TemplateField ItemStyle-Width = "150px"  HeaderText = "account_url">
            <ItemTemplate>
                <asp:Label ID="lblaccount_url" runat="server" Text='<%# Eval("account_url")%>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtaccount_url" runat="server" Text='<%# Eval("account_url")%>'></asp:TextBox>
            </EditItemTemplate>  
            <FooterTemplate>
                <asp:TextBox ID="txtaccount_url" runat="server"></asp:TextBox>
            </FooterTemplate> 
        </asp:TemplateField>
           


            <asp:TemplateField ItemStyle-Width = "150px"  HeaderText = "account_startdate">
            <ItemTemplate>
                <asp:Label ID="lblaccount_startdate" runat="server" Text='<%# Eval("account_startdate")%>'></asp:Label>
            </ItemTemplate>
        
                          
        </asp:TemplateField>
                <asp:TemplateField ItemStyle-Width = "150px"  HeaderText = "account_enabled">
            <ItemTemplate>
                <asp:Label ID="lblaccount_enabled" runat="server" Text='<%# Eval("account_enabled")%>'></asp:Label>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtaccount_enabled" runat="server" Text='<%# Eval("account_enabled")%>'></asp:TextBox>
            </EditItemTemplate>  
            <FooterTemplate>
                <asp:TextBox ID="txtaccount_enabled" runat="server"></asp:TextBox>
            </FooterTemplate> 
        </asp:TemplateField>
        
        <asp:TemplateField>
            <ItemTemplate>
                <asp:LinkButton ID="lnkRemove" runat="server" CommandArgument = '<%# Eval("account_id")%>' 
                 OnClientClick = "return confirm('Do you want to delete?')"
                Text = "Delete" OnClick = "DeleteAccount"></asp:LinkButton>
            </ItemTemplate>
             <FooterTemplate>
                <asp:Button ID="btnAdd" runat="server" Text="Add" OnClick = "AddNewAccount" />
            </FooterTemplate> 
        </asp:TemplateField> 

          

        <asp:CommandField  ShowEditButton="True" /> 
       </Columns> 
       <AlternatingRowStyle BackColor="#C2D69B"  />
    </asp:GridView> 
    <asp:Label ID="lblmsg" runat="server" CssClass="bold" ForeColor="#0033CC"></asp:Label>
    </ContentTemplate> 
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID = "GridView1" /> 
    </Triggers> 
    </asp:UpdatePanel> 

    </div>
     
          
   
    </form>
</body>
</html>
