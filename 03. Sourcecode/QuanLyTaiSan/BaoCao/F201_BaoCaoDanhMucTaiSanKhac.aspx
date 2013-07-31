<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="F201_BaoCaoDanhMucTaiSanKhac.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
    .style1
    {
        width: 15%;
        height: 26px;
    }
    .style2
    {
        width: 20%;
        height: 26px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table cellspacing="0" cellpadding="2" style="width: 100%;" class="cssTable" border="0">
        <tr>
            <td class="cssPageTitleBG" colspan="4">
                <span class="cssPageTitle">Báo cáo</span>
                <span class="expand-collapse-text initial-expand">
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
            <td align="right" style="width: 15%;">
                &nbsp;</td>
            <td style="width: 20%;">
                &nbsp;</td>
            <td align="right" style="width: 15%;">
                &nbsp;</td>
            <td style="width: 20%;">
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right" style="width: 15%;">
                <span class="cssManField">Tìm kiếm</span>
            </td>
            <td style="width: 20%;">
                <asp:TextBox ID="m_txt_tim_kiem" runat="server" CssClass="cssTextBox" Width="85%"></asp:TextBox>
            </td>
            <td align="right" style="width: 15%;">
            <span class="cssManField">Trạng thái tài sản</span></td>
            <td style="width: 20%;">
            <asp:DropDownList ID="m_cbo_trang_thai_tai_san" runat="server" Width="96%" 
                    CssClass="cssDorpdownlist" AutoPostBack="True" 
                    onselectedindexchanged="m_cbo_trang_thai_tai_san_SelectedIndexChanged">
                </asp:DropDownList>
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
                    Width="98px" Text="Lọc dữ liệu(l)" onclick="m_cmd_tim_kiem_Click" />&nbsp;
                <asp:Button ID="m_cmd_xuat_excel" AccessKey="x" CssClass="cssButton" runat="server"
                    Width="98px" Text="Xuất Excel (x)" />&nbsp;
                </td>
        </tr>
    </table>
    <table cellspacing="0" cellpadding="2" style="width: 100%;" class="cssTable" border="0">
        <tr>
            <td class="cssPageTitleBG" colspan="6">
            <span class="cssPageTitle">DANH MỤC TÀI SẢN KHÁC (TRỪ TRỤ SỞ LÀM VIỆC, CƠ SỞ HOẠT ĐỘNG SỰ NGHIỆP VÀ XE Ô TÔ)</span>
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
                    PageSize="15" ShowHeader="true" ShowFooter="true">
                    <Columns>
                        <asp:TemplateField HeaderText="Chi tiết tài sản" Visible="false">
                            <ItemTemplate>
                                <asp:HyperLink ToolTip="Chi tiết tài sản" ImageUrl="../Images/Button/detail.png"
                                    ID="lbt_hop_dong_gv" runat="server" NavigateUrl=''></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:HyperLinkField HeaderText="Tên tài sản" FooterText="Tổng cộng" DataTextField="TEN_TAI_SAN" NavigateUrl=""/>
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
                            <FooterTemplate>
                                <table border="1" cellspacing="0" cellpadding="3" width="100%">
                                	<tr>
                                		<td style = "width: 33%">
                                            <asp:Label ID="m_lbl_nguon_ns" runat="server"></asp:Label>
                                        </td>
                                        <td style = "width: 33%">
                                            <asp:Label ID="m_lbl_nguon_khac" runat="server"></asp:Label>
                                        </td>
                                        <td style = "width: 33%">
                                        <asp:Label ID="m_lbl_gia_tri_con_lai" runat="server"></asp:Label>
                                        </td>
                                	</tr>
                                </table>
                            </FooterTemplate>
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
                            <FooterTemplate>
                                <table border="1" cellspacing="0" cellpadding="3" width="100%">
                                	<tr>
                                		<td style = "width: 25%">
                                            <asp:Label ID="m_lbl_quan_ly_nha_nuoc" runat="server"></asp:Label>
                                        </td>
                                        <td style = "width: 25%">
                                            <asp:Label ID="m_lbl_kinh_doanh" runat="server"></asp:Label>
                                        </td>
                                        <td style = "width: 25%">
                                        <asp:Label ID="m_lbl_khong_kinh_doanh" runat="server"></asp:Label>
                                        </td>
                                        <td style = "width: 25%">
                                        <asp:Label ID="m_lbl_hoat_dong_khac" runat="server"></asp:Label>
                                        </td>
                                	</tr>
                                </table>
                            </FooterTemplate>
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
