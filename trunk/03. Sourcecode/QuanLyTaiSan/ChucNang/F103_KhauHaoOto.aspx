<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="F103_KhauHaoOto.aspx.cs" Inherits="ChucNang_F103_KhauHaoOto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table cellspacing="0" cellpadding="2" style="width: 99%;" class="cssTable" border="0">
        <tr>
            <td class="cssPageTitleBG" colspan="4">
                <span class="cssPageTitle">Danh sách nhà</span> <span class="expand-collapse-text initial-expand">
                </span><span class="expand-collapse-text"></span>
            </td>
        </tr>
    </table>
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
            <td align="right" style="width: 15%"><span class="cssManField">Tên nhà</span></td>
            <td>
                <asp:TextBox ID="m_txt_tu_khoa" CssClass="cssTextBox" Width="85%" runat="server"></asp:TextBox></td>
            <td></td>
            <td></td>
        </tr>
    </table>
</asp:Content>
