<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="F901_danh_muc_don_vi.aspx.cs" Inherits="DanhMuc_F901_danh_muc_don_vi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table cellspacing="0" cellpadding="2" style="width: 99%;" class="cssTable" border="0">
        <tr>
            <td class="cssPageTitleBG" colspan="4">
                <span class="cssPageTitle">Danh mục đơn vị</span> <span class="expand-collapse-text initial-expand">
                </span><span class="expand-collapse-text"></span>
            </td>
        </tr>
        <tr>
            <td align="right">
			<asp:label id="Label6" CssClass="cssManField" runat="server" 
                Text="Mã đơn vị"/>
		    </td>
            <td>
			<asp:textbox id="m_txt_ho_va_ten1" CssClass="cssTextBox"  runat="server" 
                MaxLength="25" Width="200px" />
		    </td>
            <td align="right">
			<asp:label id="Label7" CssClass="cssManField" runat="server" 
                Text="Tên đơn vị"/>
		    </td>
            <td>
			<asp:textbox id="m_txt_ho_va_ten2" CssClass="cssTextBox"  runat="server" 
                MaxLength="25" Width="200px" />
		    </td>
        </tr>
        <tr>
            <td align="right">
			<asp:label id="Label8" CssClass="cssManField" runat="server" 
                Text="Loại hình đơn vị"/>
		    </td>
            <td>
			<asp:textbox id="m_txt_ho_va_ten3" CssClass="cssTextBox"  runat="server" 
                MaxLength="25" Width="200px" />
		    </td>
            <td align="right">
			<asp:label id="Label9" CssClass="cssManField" runat="server" 
                Text="Đơn vị cấp trên"/>
		    </td>
            <td>
			<asp:textbox id="m_txt_ho_va_ten4" CssClass="cssTextBox"  runat="server" 
                MaxLength="25" Width="200px" />
		    </td>
        </tr>
        <tr>
            <td align="right">
			<asp:label id="Label10" CssClass="cssManField" runat="server" 
                Text="STT"/>
		    </td>
            <td>
			<asp:textbox id="m_txt_ho_va_ten5" CssClass="cssTextBox"  runat="server" 
                MaxLength="25" Width="200px" />
		    </td>
            <td align="right">
			<asp:label id="Label11" CssClass="cssManField" runat="server" 
                Text="Level Mode"/>
		    </td>
            <td>
			<asp:textbox id="m_txt_ho_va_ten6" CssClass="cssTextBox"  runat="server" 
                MaxLength="25" Width="200px" />
		    </td>
        </tr>
        </table>
    <table cellspacing="0" cellpadding="2" style="width:100%;" class="cssTable" border="0">
	<tr>
		<td align="center">
			<asp:button id="m_cmd_tao_moi" accessKey="c" CssClass="cssButton" 
                runat="server" Width="98px" Text="Tạo mới(c)" />&nbsp;
			<asp:button id="m_cmd_cap_nhat" accessKey="u" CssClass="cssButton" 
                runat="server" Width="98px" Text="Cập nhật(u)" />&nbsp;
			<asp:button id="btnCancel" accessKey="r" CssClass="cssButton" runat="server" 
                Width="98px" Text="Xóa trắng(r)"/>
		</td>
	</tr>
</table>
</asp:Content>

