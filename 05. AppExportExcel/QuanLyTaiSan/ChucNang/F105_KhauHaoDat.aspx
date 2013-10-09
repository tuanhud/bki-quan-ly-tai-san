<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" EnableEventValidation="false"
    CodeFile="F105_KhauHaoDat.aspx.cs" Inherits="ChucNang_F105_KhauHaoDat" %>

<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script type="text/javascript">
        $(function () {
            $(".tb").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "../ChucNang/PersonService.asmx/GetDat",
                        data: "{ 'name_prefix': '" + request.term + "', 'ip_dc_id_dv_su_dung': '"
                        + document.getElementById('<%= m_cbo_don_vi_su_dung_up.ClientID%>').value + "' }",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        dataFilter: function (data) { return data; },
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    value: item.strDIA_CHI,
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
            <table border="0" cellspacing="0" cellpadding="2" width="100%">
                <tr>
                    <td class="cssPageTitleBG" colspan="6">
                        <span class="cssPageTitle">KHẤU HAO TÀI SẢN ĐẤT</span> <span class="expand-collapse-text initial-expand">
                        </span><span class="expand-collapse-text"></span>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        <asp:ValidationSummary ID="vdsCategory" runat="server" CssClass="cssManField" Font-Bold="true"
                            ValidationGroup="m_vlg_dat" />
                        <asp:Label ID="m_lbl_mess" runat="server" CssClass="cssManField" />
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 20%">
                        <span class="cssManField">Bộ, tỉnh</span>
                    </td>
                    <td style="width: 29%" align="left">
                        <asp:DropDownList ID="m_cbo_bo_tinh_up" runat="server" Width="85%" AutoPostBack="True"
                            OnSelectedIndexChanged="m_cbo_bo_tinh_up_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td style="width: 1%">
                    </td>
                    <td align="right" style="width: 20%">
                        <span class="cssManField">Đơn vị chủ quản</span>
                    </td>
                    <td align="left" style="width: 29%;">
                        <asp:DropDownList ID="m_cbo_don_vi_chu_quan_up" runat="server" Width="85%" AutoPostBack="True"
                            OnSelectedIndexChanged="m_cbo_don_vi_chu_quan_up_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td style="width: 1%">
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span class="cssManField">Đơn vị sử dụng</span>
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="m_cbo_don_vi_su_dung_up" runat="server" Width="85%" AutoPostBack="True"
                            OnSelectedIndexChanged="m_cbo_don_vi_su_dung_up_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td>
                    </td>
                    <td align="right">
                        <span class="cssManField">Trạng thái đất</span>
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="m_cbo_trang_thai_dat_up" runat="server" Width="85%" Enabled="false">
                        </asp:DropDownList>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span class="cssManField">Địa chỉ</span>
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="m_cbo_dia_chi" runat="server" Width="85%" AutoPostBack="true"
                            OnSelectedIndexChanged="m_cbo_dia_chi_SelectedIndexChanged">
                        </asp:DropDownList>
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
                    <td align="right">
                        <span class="cssManField">Mã tài sản</span>
                    </td>
                    <td>
                        <asp:Label ID="m_lbl_ma_tai_san" runat="server" Text="" CssClass="cssManField" ForeColor="Blue"></asp:Label>
                    </td>
                    <td>
                    </td>
                    <td align="right">
                        <span class="cssManField">Diện tích khuôn viên (m2) </span>
                    </td>
                    <td>
                        <asp:Label ID="m_lbl_dt_khuon_vien" runat="server" Text="" CssClass="cssManField"
                            ForeColor="Blue"></asp:Label>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span class="cssManField">Số năm đã sử dụng</span>
                    </td>
                    <td>
                        <asp:Label ID="m_lbl_so_nam_su_dung" runat="server" Text="" CssClass="cssManField"
                            ForeColor="Blue"></asp:Label>
                    </td>
                    <td>
                    </td>
                    <td align="right">
                        <span class="cssManField">Giá trị theo số kế toán (VNĐ) </span>
                    </td>
                    <td>
                        <asp:Label ID="m_lbl_gt_theo_so_ke_toan" runat="server" Text="" CssClass="cssManField"
                            ForeColor="Blue"></asp:Label>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
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
                            ValidationGroup="m_vlg_dat"> </asp:TextBox>
                    </td>
                    <td align="left" style="width: 1%;">
                        <asp:RequiredFieldValidator ID="m_rfv_ma_phieu" runat="server" ControlToValidate="m_txt_ma_phieu"
                            ErrorMessage="Bạn phải nhập Mã Phiếu" Text="(*)" ValidationGroup="m_vlg_dat" ForeColor="Red"> </asp:RequiredFieldValidator>
                    </td>
                    <td colspan="1" style="width: 20%" align="right" class="cssManField">
                        <span>Giá trị khấu hao </span>
                    </td>
                    <td>
                        <asp:TextBox ID="m_txt_gia_tri_khau_hao" runat="server" CssClass="cssTextBox csscurrency"
                            Width="85%" ValidationGroup="m_vlg_dat"> </asp:TextBox>
                    </td>
                    <td align="left" style="width: 1%;">
                        <asp:RequiredFieldValidator ID="m_rfv_gia_tri_khau_hao" runat="server" ControlToValidate="m_txt_gia_tri_khau_hao"
                            ErrorMessage="Bạn phải nhập Giá Trị Khấu Hao" Text="(*)" ValidationGroup="m_vlg_dat"
                            ForeColor="Red"> </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="1" align="right" class="cssManField">
                        <span>Ngày lập </span>
                    </td>
                    <td style="width: 29%" align="left">
                        <asp:TextBox ID="m_txt_ngay_lap" runat="server" CssClass="cssTextBox" Width="85%"
                            ValidationGroup="m_vlg_dat"> </asp:TextBox>
                    </td>
                    <td align="left" style="width: 1%" class="cssManField">
                        <asp:RequiredFieldValidator ID="m_rfv_ngay_lap" runat="Server" ControlToValidate="m_txt_ngay_lap"
                            ErrorMessage="Bạn phải nhập đúng Ngày Lập" Text="(*)" ValidationGroup="m_vlg_dat"> </asp:RequiredFieldValidator>
                    </td>
                    <td align="right" class="cssManField">
                        <span>Ngày duyệt </span>
                    </td>
                    <td style="width: 29%" align="left">
                        <asp:TextBox ID="m_txt_ngay_duyet" runat="Server" CssClass="cssTextBox" Width="85%"
                            ValidationGroup="m_vlg_dat"> </asp:TextBox>
                    </td>
                    <td align="left" style="width: 1%;">
                        <asp:RequiredFieldValidator ID="m_rfv_ngay_duyet" runat="server" ControlToValidate="m_txt_ngay_duyet"
                            ErrorMessage="Bạn phải nhập Ngày Duyệt" Text="(*)" ValidationGroup="m_vlg_dat"
                            ForeColor="Red"> </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="center">
                        <asp:Button ID="m_cmd_tao_moi" AccessKey="c" CssClass="cssButton" runat="server"
                            Height="24px" Width="98px" Text="Tạo mới(c)" ValidationGroup="m_vlg_dat" OnClick="m_cmd_tao_moi_Click" />
                        <asp:Button ID="m_cmd_xoa_trang" AccessKey="r" CssClass="cssButton" runat="server"
                            Height="24px" Width="98px" Text="Xóa trắng(r)" OnClick="m_cmd_xoa_trang_Click" />
                        <asp:HiddenField ID="m_hdf_id" runat="server" Value="" />
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
            <table border="0" cellspacing="0" cellpadding="0" width="100%">
                <tr>
                    <td class="cssPageTitleBG" colspan="6">
                        <asp:Label ID="m_lbl_thong_tin_khau_hao_dat" runat="Server" class="cssPageTitle"
                            Text="DANH SÁCH KHẤU HAO ĐẤT"></asp:Label>
                        <span class="expand-collapse-text initial-expand"></span><span class="expand-collapse-text">
                        </span>
                    </td>
                </tr>
                <tr>
                    <td align="right" colspan="1" style="width: 20%">
                        <span class="cssManField">Bộ, tỉnh </span>
                    </td>
                    <td style="width: 30%" colspan="1">
                        <asp:DropDownList ID="m_cbo_bo_tinh_down" Width="85%" runat="Server" AutoPostBack="True"
                            TabIndex="1" OnSelectedIndexChanged="m_cbo_bo_tinh_down_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td align="right" style="width: 20%" colspan="1">
                        <span class="cssManField">Đơn vị chủ quản </span>
                    </td>
                    <td style="width: 30%" colspan="1">
                        <asp:DropDownList ID="m_cbo_don_vi_chu_quan_down" Width="85%" runat="Server" AutoPostBack="True"
                            TabIndex="2" OnSelectedIndexChanged="m_cbo_don_vi_chu_quan_down_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span class="cssManField">Đơn vị sử dụng tài sản </span>
                    </td>
                    <td>
                        <asp:DropDownList ID="m_cbo_don_vi_su_dung_down" Width="85%" runat="Server" AutoPostBack="True"
                            TabIndex="3" 
                            onselectedindexchanged="m_cbo_don_vi_su_dung_down_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td align="right">
                        <span class="cssManField">Từ khóa </span>
                    </td>
                    <td style="width: 30%" colspan="1">
                        <asp:TextBox ID="m_txt_tu_khoa" runat="server" CssClass="cssTextBox" AutoPostBack="true"
                            Width="85%" ontextchanged="m_txt_tu_khoa_TextChanged"> </asp:TextBox>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                    </td>
                    <td align="left">
                        <asp:Button ID="m_cmd_tim_kiem" runat="server" AccessKey="s" CssClass="cssButton"
                            Height="24px" Text="Tìm kiếm" Width="98px" OnClick="m_cmd_tim_kiem_Click" />
                        &nbsp;
                        <asp:Button ID="m_cmd_xuat_excel" runat="server" CausesValidation="False" CssClass="cssButton"
                            Height="25px" Text="Xuất Excel" Width="98px" OnClick="m_cmd_xuat_excel_Click" />
                    </td>
                    <td align="left">
                    </td>
                    <td align="left">
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:GridView ID="m_grv_danh_sach_dat" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            Width="100%" DataKeyNames="ID_KH" CellPadding="4" ForeColor="#333333" AllowSorting="True"
                            EmptyDataText="Không có dữ liệu phù hợp" PageSize="15" ShowHeader="true" OnPageIndexChanging="m_grv_danh_sach_dat_PageIndexChanging"
                            OnRowCommand="m_grv_danh_sach_dat_RowCommand">
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
                                <asp:BoundField HeaderText="Mã tài sản" DataField="MA_TAI_SAN" />
                                <asp:BoundField HeaderText="Địa chỉ" DataField="DIA_CHI" />
                                <asp:BoundField HeaderText="DT Khuôn viên (m2)" DataField="DT_KHUON_VIEN" ItemStyle-HorizontalAlign="Right"
                                    DataFormatString="{0:#,##0}" />
                                <asp:BoundField HeaderText="Giá trị theo số kế toán (VNĐ)" DataField="GT_THEO_SO_KE_TOAN"
                                    ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0}" />
                                <asp:BoundField HeaderText="Số năm đã sử dụng" DataField="SO_NAM_DA_SU_DUNG" ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundField HeaderText="Giá trị khấu hao" DataField="GIA_TRI_KHAU_HAO" DataFormatString="{0:#,##0}" />
                                <asp:BoundField HeaderText="Ngày lập" DataField="NGAY_LAP" />
                                <asp:BoundField HeaderText="Ngày duyệt" DataField="NGAY_DUYET" />
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
