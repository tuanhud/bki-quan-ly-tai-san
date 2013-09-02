<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="F101_QuanLyDat.aspx.cs" Inherits="ChucNang_F101_QuanLyDat" EnableEventValidation="false" %>

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
                        <span class="cssPageTitle">Quản lý đất</span> <span class="expand-collapse-text initial-expand">
                        </span><span class="expand-collapse-text"></span>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:ValidationSummary ID="vdsCategory" runat="server" CssClass="cssManField" Font-Bold="true"
                            ValidationGroup="m_vlg_nha" />
                        <asp:Label ID="m_lbl_mess" runat="server" CssClass="cssManField" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <table cellspacing="0" cellpadding="2" style="width: 100%;" class="cssTable" border="0">
                            <tr>
                                <td align="right" style="width: 15%">
                                    <span class="cssManField">Bộ, tỉnh</span>
                                </td>
                                <td style="width: 30%" align="left">
                                    <asp:DropDownList ID="m_ddl_bo_tinh" runat="server" Width="85%" ValidationGroup="m_vlg_nha"
                                        AutoPostBack="True" OnSelectedIndexChanged="m_ddl_bo_tinh_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td align="left" style="width: 1%;">
                                </td>
                                <td align="right" style="width: 15%">
                                    <span class="cssManField">Đơn vị chủ quản</span>
                                </td>
                                <td align="left" style="width: 30%;">
                                    <asp:DropDownList ID="m_ddl_don_vi_chu_quan" runat="server" Width="85%" ValidationGroup="m_vlg_nha"
                                        OnSelectedIndexChanged="m_ddl_don_vi_chu_quan_SelectedIndexChanged" AutoPostBack="True">
                                    </asp:DropDownList>
                                </td>
                                <td align="left" style="width: 1%;">
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 15%">
                                    <span class="cssManField">Đơn vị sử dụng</span>
                                </td>
                                <td style="width: 30%" align="left">
                                    <asp:DropDownList ID="m_ddl_don_vi_su_dung" runat="server" Width="85%" ValidationGroup="m_vlg_nha">
                                    </asp:DropDownList>
                                </td>
                                <td align="left" style="width: 1%;">
                                </td>
                                <td align="right" style="width: 15%">
                                    <span class="cssManField">Trạng thái</span>
                                </td>
                                <td align="left" style="width: 30%;">
                                    <asp:DropDownList ID="m_ddl_trang_thai" runat="server" Width="85%" ValidationGroup="m_vlg_nha">
                                    </asp:DropDownList>
                                </td>
                                <td align="left" style="width: 1%;">
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 15%">
                                    <span class="cssManField">Địa chỉ</span>
                                </td>
                                <td style="width: 30%" align="left">
                                    <asp:TextBox ID="m_txt_dia_chi" runat="server" CssClass="cssTextBox" Width="85%"
                                        ValidationGroup="m_vlg_nha"></asp:TextBox>
                                </td>
                                <td align="left" style="width: 1%;">
                                    <asp:RequiredFieldValidator ID="m_rfv_dia_chi" runat="server" ControlToValidate="m_txt_dia_chi"
                                        ErrorMessage="Bạn phải nhập Địa chỉ" Text="*" ValidationGroup="m_vlg_nha" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                                <td align="right" style="width: 15%">
                                    <span class="cssManField">Mã tài sản</span><td align="left" style="width: 30%;">
                                        <asp:TextBox ID="m_txt_ma_tai_san" runat="server" CssClass="cssTextBox" Width="85%"
                                            ValidationGroup="m_vlg_nha"></asp:TextBox>
                                    </td>
                                    <td align="left" style="width: 1%;">
                                        <asp:RequiredFieldValidator ID="m_rfv_ma_tai_san" runat="server" ControlToValidate="m_txt_ma_tai_san"
                                            ErrorMessage="Bạn phải nhập Mã tài sản" Text="*" ValidationGroup="m_vlg_nha"
                                            ForeColor="Red"></asp:RequiredFieldValidator>
                                    </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 15%">
                                    <span class="cssManField">Số năm đã sử dụng</span>
                                </td>
                                <td style="width: 30%" align="left">
                                    <asp:TextBox ID="m_txt_nam_xd" runat="server" CssClass="cssTextBox csscurrency" Width="85%"
                                        ValidationGroup="m_vlg_nha">0</asp:TextBox>
                                </td>
                                <td align="left" style="width: 1%;">
                                    
                                </td>
                                <td align="right" style="width: 15%">
                                    <span class="cssManField">Giá trị theo sổ kế toán (VNĐ)</span>
                                </td>
                                <td style="width: 30%" align="left">
                                    <asp:TextBox ID="m_txt_nguyen_gia" runat="server" CssClass="cssTextBox csscurrency"
                                        Width="85%" ValidationGroup="m_vlg_nha">0</asp:TextBox>
                                </td>
                                <td align="left" style="width: 1%;">
                                    
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 15%">
                                    <span class="cssManField">Diện tích khuôn viên (m2)</span>
                                </td>
                                <td style="width: 30%" align="left">
                                    <asp:TextBox ID="m_txt_dien_tich_khuon_vien" runat="server" CssClass="cssTextBox csscurrency"
                                        ValidationGroup="m_vlg_nha" Width="85%">0</asp:TextBox>
                                </td>
                                <td align="left" style="width: 1%;">
                                    &nbsp;</td>
                                <td align="right" style="width: 15%">
                                </td>
                                <td align="left" style="width: 30%;">
                                </td>
                                <td align="left" style="width: 1%;">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    HIỆN TRẠNG SỬ DỤNG
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 15%">
                                    <span class="cssManField">Trụ sở làm việc (m2)</span>
                                </td>
                                <td style="width: 30%" align="left">
                                    <asp:TextBox ID="m_txt_tru_so_lam_viec" runat="server" CssClass="cssTextBox csscurrency"
                                        Width="85%" ValidationGroup="m_vlg_nha">0</asp:TextBox>
                                </td>
                                <td align="left" style="width: 1%;">

                                </td>
                                <td align="right" style="width: 15%">
                                    <span class="cssManField">Cơ sở HĐSN (m2)</span>
                                </td>
                                <td align="left" style="width: 30%;">
                                    <asp:TextBox ID="m_txt_co_so_hdsn" runat="server" CssClass="cssTextBox csscurrency"
                                        Width="85%" ValidationGroup="m_vlg_nha">0</asp:TextBox>
                                </td>
                                <td align="left" style="width: 1%;">

                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 15%">
                                    <span class="cssManField">Làm nhà ở (m2)</span>
                                </td>
                                <td style="width: 30%" align="left">
                                    <asp:TextBox ID="m_txt_lam_nha_o" runat="server" CssClass="cssTextBox csscurrency"
                                        Width="85%" ValidationGroup="m_vlg_nha">0</asp:TextBox>
                                </td>
                                <td align="left" style="width: 1%;">

                                </td>
                                <td align="right" style="width: 15%">
                                    <span class="cssManField">Cho thuê (m2)</span>
                                </td>
                                <td align="left" style="width: 30%;">
                                    <asp:TextBox ID="m_txt_cho_thue" runat="server" CssClass="cssTextBox csscurrency"
                                        Width="85%" ValidationGroup="m_vlg_nha">0</asp:TextBox>
                                </td>
                                <td align="left" style="width: 1%;">

                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 15%">
                                    <span class="cssManField">Bỏ trống (m2)</span>
                                </td>
                                <td style="width: 30%" align="left">
                                    <asp:TextBox ID="m_txt_bo_trong" runat="server" CssClass="cssTextBox csscurrency"
                                        Width="85%" ValidationGroup="m_vlg_nha">0</asp:TextBox>
                                </td>
                                <td align="left" style="width: 1%;">

                                </td>
                                <td align="right" style="width: 15%">
                                    <span class="cssManField">Bị lấn chiếm (m2)</span>
                                </td>
                                <td align="left" style="width: 30%;">
                                    <asp:TextBox ID="m_txt_bi_lan_chiem" runat="server" CssClass="cssTextBox csscurrency"
                                        Width="85%" ValidationGroup="m_vlg_nha">0</asp:TextBox>
                                </td>
                                <td align="left" style="width: 1%;">

                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 15%">
                                    <span class="cssManField">Khác (m2)</span>
                                </td>
                                <td style="width: 30%" align="left">
                                    <asp:TextBox ID="m_txt_khac" runat="server" CssClass="cssTextBox csscurrency" Width="85%"
                                        ValidationGroup="m_vlg_nha">0</asp:TextBox>
                                </td>
                                <td align="left" style="width: 1%;">

                                </td>
                                <td align="right">
                                 <span class="cssManField">Tình trạng đất</span>
                                </td>
                                <td align="left" style="width: 30%;">
                                 <asp:DropDownList ID="m_ddl_tinh_trang_dat" runat="server" Width="85%">
                                    </asp:DropDownList>
                                </td>
                                <td align="left" style="width: 1%;">
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 15%">
                                    <br />
                                </td>
                                <td style="width: 30%" align="left">
                                </td>
                                <td align="left" style="width: 1%;">
                                </td>
                                <td align="right">
                                </td>
                                <td align="left" style="width: 30%;">
                                </td>
                                <td align="left" style="width: 1%;">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td colspan="4" align="left">
                                    <asp:Button ID="m_cmd_tao_moi" AccessKey="c" CssClass="cssButton" runat="server"
                                        Width="98px" Text="Tạo mới(c)" OnClick="m_cmd_tao_moi_Click" ValidationGroup="m_vlg_nha"
                                        Height="24px" />
                                    <asp:Button ID="m_cmd_cap_nhat" AccessKey="u" CssClass="cssButton" runat="server"
                                        Width="98px" Text="Cập nhật(u)" OnClick="m_cmd_cap_nhat_Click" ValidationGroup="m_vlg_nha"
                                        Height="24px" />
                                    <asp:Button ID="m_cmd_xoa_trang" AccessKey="r" CssClass="cssButton" runat="server"
                                        Width="98px" Text="Xóa trắng(r)" OnClick="m_cmd_xoa_trang_Click" Height="24px" />
                                    <asp:HiddenField ID="m_hdf_id" runat="server" Value="-1" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table cellspacing="0" cellpadding="2" style="width: 99%;" class="cssTable" border="0">
                <tr>
                    <td class="cssPageTitleBG" colspan="4">
                        <asp:Label ID="m_lbl_thong_tin_dat" runat="server" Text="DANH SÁCH ĐẤT" CLASS="cssPageTitle"></asp:Label>
                        <span class="expand-collapse-text initial-expand"></span><span class="expand-collapse-text">
                        </span>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 15%">
                        <span class="cssManField">Từ khóa</span>
                    </td>
                    <td align="left" style="width: 30%">
                        <asp:TextBox ID="m_txt_tu_khoa" runat="server" CssClass="cssTextBox" Width="85%"></asp:TextBox>
                    </td>
                    <td align="left">
                    </td>
                    <td align="left">
                    </td>
                </tr>
                <tr>
                    <td align="right">
                    </td>
                    <td align="left">
                        <asp:Button ID="m_cmd_tim_kiem" runat="server" AccessKey="s" CssClass="cssButton"
                            Height="24px" Text="Tìm kiếm" Width="98px" OnClick="m_cmd_tim_kiem_Click" />
                    </td>
                    <td align="left">
                        <asp:Button ID="m_cmd_xuat_excel" runat="server" CausesValidation="False" CssClass="cssButton"
                            Height="25px" Text="Xuất Excel" Width="98px" OnClick="m_cmd_xuat_excel_Click" />
                    </td>
                    <td align="left">
                    </td>
                </tr>
                <tr>
                    <td align="right">
                    </td>
                    <td align="left">
                        <asp:Label ID="m_lbl_thong_bao" Visible="false" runat="server" CssClass="cssManField" />
                    </td>
                    <td align="left">
                    </td>
                    <td align="left">
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="3" style="height: 450px;" valign="top">
                        <asp:GridView ID="m_grv_danh_sach_nha" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            Width="100%" DataKeyNames="ID" CellPadding="4" ForeColor="#333333" AllowSorting="True"
                            EmptyDataText="Không có dữ liệu phù hợp" PageSize="15" ShowHeader="true" OnPageIndexChanging="m_grv_danh_sach_nha_PageIndexChanging"
                            OnRowCommand="m_grv_danh_sach_nha_RowCommand">
                            <AlternatingRowStyle BackColor="White" />
                            <EditRowStyle BackColor="#7C6F57" />
                            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#810c15" Font-Bold="True" ForeColor="White" />
                            <PagerSettings Position="TopAndBottom" />
                            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#E3EAEB" />
                            <SelectedRowStyle CssClass="cssSelectedRow" BackColor="#C5BBAF" Font-Bold="True"
                                ForeColor="#333333"></SelectedRowStyle>
                            <Columns>
                                <asp:TemplateField HeaderText="Xóa" ItemStyle-Width="2%">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="m_lbt_delete" runat="server" CommandName="DeleteComp" ToolTip="Xóa"
                                            OnClientClick="return confirm ('Bạn có thực sự muốn xóa bản ghi này?')" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'>
                                    <img src="../Images/Button/deletered.png" alt="Delete" />
                                        
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sửa">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="m_lbt_edit" runat="server" CommandName="EditComp" ToolTip="Sửa"
                                            CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'>

                                    <img src="../Images/Button/edit.png" alt="Edit" />
                                        
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Mã tài sản" DataField="MA_TAI_SAN" />
                                <asp:BoundField HeaderText="Địa chỉ" DataField="DIA_CHI" />
                                <asp:BoundField HeaderText="DT Khuôn viên (m2)" DataField="DT_KHUON_VIEN" ItemStyle-HorizontalAlign="Right"
                                    DataFormatString="{0:#,##0.00}" />
                                <asp:BoundField HeaderText="DT Trụ sở làm việc (m2)" DataField="DT_TRU_SO_LAM_VIEC"
                                    ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}" />
                                <asp:BoundField HeaderText="DT Cơ sở hoạt động sự nghiệp (m2)" DataField="DT_CO_SO_HOAT_DONG_SU_NGHIEP"
                                    ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}" />
                                <asp:BoundField HeaderText="DT Làm nhà ở (m2)" DataField="DT_LAM_NHA_O" ItemStyle-HorizontalAlign="Right"
                                    DataFormatString="{0:#,##0.00}" />
                                <asp:BoundField HeaderText="DT Cho thuê (m2)" DataField="DT_CHO_THUE" ItemStyle-HorizontalAlign="Right"
                                    DataFormatString="{0:#,##0.00}" />
                                <asp:BoundField HeaderText="DT Bỏ trống (m2)" DataField="DT_BO_TRONG" ItemStyle-HorizontalAlign="Right"
                                    DataFormatString="{0:#,##0.00}" />
                                <asp:BoundField HeaderText="DT Bị lấn chiếm (m2)" DataField="DT_BI_LAN_CHIEM" ItemStyle-HorizontalAlign="Right"
                                    DataFormatString="{0:#,##0.00}" />
                                <asp:BoundField HeaderText="DT Sử dụng mục đích khác (m2)" DataField="DT_SU_DUNG_MUC_DICH_KHAC"
                                    ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}" />
                                <asp:BoundField HeaderText="Giá trị theo số kế toán (VNĐ)" DataField="GT_THEO_SO_KE_TOAN"
                                    ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}" />
                                <asp:BoundField HeaderText="Số năm đã sử dụng" DataField="SO_NAM_DA_SU_DUNG" ItemStyle-HorizontalAlign="Right" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="m_cmd_xuat_excel" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdateProgress runat="server">
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
