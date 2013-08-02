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
        <tr style="width: 100%">
            <td align="right" colspan="1" style="width: 18%">
                <span class="cssManField">Bộ, tỉnh:</span>
            </td>
            <td colspan="1" style="width: 25%">
                <asp:DropDownList ID="m_cbo_bo_tinh" Width="90%" runat="Server" OnSelectedIndexChanged="m_cbo_bo_tinh_SelectedIndexChanged"
                    AutoPostBack="True">
                </asp:DropDownList>
            </td>
            <td align="right" colspan="1" style="width: 18%">
                <span class="cssManField">Đơn vị chủ quản:</span>
            </td>
            <td style="width: 25%">
                <asp:DropDownList ID="m_cbo_don_vi_chu_quan" Width="90%" runat="Server" OnSelectedIndexChanged="m_cbo_don_vi_chu_quan_SelectedIndexChanged"
                    AutoPostBack="True">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 18%">
                <span class="cssManField">Đơn vị sử dụng tài sản:</span>
            </td>
            <td style="width: 25%">
                <asp:DropDownList ID="m_cbo_don_vi_su_dung_tai_san" Width="90%" runat="Server">
                </asp:DropDownList>
            </td>
            <td align="right">
                <span class="cssManField">Trạng thái: </span>
            </td>
            <td>
                <asp:DropDownList ID="m_cbo_trang_thai" runat="Server" Width="90%">
                </asp:DropDownList>
            </td>
        </tr>
        
        <tr>
            <td>
                &nbsp;
            </td>
            <td align="left">
                <asp:Button ID="m_cmd_loc_du_lieu" AccessKey="l" CssClass="cssButton" runat="server"
                    Width="98px" Text="Lọc dữ liệu(l)" Height="23px" OnClick="m_cmd_loc_du_lieu_Click" />
                <asp:Button ID="Button2" AccessKey="x" CssClass="cssButton" runat="server" Width="98px"
                    Text="Xuất Excel (x)" Height="22px" />
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
  
   <%-- <table border="0" cellspacing="0" cellpadding="0" width="100%" class="cssTable">
        <tr style="width: 100%">
            <td class="cssPageTitleBG" colspan="3">
                <span class="cssPageTitle">TÀI SẢN LÀ TRỤ SỞ LÀM VIỆC, CƠ SỞ HOẠT ĐỘNG SỰ NGHIỆP</span>
                <span class="expand-collapse-text initial-expand"></span><span class="expand-collapse-text">
                </span>
            </td>
        </tr>
        <tr>
            <td colspan="17">
                <asp:GridView ID="m_grv_nha" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    Width="100%" DataKeyNames="ID" CellPadding="4" ForeColor="#333333" AllowSorting="True"
                    PageSize="5" OnPageIndexChanging="m_grv_nha_PageIndexChanging">
                    <Columns>
                        <asp:HyperLinkField HeaderText="TÀI SẢN" HeaderStyle-Width="10%" DataTextField="TEN_TAI_SAN"
                            NavigateUrl="" />
                        <asp:BoundField HeaderText="CẤP HẠNG" HeaderStyle-Width="3%" DataField="CAP_HANG">
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="NĂM XÂY DỰNG" HeaderStyle-Width="3%" DataField="NAM_XAY_DUNG">
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="NGÀY, THÁNG, NĂM SỬ DỤNG" HeaderStyle-Width="4%" DataField="NGAY_THANG_NAM_SU_DUNG">
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderStyle-Width="21%">
                            <HeaderTemplate>
                                <table border="1" cellspacing="0" cellpadding="3" width="100%">
                                    <tr>
                                        <td colspan="3">
                                            GIÁ TRỊ THEO SỔ KẾ TOÁN
                                            <br />
                                            (ngàn đồng)
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" rowspan="1">
                                            Nguyên giá
                                        </td>
                                        <td rowspan="2" style="width: 33.33%">
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
                            <HeaderStyle CssClass="" />
                            <ItemTemplate>
                                <table border="1" cellspacing="0" cellpadding="2" width="100%">
                                    <tr>
                                        <td style="width: 33.33%" align="right">
                                            <%# Eval("NGUON_NS", "{0:#,###.00}")%>
                                        </td>
                                        <td style="width: 33.33%" align="right">
                                            <%# Eval("NGUON_KHAC", "{0:#,###.00}")%>
                                        </td>
                                        <td style="width: 33.33%" align="right">
                                            <%# Eval("GIA_TRI_CON_LAI", "{0:#,###.00}")%>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="SỐ TẦNG" DataField="SO_TANG" HeaderStyle-Width="3%">
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="DIỆN TÍCH XÂY DỰNG (m2)" DataField="DT_XAY_DUNG" HeaderStyle-Width="5%">
                            <ItemStyle HorizontalAlign="right" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="TỔNG DT SÀN XÂY DỰNG (m2)" DataField="TONG_DT_SAN_XD"
                            HeaderStyle-Width="5%">
                            <ItemStyle HorizontalAlign="right" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderStyle-Width="45%">
                            <HeaderTemplate>
                                <table border="1" cellspacing="0" cellpadding="3" width="100%">
                                    <tr>
                                        <td colspan="7">
                                            HIỆN TRẠNG SỬ DỤNG
                                            <br />
                                            (m2)
                                        </td>
                                    </tr>
                                    <tr>
                                        <td rowspan="2" style="width: 14.28%">
                                            Trụ sở làm việc
                                        </td>
                                        <td rowspan="2" style="width: 14.28%">
                                            Cơ sở HĐSN
                                        </td>
                                        <td rowspan="1" colspan="5">
                                            Sử dụng khác
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 14.28%">
                                            Làm nhà ở
                                        </td>
                                        <td style="width: 14.28%">
                                            Cho thuê
                                        </td>
                                        <td style="width: 14.28%">
                                            Bỏ trống
                                        </td>
                                        <td style="width: 14.28%">
                                            Bị lấn chiếm
                                        </td>
                                        <td style="width: 14.28%">
                                            Khác
                                        </td>
                                    </tr>
                                </table>
                            </HeaderTemplate>
                            <HeaderStyle CssClass="" />
                            <ItemTemplate>
                                <table border="1" cellspacing="0" cellpadding="2" width="100%">
                                    <tr>
                                        <td style="width: 14.28%" align="right">
                                            <%# Eval("TRU_SO_LAM_VIEC") %>
                                        </td>
                                        <td style="width: 14.28%" align="right">
                                            <%# Eval("CO_SO_HDSN") %>
                                        </td>
                                        <td style="width: 14.28%" align="right">
                                            <%# Eval("LAM_NHA_O") %>
                                        </td>
                                        <td style="width: 14.28%" align="right">
                                            <%# Eval("CHO_THUE") %>
                                        </td>
                                        <td style="width: 14.28%" align="right">
                                            <%# Eval("BO_TRONG") %>
                                        </td>
                                        <td style="width: 14.28%" align="right">
                                            <%# Eval("BI_LAN_CHIEM") %>
                                        </td>
                                        <td style="width: 14.28%" align="right">
                                            <%# Eval("KHAC") %>
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
                    <PagerSettings Position="Bottom" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle CssClass="cssSelectedRow" BackColor="#C5BBAF" Font-Bold="True"
                        ForeColor="#333333"></SelectedRowStyle>
                </asp:GridView>
            </td>
        </tr>
    </table>--%>
   <%-- <table border="0" cellspacing="0" cellpadding="0" width="100%" class="cssTable">
        <tr style="width: 100%">
            <td class="cssPageTitleBG" colspan="3">
                <span class="cssPageTitle">TÀI SẢN LÀ Ô TÔ</span> <span class="expand-collapse-text initial-expand">
                </span><span class="expand-collapse-text"></span>
            </td>
        </tr>
        <tr>
            <td colspan="15">
                <asp:GridView ID="m_grv_oto" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    Width="100%" DataKeyNames="ID" CellPadding="4" ForeColor="#333333" AllowSorting="True"
                    PageSize="5" OnPageIndexChanging="m_grv_oto_PageIndexChanging">
                    <Columns>
                        <asp:HyperLinkField HeaderText="TÀI SẢN" HeaderStyle-Width="10%" DataTextField="TEN_TAI_SAN"
                            NavigateUrl="" />
                        <asp:BoundField HeaderText="NHÃN HIỆU" HeaderStyle-Width="8%" DataField="NHAN_HIEU">
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="BIỂN KIỂM SOÁT" HeaderStyle-Width="8%" DataField="BIEN_KIEM_SOAT">
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="SỐ CHỖ NGỒI/TẢI TRỌNG" HeaderStyle-Width="4%" DataField="SO_CHO_NGOI">
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="NƯỚC SẢN XUẤT" HeaderStyle-Width="8%" DataField="NUOC_SAN_XUAT">
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="NĂM SẢN XUẤT" HeaderStyle-Width="4%" DataField="NAM_SAN_XUAT">
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="NGÀY, THÁNG, NĂM SỬ DỤNG" HeaderStyle-Width="4%" DataField="NAM_SU_DUNG">
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="CÔNG SUẤT XE" HeaderStyle-Width="5%" DataField="CONG_SUAT_XE">
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="CHỨC DANH SỬ DỤNG XE" HeaderStyle-Width="8%" DataField="CHUC_DANH_SU_DUNG">
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="NGUỒN GỐC XE" HeaderStyle-Width="8%" DataField="NGUON_GOC_XE">
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderStyle-Width="18%">
                            <HeaderTemplate>
                                <table border="1" cellspacing="0" cellpadding="3" width="100%">
                                    <tr>
                                        <td colspan="3">
                                            GIÁ TRỊ THEO SỔ KẾ TOÁN
                                            <br />
                                            (ngàn đồng)
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" rowspan="1">
                                            Nguyên giá
                                        </td>
                                        <td rowspan="2" style="width: 33.33%">
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
                            <HeaderStyle CssClass="" />
                            <ItemTemplate>
                                <table border="1" cellspacing="0" cellpadding="2" width="100%">
                                    <tr>
                                        <td style="width: 33.33%" align="right">
                                            <%# Eval("NGUON_NS", "{0:#,###.00}")%>
                                        </td>
                                        <td style="width: 33.33%" align="right">
                                            <%# Eval("NGUON_KHAC", "{0:#,###.00}")%>
                                        </td>
                                        <td style="width: 33.33%" align="right">
                                            <%# Eval("GIA_TRI_CON_LAI", "{0:#,###.00}")%>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-Width="12%">
                            <HeaderTemplate>
                                <table border="1" cellspacing="0" cellpadding="3" width="100%">
                                    <tr>
                                        <td colspan="4">
                                            HIỆN TRẠNG SỬ DỤNG
                                            <br />
                                            (cái, chiếc ))
                                        </td>
                                    </tr>
                                    <tr>
                                        <td rowspan="2" colspan="1" style="width: 25%">
                                            QLNN
                                        </td>
                                        <td rowspan="1" colspan="2">
                                            HĐ sự nghiệp
                                        </td>
                                        <td colspan="1" rowspan="2" style="width: 25%">
                                            HĐ khác
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 25%">
                                            Kinh doanh
                                        </td>
                                        <td style="width: 25%">
                                            Không KD
                                        </td>
                                    </tr>
                                </table>
                            </HeaderTemplate>
                            <HeaderStyle CssClass="" />
                            <ItemTemplate>
                                <table border="1" cellspacing="0" cellpadding="2" width="100%">
                                    <tr>
                                        <td style="width: 25%" align="right">
                                            <%# Eval("QLNN") %>
                                        </td>
                                        <td style="width: 25%" align="right">
                                            <%# Eval("KINH_DOANH") %>
                                        </td>
                                        <td style="width: 25%" align="right">
                                            <%# Eval("KHONG_KINH_DOANH") %>
                                        </td>
                                        <td style="width: 25%" align="right">
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
                    <PagerSettings Position="Bottom" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle CssClass="cssSelectedRow" BackColor="#C5BBAF" Font-Bold="True"
                        ForeColor="#333333"></SelectedRowStyle>
                </asp:GridView>
            </td>
        </tr>
    </table>--%>
    <table border="0" cellspacing="0" cellpadding="0" width="100%" class="cssTable">
        <tr style="width: 100%">
            <td class="cssPageTitleBG" colspan="3">
                <span class="cssPageTitle">DANH SÁCH CHI TIẾT TÀI SẢN</span> <span class="expand-collapse-text initial-expand">
                </span><span class="expand-collapse-text"></span>
            </td>
        </tr>
        <tr>
            <td colspan="12">
                <asp:GridView ID="m_grv_tai_san_khac" runat="server" AllowPaging="True" AutoGenerateColumns="False" EmptyDataText="Không có dữ liệu phù hợp!"
                    Width="100%" DataKeyNames="ID" CellPadding="4" ForeColor="#333333" AllowSorting="True"
                    PageSize="5" onpageindexchanging="m_grv_tai_san_khac_PageIndexChanging">
                    <Columns>
                        <asp:HyperLinkField HeaderText="TÀI SẢN" HeaderStyle-Width="10%" DataTextField="TEN_TAI_SAN"
                            NavigateUrl="" />
                        <asp:BoundField HeaderText="KÝ HIỆU" HeaderStyle-Width="8%" DataField="KY_HIEU">
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="NƯỚC SẢN XUẤT" HeaderStyle-Width="8%" DataField="NUOC_SAN_XUAT">
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="NĂM SẢN XUẤT" HeaderStyle-Width="4%" DataField="NAM_SAN_XUAT">
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="NGÀY, THÁNG, NĂM SỬ DỤNG" HeaderStyle-Width="4%" DataField="NAM_SU_DUNG">
                            <ItemStyle HorizontalAlign="center" />
                        </asp:BoundField>
                       
                        <asp:TemplateField HeaderStyle-Width="18%">
                            <HeaderTemplate>
                                <table border="1" cellspacing="0" cellpadding="3" width="100%">
                                    <tr>
                                        <td colspan="3">
                                            GIÁ TRỊ THEO SỔ KẾ TOÁN
                                            <br />
                                            (ngàn đồng)
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" rowspan="1">
                                            Nguyên giá
                                        </td>
                                        <td rowspan="2" style="width: 33.33%">
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
                            <HeaderStyle CssClass="" />
                            <ItemTemplate>
                                <table border="1" cellspacing="0" cellpadding="2" width="100%">
                                    <tr>
                                        <td style="width: 33.33%" align="right">
                                            <%# Eval("NGUON_NS", "{0:#,###.00}")%>
                                        </td>
                                        <td style="width: 33.33%" align="right">
                                            <%# Eval("NGUON_KHAC", "{0:#,###.00}")%>
                                        </td>
                                        <td style="width: 33.33%" align="right">
                                            <%# Eval("GIA_TRI_CON_LAI", "{0:#,###.00}")%>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-Width="12%">
                            <HeaderTemplate>
                                <table border="1" cellspacing="0" cellpadding="3" width="100%">
                                    <tr>
                                        <td colspan="4">
                                            HIỆN TRẠNG SỬ DỤNG
                                            <br />
                                            (cái, chiếc)
                                        </td>
                                    </tr>
                                    <tr>
                                        <td rowspan="2" colspan="1" style="width: 25%">
                                            QLNN
                                        </td>
                                        <td rowspan="1" colspan="2">
                                            HĐ sự nghiệp
                                        </td>
                                        <td colspan="1" rowspan="2" style="width: 25%">
                                            HĐ khác
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 25%">
                                            Kinh doanh
                                        </td>
                                        <td style="width: 25%">
                                            Không KD
                                        </td>
                                    </tr>
                                </table>
                            </HeaderTemplate>
                            <HeaderStyle CssClass="" />
                            <ItemTemplate>
                                <table border="1" cellspacing="0" cellpadding="2" width="100%">
                                    <tr>
                                        <td style="width: 25%" align="right">
                                            <%# Eval("QLNN") %>
                                        </td>
                                        <td style="width: 25%" align="right">
                                            <%# Eval("KINH_DOANH") %>
                                        </td>
                                        <td style="width: 25%" align="right">
                                            <%# Eval("KHONG_KINH_DOANH") %>
                                        </td>
                                        <td style="width: 25%" align="right">
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
</asp:Content>
