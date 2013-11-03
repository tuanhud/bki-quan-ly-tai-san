<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="F200_DanhMucTaiSanKhac.aspx.cs" Inherits="Default2" %>

<%@ Register Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"
    TagPrefix="asp" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Panel ID="m_pnl_confirm_tg" runat="server">
                    <div class="cssLoadWapper">
                        <asp:MultiView ID="m_mtv_1" runat="server">
                            <asp:View ID="m_view_confirm" runat="server">
                                <div class="cssLoadContent2">
                                    <table border="0" cellspacing="0" cellpadding="2" width="100%">
                                        <tr>
                                            <td>
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: center">
                                                <span class="cssManField">Đã tạo mới một tài sản, bạn cần cập nhật thông tin ghi tăng cho tài sản này!</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="text-align: center">
                                                <asp:Button ID="m_cmd_confirm" AccessKey="c" CssClass="cssButton" runat="server"
                                                    Height="24px" Width="98px" Text="Tiếp tục" CausesValidation="false" OnClick="m_cmd_confirm_Click" />
                                                </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <br />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </asp:View>
                            <asp:View ID="m_view_them_moi_tg" runat="server">
                                <div class="cssLoadContent2">
                                    <table border="0" cellspacing="0" cellpadding="2" width="100%">
                                        <tr>
                                            <td colspan="2">
                                                <asp:Label ID="m_lbl_mess_tg" runat="server" Text="" CssClass="cssManField" ForeColor="Blue"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="center">
                                                <span class="cssManField">CHI TIẾT DUYỆT GHI</span></td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <span class="cssManField">Lý do</span>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="m_cbo_ly_do_thay_doi" Width="85%" runat="server" AutoPostBack="true"
                                                    OnSelectedIndexChanged="m_cbo_ly_do_thay_doi_SelectedIndexChanged">
                                                </asp:DropDownList>
                                            </td>
                                            <td align="right">
                                                <span class="cssManField">Loại đề nghị</span>
                                            </td>
                                            <td>
                                                <asp:RadioButtonList ID="m_rbl_loai" runat="server" RepeatDirection="Horizontal"
                                                    CssClass="cssManField" Enabled="False">
                                                    <asp:ListItem Value="Y" Selected="True">Duyệt ghi tăng</asp:ListItem>
                                                    <asp:ListItem Value="N">Duyệt ghi giảm</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="width: 15%">
                                                <span class="cssManField">Mã phiếu *</span>
                                            </td>
                                            <td align="left" style="width: 30%">
                                                <asp:TextBox ID="m_txt_ma_phieu" runat="server" CssClass="cssTextBox" Width="85%"
                                                    ValidationGroup="m_vlg_tang_giam"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="m_rfv_ma_phieu" runat="server" ErrorMessage="Bạn phải nhập Mã phiếu"
                                                    Text="*" ControlToValidate="m_txt_ma_phieu" ValidationGroup="m_vlg_tang_giam"></asp:RequiredFieldValidator>
                                            </td>
                                            <td align="right" style="width: 15%">
                                                <span class="cssManField">Ngày tăng giảm tài sản</span>
                                            </td>
                                            <td align="left" style="width: 30%">
                                                <ew:CalendarPopup ID="m_dat_ngay_tang_giam" runat="server" ControlDisplay="TextBoxImage"
                                                    Culture="vi-VN" DisableTextboxEntry="true" GoToTodayText="Hôm nay: " ImageUrl="~/Images/cal.gif"
                                                    ShowGoToToday="true">
                                                    <WeekdayStyle BackColor="White" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Size="XX-Small"
                                                        ForeColor="Black" />
                                                    <WeekendStyle BackColor="LightGray" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Size="XX-Small"
                                                        ForeColor="Black" />
                                                    <OffMonthStyle BackColor="AntiqueWhite" Font-Names="Verdana,Helvetica,Tahoma,Arial"
                                                        Font-Size="XX-Small" ForeColor="Gray" />
                                                    <SelectedDateStyle BackColor="#007ccf" Font-Names="Verdana,Helvetica,Tahoma,Arial"
                                                        Font-Size="XX-Small" ForeColor="Black" />
                                                    <MonthHeaderStyle BackColor="#007ccf" Font-Names="Verdana,Helvetica,Tahoma,Arial"
                                                        Font-Size="XX-Small" ForeColor="Black" />
                                                    <DayHeaderStyle BackColor="AliceBlue" Font-Names="Verdana,Helvetica,Tahoma,Arial"
                                                        Font-Size="XX-Small" ForeColor="Black" />
                                                    <ClearDateStyle BackColor="White" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Size="XX-Small"
                                                        ForeColor="Black" />
                                                    <GoToTodayStyle BackColor="White" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Size="XX-Small"
                                                        ForeColor="Black" />
                                                    <TodayDayStyle BackColor="CadetBlue" Font-Names="Verdana,Helvetica,Tahoma,Arial"
                                                        Font-Size="XX-Small" ForeColor="Black" />
                                                </ew:CalendarPopup>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" style="width: 15%">
                                                <span class="cssManField">Ngày duyệt</span>
                                            </td>
                                            <td align="left" style="width: 30%">
                                                <ew:CalendarPopup ID="m_dat_ngay_duyet" runat="server" ControlDisplay="TextBoxImage"
                                                    Culture="vi-VN" DisableTextboxEntry="true" GoToTodayText="Hôm nay: " ImageUrl="~/Images/cal.gif"
                                                    ShowGoToToday="true">
                                                    <WeekdayStyle BackColor="White" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Size="XX-Small"
                                                        ForeColor="Black" />
                                                    <WeekendStyle BackColor="LightGray" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Size="XX-Small"
                                                        ForeColor="Black" />
                                                    <OffMonthStyle BackColor="AntiqueWhite" Font-Names="Verdana,Helvetica,Tahoma,Arial"
                                                        Font-Size="XX-Small" ForeColor="Gray" />
                                                    <SelectedDateStyle BackColor="#007ccf" Font-Names="Verdana,Helvetica,Tahoma,Arial"
                                                        Font-Size="XX-Small" ForeColor="Black" />
                                                    <MonthHeaderStyle BackColor="#007ccf" Font-Names="Verdana,Helvetica,Tahoma,Arial"
                                                        Font-Size="XX-Small" ForeColor="Black" />
                                                    <DayHeaderStyle BackColor="AliceBlue" Font-Names="Verdana,Helvetica,Tahoma,Arial"
                                                        Font-Size="XX-Small" ForeColor="Black" />
                                                    <ClearDateStyle BackColor="White" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Size="XX-Small"
                                                        ForeColor="Black" />
                                                    <GoToTodayStyle BackColor="White" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Size="XX-Small"
                                                        ForeColor="Black" />
                                                    <TodayDayStyle BackColor="CadetBlue" Font-Names="Verdana,Helvetica,Tahoma,Arial"
                                                        Font-Size="XX-Small" ForeColor="Black" />
                                                </ew:CalendarPopup>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" align="center"> 
                                                <asp:Button ID="m_cmd_tao_tang_giam" AccessKey="c" CssClass="cssButton" runat="server"
                                                    Height="24px" Width="98px" Text="Tạo mới" ValidationGroup="m_vlg_tang_giam" OnClick="m_cmd_tao_tang_giam_Click" />
                                                <asp:Button ID="m_cmd_huy_bo" AccessKey="r" CssClass="cssButton" runat="server" CausesValidation="false"
                                                    Height="24px" Width="98px" Text="Hủy bỏ" OnClick="m_cmd_huy_bo_Click" />
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </asp:View>
                        </asp:MultiView>
                    </div>
                </asp:Panel>
                <table cellspacing="0" cellpadding="2" style="width: 99%;" class="cssTable" border="0">
                    <tr>
                        <td class="cssPageTitleBG" colspan="4">
                            <span class="cssPageTitle">NHẬP MỚI, CẬP NHẬT THÔNG TIN TÀI SẢN KHÁC</span><span class="expand-collapse-text initial-expand">
                            </span><span class="expand-collapse-text"></span>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:ValidationSummary ID="vdsCategory" runat="server" CssClass="cssManField" Font-Bold="true"
                                ValidationGroup="m_vlg_tsk" />
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
                                        <asp:DropDownList ID="m_cbo_bo_tinh" runat="server" Width="85%" AutoPostBack="True"
                                            OnSelectedIndexChanged="m_cbo_bo_tinh_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    <td align="left" style="width: 1%;">
                                    </td>
                                    <td align="right" style="width: 15%">
                                        <span class="cssManField">Đơn vị chủ quản</span>
                                    </td>
                                    <td align="left" style="width: 30%;">
                                        <asp:DropDownList ID="m_cbo_don_vi_chu_quan" runat="server" Width="85%" OnSelectedIndexChanged="m_cbo_don_vi_chu_quan_SelectedIndexChanged">
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
                                        <asp:DropDownList ID="m_cbo_don_vi_su_dung" runat="server" Width="85%" AutoPostBack="true"
                                            OnSelectedIndexChanged="m_cbo_don_vi_su_dung_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    <td align="left" style="width: 1%;">
                                    </td>
                                    <td align="right" style="width: 15%">
                                        <span class="cssManField">Trạng thái tài sản</span>
                                    </td>
                                    <td align="left" style="width: 30%;">
                                        <asp:DropDownList ID="m_cbo_trang_thai_tai_san" runat="server" Width="85%" AutoPostBack="true"
                                            OnSelectedIndexChanged="m_cbo_trang_thai_tai_san_SelectedIndexChanged" Enabled="false">
                                        </asp:DropDownList>
                                    </td>
                                    <td align="left" style="width: 1%;">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 15%">
                                        <span class="cssManField">Tên tài sản *</span>
                                    </td>
                                    <td style="width: 30%" align="left">
                                        <asp:TextBox ID="m_txt_ten_tai_san" runat="server" CssClass="cssTextBox" Width="85%"
                                            ValidationGroup="m_vlg_tsk"></asp:TextBox>
                                    </td>
                                    <td align="left" style="width: 1%;">
                                        <asp:RequiredFieldValidator ID="m_rfv_ten_tai_San" runat="server" ControlToValidate="m_txt_ten_tai_san"
                                            ErrorMessage="Bạn phải nhập Tên tài sản" Text="*" ValidationGroup="m_vlg_tsk"></asp:RequiredFieldValidator>
                                    </td>
                                    <td align="right" style="width: 15%">
                                        <span class="cssManField">Mã tài sản *</span>
                                    </td>
                                    <td align="left" style="width: 30%;">
                                        <asp:TextBox ID="m_txt_ma_tai_san" runat="server" CssClass="cssTextBox" Width="85%"
                                            ValidationGroup="m_vlg_tsk"></asp:TextBox>
                                    </td>
                                    <td align="left" style="width: 1%;">
                                        <asp:RequiredFieldValidator ID="m_rfv_ma_tai_san" runat="server" ControlToValidate="m_txt_ma_tai_san"
                                            ErrorMessage="Bạn phải nhập Mã Tài sản" Text="*" ValidationGroup="m_vlg_tsk"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 15%">
                                        <span class="cssManField">Ký hiệu *</span>
                                    </td>
                                    <td style="width: 30%" align="left">
                                        <asp:TextBox ID="m_txt_ky_hieu" runat="server" CssClass="cssTextBox" Width="85%"
                                            ValidationGroup="m_vlg_tsk"></asp:TextBox>
                                    </td>
                                    <td align="left" style="width: 1%;">
                                        <asp:RequiredFieldValidator ID="m_rfv_ky_hieu" runat="server" ControlToValidate="m_txt_ky_hieu"
                                            ErrorMessage="Bạn phải nhập Ký hiệu" Text="*" ValidationGroup="m_vlg_tsk"></asp:RequiredFieldValidator>
                                    </td>
                                    <td align="right" style="width: 15%">
                                        <span class="cssManField">Nước sản xuất *</span>
                                    </td>
                                    <td align="left" style="width: 30%;">
                                        <asp:TextBox ID="m_txt_nuoc_sx" runat="server" CssClass="cssTextBox" Width="85%"
                                            ValidationGroup="m_vlg_tsk"></asp:TextBox>
                                    </td>
                                    <td align="left" style="width: 1%;">
                                        <asp:RequiredFieldValidator ID="m_rfv_nuoc_sx" runat="server" ControlToValidate="m_txt_nuoc_sx"
                                            ErrorMessage="Bạn phải nhập Nước sản xuất" Text="*" ValidationGroup="m_vlg_tsk"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 15%">
                                        <span class="cssManField">Năm sản xuất *</span>
                                    </td>
                                    <td style="width: 30%" align="left">
                                        <asp:TextBox ID="m_txt_nam_sx" runat="server" CssClass="cssTextBox cssNumber" Width="85%"
                                            ValidationGroup="m_vlg_tsk"></asp:TextBox>
                                    </td>
                                    <td align="left" style="width: 1%;">
                                        <asp:RequiredFieldValidator ID="m_rfv_nam_sx" runat="server" ControlToValidate="m_txt_nam_sx"
                                            ErrorMessage="Bạn phải nhập Mã Tài sản" Text="*" ValidationGroup="m_vlg_tsk"></asp:RequiredFieldValidator>
                                    </td>
                                    <td align="right" style="width: 15%">
                                        <span class="cssManField">Năm sử dụng *</span>
                                    </td>
                                    <td align="left" style="width: 30%;">
                                        <asp:TextBox ID="m_txt_ngay_su_dung" runat="server" CssClass="cssTextBox cssNumber"
                                            Width="85%" ValidationGroup="m_vlg_tsk"></asp:TextBox>
                                    </td>
                                    <td align="left" style="width: 1%;">
                                        <asp:RequiredFieldValidator ID="m_rfv_ngay_su_dung" runat="server" ControlToValidate="m_txt_ngay_su_dung"
                                            ErrorMessage="Bạn phải nhập Ngày sử dụng" Text="*" ValidationGroup="m_vlg_tsk"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td class="cssManField">
                                        GIÁ TRỊ THEO SỔ KẾ TOÁN (VNĐ)
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
                                        <span class="cssManField">Nguyên giá nguồn NS *</span>
                                    </td>
                                    <td style="width: 30%" align="left">
                                        <asp:TextBox ID="m_txt_nguyen_gia_nguon_ns" runat="server" CssClass="cssTextBox csscurrency"
                                            Width="85%" ValidationGroup="m_vlg_tsk"></asp:TextBox>
                                    </td>
                                    <td align="left" style="width: 1%;">
                                        <asp:RequiredFieldValidator ID="m_rfv_nguon_ngan_sach" runat="server" ControlToValidate="m_txt_nguyen_gia_nguon_ns"
                                            ErrorMessage="Bạn phải nhập Nguồn ngân sách" Text="*" ValidationGroup="m_vlg_tsk"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="m_cp_nguon_ngan_sach" runat="server" ControlToValidate="m_txt_nguyen_gia_nguon_ns"
                                            ErrorMessage="Bạn không được nhập số âm vào Nguồn ngân sách" Text="*" Operator="GreaterThanEqual"
                                            ValueToCompare="0" ValidationGroup="m_vlg_tsk"></asp:CompareValidator>
                                    </td>
                                    <td align="right" style="width: 15%">
                                        <span class="cssManField">Nguyên giá nguồn khác *</span>
                                    </td>
                                    <td align="left" style="width: 30%;">
                                        <asp:TextBox ID="m_txt_nguyen_gia_nguon_khac" runat="server" CssClass="cssTextBox csscurrency"
                                            Width="85%" ValidationGroup="m_vlg_tsk"></asp:TextBox>
                                    </td>
                                    <td align="left" style="width: 1%;">
                                        <asp:RequiredFieldValidator ID="m_rfv_nguon_khac" runat="server" ControlToValidate="m_txt_nguyen_gia_nguon_khac"
                                            ErrorMessage="Bạn phải nhập Nguồn khác" Text="*" ValidationGroup="m_vlg_tsk"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="m_cp_nguon_khac" runat="server" ControlToValidate="m_txt_nguyen_gia_nguon_khac"
                                            ErrorMessage="Bạn không được nhập số âm vào Nguồn khác" Text="*" Operator="GreaterThanEqual"
                                            ValueToCompare="0" ValidationGroup="m_vlg_tsk"></asp:CompareValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 15%">
                                        <span class="cssManField">Giá trị còn lại *</span>
                                    </td>
                                    <td style="width: 30%" align="left">
                                        <asp:TextBox ID="m_txt_gia_tri_con_lai" runat="server" CssClass="cssTextBox csscurrency"
                                            Width="85%" ValidationGroup="m_vlg_tsk"></asp:TextBox>
                                    </td>
                                    <td align="left" style="width: 1%;">
                                        <asp:RequiredFieldValidator ID="m_rfv_gia_tri_con_lai" runat="server" ControlToValidate="m_txt_gia_tri_con_lai"
                                            ErrorMessage="Bạn phải nhập Giá trị còn lại" Text="*" ValidationGroup="m_vlg_tsk"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="m_cp_gia_tri_con_lai" runat="server" ControlToValidate="m_txt_gia_tri_con_lai"
                                            ErrorMessage="Bạn không được nhập số âm vào Giá trị còn lại" Text="*" Operator="GreaterThanEqual"
                                            ValueToCompare="0" ValidationGroup="m_vlg_tsk"></asp:CompareValidator>
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
                                    <td colspan="3" class="cssManField">
                                        HIỆN TRẠNG SỬ DỤNG (Lựa chọn mục đích sử dụng)
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 15%">
                                        <span class="cssManField">Mục đích sử dụng</span>
                                    </td>
                                    <td style="width: 30%" align="left">
                                        <asp:RadioButtonList ID="m_rbl_muc_dich_su_dung" runat="server" Font-Bold="True" 
                                            ForeColor="Blue" RepeatColumns="2" RepeatDirection="Horizontal">
                                            <asp:ListItem Selected="True" Value="QLNN">Quản lý nhà nước</asp:ListItem>
                                            <asp:ListItem Value="KD">Kinh doanh</asp:ListItem>
                                            <asp:ListItem Value="KKD">Không kinh doanh</asp:ListItem>
                                            <asp:ListItem Value="MDK">Sử dụng mục đích khác</asp:ListItem>
                                        </asp:RadioButtonList>
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
                                            Width="98px" Height="24px" Text="Tạo mới(c)" OnClick="m_cmd_tao_moi_Click" ValidationGroup="m_vlg_tsk" />&nbsp;
                                        <asp:Button ID="m_cmd_cap_nhat" AccessKey="u" CssClass="cssButton" runat="server"
                                            Width="98px" Height="24px" Text="Cập nhật(u)" OnClick="m_cmd_cap_nhat_Click"
                                            ValidationGroup="m_vlg_tsk" />&nbsp;
                                        <asp:Button ID="m_cmd_xoa_trang" AccessKey="r" CssClass="cssButton" runat="server"
                                            Width="98px" Height="24px" Text="Xóa trắng(r)" OnClick="m_cmd_xoa_trang_Click" />
                                        <asp:HiddenField ID="hdf_id" runat="server" Value="" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table cellspacing="0" cellpadding="2" style="width: 99%;" class="cssTable" border="0">
                    <tr>
                        <td class="cssPageTitleBG" colspan="4">
                            <asp:Label ID="m_lbl_title" runat="server" Text="DANH SÁCH TÀI SẢN KHÁC " CssClass="cssPageTitle"></asp:Label><span
                                class="expand-collapse-text initial-expand"> </span><span class="expand-collapse-text">
                                </span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 15%">
                            <span class="cssManField">Từ khóa</span>
                        </td>
                        <td align="left" style="width: 30%">
                            <asp:TextBox ID="m_txt_tim_kiem" runat="server" CssClass="cssTextBox" AutoPostBack="true"
                                Width="85%" OnTextChanged="m_txt_tim_kiem_TextChanged"></asp:TextBox>
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
                            <asp:Button ID="m_cmd_search" runat="server" AccessKey="s" CssClass="cssButton" Height="24px"
                                Text="Tìm kiếm" Width="98px" OnClick="m_cmd_search_Click" />
                        </td>
                        <td align="left">
                            <asp:Button ID="m_cmd_xuat_excel" runat="server" CausesValidation="False" CssClass="cssButton"
                                Height="25px" Text="Xuất Excel" Width="98px" OnClick="m_cmd_xuat_excel_Click" />
                        </td>
                        <td align="left">
                            <asp:Button ID="m_cmd_an" runat="server" CausesValidation="False" CssClass="cssButton"
                                Height="25px" OnClick="m_cmd_an_Click" Text="Ẩn" Width="98px" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                        </td>
                        <td align="left">
                            <asp:Label ID="Label1" Visible="false" runat="server" CssClass="cssManField" />
                        </td>
                        <td align="left">
                        </td>
                        <td align="left">
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="4" style="height: 450px;" valign="top">
                            <asp:GridView ID="m_grv_tai_san_khac" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                Width="100%" DataKeyNames="ID" CellPadding="0" ForeColor="#333333" AllowSorting="True"
                                PageSize="30" ShowHeader="true" OnRowUpdating="m_grv_tai_san_khac_RowUpdating"
                                OnRowDeleting="m_grv_tai_san_khac_RowDeleting" EmptyDataText="Không có dữ liệu."
                                OnPageIndexChanging="m_grv_tai_san_khac_PageIndexChanging">
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
                                    <asp:TemplateField HeaderText="Chi tiết tài sản" Visible="false">
                                        <ItemTemplate>
                                            <asp:HyperLink ToolTip="Chi tiết tài sản" ImageUrl="../Images/Button/detail.png"
                                                ID="lbt_hop_dong_gv" runat="server" NavigateUrl=''></asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:HyperLinkField HeaderText="Tên tài sản" DataTextField="TEN_TAI_SAN" NavigateUrl="" />
                                    <asp:BoundField HeaderText="Mã tài sản" DataField="MA_TAI_SAN" />
                                    <asp:BoundField HeaderText="Ký hiệu" DataField="KY_HIEU" />
                                    <asp:BoundField HeaderText="Nước sản xuất" DataField="NUOC_SAN_XUAT" />
                                    <asp:BoundField HeaderText="Năm sản xuất" DataField="NAM_SAN_XUAT" ItemStyle-HorizontalAlign="Center" />
                                    <asp:BoundField HeaderText="Năm sử dụng" DataField="NAM_SU_DUNG" ItemStyle-HorizontalAlign="Center" />
                                    <asp:TemplateField HeaderStyle-Width="25%" HeaderStyle-Height="75px">
                                        <HeaderTemplate>
                                            <table border="1" cellspacing="0" cellpadding="3" width="100%" style="border-collapse: collapse;
                                                height: 100%">
                                                <tr style="height: 30%">
                                                    <td colspan="3" style="height: 100%">
                                                        Giá trị theo sổ kế toán (VNĐ)
                                                    </td>
                                                </tr>
                                                <tr style="height: 30%">
                                                    <td colspan="2" style="width: 66%">
                                                        Nguyên giá
                                                    </td>
                                                    <td rowspan="2" style="width: 33%; height: 60px">
                                                        Giá trị còn lại
                                                    </td>
                                                </tr>
                                                <tr style="height: 30%">
                                                    <td style="width: 33%">
                                                        Nguồn NS
                                                    </td>
                                                    <td style="width: 33%">
                                                        Nguồn khác
                                                    </td>
                                                </tr>
                                            </table>
                                        </HeaderTemplate>
                                        <HeaderStyle CssClass="" />
                                        <ItemTemplate>
                                            <table border="0" cellspacing="0" cellpadding="2" width="100%">
                                                <tr>
                                                    <td style="width: 33%; border-right: 1px solid gray;" height="40px" align="right">
                                                        <%# Eval("NGUON_NS", "{0:#,###}")%>
                                                    </td>
                                                    <td style="width: 33%; border-right: 1px solid gray;" align="right">
                                                        <%# Eval("NGUON_KHAC", "{0:#,###}")%>
                                                    </td>
                                                    <td style="width: 33%; border-right: 1px solid gray;" align="right">
                                                        <%# Eval("GIA_TRI_CON_LAI", "{0:#,###}")%>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <table border="1" cellspacing="0" cellpadding="2" width="100%" style="border-collapse: collapse;
                                                height: 100%">
                                                <tr style="height: 30%">
                                                    <td colspan="4" style="height: 60px">
                                                        Hiện trạng sử dụng (cái, chiếc)
                                                    </td>
                                                </tr>
                                                <tr style="height: 30%">
                                                    <td rowspan="2" style="width: 25%; height: 60px">
                                                        Quản lý nhà nước
                                                    </td>
                                                    <td colspan="2" style="width: 50%">
                                                        Hoạt đông sự nghiệp
                                                    </td>
                                                    <td rowspan="2" style="width: 25%">
                                                        Khác
                                                    </td>
                                                </tr>
                                                <tr style="height: 30%">
                                                    <td style="width: 25%">
                                                        Kinh doanh
                                                    </td>
                                                    <td style="width: 25%">
                                                        Không kinh doanh
                                                    </td>
                                                </tr>
                                            </table>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <table border="0" cellspacing="0" cellpadding="2" width="100%" style="border-collapse: collapse">
                                                <tr>
                                                    <td style="width: 25%; border-right: 1px solid gray;" height="40px" align="right">
                                                        <%# Eval("QLNN", "{0:#,###}")%>
                                                    </td>
                                                    <td style="width: 25%; border-right: 1px solid gray;" align="right">
                                                        <%# Eval("KINH_DOANH", "{0:#,###}")%>
                                                    </td>
                                                    <td style="width: 25%; border-right: 1px solid gray;" align="right">
                                                        <%# Eval("KHONG_KINH_DOANH", "{0:#,###}")%>
                                                    </td>
                                                    <td style="width: 25%; border-right: 1px solid gray;" align="right">
                                                        <%# Eval("HD_KHAC", "{0:#,###}")%>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:TemplateField>
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
