<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="F500_QuanLyOto.aspx.cs"
    EnableEventValidation="false" Inherits="ChucNang_F500_QuanLyOto" %>

<%@ Register Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"
    TagPrefix="asp" %>
<%@ Import Namespace="IP.Core.IPCommon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table cellspacing="0" cellpadding="2" style="width: 99%;" class="cssTable" border="0">
                <!--  Quan ly oto  -->
                <tr>
                    <td class="cssPageTitleBG" colspan="4">
                        <asp:Label ID="Label1" runat="server" CssClass="cssPageTitle" Text="Quản lý ô tô" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:ValidationSummary ID="vdsCategory" runat="server" CssClass="cssManField" Font-Bold="true"
                            ValidationGroup="m_vlg_nha" />
                        <asp:Label ID="Label2" runat="server" CssClass="cssManField" Style="color: Blue" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <table cellspacing="0" cellpadding="2" style="width: 100%;" class="cssTable" border="0">
                            <tr>
                                <td align="right" style="width: 15%;">
                                    <asp:Label ID="m_lbl_mess" runat="server" CssClass="cssManField" Style="color: Blue" />
                                </td>
                                <td align="left" colspan="1" style="width: 30%">
                                    &nbsp;
                                </td>
                                <td align="right" colspan="1" style="width: 15%">
                                    &nbsp;
                                </td>
                                <td align="left" class="style1" style="width: 30%">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 15%;">
                                    <asp:Label ID="lblFullName14" CssClass="cssManField" runat="server" Text="Bộ, Tỉnh" />
                                </td>
                                <td align="left" colspan="1" style="width: 30%">
                                    <asp:DropDownList ID="m_ddl_bo_tinh" runat="server" Width="85%" OnSelectedIndexChanged="m_ddl_bo_tinh_SelectedIndexChanged"
                                        AutoPostBack="True">
                                    </asp:DropDownList>
                                </td>
                                <td align="right" colspan="1" style="width: 15%">
                                    <asp:Label ID="lblFullName15" CssClass="cssManField" runat="server" Text="Đơn vị chủ quản" />
                                    &nbsp;
                                </td>
                                <td align="left" class="style1" style="width: 30%" colspan="1">
                                    <asp:DropDownList ID="m_ddl_dv_chu_quan" runat="server" Width="85%" OnSelectedIndexChanged="m_ddl_dv_chu_quan_SelectedIndexChanged"
                                        AutoPostBack="True">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 15%;">
                                    <asp:Label ID="lblFullName16" CssClass="cssManField" runat="server" Text="Đơn vị sử dụng tài sản" />
                                </td>
                                <td align="left" colspan="1" style="width: 30%">
                                    <asp:DropDownList ID="m_ddl_dv_sd_ts" runat="server" Width="85%" AutoPostBack="True">
                                    </asp:DropDownList>
                                </td>
                                <td align="right" colspan="1" style="width: 15%">
                                    <asp:Label ID="lblFullName19" CssClass="cssManField" runat="server" Text="Trạng thái ô tô" />
                                </td>
                                <td align="left" class="style1" style="width: 30%">
                                    <asp:DropDownList ID="m_ddl_trang_thai_oto" runat="server" Width="85%" AutoPostBack="True">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 15%;">
                                    <asp:Label ID="lblFullName13" CssClass="cssManField" runat="server" Text="Loại xe" />
                                </td>
                                <td align="left" colspan="1" style="width: 30%">
                                    <asp:DropDownList ID="m_ddl_loai_xe" runat="server" Width="85%" AutoPostBack="True">
                                    </asp:DropDownList>
                                </td>
                                <td align="right" colspan="1" style="width: 15%">
                                    &nbsp;
                                </td>
                                <td align="left" class="style1" style="width: 30%">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 15%;">
                                    <asp:Label ID="lblFullName18" CssClass="cssManField" runat="server" Text="Tên tài sản*" />
                                </td>
                                <td align="left" colspan="1" style="width: 30%">
                                    <asp:TextBox ID="m_txt_ten_ts" runat="server" CssClass="cssTextBox" Width="85%"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="m_rfv_ma_ts0" runat="server" ControlToValidate="m_txt_ma_ts"
                                        ErrorMessage="Bạn phải nhập Mã tài sản" Text="*" ValidationGroup="m_vlg_nha"></asp:RequiredFieldValidator>
                                </td>
                                <td align="right" colspan="1" style="width: 15%">
                                    <asp:Label ID="lblFullName17" CssClass="cssManField" runat="server" Text="Mã tài sản*" />
                                </td>
                                <td align="left" class="style1" style="width: 30%">
                                    <asp:TextBox ID="m_txt_ma_ts" runat="server" CssClass="cssTextBox" Width="85%"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="m_rfv_ma_ts1" runat="server" ControlToValidate="m_txt_ma_ts"
                                        ErrorMessage="Bạn phải nhập Mã tài sản" Text="*" ValidationGroup="m_vlg_nha"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 15%;">
                                    <asp:Label ID="lblFullName" CssClass="cssManField" runat="server" Text="Nhãn hiệu*" />
                                </td>
                                <td align="left" colspan="1" style="width: 30%">
                                    <asp:TextBox ID="m_txt_ten_nhan_hieu" runat="server" CssClass="cssTextBox" Width="85%"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="m_rfv_nhan_hieu0" runat="server" ControlToValidate="m_txt_ten_nhan_hieu"
                                        ErrorMessage="Bạn phải nhập Nhãn hiệu" Text="*" ValidationGroup="m_vlg_nha"></asp:RequiredFieldValidator>
                                </td>
                                <td align="right" colspan="1" style="width: 15%">
                                    <asp:Label ID="Label17" CssClass="cssManField" runat="server" Text="Biển kiểm soát*" />
                                </td>
                                <td align="left" class="style1" style="width: 30%">
                                    <asp:TextBox ID="m_txt_bien_kiem_soat" runat="server" CssClass="cssTextBox" Width="85%"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="m_rfv_nhan_hieu" runat="server" ControlToValidate="m_txt_bien_kiem_soat"
                                        ErrorMessage="Bạn phải nhập Biển kiểm soát" Text="*" ValidationGroup="m_vlg_nha"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 15%;">
                                    <asp:Label ID="Label19" CssClass="cssManField" runat="server" Text="Công suất xe*" />
                                </td>
                                <td align="left" colspan="1" style="width: 30%">
                                    <asp:TextBox ID="m_txt_cong_suat_xe" runat="server" CssClass="cssTextBox csscurrency"
                                        Width="85%"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="m_rfv_cong_suat_xe" runat="server" ControlToValidate="m_txt_cong_suat_xe"
                                        ErrorMessage="Bạn phải nhập Công suất xe" Text="*" ValidationGroup="m_vlg_nha"></asp:RequiredFieldValidator>
                                </td>
                                <td align="right" colspan="1" style="width: 15%">
                                    <asp:Label ID="Label20" CssClass="cssManField" runat="server" Text="Chức danh sử dụng xe" />
                                </td>
                                <td align="left" class="style1" style="width: 30%">
                                    <asp:TextBox ID="m_txt_chuc_danh_sd_xe" runat="server" CssClass="cssTextBox" Width="85%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 15%;">
                                    <asp:Label ID="Label21" CssClass="cssManField" runat="server" Text="Nguồn gốc xe" />
                                </td>
                                <td align="left" colspan="1" style="width: 30%">
                                    <asp:TextBox ID="m_txt_nguon_goc_xe" runat="server" CssClass="cssTextBox" Width="85%"></asp:TextBox>
                                </td>
                                <td align="right" colspan="1" style="width: 15%">
                                    <asp:Label ID="Label18" CssClass="cssManField" runat="server" Text="Năm sử dụng" />
                                </td>
                                <td align="left" class="style1" style="width: 30%">
                                    <asp:TextBox ID="m_txt_nam_su_dung" runat="server" CssClass="cssTextBox" Width="85%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 15%;">
                                    <asp:Label ID="Label14" CssClass="cssManField" runat="server" Text="Số chỗ ngồi/Tải trọng*" />
                                </td>
                                <td align="left" colspan="1" style="width: 30%">
                                    <asp:TextBox ID="m_txt_tai_trong" runat="server" CssClass="cssTextBox" Width="85%"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="m_rfv_so_cho_ngoi0" runat="server" ControlToValidate="m_txt_tai_trong"
                                        ErrorMessage="Bạn phải nhập Số chỗ ngồi" Text="*" ValidationGroup="m_vlg_nha"></asp:RequiredFieldValidator>
                                </td>
                                <td align="right" colspan="1" style="width: 15%">
                                    &nbsp;
                                </td>
                                <td align="left" class="style1" style="width: 30%">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 15%;">
                                    &nbsp;
                                </td>
                                <td align="left" colspan="1" style="width: 30%">
                                    GIÁ TRỊ THEO SỔ KẾ TOÁN (VNĐ)
                                </td>
                                <td align="right" colspan="1" style="width: 15%">
                                    &nbsp;
                                </td>
                                <td align="left" class="style1" style="width: 30%">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 15%;">
                                    <asp:Label ID="lblFullName4" CssClass="cssManField" runat="server" Text="Nguyên giá nguồn NS*" />
                                </td>
                                <td align="left" colspan="1" style="width: 30%">
                                    <asp:TextBox ID="m_txt_nguon_ns" runat="server" CssClass="cssTextBox csscurrency"
                                        Width="85%"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="m_rfv_nguon_ns0" runat="server" ControlToValidate="m_txt_nguon_ns"
                                        ErrorMessage="Bạn phải nhập Nguồn NS" Text="*" ValidationGroup="m_vlg_nha"></asp:RequiredFieldValidator>
                                </td>
                                <td align="right" colspan="1" style="width: 15%">
                                    <asp:Label ID="lblFullName5" CssClass="cssManField" runat="server" Text="Nguyên giá nguồn khác*" />
                                </td>
                                <td align="left" class="style1" style="width: 30%">
                                    <asp:TextBox ID="m_txt_nguon_khac" runat="server" CssClass="cssTextBox csscurrency"
                                        Width="85%"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="m_rfv_nguon_ns1" runat="server" ControlToValidate="m_txt_nguon_khac"
                                        ErrorMessage="Bạn phải nhập Nguồn Khác" Text="*" ValidationGroup="m_vlg_nha"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 15%;">
                                    <asp:Label ID="lblFullName6" CssClass="cssManField" runat="server" Text="Giá trị còn lại*" />
                                </td>
                                <td align="left" colspan="1" style="width: 30%">
                                    <asp:TextBox ID="m_txt_gia_tri_con_lai" runat="server" CssClass="cssTextBox csscurrency"
                                        Width="85%"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="m_rfv_gia_tri_con_lai" runat="server" ControlToValidate="m_txt_gia_tri_con_lai"
                                        ErrorMessage="Bạn phải nhập Giá trị còn lại" Text="*" ValidationGroup="m_vlg_nha"></asp:RequiredFieldValidator>
                                </td>
                                <td align="right" colspan="1" style="width: 15%">
                                    &nbsp;
                                </td>
                                <td align="left" class="style1" style="width: 30%">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 15%;">
                                    <asp:Label ID="Label15" CssClass="cssManField" runat="server" Text="Nước sản xuất" />
                                </td>
                                <td align="left" colspan="1" style="width: 30%">
                                    <asp:TextBox ID="m_txt_nuoc_san_xuat" runat="server" CssClass="cssTextBox" Width="85%"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="m_rfv_nuoc_san_xuat" runat="server" ControlToValidate="m_txt_nuoc_san_xuat"
                                        ErrorMessage="Bạn phải nhập Nước sản xuất" Text="*" ValidationGroup="m_vlg_nha"></asp:RequiredFieldValidator>
                                </td>
                                <td align="right" colspan="1" style="width: 15%">
                                    <asp:Label ID="Label4" CssClass="cssManField" runat="server" Text="Năm sản xuất" />
                                </td>
                                <td align="left" class="style1" style="width: 30%">
                                    <asp:TextBox ID="m_txt_nam_san_xuat" runat="server" CssClass="cssTextBox" Width="85%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 15%;">
                                    &nbsp;
                                </td>
                                <td align="left" colspan="1" style="width: 30%">
                                    HIỆN TRẠNG SỬ DỤNG (Điền 1 nếu ô tô sử dụng cho mục đích đó)
                                </td>
                                <td align="right" colspan="1" style="width: 15%">
                                    &nbsp;
                                </td>
                                <td align="left" class="style1" style="width: 30%">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 15%;">
                                    <asp:Label ID="lblFullName8" CssClass="cssManField" runat="server" Text="Quản lý nhà nước*" />
                                </td>
                                <td align="left" colspan="1" style="width: 30%">
                                    <asp:TextBox ID="m_txt_qlnn" runat="server" CssClass="cssTextBox csscurrency" Width="85%"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="m_rfv_qlnn" runat="server" ControlToValidate="m_txt_qlnn"
                                        ErrorMessage="Bạn phải nhập QLNN" Text="*" ValidationGroup="m_vlg_nha"></asp:RequiredFieldValidator>
                                </td>
                                <td align="right" colspan="1" style="width: 15%">
                                    <asp:Label ID="lblFullName12" CssClass="cssManField" runat="server" Text="HĐSN KHÔNG kinh doanh*" />
                                </td>
                                <td align="left" class="style1" style="width: 30%">
                                    <asp:TextBox ID="m_txt_khong_kinh_doanh" runat="server" CssClass="cssTextBox csscurrency"
                                        Width="85%"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="m_rfv_khong_kinh_doanh" runat="server" ControlToValidate="m_txt_khong_kinh_doanh"
                                        ErrorMessage="Bạn phải nhập Không kinh doanh" Text="*" ValidationGroup="m_vlg_nha"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 15%;">
                                    <asp:Label ID="lblFullName11" CssClass="cssManField" runat="server" Text="HĐSN Kinh doanh*" />
                                </td>
                                <td align="left" colspan="1" style="width: 30%">
                                    <asp:TextBox ID="m_txt_kinh_doanh" runat="server" CssClass="cssTextBox csscurrency"
                                        Width="85%"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="m_rfv_kinh_doanh" runat="server" ControlToValidate="m_txt_kinh_doanh"
                                        ErrorMessage="Bạn phải nhập Kinh doanh" Text="*" ValidationGroup="m_vlg_nha"></asp:RequiredFieldValidator>
                                </td>
                                <td align="right" colspan="1" style="width: 15%">
                                    <asp:Label ID="lblFullName10" CssClass="cssManField" runat="server" Text="Hoạt động khác*" />
                                </td>
                                <td align="left" class="style1" style="width: 30%">
                                    <asp:TextBox ID="m_txt_hd_khac" runat="server" CssClass="cssTextBox csscurrency"
                                        Width="85%"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="m_rfv_hd_khac" runat="server" ControlToValidate="m_txt_hd_khac"
                                        ErrorMessage="Bạn phải nhập HĐ khác" Text="*" ValidationGroup="m_vlg_nha"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 15%;">
                                    &nbsp;
                                </td>
                                <td align="left" colspan="1" style="width: 30%">
                                    &nbsp;
                                </td>
                                <td align="right" colspan="1" style="width: 15%">
                                    &nbsp;
                                </td>
                                <td align="left" class="style1" style="width: 30%">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="left" colspan="1" style="width: 15%">
                                    &nbsp;
                                </td>
                                <td align="left" style="width: 35%" colspan="1">
                                    <asp:Button ID="m_cmd_tao_moi" runat="server" AccessKey="c" CssClass="cssButton"
                                        OnClick="m_cmd_tao_moi_Click" Text="Tạo mới(c)" Width="98px" Height="24px" ValidationGroup="m_vlg_nha" />
                                    <asp:Button ID="m_cmd_cap_nhat" runat="server" AccessKey="u" CssClass="cssButton"
                                        OnClick="m_cmd_cap_nhat_Click" Text="Cập nhật(u)" Width="98px" Height="24px"
                                        ValidationGroup="m_vlg_nha" />
                                    <asp:Button ID="btnCancel" runat="server" AccessKey="r" CssClass="cssButton" OnClick="btnCancel_Click"
                                        Text="Xóa trắng(r)" Width="98px" Height="24px" TabIndex="25" />
                                </td>
                                <td colspan="1">
                                    &nbsp;
                                </td>
                                <td align="left" colspan="1" style="width: 30%;">
                                    <asp:HiddenField ID="m_hdf_id" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" colspan="1" style="width: 15%">
                                </td>
                                <td align="left" style="width: 15%" colspan="1">
                                    &nbsp;
                                </td>
                                <td align="left" style="width: 15%" colspan="1">
                                    &nbsp;
                                </td>
                                <td align="right" style="width: 15%">
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <!-- End Quan ly oto   -->
                <!-- Ket qua loc du lieu  -->
                <tr>
                    <td class="cssPageTitleBG" colspan="3">
                        <asp:Label ID="m_lbl_ket_qua_loc_du_lieu" runat="server" CssClass="cssPageTitle"
                            Text="DANH SÁCH Ô TÔ" />
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 10%;">
                        <asp:Label ID="lbl_ghi_chu0" runat="server" CssClass="cssManField" Text="Từ khóa tìm kiếm" />
                    </td>
                    <td align="left" colspan="1" style="width: 25%">
                        <asp:TextBox ID="m_txt_tim_kiem" runat="server" CssClass="cssTextBox" Width="100%"></asp:TextBox>
                    </td>
                    <td align="left" style="width: 30%;" colspan="1">
                        <asp:Button ID="m_cmd_tim_kiem" runat="server" AccessKey="c" CssClass="cssButton"
                            OnClick="m_cmd_tim_kiem_Click" Text="Tìm kiếm(s)" Width="98px" Height="24px" />
                        <asp:Button ID="m_cmd_export_excel" runat="server" AccessKey="x" CssClass="cssButton"
                            Text="Xuất Excel(x)" Width="98px" Height="24px" OnClick="m_cmd_export_excel_Click" />
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="2">
                        &nbsp;<br />
                        <asp:Label ID="m_lbl_thong_bao" runat="server" CssClass="cssManField" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <!-- End Ket qua loc du lieu  -->
            </table>
            <table cellspacing="0" cellpadding="2" style="width: 99%;" class="cssTable">
                <!--  Gridview  -->
                <tr>
                    <td align="center" colspan="3" style="height: 450px;" valign="top">
                        &nbsp;
                        <asp:GridView ID="m_grv_dm_oto" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            Width="100%" DataKeyNames="ID" CellPadding="0" ForeColor="#333333" AllowSorting="True"
                            PageSize="15" ShowHeader="true" OnPageIndexChanging="m_grv_dm_oto_PageIndexChanging"
                            OnRowCommand="m_grv_danh_sach_nha_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="Xóa" ItemStyle-Width="2%" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="m_lbt_delete" runat="server" CommandName="DeleteComp" ToolTip="Xóa"
                                            OnClientClick="return confirm ('Bạn có thực sự muốn xóa bản ghi này?')" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'>
                     <img src="../Images/Button/deletered.png" alt="Delete" />
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sửa" ItemStyle-HorizontalAlign="center">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="m_lbt_edit" runat="server" CommandName="EditComp" ToolTip="Sửa"
                                            CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'>
                     <img src="../Images/Button/edit.png" alt="Edit" />
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-Width="3%" ItemStyle-HorizontalAlign="center" HeaderText="STT">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
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
                                <asp:BoundField HeaderText="Nhãn hiệu" DataField="NHAN_HIEU" />
                                <asp:BoundField HeaderText="Biển kiểm soát" DataField="BIEN_KIEM_SOAT" />
                                <asp:BoundField HeaderText="Số chỗ ngồi" DataField="SO_CHO_NGOI" />
                                <asp:BoundField HeaderText="Công suất xe" DataField="CONG_SUAT_XE" />
                                <asp:BoundField HeaderText="Chức danh sử dụng" DataField="CHUC_DANH_SU_DUNG" />
                                <asp:BoundField HeaderText="Nguồn gốc xe" DataField="NGUON_GOC_XE" />
                                <asp:BoundField HeaderText="Nước sản xuất" DataField="NUOC_SAN_XUAT" />
                                <asp:BoundField HeaderText="Năm sản xuất" DataField="NAM_SAN_XUAT" />
                                <asp:BoundField HeaderText="Ngày/tháng/năm sử dụng" DataField="NAM_SU_DUNG" />
                                <asp:TemplateField HeaderStyle-Width="20%">
                                    <HeaderTemplate>
                                        <table border="1" cellspacing="0" cellpadding="2" width="100%" style="border-collapse: collapse;">
                                            <tr>
                                                <td colspan="3" style="height: 15px">
                                                    Giá trị theo sổ kế toán (VNĐ)
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="width: 66%; height: 20px">
                                                    Nguyên giá
                                                </td>
                                                <td rowspan="2" style="width: 33%; height: 80px">
                                                    Giá trị còn lại
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 33%">
                                                    Nguồn NS
                                                </td>
                                                <td style="width: 33%">
                                                    Nguồn khác
                                                </td>
                                            </tr>
                                        </table>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <table border="0" cellspacing="0" cellpadding="2" width="100%">
                                            <tr>
                                                <td style="width: 33%; height: 40px; border-right: 1px solid gray; text-align: right;">
                                                    <%# Eval("NGUON_NS", "{0:#,###}")%>
                                                </td>
                                                <td style="width: 33%; border-right: 1px solid gray; text-align: right;">
                                                    <%# Eval("NGUON_KHAC", "{0:#,###}")%>
                                                </td>
                                                <td style="width: 33%; text-align: right;">
                                                    <%# Eval("GIA_TRI_CON_LAI", "{0:#,###}")%>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <table border="1" cellspacing="0" cellpadding="2" width="100%" style="border-collapse: collapse">
                                            <tr>
                                                <td colspan="7" style="height: 15px;">
                                                    Hiện trạng sử dụng
                                                </td>
                                            </tr>
                                            <tr>
                                                <td rowspan="2" style="width: 25%; height: 80px;">
                                                    Quản lý nhà nước
                                                </td>
                                                <td colspan="2" style="width: 50%">
                                                    Hoạt động sự nghiệp
                                                </td>
                                                <td rowspan="2" style="width: 25%">
                                                    Khác
                                                </td>
                                            </tr>
                                            <tr>
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
                                        <table border="0" cellspacing="0" cellpadding="2" width="100%">
                                            <tr>
                                                <td style="width: 25%; height: 40px; border-right: 1px solid gray; text-align: right;">
                                                    <%# Eval("QLNN") %>
                                                </td>
                                                <td style="width: 25%; border-right: 1px solid gray; text-align: right;">
                                                    <%# Eval("KINH_DOANH") %>
                                                </td>
                                                <td style="width: 25%; border-right: 1px solid gray; text-align: right;">
                                                    <%# Eval("KHONG_KINH_DOANH") %>
                                                </td>
                                                <td style="width: 25%; text-align: right;">
                                                    <%# Eval("HD_KHAC") %>
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
                <!--End Gridview-->
            </table>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="m_cmd_export_excel" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
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
