<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="F108_DuyetGhiTangGiamOto.aspx.cs" Inherits="ChucNang_F108_DuyetGhiTangGiamOto" %>

<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<%@ Register Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"
    TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table cellspacing="0" cellpadding="2" style="width: 99%;" class="cssTable" border="0">
                <tr>
                    <td class="cssPageTitleBG" colspan="4">
                        <asp:Label ID="m_lbl_caption" runat="server" Text="" CssClass="cssPageTitle"></asp:Label>
                        <span class="expand-collapse-text"></span>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:Label ID="m_lbl_message" runat="server" Text="" CssClass="cssManField"></asp:Label>
                        <asp:ValidationSummary ID="vdsCategory" runat="server" CssClass="cssManField" Font-Bold="true" />
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 20%;">
                        &nbsp;
                    </td>
                    <td align="left" colspan="1" style="width: 30%">
                        &nbsp;
                    </td>
                    <td align="right" colspan="1" style="width: 20%">
                        &nbsp;
                    </td>
                    <td align="left" colspan="1" style="width: 30%">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 20%;" class="cssManField">
                        <span>Bộ, tỉnh</span>
                    </td>
                    <td align="left" colspan="1" style="width: 30%">
                        <asp:DropDownList ID="m_cbo_bo_tinh_up" runat="server" Width="85%" AutoPostBack="True"
                            OnSelectedIndexChanged="m_cbo_bo_tinh_up_SelectedIndexChanged" ValidationGroup="m_vlg_oto">
                        </asp:DropDownList>
                    </td>
                    <td align="right" colspan="1" class="cssManField" style="width: 20%">
                        <span>Đơn vị chủ quản</span>
                    </td>
                    <td align="left" style="width: 30%" colspan="1">
                        <asp:DropDownList ID="m_cbo_don_vi_chu_quan_up" runat="server" Width="85%" AutoPostBack="True"
                            OnSelectedIndexChanged="m_cbo_don_vi_chu_quan_up_SelectedIndexChanged" ValidationGroup="m_vlg_oto">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="cssManField" style="width: 20%;">
                        <span>Đơn vị sử dụng tài sản</span>
                    </td>
                    <td align="left" colspan="1" style="width: 30%">
                        <asp:DropDownList ID="m_cbo_don_vi_su_dung_tai_san_up" runat="server" Width="85%"
                            AutoPostBack="true" OnSelectedIndexChanged="m_cbo_don_vi_su_dung_tai_san_up_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td align="right" colspan="1" class="cssManField" style="width: 20%">
                        <span>Trạng thái ô tô</span>
                    </td>
                    <td align="left" style="width: 30%">
                        <asp:DropDownList ID="m_cbo_trang_thai_o_to_up" runat="server" Width="85%" ValidationGroup="m_vlg_oto"
                            Enabled="false" AutoPostBack="true" OnSelectedIndexChanged="m_cbo_trang_thai_o_to_up_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="cssManField">
                        <span>Loại ô tô</span>
                    </td>
                    <td>
                        <asp:DropDownList ID="m_cbo_loai_o_to_up" runat="Server" Width="85%" AutoPostBack="true"
                            OnSelectedIndexChanged="m_cbo_loai_o_to_up_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td align="right" style="width: 20%;" class="cssManField">
                        <span>Tên tài sản</span>
                    </td>
                    <td align="left" colspan="1" style="width: 30%">
                        <asp:DropDownList ID="m_cbo_ten_tai_san" runat="server" Width="85%" AutoPostBack="true"
                            OnSelectedIndexChanged="m_cbo_ten_tai_san_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="cssManField" colspan="1" style="width: 20%">
                        <span>Mã tài sản</span>
                    </td>
                    <td align="left" style="width: 30%">
                        <asp:Label ID="m_lbl_ma_tai_san" runat="Server" class="cssManField" Style="color: blue"></asp:Label>
                    </td>
                    <td align="right" class="cssManField" style="width: 20%;">
                        <span>Nhãn hiệu</span>
                    </td>
                    <td align="left" colspan="1" style="width: 30%">
                        <asp:Label ID="m_lbl_nhan_hieu" runat="server" class="cssManField" Style="color: blue"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" colspan="1" class="cssManField" style="width: 20%">
                        <span>Biển kiểm soát</span>
                    </td>
                    <td align="left" style="width: 30%">
                        <asp:Label ID="m_lbl_bien_kiem_soat" runat="Server" class="cssManField" Style="color: blue"></asp:Label>
                    </td>
                    <td align="right" colspan="1" class="cssManField" style="width: 20%">
                        <span>Chức danh sử dụng</span>
                    </td>
                    <td align="left" style="width: 30%">
                        <asp:Label ID="m_lbl_chuc_dang_su_dung" runat="Server" class="cssManField" Style="color: blue"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="cssManField" style="width: 20%;">
                        <span>Nước sản xuất</span>
                    </td>
                    <td align="left" colspan="1" style="width: 30%">
                        <asp:Label ID="m_lbl_nuoc_san_xuat" runat="Server" class="cssManField" Style="color: blue"></asp:Label>
                    </td>
                    <td align="right" class="cssManField" colspan="1" style="width: 20%">
                        <span>Năm sản xuất</span>
                    </td>
                    <td align="left" style="width: 30%">
                        <asp:Label ID="m_lbl_nam_san_xuat" runat="Server" class="cssManField" Style="color: blue"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" class="cssManField" style="width: 20%;">
                        <span>Năm sử dụng</span>
                    </td>
                    <td align="left" colspan="1" style="width: 30%">
                        <asp:Label ID="m_lbl_nam_su_dung" runat="Server" class="cssManField" Style="color: blue"></asp:Label>
                    </td>
                    <td align="right" colspan="1" style="width: 20%">
                        &nbsp;
                    </td>
                    <td align="left" style="width: 30%">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 20%;">
                        &nbsp;
                    </td>
                    <td class="cssManField" align="center" colspan="1" style="width: 30%">
                        <span>GIÁ TRỊ THEO SỔ KẾ TOÁN</span>
                    </td>
                    <td align="right" colspan="1" style="width: 20%">
                        &nbsp;
                    </td>
                    <td align="left" style="width: 30%">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="right" class="cssManField" style="width: 20%;">
                        <span>Nguyên giá Nguồn NS (VNĐ)</span>
                    </td>
                    <td colspan="1" style="width: 30%" class="cssManField" style="color: blue">
                        <asp:Label ID="m_lbl_nguyen_gia_nguon_ns" runat="Server" ForeColor="Blue"></asp:Label>
                    </td>
                    <td align="right" colspan="1" class="cssManField" style="width: 20%">
                        <span>Nguyên giá Nguồn khác (VNĐ)</span>
                    </td>
                    <td>
                        <asp:Label ID="m_lbl_nguyen_gia_nguon_khac" runat="Server" class="cssManField" Style="color: blue"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 20%;" class="cssManField">
                        <span>Giá trị còn lại (VNĐ)</span>
                    </td>
                    <td colspan="1" style="width: 30%">
                        <asp:Label ID="m_lbl_gia_tri_con_lai" runat="Server" class="cssManField" Style="color: blue"></asp:Label>
                    </td>
                    <td align="right" colspan="1" style="width: 20%">
                        &nbsp;
                    </td>
                    <td align="left" style="width: 30%">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <span class="cssManField">CHI TIẾT DUYỆT GHI TĂNG GIẢM</span>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span class="cssManField">Lý do</span>
                    </td>
                    <td>
                        <asp:DropDownList ID="m_cbo_ly_do_thay_doi" Width="85%" runat="server" AutoPostBack="true"
                            OnSelectedIndexChanged="m_cbo_ly_do_thay_doi_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td align="right">
                        <span class="cssManField">Loại đề nghị</span>
                    </td>
                    <td>
                        <asp:RadioButtonList ID="m_rbl_loai" runat="server" RepeatDirection="Horizontal"
                            Enabled="false" CssClass="cssManField">
                            <asp:ListItem Value="Y" Selected="True">Duyệt ghi tăng</asp:ListItem>
                            <asp:ListItem Value="N">Duyệt ghi giảm</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 15%">
                        <span class="cssManField">Mã phiếu</span>
                    </td>
                    <td align="left" style="width: 30%">
                        <asp:TextBox ID="m_txt_ma_phieu" runat="server" CssClass="cssTextBox" Width="85%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="m_rfv_ma_phieu" runat="server" ErrorMessage="Bạn phải nhập Mã phiếu"
                            Text="*" ControlToValidate="m_txt_ma_phieu"></asp:RequiredFieldValidator>
                    </td>
                    <td align="right" style="width: 15%">
                        <asp:Label ID="m_lbl_ten_don_vi_nhan_dieu_chuyen" runat="server" 
                            CssClass="cssManField" Text="Đơn vị nhận điều chuyển"></asp:Label>
                    </td>
                    <td align="left" style="width: 30%">
                        <asp:TextBox ID="m_txt_don_vi_nhan_dieu_chuyen" runat="server" Width="85%"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 15%">
                        <span class="cssManField">Ngày duyệt</span>
                    </td>
                    <td align="left" style="width: 30%">
                        <ew:CalendarPopup ID="m_dat_ngay_duyet" runat="server" ControlDisplay="TextBoxImage"
                            Culture="vi-VN" GoToTodayText="Hôm nay: " ShowGoToToday="true" DisableTextBoxEntry="true"
                            ImageUrl="~/Images/cal.gif">
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
                    <td align="right" style="width: 15%">
                        <span class="cssManField">Ngày giảm tài sản</span>
                    </td>
                    <td>
                        <ew:CalendarPopup ID="m_dat_ngay_tang_giam" runat="server" 
                            ControlDisplay="TextBoxImage" Culture="vi-VN" DisableTextBoxEntry="true" 
                            GoToTodayText="Hôm nay: " ImageUrl="~/Images/cal.gif" ShowGoToToday="true">
                            <WeekdayStyle BackColor="White" Font-Names="Verdana,Helvetica,Tahoma,Arial" 
                                Font-Size="XX-Small" ForeColor="Black" />
                            <WeekendStyle BackColor="LightGray" Font-Names="Verdana,Helvetica,Tahoma,Arial" 
                                Font-Size="XX-Small" ForeColor="Black" />
                            <OffMonthStyle BackColor="AntiqueWhite" 
                                Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Size="XX-Small" 
                                ForeColor="Gray" />
                            <SelectedDateStyle BackColor="#007ccf" 
                                Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Size="XX-Small" 
                                ForeColor="Black" />
                            <MonthHeaderStyle BackColor="#007ccf" 
                                Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Size="XX-Small" 
                                ForeColor="Black" />
                            <DayHeaderStyle BackColor="AliceBlue" 
                                Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Size="XX-Small" 
                                ForeColor="Black" />
                            <ClearDateStyle BackColor="White" Font-Names="Verdana,Helvetica,Tahoma,Arial" 
                                Font-Size="XX-Small" ForeColor="Black" />
                            <GoToTodayStyle BackColor="White" Font-Names="Verdana,Helvetica,Tahoma,Arial" 
                                Font-Size="XX-Small" ForeColor="Black" />
                            <TodayDayStyle BackColor="CadetBlue" 
                                Font-Names="Verdana,Helvetica,Tahoma,Arial" Font-Size="XX-Small" 
                                ForeColor="Black" />
                        </ew:CalendarPopup>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <br />
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="center">
                        <asp:Button ID="m_cmd_tao_moi" AccessKey="c" CssClass="cssButton" runat="server"
                            Height="24px" Width="98px" Text="Tạo mới(c)" OnClick="m_cmd_tao_moi_Click" />
                        <asp:Button ID="m_cmd_xoa_trang" AccessKey="r" CssClass="cssButton" runat="server"
                            CausesValidation="false" Height="24px" Width="98px" Text="Xóa trắng(r)" OnClick="m_cmd_xoa_trang_Click" />
                        <asp:HiddenField ID="m_hdf_id" runat="server" Value="" OnValueChanged="m_hdf_id_ValueChanged" />
                    </td>
                </tr>
            </table>
            <table cellspacing="0" cellpadding="2" style="width: 99%;" class="cssTable" border="0">
                <tr>
                    <td class="cssPageTitleBG" colspan="4">
                        <asp:Label ID="m_lbl_thong_tin" runat="server" Text="DANH SÁCH DUYỆT GHI TĂNG GIẢM TÀI SẢN Ô TÔ"
                            CssClass="cssPageTitle"></asp:Label>
                        <span class="expand-collapse-text initial-expand"></span><span class="expand-collapse-text">
                        </span>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 20%">
                        <span class="cssManField">Bộ, tỉnh</span>
                    </td>
                    <td style="width: 30%" align="left">
                        <asp:DropDownList ID="m_cbo_bo_tinh_down" runat="server" Width="85%" AutoPostBack="True"
                            OnSelectedIndexChanged="m_cbo_bo_tinh_down_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td align="right" style="width: 20%">
                        <span class="cssManField">Đơn vị chủ quản</span>
                    </td>
                    <td align="left" style="width: 30%;">
                        <asp:DropDownList ID="m_cbo_don_vi_chu_quan_down" runat="server" Width="85%" AutoPostBack="True"
                            OnSelectedIndexChanged="m_cbo_don_vi_chu_quan_down_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 20%" colspan="1">
                        <span class="cssManField">Đơn vị sử dụng tài sản</span>
                    </td>
                    <td style="width: 30%" align="left" colspan="1">
                        <asp:DropDownList ID="m_cbo_don_vi_su_dung_tai_san_down" runat="server" Width="85%"
                            ValidationGroup="m_vlg_oto">
                        </asp:DropDownList>
                    </td>
                    <td colspan="1" align="right" style="width: 20%">
                        <span class="cssManField">Trạng thái ô tô</span>
                    </td>
                    <td align="left" colspan="1" style="width: 30%;">
                        <asp:DropDownList ID="m_cbo_trang_thai_o_to_down" runat="server" Width="85%" AutoPostBack="true"
                            OnSelectedIndexChanged="m_cbo_trang_thai_o_to_down_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span class="cssManField">Từ khóa </span>
                    </td>
                    <td>
                        <asp:TextBox ID="m_txt_tu_khoa" runat="server" CssClass="cssTextBox" AutoPostBack="true"
                            Width="85%" OnTextChanged="m_txt_tu_khoa_TextChanged"> </asp:TextBox>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="m_cmd_tim_kiem" runat="server" AccessKey="s" CssClass="cssButton"
                            Height="24px" Text="Tìm kiếm" Width="98px" OnClick="m_cmd_tim_kiem_Click" CausesValidation="false" />
                        &nbsp;
                        <asp:Button ID="m_cmd_xuat_excel" runat="server" CausesValidation="False" CssClass="cssButton"
                            Height="25px" Text="Xuất Excel" Width="98px" OnClick="m_cmd_xuat_excel_Click" />
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:GridView ID="m_grv_danh_sach_oto" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            Width="100%" DataKeyNames="ID" CellPadding="0" ForeColor="#333333" AllowSorting="True"
                            EmptyDataText="Không có dữ liệu phù hợp" PageSize="30" ShowHeader="true" OnPageIndexChanging="m_grv_danh_sach_oto_PageIndexChanging"
                            OnRowCommand="m_grv_danh_sach_oto_RowCommand" CssClass="cssGrid">
                            <Columns>
                                <asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center" HeaderStyle-Height="30px"
                                    ItemStyle-Height="30px">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Mã phiếu" DataField="MA_PHIEU" />
                                <asp:BoundField HeaderText="Tên tài sản" DataField="TEN_TAI_SAN" />
                                <asp:BoundField HeaderText="Đơn vị sử dụng" DataField="TEN_DV_SU_DUNG" />
                                <asp:BoundField HeaderText="Số lượng" DataField="DIEN_TICH" ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundField HeaderText="Lý do tăng giảm" DataField="LY_DO_TANG_GIAM_TAI_SAN"
                                    ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField HeaderText="Giá trị nguyên giá tăng giảm" DataField="GIA_TRI_NGUYEN_GIA_TANG_GIAM"
                                    DataFormatString="{0:#,##0.00}" ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundField HeaderText="Ngày tăng giảm tài sản" DataField="NGAY_TANG_GIAM_TAI_SAN" />
                                <asp:BoundField HeaderText="Ngày duyệt" DataField="NGAY_DUYET" />
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
