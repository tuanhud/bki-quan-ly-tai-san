<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" EnableEventValidation="false"
    CodeFile="F107_DuyetGhiTangDat.aspx.cs" Inherits="ChucNang_F107_DuyetGhiTangDat" %>

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
                        <span class="cssPageTitle">Chi tiết duyệt ghi tăng giảm tài sản</span> <span class="expand-collapse-text initial-expand">
                        </span><span class="expand-collapse-text"></span>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:Label ID="m_lbl_message" runat="server" Text="" CssClass="cssManField"></asp:Label>
                        <asp:ValidationSummary ID="vdsCategory" runat="server" CssClass="cssManField" Font-Bold="true"/>
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
                    <td align="right" style="width: 20%">
                        <span class="cssManField">Đơn vị chủ quản</span>
                    </td>
                    <td align="left" style="width: 29%;">
                        <asp:DropDownList ID="m_cbo_don_vi_chu_quan_up" runat="server" Width="85%" AutoPostBack="True"
                            OnSelectedIndexChanged="m_cbo_don_vi_chu_quan_up_SelectedIndexChanged">
                        </asp:DropDownList>
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
                    <td align="right">
                        <span class="cssManField">Trạng thái đất</span>
                    </td>
                    <td align="left">
                        <asp:DropDownList ID="m_cbo_trang_thai_dat_up" runat="server" Width="85%" Enabled="false">
                        </asp:DropDownList>
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
                </tr>
                <tr>
                    <td align="right">
                        <span class="cssManField">Mã tài sản</span>
                    </td>
                    <td>
                        <asp:Label ID="m_lbl_ma_tai_san" runat="server" Text="" CssClass="cssManField" ForeColor="Blue"></asp:Label>
                    </td>
                    <td align="right">
                        <span class="cssManField">Diện tích khuôn viên (m2) </span>
                    </td>
                    <td>
                        <asp:Label ID="m_lbl_dt_khuon_vien" runat="server" Text="" CssClass="cssManField"
                            ForeColor="Blue"></asp:Label>
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
                    <td align="right">
                        <span class="cssManField">Giá trị theo số kế toán (VNĐ) </span>
                    </td>
                    <td>
                        <asp:Label ID="m_lbl_gt_theo_so_ke_toan" runat="server" Text="" CssClass="cssManField"
                            ForeColor="Blue"></asp:Label>
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
                            Text="(*)" ControlToValidate="m_txt_ma_phieu"></asp:RequiredFieldValidator>
                    </td>
                    <td align="right" style="width: 15%">
                        <span class="cssManField">Ngày tăng giảm tài sản</span>
                    </td>
                    <td align="left" style="width: 30%">
                        <asp:TextBox ID="m_txt_ngay_tang_giam" runat="server" CssClass="cssTextBox" Width="85%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="m_rfv_ngay_tang_giam" runat="server" ErrorMessage="Bạn phải nhập Ngày lập"
                            Text="(*)" ControlToValidate="m_txt_ngay_tang_giam"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 15%">
                        <span class="cssManField">Ngày duyệt</span>
                    </td>
                    <td align="left" style="width: 30%">
                        <asp:TextBox ID="m_txt_ngay_duyet" runat="server" CssClass="cssTextBox" Width="85%"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="m_rfv_ngay_duyet" runat="server" ErrorMessage="Bạn phải nhập ngày duyệt"
                            Text="(*)" ControlToValidate="m_txt_ngay_duyet"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                    </td>
                    <td>
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
                        <asp:Label ID="m_lbl_thong_tin_dat" runat="server" Text="Danh sách duyệt ghi tăng giảm đất " CssClass="cssPageTitle"></asp:Label>
                        <span class="expand-collapse-text initial-expand">
                        </span><span class="expand-collapse-text"></span>
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
                            TabIndex="3">
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
                            Height="24px" Text="Tìm kiếm" Width="98px" OnClick="m_cmd_tim_kiem_Click" CausesValidation="false" />
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
                            Width="100%" DataKeyNames="ID" CellPadding="0" ForeColor="#333333" AllowSorting="True"
                            EmptyDataText="Không có dữ liệu phù hợp" PageSize="15" ShowHeader="true" OnPageIndexChanging="m_grv_danh_sach_dat_PageIndexChanging"
                            OnRowCommand="m_grv_danh_sach_dat_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center" HeaderStyle-Height="30px"
                                    ItemStyle-Height="30px">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Mã phiếu" DataField="MA_PHIEU" />
                                <asp:BoundField HeaderText="Địa chỉ" DataField="DIA_CHI" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField HeaderText="Diện tích" DataField="DIEN_TICH" ItemStyle-HorizontalAlign="Right" />
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
