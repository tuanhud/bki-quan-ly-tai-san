<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="F202_DeNghiXuLyTaiSanKhac.aspx.cs" Inherits="Default2" %>

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
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table cellspacing="0" cellpadding="2" style="width: 100%;" class="cssTable" border="0">
                    <tr>
                        <td class="cssPageTitleBG" colspan="4">
                            <asp:Label ID="m_lbl_tieu_de" runat="Server" class="cssPageTitle"></asp:Label>
                            <span class="expand-collapse-text initial-expand"></span><span class="expand-collapse-text">
                            </span>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:ValidationSummary ID="vdsCategory" runat="server" CssClass="cssManField" Font-Bold="true" />
                            <asp:Label ID="m_lbl_mess" runat="server" CssClass="cssManField" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 15%;">
                            &nbsp;
                        </td>
                        <td style="width: 20%;">
                            &nbsp;
                        </td>
                        <td align="right" style="width: 15%;">
                            &nbsp;
                        </td>
                        <td style="width: 20%;">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="right" colspan="1" style="width: 15%">
                            <span class="cssManField">Bộ, tỉnh:</span>
                        </td>
                        <td style="width: 35%">
                            <asp:DropDownList ID="m_cbo_bo_tinh" Width="90%" runat="Server" AutoPostBack="True"
                                OnSelectedIndexChanged="m_cbo_bo_tinh_SelectedIndexChanged" TabIndex="1">
                            </asp:DropDownList>
                        </td>
                        <td align="right" style="width: 15%">
                            <span class="cssManField">Đơn vị chủ quản:</span>
                        </td>
                        <td style="width: 35%">
                            <asp:DropDownList ID="m_cbo_don_vi_chu_quan" Width="90%" runat="Server" AutoPostBack="True"
                                OnSelectedIndexChanged="m_cbo_don_vi_chu_quan_SelectedIndexChanged" TabIndex="2">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            &nbsp;<span class="cssManField">Loại hình đơn vị:</span></td>
                        <td>
                            <asp:DropDownList ID="m_cbo_loai_hinh_don_vi" runat="Server" 
                                onselectedindexchanged="m_cbo_loai_hinh_don_vi_SelectedIndexChanged" 
                                Width="90%" AutoPostBack="True">
                            </asp:DropDownList>
                        </td>
                        <td align="right">
                            <span class="cssManField">Đơn vị sử dụng tài sản:</span></td>
                        <td>
                            <asp:DropDownList ID="m_cbo_don_vi_su_dung_tai_san" runat="Server" 
                                AutoPostBack="True" TabIndex="3" 
                                Width="90%">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            &nbsp;<span class="cssManField">Trạng thái: </span>
                        </td>
                        <td>
                            <asp:DropDownList ID="m_cbo_trang_thai" runat="Server" 
                                TabIndex="4" Width="90%">
                            </asp:DropDownList>
                        </td>
                        <td align="left" colspan ="2" rowspan = "2">
                           
                            <span class="cssManField">
                            Chú ý:
                            <br />
                            - Chọn trạng thái "1-Đang sử dụng"-> Ấn tìm kiếm -> Chọn tài sản lập đề nghị xử lý
                            <br />- Chọn trạng thái "2-Đề nghị xử lý"-> Ấn tìm kiếm -> Chọn tài sản hủy đề nghị xử lý
                        </span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <span class="cssManField">Từ khóa tìm kiếm:</span>
                        </td>
                        <td>
                            <asp:TextBox ID="m_txt_tim_kiem" runat="server" CssClass="cssTextBox" Width="90%"></asp:TextBox>
                        </td>
                        <td align="right">
                            <span class="cssManField">&nbsp;</span>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            &nbsp;
                        </td>
                        <td valign="top" colspan="2">
                            <asp:HiddenField ID="hdf_id" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td colspan="2" align="left">
                            <asp:Button ID="m_cmd_tim_kiem" AccessKey="l" CssClass="cssButton" runat="server"
                                Height="24px" Width="98px" Text="Tìm kiếm(s)" OnClick="m_cmd_tim_kiem_Click" />&nbsp;
                            &nbsp;
                        </td>
                    </tr>
                </table>
                <table cellspacing="0" cellpadding="2" style="width: 100%;" class="cssTable" border="0">
                    <tr>
                        <td class="cssPageTitleBG" colspan="6">
                        <asp:Label ID="m_lbl_title" runat="server" Text="DANH MỤC TÀI SẢN KHÁC (TRỪ TRỤ SỞ LÀM VIỆC, CƠ SỞ HOẠT ĐỘNG
                                SỰ NGHIỆP VÀ XE Ô TÔ)" CssClass="cssPageTitle"></asp:Label><span class="expand-collapse-text initial-expand">
                            </span><span class="expand-collapse-text"></span>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                        </td>
                        <td align="left">
                            <asp:Button ID="m_cmd_de_nghi_xu_ly" runat="server" AccessKey="c" CssClass="cssButton"
                                Text="Đề nghị xử lý" Height="24px" Width="98px" OnClick="m_cmd_de_nghi_xu_ly_Click" />
                            <asp:Button ID="m_cmd_huy_de_nghi_xu_ly" runat="server" CssClass="cssButton" Height="24px"
                                Text="Hủy" Width="98px" OnClick="m_cmd_huy_de_nghi_xu_ly_Click" />
                        </td>
                        <td align="left">
                        </td>
                        <td align="left">
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                        </td>
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
                            <asp:GridView ID="m_grv_danh_sach_tai_san_khac" runat="server" AllowPaging="True"
                                AutoGenerateColumns="False" Width="100%" DataKeyNames="ID" CellPadding="0" ForeColor="#333333"
                                AllowSorting="True" PageSize="15" ShowHeader="true" EmptyDataText="Không có dữ liệu phù hợp"
                                OnPageIndexChanging="m_grv_danh_sach_tai_san_khac_PageIndexChanging">
                                <Columns>
                                    <asp:TemplateField HeaderText="Chi tiết tài sản" Visible="false">
                                        <ItemTemplate>
                                            <asp:HyperLink ToolTip="Chi tiết tài sản" ImageUrl="../Images/Button/detail.png"
                                                ID="lbt_hop_dong_gv" runat="server" NavigateUrl=''></asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Select">
                                        <ItemTemplate>
                                            <asp:CheckBox runat="server" ID="chkItem" ToolTip='<%# Eval("ID") %>' />
                                            <asp:CheckBox runat="server" ID="chkTrangThai" Visible="false" />
                                        </ItemTemplate>
                                        <HeaderTemplate>
                                            <input type="checkbox" id="chkAll" onclick="javascript:SelectAllCheckboxes(this)"
                                                runat="server" />
                                        </HeaderTemplate>
                                    </asp:TemplateField>
                                    <asp:HyperLinkField HeaderText="Tên tài sản" DataTextField="TEN_TAI_SAN"
                                        NavigateUrl="" HeaderStyle-Width="20%" />
                                    <asp:BoundField HeaderText="Ký hiệu" DataField="KY_HIEU" />
                                    <asp:BoundField HeaderText="Năm sản xuất" ItemStyle-HorizontalAlign="Center" DataField="NAM_SAN_XUAT"
                                        HeaderStyle-Width="3.5%">
                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:BoundField HeaderText="Năm sử dụng" ItemStyle-HorizontalAlign="Center" DataField="NAM_SU_DUNG"
                                        HeaderStyle-Width="3.5%" />
                                    <asp:TemplateField HeaderStyle-Width="25%" HeaderStyle-Height="75px">
                                        <HeaderTemplate>
                                            <table border="1" cellspacing="0" cellpadding="3" width="100%" style="border-collapse: collapse;">
                                                <tr>
                                                    <td colspan="3" style="height: 35px">
                                                        Giá trị theo sổ kế toán (VNĐ)
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" style="width: 66%">
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
                                            <table border="0" cellspacing="0" cellpadding="2" width="100%" style="border-collapse: collapse;
                                                text-align: right">
                                                <tr>
                                                    <td style="width: 33%; border-right: solid; border-right-width: 1px" height="40px">
                                                        <%# Eval("NGUON_NS", "{0:#,###}")%>
                                                    </td>
                                                    <td style="width: 33%; border-right: solid; border-right-width: 1px">
                                                        <%# Eval("NGUON_KHAC", "{0:#,###}")%>
                                                    </td>
                                                    <td style="width: 33%">
                                                        <%# Eval("GIA_TRI_CON_LAI", "{0:#,###}")%>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            <table border="1" cellspacing="0" cellpadding="2" width="100%" style="border-collapse: collapse;">
                                                <tr>
                                                    <td colspan="7" style="height: 39px">
                                                        Hiện trạng sử dụng
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td rowspan="2" style="width: 25%">
                                                        Quản lý nhà nước
                                                    </td>
                                                    <td colspan="2" style="width: 50%">
                                                        Hoạt đông sự nghiệp
                                                    </td>
                                                    <td rowspan="2" style="width: 25%">
                                                        Khác
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 25%">
                                                        Kinh doanh
                                                    </td>
                                                    <td style="width: 25%">
                                                        Không kinh doanh
                                                    </td>
                                                </tr>
                                            </table>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <table border="0" cellspacing="0" cellpadding="2" width="100%" style="text-align: right;
                                                border-collapse: collapse;">
                                                <tr>
                                                    <td style="width: 25%; border-right: solid; border-right-width: 1px" height="40px">
                                                        <%# Eval("QLNN", "{0:#,###}")%>
                                                    </td>
                                                    <td style="width: 25%; border-right: solid; border-right-width: 1px">
                                                        <%# Eval("KINH_DOANH", "{0:#,###}")%>
                                                    </td>
                                                    <td style="width: 25%; border-right: solid; border-right-width: 1px">
                                                        <%# Eval("KHONG_KINH_DOANH", "{0:#,###}")%>
                                                    </td>
                                                    <td style="width: 25%">
                                                        <%# Eval("HD_KHAC", "{0:#,###}")%>
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
            </ContentTemplate>
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
