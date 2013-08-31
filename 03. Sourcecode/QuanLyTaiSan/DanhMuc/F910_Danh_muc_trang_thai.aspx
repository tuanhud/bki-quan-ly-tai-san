<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="F910_Danh_muc_trang_thai.aspx.cs" Inherits="DanhMuc_F910_Danh_muc_trang_thai" %>

<%@ Register Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"
    TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .style2
        {
            height: 37px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table cellspacing="0" cellpadding="2" style="width: 100%;" class="cssTable" border="0">
                    <tr>
                        <td class="cssPageTitleBG" colspan="4">
                            <asp:Label ID="lblUser0" runat="server" CssClass="cssPageTitle" Text="Quản lý trạng thái" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="m_lbl_loai_tai_san_detail0" runat="server" CssClass="cssManField"
                                Text="Loại" />
                        </td>
                        <td>
                            <asp:DropDownList ID="m_cbo_loai_tai_san_detail" runat="server" Width="98%" CssClass="cssDorpdownlist"
                                AutoPostBack="true"  />
                        </td>
                        <td align="right">
                            <asp:Label ID="m_lbl_ghi_chu8" runat="server" CssClass="cssManField" Text="Tên trạng thái" />
                        </td>
                        <td>
                            <asp:TextBox ID="m_txt_ten_trang_thai" AccessKey="m" runat="server" Width="98%" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="m_lbl_loai_tai_san_detail" runat="server" CssClass="cssManField" Text="Mã từ điển" />
                        </td>
                        <td>
                            <asp:TextBox ID="m_txt_ma_tu_dien" AccessKey="m" runat="server" Width="150px" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="style2" align="right">
                            <asp:Label ID="m_lbl_ghi_chu" runat="server" CssClass="cssManField" Text="Ghi chú" />
                        </td>
                        <td colspan="3" class="style2">
                            <asp:TextBox ID="m_txt_ghi_chu" AccessKey="m" runat="server" Width="350px" TextMode="MultiLine" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <asp:Button ID="m_cmd_tao_moi" AccessKey="c" CssClass="cssButton" runat="server"
                                Width="98px" Text="Tạo mới(c)" OnClick="m_cmd_tao_moi_Click" />&nbsp;
                            <asp:Button ID="m_cmd_cap_nhat" AccessKey="u" CssClass="cssButton" runat="server"
                                Width="98px" Text="Cập nhật(u)" OnClick="m_cmd_cap_nhat_Click" />&nbsp;
                            <asp:Button ID="btnCancel" AccessKey="r" CssClass="cssButton" runat="server" Width="98px"
                                Text="Xóa trắng(r)" onclick="btnCancel_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td class="cssPageTitleBG" colspan="4">
                            <asp:Label ID="lblUser" runat="server" CssClass="cssPageTitle" Text="Danh mục trạng thái" />
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
                        <td colspan="4" align="center">
                            <asp:HiddenField ID="m_hdf_id_trang_thai" runat="server" Visible="False" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <asp:GridView ID="m_grv_dm_trang_thai" runat="server" AutoGenerateColumns="False"
                                Width="80%" DataKeyNames="ID" CellPadding="4" ForeColor="#333333" CssClass="cssGrid"
                                OnRowDeleting="m_grv_dm_trang_thai_RowDeleting" 
                                onrowupdating="m_grv_dm_trang_thai_RowUpdating">
                                <AlternatingRowStyle BackColor="White" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Xóa" ItemStyle-Width="2%">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="m_lbt_delete" runat="server" CommandName="Delete" ToolTip="Xóa"
                                                OnClientClick="return confirm ('Bạn có thực sự muốn xóa bản ghi này?')">

                     <img src="../Images/Button/deletered.png" alt="Delete" />
                                

                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sửa">
                                        <ItemTemplate>
                                            <asp:LinkButton ToolTip="Sửa" ID="m_lbt_edit" CommandName="Update" runat="server">

                                <img src="../Images/Button/edit.png" alt="Update" />
                                

                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %></ItemTemplate>
                                        <HeaderStyle Width="15px" />
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="MA_TU_DIEN" HeaderText="Mã từ điển" />
                                    <asp:BoundField DataField="TEN" HeaderText="Tên trạng thái"></asp:BoundField>
                                    <asp:BoundField DataField="GHI_CHU" ItemStyle-HorizontalAlign="Center" HeaderText="Ghi chú">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
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
    </div>
    <asp:UpdateProgress ID="Updateprogress1" runat="server">
        <ProgressTemplate>
            <div class="cssLoadWapper">
                <div class="cssLoadContent">
                    <img src="../Images/loadingBar.gif" alt="" />
                    <p>
                        Đang gửi yêu cầu, hãy đợi ...</p>
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
