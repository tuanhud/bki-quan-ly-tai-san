<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="F200_DanhMucTaiSanKhac.aspx.cs" Inherits="Default2" %>

<%@ Register Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"
    TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table cellspacing="0" cellpadding="2" style="width: 99%;" class="cssTable" border="0">
                    <tr>
                        <td class="cssPageTitleBG" colspan="4">
                            <span class="cssPageTitle">Quản lý tài sản khác</span> <span class="expand-collapse-text initial-expand">
                            </span><span class="expand-collapse-text"></span>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:ValidationSummary ID="vdsCategory" runat="server" CssClass="cssManField" Font-Bold="true" />
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
                                        <asp:DropDownList ID="m_cbo_don_vi_su_dung" runat="server" Width="85%">
                                        </asp:DropDownList>
                                    </td>
                                    <td align="left" style="width: 1%;">
                                    </td>
                                    <td align="right" style="width: 15%">
                                        <span class="cssManField">Trạng thái tài sản</span>
                                    </td>
                                    <td align="left" style="width: 30%;">
                                        <asp:DropDownList ID="m_cbo_trang_thai_tai_san" runat="server" Width="85%">
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
                                            ValidationGroup="m_vlg_tsk"></asp:TextBox>
                                    </td>
                                    <td align="left" style="width: 1%;">
                                        (*)
                                        <asp:RequiredFieldValidator ID="m_rfv_ten_tai_San" runat="server" ControlToValidate="m_txt_ten_tai_san"
                                            ErrorMessage="Bạn phải nhập Tên tài sản" Text="*" ValidationGroup="m_vlg_tsk"></asp:RequiredFieldValidator>
                                    </td>
                                    <td align="right" style="width: 15%">
                                        <span class="cssManField">Mã tài sản</span>
                                    </td>
                                    <td align="left" style="width: 30%;">
                                        <asp:TextBox ID="m_txt_ma_tai_san" runat="server" CssClass="cssTextBox" Width="85%"
                                            ValidationGroup="m_vlg_tsk"></asp:TextBox>
                                    </td>
                                    <td align="left" style="width: 1%;">
                                        (*)
                                        <asp:RequiredFieldValidator ID="m_rfv_ma_tai_san" runat="server" ControlToValidate="m_txt_ma_tai_san"
                                            ErrorMessage="Bạn phải nhập Mã Tài sản" Text="*" ValidationGroup="m_vlg_tsk"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 15%">
                                        <span class="cssManField">Ký hiệu</span>
                                    </td>
                                    <td style="width: 30%" align="left">
                                        <asp:TextBox ID="m_txt_ky_hieu" runat="server" CssClass="cssTextBox" Width="85%"
                                            ValidationGroup="m_vlg_tsk"></asp:TextBox>
                                    </td>
                                    <td align="left" style="width: 1%;">
                                        (*)
                                        <asp:RequiredFieldValidator ID="m_rfv_ky_hieu" runat="server" ControlToValidate="m_txt_ky_hieu"
                                            ErrorMessage="Bạn phải nhập Ký hiệu" Text="*" ValidationGroup="m_vlg_tsk"></asp:RequiredFieldValidator>
                                    </td>
                                    <td align="right" style="width: 15%">
                                        <span class="cssManField">Nước sản xuất</span>
                                    </td>
                                    <td align="left" style="width: 30%;">
                                        <asp:TextBox ID="m_txt_nuoc_sx" runat="server" CssClass="cssTextBox" Width="85%"
                                            ValidationGroup="m_vlg_tsk"></asp:TextBox>
                                    </td>
                                    <td align="left" style="width: 1%;">
                                        (*)
                                        <asp:RequiredFieldValidator ID="m_rfv_nuoc_sx" runat="server" ControlToValidate="m_txt_nuoc_sx"
                                            ErrorMessage="Bạn phải nhập Nước sản xuất" Text="*" ValidationGroup="m_vlg_tsk"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 15%">
                                        <span class="cssManField">Năm sản xuất</span>
                                    </td>
                                    <td style="width: 30%" align="left">
                                        <asp:TextBox ID="m_txt_nam_sx" runat="server" CssClass="cssTextBox" Width="85%" ValidationGroup="m_vlg_tsk"></asp:TextBox>
                                    </td>
                                    <td align="left" style="width: 1%;">
                                        (*)
                                        <asp:RequiredFieldValidator ID="m_rfv_nam_sx" runat="server" ControlToValidate="m_txt_nam_sx"
                                            ErrorMessage="Bạn phải nhập Mã Tài sản" Text="*" ValidationGroup="m_vlg_tsk"></asp:RequiredFieldValidator>
                                    </td>
                                    <td align="right" style="width: 15%">
                                        <span class="cssManField">Năm sử dụng</span>
                                    </td>
                                    <td align="left" style="width: 30%;">
                                        <asp:TextBox ID="m_txt_ngay_su_dung" runat="server" CssClass="cssTextBox" Width="85%"
                                            ValidationGroup="m_vlg_tsk"></asp:TextBox>
                                    </td>
                                    <td align="left" style="width: 1%;">
                                        (*)
                                        <asp:RequiredFieldValidator ID="m_rfv_ngay_su_dung" runat="server" ControlToValidate="m_txt_ngay_su_dung"
                                            ErrorMessage="Bạn phải nhập Ngày sử dụng" Text="*" ValidationGroup="m_vlg_tsk"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
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
                                        <span class="cssManField">Nguyên giá nguồn NS</span>
                                    </td>
                                    <td style="width: 30%" align="left">
                                        <asp:TextBox ID="m_txt_nguyen_gia_nguon_ns" runat="server" CssClass="cssTextBox csscurrency"
                                            Width="85%" ValidationGroup="m_vlg_tsk"></asp:TextBox>
                                    </td>
                                    <td align="left" style="width: 1%;">
                                        (*)
                                        <asp:RequiredFieldValidator ID="m_rfv_nguon_ngan_sach" runat="server" ControlToValidate="m_txt_nguyen_gia_nguon_ns"
                                            ErrorMessage="Bạn phải nhập Nguồn ngân sách" Text="*" ValidationGroup="m_vlg_tsk"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="m_cp_nguon_ngan_sach" runat="server" ControlToValidate="m_txt_nguyen_gia_nguon_ns"
                                            ErrorMessage="Bạn không được nhập số âm vào Nguồn ngân sách" Text="*" Operator="GreaterThanEqual"
                                            ValueToCompare="0" ValidationGroup="m_vlg_tsk"></asp:CompareValidator>
                                    </td>
                                    <td align="right" style="width: 15%">
                                        <span class="cssManField">Nguyên giá nguồn khác</span>
                                    </td>
                                    <td align="left" style="width: 30%;">
                                        <asp:TextBox ID="m_txt_nguyen_gia_nguon_khac" runat="server" CssClass="cssTextBox csscurrency"
                                            Width="85%" ValidationGroup="m_vlg_tsk"></asp:TextBox>
                                    </td>
                                    <td align="left" style="width: 1%;">
                                        (*)
                                        <asp:RequiredFieldValidator ID="m_rfv_nguon_khac" runat="server" ControlToValidate="m_txt_nguyen_gia_nguon_khac"
                                            ErrorMessage="Bạn phải nhập Nguồn khác" Text="*" ValidationGroup="m_vlg_tsk"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="m_cp_nguon_khac" runat="server" ControlToValidate="m_txt_nguyen_gia_nguon_khac"
                                            ErrorMessage="Bạn không được nhập số âm vào Nguồn khác" Text="*" Operator="GreaterThanEqual"
                                            ValueToCompare="0" ValidationGroup="m_vlg_tsk"></asp:CompareValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 15%">
                                        <span class="cssManField">Giá trị còn lại</span>
                                    </td>
                                    <td style="width: 30%" align="left">
                                        <asp:TextBox ID="m_txt_gia_tri_con_lai" runat="server" CssClass="cssTextBox csscurrency"
                                            Width="85%" ValidationGroup="m_vlg_tsk"></asp:TextBox>
                                    </td>
                                    <td align="left" style="width: 1%;">
                                        (*)
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
                                        <span class="cssManField">Quản lý nhà nước</span>
                                    </td>
                                    <td style="width: 30%" align="left">
                                        <asp:TextBox ID="m_txt_quan_ly_nha_nuoc" runat="server" CssClass="cssTextBox csscurrency"
                                            align="left" Width="85%" ValidationGroup="m_vlg_tsk"></asp:TextBox>
                                    </td>
                                    <td align="left" style="width: 1%;">
                                        (*)
                                        <asp:RequiredFieldValidator ID="m_rfv_quan_ly_nha_nuoc" runat="server" ControlToValidate="m_txt_quan_ly_nha_nuoc"
                                            ErrorMessage="Bạn phải nhập Quản lý nhà nước" Text="*" ValidationGroup="m_vlg_tsk"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="m_cp_quan_ly_nha_nuoc" runat="server" ControlToValidate="m_txt_quan_ly_nha_nuoc"
                                            ErrorMessage="Bạn không được nhập số âm vào Quản lý nhà nước" Text="*" Operator="GreaterThanEqual"
                                            ValueToCompare="0" ValidationGroup="m_vlg_tsk"></asp:CompareValidator>
                                    </td>
                                    <td align="right" style="width: 15%">
                                    </td>
                                    <td align="left" style="width: 30%;">
                                        &nbsp;
                                    </td>
                                    <td align="left" style="width: 1%;">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 15%">
                                        <span class="cssManField">HĐSN (Kinh doanh)</span>
                                    </td>
                                    <td style="width: 30%" align="left">
                                        <asp:TextBox ID="m_txt_kinh_doanh" runat="server" CssClass="cssTextBox csscurrency"
                                            align="left" Width="85%" ValidationGroup="m_vlg_tsk"></asp:TextBox>
                                    </td>
                                    <td align="left" style="width: 1%;">
                                        (*)
                                        <asp:RequiredFieldValidator ID="m_rfv_kinh_doanh" runat="server" ControlToValidate="m_txt_kinh_doanh"
                                            ErrorMessage="Bạn phải nhập Kinh doanh" Text="*" ValidationGroup="m_vlg_tsk"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="m_cp_kinh_doanh" runat="server" ControlToValidate="m_txt_kinh_doanh"
                                            ErrorMessage="Bạn không được nhập số âm vào Kinh doanh" Text="*" Operator="GreaterThanEqual"
                                            ValueToCompare="0" ValidationGroup="m_vlg_tsk"></asp:CompareValidator>
                                    </td>
                                    <td align="right" style="width: 15%">
                                        <span class="cssManField">HĐSN(Không kinh doanh)</span>
                                    </td>
                                    <td align="left" style="width: 30%;">
                                        <asp:TextBox ID="m_txt_khong_kinh_doanh" runat="server" CssClass="cssTextBox csscurrency"
                                            align="left" Width="85%" ValidationGroup="m_vlg_tsk"></asp:TextBox>
                                    </td>
                                    <td align="left" style="width: 1%;">
                                        (*)
                                        <asp:RequiredFieldValidator ID="m_rfv_khong_kinh_doanh" runat="server" ControlToValidate="m_txt_khong_kinh_doanh"
                                            ErrorMessage="Bạn phải nhập Không kinh doanh" Text="*" ValidationGroup="m_vlg_tsk"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="m_cp_khong_kinh_doanh" runat="server" ControlToValidate="m_txt_khong_kinh_doanh"
                                            ErrorMessage="Bạn không được nhập số âm vào Không kinh doanh" Text="*" Operator="GreaterThanEqual"
                                            ValueToCompare="0" ValidationGroup="m_vlg_tsk"></asp:CompareValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 15%">
                                        <span class="cssManField">Khác</span>
                                    </td>
                                    <td style="width: 30%" align="left">
                                        <asp:TextBox ID="m_txt_khac" runat="server" CssClass="cssTextBox csscurrency" Width="85%"
                                            align="left" ValidationGroup="m_vlg_tsk"></asp:TextBox>
                                    </td>
                                    <td align="left" style="width: 1%;">
                                        (*)
                                        <asp:RequiredFieldValidator ID="m_rfv_khac" runat="server" ControlToValidate="m_txt_khac"
                                            ErrorMessage="Bạn phải nhập Khác" Text="*" ValidationGroup="m_vlg_tsk"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="m_cp_khac" runat="server" ControlToValidate="m_txt_khac"
                                            ErrorMessage="Bạn không được nhập số âm vào Khác" Text="*" Operator="GreaterThanEqual"
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
                                        &nbsp;
                                    </td>
                                    <td colspan="4" align="left">
                                        <asp:Button ID="m_cmd_tao_moi" AccessKey="c" CssClass="cssButton" runat="server"
                                            Width="98px" Text="Tạo mới(c)" OnClick="m_cmd_tao_moi_Click" ValidationGroup="m_vlg_tsk" />&nbsp;
                                        <asp:Button ID="m_cmd_cap_nhat" AccessKey="u" CssClass="cssButton" runat="server"
                                            Width="98px" Text="Cập nhật(u)" OnClick="m_cmd_cap_nhat_Click" ValidationGroup="m_vlg_tsk" />&nbsp;
                                        <asp:Button ID="m_cmd_xoa_trang" AccessKey="r" CssClass="cssButton" runat="server"
                                            Width="98px" Text="Xóa trắng(r)" OnClick="m_cmd_xoa_trang_Click" />
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
                            <asp:TextBox ID="m_txt_tim_kiem" runat="server" CssClass="cssTextBox" Width="85%"></asp:TextBox>
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
                            <asp:Button ID="m_cmd_an" runat="server" CausesValidation="False" 
                                CssClass="cssButton" Height="25px" OnClick="m_cmd_an_Click" Text="Ẩn" 
                                Width="98px" />
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
                                PageSize="15" ShowHeader="true" OnRowUpdating="m_grv_tai_san_khac_RowUpdating"
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
                                    <asp:BoundField HeaderText="Ký hiệu" DataField="KY_HIEU" />
                                    <asp:BoundField HeaderText="Nước sản xuất" DataField="NUOC_SAN_XUAT" />
                                    <asp:BoundField HeaderText="Năm sản xuất" DataField="NAM_SAN_XUAT" ItemStyle-HorizontalAlign="Center" />
                                    <asp:BoundField HeaderText="Ngày, tháng, năm sử dụng" DataField="NAM_SU_DUNG" ItemStyle-HorizontalAlign="Center" />
                                    <asp:TemplateField HeaderStyle-Width="25%" HeaderStyle-Height="75px">
                                        <HeaderTemplate>
                                            <table border="1" cellspacing="0" cellpadding="3" width="100%" style="border-collapse: collapse;
                                                height: 100%">
                                                <tr style="height: 30%">
                                                    <td colspan="3" style="height: 100%">
                                                        Giá trị theo sổ kế toán
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
                                                    <td style="width: 33%; border-right: solid; border-right-width: 1px" height="40px"
                                                        align="right">
                                                        <%# Eval("NGUON_NS", "{0:#,###}")%>
                                                    </td>
                                                    <td style="width: 33%; border-right: solid; border-right-width: 1px" align="right">
                                                        <%# Eval("NGUON_KHAC", "{0:#,###}")%>
                                                    </td>
                                                    <td style="width: 33%; border-right: solid; border-right-width: 1px" align="right">
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
                                                        Hiện trạng sử dụng
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
                                                    <td style="width: 25%; border-right: solid; border-right-width: 1px" height="40px"
                                                        align="right">
                                                        <%# Eval("QLNN") %>
                                                    </td>
                                                    <td style="width: 25%; border-right: solid; border-right-width: 1px" align="right">
                                                        <%# Eval("KINH_DOANH") %>
                                                    </td>
                                                    <td style="width: 25%; border-right: solid; border-right-width: 1px" align="right">
                                                        <%# Eval("KHONG_KINH_DOANH") %>
                                                    </td>
                                                    <td style="width: 25%; border-right: solid; border-right-width: 1px" align="right">
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
