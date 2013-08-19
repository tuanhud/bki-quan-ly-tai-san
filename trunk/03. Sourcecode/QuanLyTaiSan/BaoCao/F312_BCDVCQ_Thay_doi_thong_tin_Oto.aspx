<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="F312_BCDVCQ_Thay_doi_thong_tin_Oto.aspx.cs" Inherits="BaoCao_F312_BCDVCQ_Thay_doi_thong_tin_Oto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table border="0" cellspacing="0" cellpadding="0" width="100%" class="cssTable">
        <tr>
            <td class="cssPageTitleBG" colspan="6">
                <span class="expand-collapse-text initial-expand"></span><span class="expand-collapse-text">
                </span><span class="cssPageTitle">BÁO CÁO THAY ĐỔI THÔNG TIN Ô TÔ</span>
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
            <td style="width: 34%">
                <asp:DropDownList ID="m_cbo_bo_tinh" Width="90%" runat="Server" AutoPostBack="True"
                    TabIndex="1">
                </asp:DropDownList>
            </td>
            <td style="width: 1%">
            </td>
            <td align="right" style="width: 15%">
                <span class="cssManField">Đơn vị chủ quản:</span>
            </td>
            <td style="width: 34%">
                <asp:DropDownList ID="m_cbo_don_vi_chu_quan" Width="90%" runat="Server" AutoPostBack="True"
                    TabIndex="2">
                </asp:DropDownList>
            </td>
            <td style="width: 1%">
            </td>
        </tr>
        <tr>
            <td align="right">
                <span class="cssManField">Đơn vị sử dụng tài sản:</span>
            </td>
            <td>
                <asp:DropDownList ID="m_cbo_don_vi_su_dung_tai_san" Width="90%" runat="Server" AutoPostBack="True"
                    TabIndex="3">
                </asp:DropDownList>
            </td>
            <td>
            </td>
            <td align="right">
                <span class="cssManField">Trạng thái</span></td>
            <td>
                <asp:DropDownList ID="m_cbo_trang_thai0" runat="Server" Width="90%">
                </asp:DropDownList>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="cssManField" align="right">
                <span>Từ ngày:</span>
            </td>
            <td>
                <asp:TextBox ID="m_txt_tu_ngay" runat="Server" Width="89%"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="m_rfv_ma_phieu" runat="server" ControlToValidate="m_txt_tu_ngay"
                    ErrorMessage="Bạn phải nhập Từ Ngày" Text="*" ValidationGroup="m_vlg_tai_san"
                    ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
            <td class="cssManField" align="right">
                <span>Đến ngày:</span>
            </td>
            <td>
                <asp:TextBox ID="m_txt_den_ngay" runat="Server" Width="89%"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="m_txt_den_ngay"
                    ErrorMessage="Bạn phải nhập Đến Ngày" Text="*" ValidationGroup="m_vlg_tai_san"
                    ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right">
                <span class="cssManField">Tìm kiếm:</span>
            </td>
            <td colspan="4">
                <asp:TextBox ID="m_txt_tim_kiem" runat="Server" Width="95%"></asp:TextBox>
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
                    Width="98px" Text="Lọc dữ liệu(l)" Height="23px" TabIndex="5" />
                <asp:Button ID="m_cmd_xuat_excel" AccessKey="x" CssClass="cssButton" runat="server"
                    Width="98px" Text="Xuất Excel (x)" Height="22px"/>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
            </td>
        </tr>
    </table>
    <table cellspacing="0" cellpadding="2" style="width: 100%;" class="cssTable" border="0">
        <tr>
            <td class="cssPageTitleBG" colspan="6">
                <span class="cssPageTitle">THÔNG TIN THAY ĐỔI</span> <span class="expand-collapse-text initial-expand">
                </span><span class="expand-collapse-text"></span>
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
        <tr>
            <td align="center" colspan="3" style="height: 450px;" valign="top">
                4<asp:GridView ID="m_grv_oto_history" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    Width="100%" DataKeyNames="ID" CellPadding="4" ForeColor="#333333" AllowSorting="True"
                    EmptyDataText="Không có dữ liệu phù hợp" PageSize="15" ShowHeader="true" OnPageIndexChanging="m_grv_oto_history_PageIndexChanging">
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#810c15" Font-Bold="True" ForeColor="White" />
                    <PagerSettings Position="TopAndBottom" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle CssClass="cssSelectedRow" BackColor="#C5BBAF" Font-Bold="True"
                        ForeColor="#333333"></SelectedRowStyle>
                    <Columns>
                        <asp:BoundField HeaderText="NGÀY CẬP NHẬT CUỐI" DataField="NGAY_CAP_NHAT_CUOI" ItemStyle-HorizontalAlign="right" />
                        <asp:BoundField HeaderText="LỊCH SỬ CẬP NHẬT" DataField="GHI_CHU_LICH_SU" ItemStyle-HorizontalAlign="left" />
                        <asp:BoundField HeaderText="TÊN TÀI SẢN" DataField="TEN_TAI_SAN" />
                        <asp:BoundField HeaderText="MÃ TÀI SẢN" DataField="MA_TAI_SAN" />
                        <asp:BoundField HeaderText="NHÃN HIỆU" DataField="NHAN_HIEU" />
                        <asp:BoundField HeaderText="NƯỚC SẢN XUẤT" DataField="NUOC_SAN_XUAT" />
                        <asp:BoundField HeaderText="BIỂN KIỂM SOÁT" DataField="BIEN_KIEM_SOAT" />
                        <asp:BoundField HeaderText="SỐ CHỖ NGỒI" DataField="SO_CHO_NGOI" />
                        <asp:BoundField HeaderText="CÔNG SUẤT XE <br/> (ngàn đồng)" HtmlEncode="false"
                            DataField="CONG_SUAT_XE" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}" />
                        <asp:BoundField HeaderText="NĂM SỬ DỤNG" DataField="NAM_SU_DUNG" />
                        <asp:BoundField HeaderText="NĂM SẢN XUẤT" DataField="NAM_SAN_XUAT" />
                        <asp:BoundField HeaderText="NGUỒN NGÂN SÁCH <br/> (ngàn đồng)" HtmlEncode="false"
                            DataField="NGUON_NS" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}" />
                        <asp:BoundField HeaderText="NGUỒN KHÁC <br/> (ngàn đồng)" HtmlEncode="false"
                            DataField="NGUON_KHAC" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}" />
                        <asp:BoundField HeaderText="GIÁ TRỊ CÒN LẠI <br/> (ngàn đồng)" HtmlEncode="false"
                            DataField="GIA_TRI_CON_LAI" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}" />
                        <asp:BoundField HeaderText="QUẢN LÝ NHÀ NƯỚC" DataField="QLNN" />
                        <asp:BoundField HeaderText="KINH DOANH" DataField="KINH_DOANH" />
                        <asp:BoundField HeaderText="KHÔNG KINH DOANH" DataField="KHONG_KINH_DOANH" />
                        <asp:BoundField HeaderText="KHÁC" DataField="HD_KHAC" />
                        <asp:BoundField HeaderText="CHỨC NĂNG SỬ DỤNG" DataField="CHUC_NANG_SU_DUNG" />
                        <asp:BoundField HeaderText="NGUỒN GỐC XE" DataField="NGUON_GOC_XE" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
