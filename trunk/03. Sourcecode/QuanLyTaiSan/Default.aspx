<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" TagPrefix="asp" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    </asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <asp:ScriptManager runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Literal ID="Literal1" runat="server"></asp:Literal> 
                <asp:Timer ID="Timer1" runat="server" Interval="1000" ontick="Timer1_Tick"> 
                </asp:Timer>
                <br />
            </ContentTemplate>
            <Triggers>
                 <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" /> 
            </Triggers>
        </asp:UpdatePanel>
    </div>

    <!-- Bang tin tuc -->
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
	<tbody>
		<tr>
			<td style="padding-top: 8px; height: 8px;"></td>
		</tr>
		
		<tr><td style="padding-left: 8px; padding-right: 5px;" valign="top">
		
		<table border="0" cellpadding="0" cellspacing="0" width="300">
			<tbody>
				<tr><td valign="top">
					<table border="0" width="200" cellpadding="0" cellspacing="3" align="left">
					<tbody><tr>
						<td>
						<a href="modules.php?name=News&amp;op=viewst&amp;sid=745" title="Suy ngẫm: Vì sao anh giàu? Vì sao tôi nghèo?">
                            <img border="0" src="Images/pager/dat.jpg" width="200"></a></td>
						</tr>
					</tbody></table>
				</td>
			</tr>
			<tr><td style="height: 5px;"></td>
			</tr>
			<tr><td><p class="link_news_hot" style="margin-top: 0px; margin-bottom: 5px"><a href="modules.php?name=News&amp;op=viewst&amp;sid=745">Suy ngẫm: Vì sao anh giàu? Vì sao tôi nghèo?</a></p>
			</td></tr><tr>
			<td>
			<table border="0" cellpadding="0" cellspacing="0" width="98%">
			<tbody>
			<tr>
			<td><span class="indexhometext">Vì sao cùng một xuất phát điểm và cùng có mong muốn đổi đời, nhưng có những người thành đạt và trở nên giàu có, trong khi nhiều người...</span></td>
			</tr>
			</tbody></table>
			</td>
			</tr>
			<tr>
			<td style="height: 5px;">
			</td>
			</tr>
			</tbody>
		</table>
	</td>
	<td style="width: 100%; padding-left: 5px; padding-right: 8px; 
	border-left: 1px solid rgb(229, 229, 229);" valign="top">
	<table id="dnn_ctr698_newsHot_drgOtherNews" style="width: 
	100%; border-collapse: collapse;" border="0" cellspacing="0">
	<tbody><tr>
	<td>
	<table cellpadding="0" cellspacing="0" width="100%">
	<tbody><tr>
	<td class="OtherNews_td">
	<a id="dnn_ctr698_newsHot_drgOtherNews_ctl00_hplOtherNews" class="link_OtherNews" href="modules.php?name=News&amp;op=viewst&amp;sid=745">Suy ngẫm: Vì sao anh giàu? Vì sao tôi nghèo?</a>
	<br>
	<span id="dnn_ctr698_newsHot_drgOtherNews_ctl00_lbDateText" class="HotNews_DateText">Ngày cập nhật:</span>
	<span id="dnn_ctr698_newsHot_drgOtherNews_ctl00_lbDate" class="HotNews_date">2013-07-31 14:45:58</span></td>
	</tr>
	</tbody></table>
	</td>
	</tr><tr>
	<td>
	<table cellpadding="0" cellspacing="0" width="100%">
	<tbody><tr>
	<td class="OtherNews_td">
	<a id="dnn_ctr698_newsHot_drgOtherNews_ctl00_hplOtherNews" class="link_OtherNews" href="modules.php?name=News&amp;op=viewst&amp;sid=744">Thông báo mở khóa học " Microsoft Excel cơ bản và nâng cao 06/2013"</a>
	<br>
	<span id="dnn_ctr698_newsHot_drgOtherNews_ctl00_lbDateText" class="HotNews_DateText">Ngày cập nhật:</span>
	<span id="dnn_ctr698_newsHot_drgOtherNews_ctl00_lbDate" class="HotNews_date">2013-07-29 15:05:17</span></td>
	</tr>
	</tbody></table>
	</td>
	</tr><tr>
	<td>
	<table cellpadding="0" cellspacing="0" width="100%">
	<tbody><tr>
	<td class="OtherNews_td">
	<a id="dnn_ctr698_newsHot_drgOtherNews_ctl00_hplOtherNews" class="link_OtherNews" href="modules.php?name=News&amp;op=viewst&amp;sid=743">Buổi khai giảng sôi động của khóa MS EXCEL 04/2013</a>
	<br>
	<span id="dnn_ctr698_newsHot_drgOtherNews_ctl00_lbDateText" class="HotNews_DateText">Ngày cập nhật:</span>
	<span id="dnn_ctr698_newsHot_drgOtherNews_ctl00_lbDate" class="HotNews_date">2013-07-29 14:10:57</span></td>
	</tr>
	</tbody></table>
	</td>
	</tr><tr>
	<td>
	<table cellpadding="0" cellspacing="0" width="100%">
	<tbody><tr>
	<td class="OtherNews_td">
	<a id="dnn_ctr698_newsHot_drgOtherNews_ctl00_hplOtherNews" class="link_OtherNews" href="modules.php?name=News&amp;op=viewst&amp;sid=742">Những tác phẩm nghệ thuật đỉnh cao được làm từ...Excel</a>
	<br>
	<span id="dnn_ctr698_newsHot_drgOtherNews_ctl00_lbDateText" class="HotNews_DateText">Ngày cập nhật:</span>
	<span id="dnn_ctr698_newsHot_drgOtherNews_ctl00_lbDate" class="HotNews_date">2013-07-21 23:17:05</span></td>
	</tr>
	</tbody></table>
	</td>
	</tr><tr>
	<td>
	<table cellpadding="0" cellspacing="0" width="100%">
	<tbody><tr>
	<td class="OtherNews_td">
	<a id="dnn_ctr698_newsHot_drgOtherNews_ctl00_hplOtherNews" class="link_OtherNews" href="modules.php?name=News&amp;op=viewst&amp;sid=741">Mất hơn 6 tỷ USD vì lỗi Excel</a>
	<br>
	<span id="dnn_ctr698_newsHot_drgOtherNews_ctl00_lbDateText" class="HotNews_DateText">Ngày cập nhật:</span>
	<span id="dnn_ctr698_newsHot_drgOtherNews_ctl00_lbDate" class="HotNews_date">2013-07-16 23:27:22</span></td>
	</tr>
	</tbody></table>
	</td>
	</tr><tr>
	<td>
	<table cellpadding="0" cellspacing="0" width="100%">
	<tbody><tr>
	<td class="OtherNews_td">
	<a id="dnn_ctr698_newsHot_drgOtherNews_ctl00_hplOtherNews" class="link_OtherNews" href="modules.php?name=News&amp;op=viewst&amp;sid=740">Vô địch MS Office World Champion Excel cấp quốc gia năm 2013 với chỉ 11 phút 45 giây</a>
	<br>
	<span id="dnn_ctr698_newsHot_drgOtherNews_ctl00_lbDateText" class="HotNews_DateText">Ngày cập nhật:</span>
	<span id="dnn_ctr698_newsHot_drgOtherNews_ctl00_lbDate" class="HotNews_date">2013-07-16 23:22:17</span></td>
	</tr>
	</tbody></table>
	</td>
	</tr>
	</tbody></table>
	</td>
	</tr>
	</tbody>
</table>

    </asp:Content>
