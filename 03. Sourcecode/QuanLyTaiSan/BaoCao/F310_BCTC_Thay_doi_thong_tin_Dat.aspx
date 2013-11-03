<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="F310_BCTC_Thay_doi_thong_tin_Dat.aspx.cs" Inherits="BaoCao_F310_BCTC_Thay_doi_thong_tin_Dat"
    EnableEventValidation="false" %>

<%@ Register Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"
    TagPrefix="asp" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table border="0" cellspacing="0" cellpadding="0" width="100%" class="cssTable">
                <tr>
                    <td class="cssPageTitleBG" colspan="6">
                        <span class="expand-collapse-text initial-expand"></span><span class="expand-collapse-text">
                        </span><span class="cssPageTitle">BÁO CÁO THAY ĐỔI THÔNG TIN ĐẤT</span>
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
                            TabIndex="2" OnSelectedIndexChanged="m_cbo_don_vi_chu_quan_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td style="width: 1%">
                    </td>
                </tr>
                <tr>
                    <td align="right" class="cssManField">
                        <span>Loại hình đơn vị:</span>
                    </td>
                    <td>
                        <asp:DropDownList ID="m_cbo_loai_hinh_don_vi" runat="Server" Width="90%" AutoPostBack="True"
                            OnSelectedIndexChanged="m_cbo_loai_hinh_don_vi_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td>
                    </td>
                    <td align="right">
                        <span class="cssManField">Đơn vị sử dụng tài sản:</span>
                    </td>
                    <td>
                        <asp:DropDownList ID="m_cbo_don_vi_su_dung_tai_san" Width="90%" runat="Server" AutoPostBack="True"
                            TabIndex="3" OnSelectedIndexChanged="m_cbo_don_vi_su_dung_tai_san_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span class="cssManField">Trạng thái:</span>
                    </td>
                    <td>
                        <asp:DropDownList ID="m_cbo_trang_thai" runat="Server" Width="90%" OnSelectedIndexChanged="m_cbo_trang_thai_SelectedIndexChanged"
                            AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                    <td>
                    </td>
                    <td align="right">
                        <span class="cssManField">Địa chỉ đất: </span>
                    </td>
                    <td>
                        <asp:DropDownList ID="m_cbo_dia_chi" runat="Server" Width="90%" TabIndex="4">
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
                        <ew:CalendarPopup ID="m_dat_tu_ngay" runat="server" ControlDisplay="TextBoxImage"
                            Culture="vi-VN" DisableTextboxEntry="true" GoToTodayText="Hôm nay: " ImageUrl="~/Images/cal.gif"
                            ShowGoToToday="true">
                            <WeekdayStyle BackColor="White" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Size="XX-Small"
                                ForeColor="Black" />
                            <WeekendStyle BackColor="LightGray" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Size="XX-Small"
                                ForeColor="Black" />
                            <OffMonthStyle BackColor="AntiqueWhite" Font-Names="Verdana,Helvetica,Tahoma,Arial"
                                Font-Size="XX-Small" ForeColor="Gray" />
                            <SelectedDateStyle BackColor="#007ccf" Font-Names="Verdana,Helvetica,Tahoma,Arial"
                                Font-Size="XX-Small" ForeColor="Black" />
                            <MonthHeaderStyle BackColor="#007ccf" Font-Names="Verdana,Helvetica,Tahoma,Arial"
                                Font-Size="XX-Small" ForeColor="Black" />
                            <DayHeaderStyle BackColor="AliceBlue" Font-Names="Verdana,Helvetica,Tahoma,Arial"
                                Font-Size="XX-Small" ForeColor="Black" />
                            <ClearDateStyle BackColor="White" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Size="XX-Small"
                                ForeColor="Black" />
                            <GoToTodayStyle BackColor="White" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Size="XX-Small"
                                ForeColor="Black" />
                            <TodayDayStyle BackColor="CadetBlue" Font-Names="Verdana,Helvetica,Tahoma,Arial"
                                Font-Size="XX-Small" ForeColor="Black" />
                        </ew:CalendarPopup>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td class="cssManField" align="right">
                        <span>Đến ngày:</span>
                    </td>
                    <td>
                        <ew:CalendarPopup ID="m_dat_den_ngay" runat="server" ControlDisplay="TextBoxImage"
                            Culture="vi-VN" DisableTextboxEntry="true" GoToTodayText="Hôm nay: " ImageUrl="~/Images/cal.gif"
                            ShowGoToToday="true">
                            <WeekdayStyle BackColor="White" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Size="XX-Small"
                                ForeColor="Black" />
                            <WeekendStyle BackColor="LightGray" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Size="XX-Small"
                                ForeColor="Black" />
                            <OffMonthStyle BackColor="AntiqueWhite" Font-Names="Verdana,Helvetica,Tahoma,Arial"
                                Font-Size="XX-Small" ForeColor="Gray" />
                            <SelectedDateStyle BackColor="#007ccf" Font-Names="Verdana,Helvetica,Tahoma,Arial"
                                Font-Size="XX-Small" ForeColor="Black" />
                            <MonthHeaderStyle BackColor="#007ccf" Font-Names="Verdana,Helvetica,Tahoma,Arial"
                                Font-Size="XX-Small" ForeColor="Black" />
                            <DayHeaderStyle BackColor="AliceBlue" Font-Names="Verdana,Helvetica,Tahoma,Arial"
                                Font-Size="XX-Small" ForeColor="Black" />
                            <ClearDateStyle BackColor="White" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Size="XX-Small"
                                ForeColor="Black" />
                            <GoToTodayStyle BackColor="White" Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Size="XX-Small"
                                ForeColor="Black" />
                            <TodayDayStyle BackColor="CadetBlue" Font-Names="Verdana,Helvetica,Tahoma,Arial"
                                Font-Size="XX-Small" ForeColor="Black" />
                        </ew:CalendarPopup>
                    </td>
                    <td>
                        &nbsp;
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
                            Width="98px" Text="Lọc dữ liệu(l)" Height="23px" TabIndex="5" OnClick="m_cmd_loc_du_lieu_Click" />
                        <asp:Button ID="m_cmd_xuat_excel" CausesValidation="False" AccessKey="x" CssClass="cssButton"
                            runat="server" Width="98px" Text="Xuất Excel (x)" Height="22px" OnClick="m_cmd_xuat_excel_Click" />
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
                        <asp:Label ID="m_lbl_title" runat="server" Text="THÔNG TIN THAY ĐỔI " CssClass="cssPageTitle"></asp:Label><span></span>
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
                <tr>
                    <td align="center" colspan="3" style="height: 450px;" valign="top">
                        <asp:GridView ID="m_grv_dat_history" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            Width="100%" DataKeyNames="ID" CellPadding="4" ForeColor="#333333" AllowSorting="True"
                            EmptyDataText="Không có dữ liệu phù hợp" PageSize="15" ShowHeader="true" OnPageIndexChanging="m_grv_dat_history_PageIndexChanging">
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
                                <asp:TemplateField HeaderStyle-Width="3%" ItemStyle-HorizontalAlign="center" HeaderText="STT">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="NGÀY CẬP NHẬT CUỐI" DataField="NGAY_CAP_NHAT_CUOI" ItemStyle-HorizontalAlign="center"
                                    HeaderStyle-Width="6%" />
                                <asp:BoundField HeaderText="LỊCH SỬ CẬP NHẬT" DataField="GHI_CHU_LICH_SU" ItemStyle-HorizontalAlign="center"
                                    HeaderStyle-Width="6%" />
                                <asp:BoundField HeaderText="ĐỊA CHỈ ĐẤT" DataField="DIA_CHI" HeaderStyle-Width="8%" />
                                <asp:BoundField HeaderText="MÃ TÀI SẢN" DataField="MA_TAI_SAN" HeaderStyle-Width="3%" />
                                <asp:BoundField HeaderText="ĐƠN VỊ SỬ DỤNG" DataField="TEN_DV_SU_DUNG" HeaderStyle-Width="7%" />
                                <asp:BoundField HeaderText="LOẠI HÌNH ĐƠN VỊ SỬ DỤNG" DataField="TEN_LOAI_HINH_DVSD"
                                    HeaderStyle-Width="5%" ItemStyle-HorizontalAlign="center" />
                                <asp:BoundField HeaderText="ĐƠN VỊ CHỦ QUẢN" DataField="TEN_DV_CHU_QUAN" HeaderStyle-Width="6%" />
                                <asp:BoundField HeaderText="ĐƠN VỊ BỘ TỈNH" DataField="TEN_DV_BO_TINH" HeaderStyle-Width="6%" />
                                <asp:BoundField HtmlEncode="false" HeaderText="DIỆN TÍCH KHUÔN VIÊN <br/> (m2)" DataField="DT_KHUON_VIEN"
                                    ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}" HeaderStyle-Width="4%" />
                                <asp:BoundField HeaderText="DIỆN TÍCH TRỤ SỞ LÀM VIỆC <br/>(m2)" HtmlEncode="false"
                                    DataField="DT_TRU_SO_LAM_VIEC" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}"
                                    HeaderStyle-Width="4%" />
                                <asp:BoundField HeaderText="DIỆN TÍCH CƠ SỞ HĐSN <br/> (m2)" HtmlEncode="false" DataField="DT_CO_SO_HOAT_DONG_SU_NGHIEP"
                                    ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}" HeaderStyle-Width="4%" />
                                <asp:BoundField HeaderText="DIỆN TÍCH LÀM NHÀ Ở <br/> (m2)" HtmlEncode="false" DataField="DT_LAM_NHA_O"
                                    ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}" HeaderStyle-Width="4%" />
                                <asp:BoundField HeaderText="DIỆN TÍCH CHO THUÊ <br/> (m2)" HtmlEncode="false" DataField="DT_CHO_THUE"
                                    ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}" HeaderStyle-Width="4%" />
                                <asp:BoundField HeaderText="DIỆN TÍCH BỎ TRỐNG <br/> (m2)" HtmlEncode="false" DataField="DT_BO_TRONG"
                                    ItemStyle-HorizontalAlign="right" HeaderStyle-Width="4%" DataFormatString="{0:#,##0.00}" />
                                <asp:BoundField HeaderText="DIỆN TÍCH BỊ LẤN CHIẾM  <br/> (m2)" HtmlEncode="false"
                                    DataField="DT_BI_LAN_CHIEM" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}"
                                    HeaderStyle-Width="4%" />
                                <asp:BoundField HeaderText="DIỆN TÍCH SỬ DỤNG VÀO MỤC ĐÍCH KHÁC <br/> (m2)" HtmlEncode="false"
                                    DataField="DT_SU_DUNG_MUC_DICH_KHAC" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}"
                                    HeaderStyle-Width="4%" />
                                <asp:BoundField HeaderText="GIÁ TRỊ THEO SỔ KẾ TOÁN <br/> (VNĐ)" HtmlEncode="false"
                                    DataField="GT_THEO_SO_KE_TOAN" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0.00}"
                                    HeaderStyle-Width="4%" />
                                <asp:BoundField HeaderText="SỐ NĂM ĐÃ SỬ DỤNG" DataField="SO_NAM_DA_SU_DUNG" ItemStyle-HorizontalAlign="Right"
                                    HeaderStyle-Width="4%" />
                            </Columns>
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
