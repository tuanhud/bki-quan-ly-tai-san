﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="F301_DMTruSoCoSoHDSuNghiepDNXL.aspx.cs" Inherits="BaoCao_F301_DMTruSoCoSoHDSuNghiepDNXL" %>

<%@ Import Namespace="WebUS" %>
<%@ Import Namespace="WebDS.CDBNames" %>
<%@ Register Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"
    TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table border="0" cellspacing="0" cellpadding="0" width="100%" class="cssTable">
                <tr>
                    <td class="cssPageTitleBG" colspan="4">
                        <asp:Label ID="m_lbl_tieu_de" runat="Server" class="cssPageTitle"></asp:Label>
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
                    <td align="right" colspan="1" style="width: 15%">
                        <span class="cssManField">Bộ, tỉnh:</span>
                    </td>
                    <td style="width: 35%">
                        <asp:DropDownList ID="m_cbo_bo_tinh" Width="90%" runat="Server" AutoPostBack="True"
                            OnSelectedIndexChanged="m_cbo_bo_tinh_SelectedIndexChanged" TabIndex="1">
                        </asp:DropDownList>
                    </td>
                    <td align="right" style="width: 15%">
                        <span class="cssManField">Đơn vị chủ quản:</span>
                    </td>
                    <td style="width: 35%">
                        <asp:DropDownList ID="m_cbo_don_vi_chu_quan" Width="90%" runat="Server" AutoPostBack="True"
                            OnSelectedIndexChanged="m_cbo_don_vi_chu_quan_SelectedIndexChanged" TabIndex="2">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span class="cssManField">Loại hình đơn vị sử dụng:</span>
                    </td>
                    <td>
                        <asp:DropDownList ID="m_cbo_loai_hinh_don_vi" runat="Server" Width="90%" AutoPostBack="True"
                            OnSelectedIndexChanged="m_cbo_loai_hinh_don_vi_SelectedIndexChanged">
                        </asp:DropDownList>
                        </asp>
                    </td>
                    <td align="right">
                        <span class="cssManField">Đơn vị sử dụng tài sản:</span>
                    </td>
                    <td>
                        <asp:DropDownList ID="m_cbo_don_vi_su_dung_tai_san" Width="90%" runat="Server" AutoPostBack="True"
                            OnSelectedIndexChanged="m_cbo_don_vi_su_dung_tai_san_SelectedIndexChanged" TabIndex="3">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span class="cssManField">Địa chỉ đất: </span>
                    </td>
                    <td>
                        <asp:DropDownList ID="m_cbo_dia_chi" runat="Server" Width="90%" TabIndex="4">
                        </asp:DropDownList>
                    </td>
                    <td align="right">
                        <span class="cssManField">Trạng thái nhà:</span>
                    </td>
                    <td>
                        <asp:DropDownList ID="m_cbo_trang_thai" runat="Server" Width="90%" AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="1" align="right">
                        <asp:Label ID="m_lbl_tu_khoa" runat="server" Text="Từ khoá:" CssClass="cssManField"></asp:Label>
                    </td>
                    <td colspan="1">
                        <asp:TextBox ID="m_txt_tu_khoa" runat="server" CssClass="cssTextBox" Style="width: 89%"></asp:TextBox>
                    </td>
                </tr>
                <tr style="height: 10px">
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
                    <td>
                        &nbsp;
                    </td>
                    <td align="left">
                        <asp:Button ID="m_cmd_loc_du_lieu" AccessKey="l" CssClass="cssButton" runat="server"
                            Width="98px" Text="Lọc dữ liệu(l)" Height="23px" OnClick="m_cmd_loc_du_lieu_Click"
                            TabIndex="5" />
                        <asp:Button ID="m_cmd_xuat_excel" AccessKey="x" CssClass="cssButton" runat="server"
                            Width="98px" Text="Xuất Excel (x)" Height="22px" OnClick="m_cmd_xuat_excel_Click" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
            <table border="0" cellspacing="0" cellpadding="0" width="150%" class="cssTable">
                <tr>
                    <td class="cssPageTitleBG">
                        <asp:Label ID="m_lbl_title" runat="server" Text="THÔNG TIN NHÀ ĐẤT " CssClass="cssPageTitle"></asp:Label><span
                            class="expand-collapse-text initial-expand"> </span><span class="expand-collapse-text">
                            </span>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel ID="m_pnl_thong_tin_nha_dat" runat="Server" Width="100%">
                            <table border="0" cellspacing="0" cellpadding="0" width="100%">
                                <tr>
                                    <td colspan="1" style="width: 5%">
                                    </td>
                                    <td colspan="1" style="width: 30%">
                                        <span class="cssManField">I-Về đất:</span>
                                    </td>
                                    <td colspan="1" style="width: 15%">
                                    </td>
                                    <td colspan="1" style="width: 30%">
                                    </td>
                                    <td colspan="1" style="width: 15%">
                                    </td>
                                    <td colspan="1" style="width: 5%">
                                    </td>
                                </tr>
                                <tr class="cssManField">
                                    <td colspan="1">
                                    </td>
                                    <td colspan="1" align="right">
                                        <span class="cssManField">Địa chỉ: </span>&nbsp;
                                    </td>
                                    <td align="left" colspan="2">
                                        <span>&nbsp;&nbsp;&nbsp;&nbsp;</span>
                                        <asp:Label ID="m_lbl_dia_chi" runat="Server" ForeColor="blue"></asp:Label>
                                    </td>
                                </tr>
                                <tr class="cssManField">
                                    <td>
                                    </td>
                                    <td colspan="1" class="cssManField" align="left">
                                        <span>a-Diện tích khuôn viên đất: </span>
                                    </td>
                                    <td align="right" colspan="1">
                                        <span>&nbsp;&nbsp;&nbsp;&nbsp;</span>
                                        <asp:Label ID="m_lbl_dien_tich_khuon_vien_dat" runat="server" ForeColor="blue" />
                                        <span class="cssManField">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; m2</span>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td colspan="4" class="cssManField">
                                        <span>b-Hiện trạng sử dụng: </span>
                                    </td>
                                </tr>
                                <tr class="cssManField">
                                    <td>
                                    </td>
                                    <td align="right" colspan="1">
                                        Làm trụ sở làm việc:
                                    </td>
                                    <td colspan="1" align="right">
                                        <span>&nbsp;&nbsp;&nbsp;&nbsp;</span>
                                        <asp:Label ID="m_lbl_lam_tru_so_lam_viec" runat="server" ForeColor="blue" />
                                        <span class="cssManField">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; m2</span>
                                    </td>
                                    <tr class="cssManField">
                                        <td>
                                        </td>
                                        <td align="right" colspan="1">
                                            <span>Làm cơ sở HĐ sự nghiệp:</span>
                                        </td>
                                        <td colspan="1" align="right">
                                            <span>&nbsp;&nbsp;&nbsp;&nbsp;</span>
                                            <asp:Label ID="m_lbl_lam_co_so_hd_du_nghiep" runat="Server" ForeColor="blue"></asp:Label>
                                            <span class="cssManField">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; m2</span>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </tr>
                                <tr class="cssManField">
                                    <td>
                                    </td>
                                    <td align="right" colspan="1">
                                        <span>Làm nhà ở:</span>
                                    </td>
                                    <td colspan="1" align="right">
                                        <span>&nbsp;&nbsp;&nbsp;&nbsp;</span>
                                        <asp:Label ID="m_lbl_lam_nha_o" runat="Server" ForeColor="blue"></asp:Label>
                                        <span class="cssManField">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; m2</span>
                                    </td>
                                </tr>
                                <tr class="cssManField">
                                    <td>
                                    </td>
                                    <td align="right" colspan="1">
                                        <span>Cho thuê:</span>
                                    </td>
                                    <td colspan="1" align="right">
                                        <span>&nbsp;&nbsp;&nbsp;&nbsp;</span>
                                        <asp:Label ID="m_lbl_cho_thue" runat="Server" ForeColor="blue"></asp:Label>
                                        <span class="cssManField">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; m2</span>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr class="cssManField">
                                    <td>
                                    </td>
                                    <td align="right">
                                        <span>Bỏ trống:</span>
                                    </td>
                                    <td align="right">
                                        <span>&nbsp;&nbsp;&nbsp;&nbsp;</span>
                                        <asp:Label ID="m_lbl_bo_trong" runat="Server" ForeColor="blue"></asp:Label>
                                        <span class="cssManField">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; m2</span>
                                    </td>
                                </tr>
                                <tr class="cssManField">
                                    <td>
                                    </td>
                                    <td align="right">
                                        <span>Bị lấn chiếm:</span>
                                    </td>
                                    <td align="right">
                                        <span>&nbsp;&nbsp;&nbsp;&nbsp;</span>
                                        <asp:Label ID="m_lbl_bi_lan_chiem" runat="Server" ForeColor="blue"></asp:Label>
                                        <span class="cssManField">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; m2</span>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr class="cssManField">
                                    <td>
                                    </td>
                                    <td align="right">
                                        <span>Sử dụng vào mục đích khác:</span>
                                    </td>
                                    <td align="right">
                                        <span>&nbsp;&nbsp;&nbsp;&nbsp;</span>
                                        <asp:Label ID="m_lbl_su_dung_vao_muc_dich_khac" runat="Server" ForeColor="blue"></asp:Label>
                                        <span class="cssManField">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; m2</span>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr class="cssManField">
                                    <td>
                                    </td>
                                    <td class="cssManField" colspan="1" align="left">
                                        <span>c-Giá trị theo sổ kế toán: </span>
                                    </td>
                                    <td colspan="1" align="right">
                                        <span>&nbsp;&nbsp;&nbsp;&nbsp;</span>
                                        <asp:Label ID="m_lbl_gia_tri_theo_so_ke_toan" runat="Server" ForeColor="blue">
                    
                                        </asp:Label>
                                        <span class="cssManField">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; đồng</span>
                                    </td>
                                    <td colspan="1">
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr class="cssManField">
                                    <td>
                                    </td>
                                    <td>
                                        <span>II-Về nhà</span>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr class="cssManField">
                                    <td>
                                        <br />
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="m_grv_nha" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            EmptyDataText="Không có dữ liệu phù hợp!" Width="100%" DataKeyNames="ID" CellPadding="0"
                            ForeColor="#333333" AllowSorting="True" PageSize="15" ShowHeader="true" OnPageIndexChanging="m_grv_danh_sach_nha_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField HeaderStyle-Width="2%" ItemStyle-HorizontalAlign="center" HeaderText="STT">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="CHI TIẾT" ItemStyle-HorizontalAlign='center' HeaderStyle-HorizontalAlign='center' HeaderStyle-Width="2%">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="m_lnk_lop_mon_detail" runat="server" Target="_blank" ToolTip="Xem chi tiết"
                                            NavigateUrl='<%# "~/ChucNang/F100_QuanLyNha.aspx?"+CONST_QLDB.MA_THAM_SO_URL.ID_NHA+"="+Eval(V_DM_NHA.ID) %>'
                                            ImageUrl="~/Images/Button/detail.png">Chi tiết</asp:HyperLink>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="ĐƠN VỊ BỘ TỈNH" DataField="TEN_DV_BO_TINH" HeaderStyle-Width="6%" />
                                <asp:BoundField HeaderText="ĐƠN VỊ CHỦ QUẢN" DataField="TEN_DV_CHU_QUAN" HeaderStyle-Width="7%" />
                                <asp:BoundField HeaderText="ĐƠN VỊ SỬ DỤNG" DataField="TEN_DV_SU_DUNG" HeaderStyle-Width="7%" />
                                <asp:BoundField HeaderText="ĐỊA CHỈ" DataField="DIA_CHI" HeaderStyle-Width="8%" />
                                <asp:HyperLinkField HeaderText="TÀI SẢN" HeaderStyle-Width="8%" DataTextField="TEN_TAI_SAN"
                                    NavigateUrl="" />
                                <asp:BoundField HeaderText="CẤP HẠNG" HeaderStyle-Width="2%" DataField="CAP_HANG">
                                    <ItemStyle HorizontalAlign="center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="NĂM XÂY DỰNG" HeaderStyle-Width="2%" DataField="NAM_XAY_DUNG">
                                    <ItemStyle HorizontalAlign="center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="NĂM SỬ DỤNG" HeaderStyle-Width="2%" DataField="NGAY_THANG_NAM_SU_DUNG">
                                    <ItemStyle HorizontalAlign="center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderStyle-Width="18.5%" HeaderStyle-Height="110px">
                                    <HeaderTemplate>
                                        <table border="1" cellspacing="0" cellpadding="2" width="100%" style="border-collapse: collapse;">
                                            <tr>
                                                <td colspan="3" style="height: 50px; text-align: center; color: White; font-weight: bold">
                                                    GIÁ TRỊ THEO SỔ KẾ TOÁN
                                                    <br />
                                                    (ngàn đồng)
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" rowspan="1" style="text-align: center; color: White; font-weight: bold">
                                                    Nguyên giá
                                                </td>
                                                <td rowspan="2" style="width: 33.33%; height: 60px; text-align: center; color: White;
                                                    font-weight: bold">
                                                    Giá trị còn lại
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 33.33%; text-align: center; color: White; font-weight: bold">
                                                    Nguồn NS
                                                </td>
                                                <td style="width: 33.33%; text-align: center; color: White; font-weight: bold">
                                                    Nguồn khác
                                                </td>
                                            </tr>
                                        </table>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <table border="0" cellspacing="0" cellpadding="2" width="100%">
                                            <tr>
                                                <td style="width: 33.33%; border-right: 1px solid gray;" align="right">
                                                    <%# Eval("NGUON_NS", "{0:#,###}")%>
                                                </td>
                                                <td style="width: 33.33%; border-right: 1px solid gray;" align="right">
                                                    <%# Eval("NGUON_KHAC", "{0:#,###}")%>
                                                </td>
                                                <td style="width: 33.33%; height: 40px;" align="right">
                                                    <%# Eval("GIA_TRI_CON_LAI", "{0:#,###}")%>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="SỐ TẦNG" DataField="SO_TANG" HeaderStyle-Width="2%">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="DIỆN TÍCH XÂY DỰNG <br/> (m2)" DataFormatString="{0:#,###}" HtmlEncode="false" DataField="DT_XAY_DUNG"
                                    HeaderStyle-Width="3.25%">
                                    <ItemStyle HorizontalAlign="right" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="TỔNG DT SÀN XÂY DỰNG <br/> (m2)" DataFormatString="{0:#,###}" HtmlEncode="false" DataField="TONG_DT_SAN_XD"
                                    HeaderStyle-Width="3.25%">
                                    <ItemStyle HorizontalAlign="right" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderStyle-Width="20%" HeaderStyle-Height="110px">
                                    <HeaderTemplate>
                                        <table border="1" cellspacing="0" cellpadding="2" width="100%" style="border-collapse: collapse;">
                                            <tr>
                                                <td colspan="7" style="height: 50px; text-align: center; color: White; font-weight: bold">
                                                    HIỆN TRẠNG SỬ DỤNG
                                                    <br />
                                                    (m2)
                                                </td>
                                            </tr>
                                            <tr>
                                                <td rowspan="2" style="width: 14.28%; height: 60px; text-align: center; color: White;
                                                    font-weight: bold">
                                                    Trụ sở làm việc
                                                </td>
                                                <td rowspan="2" style="width: 14.28%; text-align: center; color: White; font-weight: bold">
                                                    Cơ sở HĐSN
                                                </td>
                                                <td rowspan="1" colspan="5" style="text-align: center; color: White; font-weight: bold">
                                                    Sử dụng khác
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 14.28%; text-align: center; color: White; font-weight: bold">
                                                    Làm nhà ở
                                                </td>
                                                <td style="width: 14.28%; text-align: center; color: White; font-weight: bold">
                                                    Cho thuê
                                                </td>
                                                <td style="width: 14.28%; text-align: center; color: White; font-weight: bold">
                                                    Bỏ trống
                                                </td>
                                                <td style="width: 14.28%; text-align: center; color: White; font-weight: bold">
                                                    Bị lấn chiếm
                                                </td>
                                                <td style="width: 14.28%; text-align: center; color: White; font-weight: bold">
                                                    Khác
                                                </td>
                                            </tr>
                                        </table>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <table border="0" cellspacing="0" cellpadding="2" width="100%">
                                            <tr>
                                                <td style="width: 14.28%; height: 40px; border-right: 1px solid gray;" align="right">
                                                    <%# Eval("TRU_SO_LAM_VIEC", "{0:#,###}")%>
                                                </td>
                                                <td style="width: 14.28%; border-right: 1px solid gray;" align="right">
                                                    <%# Eval("CO_SO_HDSN", "{0:#,###}")%>
                                                </td>
                                                <td style="width: 14.28%; border-right: 1px solid gray;" align="right">
                                                    <%# Eval("LAM_NHA_O", "{0:#,###}")%>
                                                </td>
                                                <td style="width: 14.28%; border-right: 1px solid gray;" align="right">
                                                    <%# Eval("CHO_THUE", "{0:#,###}")%>
                                                </td>
                                                <td style="width: 14.28%; border-right: 1px solid gray;" align="right">
                                                    <%# Eval("BO_TRONG", "{0:#,###}")%>
                                                </td>
                                                <td style="width: 14.28%; border-right: 1px solid gray;" align="right">
                                                    <%# Eval("BI_LAN_CHIEM", "{0:#,###}")%>
                                                </td>
                                                <td style="width: 14.28%;" align="right">
                                                    <%# Eval("KHAC", "{0:#,###}")%>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="TRẠNG THÁI" DataField="TEN_TRANG_THAI" HeaderStyle-Width="6%"
                                    ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField HeaderText="TÌNH TRẠNG" DataField="TEN_TINH_TRANG" HeaderStyle-Width="4%"
                                    ItemStyle-HorizontalAlign="Center" />
                                <asp:TemplateField HeaderText="LOẠI HÌNH ĐƠN VỊ">
                                    <ItemTemplate>
                                        <%#get_ten_loai_hinh_don_vi()%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="MÃ ĐƠN VI SỬ DỤNG">
                                    <ItemTemplate>
                                        <%#get_ma_don_vi_su_dung()%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="DT KHUÔN VIÊN ĐẤT">
                                    <ItemTemplate>
                                        <%#get_thong_tin_dat(THONG_TIN_DAT.DT_KHUON_VIEN_DAT)%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="DT ĐẤT LÀM TRỤ SỞ LÀM VIỆC">
                                    <ItemTemplate>
                                        <%#get_thong_tin_dat(THONG_TIN_DAT.HTSD_LAM_TRU_SO_LAM_VIEC)%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="DT ĐẤT LÀM CƠ SỞ HĐSN">
                                    <ItemTemplate>
                                        <%#get_thong_tin_dat(THONG_TIN_DAT.HTSD_CO_SO_HDSN)%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="DT ĐẤT LÀM NHÀ Ở">
                                    <ItemTemplate>
                                        <%#get_thong_tin_dat(THONG_TIN_DAT.HTSD_LAM_NHA_O)%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="DT ĐẤT CHO THUÊ">
                                    <ItemTemplate>
                                        <%#get_thong_tin_dat(THONG_TIN_DAT.HTSD_CHO_THUE)%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="DT ĐẤT BỎ TRỐNG">
                                    <ItemTemplate>
                                        <%#get_thong_tin_dat(THONG_TIN_DAT.HTSD_BO_TRONG)%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="DT ĐẤT BỊ LẤN CHIẾM">
                                    <ItemTemplate>
                                        <%#get_thong_tin_dat(THONG_TIN_DAT.HTSD_BI_LAN_CHIEM)%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="DT ĐẤT SỬ DỤNG VÀO MỤC ĐÍCH KHÁC">
                                    <ItemTemplate>
                                        <%#get_thong_tin_dat(THONG_TIN_DAT.HTSD_SU_DUNG_VAO_MUC_DICH_KHAC)%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="GT ĐẤT THEO SỔ KẾ TOÁN">
                                    <ItemTemplate>
                                        <%#get_thong_tin_dat(THONG_TIN_DAT.GIA_TRI_THEO_SO_KE_TOAN)%>
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
