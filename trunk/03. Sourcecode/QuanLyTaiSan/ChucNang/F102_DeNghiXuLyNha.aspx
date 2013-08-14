<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="F102_DeNghiXuLyNha.aspx.cs" Inherits="ChucNang_F102_DeNghiXuLyNha" %>

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
    <table cellspacing="0" cellpadding="2" style="width: 99%;" class="cssTable" border="0">
        <tr>
            <td class="cssPageTitleBG" colspan="4">
                <span class="cssPageTitle">Danh sách nhà</span> <span class="expand-collapse-text initial-expand">
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
                    OnSelectedIndexChanged="m_ddl_trang_thai_nha_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 15%">
                <span class="cssManField">Thuộc khu đất</span>
            </td>
            <td style="width: 30%" align="left">
                <asp:DropDownList ID="m_ddl_thuoc_khu_dat" runat="server" Width="85%" ValidationGroup="m_vlg_nha">
                </asp:DropDownList>
            </td>
            <td align="right" style="width: 15%">
            </td>
            <td align="left" style="width: 30%;">
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 15%">
                <span class="cssManField">Từ khóa</span>
            </td>
            <td>
                <asp:TextBox ID="m_txt_tu_khoa" runat="server" CssClass="cssTextBox" Width="85%"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="m_cmd_tim_kiem" runat="server" AccessKey="s" CssClass="cssButton"
                    Height="24px" Text="Tìm kiếm" Width="98px" OnClick="m_cmd_tim_kiem_Click" />
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <hr/>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="m_cmd_de_nghi_xu_ly" runat="server" Text="Đề nghị xử lý" CssClass="cssButton"
                    Height="24px" Width="98px" OnClick="m_cmd_de_nghi_xu_ly_Click" 
                    Enabled="False" />
                <asp:Button ID="m_cmd_huy_de_nghi_xu_ly" runat="server" Text="Hủy" CssClass="cssButton"
                    Height="24px" Width="98px" OnClick="m_cmd_huy_de_nghi_xu_ly_Click" 
                    Enabled="False" />
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
                    Width="100%" DataKeyNames="ID" CellPadding="0" ForeColor="#333333" AllowSorting="True"
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
                        <asp:HyperLinkField HeaderText="Tên tài sản" DataTextField="TEN_TAI_SAN" NavigateUrl="" />
                        <asp:BoundField HeaderText="Cấp hạng" DataField="CAP_HANG" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField HeaderText="Năm xây dựng" DataField="NAM_XAY_DUNG" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField HeaderText="Ngày, tháng, năm sử dụng" DataField="NGAY_THANG_NAM_SU_DUNG"
                            ItemStyle-HorizontalAlign="Center" />
                        <asp:TemplateField HeaderStyle-Width="25%" HeaderStyle-Height="75px">
                            <HeaderTemplate>
                                <table border="1" cellspacing="0" cellpadding="2" width="100%" style="border-collapse: collapse;">
                                    <tr>
                                        <td colspan="3" style="height: 20px">
                                            Giá trị theo sổ kế toán
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            Nguyên giá
                                        </td>
                                        <td rowspan="2" style="width: 33%; height: 55px">
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
                            <ItemTemplate>
                                <table border="0" cellspacing="0" cellpadding="2" width="100%" style="border-collapse: collapse;
                                    text-align: right">
                                    <td style="width: 33%; height: 60px; border-right: 1px solid gray;">
                                        <%# Eval("NGUON_NS", "{0:#,##0.00}")%>
                                    </td>
                                    <td style="width: 33%; height: 60px; border-right: 1px solid gray;">
                                        <%# Eval("NGUON_KHAC", "{0:#,##0.00}")%>
                                    </td>
                                    <td style="width: 33%; height: 50px;">
                                        <%# Eval("GIA_TRI_CON_LAI", "{0:#,##0.00}")%>
                                    </td>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Số tầng" DataField="SO_TANG" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField HeaderText="DT xây dựng" DataField="DT_XAY_DUNG" ItemStyle-HorizontalAlign="Right" />
                        <asp:BoundField HeaderText="Tổng DT xây dựng" DataField="TONG_DT_SAN_XD" ItemStyle-HorizontalAlign="Right" />
                        <asp:TemplateField HeaderStyle-Height="75px">
                            <HeaderTemplate>
                                <table border="1" cellspacing="0" cellpadding="2" width="100%" style="border-collapse: collapse;">
                                    <tr>
                                        <td colspan="7" style="height:20px">
                                            Hiện trạng sử dụng (m2)
                                        </td>
                                    </tr>
                                    <tr>
                                        <td rowspan="2" style="width: 14%; height:55px;">
                                            Trụ sở làm việc
                                        </td>
                                        <td rowspan="2" style="width: 14%">
                                            Cơ sở HĐSN
                                        </td>
                                        <td colspan="5">
                                            Sử dụng khác
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 14%">
                                            Làm nhà ở
                                        </td>
                                        <td style="width: 14%">
                                            Cho thuê
                                        </td>
                                        <td style="width: 14%">
                                            Bỏ trống
                                        </td>
                                        <td style="width: 14%">
                                            Bị lấn chiếm
                                        </td>
                                        <td style="width: 14%">
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
                                            <%# Eval("TRU_SO_LAM_VIEC", "{0:#,##0.00}")%>
                                        </td>
                                        <td style="width: 14%; border-right: 1px solid gray;">
                                            <%# Eval("CO_SO_HDSN", "{0:#,##0.00}")%>
                                        </td>
                                        <td style="width: 14%; border-right: 1px solid gray;">
                                            <%# Eval("LAM_NHA_O", "{0:#,##0.00}")%>
                                        </td>
                                        <td style="width: 14%; border-right: 1px solid gray;">
                                            <%# Eval("CHO_THUE", "{0:#,##0.00}")%>
                                        </td>
                                        <td style="width: 14%; border-right: 1px solid gray;">
                                            <%# Eval("BO_TRONG", "{0:#,##0.00}")%>
                                        </td>
                                        <td style="width: 14%; border-right: 1px solid gray;">
                                            <%# Eval("BI_LAN_CHIEM", "{0:#,##0.00}")%>
                                        </td>
                                        <td style="width: 14%">
                                            <%# Eval("KHAC", "{0:#,##0.00}")%>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
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
</asp:Content>
