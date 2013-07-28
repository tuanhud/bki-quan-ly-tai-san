<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="F300_TaiSanCoNguyenGiaTu500TrieuTroLen.aspx.cs" Inherits="Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table border="0" cellspacing="0" cellpadding="0" width="100%" class="cssTable">
        <tr>
            <td class="cssPageTitleBG" colspan="4">
                <span class="cssPageTitle">BÁO CÁO KÊ KHAI TÀI SẢN CÓ NGUYÊN GIÁ TỪ 500 TRIỆU TRỞ LÊN</span>
                <span class="expand-collapse-text initial-expand"></span><span class="expand-collapse-text">
                </span>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:ValidationSummary ID="vdsCategory" runat="server" CssClass="cssManField" Font-Bold="true" />
                <asp:Label ID="m_lbl_mess" runat="server" CssClass="cssManField" />
            </td>
        </tr>
        <tr>
            <td align="right" colspan="1" width="25%">
                <span class="cssManField">Bộ, tỉnh:</span>
            </td>
            <td width="25%">
                <asp:DropDownList ID="m_cbo_bo_tinh" Width="96%" runat="Server">
                </asp:DropDownList>
            </td>
            <td colspan="1" width="25%">
            </td>
            <td colspan="1" width="25%">
            </td>
        </tr>
        <tr>
            <td align="right">
                <span class="cssManField">Đơn vị chủ quản:</span>
            </td>
            <td>
                <asp:DropDownList ID="m_cbo_don_vi_chu_quan" Width="96%" runat="Server">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right">
                <span class="cssManField">Đơn vị sử dụng tài sản:</span>
            </td>
            <td>
                <asp:DropDownList ID="m_cbo_don_vi_su_dung_tai_san" Width="96%" runat="Server">
                </asp:DropDownList>
            </td>
        </tr>
       
        <tr>
            <td align="right">
                <span class="cssManField">Loại hình đơn vị:</span>
            </td>
            <td>
                <asp:Label ID="m_lbl_loai_hinh_don_vi" runat="Server" CssClass="cssManField"></asp:Label>
            </td>
        </tr>
        <tr style="height: 10px">
            <td>
                
            </td>
            <td>
            <asp:HiddenField ID="hdf_id" runat="server" />
            </td>
        </tr>
        <tr>
        <td>&nbsp;</td>
            <td align="left">
                <asp:Button ID="m_cmd_loc_du_lieu" AccessKey="l" CssClass="cssButton" runat="server"
                    Width="98px" Text="Lọc dữ liệu(l)" Height="23px" />
                    <asp:Button ID="Button2" AccessKey="x" CssClass="cssButton" runat="server"
                    Width="98px" Text="Xuất Excel (x)" Height="22px" />
            </td>
            
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <table border="0" cellspacing="0" cellpadding="0" width="100%" class="cssTable">
        <tr>
            <td class="cssPageTitleBG" colspan="4">
                <span class="cssPageTitle">DANH SÁCH TÀI SẢN CÓ NGUYÊN GIÁ TỪ 500 TRIỆU TRỞ LÊN</span>
                <span class="expand-collapse-text initial-expand"></span><span class="expand-collapse-text">
                </span>
            </td>
        </tr>
        
       
        <tr>
            
            <td align="left">
                <asp:Label ID="m_lbl_thong_bao" Visible="false" runat="server" CssClass="cssManField" />
            </td>
            <td align="left">
            </td>
            <td align="left">
            </td>
        </tr>
    </table>
    <asp:GridView ID="m_grv_danh_sach_nha" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        Width="100%" DataKeyNames="ID" CellPadding="4" ForeColor="#333333" AllowSorting="True"
        PageSize="15" ShowHeader="true">
        <Columns>
           
            <asp:TemplateField HeaderText="Chi tiết tài sản" Visible="false">
                <ItemTemplate>
                    <asp:HyperLink ToolTip="Chi tiết tài sản" ImageUrl="../Images/Button/detail.png"
                        ID="lbt_hop_dong_gv" runat="server" NavigateUrl=''></asp:HyperLink>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:HyperLinkField HeaderText="TÀI SẢN" DataTextField="TEN_TAI_SAN" NavigateUrl="" />
            <asp:BoundField HeaderText="KÝ HIỆU" DataField="KY_HIEU" />
            <asp:BoundField HeaderText="NƯỚC SẢN XUẤT" DataField="NUOC_SAN_XUAT" />
            <asp:BoundField HeaderText="NGÀY, THÁNG, NĂM SỬ DỤNG" DataField="NAM_SU_DUNG" />
            <asp:TemplateField>
                <HeaderTemplate>
                    <table border="1" cellspacing="0" cellpadding="3" width="100%">
                        <tr>
                            <td colspan="3">
                                GIÁ TRỊ THEO SỔ KẾ TOÁN
                                <BR />
                                (ngàn đồng)
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" rowspan="1">
                                Nguyên giá
                            </td>
                            <td rowspan="2">
                                Giá trị còn lại
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Nguồn NS
                            </td>
                            <td>
                                Nguồn khác
                            </td>
                        </tr>
                    </table>
                </HeaderTemplate>
                <HeaderStyle CssClass="" />
                <ItemTemplate>
                    <table border="1" cellspacing="0" cellpadding="2" width="100%">
                        <tr>
                            <td>
                                <%# Eval("NGUON_NS") %>
                            </td>
                            <td>
                                <%# Eval("NGUON_KHAC") %>
                            </td>
                            <td>
                                <%# Eval("GIA_TRI_CON_LAI") %>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <table border="1" cellspacing="0" cellpadding="3" width="100%">
                        <tr>
                            <td colspan="4">
                                HIỆN TRẠNG SỬ DỤNG
                                <br />
                                (cái, chiếc))
                            </td>
                        </tr>
                        <tr>
                            <td rowspan="2">
                                QLNN
                            </td>
                            <td rowspan="1" colspan="2">
                                HĐ sự nghiệp
                            </td>
                            <td colspan="1" rowspan="2">
                                HĐ KHÁC
                            </td>
                        </tr>
                        <tr>
                            <
                            <td>
                                Kinh doanh
                            </td>
                            <td>
                                Không KD
                            </td>
                        </tr>
                    </table>
                   
                </HeaderTemplate>
                <HeaderStyle CssClass="" />
                <ItemTemplate>
                    <table border="1" cellspacing="0" cellpadding="2" width="100%">
                        <tr>
                            <td>
                                <%# Eval("QLNN") %>
                            </td>
                            <td>
                                <%# Eval("KINH_DOANH") %>
                            </td>
                            <td>
                                <%# Eval("KHONG_KD") %>
                            </td>
                            <td>
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
    </td> </tr> </table>
</asp:Content>
