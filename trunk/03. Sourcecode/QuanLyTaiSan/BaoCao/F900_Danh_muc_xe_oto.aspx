<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="F900_Danh_muc_xe_oto.aspx.cs" Inherits="BaoCao_F900_Danh_muc_xe_oto_de_nghi_xu_ly" %>

<%@ Register Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"
    TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <script type="text/javascript" src="http://code.jquery.com/jquery-1.8.3.min.js"></script>
    <asp:ScriptManager runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel runat="server" ID="updatePanel">
        <ContentTemplate>
            <table cellspacing="0" cellpadding="2" style="width: 99%;" class="cssTable" border="0">
                <tr>
                    <td class="cssPageTitleBG" colspan="4">
                        <asp:Label ID="m_lbl_title" runat="Server" class="cssPageTitle"></asp:Label>
                        <span class="expand-collapse-text initial-expand"></span><span class="expand-collapse-text">
                        </span>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="m_lbl_mess" runat="Server" class="cssManField"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 15%;">
                        <span class="cssManField">Bộ, tỉnh:</span>
                    </td>
                    <td style="width: 35%;">
                        <asp:DropDownList ID="m_cbo_bo_tinh" runat="server" AutoPostBack="True" CssClass="cssDorpdownlist"
                            OnSelectedIndexChanged="m_cbo_bo_tinh_SelectedIndexChanged" Width="96%">
                        </asp:DropDownList>
                    </td>
                    <td align="right" style="width: 15%;">
                        <span class="cssManField">Đơn vị quản lý:</span>
                    </td>
                    <td style="width: 35%;">
                        <asp:DropDownList ID="m_cbo_don_vi_quan_ly" runat="server" AutoPostBack="True" CssClass="cssDorpdownlist"
                            OnSelectedIndexChanged="m_cbo_don_vi_quan_ly_SelectedIndexChanged" Width="96%">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span class="cssManField">Loại hình đơn vị:</span>
                    </td>
                    <td>
                        <asp:DropDownList ID="m_cbo_loai_hinh_don_vi" runat="Server" class="cssDorpdownlist"
                            Width="96%" AutoPostBack="True" OnSelectedIndexChanged="m_cbo_loai_hinh_don_vi_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td align="right" style="width: 15%;">
                        <span class="cssManField">Đơn vị sử dụng:</span>
                    </td>
                    <td style="width: 20%;">
                        <asp:DropDownList ID="m_cbo_don_vi_su_dung" runat="server" CssClass="cssDorpdownlist"
                            Width="96%" AutoPostBack="False">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 15%">
                        <span class="cssManField">Trạng thái:</span>
                    </td>
                    <td align="left" style="width: 30%">
                        <asp:DropDownList ID="m_cbo_trang_thai" runat="server" CssClass="cssDorpdownlist"
                            Width="96%">
                        </asp:DropDownList>
                    </td>
                    <td align="right">
                        <span class="cssManField">Loại xe:</span>
                    </td>
                    <td>
                        <asp:DropDownList ID="m_cbo_loai_xe" runat="Server" class="cssDorpdownlist" Width="96%">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span class="cssManField">Từ khóa:</span>&nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="m_txt_tu_khoa" runat="server" CssClass="cssTextBox" Width="95%"></asp:TextBox>
                    </td>
                    <td align="right">
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td align="left" colspan="1">
                        <asp:Button ID="m_cmd_tim_kiem" runat="server" AccessKey="s" CssClass="cssButton"
                            Height="24px" Text="Tìm kiếm" Width="98px" OnClick="m_cmd_tim_kiem_Click" />
                        <asp:Button ID="m_cmd_xuat_excel" runat="server" CausesValidation="False" CssClass="cssButton"
                            Height="25px" OnClick="m_cmd_xuat_excel_Click" Text="Xuất Excel" Width="98px" />
                    </td>
                    <td align="right" colspan="1">
                    </td>
                </tr>
                <tr>
                    <td align="right">
                    </td>
                    <td align="left" colspan="2">
                    </td>
                </tr>
            </table>
            <table border="0" cellspacing="0" cellpadding="0" class="cssTable" width="150%">
                <tr>
                    <td class="cssPageTitleBG">
                        <asp:Label ID="m_lbl_thong_tin_oto" runat="Server" class="cssPageTitle" Text="DANH SÁCH Ô TÔ"></asp:Label>
                        <span class="expand-collapse-text initial-expand"></span><span class="expand-collapse-text">
                        </span>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:GridView ID="m_grv_bao_cao_oto" AllowPaging="true" runat="server" AutoGenerateColumns="False"
                            Width="100%" DataKeyNames="ID" CellPadding="0" ForeColor="#333333" PageSize="10"
                            EmptyDataText="Không có dữ liệu phù hợp!" OnPageIndexChanging="m_grv_bao_cao_oto_PageIndexChanging">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:TemplateField HeaderStyle-Width="2%" ItemStyle-HorizontalAlign="center" HeaderText="STT">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="ĐƠN VỊ BỘ TỈNH" DataField="TEN_DV_BO_TINH" HeaderStyle-Width="6%" />
                                <asp:BoundField HeaderText="ĐƠN VỊ CHỦ QUẢN" DataField="TEN_DV_CHU_QUAN" HeaderStyle-Width="7%" />
                                <asp:BoundField HeaderText="ĐƠN VỊ SỬ DỤNG" DataField="TEN_DV_SU_DUNG" HeaderStyle-Width="6%" />
                                <asp:BoundField HeaderText="TÀI SẢN" ItemStyle-HorizontalAlign="left" DataField="TEN_TAI_SAN"
                                    HeaderStyle-Width="7%"></asp:BoundField>
                                <asp:TemplateField HeaderStyle-Width="6%" ItemStyle-HorizontalAlign="center">
                                    <HeaderTemplate>
                                        LOẠI XE
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <%# getTenLoaiTaiSan(Convert.ToDecimal(Eval("ID_LOAI_TAI_SAN"))) %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="NHÃN HIỆU" ItemStyle-HorizontalAlign="Center" DataField="NHAN_HIEU"
                                    HeaderStyle-Width="3%"></asp:BoundField>
                                <asp:BoundField HeaderText="BIỂN KIỂM SOÁT" ItemStyle-HorizontalAlign="Center" DataField="BIEN_KIEM_SOAT"
                                    HeaderStyle-Width="4%"></asp:BoundField>
                                <asp:BoundField HeaderText="SỐ CHỖ NGỒI/TẢI TRỌNG" ItemStyle-HorizontalAlign="Center"
                                    DataField="SO_CHO_NGOI" HeaderStyle-Width="3%"></asp:BoundField>
                                <asp:BoundField HeaderText="NƯỚC SẢN XUẤT" ItemStyle-HorizontalAlign="Center" DataField="NUOC_SAN_XUAT"
                                    HeaderStyle-Width="4%"></asp:BoundField>
                                <asp:BoundField HeaderText="NĂM SẢN XUẤT" ItemStyle-HorizontalAlign="Center" DataField="NAM_SAN_XUAT"
                                    HeaderStyle-Width="4%"></asp:BoundField>
                                <asp:BoundField HeaderText="NGÀY, THÁNG, NĂM SỬ DỤNG" ItemStyle-HorizontalAlign="Center"
                                    DataField="NAM_SU_DUNG" HeaderStyle-Width="3%"></asp:BoundField>
                                <asp:BoundField HeaderText="CÔNG SUẤT XE" ItemStyle-HorizontalAlign="Center" DataField="CONG_SUAT_XE"
                                    HeaderStyle-Width="3%"></asp:BoundField>
                                <asp:BoundField HeaderText="CHỨC DANH SỬ DỤNG XE" ItemStyle-HorizontalAlign="Center"
                                    DataField="CHUC_DANH_SU_DUNG" HeaderStyle-Width="4%"></asp:BoundField>
                                <asp:BoundField HeaderText="NGUỒN GỐC XE" ItemStyle-HorizontalAlign="Center" DataField="NGUON_GOC_XE"
                                    HeaderStyle-Width="4%"></asp:BoundField>
                                <asp:TemplateField HeaderStyle-Width="16%" HeaderStyle-Height="110px">
                                    <HeaderTemplate>
                                        <table border="1" cellspacing="0" cellpadding="2" width="100%" style="border-collapse: collapse;">
                                            <tr>
                                                <td colspan="3" style="height: 50px">
                                                    GIÁ TRỊ THEO SỔ KẾ TOÁN
                                                    <br />
                                                    (đồng)
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="height: 30px">
                                                    Nguyên giá
                                                </td>
                                                <td rowspan="2" style="height: 60px">
                                                    Giá trị còn lại
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 33.5%">
                                                    Nguồn NS
                                                </td>
                                                <td style="width: 33.5%;">
                                                    Nguồn khác
                                                </td>
                                            </tr>
                                        </table>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <table border="0" cellspacing="0" cellpadding="2" width="100%" style="border-collapse: collapse;">
                                            <tr>
                                                <td style="width: 33.5%; border-right: 1px solid gray;" align="right">
                                                    <%# Eval("NGUON_NS", "{0:#,###.00}")%>
                                                </td>
                                                <td style="width: 33.5%; border-right: 1px solid gray;" align="right">
                                                    <%# Eval("NGUON_KHAC", "{0:#,###.00}")%>
                                                </td>
                                                <td style="width: 33%; height: 50px" align="right">
                                                    <%# Eval("GIA_TRI_CON_LAI", "{0:#,###.00}")%>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderStyle-Width="15%" HeaderStyle-Height="110px">
                                    <HeaderTemplate>
                                        <table border="1" cellpadding="2" width="100%" style="border-collapse: collapse;">
                                            <tr>
                                                <td colspan="4" style="height: 50px">
                                                    HIỆN TRẠNG SỬ DỤNG
                                                    <br />
                                                    (chiếc)
                                                </td>
                                            </tr>
                                            <tr>
                                                <td rowspan="2" style="width: 25%; border-right: 1px solid gray; height: 60px">
                                                    QLNN
                                                </td>
                                                <td colspan="2" style="width: 50%; border-right: 1px solid gray; height: 30px">
                                                    HĐ Sự nghiệp
                                                </td>
                                                <td rowspan="2" style="width: 25%">
                                                    HĐ Khác
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 25%;">
                                                    Kinh doanh
                                                </td>
                                                <td style="width: 25%;">
                                                    Không KD
                                                </td>
                                            </tr>
                                        </table>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <table border="0" cellspacing="0" cellpadding="2" width="100%">
                                            <tr>
                                                <td style="width: 25%; border-right: 1px solid gray; height: 50px" align="right">
                                                    <%# Eval("QLNN") %>
                                                </td>
                                                <td style="width: 25%; border-right: 1px solid gray;" align="right">
                                                    <%# Eval("KINH_DOANH") %>
                                                </td>
                                                <td style="width: 25%; border-right: 1px solid gray;" align="right">
                                                    <%# Eval("KHONG_KINH_DOANH") %>
                                                </td>
                                                <td style="width: 25%" align="right">
                                                    <%# Eval("HD_KHAC") %>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="TRẠNG THÁI" DataField="TEN_TRANG_THAI" HeaderStyle-Width="4%"
                                    ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField HeaderText="TÌNH TRẠNG" DataField="TEN_TINH_TRANG" HeaderStyle-Width="2%"
                                    ItemStyle-HorizontalAlign="Center" />
                            </Columns>
                            <EditRowStyle BackColor="#7C6F57" />
                            <HeaderStyle BackColor="#810c15" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#E3EAEB" />
                            <SelectedRowStyle CssClass="cssSelectedRow" BackColor="#C5BBAF" Font-Bold="True"
                                ForeColor="#333333"></SelectedRowStyle>
                            <PagerSettings Position="TopAndBottom" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
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
