<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="F307_TH_HTSD_nha_dat_Tong_hop_chung.aspx.cs" Inherits="BaoCao_F307_TH_HTSD_nha_dat_Tong_hop_chung" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table border="0" cellspacing="0" cellpadding="0" width="100%" class="cssTable">
        <tr>
            <td class="cssPageTitleBG" colspan="6">
                <span class="cssPageTitle">TỔNG HỢP HIỆN TRẠNG SỬ DỤNG NHÀ, ĐẤT</span> <span class="expand-collapse-text">
                </span>
                <br />
                <span class="cssPageTitle">Phần 1: Tổng hợp chung</span><span class="expand-collapse-text initial-expand"></span>
            </td>
        </tr>
        <tr>
            <td colspan="6">
                <asp:ValidationSummary ID="vdsCategory" runat="server" CssClass="cssManField" Font-Bold="true"
                    ValidationGroup="m_vlg_tai_san_nha_dat" />
                <asp:Label ID="m_lbl_mess" runat="server" CssClass="cssManField" />
            </td>
        </tr>
        <tr>
            <td align="right" colspan="1" style="width: 15%">
                <span class="cssManField">Bộ, tỉnh:</span>
            </td>
            <td style="width: 34%">
                <asp:DropDownList ID="m_cbo_bo_tinh" Width="90%" runat="Server" AutoPostBack="True"
                    TabIndex="1" onselectedindexchanged="m_cbo_bo_tinh_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
            <td style="width: 1%">
            </td>
            <td align="right" style="width: 15%">
                <span class="cssManField">Đơn vị chủ quản:</span>
            </td>
            <td style="width: 34%">
                <asp:DropDownList ID="m_cbo_don_vi_chu_quan" Width="90%" runat="Server" AutoPostBack="True"
                    TabIndex="2" 
                    onselectedindexchanged="m_cbo_don_vi_chu_quan_SelectedIndexChanged">
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
                <span class="cssManField">Trạng thái:</span>
            </td>
            <td>
                <asp:DropDownList ID="m_cbo_trang_thai" Width="90%" runat="Server" AutoPostBack="True"
                    TabIndex="3">
                </asp:DropDownList>
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
                    ErrorMessage="Bạn phải nhập Từ Ngày" Text="*" ValidationGroup="m_vlg_tai_san_nha_dat"
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
                    ErrorMessage="Bạn phải nhập Đến Ngày" Text="*" ValidationGroup="m_vlg_tai_san_nha_dat"
                    ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td align="left">
                <asp:Button ID="m_cmd_loc_du_lieu" AccessKey="l" CssClass="cssButton" runat="server"
                    Width="98px" Text="Lọc dữ liệu(l)" Height="23px" TabIndex="5" 
                    onclick="m_cmd_loc_du_lieu_Click" />
                <asp:Button ID="m_cmd_xuat_excel" AccessKey="x" CssClass="cssButton" runat="server"
                    Width="98px" Text="Xuất Excel (x)" Height="22px" />
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
    </table>
    <table border="0" cellspacing="0" cellpadding="0" width="100%" class="cssTable">
        <tr>
            <td class="cssPageTitleBG">
                <span class="cssPageTitle">Chi tiết tài sản</span> <span class="expand-collapse-text initial-expand">
                </span><span class="expand-collapse-text"></span>
            </td>
        </tr>
        <tr>
            <td style="width: 10%">
                <asp:GridView ID="m_grv_tai_san_nha_dat" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    EmptyDataText="Không có dữ liệu phù hợp!" Width="100%" DataKeyNames="ID" CellPadding="0"
                    ForeColor="#333333" AllowSorting="True" PageSize="10" ShowHeader="true">
                    <Columns>
                        <asp:HyperLinkField HeaderText="TÀI SẢN" HeaderStyle-Width="31.25%" DataTextField="TEN_TAI_SAN"
                            HeaderStyle-HorizontalAlign="Center" />
                        <asp:BoundField HeaderText="SỐ LƯỢNG" HeaderStyle-Width="6.25%" DataField="SO_LUONG"
                            ItemStyle-HorizontalAlign="right"></asp:BoundField>
                        <asp:BoundField HeaderText="DIỆN TÍCH" HeaderStyle-Width="18.75%" DataField="DIEN_TICH"
                            ItemStyle-HorizontalAlign="right" HeaderStyle-HorizontalAlign="Center"></asp:BoundField>
                        <asp:TemplateField HeaderStyle-Width="30%" HeaderStyle-Height="110px">
                            <HeaderTemplate>
                                <table border="1" cellspacing="0" cellpadding="2" width="100%" style="border-collapse: collapse;">
                                    <tr>
                                        <td colspan="7" style="height: 50px">
                                            HIỆN TRẠNG SỬ DỤNG
                                            <br />
                                            (m2)
                                        </td>
                                    </tr>
                                    <tr>
                                        <td rowspan="2" style="width: 6.25%; height: 60px">
                                            Trụ sở làm việc
                                        </td>
                                        <td rowspan="2" style="width: 6.25%">
                                            Cơ sở HĐSN
                                        </td>
                                        <td rowspan="1" colspan="5">
                                            Sử dụng khác
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 6.25%">
                                            Làm nhà ở
                                        </td>
                                        <td style="width: 6.25%">
                                            Cho thuê
                                        </td>
                                        <td style="width: 6.25%">
                                            Bỏ trống
                                        </td>
                                        <td style="width: 6.25%">
                                            Bị lấn chiếm
                                        </td>
                                        <td style="width: 6.25%">
                                            Khác
                                        </td>
                                    </tr>
                                </table>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <table border="0" cellspacing="0" cellpadding="2" width="100%">
                                    <tr>
                                        <td style="width: 6.25%; height: 40px; border-right: 1px solid gray;" align="right">
                                            <%# Eval("TRU_SO_LAM_VIEC") %>
                                        </td>
                                        <td style="width: 6.25%; border-right: 1px solid gray;" align="right">
                                            <%# Eval("CO_SO_HDSN") %>
                                        </td>
                                        <td style="width: 6.25%; border-right: 1px solid gray;" align="right">
                                            <%# Eval("LAM_NHA_O") %>
                                        </td>
                                        <td style="width: 6.25%; border-right: 1px solid gray;" align="right">
                                            <%# Eval("CHO_THUE") %>
                                        </td>
                                        <td style="width: 6.25%; border-right: 1px solid gray;" align="right">
                                            <%# Eval("BO_TRONG") %>
                                        </td>
                                        <td style="width: 6.25%; border-right: 1px solid gray;" align="right">
                                            <%# Eval("BI_LAN_CHIEM") %>
                                        </td>
                                        <td style="width: 6.25%" align="right">
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
