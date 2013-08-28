<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" EnableEventValidation="false"
    CodeFile="F100_QuanLyNha.aspx.cs" Inherits="ChucNang_F100_QuanLyNha" %>
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
                        <span class="cssPageTitle">Quản lý nhà</span> <span class="expand-collapse-text initial-expand">
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
                                    <asp:DropDownList ID="m_ddl_don_vi_su_dung" runat="server" Width="85%" ValidationGroup="m_vlg_nha"
                                        OnSelectedIndexChanged="m_ddl_don_vi_su_dung_SelectedIndexChanged" AutoPostBack="True">
                                    </asp:DropDownList>
                                </td>
                                <td align="left" style="width: 1%;">
                                </td>
                                <td align="right" style="width: 15%">
                                    <span class="cssManField">Trạng thái nhà</span>
                                </td>
                                <td align="left" style="width: 30%;">
                                    <asp:DropDownList ID="m_ddl_trang_thai_nha" runat="server" Width="85%" ValidationGroup="m_vlg_nha">
                                    </asp:DropDownList>
                                </td>
                                <td align="left" style="width: 1%;">
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 15%">
                                    <span class="cssManField">Thuộc khu đất</span>
                                </td>
                                <td style="width: 30%" align="left">
                                    <asp:DropDownList ID="m_ddl_thuoc_khu_dat" runat="server" Width="85%" ValidationGroup="m_vlg_nha">
                                    </asp:DropDownList>
                                </td>
                                <td align="left" style="width: 1%;">
                                </td>
                                <td align="right" style="width: 15%">
                                    <span class="cssManField">Đơn vị đầu tư</span>
                                </td>
                                <td align="left" style="width: 30%;">
                                    <asp:DropDownList ID="m_ddl_don_vi_dau_tu" runat="server" Width="85%" ValidationGroup="m_vlg_nha">
                                    </asp:DropDownList>
                                </td>
                                <td align="left" style="width: 1%;">
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 15%">
                                    <span class="cssManField">Tên tài sản</span>
                                </td>
                                <td style="width: 30%" align="left">
                                    <asp:TextBox ID="m_txt_ten_tai_san" runat="server" CssClass="cssTextBox" Width="85%"
                                        ValidationGroup="m_vlg_nha"></asp:TextBox>
                                </td>
                                <td align="left" style="width: 1%;">
                                    <asp:RequiredFieldValidator ID="m_rfv_ten_dat" runat="server" ControlToValidate="m_txt_ten_tai_san"
                                        ErrorMessage="Bạn phải nhập Tên tài sản" Text="*" ValidationGroup="m_vlg_nha"
                                        ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                                <td align="right" style="width: 15%">
                                    <span class="cssManField">Mã tài sản</span>
                                </td>
                                <td style="width: 30%" align="left">
                                    <asp:TextBox ID="m_txt_ma_tai_san" runat="server" CssClass="cssTextBox" Width="85%"
                                        ValidationGroup="m_vlg_nha"></asp:TextBox>
                                </td>
                                <td align="left" style="width: 1%;">
                                    <asp:RequiredFieldValidator ID="m_rfv_ma_tai_san" runat="server" ControlToValidate="m_txt_ma_tai_san"
                                        ErrorMessage="Bạn phải nhập Cấp hạng" Text="*" ValidationGroup="m_vlg_nha" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 15%">
                                    <span class="cssManField">Cấp hạng</span>
                                </td>
                                <td style="width: 30%" align="left">
                                    <asp:TextBox ID="m_txt_cap_hang" runat="server" CssClass="cssTextBox" Width="85%"
                                        ValidationGroup="m_vlg_nha"></asp:TextBox>
                                </td>
                                <td align="left" style="width: 1%;">
                                    <asp:RequiredFieldValidator ID="m_rfv_cap_hang" runat="server" ControlToValidate="m_txt_cap_hang"
                                        ErrorMessage="Bạn phải nhập Cấp hạng" Text="*" ValidationGroup="m_vlg_nha" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                                <td align="right" style="width: 15%">
                                    <span class="cssManField">Năm xây dựng</span>
                                </td>
                                <td align="left" style="width: 30%;">
                                    <asp:TextBox ID="m_txt_nam_xd" runat="server" CssClass="cssTextBox" Width="85%" ValidationGroup="m_vlg_nha"></asp:TextBox>
                                </td>
                                <td align="left" style="width: 1%;">
                                    <asp:RequiredFieldValidator ID="m_rfv_nam_xd" runat="server" ControlToValidate="m_txt_nam_xd"
                                        ErrorMessage="Bạn phải nhập Năm xây dựng" Text="*" ValidationGroup="m_vlg_nha"
                                        ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 15%">
                                    <span class="cssManField">Ngày, tháng, năm sử dụng</span>
                                </td>
                                <td style="width: 30%" align="left">
                                    <asp:TextBox ID="m_txt_ngay_su_dung" runat="server" CssClass="cssTextBox" Width="85%"
                                        ValidationGroup="m_vlg_nha"></asp:TextBox>
                                </td>
                                <td align="left" style="width: 1%;">
                                    <asp:RequiredFieldValidator ID="m_rfv_ngay_su_dung" runat="server" ControlToValidate="m_txt_ngay_su_dung"
                                        ErrorMessage="Bạn phải nhập Ngày sử dụng nhà" Text="*" ValidationGroup="m_vlg_nha"
                                        ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
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
                                    GIÁ TRỊ THEO SỔ KẾ TOÁN
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
                                    <span class="cssManField">Nguyên giá nguồn NS (VNĐ)</span>
                                </td>
                                <td style="width: 30%" align="left">
                                    <asp:TextBox ID="m_txt_nguyen_gia" runat="server" CssClass="cssTextBox csscurrency"
                                        Width="85%" ValidationGroup="m_vlg_nha">0</asp:TextBox>
                                </td>
                                <td align="left" style="width: 1%;">
                                    <asp:RequiredFieldValidator ID="m_rfv_nguyen_gia" runat="server" ControlToValidate="m_txt_nguyen_gia"
                                        ErrorMessage="Bản phải nhập Nguyên giá nguồn NS" Text="*" ValidationGroup="m_vlg_nha"
                                        ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                                <td align="right" style="width: 15%">
                                    <span class="cssManField">Nguyên giá nguồn khác (VNĐ)</span>
                                </td>
                                <td align="left" style="width: 30%;">
                                    <asp:TextBox ID="m_txt_nguyen_gia_nguon_khac" runat="server" CssClass="cssTextBox csscurrency"
                                        Width="85%" ValidationGroup="m_vlg_nha">0</asp:TextBox>
                                </td>
                                <td align="left" style="width: 1%;">
                                    <asp:RequiredFieldValidator ID="m_rfv_nguyen_gia_nguon_khac" runat="server" ControlToValidate="m_txt_nguyen_gia_nguon_khac"
                                        ErrorMessage="Bạn phải nhập Nguyên giá nguồn khác" Text="*" ValidationGroup="m_vlg_nha"
                                        ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 15%">
                                    <span class="cssManField">Giá trị còn lại (VNĐ)</span>
                                </td>
                                <td style="width: 30%" align="left">
                                    <asp:TextBox ID="m_txt_gia_tri_con_lai" runat="server" CssClass="cssTextBox csscurrency"
                                        Width="85%" ValidationGroup="m_vlg_nha">0</asp:TextBox>
                                </td>
                                <td align="left" style="width: 1%;">
                                    <asp:RequiredFieldValidator ID="m_rfv_gia_tri_con_lai" runat="server" ControlToValidate="m_txt_gia_tri_con_lai"
                                        ErrorMessage="Bạn phải nhập Giá trị còn lại" Text="*" ValidationGroup="m_vlg_nha"
                                        ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                                <td align="right">
                                </td>
                                <td align="left" style="width: 30%;">
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
                                <td align="right" style="width: 15%">
                                    <span class="cssManField">Số tầng</span>
                                </td>
                                <td style="width: 30%" align="left">
                                    <asp:TextBox ID="m_txt_so_tang" runat="server" CssClass="cssTextBox cssNumber" Width="85%"
                                        ValidationGroup="m_vlg_nha">0</asp:TextBox>
                                </td>
                                <td align="left" style="width: 1%;">
                                    <asp:RequiredFieldValidator ID="m_rfv_so_tang" runat="server" ControlToValidate="m_txt_so_tang"
                                        ErrorMessage="Bạn phải nhập Số tầng" Text="*" ValidationGroup="m_vlg_nha" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                                <td align="right" style="width: 15%">
                                    <span class="cssManField">Diện tích xây dựng (m2)</span>
                                </td>
                                <td align="left" style="width: 30%;">
                                    <asp:TextBox ID="m_txt_dien_tich_xay_dung" runat="server" CssClass="cssTextBox csscurrency"
                                        Width="85%" ValidationGroup="m_vlg_nha">0</asp:TextBox>
                                </td>
                                <td align="left" style="width: 1%;">
                                    <asp:RequiredFieldValidator ID="m_rfv_dien_tich_xay_dung" runat="server" ControlToValidate="m_txt_dien_tich_xay_dung"
                                        ErrorMessage="Bạn phải nhập Diện tích xây dựng" Text="*" ValidationGroup="m_vlg_nha"
                                        ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 15%">
                                    <span class="cssManField">Tổng diện tích sàn xây dựng (m2)</span>
                                </td>
                                <td style="width: 30%" align="left">
                                    <asp:TextBox ID="m_txt_tong_dien_tich_xay_dung" runat="server" CssClass="cssTextBox csscurrency"
                                        Width="85%" ValidationGroup="m_vlg_nha">0</asp:TextBox>
                                </td>
                                <td align="left" style="width: 1%;">
                                    <asp:RequiredFieldValidator ID="m_rfv_tong_dien_tich_xay_dung" runat="server" ControlToValidate="m_txt_tong_dien_tich_xay_dung"
                                        ErrorMessage="Bạn phải nhập Tổng diện tích sàn xây dựng" Text="*" ValidationGroup="m_vlg_nha"
                                        ForeColor="Red"></asp:RequiredFieldValidator>
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
                                    <asp:RequiredFieldValidator ID="m_rfv_tru_so_lam_viec" runat="server" ControlToValidate="m_txt_tru_so_lam_viec"
                                        ErrorMessage="Bạn phải nhập DT Trụ sở làm việc" Text="*" ValidationGroup="m_vlg_nha"
                                        ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                                <td align="right" style="width: 15%">
                                    <span class="cssManField">Cơ sở HĐSN (m2)</span>
                                </td>
                                <td align="left" style="width: 30%;">
                                    <asp:TextBox ID="m_txt_co_so_hdsn" runat="server" CssClass="cssTextBox csscurrency"
                                        Width="85%" ValidationGroup="m_vlg_nha">0</asp:TextBox>
                                </td>
                                <td align="left" style="width: 1%;">
                                    <asp:RequiredFieldValidator ID="m_rfv_co_so_hdsn" runat="server" ControlToValidate="m_txt_co_so_hdsn"
                                        ErrorMessage="Bạn phải nhập DT Cơ sở HĐ sự nghiệp" Text="*" ValidationGroup="m_vlg_nha"
                                        ForeColor="Red"></asp:RequiredFieldValidator>
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
                                    <asp:RequiredFieldValidator ID="m_rfv_lam_nha_o" runat="server" ControlToValidate="m_txt_lam_nha_o"
                                        ErrorMessage="Bạn phải nhập DT Làm nhà ở" Text="*" ValidationGroup="m_vlg_nha"
                                        ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                                <td align="right" style="width: 15%">
                                    <span class="cssManField">Cho thuê (m2)</span>
                                </td>
                                <td align="left" style="width: 30%;">
                                    <asp:TextBox ID="m_txt_cho_thue" runat="server" CssClass="cssTextBox csscurrency"
                                        Width="85%" ValidationGroup="m_vlg_nha">0</asp:TextBox>
                                </td>
                                <td align="left" style="width: 1%;">
                                    <asp:RequiredFieldValidator ID="m_rfv_cho_thue" runat="server" ControlToValidate="m_txt_cho_thue"
                                        ErrorMessage="Bạn phải nhập Cho thuê" Text="*" ValidationGroup="m_vlg_nha" ForeColor="Red"></asp:RequiredFieldValidator>
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
                                    <asp:RequiredFieldValidator ID="m_rfv_bo_trong" runat="server" ControlToValidate="m_txt_bo_trong"
                                        ErrorMessage="Bạn phải nhập DT Bỏ trống" Text="*" ValidationGroup="m_vlg_nha"
                                        ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                                <td align="right" style="width: 15%">
                                    <span class="cssManField">Bị lấn chiếm (m2)</span>
                                </td>
                                <td align="left" style="width: 30%;">
                                    <asp:TextBox ID="m_txt_bi_lan_chiem" runat="server" CssClass="cssTextBox csscurrency"
                                        Width="85%" ValidationGroup="m_vlg_nha">0</asp:TextBox>
                                </td>
                                <td align="left" style="width: 1%;">
                                    <asp:RequiredFieldValidator ID="m_rfv_bi_lan_chiem" runat="server" ControlToValidate="m_txt_bi_lan_chiem"
                                        ErrorMessage="Bạn phải nhập DT Bị lấn chiếm" Text="*" ValidationGroup="m_vlg_nha"
                                        ForeColor="Red"></asp:RequiredFieldValidator>
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
                                    <asp:RequiredFieldValidator ID="m_rfv_khac" runat="server" ControlToValidate="m_txt_khac"
                                        ErrorMessage="Bạn phải nhập DT Khác" Text="*" ValidationGroup="m_vlg_nha" ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                                <td align="right">
                                </td>
                                <td align="left" style="width: 30%;">
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
                                        Height="24px" />&nbsp;
                                    <asp:Button ID="m_cmd_cap_nhat" AccessKey="u" CssClass="cssButton" runat="server"
                                        Width="98px" Text="Cập nhật(u)" OnClick="m_cmd_cap_nhat_Click" ValidationGroup="m_vlg_nha"
                                        Height="24px" Visible="False" />&nbsp;
                                    <asp:Button ID="m_cmd_xoa_trang" AccessKey="r" CssClass="cssButton" runat="server"
                                        Width="98px" Text="Xóa trắng(r)" OnClick="m_cmd_xoa_trang_Click" Height="24px" />
                                    <asp:HiddenField ID="m_hdf_id" runat="server" Value="" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table cellspacing="0" cellpadding="2" style="width: 99%;" class="cssTable" border="0">
                <tr>
                    <td class="cssPageTitleBG" colspan="4">
                        <span class="cssPageTitle">Danh sách nhà</span> <span class="expand-collapse-text initial-expand">
                        </span><span class="expand-collapse-text"></span>
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
                            Width="100%" DataKeyNames="ID" CellPadding="0" ForeColor="#333333" AllowSorting="True"
                            EmptyDataText="Không có dữ liệu phù hợp" PageSize="15" ShowHeader="true" OnRowCommand="m_grv_danh_sach_nha_RowCommand"
                            OnPageIndexChanging="m_grv_danh_sach_nha_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField HeaderText="Xóa" ItemStyle-Width="2%">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="m_lbt_delete" runat="server" CommandName="DeleteComp" ToolTip="Xóa"
                                            OnClientClick="return confirm ('Bạn có thực sự muốn xóa bản ghi này?')" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'>
                                    <img src="../Images/Button/deletered.png" alt="Delete" />
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sửa" ItemStyle-Width="2%">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="m_lbt_edit" runat="server" CommandName="EditComp" ToolTip="Sửa"
                                            CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'>
                                    <img src="../Images/Button/edit.png" alt="Edit" />
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="STT">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Tên tài sản" DataField="TEN_TAI_SAN" />
                                <asp:BoundField HeaderText="Bộ tỉnh" DataField="TEN_DV_BO_TINH" />
                                <asp:BoundField HeaderText="Tên đơn vị chủ quản" DataField="TEN_DV_CHU_QUAN" />
                                <asp:BoundField HeaderText="Tên đơn vị sử dụng" DataField="TEN_DV_SU_DUNG" />
                                <asp:BoundField HeaderText="Cấp hạng" DataField="CAP_HANG" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField HeaderText="Năm xây dựng" DataField="NAM_XAY_DUNG" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField HeaderText="Ngày, tháng, năm sử dụng" DataField="NGAY_THANG_NAM_SU_DUNG"
                                    ItemStyle-HorizontalAlign="Center" />
                                <asp:TemplateField HeaderStyle-Width="25%" HeaderStyle-Height="110px">
                                    <HeaderTemplate>
                                        <table border="1" cellspacing="0" cellpadding="2" width="100%" style="border-collapse: collapse;">
                                            <tr>
                                                <td colspan="3" style="height: 50px">
                                                    GIÁ TRỊ THEO SỔ KẾ TOÁN
                                                    <br />
                                                    (ngàn đồng)
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" rowspan="1">
                                                    Nguyên giá
                                                </td>
                                                <td rowspan="2" style="width: 33.33%; height: 60px">
                                                    Giá trị còn lại
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 33.33%">
                                                    Nguồn NS
                                                </td>
                                                <td style="width: 33.33%">
                                                    Nguồn khác
                                                </td>
                                            </tr>
                                        </table>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <table border="0" cellspacing="0" cellpadding="2" width="100%" style="border-collapse: collapse;
                                            text-align: right">
                                            <td style="width: 33%; height: 60px; border-right: 1px solid gray;">
                                                <%# Eval("NGUON_NS", "{0:#,##0.00}")%>
                                            </td>
                                            <td style="width: 33%; height: 60px; border-right: 1px solid gray;">
                                                <%# Eval("NGUON_KHAC", "{0:#,##0.00}")%>
                                            </td>
                                            <td style="width: 33%; height: 50px;">
                                                <%# Eval("GIA_TRI_CON_LAI", "{0:#,##0.00}")%>
                                            </td>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Số tầng" DataField="SO_TANG" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField HeaderText="DT xây dựng" DataField="DT_XAY_DUNG" ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundField HeaderText="Tổng DT xây dựng" DataField="TONG_DT_SAN_XD" ItemStyle-HorizontalAlign="Right" />
                                <asp:TemplateField HeaderStyle-Width="30%" HeaderStyle-Height="110px">
                                    <HeaderTemplate>
                                        <table border="1" cellspacing="0" cellpadding="2" width="100%" style="border-collapse: collapse;">
                                            <tr>
                                                <td colspan="7" style="height: 50px">
                                                    HIỆN TRẠNG SỬ DỤNG
                                                    <br />
                                                    (m2)
                                                </td>
                                            </tr>
                                            <tr>
                                                <td rowspan="2" style="width: 14; height: 60px">
                                                    Trụ sở làm việc
                                                </td>
                                                <td rowspan="2" style="width: 14">
                                                    Cơ sở HĐSN
                                                </td>
                                                <td rowspan="1" colspan="5">
                                                    Sử dụng khác
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 14">
                                                    Làm nhà ở
                                                </td>
                                                <td style="width: 14">
                                                    Cho thuê
                                                </td>
                                                <td style="width: 14">
                                                    Bỏ trống
                                                </td>
                                                <td style="width: 14">
                                                    Bị lấn chiếm
                                                </td>
                                                <td style="width: 14">
                                                    Khác
                                                </td>
                                            </tr>
                                        </table>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <table border="0" cellspacing="0" cellpadding="2" width="100%" style="text-align: right;
                                            border-collapse: collapse;">
                                            <tr>
                                                <td style="width: 14%; height: 60px; border-right: 1px solid gray;">
                                                    <%# Eval("TRU_SO_LAM_VIEC", "{0:#,##0.00}")%>
                                                </td>
                                                <td style="width: 14%; border-right: 1px solid gray;">
                                                    <%# Eval("CO_SO_HDSN", "{0:#,##0.00}")%>
                                                </td>
                                                <td style="width: 14%; border-right: 1px solid gray;">
                                                    <%# Eval("LAM_NHA_O", "{0:#,##0.00}")%>
                                                </td>
                                                <td style="width: 14%; border-right: 1px solid gray;">
                                                    <%# Eval("CHO_THUE", "{0:#,##0.00}")%>
                                                </td>
                                                <td style="width: 14%; border-right: 1px solid gray;">
                                                    <%# Eval("BO_TRONG", "{0:#,##0.00}")%>
                                                </td>
                                                <td style="width: 14%; border-right: 1px solid gray;">
                                                    <%# Eval("BI_LAN_CHIEM", "{0:#,##0.00}")%>
                                                </td>
                                                <td style="width: 14%">
                                                    <%# Eval("KHAC", "{0:#,##0.00}")%>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Trạng thái" DataField="TEN_TRANG_THAI" ItemStyle-HorizontalAlign="Center" />
                            </Columns>
                            <AlternatingRowStyle BackColor="White" />
                            <EditRowStyle BackColor="#7C6F57" />
                            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#810c15" Font-Bold="True" ForeColor="White" />
                            <PagerSettings Position="TopAndBottom" />
                            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#E3EAEB" />
                            <SelectedRowStyle CssClass="cssSelectedRow" BackColor="#C5BBAF" Font-Bold="True"
                                ForeColor="#333333"></SelectedRowStyle>
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
