<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"
    TagPrefix="asp" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <asp:ScriptManager runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick">
                </asp:Timer>
                <br />
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Timer1" EventName="Tick" />
            </Triggers>
        </asp:UpdatePanel>
    </div>

    <div style="clip: rect(auto, auto, auto, auto); margin-left:10%" id="TrongHV_Table" >
        
    <!-- Bang Dat -->
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tbody>
            <tr>
                <td style="padding-left: 8px; padding-right: 5px;" valign="top">
                    <table border="0" cellpadding="0" cellspacing="0" width="300">
                        <tbody>
                            <tr>
                                <td valign="top">
                                    <table border="0" width="200" cellpadding="0" cellspacing="3" align="left">
                                        <tbody>
                                            <tr>
                                                <td>
                                                    <a href="#" title="Quản lý đất">
                                                        <img border="0" src="Images/pager/dat1.jpg" width="200" 
                                                        title="Quản lý đất" /></a>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 5px;">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <p class="link_news_hot" style="margin-top: 0px; margin-bottom: 5px">
                                        <a href="#">Quản lý đất</a></p>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table border="0" cellpadding="0" cellspacing="0" width="98%">
                                        <tbody>
                                            <tr>
                                                <td>
                                                    Mô tả quản lý đất
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 5px;">
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
                <td style="width: 40%; padding-left: 5px; padding-right: 8px; border-left: 1px solid rgb(229, 229, 229);"
                    valign="top">
                    <table id="Table5" style="width: 100%; border-collapse: collapse;" border="0" cellspacing="0">
                        <tbody>
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tbody>
                                            <tr>
                                                <td class="OtherNews_td">
                                                    <a href="#" style="font-weight: bold">Danh mục đất</a>
                                                    <br>
                                                    <span class="HotNews_DateText">Ngày cập nhật:</span> <span class="HotNews_date">2013-07-31
                                                        14:45:58</span>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tbody>
                                            <tr>
                                                <td class="OtherNews_td">
                                                    <a class="link_OtherNews" href="#" style="font-weight: bold">Đề nghị xử lý đất</a>
                                                    <br>
                                                    <span class="HotNews_DateText">Ngày cập nhật:</span> <span class="HotNews_date">2013-07-29
                                                        15:05:17</span>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tbody>
                                            <tr>
                                                <td class="OtherNews_td">
                                                    <a class="link_OtherNews" href="#" style="font-weight: bold">Đề nghị trang cấp đất</a>
                                                    <br>
                                                    <span class="HotNews_DateText">Ngày cập nhật:</span> <span class="HotNews_date">2013-07-29
                                                        14:10:57</span>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                          
                        </tbody>
                    </table>
                </td>
                <td style="width: 60%; padding-left: 5px; padding-right: 8px; border-left: 1px solid rgb(229, 229, 229);"
                    valign="top">
                    <table id="Table6" style="width: 100%; border-collapse: collapse;" border="0" cellspacing="0">
                        <tbody>
                            
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tbody>
                                            <tr>
                                                <td class="OtherNews_td">
                                                    <a class="link_OtherNews" href="#" style="font-weight: bold">Kê khai đất</a>
                                                    <br>
                                                    <span class="HotNews_DateText">Ngày cập nhật:</span> <span class="HotNews_date">2013-07-21
                                                        23:17:05</span>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tbody>
                                            <tr>
                                                <td class="OtherNews_td">
                                                    <a class="link_OtherNews" href="#" style="font-weight: bold">Đề nghị xử lý đất</a>
                                                    <br>
                                                    <span class="HotNews_DateText">Ngày cập nhật:</span> <span class="HotNews_date">2013-07-16
                                                        23:27:22</span>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tbody>
                                            <tr>
                                                <td class="OtherNews_td">
                                                    <a class="link_OtherNews" href="#" style="font-weight: bold">Khấu hao đất</a>
                                                    <br>
                                                    <span class="HotNews_DateText">Ngày cập nhật:</span> <span class="HotNews_date">2013-07-16
                                                        23:22:17</span>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
        </tbody>
    </table>
    <!-- Ket thuc bang Nha-->
    <hr />
    <!-- Bang Nha -->
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tbody>
            <tr>
                <td style="padding-left: 8px; padding-right: 5px;" valign="top">
                    <table border="0" cellpadding="0" cellspacing="0" width="300">
                        <tbody>
                            <tr>
                                <td valign="top">
                                    <table border="0" width="200" cellpadding="0" cellspacing="3" align="left">
                                        <tbody>
                                            <tr>
                                                <td>
                                                    <a href="#" title="Quản lý nhà">
                                                        <img border="0" src="Images/pager/nha1.jpg" width="200" title="Quản lý nhà" /></a>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 5px;">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <p class="link_news_hot" style="margin-top: 0px; margin-bottom: 5px">
                                        <a href="#">Quản lý nhà</a></p>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table border="0" cellpadding="0" cellspacing="0" width="98%">
                                        <tbody>
                                            <tr>
                                                <td>
                                                    Mô tả quản lý nhà
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 5px;">
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
                <td style="width: 40%; padding-left: 5px; padding-right: 8px; border-left: 1px solid rgb(229, 229, 229);"
                    valign="top">
                    <table id="Table1" style="width: 100%; border-collapse: collapse;" border="0" cellspacing="0">
                        <tbody>
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tbody>
                                            <tr>
                                                <td class="OtherNews_td">
                                                    <a href="#" style="font-weight: bold">Danh mục nhà</a>
                                                    <br>
                                                    <span class="HotNews_DateText">Ngày cập nhật:</span> <span class="HotNews_date">2013-07-31
                                                        14:45:58</span>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tbody>
                                            <tr>
                                                <td class="OtherNews_td">
                                                    <a class="link_OtherNews" href="#" style="font-weight: bold">Đề nghị xử lý nhà</a>
                                                    <br>
                                                    <span class="HotNews_DateText">Ngày cập nhật:</span> <span class="HotNews_date">2013-07-29
                                                        15:05:17</span>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tbody>
                                            <tr>
                                                <td class="OtherNews_td">
                                                    <a class="link_OtherNews" href="#" style="font-weight: bold">Đề nghị trang cấp nhà</a>
                                                    <br>
                                                    <span class="HotNews_DateText">Ngày cập nhật:</span> <span class="HotNews_date">2013-07-29
                                                        14:10:57</span>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                          
                        </tbody>
                    </table>
                </td>
                <td style="width: 60%; padding-left: 5px; padding-right: 8px; border-left: 1px solid rgb(229, 229, 229);"
                    valign="top">
                    <table id="Table4" style="width: 100%; border-collapse: collapse;" border="0" cellspacing="0">
                        <tbody>
                            
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tbody>
                                            <tr>
                                                <td class="OtherNews_td">
                                                    <a class="link_OtherNews" href="#" style="font-weight: bold">Kê khai nhà</a>
                                                    <br>
                                                    <span class="HotNews_DateText">Ngày cập nhật:</span> <span class="HotNews_date">2013-07-21
                                                        23:17:05</span>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tbody>
                                            <tr>
                                                <td class="OtherNews_td">
                                                    <a class="link_OtherNews" href="#" style="font-weight: bold">Đề nghị xử lý nhà</a>
                                                    <br>
                                                    <span class="HotNews_DateText">Ngày cập nhật:</span> <span class="HotNews_date">2013-07-16
                                                        23:27:22</span>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tbody>
                                            <tr>
                                                <td class="OtherNews_td">
                                                    <a class="link_OtherNews" href="#" style="font-weight: bold">Khấu hao nhà</a>
                                                    <br>
                                                    <span class="HotNews_DateText">Ngày cập nhật:</span> <span class="HotNews_date">2013-07-16
                                                        23:22:17</span>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
        </tbody>
    </table>
    <!-- Ket thuc bang Nha-->
    <hr />
    <!-- Bang Oto -->
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tbody>
            <tr>
                <td style="padding-left: 8px; padding-right: 5px;" valign="top">
                    <table border="0" cellpadding="0" cellspacing="0" width="300">
                        <tbody>
                            <tr>
                                <td valign="top">
                                    <table border="0" width="200" cellpadding="0" cellspacing="3" align="left">
                                        <tbody>
                                            <tr>
                                                <td>
                                                    <a href="#" title="Quản lý Oto">
                                                        <img border="0" src="Images/pager/oto1.jpg" width="200" title="Quản lý Oto"></a>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 5px;">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <p class="link_news_hot" style="margin-top: 0px; margin-bottom: 5px">
                                        <a href="#">Quản lý Oto</a></p>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table border="0" cellpadding="0" cellspacing="0" width="98%">
                                        <tbody>
                                            <tr>
                                                <td>
                                                    <span class="indexhometext">Mô tả quản lý Oto</span>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 5px;">
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
                <td style="width: 40%; padding-left: 5px; padding-right: 8px; border-left: 1px solid rgb(229, 229, 229);"
                    valign="top">
                    <table id="Table2" style="width: 100%; border-collapse: collapse;" border="0" cellspacing="0">
                        <tbody>
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tbody>
                                            <tr>
                                                <td class="OtherNews_td">
                                                    <a href="#" style="font-weight: bold">Danh mục Oto</a>
                                                    <br>
                                                    <span class="HotNews_DateText">Ngày cập nhật:</span> <span class="HotNews_date">2013-07-31
                                                        14:45:58</span>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tbody>
                                            <tr>
                                                <td class="OtherNews_td">
                                                    <a class="link_OtherNews" href="#" style="font-weight: bold">Đề nghị xử lý Oto</a>
                                                    <br>
                                                    <span class="HotNews_DateText">Ngày cập nhật:</span> <span class="HotNews_date">2013-07-29
                                                        15:05:17</span>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tbody>
                                            <tr>
                                                <td class="OtherNews_td">
                                                    <a class="link_OtherNews" href="#" style="font-weight: bold">Đề nghị trang cấp Oto</a>
                                                    <br>
                                                    <span class="HotNews_DateText">Ngày cập nhật:</span> <span class="HotNews_date">2013-07-29
                                                        14:10:57</span>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                           
                        </tbody>
                    </table>
                </td>

                <td style="width: 60%; padding-left: 5px; padding-right: 8px; border-left: 1px solid rgb(229, 229, 229);"
                    valign="top">
                    <table id="Table7" style="width: 100%; border-collapse: collapse;" border="0" cellspacing="0">
                        <tbody>
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tbody>
                                            <tr>
                                                <td class="OtherNews_td">
                                                    <a class="link_OtherNews" href="#" style="font-weight: bold">Kê khai Oto</a>
                                                    <br>
                                                    <span class="HotNews_DateText">Ngày cập nhật:</span> <span class="HotNews_date">2013-07-21
                                                        23:17:05</span>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tbody>
                                            <tr>
                                                <td class="OtherNews_td">
                                                    <a class="link_OtherNews" href="#" style="font-weight: bold">Đề nghị xử lý Oto</a>
                                                    <br>
                                                    <span class="HotNews_DateText">Ngày cập nhật:</span> <span class="HotNews_date">2013-07-16
                                                        23:27:22</span>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tbody>
                                            <tr>
                                                <td class="OtherNews_td">
                                                    <a class="link_OtherNews" href="#" style="font-weight: bold">Khấu hao Oto</a>
                                                    <br>
                                                    <span class="HotNews_DateText">Ngày cập nhật:</span> <span class="HotNews_date">2013-07-16
                                                        23:22:17</span>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
        </tbody>
    </table>
    <!-- Ket thuc Oto-->
    <hr />
    <!-- Bang Tai San Khac -->
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tbody>
            <tr>
                <td style="padding-left: 8px; padding-right: 5px;" valign="top">
                    <table border="0" cellpadding="0" cellspacing="0" width="300">
                        <tbody>
                            <tr>
                                <td valign="top">
                                    <table border="0" width="200" cellpadding="0" cellspacing="3" align="left">
                                        <tbody>
                                            <tr>
                                                <td>
                                                    <a href="#" title="Quản lý tài sản khác">
                                                        <img border="0" src="Images/pager/cau_my_thuan.jpg" width="200" title="Quản lý tài sản khác"></a>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 5px;">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <p class="link_news_hot" style="margin-top: 0px; margin-bottom: 5px">
                                        <a href="#">Quản lý tài sản khác</a></p>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table border="0" cellpadding="0" cellspacing="0" width="98%">
                                        <tbody>
                                            <tr>
                                                <td>
                                                    <span class="indexhometext">Mô tả quản lý tài sản khác</span>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 5px;">
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
                <td style="width: 40%; padding-left: 5px; padding-right: 8px; border-left: 1px solid rgb(229, 229, 229);"
                    valign="top">
                    <table id="Table3" style="width: 100%; border-collapse: collapse;" border="0" cellspacing="0">
                        <tbody>
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tbody>
                                            <tr>
                                                <td class="OtherNews_td">
                                                    <a href="#" style="font-weight: bold">Danh mục tài sản khác</a>
                                                    <br>
                                                    <span class="HotNews_DateText">Ngày cập nhật:</span> <span class="HotNews_date">2013-07-31
                                                        14:45:58</span>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tbody>
                                            <tr>
                                                <td class="OtherNews_td">
                                                    <a class="link_OtherNews" href="#" style="font-weight: bold">Đề nghị xử lý tài sản khác</a>
                                                    <br>
                                                    <span class="HotNews_DateText">Ngày cập nhật:</span> <span class="HotNews_date">2013-07-29
                                                        15:05:17</span>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tbody>
                                            <tr>
                                                <td class="OtherNews_td">
                                                    <a class="link_OtherNews" href="#" style="font-weight: bold">Đề nghị trang cấp tài sản
                                                        khác</a>
                                                    <br>
                                                    <span class="HotNews_DateText">Ngày cập nhật:</span> <span class="HotNews_date">2013-07-29
                                                        14:10:57</span>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                          
                        </tbody>
                    </table>
                </td>

                <td style="width: 60%; padding-left: 5px; padding-right: 8px; border-left: 1px solid rgb(229, 229, 229);"
                    valign="top">
                    <table id="Table8" style="width: 100%; border-collapse: collapse;" border="0" cellspacing="0">
                        <tbody>
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tbody>
                                            <tr>
                                                <td class="OtherNews_td">
                                                    <a class="link_OtherNews" href="#" style="font-weight: bold">Kê khai tài sản khác</a>
                                                    <br>
                                                    <span class="HotNews_DateText">Ngày cập nhật:</span> <span class="HotNews_date">2013-07-21
                                                        23:17:05</span>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tbody>
                                            <tr>
                                                <td class="OtherNews_td">
                                                    <a class="link_OtherNews" href="#" style="font-weight: bold">Đề nghị xử lý tài sản khác</a>
                                                    <br>
                                                    <span class="HotNews_DateText">Ngày cập nhật:</span> <span class="HotNews_date">2013-07-16
                                                        23:27:22</span>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tbody>
                                            <tr>
                                                <td class="OtherNews_td">
                                                    <a class="link_OtherNews" href="#" style="font-weight: bold">Khấu hao tài sản khác</a>
                                                    <br>
                                                    <span class="HotNews_DateText">Ngày cập nhật:</span> <span class="HotNews_date">2013-07-16
                                                        23:22:17</span>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>

            </tr>
        </tbody>
    </table>
    <!-- Ket thuc bang Tai San Khac-->

    </div>
    
</asp:Content>
