<%@ page language="C#" masterpagefile="~/Site.master" autoeventwireup="true" enableeventvalidation="false" inherits="BaoCao_F208_BaoCaoDanhMucDat, App_Web_lvrqyice" %>

<%@ Import Namespace="WebUS" %>
<%@ Import Namespace="WebDS.CDBNames" %>
<%@ Register Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"
    TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
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
                            <span class="cssManField">Loại hình đơn vị:</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="m_cbo_loai_hinh_don_vi" runat="Server" OnSelectedIndexChanged="m_cbo_loai_hinh_don_vi_SelectedIndexChanged"
                                Width="90%" AutoPostBack="True">
                            </asp:DropDownList>
                        </td>
                        <td align="right">
                            <span class="cssManField">Đơn vị sử dụng tài sản:</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="m_cbo_don_vi_su_dung_tai_san" runat="Server" AutoPostBack="True"
                                TabIndex="3" Width="90%">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Label ID="m_lbl_tim_kiem" runat="server" CssClass="cssManField" 
                                Visible="False">Tìm kiếm:</asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="m_txt_tim_kiem" runat="Server" Width="90%" CssClass="cssTextBox"></asp:TextBox>
                        </td>
                        <td align="right">
                            <span class="cssManField">Trạng thái:</span>
                        </td>
                        <td>
                            <asp:DropDownList ID="m_cbo_trang_thai" runat="Server" TabIndex="4" Width="90%">
                            </asp:DropDownList>
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
                                Height="24px" Width="98px" Text="Lọc dữ liệu(l)" OnClick="m_cmd_tim_kiem_Click" />&nbsp;
                            <asp:Button ID="m_cmd_xuat_excel" AccessKey="x" CssClass="cssButton" runat="server"
                                Height="24px" Width="98px" Text="Xuất Excel (x)" OnClick="m_cmd_xuat_excel_Click" />&nbsp;
                        </td>
                    </tr>
                </table>
                <table cellspacing="0" cellpadding="2" style="width: 100%;" class="cssTable" border="0">
                    <tr>
                        <td class="cssPageTitleBG" colspan="6">
                            <asp:Label ID="m_lbl_title" runat="server" Text="DANH MỤC ĐẤT" CssClass="cssPageTitle"></asp:Label><span
                                class="expand-collapse-text initial-expand"> </span><span class="expand-collapse-text">
                                </span>
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
                            <asp:GridView ID="m_grv_danh_sach_dat" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                Width="100%" DataKeyNames="ID" CellPadding="4" ForeColor="#333333" AllowSorting="True"
                                EmptyDataText="Không có dữ liệu phù hợp" PageSize="15" ShowHeader="true" OnPageIndexChanging="m_grv_danh_sach_dat_PageIndexChanging">
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
                                    <asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Chi tiết">
                                        <ItemTemplate>
                                            <asp:HyperLink ID="m_lnk_lop_mon_detail" runat="server" Target="_blank" ToolTip="Xem chi tiết"
                                                NavigateUrl='<%# "~/ChucNang/F101_QuanLyDat.aspx?"+CONST_QLDB.MA_THAM_SO_URL.ID_DAT+"="+Eval(V_DM_DAT.ID) %>'
                                                ImageUrl="~/Images/Button/detail.png">Chi tiết</asp:HyperLink>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Mã tài sản" DataField="MA_TAI_SAN" />
                                    <asp:BoundField HeaderText="Đơn vị bộ tỉnh" DataField="TEN_DV_BO_TINH" Visible="false"/>
                                    <asp:BoundField HeaderText="Đơn vị chủ quản" DataField="TEN_DV_CHU_QUAN" Visible="false"/>
                                    <asp:BoundField HeaderText="Đơn vị sử dụng" DataField="TEN_DV_SU_DUNG" />
                                    <asp:BoundField HeaderText="Trạng thái" DataField="TEN_TRANG_THAI" />
                                    <asp:BoundField HeaderText="Tình trạng" DataField="TEN_TINH_TRANG" />
                                    <asp:BoundField HeaderText="Địa chỉ" DataField="DIA_CHI" />
                                    <asp:BoundField HeaderText="DT Khuôn viên (m2)" DataField="DT_KHUON_VIEN" ItemStyle-HorizontalAlign="Right"
                                        DataFormatString="{0:#,##0}" />
                                    <asp:BoundField HeaderText="DT Trụ sở làm việc (m2)" DataField="DT_TRU_SO_LAM_VIEC"
                                        ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,###}" />
                                    <asp:BoundField HeaderText="DT Cơ sở hoạt động sự nghiệp (m2)" DataField="DT_CO_SO_HOAT_DONG_SU_NGHIEP"
                                        ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,###}" />
                                    <asp:BoundField HeaderText="DT Làm nhà ở (m2)" DataField="DT_LAM_NHA_O" ItemStyle-HorizontalAlign="Right"
                                        DataFormatString="{0:#,###}" />
                                    <asp:BoundField HeaderText="DT Cho thuê (m2)" DataField="DT_CHO_THUE" ItemStyle-HorizontalAlign="Right"
                                        DataFormatString="{0:#,###}" />
                                    <asp:BoundField HeaderText="DT Bỏ trống (m2)" DataField="DT_BO_TRONG" ItemStyle-HorizontalAlign="Right"
                                        DataFormatString="{0:#,###}" />
                                    <asp:BoundField HeaderText="DT Bị lấn chiếm (m2)" DataField="DT_BI_LAN_CHIEM" ItemStyle-HorizontalAlign="Right"
                                        DataFormatString="{0:#,###}" />
                                    <asp:BoundField HeaderText="DT Sử dụng mục đích khác (m2)" DataField="DT_SU_DUNG_MUC_DICH_KHAC"
                                        ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,###}" />
                                    <asp:BoundField HeaderText="Giá trị theo số kế toán (ngàn đồng)" DataField="GT_THEO_SO_KE_TOAN"
                                        ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,###}" />
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
