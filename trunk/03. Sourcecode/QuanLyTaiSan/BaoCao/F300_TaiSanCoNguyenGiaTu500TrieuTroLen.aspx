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
                <asp:DropDownList ID="m_cbo_bo_tinh" Width="90%" runat="Server" OnSelectedIndexChanged="m_cbo_bo_tinh_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td align="right" colspan="1" style="width: 18%">
                <span class="cssManField">Đơn vị chủ quản:</span>
            </td>
            <td style="width: 25%">
                <asp:DropDownList ID="m_cbo_don_vi_chu_quan" Width="90%" runat="Server" OnSelectedIndexChanged="m_cbo_don_vi_chu_quan_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 18%">
                <span class="cssManField">Đơn vị sử dụng tài sản:</span>
            </td>
            <td style="width: 25%">
                <asp:DropDownList ID="m_cbo_don_vi_su_dung_tai_san" Width="90%" runat="Server" OnSelectedIndexChanged="m_cbo_don_vi_su_dung_tai_san_SelectedIndexChanged">
                </asp:DropDownList>
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
    <table border="0" cellspacing="0" cellpadding="0" width="100%" class="cssTable">
        <tr>
            <td class="cssPageTitleBG" colspan="3">
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
        <<%--tr>
            <asp:GridView ID="m_grv_dat" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                Width="100%" DataKeyNames="ID" CellPadding="4" ForeColor="#333333" AllowSorting="True"
                CLASS="cssGrid" PageSize="5">
                <Columns>
                    <asp:BoundField HeaderText="KÝ HIỆU" DataField="MA_TAI_SAN" />
                    <asp:BoundField HeaderText="ĐỊA CHỈ" DataField="DIA_CHI" />
                    <asp:TemplateField>
                        <HeaderTemplate>
                            <table border="1" cellspacing="0" cellpadding="3" width="100%">
                                <tr>
                                    <td rowspan="1" colspan="7">
                                        DIỆN TÍCH KHUÔN VIÊN ĐẤT
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="1" rowspan="2">
                                        TRỤ SỞ LÀM VIỆC
                                        <br />
                                        m2
                                    </td>
                                    <td colspan="1" rowspan="2">
                                        CƠ SỞ HOẠT ĐỘNG SỰ NGHIỆP
                                        <br />
                                        m2
                                    </td>
                                    <td colspan="5" rowspan="1">
                                        SỬ DỤNG KHÁC
                                    </td>
                                    <tr>
                                        <td>
                                            LÀM NHÀ Ở
                                        </td>
                                        <td>
                                            CHO THUÊ
                                        </td>
                                        <td>
                                            BỎ TRỐNG
                                        </td>
                                        <td>
                                            BỊ CHIẾM LẤN
                                        </td>
                                        <td>
                                            SỬ DỤNG VÀO MỤC ĐÍCH KHÁC
                                        </td>
                                    </tr>
                                </tr>
                            </table>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <table border="1" cellspacing="0" cellpadding="2" width="100%">
                                <tr>
                                    <td>
                                        <%# Eval("DT_TRU_SO_LAM_VIEC", "{0:#,###}")%>
                                    </td>
                                    <td>
                                        <%# Eval("DT_CO_SO_HOAT_DONG_SU_NGHIEP", "{0:#,###}")%>
                                    </td>
                                    <td>
                                        <%# Eval("DT_LAM_NHA_O", "{0:#,###}")%>
                                    </td>
                                    <td>
                                        <%# Eval("DT_CHO_THUE", "{0:#,###}")%>
                                    </td>
                                    <td>
                                        <%# Eval("DT_BO_TRONG", "{0:#,###}")%>
                                    </td>
                                    <td>
                                        <%# Eval("DT_BI_LAN_CHIEM", "{0:#,###}")%>
                                    </td>
                                    <td>
                                        <%# Eval("DT_SU_DUNG_MUC_DICH_KHAC", "{0:#,###}")%>
                                    </td>
                                </tr>
                            </table>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <HeaderTemplate>
                            GIÁ TỊ THEO SỔ KẾ TOÁN
                        </HeaderTemplate>
                        <ItemTemplate>
                            <%# Eval("GT_THEO_SO_KE_TOAN") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField>
                        <HeaderTemplate>
                            TRẠNG THÁI
                        </HeaderTemplate>
                        <ItemTemplate>
                            <%# get_trang_thai_dat(Convert.ToDecimal(Eval("ID_TRANG_THAI"))) %>
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
        </tr>--%>
    </table>
    <table>
        <tr>
            <td class="cssPageTitleBG" colspan="17" >
                <span class="cssPageTitle">DANH SÁCH TRỤ SỞ LÀM VIỆC, CƠ SỞ HOẠT ĐỘNG SỰ NGHIỆP</span>
                <span class="expand-collapse-text initial-expand"></span><span class="expand-collapse-text">
                </span>
            </td>
        </tr>
        <tr>
            <td colspan="17">
                <asp:GridView ID="m_grv_nha" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    Width="100%" DataKeyNames="ID" CellPadding="4" ForeColor="#333333" AllowSorting="True"
                    PageSize="5">
                    <Columns>
                        <asp:HyperLinkField HeaderText="TÀI SẢN" HeaderStyle-Width="160px" DataTextField="TEN_TAI_SAN"
                            NavigateUrl="" />
                        <asp:BoundField HeaderText="CẤP HẠNG" HeaderStyle-Width="20px" DataField="CAP_HANG" />
                        <asp:BoundField HeaderText="NĂM XÂY DỰNG" HeaderStyle-Width="20px" DataField="NAM_XAY_DUNG" />
                        <asp:BoundField HeaderText="NGÀY, THÁNG, NĂM SỬ DỤNG" HeaderStyle-Width="60px" DataField="NGAY_THANG_NAM_SU_DUNG" />
                        <asp:TemplateField>
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
                                        <td rowspan="2" style="width: 120px">
                                            Giá trị còn lại
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 90px">
                                            Nguồn NS
                                        </td>
                                        <td style="width: 120px">
                                            Nguồn khác
                                        </td>
                                    </tr>
                                </table>
                            </HeaderTemplate>
                            <HeaderStyle CssClass="" />
                            <ItemTemplate>
                                <table border="1" cellspacing="0" cellpadding="2" width="100%">
                                    <tr>
                                        <td style="width: 90px">
                                            <%# Eval("NGUON_NS", "{0:#,###.00}")%>
                                        </td>
                                        <td style="width: 120px">
                                            <%# Eval("NGUON_KHAC", "{0:#,###.00}")%>
                                        </td>
                                        <td style="width: 120px">
                                            <%# Eval("GIA_TRI_CON_LAI", "{0:#,###.00}")%>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="SỐ TẦNG" DataField="SO_TANG" />
                        <asp:BoundField HeaderText="DIỆN TÍCH XÂY DỰNG (m2)" DataField="DT_XAY_DUNG" />
                        <asp:BoundField HeaderText="TỔNG DT SÀN XÂY DỰNG (m2)" DataField="TONG_DT_SAN_XD" />
                        <asp:TemplateField>
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
                                        <td rowspan="2">
                                            Trụ sở làm việc
                                        </td>
                                        <td rowspan="2">
                                            Cơ sở HĐSN
                                        </td>
                                        <td rowspan="1" colspan="5">
                                            Sử dụng khác
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Làm nhà ở
                                        </td>
                                        <td>
                                            Cho thuê
                                        </td>
                                        <td>
                                            Bỏ trống
                                        </td>
                                        <td>
                                            Bị lấn chiếm
                                        </td>
                                        <td>
                                            Khác
                                        </td>
                                    </tr>
                                </table>
                            </HeaderTemplate>
                            <HeaderStyle CssClass="" />
                            <ItemTemplate>
                                <table border="1" cellspacing="0" cellpadding="2" width="100%">
                                    <tr>
                                        <td>
                                            <%# Eval("TRU_SO_LAM_VIEC") %>
                                        </td>
                                        <td>
                                            <%# Eval("CO_SO_HDSN") %>
                                        </td>
                                        <td>
                                            <%# Eval("LAM_NHA_O") %>
                                        </td>
                                        <td>
                                            <%# Eval("CHO_THUE") %>
                                        </td>
                                        <td>
                                            <%# Eval("BO_TRONG") %>
                                        </td>
                                        <td>
                                            <%# Eval("BI_LAN_CHIEM") %>
                                        </td>
                                        <td>
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
