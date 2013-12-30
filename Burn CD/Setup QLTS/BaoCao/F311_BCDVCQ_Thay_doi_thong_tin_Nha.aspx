<%@ page title="" language="C#" masterpagefile="~/Site.master" autoeventwireup="true" enableeventvalidation="false" inherits="BaoCao_F311_BCDVCQ_Thay_doi_thong_tin_Nha, App_Web_lvrqyice" %>

<%@ Register Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"
    TagPrefix="asp" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
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
                            <span class="expand-collapse-text initial-expand"></span><span class="expand-collapse-text">
                            </span><span class="cssPageTitle">BÁO CÁO THAY ĐỔI THÔNG TIN NHÀ</span>
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
                        <td align="right">
                            &nbsp;&nbsp;<span class="cssManField">Loại hình đơn vị:</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="m_cbo_loai_hinh_don_vi" runat="Server" AutoPostBack="True"
                                OnSelectedIndexChanged="m_cbo_loai_hinh_don_vi_SelectedIndexChanged" Width="90%">
                            </asp:DropDownList>
                        </td>
                        <td>
                        </td>
                        <td align="right">
                            <span class="cssManField">Đơn vị sử dụng tài sản:</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="m_cbo_don_vi_su_dung_tai_san" runat="Server" AutoPostBack="True"
                                TabIndex="3" Width="90%" OnSelectedIndexChanged="m_cbo_don_vi_su_dung_tai_san_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            &nbsp;<span class="cssManField">Trạng thái: </span>
                        </td>
                        <td>
                            <asp:DropDownList ID="m_cbo_trang_thai" runat="Server" Width="90%">
                            </asp:DropDownList>
                        </td>
                        <td>
                        </td>
                        <td align="right">
                            <span class="cssManField">&nbsp;Địa chỉ đất: </span>
                        </td>
                        <td>
                            <asp:DropDownList ID="m_cbo_dia_chi" runat="Server" TabIndex="4" Width="90%">
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
                            <asp:TextBox ID="m_txt_tim_kiem" runat="Server" Width="95%" CssClass="cssTextBox"></asp:TextBox>
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
                                Width="98px" Text="Lọc dữ liệu(l)" Height="23px" TabIndex="5" OnClick="m_cmd_tim_kiem_Click" />
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
                <table cellspacing="0" cellpadding="2" style="width: 100%;" class="cssTable" border="0">
                    <tr>
                        <td class="cssPageTitleBG" colspan="6">
                            <asp:Label ID="m_lbl_title" runat="server" Text="THÔNG TIN THAY ĐỔI" CssClass="cssPageTitle"></asp:Label><span
                                class="expand-collapse-text initial-expand"> </span><span class="expand-collapse-text">
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
                        <td align="center" colspan="3" style="height: 450px;" valign="top">
                            <asp:GridView ID="m_grv_nha_history" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                Width="100%" DataKeyNames="ID" CellPadding="4" ForeColor="#333333" AllowSorting="True"
                                EmptyDataText="Không có dữ liệu phù hợp" PageSize="15" ShowHeader="true" OnPageIndexChanging="m_grv_nha_history_PageIndexChanging">
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
                                    <asp:TemplateField HeaderStyle-Width="2%" ItemStyle-HorizontalAlign="center" HeaderText="STT">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="NGÀY CẬP NHẬT CUỐI" DataField="NGAY_CAP_NHAT_CUOI" ItemStyle-HorizontalAlign="right" />
                                    <asp:BoundField HeaderText="LỊCH SỬ CẬP NHẬT" DataField="GHI_CHU_LICH_SU" ItemStyle-HorizontalAlign="left" />
                                    <asp:BoundField HeaderText="ĐƠN VỊ THAY ĐỔI" DataField="USER_GROUP_NAME" />
                                    <asp:BoundField HeaderText="ĐƠN VỊ BỘ TỈNH" DataField="TEN_DV_BO_TINH" />
                                    <asp:BoundField HeaderText="ĐƠN VỊ CHỦ QUẢN" DataField="TEN_DV_CHU_QUAN" />
                                    <asp:BoundField HeaderText="ĐƠN VỊ SỬ DỤNG" DataField="TEN_DV_SU_DUNG" />
                                    <asp:BoundField HeaderText="TRẠNG THÁI" DataField="TEN_TRANG_THAI" />
                                    <asp:BoundField HeaderText="TÊN TÀI SẢN" DataField="TEN_TAI_SAN" />
                                    <asp:BoundField HeaderText="MÃ TÀI SẢN" DataField="MA_TAI_SAN" />
                                    <asp:BoundField HeaderText="CẤP HẠNG" DataField="CAP_HANG" />
                                    <asp:BoundField HeaderText="SỐ TẦNG" DataField="SO_TANG" />
                                    <asp:BoundField HeaderText="NĂM SỬ DỤNG" DataField="NGAY_THANG_NAM_SU_DUNG" />
                                    <asp:BoundField HeaderText="NĂM XÂY DỰNG" DataField="NAM_XAY_DUNG" />
                                    <asp:BoundField HtmlEncode="false" HeaderText="DIỆN TÍC XÂY DỰNG <br/> (m2)" DataField="DT_XAY_DUNG"
                                        ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,###}" />
                                    <asp:BoundField HeaderText="TỔNG DIỆN TÍCH SÀN XÂY DỰNG <br/>(m2)" HtmlEncode="false"
                                        DataField="TONG_DT_SAN_XD" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,###}" />
                                    <asp:BoundField HeaderText="NGUỒN NGÂN SÁCH <br/> (ngàn đồng)" HtmlEncode="false"
                                        DataField="NGUON_NS" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,###}" />
                                    <asp:BoundField HeaderText="NGUỒN KHÁC <br/> (ngàn đồng)" HtmlEncode="false" DataField="NGUON_KHAC"
                                        ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,###}" />
                                    <asp:BoundField HeaderText="GIÁ TRỊ CÒN LẠI <br/> (ngàn đồng)" HtmlEncode="false"
                                        DataField="GIA_TRI_CON_LAI" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,###}" />
                                    <asp:BoundField HeaderText="DIỆN TÍCH TRỤ SỞ LÀM VIỆC <br/> (m2)" HtmlEncode="false"
                                        DataField="TRU_SO_LAM_VIEC" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,###}" />
                                    <asp:BoundField HeaderText="DIỆN TÍCH CƠ SỞ HĐSN <br/> (m2)" HtmlEncode="false" DataField="CO_SO_HDSN"
                                        ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,###}" />
                                    <asp:BoundField HeaderText="DIỆN TÍCH LÀM NHÀ Ở <br/> (m2)" HtmlEncode="false" DataField="LAM_NHA_O"
                                        ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,###}" />
                                    <asp:BoundField HeaderText="DIỆN TÍCH CHO THUÊ <br/> (m2)" HtmlEncode="false" DataField="CHO_THUE"
                                        ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,###}" />
                                    <asp:BoundField HeaderText="DIỆN TÍCH BỎ TRỐNG <br/> (m2)" HtmlEncode="false" DataField="BO_TRONG" />
                                    <asp:BoundField HeaderText="DIỆN TÍCH BỊ LẤN CHIẾM  <br/> (m2)" HtmlEncode="false"
                                        DataField="BI_LAN_CHIEM" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,###}" />
                                    <asp:BoundField HeaderText="DIỆN TÍCH SỬ DỤNG VÀO MỤC ĐÍCH KHÁC <br/> (m2)" HtmlEncode="false"
                                        DataField="KHAC" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,###}" />
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
