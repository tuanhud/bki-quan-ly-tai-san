<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="F104_DeNghiXuLyDat.aspx.cs" Inherits="ChucNang_F104_DeNghiXuLyDat" %>

<%@ Register Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"
    TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script type="text/javascript">
        // Hàm này dùng để check all checkbox trên lưới
        function SelectAllCheckboxes(spanChk) {
            // Added as ASPX uses SPAN for checkbox
            var oItem = spanChk.children;
            var theBox = (spanChk.type == "checkbox") ? spanChk : spanChk.children.item[0];
            xState = theBox.checked;
            elm = theBox.form.elements;

            for (i = 0; i < elm.length; i++)
                if (elm[i].type == "checkbox" && elm[i].id != theBox.id) {
                    if (elm[i].checked != xState)
                        elm[i].click();
                }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table cellspacing="0" cellpadding="2" style="width: 99%;" class="cssTable" border="0">
                <tr>
                    <td colspan="4">
                        <asp:Label ID="m_lbl_message" runat="server" Text="" CssClass="cssManField"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="cssPageTitleBG" colspan="4">
                        <asp:Label ID="m_lbl_thong_tin_dat" runat="server" Text="DANH SÁCH ĐẤT" CssClass="cssPageTitle"></asp:Label><span
                            class="expand-collapse-text initial-expand"> </span><span class="expand-collapse-text">
                            </span>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 15%">
                        <span class="cssManField">Bộ, tỉnh</span>
                    </td>
                    <td style="width: 30%" align="left">
                        <asp:DropDownList ID="m_ddl_bo_tinh" runat="server" Width="85%" ValidationGroup="m_vlg_dat"
                            AutoPostBack="True" OnSelectedIndexChanged="m_ddl_bo_tinh_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td align="right" style="width: 15%">
                        <span class="cssManField">Đơn vị chủ quản</span>
                    </td>
                    <td align="left" style="width: 30%;">
                        <asp:DropDownList ID="m_ddl_don_vi_chu_quan" runat="server" Width="85%" ValidationGroup="m_vlg_dat"
                            OnSelectedIndexChanged="m_ddl_don_vi_chu_quan_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 15%">
                        <span class="cssManField">Đơn vị sử dụng</span>
                    </td>
                    <td style="width: 30%" align="left">
                        <asp:DropDownList ID="m_ddl_don_vi_su_dung" runat="server" Width="85%" ValidationGroup="m_vlg_dat"
                            AutoPostBack="True" OnSelectedIndexChanged="m_ddl_don_vi_su_dung_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td align="right" style="width: 15%">
                        <span class="cssManField">Trạng thái nhà</span>
                    </td>
                    <td align="left" style="width: 30%;">
                        <asp:DropDownList ID="m_ddl_trang_thai_nha" runat="server" Width="85%" ValidationGroup="m_vlg_dat">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 15%">
                        <span class="cssManField">Từ khóa</span>
                    </td>
                    <td>
                        <asp:TextBox ID="m_txt_tu_khoa" runat="server" CssClass="cssTextBox" Width="85%">
                        </asp:TextBox>
                    </td>
                    <td colspan="2" rowspan="2">
                        <span class="cssManField">Chú ý:
                            <br />
                            - Chọn trạng thái "1-Đang sử dụng" -> Ấn tìm kiếm -> Chọn tài sản để lập đề nghị
                            xử lý
                            <br />
                            - Chọn trạng thái "2-Đề nghị xử lý" -> Ấn tìm kiếm -> Chọn tài sản để hủy đề nghị
                            xử lý </span>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="m_cmd_tim_kiem" runat="server" AccessKey="s" CssClass="cssButton"
                            Height="24px" OnClick="m_cmd_tim_kiem_Click" Text="Tìm kiếm" Width="98px" />
                        &nbsp;
                        <asp:Button ID="m_cmd_xuat_excel" runat="server" CausesValidation="False" CssClass="cssButton"
                            Height="25px" Text="Xuất Excel" Width="98px" OnClick="m_cmd_xuat_excel_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <hr />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="m_cmd_de_nghi_xu_ly" runat="server" Text="Đề nghị xử lý" CssClass="cssButton"
                            Height="24px" Width="98px" OnClick="m_cmd_de_nghi_xu_ly_Click" Enabled="False" />
                        <asp:Button ID="m_cmd_huy_de_nghi_xu_ly" runat="server" Text="Hủy" CssClass="cssButton"
                            Height="24px" Width="98px" OnClick="m_cmd_huy_de_nghi_xu_ly_Click" Enabled="False" />
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="4" style="height: 450px;" valign="top">
                        <asp:GridView ID="m_grv_danh_sach_nha" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            Width="100%" DataKeyNames="ID" CellPadding="4" ForeColor="#333333" AllowSorting="True"
                            EmptyDataText="Không có dữ liệu phù hợp" PageSize="15" ShowHeader="true" OnPageIndexChanging="m_grv_danh_sach_nha_PageIndexChanging">
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
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <!-- Header checkbox -->
                                        <input type="checkbox" id="chkAll" onclick="javascript:SelectAllCheckboxes(this)"
                                            runat="server" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <!-- cái này là checkbox, hiểu là dữ liệu của cột -->
                                        <asp:CheckBox runat="server" ID="chkItem" ToolTip='<%# Eval("ID") %>' />
                                        <asp:CheckBox runat="server" ID="chkTrangThai" Visible="false" />
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
                                <asp:BoundField HeaderText="DT Trụ sở làm việc (m2)" DataField="DT_TRU_SO_LAM_VIEC"
                                    ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0}" />
                                <asp:BoundField HeaderText="DT Cơ sở hoạt động sự nghiệp (m2)" DataField="DT_CO_SO_HOAT_DONG_SU_NGHIEP"
                                    ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0}" />
                                <asp:BoundField HeaderText="DT Làm nhà ở (m2)" DataField="DT_LAM_NHA_O" ItemStyle-HorizontalAlign="Right"
                                    DataFormatString="{0:#,##0}" />
                                <asp:BoundField HeaderText="DT Cho thuê (m2)" DataField="DT_CHO_THUE" ItemStyle-HorizontalAlign="Right"
                                    DataFormatString="{0:#,##0}" />
                                <asp:BoundField HeaderText="DT Bỏ trống (m2)" DataField="DT_BO_TRONG" ItemStyle-HorizontalAlign="Right"
                                    DataFormatString="{0:#,##0}" />
                                <asp:BoundField HeaderText="DT Bị lấn chiếm (m2)" DataField="DT_BI_LAN_CHIEM" ItemStyle-HorizontalAlign="Right"
                                    DataFormatString="{0:#,##0}" />
                                <asp:BoundField HeaderText="DT Sử dụng mục đích khác (m2)" DataField="DT_SU_DUNG_MUC_DICH_KHAC"
                                    ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0}" />
                                <asp:BoundField HeaderText="Giá trị theo số kế toán (VNĐ)" DataField="GT_THEO_SO_KE_TOAN"
                                    ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,##0}" />
                                <asp:BoundField HeaderText="Số năm đã sử dụng" DataField="SO_NAM_DA_SU_DUNG" ItemStyle-HorizontalAlign="Right" />
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
