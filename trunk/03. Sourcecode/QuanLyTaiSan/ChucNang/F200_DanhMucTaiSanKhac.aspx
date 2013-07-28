<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="F200_DanhMucTaiSanKhac.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table cellspacing="0" cellpadding="2" style="width:99%;" class="cssTable" border="0">
        <tr>
            <td class="cssPageTitleBG" colspan="4">
                <span class="cssPageTitle">Quản lý nhà</span> <span class="expand-collapse-text initial-expand">
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
                            <asp:DropDownList ID="m_ddl_bo_tinh" runat="server" Width="85%">
                            </asp:DropDownList>
                        </td>
                        <td align="left" style="width: 1%;">
                        </td>
                        <td align="right" style="width: 15%">
                            <span class="cssManField">Đơn vị chủ quản</span>
                        </td>
                        <td align="left" style="width: 30%;">
                            <asp:DropDownList ID="m_ddl_don_vi_chu_quan" runat="server" Width="85%">
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
                            <asp:DropDownList ID="DropDownList2" runat="server" Width="85%">
                            </asp:DropDownList>
                        </td>
                        <td align="left" style="width: 1%;">
                        </td>
                        <td align="right" style="width: 15%">
                            <span class="cssManField">Trạng thái nhà</span>
                        </td>
                        <td align="left" style="width: 30%;">
                            <asp:DropDownList ID="m_ddl_trang_thai_nha" runat="server" Width="85%">
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
                            <asp:TextBox ID="m_txt_ten_dat0" runat="server" CssClass="cssTextBox" 
                                Width="85%"></asp:TextBox>
                        </td>
                        <td align="left" style="width: 1%;">
                        </td>
                        <td align="right" style="width: 15%">
                        </td>
                        <td align="left" style="width: 30%;">
                            &nbsp;</td>
                        <td align="left" style="width: 1%;">
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 15%">
                            <span class="cssManField">Ký hiệu</span>
                        </td>
                        <td style="width: 30%" align="left">
                            <asp:TextBox ID="m_txt_ky_hieu" runat="server" CssClass="cssTextBox" Width="85%"></asp:TextBox>
                        </td>
                        <td align="left" style="width: 1%;">
                            (*)
                            <asp:RequiredFieldValidator ID="m_rfv_ky_hieu" runat="server" ControlToValidate="m_txt_ky_hieu"
                                ErrorMessage="Bạn phải nhập Ký hiệu" Text="*"></asp:RequiredFieldValidator>
                        </td>
                        <td align="right" style="width: 15%">
                            <span class="cssManField">Nước sản xuất</span>
                        </td>
                        <td align="left" style="width: 30%;">
                            <asp:TextBox ID="m_txt_nuoc_sx" runat="server" CssClass="cssTextBox" Width="85%"></asp:TextBox>
                        </td>
                        <td align="left" style="width: 1%;">
                            (*)
                            <asp:RequiredFieldValidator ID="m_rfv_nuoc_sx" runat="server" ControlToValidate="m_txt_nuoc_sx"
                                ErrorMessage="Bạn phải nhập Nước sản xuất" Text="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 15%">
                            <span class="cssManField">Năm sản xuất</span>
                        </td>
                        <td style="width: 30%" align="left">
                            <asp:TextBox ID="m_txt_nam_sx" runat="server" CssClass="cssTextBox" Width="85%"></asp:TextBox>
                        </td>
                        <td align="left" style="width: 1%;">
                            (*)
                            <asp:RequiredFieldValidator ID="m_rfv_nam_sx" runat="server" ControlToValidate="m_txt_nam_sx"
                                ErrorMessage="Bạn phải nhập Năm sản xuất" Text="*"></asp:RequiredFieldValidator>
                        </td>
                        <td align="right" style="width: 15%">
                            <span class="cssManField">Ngày, tháng, năm sử dụng</span>
                        </td>
                        <td align="left" style="width: 30%;">
                            <asp:TextBox ID="m_txt_ngay_su_dung" runat="server" CssClass="cssTextBox" Width="85%"></asp:TextBox>
                        </td>
                        <td align="left" style="width: 1%;">
                            (*)
                            <asp:RequiredFieldValidator ID="m_rfv_ngay_su_dung" runat="server" ControlToValidate="m_txt_ngay_su_dung"
                                ErrorMessage="Bạn phải nhập ngày tháng năm sử dụng" Text="*"></asp:RequiredFieldValidator>
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
                                Width="85%"></asp:TextBox>
                        </td>
                        <td align="left" style="width: 1%;">
                            (*)
                            <asp:RequiredFieldValidator ID="m_rfv_nguyen_gia" runat="server" ControlToValidate="m_txt_nguyen_gia"
                                ErrorMessage="Bạn phải nhập Nguyên giá" Text="*"></asp:RequiredFieldValidator>
                        </td>
                        <td align="right" style="width: 15%">
                            <span class="cssManField">Nguyên giá nguồn khác (VNĐ)</span>
                        </td>
                        <td align="left" style="width: 30%;">
                            <asp:TextBox ID="m_txt_nguyen_gia_nguon_khac" runat="server" CssClass="cssTextBox csscurrency"
                                Width="85%"></asp:TextBox>
                        </td>
                        <td align="left" style="width: 1%;">
                            (*)
                            <asp:RequiredFieldValidator ID="m_rfv_nguyen_gia_nguon_khac" runat="server" ControlToValidate="m_txt_nguyen_gia_nguon_khac"
                                ErrorMessage="Bạn phải nhập Nguyên giá nguồn khác" Text="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 15%">
                            <span class="cssManField">Giá trị còn lại (VNĐ)</span>
                        </td>
                        <td style="width: 30%" align="left">
                            <asp:TextBox ID="m_txt_gia_tri_con_lai" runat="server" CssClass="cssTextBox csscurrency"
                                Width="85%"></asp:TextBox>
                        </td>
                        <td align="left" style="width: 1%;">
                            (*)
                            <asp:RequiredFieldValidator ID="m_rfv_gia_tri_con_lai" runat="server" ControlToValidate="m_txt_gia_tri_con_lai"
                                ErrorMessage="Bạn phải nhập Giá trị còn lại" Text="*"></asp:RequiredFieldValidator>
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
                            <asp:TextBox ID="m_txt_quan_ly_nha_nuoc" runat="server" CssClass="cssTextBox" Width="85%"></asp:TextBox>
                        </td>
                        <td align="left" style="width: 1%;">
                            (*)
                            <asp:RequiredFieldValidator ID="m_rfv_quan_ly_nha_nuoc" runat="server" ControlToValidate="m_txt_quan_ly_nha_nuoc"
                                ErrorMessage="Bạn phải nhập Quản lý nhà nước" Text="*"></asp:RequiredFieldValidator>
                        </td>
                        <td align="right" style="width: 15%">
                        </td>
                        <td align="left" style="width: 30%;">
                            &nbsp;</td>
                        <td align="left" style="width: 1%;">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 15%">
                            <span class="cssManField">Hoạt động sự nghiệp (Kinh doanh)</span>
                        </td>
                        <td style="width: 30%" align="left">
                            <asp:TextBox ID="m_txt_kinh_doanh" runat="server" CssClass="cssTextBox" Width="85%"></asp:TextBox>
                        </td>
                        <td align="left" style="width: 1%;">
                            (*)
                            <asp:RequiredFieldValidator ID="m_rfv_kinh_doanh" runat="server" ControlToValidate="m_txt_kinh_doanh"
                                ErrorMessage="Bạn phải nhập Kinh doanh" Text="*"></asp:RequiredFieldValidator>
                        </td>
                        <td align="right" style="width: 15%">
                            <span class="cssManField">Hoạt động sự nghiệp (Không kinh doanh)</span>
                        </td>
                        <td align="left" style="width: 30%;">
                            <asp:TextBox ID="m_txt_khong_kinh_doanh" runat="server" CssClass="cssTextBox" Width="85%"></asp:TextBox>
                        </td>
                        <td align="left" style="width: 1%;">
                            (*)
                            <asp:RequiredFieldValidator ID="m_rfv_khong_kinh_doanh" runat="server" ControlToValidate="m_txt_khong_kinh_doanh"
                                ErrorMessage="Bạn phải nhập Không kinh doanh" Text="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 15%">
                            <span class="cssManField">Khác</span>
                        </td>
                        <td style="width: 30%" align="left">
                            <asp:TextBox ID="m_txt_khac" runat="server" CssClass="cssTextBox" Width="85%"></asp:TextBox>
                        </td>
                        <td align="left" style="width: 1%;">
                            (*)
                            <asp:RequiredFieldValidator ID="m_rfv_khac" runat="server" ControlToValidate="m_txt_khac"
                                ErrorMessage="Bạn phải nhập Khac" Text="*"></asp:RequiredFieldValidator>
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
                                Width="98px" Text="Tạo mới(c)"/>&nbsp;
                            <asp:Button ID="m_cmd_cap_nhat" AccessKey="u" CssClass="cssButton" runat="server"
                                Width="98px" Text="Cập nhật(u)"/>&nbsp;
                            <asp:Button ID="m_cmd_xoa_trang" AccessKey="r" CssClass="cssButton" runat="server"
                                Width="98px" Text="Xóa trắng(r)"/>
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
		    <span class="cssPageTitle">Danh sách tài sản khác</span> <span class="expand-collapse-text initial-expand">
                </span><span class="expand-collapse-text"></span>
		</td>
	</tr>
    <tr>
            <td align="right" style="width: 15%">
                <span class="cssManField">Từ khóa</span>
            </td>
            <td align="left" style="width: 30%">
                <asp:TextBox ID="TextBox1" runat="server" CssClass="cssTextBox" Width="85%"></asp:TextBox>
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
                <asp:Button ID="Button1" runat="server" AccessKey="s" CssClass="cssButton"
                    Height="24px" Text="Tìm kiếm" Width="98px"/>
            </td>
            <td align="left">
                <asp:Button ID="Button2" runat="server" CausesValidation="False" CssClass="cssButton"
                    Height="25px" Text="Xuất Excel" Width="98px"/>
            </td>
            <td align="left">
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
		<td align="center" colspan="4" style="height:450px;" valign="top">
		    <asp:GridView ID="m_grv_tai_san_khac" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    Width="100%" DataKeyNames="ID" CellPadding="4" ForeColor="#333333" AllowSorting="True"
                    PageSize="15" ShowHeader="true">
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
                                <asp:HyperLink ToolTip="Sửa" ImageUrl="../Images/Button/edit.png" ID="lbt_edit" runat="server"
                                    NavigateUrl=''></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Chi tiết tài sản" Visible="false">
                            <ItemTemplate>
                                <asp:HyperLink ToolTip="Chi tiết tài sản" ImageUrl="../Images/Button/detail.png"
                                    ID="lbt_hop_dong_gv" runat="server" NavigateUrl=''></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:HyperLinkField HeaderText="Tên tài sản" DataTextField="TEN_TAI_SAN" NavigateUrl=""/>
                        <asp:BoundField HeaderText="Ký hiệu" DataField="KY_HIEU"/>
                        <asp:BoundField HeaderText="Nước sản xuất" DataField="NUOC_SAN_XUAT"/>
                        <asp:BoundField HeaderText="Năm sản xuất" DataField="NAM_SAN_XUAT"/>
                        <asp:BoundField HeaderText="Ngày, tháng, năm sử dụng" DataField="NAM_SU_DUNG"/>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <table border="1" cellspacing="0" cellpadding="3" width="100%">
                                	<tr>
                                		<td colspan="3">Giá trị theo sổ kế toán</td>
                                	</tr>
                                    <tr>
                                        <td colspan="2" style = "width: 66%">Nguyên giá</td>
                                        <td rowspan="2" style = "width: 33%">Giá trị còn lại</td>
                                    </tr>
                                    <tr>
                                        <td style = "width: 33%">Nguồn NS</td>
                                        <td style = "width: 33%">Nguồn khác</td>
                                    </tr>
                                </table>
                            </HeaderTemplate>
                            <HeaderStyle CssClass=""/>
                            <ItemTemplate>
                                <table border="1" cellspacing="0" cellpadding="2" width="100%">
                                	<tr>
                                		<td style = "width: 33%"><%# Eval("NGUON_NS", "{0:#,###}")%></td>
                                        <td style = "width: 33%"><%# Eval("NGUON_KHAC", "{0:#,###}")%></td>
                                        <td style = "width: 33%"><%# Eval("GIA_TRI_CON_LAI", "{0:#,###}")%></td>
                                	</tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <table border="1" cellspacing="0" cellpadding="2" width="100%">
                                	<tr>
                                		<td colspan="7">Hiện trạng sử dụng</td>
                                	</tr>
                                    <tr>
                                        <td rowspan="2" style = "width: 25%">Quản lý nhà nước</td>
                                        <td colspan="2" style = "width: 50%">Hoạt đông sự nghiệp</td>
                                        <td rowspan="2" style = "width: 25%">Khác</td>
                                    </tr>
                                    <tr>
                                        <td style = "width: 25%">Kinh doanh</td>
                                        <td style = "width: 25%">Không kinh doanh</td>
                                    </tr>
                                </table>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <table border="1" cellspacing="0" cellpadding="2" width="100%">
                                	<tr>
                                		<td style = "width: 25%"><%# Eval("QLNN") %></td>
                                        <td style = "width: 25%"><%# Eval("KINH_DOANH") %></td>
                                        <td style = "width: 25%"><%# Eval("KHONG_KINH_DOANH") %></td>
                                        <td style = "width: 25%"><%# Eval("HD_KHAC") %></td>
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
</asp:Content>

