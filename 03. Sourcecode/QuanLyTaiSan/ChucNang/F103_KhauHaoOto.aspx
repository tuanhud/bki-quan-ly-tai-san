<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="F103_KhauHaoOto.aspx.cs" Inherits="ChucNang_F103_KhauHaoOto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table cellspacing="0" cellpadding="2" style="width: 99%;" class="cssTable" border="0">
        <!--  Quan ly oto  -->
        <tr>
            <td class="cssPageTitleBG" colspan="4">
                <asp:Label ID="m_lbl_title" runat="server" CssClass="cssPageTitle" Text="Khấu hao ô tô" />
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:ValidationSummary ID="vdsCategory" runat="server" CssClass="cssManField" Font-Bold="true"
                    ValidationGroup="m_vlg_oto" />
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <table cellspacing="0" cellpadding="2" style="width: 100%;" class="cssTable" border="0">
                    <tr>
                        <td align="right" style="width: 20%;">
                            <asp:Label ID="m_lbl_mess" runat="server" CssClass="cssManField" />
                        </td>
                        <td align="left" colspan="1" style="width: 30%">
                            &nbsp;
                        </td>
                        <td align="right" colspan="1" style="width: 20%">
                            &nbsp;
                        </td>
                        <td align="left" colspan="1" style="width: 30%">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 20%;" class="cssManField">
                            <span>Bộ, tỉnh:</span>
                        </td>
                        <td align="left" colspan="1" style="width: 30%">
                            <asp:DropDownList ID="m_cbo_bo_tinh_up" runat="server" Width="85%" AutoPostBack="True"
                                OnSelectedIndexChanged="m_cbo_bo_tinh_up_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td align="right" colspan="1" class="cssManField" style="width: 20%">
                            <span>Đơn vị chủ quản</span>
                        </td>
                        <td align="left" class="style1" style="width: 30%" colspan="1">
                            <asp:DropDownList ID="m_cbo_don_vi_chu_quan_up" runat="server" Width="85%" AutoPostBack="True"
                                OnSelectedIndexChanged="m_cbo_don_vi_chu_quan_up_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="cssManField" style="width: 20%;">
                            <span>Đơn vi sử dụng tài sản:</span>
                        </td>
                        <td align="left" colspan="1" style="width: 30%">
                            <asp:DropDownList ID="m_cbo_don_vi_su_dung_tai_san_up" runat="server" Width="85%"
                                AutoPostBack="True" OnSelectedIndexChanged="m_cbo_don_vi_su_dung_tai_san_up_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td align="right" colspan="1" class="cssManField" style="width: 20%">
                            <span>Trạng thái ô tô</span>
                        </td>
                        <td align="left" class="style1" style="width: 30%">
                            <asp:DropDownList ID="m_cbo_trang_thai_o_to_up" runat="server" Width="85%" AutoPostBack="True"
                                OnSelectedIndexChanged="m_cbo_trang_thai_o_to_up_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <tr>
                            <td align="right" class="cssManField">
                                <span>Loại ô tô:</span>
                            </td>
                            <td>
                                <asp:DropDownList ID="m_cbo_loai_o_to_up" runat="Server" Width="85%" OnSelectedIndexChanged="m_cbo_loai_o_to_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>
                            <td align="right" style="width: 20%;" class="cssManField">
                                <span>Tên tài sản:</span>
                            </td>
                            <td align="left" colspan="1" style="width: 30%">
                                <asp:TextBox ID="m_txt_ten_tai_san" runat="server" CssClass="cssTextBox" Width="85%"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="m_rfv_ten_tai_san" runat="server" ControlToValidate="m_txt_ten_tai_san"
                                    ErrorMessage="Bạn phải nhập Tên Tài Sản" Text="*" ValidationGroup="m_vlg_oto"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="cssManField" colspan="1" style="width: 20%">
                                <span>Mã tài sản:</span>
                            </td>
                            <td align="left" class="style1" style="width: 30%">
                                <asp:Label ID="m_lbl_ma_tai_san" runat="Server" class="cssManField" Style="color: blue"></asp:Label>
                            </td>
                            <td align="right" class="cssManField" style="width: 20%;">
                                <span>Nhãn hiệu:</span>
                            </td>
                            <td align="left" colspan="1" style="width: 30%">
                                <asp:Label ID="m_lbl_nhan_hieu" runat="server" class="cssManField" Style="color: blue"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" colspan="1" class="cssManField" style="width: 20%">
                                <span>Biển kiểm soát:</span>
                            </td>
                            <td align="left" class="style1" style="width: 30%">
                                <asp:Label ID="m_lbl_bien_kiem_soat" runat="Server" class="cssManField" Style="color: blue"></asp:Label>
                            </td>
                            <td align="right" colspan="1" class="cssManField" style="width: 20%">
                                <span>Chức danh sử dụng</span>
                            </td>
                            <td align="left" class="style1" style="width: 30%">
                                <asp:Label ID="m_lbl_chuc_dang_su_dung" runat="Server" class="cssManField" Style="color: blue"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="cssManField" style="width: 20%;">
                                <span>Nước sản xuất:</span>
                            </td>
                            <td align="left" colspan="1" style="width: 30%">
                                <asp:Label ID="m_lbl_nuoc_san_xuat" runat="Server" class="cssManField" Style="color: blue"></asp:Label>
                            </td>
                            <td align="right" class="cssManField" colspan="1" style="width: 20%">
                                <span>Năm sản xuất:</span>
                            </td>
                            <td align="left" class="style1" style="width: 30%">
                                <asp:Label ID="m_lbl_nam_san_xuat" runat="Server" class="cssManField" Style="color: blue"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="cssManField" style="width: 20%;">
                                <span>Năm sử dụng:</span>
                            </td>
                            <td align="left" colspan="1" style="width: 30%">
                                <asp:Label ID="m_lbl_nam_su_dung" runat="Server" class="cssManField" Style="color: blue"></asp:Label>
                            </td>
                            <td align="right" colspan="1" style="width: 20%">
                                &nbsp;
                            </td>
                            <td align="left" class="style1" style="width: 30%">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 20%;">
                                &nbsp;
                            </td>
                            <td class="cssManField" align="center" colspan="2" style="width: 30%">
                                <span>GIÁ TRỊ THEO SỔ KẾ TOÁN</span>
                            </td>
                            <td align="right" colspan="1" style="width: 20%">
                                &nbsp;
                            </td>
                            <td align="left" class="style1" style="width: 30%">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="cssManField" style="width: 20%;">
                                <span>Nguyên giá Nguồn NS:</span>
                            </td>
                            <td align="right" colspan="1" style="width: 30%" class="cssManField" style="color: blue">
                                <asp:Label ID="m_lbl_nguyen_gia_nguon_ns" runat="Server"></asp:Label>
                            </td>
                            <td align="right" colspan="1" class="cssManField" style="width: 20%">
                                <span>Nguyên giá Nguồn khác</span>
                            </td>
                            <td align="right">
                                <asp:Label ID="m_lbl_nguyen_gia_nguon_khac" runat="Server" class="cssManField" Style="color: blue"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" style="width: 20%;" class="cssManField">
                                <span>Giá trị còn lại:</span>
                            </td>
                            <td align="right" colspan="1" style="width: 30%">
                                <asp:Label ID="m_lbl_gia_tri_con_lai" runat="Server" class="cssManField" Style="color: blue"></asp:Label>
                            </td>
                            <td align="right" colspan="1" style="width: 20%">
                                &nbsp;
                            </td>
                            <td align="left" class="style1" style="width: 30%">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="right" colspan="1" style="width: 20%">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td colspan="4" align="left">
                                <asp:Button ID="m_cmd_tao_moi" AccessKey="c" CssClass="cssButton" runat="server"
                                    Width="98px" Text="Tạo mới(c)" ValidationGroup="m_vlg_tai_san_khac" />&nbsp;
                                <asp:Button ID="m_cmd_xoa_trang" AccessKey="r" CssClass="cssButton" runat="server"
                                    Width="98px" Text="Xóa trắng(r)" />
                                <asp:HiddenField ID="hdf_id" runat="server" Value="" />
                            </td>
                        </tr>
                </table>
            </td>
        </tr>
        <!-- End Quan ly oto   -->
        <!-- Ket qua loc du lieu  -->
    </table>
    <table cellspacing="0" cellpadding="2" style="width: 99%;" class="cssTable" border="0">
        <tr>
            <td class="cssPageTitleBG" colspan="4">
                <span class="cssPageTitle">Chọn ô tô</span> <span class="expand-collapse-text initial-expand">
                </span><span class="expand-collapse-text"></span>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 20%">
                <span class="cssManField">Bộ, tỉnh</span>
            </td>
            <td style="width: 30%" align="left">
                <asp:DropDownList ID="m_cbo_bo_tinh_down" runat="server" Width="85%" ValidationGroup="m_vlg_oto"
                    AutoPostBack="True" OnSelectedIndexChanged="m_cbo_bo_tinh_down_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td align="right" style="width: 20%">
                <span class="cssManField">Đơn vị chủ quản</span>
            </td>
            <td align="left" style="width: 30%;">
                <asp:DropDownList ID="m_cbo_don_vi_chu_quan_down" runat="server" Width="85%" ValidationGroup="m_vlg_oto"
                    AutoPostBack="True" OnSelectedIndexChanged="m_cbo_don_vi_chu_quan_down_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 20%" colspan="1">
                <span class="cssManField">Đơn vị sử dụng tài sản</span>
            </td>
            <td style="width: 30%" align="left" colspan="1">
                <asp:DropDownList ID="m_cbo_don_vi_su_dung_tai_san_down" runat="server" Width="85%"
                    ValidationGroup="m_vlg_oto" AutoPostBack="True" OnSelectedIndexChanged="m_cbo_don_vi_su_dung_tai_san_down_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td colspan="1" align="right" style="width: 20%">
                <span class="cssManField">Trạng thái ô tô</span>
            </td>
            <td align="left" colspan="1" style="width: 30%;">
                <asp:DropDownList ID="m_cbo_trang_thai_o_to_down" runat="server" Width="85%" ValidationGroup="m_vlg_oto"
                    OnSelectedIndexChanged="m_cbo_trang_thai_o_to_down_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="4" style="height: 450px;" valign="top">
                &nbsp;
                <asp:GridView ID="m_grv_dm_oto" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    Width="100%" DataKeyNames="ID" CellPadding="0" ForeColor="#333333" AllowSorting="True"
                    PageSize="15" ShowHeader="true">
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
                        <asp:TemplateField HeaderText="Chi tiết tài sản" Visible="false">
                            <ItemTemplate>
                                <asp:HyperLink ToolTip="Chi tiết tài sản" ImageUrl="../Images/Button/detail.png"
                                    ID="lbt_hop_dong_gv" runat="server" NavigateUrl=''></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Mã phiếu" DataField="MA_PHIEU" />
                        <asp:HyperLinkField HeaderText="Tên tài sản" DataTextField="TEN_TAI_SAN" NavigateUrl="" />
                        <asp:BoundField HeaderText="Mã tài sản" DataField="MA_TAI_SAN" />
                        <asp:BoundField HeaderText="Nhãn hiệu" DataField="NHAN_HIEU" />
                        <asp:BoundField HeaderText="Biển kiểm soát" DataField="BIEN_KIEM_SOAT" />
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
                                            Giá trị theo sổ kế toán
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
                        <asp:BoundField HeaderText="Giá trị khấu hao" DataField="GIA_TRI_KHAU_HAO" />
                        <asp:BoundField HeaderText="Ngày lập" DataField="NGAY_LAP" />
                        <asp:BoundField HeaderText="Ngày duyệt" DataField="NGAY_DUYET" />
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
</asp:Content>
