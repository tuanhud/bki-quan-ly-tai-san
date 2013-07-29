<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="F910_Danh_muc_trang_thai.aspx.cs" Inherits="DanhMuc_F910_Danh_muc_trang_thai" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .style1
        {
            height: 26px;
        }
        .style2
        {
            height: 37px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <table cellspacing="0" cellpadding="2" style="width:100%;" class="cssTable" border="0">
        <tr>
		<td class="cssPageTitleBG" colspan="4">
		    <asp:label id="lblUser0" runat="server" CssClass="cssPageTitle" 
                Text="Quản lý trạng thái"/>
		</td>
	    </tr>
        <tr>
            <td align="right">
            <asp:Label ID="m_lbl_loai_tai_san_detail0" runat="server" CssClass="cssManField" 
                Text="Loại" />
            </td>
            <td>
		    <asp:DropDownList id="m_cbo_loai_tai_san_detail" runat="server" Width="264px" 
                CssClass="cssDorpdownlist" AutoPostBack = "true"/>
		    </td>
            <td align="right">
            <asp:Label ID="m_lbl_ghi_chu8" runat="server" CssClass="cssManField" 
                Text="Tên trạng thái" />
            </td>
            <td>
		    <asp:textbox id="m_txt_ten_trang_thai" accessKey="m" runat="server"  
                    Width="150px" />
		    </td>
        </tr>
        <tr>
            <td align="right">
            <asp:Label ID="m_lbl_loai_tai_san_detail" runat="server" CssClass="cssManField" 
                Text="Mã từ điển" />
            </td>
            <td>
		    <asp:textbox id="m_txt_ma_tu_dien" accessKey="m" runat="server"  
                    Width="150px" />
		    </td>
            <td>
                &nbsp;</td>
            <td>
		        &nbsp;</td>
        </tr>
        <tr>
            <td class="style2" align="right">
            <asp:Label ID="m_lbl_ghi_chu" runat="server" CssClass="cssManField" 
                Text="Ghi chú" />
            </td>
            <td colspan="3" class="style2">
		    <asp:textbox id="m_txt_ghi_chu" accessKey="m" runat="server"  Width="350px" 
                TextMode="MultiLine" />
		    </td>
        </tr>
        <tr>
		<td colspan="4" align="center">
			<asp:button id="m_cmd_tao_moi" accessKey="c" CssClass="cssButton" 
                runat="server" Width="98px" Text="Tạo mới(c)" 
                onclick="m_cmd_tao_moi_Click"  />&nbsp;
			<asp:button id="m_cmd_cap_nhat" accessKey="u" CssClass="cssButton" 
                runat="server" Width="98px" Text="Cập nhật(u)" 
                onclick="m_cmd_cap_nhat_Click" />&nbsp;
			<asp:button id="btnCancel" accessKey="r" CssClass="cssButton" runat="server" 
                Width="98px" Text="Xóa trắng(r)" onclick="btnCancel_Click"/>
		</td>
	    </tr>
        <tr>
            <td class="cssPageTitleBG" colspan="4">
                <asp:label id="lblUser" runat="server" CssClass="cssPageTitle" 
                Text="Danh mục trạng thái"/>
            </td>
        </tr>
        <tr>
		<td align="left">
                <asp:label id="m_lbl_mess" Visible="False" runat="server" 
                    CssClass="cssManField" />
        </td>
        <td >
		    &nbsp;</td>
	    </tr>
        <tr>
            <td colspan="2" align="right" class="style1" width="40%">
            
            <asp:Label ID="m_lbl_ghi_chu7" runat="server" CssClass="cssManField" 
                Text="Loại" />
            
            </td>
            <td colspan="2" class="style1">
            
		    <asp:DropDownList id="m_cbo_loai_tai_san_master" runat="server" Width="264px" 
                CssClass="cssDorpdownlist" AutoPostBack = "true"/>
            
            </td>
        </tr>
        <tr>
           <td colspan="4" align="center">
		    <asp:HiddenField ID="m_hdf_id_trang_thai" runat="server" Visible="False" />
            </td>
        </tr>
        <tr>
            <td colspan="4" align="center">
            
		    <asp:GridView ID="m_grv_dm_trang_thai" runat="server" AutoGenerateColumns="False" 
                Width="80%" DataKeyNames="ID" 
                CellPadding="4" ForeColor="#333333" CssClass="cssGrid" 
                    onrowdeleting="m_grv_dm_trang_thai_RowDeleting" 
                    onselectedindexchanging="m_grv_dm_trang_thai_SelectedIndexChanging">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center"><ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>

                        <HeaderStyle Width="15px" />

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:TemplateField>
                    <asp:BoundField DataField="MA_TU_DIEN" HeaderText="Mã từ điển" />
                    <asp:BoundField DataField="TEN" HeaderText="Tên trạng thái">
                        </asp:BoundField>
                    <asp:BoundField DataField="GHI_CHU" ItemStyle-HorizontalAlign="Center" 
                        HeaderText="Ghi chú" >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:BoundField>
                    <asp:CommandField DeleteText="Xóa" ShowDeleteButton="True" 
                        ItemStyle-HorizontalAlign="Center" >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:CommandField>
                    <asp:CommandField SelectText="Sửa" ShowSelectButton="True" 
                        ItemStyle-HorizontalAlign="Center" >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                    </asp:CommandField>
                </Columns>
                <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#810c15" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle CssClass="cssSelectedRow" BackColor="#C5BBAF" 
                    Font-Bold="True" ForeColor="#333333"></SelectedRowStyle>
            </asp:GridView>
            
            </td>
        </tr>
    </table>

</asp:Content>

