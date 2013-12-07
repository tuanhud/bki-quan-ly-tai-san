<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="F103_KhauHaoOto.aspx.cs" Inherits="ChucNang_F103_KhauHaoOto" %>

<%@ Register Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"
    TagPrefix="asp" %>
<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script type="text/javascript">
        $(function () {
            $(".tb").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "../ChucNang/PersonService.asmx/GetOto",
                        data: "{ 'name_prefix': '" + request.term + "', 'ip_dc_id_dv_su_dung': '"
                        + document.getElementById('<%= m_cbo_don_vi_su_dung_tai_san_up.ClientID%>').value + "' }",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    value: item.strTEN_TAI_SAN,
                                    dcID: item.dcID
                                }
                            }))
                        },
                        error: function (XMLHttpRequest, textStatus, errorThrown) {
                            alert(textStatus);
                        }
                    });
                },
                minLength: 1,
                select: function (event, ui) {
                    document.getElementById("<%= m_hdf_id.ClientID%>").value = ui.item.dcID;
                    console.log(ui.item.dcID);
                }
            });
        });
    </script>
    <script type="text/javascript">
        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table cellspacing="0" cellpadding="2" style="width: 99%;" class="cssTable" border="0">
                <!--  Quan ly oto  -->
                <tr>
                    <td class="cssPageTitleBG" colspan="4">
                        <asp:Label ID="m_lbl_title" runat="server" CssClass="cssPageTitle" Text="HAO MÒN TÀI SẢN Ô TÔ" />
                        <span class="expand-collapse-text initial-expand"></span><span class="expand-collapse-text">
                        </span>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:Label ID="m_lbl_message" runat="server" Text="" CssClass="cssManField"></asp:Label>
                        <asp:ValidationSummary ID="vdsCategory" runat="server" CssClass="cssManField" Font-Bold="true"
                            ValidationGroup="m_vlg_oto" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <table cellspacing="0" cellpadding="2" style="width: 100%;" class="cssTable" border="0">
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
                                <td align="left" class="style1" style="width: 30%" colspan="1">
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
                                <td align="left" class="style1" style="width: 30%">
                                    <asp:DropDownList ID="m_cbo_trang_thai_o_to_up" runat="server" Width="85%" ValidationGroup="m_vlg_oto"
                                        Enabled="False">
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
                                <td align="left" class="style1" style="width: 30%">
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
                                <td align="left" class="style1" style="width: 30%">
                                    <asp:Label ID="m_lbl_bien_kiem_soat" runat="Server" class="cssManField" Style="color: blue"></asp:Label>
                                </td>
                                <td align="right" colspan="1" class="cssManField" style="width: 20%">
                                    <span>Chức danh sử dụng</span>
                                </td>
                                <td align="left" class="style1" style="width: 30%">
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
                                <td align="left" class="style1" style="width: 30%">
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
                                <td align="left" class="style1" style="width: 30%">
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
                                <td align="left" class="style1" style="width: 30%">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="cssManField" style="width: 20%;">
                                    <span>Nguyên giá Nguồn NS (ngàn đồng)</span>
                                </td>
                                <td colspan="1" style="width: 30%" class="cssManField" style="color: blue">
                                    <asp:Label ID="m_lbl_nguyen_gia_nguon_ns" runat="Server" ForeColor="Blue"></asp:Label>
                                </td>
                                <td align="right" colspan="1" class="cssManField" style="width: 20%">
                                    <span>Nguyên giá Nguồn khác (ngàn đồng)</span>
                                </td>
                                <td>
                                    <asp:Label ID="m_lbl_nguyen_gia_nguon_khac" runat="Server" class="cssManField" Style="color: blue"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 20%;" class="cssManField">
                                    <span>Giá trị còn lại (ngàn đồng)</span>
                                </td>
                                <td colspan="1" style="width: 30%">
                                    <asp:Label ID="m_lbl_gia_tri_con_lai" runat="Server" class="cssManField" Style="color: blue"></asp:Label>
                                </td>
                                <td align="right" colspan="1" style="width: 20%">
                                    &nbsp;
                                </td>
                                <td align="left" class="style1" style="width: 30%">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="right" colspan="1" style="width: 20%">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td class="cssManField" align="center">
                                    <span>CHI TIẾT HAO MÒN TÀI SẢN</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="cssManField" align="right" colspan="1" style="width: 20%">
                                    <span>Mã phiếu *</span>
                                </td>
                                <td colspan="1" style="width: 29%">
                                    <asp:TextBox ID="m_txt_ma_phieu" runat="server" CssClass="cssTextBox" Width="85%"
                                        ValidationGroup="m_vlg_oto"> </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="m_rfv_ma_phieu" runat="server" ControlToValidate="m_txt_ma_phieu"
                                        ErrorMessage="Bạn phải nhập Mã Phiếu" Text="*" ValidationGroup="m_vlg_oto"
                                        ForeColor="Red"> </asp:RequiredFieldValidator>
                                </td>
                                <td colspan="1" style="width: 20%" align="right" class="cssManField">
                                    <span>Giá trị hao mòn (ngàn đồng) *</span>
                                </td>
                                <td>
                                    <asp:TextBox ID="m_txt_gia_tri_khau_hao" runat="server" CssClass="cssTextBox csscurrency"
                                        Width="85%" ValidationGroup="m_vlg_oto"> </asp:TextBox>
                                    <asp:RequiredFieldValidator ID="m_rfv_gia_tri_khau_hao" runat="server" ControlToValidate="m_txt_gia_tri_khau_hao"
                                        ErrorMessage="Bạn phải nhập Giá Trị hao mòn" Text="*" ValidationGroup="m_vlg_oto"
                                        ForeColor="Red"> </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="1" align="right" class="cssManField">
                                    <span>Ngày lập </span>
                                </td>
                                <td style="width: 29%" align="left">
                                    <ew:CalendarPopup ID="m_dat_ngay_lap" runat="server" ControlDisplay="TextBoxImage"
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
                                <td align="right" class="cssManField">
                                    <span>Ngày duyệt </span>
                                </td>
                                <td style="width: 29%" align="left">
                                    <ew:CalendarPopup ID="m_dat_ngay_duyet" runat="server" ControlDisplay="TextBoxImage"
                                        Culture="vi-VN" GoToTodayText="Hôm nay: " ShowGoToToday="true" DisableTextboxEntry="true"
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
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td colspan="4" align="left">
                                    <asp:Button ID="m_cmd_tao_moi" AccessKey="c" CssClass="cssButton" runat="server"
                                        Height="24px" Width="98px" Text="Tạo mới(c)" ValidationGroup="m_vlg_oto" OnClick="m_cmd_tao_moi_Click" />
                                    <asp:Button ID="m_cmd_xoa_trang" AccessKey="r" CssClass="cssButton" runat="server"
                                        CausesValidation="false" Height="24px" Width="98px" Text="Xóa trắng(r)" OnClick="m_cmd_xoa_trang_Click" />
                                    <asp:HiddenField ID="m_hdf_id" runat="server" Value="" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <!-- End Quan ly oto   -->
                <!-- Ket qua loc du lieu  -->
            </table>
            <table cellspacing="0" cellpadding="2" style="width: 99%;" class="cssTable" border="0">
                <tr>
                    <td class="cssPageTitleBG" colspan="4">
                        <asp:Label ID="m_lbl_thong_tin_khau_hao" runat="Server" class="cssPageTitle" Text="DANH SÁCH CÁC LẦN HAO MÒN TÀI SẢN Ô TÔ"></asp:Label>
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
                            ValidationGroup="m_vlg_oto" AutoPostBack="true" OnSelectedIndexChanged="m_cbo_don_vi_su_dung_tai_san_down_SelectedIndexChanged">
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
                            Height="24px" Text="Tìm kiếm" Width="98px" OnClick="m_cmd_tim_kiem_Click" />
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
                    <td align="center" colspan="4" style="height: 450px;" valign="top">
                        <asp:GridView ID="m_grv_dm_oto" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            CssClass="cssGrid" Width="100%" DataKeyNames="ID_KH" CellPadding="0" ForeColor="#333333"
                            AllowSorting="True" PageSize="30" ShowHeader="true" OnRowCommand="m_grv_dm_oto_RowCommand"
                            EmptyDataText="Không có dữ liệu phù hợp">
                            <Columns>
                                <asp:TemplateField HeaderText="Xóa" ItemStyle-Width="2%">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="m_lbt_delete" runat="server" CommandName="DeleteComp" ToolTip="Xóa"
                                            OnClientClick="return confirm ('Bạn có thực sự muốn xóa bản ghi này?')" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'>
                     <img src="../Images/Button/deletered.png" alt="Delete" />
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Mã phiếu" DataField="MA_PHIEU" />
                                <asp:BoundField HeaderText="Tên tài sản" DataField="TEN_TAI_SAN" />
                                <asp:BoundField HeaderText="Mã tài sản" DataField="MA_TAI_SAN" />
                                <asp:BoundField HeaderText="Đơn vị sử dụng" DataField="TEN_DV_SU_DUNG" />
                                <asp:BoundField HeaderText="Nhãn hiệu" DataField="NHAN_HIEU" />
                                <asp:BoundField HeaderText="Biển kiểm soát" DataField="BIEN_KIEM_SOAT" />
                                <asp:BoundField HeaderText="Chức danh sử dụng" DataField="CHUC_DANH_SU_DUNG" />
                                <asp:BoundField HeaderText="Nguồn gốc xe" DataField="NGUON_GOC_XE" />
                                <asp:BoundField HeaderText="Nước sản xuất" DataField="NUOC_SAN_XUAT" />
                                <asp:BoundField HeaderText="Năm sản xuất" DataField="NAM_SAN_XUAT" />
                                <asp:BoundField HeaderText="Năm sử dụng" DataField="NAM_SU_DUNG" />
                                <asp:TemplateField HeaderStyle-Width="20%">
                                    <HeaderTemplate>
                                        <table border="1" cellspacing="0" cellpadding="2" width="100%" style="border-collapse: collapse;">
                                            <tr>
                                                <td colspan="3" style="height: 45px; text-align: center">
                                                    Giá trị theo sổ kế toán
                                                    <br />
                                                    (ngàn đồng)
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="width: 66%; height: 20px; text-align: center">
                                                    Nguyên giá
                                                </td>
                                                <td rowspan="2" style="width: 33%; height: 80px; text-align: center">
                                                    Giá trị còn lại
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 33%; text-align: center">
                                                    Nguồn NS
                                                </td>
                                                <td style="width: 33%; text-align: center">
                                                    Nguồn khác
                                                </td>
                                            </tr>
                                        </table>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <table border="0" cellspacing="0" cellpadding="2" width="100%">
                                            <tr>
                                                <td style="width: 33%; height: 40px; border-right: 1px solid gray; text-align: right;">
                                                    <%# Eval("NGUON_NS", "{0:#,##0}")%>
                                                </td>
                                                <td style="width: 33%; border-right: 1px solid gray; text-align: right;">
                                                    <%# Eval("NGUON_KHAC", "{0:#,##0}")%>
                                                </td>
                                                <td style="width: 33%; text-align: right;">
                                                    <%# Eval("GIA_TRI_CON_LAI", "{0:#,##0}")%>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Giá trị hao mòn" DataField="GIA_TRI_KHAU_HAO" DataFormatString="{0:#,##0}" ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundField HeaderText="Ngày lập" DataField="NGAY_LAP" />
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
    <asp:UpdateProgress runat="server">
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
