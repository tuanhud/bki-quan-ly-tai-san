<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Account_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">

    <script type="text/javascript">
    // Hàm này dùng để check all checkbox trên lưới
    function SelectAllCheckboxes(spanChk) {
        // Added as ASPX uses SPAN for checkbox
        var oItem = spanChk.children;
        var theBox = (spanChk.type == "checkbox") ? spanChk : spanChk.children.item[0];
        xState = theBox.checked;
        elm = theBox.form.elements;

        for (i = 0; i < elm.length; i++)
            if (elm[i].type == "checkbox" && elm[i].id != theBox.id) {
                if (elm[i].checked != xState)
                    elm[i].click();
            }
    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <asp:GridView ID="m_grv_danh_sach_nha" runat="server" AutoGenerateColumns="False"
                Width="100%" DataKeyNames="ID" ShowFooter="true"
                CellPadding="4" ForeColor="#333333" 
                AllowPaging="True" AllowSorting="True" PageSize="35" >
                  <AlternatingRowStyle BackColor="White" />
                <Columns>

                 <asp:TemplateField>
                  <HeaderTemplate> <!-- Header checkbox --> 
                   <input type="checkbox" id="chkAll" onclick="javascript:SelectAllCheckboxes(this)" runat="server" />
                  </HeaderTemplate>                 
                  <ItemTemplate>  <!-- cái này là checkbox, hiểu là dữ liệu của cột --> 
                    <asp:CheckBox runat="server" ID="chkItem" ToolTip='<%# Eval("ID") %>' />
                    <asp:CheckBox runat="server" ID="chkTrangThai" Visible="false" />
                  </ItemTemplate>
                  <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>

                    <asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center">
                       <ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                </Columns>
                  <EditRowStyle BackColor="#7C6F57" />
                  <FooterStyle BackColor="#810c15" Font-Bold="True" ForeColor="White"  />
                  <HeaderStyle BackColor="#810c15" Font-Bold="True" ForeColor="White" />
                  <PagerSettings Position="TopAndBottom" />
                  <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                  <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle CssClass="cssSelectedRow" BackColor="#C5BBAF" Font-Bold="True" 
                      ForeColor="#333333"></SelectedRowStyle>
            </asp:GridView>
            <asp:Button ID="m_cmd_hien_thi_id" runat="server" Text="Click" OnClick="m_cmd_hien_thi_id_Click" />
</asp:Content>

