<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="F204_TH_HTSD_tai_san_khac_Tong_hop_chung.aspx.cs"
    Inherits="BaoCao_204_TH_HTSD_tai_san_khac_Tong_hop_chung" %>

<%@ Register Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"
    TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table border="0" cellspacing="0" cellpadding="0" width="100%" class="cssTable">
                    <tr>
                        <td class="cssPageTitleBG" colspan="6">
                            <span class="cssPageTitle">TỔNG HỢP HIỆN TRẠNG SỬ DỤNG TÀI SẢN KHÁC</span> <span
                                class="expand-collapse-text"></span>
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
                                TabIndex="1" OnSelectedIndexChanged="m_cbo_bo_tinh_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 1%">
                        </td>
                        <td align="right" style="width: 15%">
                            <span class="cssManField">Đơn vị chủ quản:</span>
                        </td>
                        <td style="width: 34%">
                            <asp:DropDownList ID="m_cbo_don_vi_chu_quan" Width="90%" runat="Server" AutoPostBack="True"
                                TabIndex="3">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 1%">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td align="left">
                            <asp:Button ID="m_cmd_loc_du_lieu" AccessKey="l" CssClass="cssButton" runat="server"
                                Width="98px" Text="Lọc dữ liệu(l)" Height="23px" TabIndex="5" OnClick="m_cmd_loc_du_lieu_Click" />
                            <asp:Button ID="m_cmd_xuat_excel" AccessKey="x" CssClass="cssButton" runat="server"
                                Width="98px" Text="Xuất Excel (x)" Height="22px" OnClick="m_cmd_xuat_excel_Click" />
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
                            <asp:GridView ID="m_grv_tai_san_khac" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                EmptyDataText="Không có dữ liệu phù hợp!" Width="100%" DataKeyNames="ID" CellPadding="0"
                                ForeColor="#333333" AllowSorting="True" PageSize="10" ShowHeader="true">
                                <Columns>
                                    <asp:HyperLinkField HeaderText="TÀI SẢN" HeaderStyle-Width="20%" DataTextField="TEN_TAI_SAN"
                                        HeaderStyle-HorizontalAlign="Center" />
                                    <asp:BoundField HeaderText="SỐ LƯỢNG" HeaderStyle-Width="6.25%" DataField="SO_LUONG"
                                        ItemStyle-HorizontalAlign="right" DataFormatString="{0:#,###.##}"></asp:BoundField>
                                    <asp:TemplateField HeaderStyle-Width="25%" HeaderStyle-Height="75px">
                                        <HeaderTemplate>
                                            <table border="1" cellspacing="0" cellpadding="3" width="100%" style="border-collapse: collapse;
                                                height: 100%">
                                                <tr>
                                                    <td colspan="3" style="height: 35px; text-align: center; color: white; font-height: bold">
                                                        Giá trị theo sổ kế toán (VNĐ)
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" style="width: 66%; text-align: center; color: white; font-height: bold">
                                                        Nguyên giá
                                                    </td>
                                                    <td rowspan="2" style="width: 33%; text-align: center; color: white; font-height: bold">
                                                        Giá trị còn lại
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 33%; text-align: center; color: white; font-height: bold">
                                                        Nguồn NS
                                                    </td>
                                                    <td style="width: 33%; text-align: center; color: white; font-height: bold">
                                                        Nguồn khác
                                                    </td>
                                                </tr>
                                            </table>
                                        </HeaderTemplate>
                                        <HeaderStyle CssClass="" />
                                        <ItemTemplate>
                                            <table border="0" cellspacing="0" cellpadding="2" width="100%" style="border-collapse: collapse;
                                                text-align: right">
                                                <tr>
                                                    <td style="width: 33%; border-right: solid; border-right-width: 1px" height="40px">
                                                        <%# Eval("NGUON_NS", "{0:#,###}")%>
                                                    </td>
                                                    <td style="width: 33%; border-right: solid; border-right-width: 1px">
                                                        <%# Eval("NGUON_KHAC", "{0:#,###}")%>
                                                    </td>
                                                    <td style="width: 33%">
                                                        <%# Eval("GIA_TRI_CON_LAI", "{0:#,###}")%>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-Width="25%" HeaderStyle-Height="75px">
                                        <HeaderTemplate>
                                            <table border="1" cellspacing="0" cellpadding="2" width="100%" style="border-collapse: collapse;
                                                height: 100%">
                                                <tr>
                                                    <td colspan="4" style="height: 39px; text-align: center; color: white; font-height: bold">
                                                        Hiện trạng sử dụng (cái, chiếc)
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td rowspan="2" style="width: 25%; text-align: center; color: white; font-height: bold">
                                                        Quản lý nhà nước
                                                    </td>
                                                    <td colspan="2" style="width: 50%; text-align: center; color: white; font-height: bold">
                                                        Hoạt đông sự nghiệp
                                                    </td>
                                                    <td rowspan="2" style="width: 25%; text-align: center; color: white; font-height: bold">
                                                        Khác
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 25%; text-align: center; color: white; font-height: bold">
                                                        Kinh doanh
                                                    </td>
                                                    <td style="width: 25%; text-align: center; color: white; font-height: bold">
                                                        Không kinh doanh
                                                    </td>
                                                </tr>
                                            </table>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <table border="0" cellspacing="0" cellpadding="2" width="100%" style="text-align: right;
                                                border-collapse: collapse;">
                                                <tr>
                                                    <td style="width: 25%; border-right: solid; border-right-width: 1px" height="40px">
                                                        <%# Eval("QUAN_LY_NN", "{0:#,###}")%>
                                                    </td>
                                                    <td style="width: 25%; border-right: solid; border-right-width: 1px">
                                                        <%# Eval("KINH_DOANH", "{0:#,###}")%>
                                                    </td>
                                                    <td style="width: 25%; border-right: solid; border-right-width: 1px">
                                                        <%# Eval("KHONG_KINH_DOANH", "{0:#,###}")%>
                                                    </td>
                                                    <td style="width: 25%">
                                                        <%# Eval("HD_KHAC", "{0:#,###}")%>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="TÊN ĐƠN VỊ BỘ TỈNH">
                                        <ItemTemplate>
                                            <%#get_ten_bo_tinh()%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="TÊN ĐƠN VỊ CHỦ QUẢN">
                                        <ItemTemplate>
                                            <%#get_ten_don_vi_chu_quan()%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="MÃ ĐƠN VỊ CHỦ QUẢN">
                                        <ItemTemplate>
                                            <%#get_ma_don_vi_chu_quan()%>
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
    </div>
    <asp:UpdateProgress ID="Updateprogress1" runat="server">
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
