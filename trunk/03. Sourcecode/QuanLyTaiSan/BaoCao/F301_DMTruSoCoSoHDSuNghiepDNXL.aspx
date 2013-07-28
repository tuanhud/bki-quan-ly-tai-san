<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="F301_DMTruSoCoSoHDSuNghiepDNXL.aspx.cs" Inherits="ChucNang_F301_DanhMucTruSoLamViecCoSoHoatDongSuNghiepDeNghiXuLy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table border="0" cellspacing="0" cellpadding="0" width="100%" class="cssTable">
        <tr>
            <td class="cssPageTitleBG" colspan="4">
                <span class="cssPageTitle">DANH MỤC TRỤ SỞ LÀM VIỆC, CƠ SỞ HOẠT ĐỘNG SỰ NGHIỆP ĐỀ NGHỊ
                    XỬ LÝ</span> <span class="expand-collapse-text initial-expand"></span><span class="expand-collapse-text">
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
            <td>
                &nbsp;
            </td>
            <td align="left">
                <asp:Button ID="m_cmd_loc_du_lieu" AccessKey="l" CssClass="cssButton" runat="server"
                    Width="98px" Text="Lọc dữ liệu(l)" Height="23px" />
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
            <td class="cssPageTitleBG" colspan="4">
                <span class="cssPageTitle">THÔNG TIN NHÀ ĐẤT</span> <span class="expand-collapse-text initial-expand">
                </span><span class="expand-collapse-text"></span>
            </td>
        </tr>
        <tr>
            <td align="left" colspan="1" align="left">
                <asp:Label ID="m_lbl_thong_bao" Visible="false" runat="server" CssClass="cssManField" />
            </td>
            <td align="left">
            </td>
            <td align="left">
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="left">
                <span class="cssManField">Địa chỉ:</span>
                <asp:Label ID="m_lbl_dia_chi" runat="Server"></asp:Label>
            </td>
            <td>
                &nbsp;
            </td>
            <td colspan="1">
            </td>
            <td colspan="1">
            </td>
        </tr>
        <tr>
            <td>
                <span class="cssManField">I-Về đất:</span>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="cssManField" align="left">
                <span>a-Diện tích khuôn viên đất: </span>
                <asp:Label ID="m_lbl_dien_tich_khuon_vien_dat" runat="server" />
                <span>m2</span>
            </td>
        </tr>
        <tr>
            <td colspan="4" class="cssManField">
                <span>b-Hiện trạng sử dụng: </span>
            </td>
        </tr>
        <tr class="cssManField">
            <td align="right" style="width:20%">
                Làm trụ sở làm việc:
            </td>
            <td style="width:20%">
                <asp:Label ID="m_lbl_hien_trang_su_dung" runat="server" />
                <span>m2</span>
            </td style="width:20%">
            <td align="right">
                </span> <span>Làm cơ sở HĐ sự nghiệp:</span>
            </td>
            <td style="width:20%">
                <asp:Label ID="m_lbl_lam_co_so_hd_du_nghiep" runat="Server"></asp:Label>
                <span>m2</span>
            </td>
        </tr>
        <tr class="cssManField">
            <td align="right">
                <span>Làm nhà ở:</span>
                </td>
                <td>
                <asp:Label ID="m_lbl_lam_nha_o" runat="Server"></asp:Label>
                <span>m2</span>
            </td>
            <td align="right">
                <span>Cho thuê:</span>
                </td><td>
                <asp:Label ID="m_lbl_cho_thue" runat="Server"></asp:Label>
                <span>m2</span>
            </td>
        </tr>
        <tr class="cssManField">
            <td align="right">
                <span >Bỏ trống:</span>
                </td><td>
                <asp:Label ID="m_lbl_bo_trong" runat="Server"></asp:Label>
                <span>m2</span>
            </td>
            <td align="right">
                <span>Bị lấn chiếm:</span>
                </td>
                <td>
                <asp:Label ID="m_lbl_bi_lan_chiem" runat="Server"></asp:Label>
                <span>m2</span>
            </td>
        </tr>
        <tr class="cssManField">
            <td align="right">
                <span>Sử dụng vào mục đích khác:</span>
                </td>
                <td>
                <asp:Label ID="m_lbl_su_dung_vao_muc_dich_khac" runat="Server"></asp:Label>
                <span>m2</span>
            </td>
        </tr>
        <tr>
            <td class="cssManField" colspan="2">
                <span>c-Giá trị theo sổ kế toán: </span>
                <asp:Label ID="m_lbl_gia_tri_theo_so_ke_toan" runat="Server"></asp:Label>
                <span>ngàn đồng.</span>
            </td>
        </tr>
        <tr class="cssManField">
            <td><span>II-Về nhà</span></td>
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
            <asp:BoundField HeaderText="CẤP HẠNG" DataField="CAP_HANG" />
            <asp:BoundField HeaderText="NĂM SỬ DỤNG" DataField="NAM_SU_DUNG" />
            <asp:BoundField HeaderText="NGÀY, THÁNG, NĂM SỬ DỤNG" DataField="NAM_SU_DUNG" />
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
            <asp:BoundField HeaderText="SỐ TĂNG" DataField="SO_TANG" />
            <asp:BoundField HeaderText="DT XÂY DỰNG (m2)" DataField="DT_XAY_DUNG" />
            <asp:BoundField HeaderText="TỔNG DT SÀN XÂY DỰNG (m2)" DataField="TONG_DT_SAN_XAY_DUNG" />
            <asp:TemplateField>
                <HeaderTemplate>
                    <table border="1" cellspacing="0" cellpadding="3" width="100%">
                        <tr>
                            <td colspan="7">
                                HIỆN TRẠNG SỬ DỤNG
                                <br />
                                (cái, chiếc))
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
                                Bị xâm chiếm
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
                                <%# Eval("BO_TRONG")%>
                            </td>
                            <td>
                                <%# Eval("BI_XAM_CHIEM") %>
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
</asp:Content>
