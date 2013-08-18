<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="F302_khau_hao_nha.aspx.cs" Inherits="ChucNang_F302_khau_hao_nha" %>

<%@ Register Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"
    TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script type="text/javascript">
        $(function () {
            $(".tb").autocomplete({
                source: function (request, response) {
                    $.ajax({
                        url: "../ChucNang/PersonService.asmx/GetNha",
                        data: "{ 'name_prefix': '" + request.term + "', 'ip_dc_id_dat': '"
                        + document.getElementById('<%= m_cbo_thuoc_khu_dat.ClientID%>').value + "' }",
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
<asp:Content ID="Content2" ContentPlaceHolderID ="MainContent" runat="Server">
    <table border="0" cellspacing="0" cellpadding="0" width="100%">
        <tr>
            <td class="cssPageTitleBG" colspan="6">
                <span class="cssPageTitle">KHẤU HAO TÀI SẢN NHÀ</span> <span class="expand-collapse-text initial-expand">
                </span><span class="expand-collapse-text"></span>
            </td>
        </tr>
        <tr>
            <td colspan="6">
                <asp:ValidationSummary id="vdsCategory" runat="server" cssclass="cssManField" font-bold="true"
                    ValidationGroup="m_vlg_nha" />
                <asp:label id="m_lbl_mess" runat="server" cssclass="cssManField" />
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <table cellspacing="0" cellpadding="2" style="width: 100%;" class="cssTable" border="0">
                    <tr>
                        <td align="right" style="width: 20%">
                            <span class="cssManField">Bộ, tỉnh</span>
                        </td>
                        <td style="width: 29%" align="left">
                            <asp:dropdownlist id="m_cbo_bo_tinh_up" runat="server" width="85%" validationgroup="m_vlg_nha"
                                autopostback="True" onselectedindexchanged="m_cbo_bo_tinh_up_SelectedIndexChanged">
                            </asp:dropdownlist>
                        </td>
                        <td style="width: 1%">
                        </td>
                        <td align="right" style="width: 20%">
                            <span class="cssManField">Đơn vị chủ quản</span>
                        </td>
                        <td align="left" style="width: 29%;">
                            <asp:dropdownlist id="m_cbo_don_vi_chu_quan_up" runat="server" width="85%" validationgroup="m_vlg_nha"
                                autopostback="True" onselectedindexchanged="m_cbo_don_vi_chu_quan_up_SelectedIndexChanged">
                            </asp:dropdownlist>
                        </td>
                        <td style="width: 1%">
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <span class="cssManField">Đơn vị sử dụng</span>
                        </td>
                        <td align="left">
                            <asp:dropdownlist id="m_cbo_don_vi_su_dung_up" runat="server" width="85%" validationgroup="m_vlg_nha"
                                autopostback="True" onselectedindexchanged="m_cbo_don_vi_su_dung_up_SelectedIndexChanged">
                            </asp:dropdownlist>
                        </td>
                        <td>
                        </td>
                        <td align="right">
                            <span class="cssManField">Trạng thái nhà</span>
                        </td>
                        <td align="left">
                            <asp:dropdownlist id="m_cbo_trang_thai_nha_up" runat="server" width="85%" validationgroup="m_vlg_nha"
                                enabled="false">
                            </asp:dropdownlist>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <span class="cssManField">Thuộc khu đất</span>
                        </td>
                        <td align="left">
                            <asp:dropdownlist id="m_cbo_thuoc_khu_dat" runat="server" width="85%" validationgroup="m_vlg_nha">
                            </asp:dropdownlist>
                        </td>
                        <td>
                        </td>
                        <td align="right">
                            <span class="cssManField">Nhà</span>
                        </td>
                        <td align="left">
                            <asp:textbox id="m_txt_nha" class="tb" runat="server" width="85%" validationgroup="m_vlg_nha"
                                autopostback="True" ontextchanged="m_txt_nha_TextChanged">
                            </asp:textbox>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <span class="cssManField">Tên tài sản</span>
                        </td>
                        <td align="left">
                            <asp:label id="m_lbl_ten_tai_san" runat="Server" class="cssManField" style="color: blue">
                            </asp:label>
                        </td>
                        <td>
                        </td>
                        <td align="right">
                            <span class="cssManField">Mã tài sản</span>
                        </td>
                        <td>
                            <asp:label id="m_lbl_ma_tai_san" runat="Server" class="cssManField" style="color: blue">
                            </asp:label>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 15%">
                            <span class="cssManField">Cấp hạng</span>
                        </td>
                        <td>
                            <asp:label id="m_lbl_cap_hang" runat="Server" class="cssManField" style="color: blue">
                            </asp:label>
                        </td>
                        <td>
                        </td>
                        <td align="right">
                            <span class="cssManField">Năm xây dựng</span>
                        </td>
                        <td align="left">
                            <asp:label id="m_lbl_nam_xay_dung" runat="Server" class="cssManField" style="color: blue">
                            </asp:label>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 20%">
                            <span class="cssManField">Ngày, tháng, năm sử dụng</span>
                        </td>
                        <td style="width: 29%" align="left">
                            <asp:label id="m_lbl_ngay_thang_nam_du_dung" runat="Server" class="cssManField" style="color: blue">
                            </asp:label>
                        </td>
                        <td align="right" style="width: 1%">
                        </td>
                        <td align="left" style="width: 20%;">
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center" class="cssManField">
                            <span>GIÁ TRỊ CÒN LẠI</span>
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
                        <td align="left">
                            <asp:label id="m_lbl_nguyen_gia_nguon_ns" runat="Server" class="cssManField" style="color: blue">
                            </asp:label>
                        </td>
                        <td>
                        </td>
                        <td align="right">
                            <span class="cssManField">Nguyên giá nguồn khác (VNĐ)</span>
                        </td>
                        <td align="left">
                            <asp:label id="m_lbl_nguyen_gia_nguon_khac" runat="Server" class="cssManField" style="color: blue">
                            </asp:label>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <span class="cssManField">Giá trị còn lại (VNĐ)</span>
                        </td>
                        <td align="left">
                            <asp:label id="m_lbl_gia_tri_con_lai" runat="Server" class="cssManField" style="color: blue">
                            </asp:label>
                        </td>
                    </tr>
                    <tr>
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
                            <asp:textbox id="m_txt_ma_phieu" runat="server" cssclass="cssTextBox csscurrency" width="85%"
                                validationgroup="m_vlg_nha">
                            </asp:textbox>
                        </td>
                        <td align="left" style="width: 1%;">
                            <asp:requiredfieldvalidator id="m_rfv_ma_phieu" runat="server" controltovalidate="m_txt_ma_phieu"
                                errormessage="Bạn phải nhập Mã Phiếu" text="*" validationgroup="m_vlg_nha" forecolor="Red">
                            </asp:requiredfieldvalidator>
                        </td>
                        <td colspan="1" style="width: 20%" align="right" class="cssManField">
                            <span>Giá trị khấu hao </span>
                        </td>
                        <td>
                            <asp:textbox id="m_txt_gia_tri_khau_hao" runat="server" cssclass="cssTextBox csscurrency"
                                width="85%" validationgroup="m_vlg_nha">
                            </asp:textbox>
                        </td>
                        <td align="left" style="width: 1%;">
                            <asp:requiredfieldvalidator id="m_rfv_gia_tri_khau_hao" runat="server" controltovalidate="m_txt_gia_tri_khau_hao"
                                errormessage="Bạn phải nhập Giá Trị Khấu Hao" text="*" validationgroup="m_vlg_nha"
                                forecolor="Red">
                            </asp:requiredfieldvalidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="1" align="right" class="cssManField">
                            <span>Ngày lập </span>
                        </td>
                        <td style="width: 29%" align="left">
                            <asp:textbox id="m_txt_ngay_lap" runat="server" cssclass="cssTextBox" width="85%"
                                validationgroup="m_vlg_nha">
                            </asp:textbox>
                        </td>
                        <td align="left" style="width: 1%" class="cssManField">
                            <asp:requiredfieldvalidator id="m_rfv_ngay_lap" runat="Server" controltovalidate="m_txt_ngay_lap"
                                errormessage="Bạn phải nhập đúng Ngày Lập" text="*" validationgroup="m_vlg_nha">
                            </asp:requiredfieldvalidator>
                        </td>
                        <td align="right" class="cssManField">
                            <span>Ngày duyệt </span>
                        </td>
                        <td style="width: 29%" align="left">
                            <asp:textbox id="m_txt_ngay_duyet" runat="Server" cssclass=" cssTextBox" width="85%"
                                validationgroup="m_vlg_nha">
                            </asp:textbox>
                        </td>
                        <td align="left" style="width: 1%;">
                            <asp:requiredfieldvalidator id="m_rfv_ngay_duyet" runat="server" controltovalidate="m_txt_ngay_duyet"
                                errormessage="Bạn phải nhập Ngày Duyệt" text="*" validationgroup="m_vlg_nha"
                                forecolor="Red">
                            </asp:requiredfieldvalidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4" align="center">
                            <asp:button id="m_cmd_tao_moi" accesskey="c" cssclass="cssButton" runat="server"
                                height="24px" width="98px" text="Tạo mới(c)" validationgroup="m_vlg_nha" onclick="m_cmd_tao_moi_Click" />
                            <asp:button id="m_cmd_xoa_trang" accesskey="r" cssclass="cssButton" runat="server"
                                height="24px" width="98px" text="Xóa trắng(r)" onclick="m_cmd_xoa_trang_Click" />
                            <asp:hiddenfield id="m_hdf_id" runat="server" value="" onvaluechanged="m_hdf_id_ValueChanged" />
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table cellspacing="0" cellpadding="2" style="width: 100%;" class="cssTable" border="0">
        <tr>
            <td class="cssPageTitleBG" colspan="6">
                <span class="cssPageTitle">Chọn nhà</span> <span class="expand-collapse-text initial-expand">
                </span><span class="expand-collapse-text"></span>
            </td>
        </tr>
        <tr>
            <td align="right" colspan="1" style="width: 20%">
                <span class="cssManField">Bộ, tỉnh </span>
            </td>
            <td style="width: 30%" colspan="1">
                <asp:dropdownlist id="m_cbo_bo_tinh_down" width="85%" runat="Server" autopostback="True"
                    tabindex="1" onselectedindexchanged="m_cbo_bo_tinh_down_SelectedIndexChanged">
                </asp:dropdownlist>
            </td>
            <td align="right" style="width: 20%" colspan="1">
                <span class="cssManField">Đơn vị chủ quản </span>
            </td>
            <td style="width: 30%" colspan="1">
                <asp:dropdownlist id="m_cbo_don_vi_chu_quan_down" width="85%" runat="Server" autopostback="True"
                    tabindex="2" onselectedindexchanged="m_cbo_don_vi_chu_quan_down_SelectedIndexChanged">
                </asp:dropdownlist>
            </td>
        </tr>
        <tr>
            <td align="right">
                <span class="cssManField">Đơn vị sử dụng tài sản </span>
            </td>
            <td>
                <asp:dropdownlist id="m_cbo_don_vi_su_dung_down" width="85%" runat="Server" autopostback="True"
                    tabindex="3" onselectedindexchanged="m_cbo_don_vi_su_dung_down_SelectedIndexChanged">
                </asp:dropdownlist>
            </td>
            <td align="right">
                <span class="cssManField">Địa chỉ đất </span>
            </td>
            <td>
                <asp:dropdownlist id="m_cbo_dia_chi" runat="Server" width="85%" tabindex="4">
                </asp:dropdownlist>
            </td>
        </tr>
        <tr>
            <td align="right" colspan="1" style="width: 20%">
                <span class="cssManField">Từ khóa </span>
            </td>
            <td style="width: 30%" colspan="1">
                <asp:textbox id="m_txt_tu_khoa" runat="server" cssclass="cssTextBox" width="85%">
                </asp:textbox>
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
                <asp:button id="m_cmd_tim_kiem" runat="server" accesskey="s" cssclass="cssButton"
                    height="24px" text="Tìm kiếm" width="98px" onclick="m_cmd_tim_kiem_Click" />
            </td>
            <td align="left">
                <asp:button id="m_cmd_xuat_excel" runat="server" causesvalidation="False" cssclass="cssButton"
                    height="25px" text="Xuất Excel" width="98px" onclick="m_cmd_xuat_excel_Click" />
            </td>
            <td align="left">
            </td>
        </tr>
        <tr>
            <td align="left" colspan="2">
                <asp:label id="m_lbl_thong_bao" visible="false" runat="server" cssclass="cssManField" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="4" style="height: 450px;" valign="top">
                <asp:gridview id="m_grv_danh_sach_nha" runat="server" allowpaging="True" autogeneratecolumns="False"
                    width="100%" datakeynames="ID" cellpadding="0" forecolor="#333333" allowsorting="True"
                    emptydatatext="Không có dữ liệu phù hợp" pagesize="15" showheader="true" onpageindexchanging="m_grv_danh_sach_nha_PageIndexChanging"
                    onrowcommand="m_grv_danh_sach_nha_RowCommand">
                    <columns>
                        <asp:TemplateField HeaderText="Xóa" ItemStyle-Width="2%">
                            <ItemTemplate>
                                <asp:LinkButton ID="m_lbt_delete" runat="server" CommandName="DeleteComp" ToolTip="Xóa"
                                    OnClientClick="return confirm ('Bạn có thực sự muốn xóa bản ghi này?')" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'>
                                    <img src="../Images/Button/deletered.png" alt="Delete" />
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sửa" ItemStyle-Width="2%">
                            <ItemTemplate>
                                <asp:LinkButton ID="m_lbt_edit" runat="server" CommandName="EditComp" ToolTip="Sửa"
                                    CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'>
                                    <img src="../Images/Button/edit.png" alt="Edit" />
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Chi tiết tài sản" Visible="false">
                            <ItemTemplate>
                                <asp:HyperLink ToolTip="Chi tiết tài sản" ImageUrl="../Images/Button/detail.png"
                                    ID="lbt_hop_dong_gv" runat="server" NavigateUrl=''></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Mã phiếu" DataField="MA_PHIEU" />
                        <asp:HyperLinkField HeaderText="Tên tài sản" DataTextField="TEN_TAI_SAN" NavigateUrl="" />
                        <asp:BoundField HeaderText="Địa chỉ" DataField="DIA_CHI" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField HeaderText="Cấp hạng" DataField="CAP_HANG" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField HeaderText="Năm xây dựng" DataField="NAM_XAY_DUNG" ItemStyle-HorizontalAlign="Center" />
                        <asp:BoundField HeaderText="Ngày, tháng, năm sử dụng" DataField="NGAY_THANG_NAM_SU_DUNG"
                            ItemStyle-HorizontalAlign="Center" />
                        <asp:TemplateField HeaderStyle-Width="25%" HeaderStyle-Height="110px">
                            <HeaderTemplate>
                                <table border="1" cellspacing="0" cellpadding="2" width="100%" style="border-collapse: collapse;">
                                    <tr>
                                        <td colspan="3" style="height: 50px">
                                            GIÁ TRỊ THEO SỔ KẾ TOÁN
                                            <br />
                                            (ngàn đồng)
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            Nguyên giá
                                        </td>
                                        <td rowspan="2" style="width: 33%; height: 60px">
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
                                    <td style="width: 33%; height: 60px;">
                                        <%# Eval("GIA_TRI_CON_LAI", "{0:#,##0.00}")%>
                                    </td>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Giá trị khấu hao" DataField="GIA_TRI_KHAU_HAO" />
                        <asp:BoundField HeaderText="Ngày lập" DataField="NGAY_LAP" />
                        <asp:BoundField HeaderText="Ngày duyệt" DataField="NGAY_DUYET" />
                    </columns>
                    <alternatingrowstyle backcolor="White" />
                    <editrowstyle backcolor="#7C6F57" />
                    <footerstyle backcolor="#1C5E55" font-bold="True" forecolor="White" />
                    <headerstyle backcolor="#810c15" font-bold="True" forecolor="White" />
                    <pagersettings position="TopAndBottom" />
                    <pagerstyle backcolor="#666666" forecolor="White" horizontalalign="Center" />
                    <rowstyle backcolor="#E3EAEB" />
                    <selectedrowstyle cssclass="cssSelectedRow" backcolor="#C5BBAF" font-bold="True"
                        forecolor="#333333"></selectedrowstyle>
                </asp:gridview>
            </td>
        </tr>
    </table>
</asp:content>
