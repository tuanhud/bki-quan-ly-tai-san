<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="F1000_Bao_cao_tong_cuc_truong.aspx.cs" Inherits="BaoCao_F1000_Bao_cao_tong_cuc_truong" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table cellspacing="0" cellpadding="2" style="width: 100%;" class="cssTable" border="0">
        <tr>
            <td class="cssPageTitleBG" colspan="6">
                <asp:Label ID="lblUser" runat="server" CssClass="cssPageTitle" Text="Phân quyền cho nhóm người dùng" />
            </td>
        </tr>
        <tr>
            <td colspan="6">
                <asp:ValidationSummary ID="vdsCategory" runat="server" CssClass="cssManField" Font-Bold="true" />
                <asp:Label ID="m_lbl_mess" runat="server" CssClass="cssManField" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:Label ID="lblFullName" CssClass="cssManField" runat="server" Text="Danh sách chủ quản" />
            </td>
            </tr>
        <tr>
            <td>
            </td>
            <td align="left" style="width: 30%;">
                <asp:DropDownList ID="m_ddl_don_vi_chu_quan" runat="server" Width="85%" ValidationGroup="m_vlg_nha"
                    OnSelectedIndexChanged="m_ddl_don_vi_chu_quan_SelectedIndexChanged" AutoPostBack="True">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:Label ID="lblFullName0" CssClass="cssManField" runat="server" Text="Danh sách đơn vị sử dụng" />
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:Label ID="lblFullName1" CssClass="cssManField" runat="server" Text="Danh sách loại báo cáo" />
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:Label ID="lblFllName2" CssClass="cssManField" runat="server" Text="Danh sách loại tài sản" />
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="right" width="100px">
                &nbsp;
            </td>
            <td width="300px">
                <asp:ListBox ID="m_lst_don_vi_su_dung" runat="server" Width="300px" Height="300px"
                    SelectionMode="Multiple"></asp:ListBox>
            </td>
            <td width="10px" align="center">
            </td>
            <td width="300px">
                <asp:ListBox ID="m_lst_loai_bao_cao" runat="server" Width="300px" Height="300px"
                    SelectionMode="Multiple"></asp:ListBox>
            </td>
            <td>
                &nbsp;
            </td>
            <td width="300px">
                <asp:ListBox ID="m_lst_loai_tai_san" runat="server" Width="300px" Height="300px"
                    SelectionMode="Multiple"></asp:ListBox>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
</asp:Content>
