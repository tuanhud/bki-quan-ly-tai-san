<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="F900_Danh_muc_xe_oto.aspx.cs" Inherits="BaoCao_F900_Danh_muc_xe_oto_de_nghi_xu_ly" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.8.3.min.js"></script>
    <%# Eval("GIA_TRI_CON_LAI") %>
    <table cellspacing="0" cellpadding="2" style="width: 99%;" class="cssTable" border="0">
        <tr>
            <td class="cssPageTitleBG" colspan="4">
                <span class="cssPageTitle">Kê khai xe ô tô</span> <span class="expand-collapse-text initial-expand">
                </span><span class="expand-collapse-text"></span>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 15%">
                <span class="cssManField">Từ khóa</span>
            </td>
            <td align="left" style="width: 30%">
                <asp:TextBox ID="m_txt_tu_khoa" runat="server" CssClass="cssTextBox" 
                    Width="85%"></asp:TextBox>
            </td>
            <td align="right">
                <span class="cssManField">Trạng thái</span>
            </td>
            <td align="left">
                <asp:DropDownList ID="m_cbo_trang_thai" runat="server" Width="264px" 
                    CssClass="cssDorpdownlist" AutoPostBack="True" />
            </td>
        </tr>
        <tr>
            <td align="right">
            </td>
            <td align="left" colspan="2">
                <asp:Button ID="m_cmd_tim_kiem" runat="server" AccessKey="s" 
                    CssClass="cssButton" Height="24px"
                    Text="Tìm kiếm" Width="98px" onclick="m_cmd_tim_kiem_Click"/>
            </td>
            <td align="left">
                <asp:Button ID="m_cmd_xuat_excel" runat="server" CausesValidation="False" CssClass="cssButton"
                    Height="25px" Text="Xuất Excel" Width="98px" />
            </td>
        </tr>
        <tr>
            <td align="right">
            </td>
            <td align="left">
                <asp:Label ID="Label1" Visible="false" runat="server" CssClass="cssManField" />
            </td>
            <td align="left" colspan="2">
            </td>
        </tr>
    </table>
    <div id="gridViewContent">
        <asp:GridView ID="m_grv_bao_cao_oto" AllowPaging="True" runat="server" AutoGenerateColumns="False"
            Width="100%" DataKeyNames="ID" CellPadding="4" ForeColor="#333333" PageSize="30">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField HeaderText="TÀI SẢN" ItemStyle-HorizontalAlign="Center" DataField="TEN_TAI_SAN"
                    HeaderStyle-Width="6.667%">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="NHÃN HIỆU" ItemStyle-HorizontalAlign="Center" DataField="NHAN_HIEU"
                    HeaderStyle-Width="6.667%">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="BIỂN KIỂM SOÁT" ItemStyle-HorizontalAlign="Center" DataField="BIEN_KIEM_SOAT"
                    HeaderStyle-Width="6.667%">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="SỐ CHỖ NGỒI/TẢI TRỌNG" ItemStyle-HorizontalAlign="Center"
                    DataField="SO_CHO_NGOI" HeaderStyle-Width="6.667%">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="NƯỚC SẢN XUẤT" ItemStyle-HorizontalAlign="Center" DataField="NUOC_SAN_XUAT"
                    HeaderStyle-Width="6.667%">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="NGÀY, THÁNG, NĂM SỬ DỤNG" ItemStyle-HorizontalAlign="Center"
                    DataField="NAM_SU_DUNG" HeaderStyle-Width="6.667%">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="CÔNG SUẤT XE" ItemStyle-HorizontalAlign="Center" DataField="CONG_SUAT_XE"
                    HeaderStyle-Width="6.667%">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="CHỨC DANH SỬ DỤNG XE" ItemStyle-HorizontalAlign="Center"
                    DataField="CHUC_DANH_SU_DUNG" HeaderStyle-Width="6.667%">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField HeaderText="NGUỒN GỐC XE" ItemStyle-HorizontalAlign="Center" DataField="NGUON_GOC_XE"
                    HeaderStyle-Width="6.667%">
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="20%">
                    <HeaderTemplate>
                        <table border="1" cellspacing="0" cellpadding="3" width="100%">
                            <tr>
                                <td colspan="3">
                                    GIÁ TRỊ THEO SỔ KẾ TOÁN
                                    <br />
                                    (NGÀN ĐỒNG)
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    Nguyên giá
                                </td>
                                <td rowspan="2" style="width: 33%">
                                    Giá trị còn lại
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 33.5%">
                                    Nguồn NS
                                </td>
                                <td style="width: 33.5%">
                                    Nguồn khác
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table border="1" cellspacing="0" cellpadding="2" width="100%">
                            <tr>
                                <td style="width: 33.5%">
                                    <%# Eval("NGUON_NS") %>
                                </td>
                                <td style="width: 33.5%">
                                    <%# Eval("NGUON_KHAC") %>
                                </td>
                                <td style="width: 33%">
                                    <%# Eval("GIA_TRI_CON_LAI") %>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="20%">
                    <HeaderTemplate>
                        <table border="1" cellspacing="0" cellpadding="3" width="100%">
                            <tr>
                                <td colspan="4">
                                    HIỆN TRẠNG SỬ DỤNG<br />
                                    (chiếc)
                                </td>
                            </tr>
                            <tr>
                                <td rowspan="2" style="width: 25%">
                                    QLNN
                                </td>
                                <td colspan="2" style="width: 50%">
                                    HĐ Sự nghiệp
                                </td>
                                <td rowspan="2" style="width: 25%">
                                    HĐ Khác
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 25%">
                                    Kinh doanh
                                </td>
                                <td style="width: 25%">
                                    Không kinh doanh
                                </td>
                            </tr>
                        </table>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <table border="1" cellspacing="0" cellpadding="2" width="100%">
                            <tr>
                                <td style="width: 25%">
                                    <%# Eval("QLNN") %>
                                </td>
                                <td style="width: 25%">
                                    <%# Eval("KINH_DOANH") %>
                                </td>
                                <td style="width: 25%">
                                    <%# Eval("KHONG_KINH_DOANH") %>
                                </td>
                                <td style="width: 25%">
                                    <%# Eval("HD_KHAC") %>
                                </td>
                            </tr>
                        </table>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <HeaderStyle BackColor="#810c15" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle CssClass="cssSelectedRow" BackColor="#C5BBAF" Font-Bold="True"
                ForeColor="#333333"></SelectedRowStyle>
            <PagerSettings Position="TopAndBottom" />
        </asp:GridView>
    </div>
</asp:Content>
