<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    EnableEventValidation="false" CodeFile="F102_DeNghiXuLyNha.aspx.cs" Inherits="ChucNang_F102_DeNghiXuLyNha" %>

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
                        <asp:Label ID="m_lbl_thong_tin_nha" runat="server" Text="DANH SÁCH NHÀ" CLASS="cssPageTitle"></asp:Label>
                        <span class="expand-collapse-text initial-expand">
                        </span><span class="expand-collapse-text"></span>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 15%">
                        <span class="cssManField">Bộ, tỉnh</span>
                    </td>
                    <td style="width: 30%" align="left">
                        <asp:DropDownList ID="m_ddl_bo_tinh" runat="server" Width="85%" ValidationGroup="m_vlg_nha"
                            AutoPostBack="True" OnSelectedIndexChanged="m_ddl_bo_tinh_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td align="right" style="width: 15%">
                        <span class="cssManField">Đơn vị chủ quản</span>
                    </td>
                    <td align="left" style="width: 30%;">
                        <asp:DropDownList ID="m_ddl_don_vi_chu_quan" runat="server" Width="85%" ValidationGroup="m_vlg_nha"
                            OnSelectedIndexChanged="m_ddl_don_vi_chu_quan_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 15%">
                        <span class="cssManField">Đơn vị sử dụng</span>
                    </td>
                    <td style="width: 30%" align="left">
                        <asp:DropDownList ID="m_ddl_don_vi_su_dung" runat="server" Width="85%" ValidationGroup="m_vlg_nha"
                            OnSelectedIndexChanged="m_ddl_don_vi_su_dung_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                    <td align="right" style="width: 15%">
                        <span class="cssManField">Trạng thái nhà</span>
                    </td>
                    <td align="left" style="width: 30%;">
                        <asp:DropDownList ID="m_ddl_trang_thai_nha" runat="server" Width="85%" ValidationGroup="m_vlg_nha"
                            AutoPostBack="true" OnSelectedIndexChanged="m_ddl_trang_thai_nha_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 15%">
                        <span class="cssManField">Thuộc khu đất</span>
                    </td>
                    <td style="width: 30%" align="left">
                        <asp:DropDownList ID="m_ddl_thuoc_khu_dat" runat="server" Width="85%" 
                            ValidationGroup="m_vlg_nha" AutoPostBack="true"
                            onselectedindexchanged="m_ddl_thuoc_khu_dat_SelectedIndexChanged">
                        </asp:DropDownList>
                    </td>
                    <td align="left" colspan = "2" rowspan = "2" style="width: 15%">
                        
                    
                        <span class="cssManField">
                            Chú ý:
                            <br />
                            - Chọn trạng thái "1-Đang sử dụng" -> Ấn tìm kiếm -> Chọn tài sản lập đề nghị xử lý
                            <br />- Chọn trạng thái "2-Đề nghị xử lý"-> Ấn tìm kiếm -> Chọn tài sản để hủy đề nghị xử lý
                        </span>
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
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="m_cmd_tim_kiem" runat="server" AccessKey="s" CssClass="cssButton"
                            Height="24px" OnClick="m_cmd_tim_kiem_Click" Text="Tìm kiếm" Width="98px" />
                    </td>
                    <td>
                        <asp:Button ID="m_cmd_xuat_excel" runat="server" CausesValidation="False" CssClass="cssButton"
                            Height="25px" OnClick="m_cmd_xuat_excel_Click" Text="Xuất Excel" Width="98px" />
                    </td>
                    <td>
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
                            Width="100%" DataKeyNames="ID" CellPadding="0" ForeColor="#333333" AllowSorting="True" CssClass="cssGrid"
                            EmptyDataText="Không có dữ liệu phù hợp" PageSize="15" ShowHeader="true" OnPageIndexChanging="m_grv_danh_sach_nha_PageIndexChanging">
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
                                <asp:BoundField HeaderText="Tên tài sản" DataField="TEN_TAI_SAN" />
                                <asp:BoundField HeaderText="Mã tài sản" DataField="MA_TAI_SAN" />
                                <asp:BoundField HeaderText="Bộ tỉnh" DataField="TEN_DV_BO_TINH" />
                                <asp:BoundField HeaderText="Đơn vị chủ quản" DataField="TEN_DV_CHU_QUAN" />
                                <asp:BoundField HeaderText="Đơn vị sử dụng" DataField="TEN_DV_SU_DUNG" />
                                <asp:BoundField HeaderText="Cấp hạng" DataField="CAP_HANG" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField HeaderText="Năm xây dựng" DataField="NAM_XAY_DUNG" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField HeaderText="Năm sử dụng" DataField="NGAY_THANG_NAM_SU_DUNG"
                                    ItemStyle-HorizontalAlign="Center" />
                                <asp:TemplateField HeaderStyle-Width="25%" HeaderStyle-Height="110px">
                                    <HeaderTemplate>
                                        <table border="1" cellspacing="0" cellpadding="2" width="100%" style="border-collapse: collapse; color: White">
                                            <tr>
                                                <td colspan="3" style="height: 50px; text-align:center">
                                                    GIÁ TRỊ THEO SỔ KẾ TOÁN
                                                    <br />
                                                    (ngàn đồng)
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" rowspan="1" style="text-align:center">
                                                    Nguyên giá
                                                </td>
                                                <td rowspan="2" style="width: 33.33%; height: 60px; text-align:center">
                                                    Giá trị còn lại
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 33.33%; text-align:center">
                                                    Nguồn NS
                                                </td>
                                                <td style="width: 33.33%; text-align:center">
                                                    Nguồn khác
                                                </td>
                                            </tr>
                                        </table>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <table border="0" cellspacing="0" cellpadding="2" width="100%" style="border-collapse: collapse;
                                            text-align: right">
                                            <td style="width: 33%; height: 60px; border-right: 1px solid gray;">
                                                <%# Eval("NGUON_NS", "{0:#,##0}")%>
                                            </td>
                                            <td style="width: 33%; height: 60px; border-right: 1px solid gray;">
                                                <%# Eval("NGUON_KHAC", "{0:#,##0}")%>
                                            </td>
                                            <td style="width: 33%; height: 50px;">
                                                <%# Eval("GIA_TRI_CON_LAI", "{0:#,##0}")%>
                                            </td>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Số tầng" DataField="SO_TANG" ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField HeaderText="DT xây dựng" DataField="DT_XAY_DUNG" ItemStyle-HorizontalAlign="Right" />
                                <asp:BoundField HeaderText="Tổng DT xây dựng" DataField="TONG_DT_SAN_XD" ItemStyle-HorizontalAlign="Right" 
                                    DataFormatString=""/>
                                <asp:TemplateField HeaderStyle-Height="110px" HeaderStyle-Width="30%">
                                    <HeaderTemplate>
                                        <table border="1" cellspacing="0" cellpadding="2" width="100%" style="border-collapse: collapse; color:White">
                                            <tr>
                                                <td colspan="7" style="height: 50px; text-align: center">
                                                    Hiện trạng sử dụng
                                                    <br />
                                                    (m2)
                                                </td>
                                            </tr>
                                            <tr>
                                                <td rowspan="2" style="width: 14%; height: 60px; text-align: center">
                                                    Trụ sở làm việc
                                                </td>
                                                <td rowspan="2" style="width: 14%; text-align: center">
                                                    Cơ sở HĐSN
                                                </td>
                                                <td colspan="5" style="text-align: center">
                                                    Sử dụng khác
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 14%; text-align: center">
                                                    Làm nhà ở
                                                </td>
                                                <td style="width: 14%; text-align: center">
                                                    Cho thuê
                                                </td>
                                                <td style="width: 14%; text-align: center">
                                                    Bỏ trống
                                                </td>
                                                <td style="width: 14%; text-align: center">
                                                    Bị lấn chiếm
                                                </td>
                                                <td style="width: 14%; text-align: center">
                                                    Khác
                                                </td>
                                            </tr>
                                        </table>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <table border="0" cellspacing="0" cellpadding="2" width="100%" style="text-align: right;
                                            border-collapse: collapse;">
                                            <tr>
                                                <td style="width: 14%; height: 60px; border-right: 1px solid gray;">
                                                    <%# Eval("TRU_SO_LAM_VIEC", "{0:#,##0}")%>
                                                </td>
                                                <td style="width: 14%; border-right: 1px solid gray;">
                                                    <%# Eval("CO_SO_HDSN", "{0:#,##0}")%>
                                                </td>
                                                <td style="width: 14%; border-right: 1px solid gray;">
                                                    <%# Eval("LAM_NHA_O", "{0:#,##0}")%>
                                                </td>
                                                <td style="width: 14%; border-right: 1px solid gray;">
                                                    <%# Eval("CHO_THUE", "{0:#,##0}")%>
                                                </td>
                                                <td style="width: 14%; border-right: 1px solid gray;">
                                                    <%# Eval("BO_TRONG", "{0:#,##0}")%>
                                                </td>
                                                <td style="width: 14%; border-right: 1px solid gray;">
                                                    <%# Eval("BI_LAN_CHIEM", "{0:#,##0}")%>
                                                </td>
                                                <td style="width: 14%;">
                                                    <%# Eval("KHAC", "{0:#,##0}")%>
                                                </td>
                                            </tr>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Trạng thái" DataField="TEN_TRANG_THAI" />
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
