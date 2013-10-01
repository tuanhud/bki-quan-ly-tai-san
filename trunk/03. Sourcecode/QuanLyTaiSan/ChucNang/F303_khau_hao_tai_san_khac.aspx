<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="F303_khau_hao_tai_san_khac.aspx.cs" Inherits="ChucNang_F303_khau_hao_tai_san_khac" %>

<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script type="text/javascript">
        $(function () {
            $(".tb").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "../ChucNang/PersonService.asmx/GetTaiSanKhac",
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table cellspacing="0" cellpadding="2" style="width: 99%;" class="cssTable" border="0">
                <tr>
                    <td class="cssPageTitleBG" colspan="4">
                        <span class="cssPageTitle">KHẤU HAO TÀI SẢN KHÁC</span> <span class="expand-collapse-text initial-expand">
                        </span><span class="expand-collapse-text"></span>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:ValidationSummary ID="vdsCategory" runat="server" CssClass="cssManField" Font-Bold="true"
                            ValidationGroup="m_vlg_tai_san_khac" />
                        <asp:Label ID="m_lbl_mess" runat="server" CssClass="cssManField" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <table cellspacing="0" cellpadding="2" style="width: 100%;" class="cssTable" border="0">
                            <tr>
                                <td align="right" style="width: 15%">
                                    <span class="cssManField">Bộ, tỉnh</span>
                                </td>
                                <td style="width: 30%" align="left">
                                    <asp:DropDownList ID="m_cbo_bo_tinh_up" runat="server" Width="85%" AutoPostBack="True"
                                        OnSelectedIndexChanged="m_cbo_bo_tinh_up_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td align="left" style="width: 1%;">
                                </td>
                                <td align="right" style="width: 15%">
                                    <span class="cssManField">Đơn vị chủ quản</span>
                                </td>
                                <td align="left" style="width: 30%;">
                                    <asp:DropDownList ID="m_cbo_don_vi_chu_quan_up" runat="server" Width="85%" OnSelectedIndexChanged="m_cbo_don_vi_chu_quan_up_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td align="left" style="width: 1%;">
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 15%">
                                    <span class="cssManField">Đơn vị sử dụng tài sản</span>
                                </td>
                                <td style="width: 30%" align="left">
                                    <asp:DropDownList ID="m_cbo_don_vi_su_dung_tai_san_up" runat="server" Width="85%"
                                        AutoPostBack="true" OnSelectedIndexChanged="m_cbo_don_vi_su_dung_tai_san_up_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td align="left" style="width: 1%;">
                                </td>
                                <td align="right" style="width: 15%">
                                    <span class="cssManField">Trạng thái tài sản</span>
                                </td>
                                <td align="left" style="width: 30%;">
                                    <asp:DropDownList ID="m_cbo_trang_thai_tai_san_up" runat="server" Width="85%" Enabled="False">
                                    </asp:DropDownList>
                                </td>
                                <td align="left" style="width: 1%;">
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 15%">
                                    <span class="cssManField">Tên tài sản</span>
                                </td>
                                <td style="width: 30%" align="left">
                                    <asp:DropDownList ID="m_cbo_ten_tai_san" runat="server" Width="85%" AutoPostBack="true"
                                        OnSelectedIndexChanged="m_cbo_ten_tai_san_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td align="left" style="width: 1%;">
                                </td>
                                <td align="right" style="width: 15%">
                                    <span class="cssManField">Mã tài sản</span>
                                </td>
                                <td align="left" style="width: 30%;">
                                    <asp:Label ID="m_lbl_ma_tai_san" runat="Server" CssClass="cssManField" Style="color: blue">
                                    </asp:Label>
                                </td>
                                <td align="left" style="width: 1%;">
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 15%">
                                    <span class="cssManField">Ký hiệu</span>
                                </td>
                                <td style="width: 30%" align="left">
                                    <asp:Label ID="m_lbl_ky_hieu" runat="server" CssClass="cssManField" Style="color: blue">
                                    </asp:Label>
                                </td>
                                <td align="left" style="width: 1%;">
                                </td>
                                <td align="right" style="width: 15%">
                                    <span class="cssManField">Nước sản xuất</span>
                                </td>
                                <td align="left" style="width: 30%;">
                                    <asp:Label ID="m_lbl_nuoc_san_xuat" runat="Server" CssClass="cssManField" Style="color: blue">
                                    </asp:Label>
                                </td>
                                <td align="left" style="width: 1%;">
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 15%">
                                    <span class="cssManField">Năm sản xuất</span>
                                </td>
                                <td style="width: 30%" align="left">
                                    <asp:Label ID="m_lbl_nam_san_xuat" CssClass="cssManField" runat="server" Style="color: blue">
                                    </asp:Label>
                                </td>
                                <td align="left" style="width: 1%;">
                                </td>
                                <td align="right" style="width: 15%">
                                    <span class="cssManField">Năm sử dụng</span>
                                </td>
                                <td align="left" style="width: 30%;">
                                    <asp:Label ID="m_lbl_ngay_thang_nam_su_dung" runat="Server" CssClass="cssManField"
                                        Style="color: blue"></asp:Label>
                                </td>
                                <td align="left" style="width: 1%;">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center" class="cssManField">
                                    <span>GIÁ TRỊ THEO SỔ KẾ TOÁN</span>
                                </td>
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
                                <td align="right" style="width: 15%">
                                    <span class="cssManField">Nguyên giá nguồn NS (VNĐ)</span>
                                </td>
                                <td style="width: 30%" align="right">
                                    <asp:Label ID="m_lbl_nguyen_gia_nguon_ns" runat="Server" CssClass="cssManField" Style="color: blue">
                                    </asp:Label>
                                </td>
                                <td align="left" style="width: 1%;">
                                </td>
                                <td align="right" style="width: 15%">
                                    <span class="cssManField">Nguyên giá nguồn khác (VNĐ)</span>
                                </td>
                                <td align="right" style="width: 30%;">
                                    <asp:Label ID="m_lbl_nguyen_gia_nguon_khac" runat="Server" CssClass="cssManField"
                                        Style="color: blue"></asp:Label>
                                </td>
                                <td align="left" style="width: 1%;">
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width: 15%">
                                    <span class="cssManField">Giá trị còn lại (VNĐ)</span>
                                </td>
                                <td style="width: 30%" align="right">
                                    <asp:Label ID="m_lbl_gia_tri_con_lai" runat="Server" CssClass="cssManField" Style="color: blue">
                                    </asp:Label>
                                </td>
                                <td align="left" style="width: 1%;">
                                </td>
                                <td align="right">
                                </td>
                                <td align="left" style="width: 30%;">
                                </td>
                                <td align="left" style="width: 1%;">
                                </td>
                            </tr>
                            <tr>
                                <td class="cssManField" colspan="2" align="center">
                                    <span>KHẤU HAO TÀI SẢN</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="cssManField" align="right" colspan="1" style="width: 20%">
                                    <span>Mã phiếu</span>
                                </td>
                                <td colspan="1" style="width: 29%">
                                    <asp:TextBox ID="m_txt_ma_phieu" runat="server" CssClass="cssTextBox" Width="85%"
                                        ValidationGroup="m_vlg_tai_san_khac">
                                    </asp:TextBox>
                                </td>
                                <td align="left" style="width: 1%;">
                                    <asp:RequiredFieldValidator ID="m_rfv_ma_phieu" runat="server" ControlToValidate="m_txt_ma_phieu"
                                        ErrorMessage="Bạn phải nhập Mã Phiếu" Text="(*)" ValidationGroup="m_vlg_tai_san_khac" ForeColor="Red">
                                    </asp:RequiredFieldValidator>
                                </td>
                                <td colspan="1" style="width: 20%" align="right" class="cssManField">
                                    <span>Giá trị khấu hao </span>
                                </td>
                                <td>
                                    <asp:TextBox ID="m_txt_gia_tri_khau_hao" runat="server" CssClass="cssTextBox csscurrency"
                                        Width="85%" ValidationGroup="m_vlg_tai_san_khac">
                                    </asp:TextBox>
                                </td>
                                <td align="left" style="width: 1%;">
                                    <asp:RequiredFieldValidator ID="m_rfv_gia_tri_khau_hao" runat="server" ControlToValidate="m_txt_gia_tri_khau_hao"
                                        ErrorMessage="Bạn phải nhập Giá Trị Khấu Hao" Text="(*)" ValidationGroup="m_vlg_tai_san_khac"
                                        ForeColor="Red">
                                    </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="1" align="right" class="cssManField">
                                    <span>Ngày lập </span>
                                </td>
                                <td style="width: 29%" align="left">
                                    <asp:TextBox ID="m_txt_ngay_lap" runat="server" CssClass="cssTextBox" Width="85%"
                                        ValidationGroup="m_vlg_tai_san_khac">
                                    </asp:TextBox>
                                </td>
                                <td align="left" style="width: 1%" class="cssManField">
                                    <asp:RequiredFieldValidator ID="m_rfv_ngay_lap" runat="Server" ControlToValidate="m_txt_ngay_lap"
                                        ErrorMessage="Bạn phải nhập đúng Ngày Lập" Text="(*)" ValidationGroup="m_vlg_tai_san_khac">
                                    </asp:RequiredFieldValidator>
                                </td>
                                <td align="right" class="cssManField">
                                    <span>Ngày duyệt </span>
                                </td>
                                <td style="width: 29%" align="left">
                                    <asp:TextBox ID="m_txt_ngay_duyet" runat="Server" CssClass=" cssTextBox" Width="85%"
                                        ValidationGroup="m_vlg_tai_san_khac">
                                    </asp:TextBox>
                                </td>
                                <td align="left" style="width: 1%;">
                                    <asp:RequiredFieldValidator ID="m_rfv_ngay_duyet" runat="server" ControlToValidate="m_txt_ngay_duyet"
                                        ErrorMessage="Bạn phải nhập Ngày Duyệt" Text="(*)" ValidationGroup="m_vlg_tai_san_khac"
                                        ForeColor="Red">
                                    </asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td colspan="4" align="left">
                                    <asp:Button ID="m_cmd_tao_moi" AccessKey="c" CssClass="cssButton" runat="server"
                                        Height="24px" Width="98px" Text="Tạo mới(c)" ValidationGroup="m_vlg_tai_san_khac"
                                        OnClick="m_cmd_tao_moi_Click" />&nbsp;
                                    <asp:Button ID="m_cmd_xoa_trang" AccessKey="r" CssClass="cssButton" runat="server"
                                        Height="24px" Width="98px" Text="Xóa trắng(r)" />
                                    <asp:HiddenField ID="m_hdf_id" runat="server" Value="" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table cellspacing="0" cellpadding="2" style="width: 99%;" class="cssTable" border="0">
                <tr>
                    <td class="cssPageTitleBG" colspan="4">
                        <asp:Label ID="m_lbl_khau_hao_tai_san_khac" runat="Server" class="cssPageTitle" Text="DANH SÁCH CÁC LẦN KHẤU HAO"></asp:Label>
                        <span class="expand-collapse-text initial-expand"></span><span class="expand-collapse-text">
                        </span>
                    </td>
                </tr>
                <tr>
                    <td align="right" colspan="1" style="width: 20%">
                        <span class="cssManField">Bộ, tỉnh:</span>
                    </td>
                    <td style="width: 30%" colspan="1">
                        <asp:DropDownList ID="m_cbo_bo_tinh_down" Width="85%" runat="Server" AutoPostBack="True"
                            TabIndex="1" OnSelectedIndexChanged="m_cbo_bo_tinh_down_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td align="right" style="width: 20%" colspan="1">
                        <span class="cssManField">Đơn vị chủ quản:</span>
                    </td>
                    <td style="width: 30%" colspan="1">
                        <asp:DropDownList ID="m_cbo_don_vi_chu_quan_down" Width="85%" runat="Server" AutoPostBack="True"
                            TabIndex="2" OnSelectedIndexChanged="m_cbo_don_vi_chu_quan_down_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span class="cssManField">Đơn vị sử dụng tài sản:</span>
                    </td>
                    <td>
                        <asp:DropDownList ID="m_cbo_don_vi_su_dung_tai_san_down" Width="85%" runat="Server"
                            AutoPostBack="True" TabIndex="3">
                        </asp:DropDownList>
                    </td>
                    <td align="right">
                        <span class="cssManField">Trạng thái tài sản: </span>
                    </td>
                    <td>
                        <asp:DropDownList ID="m_cbo_trang_thai_tai_san_down" runat="Server" Width="85%" TabIndex="4">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right" colspan="1" style="width: 20%">
                        <span class="cssManField">Từ khóa </span>
                    </td>
                    <td style="width: 30%" colspan="1">
                        <asp:TextBox ID="m_txt_tu_khoa" runat="server" CssClass="cssTextBox" AutoPostBack="true"
                            Width="85%" ontextchanged="m_txt_tu_khoa_TextChanged">
                        </asp:TextBox>
                    </td>
                    <td align="right" style="width: 20%" colspan="1">
                    </td>
                    <td style="width: 30%" colspan="1">
                    </td>
                </tr>
                <tr>
                    <td align="right">
                    </td>
                    <td align="left">
                        <asp:Button ID="m_cmd_tim_kiem" runat="server" AccessKey="s" CssClass="cssButton"
                            Height="24px" Text="Tìm kiếm" Width="98px" OnClick="m_cmd_tim_kiem_Click" CausesValidation="false"/>
                    </td>
                    <td align="left">
                        <asp:Button ID="m_cmd_xuat_excel" runat="server" CausesValidation="False" CssClass="cssButton"
                            Height="25px" Text="Xuất Excel" Width="98px" OnClick="m_cmd_xuat_excel_Click" />
                    </td>
                    <td align="left">
                    </td>
                </tr>
                <tr>
                    <td align="left" colspan="2">
                        <asp:Label ID="m_lbl_thong_bao" Visible="false" runat="server" CssClass="cssManField" />
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="4" style="height: 450px;" valign="top">
                        <asp:GridView ID="m_grv_tai_san_khac" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            Width="100%" DataKeyNames="ID_KH" CellPadding="0" ForeColor="#333333" AllowSorting="True"
                            PageSize="15" ShowHeader="true" EmptyDataText="Không có dữ liệu." OnPageIndexChanging="m_grv_tai_san_khac_PageIndexChanging"
                            OnRowCommand="m_grv_tai_san_khac_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="Xóa" ItemStyle-Width="2%">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="m_lbt_delete" runat="server" CommandName="DeleteComp" ToolTip="Xóa"
                                            OnClientClick="return confirm ('Bạn có thực sự muốn xóa bản ghi này?')">
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
                                <asp:BoundField HeaderText="Ký hiệu" DataField="KY_HIEU" />
                                <asp:BoundField HeaderText="Nước sản xuất" DataField="NUOC_SAN_XUAT" />
                                <asp:BoundField HeaderText="Năm sản xuất" DataField="NAM_SAN_XUAT" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField HeaderText="Ngày, tháng, năm sử dụng" DataField="NAM_SU_DUNG" ItemStyle-HorizontalAlign="Center" />
                                <asp:TemplateField HeaderStyle-Width="25%" HeaderStyle-Height="75px">
                                    <HeaderTemplate>
                                        <table border="1" cellspacing="0" cellpadding="3" width="100%" style="border-collapse: collapse">
                                            <tr>
                                                <td colspan="3" style="height: 35px">
                                                    Giá trị theo sổ kế toán
                                                    <br />
                                                    (đồng)
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="width: 66%; height: 24px">
                                                    Nguyên giá
                                                </td>
                                                <td rowspan="2" style="width: 33%">
                                                    Giá trị còn lại
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 33%">
                                                    Nguồn NS
                                                </td>
                                                <td style="width: 33%">
                                                    Nguồn khác
                                                </td>
                                            </tr>
                                        </table>
                                    </HeaderTemplate>
                                    <HeaderStyle CssClass="" />
                                    <ItemTemplate>
                                        <table border="0" cellspacing="0" cellpadding="2" width="100%">
                                            <tr>
                                                <td style="width: 33%; border-right: solid; border-right-width: 1px" height="40px"
                                                    align="right">
                                                    <%# Eval("NGUON_NS", "{0:#,##0}")%>
                                                </td>
                                                <td style="width: 33%; border-right: solid; border-right-width: 1px" align="right">
                                                    <%# Eval("NGUON_KHAC", "{0:#,##0}")%>
                                                </td>
                                                <td style="width: 33%;" align="right">
                                                    <%# Eval("GIA_TRI_CON_LAI", "{0:#,##0}")%>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Giá trị khấu hao" DataField="GIA_TRI_KHAU_HAO" DataFormatString="{0:#,##0}"/>
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
</asp:Content>
