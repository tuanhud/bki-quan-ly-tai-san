<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="F901_danh_muc_don_vi.aspx.cs" Inherits="DanhMuc_F901_danh_muc_don_vi" %>

<%@ Register Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"
    TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table cellspacing="0" cellpadding="2" style="width: 99%;" class="cssTable" border="0">
                <tr>
                    <td class="cssPageTitleBG" colspan="4">
                        <span class="cssPageTitle">Danh mục đơn vị</span> <span class="expand-collapse-text initial-expand">
                        </span><span class="expand-collapse-text"></span>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label6" CssClass="cssManField" runat="server" Text="Mã đơn vị" />
                    </td>
                    <td>
                        <asp:TextBox ID="m_txt_ma_don_vi" CssClass="cssTextBox" runat="server" MaxLength="25"
                            Width="200px" />
                    </td>
                    <td align="right">
                        <asp:Label ID="Label7" CssClass="cssManField" runat="server" Text="Tên đơn vị" />
                    </td>
                    <td>
                        <asp:TextBox ID="m_txt_ten_don_vi" CssClass="cssTextBox" runat="server" MaxLength="50"
                            Width="200px" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label8" CssClass="cssManField" runat="server" Text="Loại hình đơn vị" />
                    </td>
                    <td>
                        <asp:TextBox ID="m_txt_loai_hinh_don_vi" CssClass="cssTextBox" runat="server" MaxLength="25"
                            Width="200px" />
                    </td>
                    <td align="right">
                        <asp:Label ID="Label9" CssClass="cssManField" runat="server" Text="Đơn vị cấp trên" />
                    </td>
                    <td>
                        <asp:DropDownList ID="m_cbo_don_vi_cap_tren" runat="server" Width="264px" CssClass="cssDorpdownlist"
                            AutoPostBack="true" 
                            onselectedindexchanged="m_cbo_don_vi_cap_tren_SelectedIndexChanged" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label10" CssClass="cssManField" runat="server" Text="STT" />
                    </td>
                    <td>
                        <asp:TextBox ID="m_txt_stt" CssClass="cssTextBox" runat="server" MaxLength="25" Width="200px" />
                    </td>
                    <td align="right">
                        <asp:Label ID="Label11" CssClass="cssManField" runat="server" Text="Level Mode" />
                    </td>
                    <td>
                        <asp:TextBox ID="m_txt_level_mode" CssClass="cssTextBox" runat="server" MaxLength="25"
                            Width="200px" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <asp:Label ID="Label12" CssClass="cssManField" runat="server" Text="Loại đơn vị" />
                    </td>
                    <td>
                        <asp:DropDownList ID="m_cbo_loai_don_vi" runat="server" Width="264px" CssClass="cssDorpdownlist"
                            AutoPostBack="true" 
                            onselectedindexchanged="m_cbo_loai_don_vi_SelectedIndexChanged" />
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="4">
                        <asp:Button ID="m_cmd_tao_moi" AccessKey="c" CssClass="cssButton" runat="server"
                            Width="98px" Text="Tạo mới(c)" onclick="m_cmd_tao_moi_Click" />&nbsp;
                        <asp:Button ID="m_cmd_cap_nhat" AccessKey="u" CssClass="cssButton" runat="server"
                            Width="98px" Text="Cập nhật(u)" onclick="m_cmd_cap_nhat_Click" />&nbsp;
                        <asp:Button ID="btnCancel" AccessKey="r" CssClass="cssButton" runat="server" Width="98px"
                            Text="Xóa trắng(r)" onclick="btnCancel_Click" />
                    </td>
                </tr>
            </table>
            <table cellspacing="0" cellpadding="2" style="width: 100%;" class="cssTable" border="0">
                <tr>
                    <td class="cssPageTitleBG">
                        <span class="cssPageTitle">Danh mục đơn vị</span> <span class="expand-collapse-text initial-expand">
                        </span><span class="expand-collapse-text"></span>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:Label ID="m_lbl_mess" Visible="False" runat="server" CssClass="cssManField" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:HiddenField ID="m_hdf_id_don_vi" runat="server" Visible="False" />
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:GridView ID="m_grv_dm_don_vi" runat="server" AutoGenerateColumns="False" Width="80%"
                            DataKeyNames="ID" AllowPaging="True" PageSize="15" CellPadding="4" ForeColor="#333333"
                            CssClass="cssGrid" OnRowDeleting="m_grv_dm_don_vi_RowDeleting" OnSelectedIndexChanging="m_grv_dm_don_vi_SelectedIndexChanging"
                            OnPageIndexChanging="m_grv_dm_don_vi_PageIndexChanging" 
                            onrowupdating="m_grv_dm_don_vi_RowUpdating" >
                            <PagerSettings Position="TopAndBottom" />
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:CommandField SelectText="Sửa" ShowSelectButton="True" 
                                    ItemStyle-HorizontalAlign="Center" Visible="False">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:CommandField>
                                <asp:TemplateField HeaderText="Sửa" HeaderStyle-Width="3%">
                            <ItemTemplate>
                                <asp:LinkButton ToolTip="Sửa" ID="m_lbt_edit" CommandName="Update" runat="server">
                                <img src="../Images/Button/edit.png" alt="Update" align="middle"/>
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                                <asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %></ItemTemplate>
                                    <HeaderStyle Width="15px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:BoundField DataField="MA_DON_VI" ItemStyle-HorizontalAlign="Center" HeaderText="Mã đơn vị">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TEN_DON_VI" HeaderText="Tên đơn vị"></asp:BoundField>
                                <asp:BoundField DataField="LOAI_HINH_DON_VI" HeaderText="Loại hình đơn vị" />
                                <asp:BoundField DataField="ID_DON_VI_CAP_TREN" HeaderText="Đơn vị cấp trên" />
                                <asp:CommandField DeleteText="Xóa" ShowDeleteButton="True" 
                                    ItemStyle-HorizontalAlign="Center" Visible="False">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:CommandField>
                            </Columns>
                            <EditRowStyle BackColor="#7C6F57" />
                            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#810c15" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#E3EAEB" />
                            <SelectedRowStyle CssClass="cssSelectedRow" BackColor="#C5BBAF" Font-Bold="True"
                                ForeColor="#333333"></SelectedRowStyle>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
