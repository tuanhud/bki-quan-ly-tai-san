<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="F202_BaoDanhMucTaiSanKhacDeNghiXuLy.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table cellspacing="0" cellpadding="2" style="width: 100%;" class="cssTable" border="0">
        <tr>
            <td class="cssPageTitleBG" colspan="3">
                <span class="cssPageTitle">Tìm kiếm</span>
                <span class="expand-collapse-text initial-expand">
                </span><span class="expand-collapse-text"></span>
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:ValidationSummary ID="vdsCategory" runat="server" CssClass="cssManField" Font-Bold="true" />
                <asp:Label ID="m_lbl_mess" runat="server" CssClass="cssManField" />
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 15%;">
                <span class="cssManField">Bộ, tỉnh</span>
            </td>
            <td style="width: 20%;">
                <asp:DropDownList ID="m_cbo_bo_tinh" runat="server" Width="96%" CssClass="cssDorpdownlist">
                </asp:DropDownList>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 15%;">
                <span class="cssManField">Đơn vị quản lý</span>
            </td>
            <td style="width: 20%;">
                <asp:DropDownList ID="m_cbo_don_vi_quan_ly" runat="server" Width="96%" CssClass="cssDorpdownlist">
                </asp:DropDownList>
            </td>
            <td></td>
        </tr>
        <tr>
            <td align="right" style="width: 15%;">
                <span class="cssManField">Đơn vị sử dụng</span>
            </td>
            <td style="width: 20%;">
                <asp:DropDownList ID="m_cbo_don_vi_su_dung" runat="server" Width="96%" CssClass="cssDorpdownlist">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="right">
                &nbsp;
            </td>
            <td valign="top" colspan="2">
                <asp:HiddenField ID="hdf_id" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="2" align="left">
                <asp:Button ID="m_cmd_tim_kiem" AccessKey="l" CssClass="cssButton" runat="server"
                    Width="98px" Text="Lọc dữ liệu(l)" />&nbsp;
                <asp:Button ID="m_cmd_xuat_excel" AccessKey="x" CssClass="cssButton" runat="server"
                    Width="98px" Text="Xuất Excel (x)" />&nbsp;
                </td>
        </tr>
    </table>
    <table cellspacing="0" cellpadding="2" style="width: 100%;" class="cssTable" border="0">
        <tr>
            <td class="cssPageTitleBG" colspan="6">
            <span class="cssPageTitle">DANH MỤC TÀI SẢN KHÁC (TRỪ TRỤ SỞ LÀM VIỆC, CƠ SỞ HOẠT ĐỘNG SỰ NGHIỆP VÀ XE Ô TÔ) ĐỀ NGHỊ XỬ LÝ</span>
            <span class="expand-collapse-text initial-expand">
                </span><span class="expand-collapse-text"></span>
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
                <asp:GridView ID="m_grv_danh_sach_tai_san_khac" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    Width="100%" DataKeyNames="ID" CellPadding="4" ForeColor="#333333" AllowSorting="True"
                    PageSize="15" ShowHeader="true">
                    <Columns>
                        <asp:TemplateField HeaderText="Chi tiết tài sản" Visible="false">
                            <ItemTemplate>
                                <asp:HyperLink ToolTip="Chi tiết tài sản" ImageUrl="../Images/Button/detail.png"
                                    ID="lbt_hop_dong_gv" runat="server" NavigateUrl=''></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:HyperLinkField HeaderText="Tên tài sản" DataTextField="a" NavigateUrl=""/>
                        <asp:BoundField HeaderText="Ký hiệu" DataField="a"/>
                        <asp:BoundField HeaderText="Nước sản xuất" DataField="a"/>
                        <asp:BoundField HeaderText="Năm sản xuất" DataField="a"/>
                        <asp:BoundField HeaderText="Ngày, tháng, năm sử dụng" DataField="NAM_SU_DUNG"/>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <table border="1" cellspacing="0" cellpadding="3" width="100%">
                                	<tr>
                                		<td colspan="3">Giá trị theo sổ kế toán</td>
                                	</tr>
                                    <tr>
                                        <td colspan="2">Nguyên giá</td>
                                        <td rowspan="2">Giá trị còn lại</td>
                                    </tr>
                                    <tr>
                                        <td>Nguồn NS</td>
                                        <td>Nguồn khác</td>
                                    </tr>
                                </table>
                            </HeaderTemplate>
                            <HeaderStyle CssClass=""/>
                            <ItemTemplate>
                                <table border="1" cellspacing="0" cellpadding="2" width="100%">
                                	<tr>
                                		<td><%# Eval("NGUON_NS") %></td>
                                        <td><%# Eval("NGUON_KHAC") %></td>
                                        <td><%# Eval("GIA_TRI_CON_LAI") %></td>
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
                                        <td rowspan="2">Quản lý nhà nước</td>
                                        <td colspan="2">Hoạt đông sự nghiệp</td>
                                        <td rowspan="2">Khác</td>
                                    </tr>
                                    <tr>
                                        <td>Kinh doanh</td>
                                        <td>Không kinh doanh</td>
                                    </tr>
                                </table>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <table border="1" cellspacing="0" cellpadding="2" width="100%">
                                	<tr>
                                		<td><%# Eval("") %></td>
                                        <td><%# Eval("") %></td>
                                        <td><%# Eval("") %></td>
                                        <td><%# Eval("") %></td>
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
