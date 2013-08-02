<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="F500_QuanLyOto.aspx.cs" Inherits="ChucNang_F500_QuanLyOto" %>
<%@ Register assembly="eWorld.UI" namespace="eWorld.UI" tagprefix="ew" %>
<%@ Import Namespace ="IP.Core.IPCommon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
 a 
 {
   text-decoration:none;    
 }
        .style1
        {
            width: 13%;
        }
        .style2
        {
            width: 1%;
        }
        .cssTextBox
        {}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">

    <table cellspacing="0" cellpadding="2" style="width:100%;" class="cssTable" border="0">
    <tr>
		<td class="cssPageTitleBG" colspan="3">
		    <asp:label id="Label1" runat="server" CssClass="cssPageTitle" 
                Text="Quản lý ô tô"/>
		</td>
	</tr>	
    <tr>
        <td>
        
        <table cellspacing="0" cellpadding="2" style="width:1000px;" class="cssTable" border="0"> 
            <tr>
                <td align="right" style="width:7%;">
			        &nbsp;</td>
                <td align="left" colspan="6">
                    <asp:ValidationSummary ID="vdsCategory" runat="server" CssClass="cssManField" 
                        Font-Bold="true" />
                </td>
                <td align="right" colspan="4">
			        &nbsp;</td>
                <td align="left" class="style1">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width:7%;">
			        <asp:Label ID="m_lbl_mess" runat="server" CssClass="cssManField" />
                         </td>
                <td align="left" colspan="6">
                    &nbsp;</td>
                <td align="right" colspan="4">
			        &nbsp;</td>
                <td align="left" class="style1">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width:7%;">
			        &nbsp;</td>
                <td align="left" colspan="6">
                    &nbsp;</td>
                <td align="right" colspan="4">
			        &nbsp;</td>
                <td align="left" class="style1">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width:7%;">
			<asp:label id="lblFullName14" CssClass="cssManField" runat="server" 
                Text="Bộ, Tỉnh" />
                         </td>
                <td align="left" colspan="6">
                    <asp:DropDownList ID="m_ddl_bo_tinh" runat="server" Width="265px" 
                        onselectedindexchanged="m_ddl_bo_tinh_SelectedIndexChanged" 
                        AutoPostBack="True">
                    </asp:DropDownList>
                </td>
                <td align="right" colspan="4">
			        &nbsp;</td>
                <td align="left" class="style1">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width:7%;">
			<asp:label id="lblFullName15" CssClass="cssManField" runat="server" 
                Text="Đơn vị chủ quản" />
                         </td>
                <td align="left" colspan="6">
                    <asp:DropDownList ID="m_ddl_dv_chu_quan" runat="server" Width="265px" 
                        onselectedindexchanged="m_ddl_dv_chu_quan_SelectedIndexChanged" 
                        AutoPostBack="True">
                    </asp:DropDownList>
                </td>
                <td align="right" colspan="4">
			        &nbsp;</td>
                <td align="left" class="style1">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width:7%;">
			<asp:label id="lblFullName16" CssClass="cssManField" runat="server" 
                Text="Đơn vị sử dụng tài sản" />
                         </td>
                <td align="left" colspan="6">
                    <asp:DropDownList ID="m_ddl_dv_sd_ts" runat="server" Width="265px" 
                        onselectedindexchanged="m_ddl_dv_sd_ts_SelectedIndexChanged" 
                        AutoPostBack="True">
                    </asp:DropDownList>
                </td>
                <td align="right" colspan="4">
			        &nbsp;</td>
                <td align="left" class="style1">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width:7%;">
			        &nbsp;</td>
                <td align="left" colspan="6">
                    &nbsp;</td>
                <td align="right" colspan="4">
			        &nbsp;</td>
                <td align="left" class="style1">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width:7%;">
			<asp:label id="lblFullName13" CssClass="cssManField" runat="server" 
                Text="&lt;U&gt;L&lt;/U&gt;oại xe" />
                         </td>
                <td align="left" colspan="6">
                    <asp:DropDownList ID="m_ddl_loai_xe" runat="server" Width="265px" 
                        onselectedindexchanged="m_ddl_loai_xe_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
                <td align="right" colspan="4">
			<asp:label id="lblFullName19" CssClass="cssManField" runat="server" 
                Text="Trạng thái ô tô" />
                         </td>
                <td align="left" class="style1">
                    <asp:DropDownList ID="m_ddl_trang_thai_oto" runat="server" Width="265px" 
                        onselectedindexchanged="m_ddl_dv_sd_ts_SelectedIndexChanged" 
                        AutoPostBack="True">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right" style="width:7%;">
			<asp:label id="lblFullName17" CssClass="cssManField" runat="server" 
                Text="Mã tài sản" />
                         </td>
                <td align="left" colspan="6">
                        <asp:TextBox ID="m_txt_ma_ts" runat="server" CssClass="cssTextBox" 
                        Width="265px"></asp:TextBox>
                </td>
                <td align="right" colspan="4">
			        &nbsp;</td>
                <td align="left" class="style1">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width:7%;">
			<asp:label id="lblFullName18" CssClass="cssManField" runat="server" 
                Text="Tên tài sản" />
                         </td>
                <td align="left" colspan="6">
                        <asp:TextBox ID="m_txt_ten_ts" runat="server" CssClass="cssTextBox" 
                        Width="265px"></asp:TextBox>
                </td>
                <td align="right" colspan="4">
			        &nbsp;</td>
                <td align="left" class="style1">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width:7%;">
			<asp:label id="lblFullName" CssClass="cssManField" runat="server" 
                Text="Nhãn hiệu" />
                         </td>
                <td align="left" colspan="6">
                        <asp:TextBox ID="m_txt_ten_nhan_hieu" runat="server" CssClass="cssTextBox" 
                        Width="265px"></asp:TextBox>
                    </td>
                <td align="right" colspan="4">
			<asp:label id="lblFullName2" CssClass="cssManField" runat="server" 
                Text="Giá trị theo số kế toán (ngàn đồng)" />
		            </td>
                <td align="left" class="style1"></td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
                    <asp:label id="Label17" CssClass="cssManField" runat="server" 
                Text="Biển kiểm soát" /></td>
                <td align="left" colspan="6">
                        <asp:TextBox ID="m_txt_bien_kiem_soat" runat="server" CssClass="cssTextBox" 
                        Width="265px"></asp:TextBox>
                    </td>
                <td align="left" style="width:7%;" rowspan="2">
			<asp:label id="lblFullName3" CssClass="cssManField" runat="server" 
                Text="Nguyên giá" />
                         </td>
                <td align="right" colspan="3" style="margin-left: 40px">
			<asp:label id="lblFullName4" CssClass="cssManField" runat="server" 
                Text="Nguồn NS" />
                </td>
                <td align="left" class="style1">
                    <asp:TextBox ID="m_txt_nguon_ns" runat="server" CssClass="cssTextBox" 
                        Width="265px"></asp:TextBox>
		            </td>
            </tr>                   
            <tr>
                <td align="right" style="width:5%;">
                    <asp:label id="Label14" CssClass="cssManField" runat="server" 
                Text="Số chỗ ngồi/Tải trọng" /></td>
                <td align="left" colspan="6">
                     <asp:TextBox ID="m_txt_tai_trong" runat="server" CssClass="cssTextBox" 
                        Width="265px"></asp:TextBox></td>
                <td align="right" colspan="3" style="margin-left: 40px">
			<asp:label id="lblFullName5" CssClass="cssManField" runat="server" 
                Text="Nguồn khác" />
                </td>
                <td align="left" class="style1">
                    <asp:TextBox ID="m_txt_nguon_khac" runat="server" CssClass="cssTextBox" 
                        Width="265px"></asp:TextBox>
		            </td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
                    <asp:label id="Label15" CssClass="cssManField" runat="server" 
                Text="Nước sản xuất" /></td>
                <td align="left" colspan="6">
                     <asp:TextBox ID="m_txt_nuoc_san_xuat" runat="server" CssClass="cssTextBox" 
                        Width="265px"></asp:TextBox></td>
                <td align="left" colspan="4">
			<asp:label id="lblFullName6" CssClass="cssManField" runat="server" 
                Text="Giá trị còn lại" />
                         </td>
                <td align="left" class="style1">
                    <asp:TextBox ID="m_txt_gia_tri_con_lai" runat="server" CssClass="cssTextBox" 
                        Width="265px"></asp:TextBox>
		            </td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
                    <asp:label id="Label4" CssClass="cssManField" runat="server" 
                Text="Năm sản xuất" /></td>
                <td align="left" colspan="6">
                     <asp:TextBox ID="m_txt_nam_san_xuat" runat="server" CssClass="cssTextBox" 
                        Width="265px"></asp:TextBox></td>
                <td  align="right" colspan="4">
			<asp:label id="lblFullName7" CssClass="cssManField" runat="server" 
                Text="Hiện trạng sử dụng (chiếc)" />
                         </td>
                <td align="left" class="style1">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
                    <asp:label id="Label19" CssClass="cssManField" runat="server" 
                Text="Cống suất xe" /></td>
                <td align="left" colspan="6">
                     <asp:TextBox ID="m_txt_cong_suat_xe" runat="server" CssClass="cssTextBox" 
                        Width="265px"></asp:TextBox></td>
                <td align="left" colspan="4">
			<asp:label id="lblFullName8" CssClass="cssManField" runat="server" 
                Text="QLNN" />
                         </td>
                <td align="left" class="style1">
                    <asp:TextBox ID="m_txt_qlnn" runat="server" CssClass="cssTextBox" 
                        Width="265px"></asp:TextBox>
		            </td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
                    <asp:label id="Label20" CssClass="cssManField" runat="server" 
                Text="Chức danh sử dụng xe" /></td>
                <td align="left" colspan="6">
                     <asp:TextBox ID="m_txt_chuc_danh_sd_xe" runat="server" CssClass="cssTextBox" 
                        Width="265px"></asp:TextBox></td>
                <td align="left" style="width:7%;"  rowspan="2">
			<asp:label id="lblFullName9" CssClass="cssManField" runat="server" 
                Text="HĐ sự nghiệp" />
                         </td>
                <td align="right" colspan="3" style="margin-left: 40px">
			<asp:label id="lblFullName11" CssClass="cssManField" runat="server" 
                Text="Kinh doanh" />
                </td>
                <td align="left" class="style1">
                    <asp:TextBox ID="m_txt_kinh_doanh" runat="server" CssClass="cssTextBox" 
                        Width="265px"></asp:TextBox>
		            </td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
                    <asp:label id="Label21" CssClass="cssManField" runat="server" 
                Text="Nguồn gốc xe" /></td>
                <td align="left" colspan="6">
                     <asp:TextBox ID="m_txt_nguon_goc_xe" runat="server" CssClass="cssTextBox" 
                        Width="265px"></asp:TextBox></td>
                <td align="right" colspan="3" style="margin-left: 40px">
			<asp:label id="lblFullName12" CssClass="cssManField" runat="server" 
                Text="Không kinh doanh" />
                </td>
                <td align="left" class="style1">
                    <asp:TextBox ID="m_txt_khong_kinh_doanh" runat="server" CssClass="cssTextBox" 
                        Width="265px"></asp:TextBox>
		            </td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
                    <asp:label id="Label18" CssClass="cssManField" runat="server" 
                Text="Năm sử dụng" /></td>
                <td align="left" colspan="6">
                     <asp:TextBox ID="m_txt_nam_su_dung" runat="server" CssClass="cssTextBox" 
                        Width="265px"></asp:TextBox></td>
                <td align="left" colspan="4">
			<asp:label id="lblFullName10" CssClass="cssManField" runat="server" 
                Text="HĐ khác" />
                         </td>
                <td align="left" class="style1">
                    <asp:TextBox ID="m_txt_hd_khac" runat="server" CssClass="cssTextBox" 
                        Width="265px"></asp:TextBox>
		            </td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
                    &nbsp;</td>
                <td align="left" colspan="6">
                     &nbsp;</td>
                <td style="width:7%;" class="csscurrency">
                    &nbsp;</td>
                <td align="right" colspan="3" style="margin-left: 40px">
                    &nbsp;</td>
                <td align="left" class="style1">
                     &nbsp;</td>
            </tr>
            <tr>
                <td align="left" colspan="2">

                    &nbsp;</td>
                <td align="left" colspan="2">

                    <asp:Button ID="m_cmd_tao_moi" runat="server" accessKey="c" 
                        CssClass="cssButton" onclick="m_cmd_tao_moi_Click" Text="Tạo mới(c)" 
                        Width="98px" />
                    <asp:Button ID="m_cmd_cap_nhat" runat="server" accessKey="u" 
                        CssClass="cssButton" onclick="m_cmd_cap_nhat_Click" Text="Cập nhật(u)" 
                        Width="98px" />
                    <asp:Button ID="btnCancel" runat="server" accessKey="r" CssClass="cssButton" 
                        onclick="btnCancel_Click" Text="Xóa trắng(r)" Width="98px" />

		        </td>
                <td align="left" colspan="2">

                    &nbsp;</td>
                <td align="left" colspan="2">

                    &nbsp;</td>
                <td align="left" colspan="3" style="margin-left: 40px">
                 <asp:HiddenField id="m_hdf_id" runat="server"/></td>
            </tr>
            <tr>
                <td align="left" colspan="8">

                    &nbsp;</td>
                <td align="left" colspan="3" style="margin-left: 40px">
			        &nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
			        &nbsp;</td>
                <td align="left" colspan="6">          
                     &nbsp;</td>
                <td align="left" style="width:7%;">     
			        &nbsp;</td>     
                    <td align="left" style="width:1%;"></td>
                 <td align="right" style="width:5%;"></td>
                <td align="left" class="style2"></td>     <td align="left" class="style1"></td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
			        &nbsp;</td>
                <td align="left" style="width:10%;" colspan="2">          
			        &nbsp;</td>
			    <td align="left" style="width:1%;" colspan="2">
                    &nbsp;</td>
			
                <td align="left" class="style2" colspan="2">
			        &nbsp;</td>
                <td align="left" style="width:7%;">     
			        &nbsp;</td>     
                    <td align="left" style="width:1%;">&nbsp;</td>
                 <td align="right" style="width:5%;">&nbsp;</td>
                <td align="left" class="style2">&nbsp;</td>     <td align="left" class="style1">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="width:5%;">
			        <asp:Label ID="lbl_ghi_chu0" runat="server" CssClass="cssManField" 
                        Text="Từ khóa tìm kiếm" />
                </td>
                <td align="left" colspan="6">          
                     <asp:TextBox ID="m_txt_tim_kiem" runat="server" CssClass="cssTextBox" 
                        Width="85%"></asp:TextBox></td>
                <td align="left" style="width:7%;">     
			        <asp:Button ID="m_cmd_tim_kiem" runat="server" accessKey="c" 
                        CssClass="cssButton" onclick="m_cmd_tim_kiem_Click" Text="Tìm kiếm(s)" 
                        Width="98px" />
                    </td>     
                    <td align="left" style="width:1%;">&nbsp;</td>
                 <td align="right" style="width:5%;">&nbsp;</td>
                <td align="left" class="style2">&nbsp;</td>     <td align="left" class="style1">&nbsp;</td>
            </tr>
            <tr>
                <td align="right" colspan="7" >
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <%# Eval("GIA_TRI_CON_LAI", "{0:#,###}")%>
			    </td>
                <td align="left" >    
			        &nbsp;</td>
                             <td align="left" >&nbsp;</td>
                 <td align="right" >
                     &nbsp;</td>
                <td align="left" class="style2" ></td>    
                <td align="left" class="style1" >&nbsp;</td>
            </tr>
            </table>        
        </td>
    </tr>  
    <tr>
		<td class="cssPageTitleBG" colspan="3">
		    <asp:label id="m_lbl_ket_qua_loc_du_lieu" runat="server" CssClass="cssPageTitle" 
                Text="Kết quả lọc dữ liệu"/>
		</td>
	</tr>	
    <tr>
		<td align="left">
        &nbsp;<br />
                <asp:Label ID="m_lbl_thong_bao" runat="server" CssClass="cssManField" />
        </td>
        <td >
		    &nbsp;</td>
	</tr>	
	<tr>
		<td align="center" colspan="3" style="height:450px;" valign="top">
		    &nbsp;
   <asp:GridView ID="m_grv_dm_oto" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    Width="100%" DataKeyNames="ID" CellPadding="4" ForeColor="#333333" AllowSorting="True"
                    PageSize="15" ShowHeader="true" 
                onpageindexchanging="m_grv_dm_oto_PageIndexChanging" 
                onrowcommand="m_grv_danh_sach_nha_RowCommand">
                    <Columns>
                    <asp:TemplateField HeaderText="Xóa" ItemStyle-Width="2%">
                            <ItemTemplate>
                                <asp:LinkButton ID="m_lbt_delete" runat="server" CommandName="DeleteComp" ToolTip="Xóa"
                                    OnClientClick="return confirm ('Bạn có thực sự muốn xóa bản ghi này?')" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'>
                     <img src="../Images/Button/deletered.png" alt="Delete" />
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sửa">
                            <ItemTemplate>
                                <asp:LinkButton ID="m_lbt_edit" runat="server" CommandName="EditComp" ToolTip="Sửa" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'>
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
                        <asp:HyperLinkField HeaderText="Tên tài sản" DataTextField="TEN_TAI_SAN" NavigateUrl=""/>
                        <asp:BoundField HeaderText="Nhãn hiệu" DataField="NHAN_HIEU"/>
                        <asp:BoundField HeaderText="Biển kiểm soát" DataField="BIEN_KIEM_SOAT"/>
                        <asp:BoundField HeaderText="Số chỗ ngồi" DataField="SO_CHO_NGOI"/>
                        <asp:BoundField HeaderText="Công suất xe" DataField="CONG_SUAT_XE"/>
                        <asp:BoundField HeaderText="Chức danh sử dụng" DataField="CHUC_DANH_SU_DUNG"/>
                        <asp:BoundField HeaderText="Nguồn gốc xe" DataField="NGUON_GOC_XE"/>
                        <asp:BoundField HeaderText="Nước sản xuất" DataField="NUOC_SAN_XUAT"/>
                        <asp:BoundField HeaderText="Năm sản xuất" DataField="NAM_SAN_XUAT"/>
                        <asp:BoundField HeaderText="Ngày/tháng/năm sử dụng" DataField="NAM_SU_DUNG"/>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <table border="1" cellspacing="0" cellpadding="3" width="100%">
                                	<tr>
                                		<td colspan="3">Giá trị theo sổ kế toán</td>
                                	</tr>
                                    <tr>
                                        <td colspan="2" style = "width: 66%">Nguyên giá</td>
                                        <td rowspan="2" style = "width: 33%">Giá trị còn lại</td>
                                    </tr>
                                    <tr>
                                        <td style = "width: 33%">Nguồn NS</td>
                                        <td style = "width: 33%">Nguồn khác</td>
                                    </tr>
                                </table>
                            </HeaderTemplate>
                            <HeaderStyle CssClass=""/>
                            <ItemTemplate>
                                <table border="1" cellspacing="0" cellpadding="2" width="100%">
                                	<tr>
                                		<td style = "width: 33%"><%# Eval("NGUON_NS", "{0:#,###}")%></td>
                                        <td style = "width: 33%"><%# Eval("NGUON_KHAC", "{0:#,###}")%></td>
                                        <td style = "width: 33%"><%# Eval("GIA_TRI_CON_LAI", "{0:#,###}")%></td>
                                	</tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <table border="1" cellspacing="0" cellpadding="2" width="100%">
                                	<tr>
                                		<td colspan="7">Hiện trạng sử dụng</td>
                                	</tr>
                                    <tr>
                                        <td rowspan="2" style = "width: 25%">Quản lý nhà nước</td>
                                        <td colspan="2" style = "width: 50%">Hoạt đông sự nghiệp</td>
                                        <td rowspan="2" style = "width: 25%">Khác</td>
                                    </tr>
                                    <tr>
                                        <td style = "width: 25%">Kinh doanh</td>
                                        <td style = "width: 25%">Không kinh doanh</td>
                                    </tr>
                                </table>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <table border="1" cellspacing="0" cellpadding="2" width="100%">
                                	<tr>
                                		<td style = "width: 25%"><%# Eval("QLNN") %></td>
                                        <td style = "width: 25%"><%# Eval("KINH_DOANH") %></td>
                                        <td style = "width: 25%"><%# Eval("KHONG_KINH_DOANH") %></td>
                                        <td style = "width: 25%"><%# Eval("HD_KHAC") %></td>
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
