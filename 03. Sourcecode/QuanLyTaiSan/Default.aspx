<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35" TagPrefix="asp" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style2
        {
            width: 712px;
        }
    </style>
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
    <table align="center" width="100%">
        <tr>
            <td width="30%" align="right"><a>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/pager/dat.jpg" 
                    Width="30%"/>
                    </a></td>
        </tr>
        <tr><td></td>
            <td></td>
            </tr>
        <tr><td align="right"><a>
                <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/pager/nha.jpg" Width="30%"/>
                </a></td>
            <td></td>
            </tr>
        <tr><td></td>
            <td></td>
            </tr>
        <tr><td align="right"><a href="ChucNang/F500_QuanLyOto.aspx">
                <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/pager/oto.jpg" 
                    Width="30%"/></a></td>
            <td></td>
            </tr>
        <tr><td></td>
            <td></td>
            </tr>
        <tr><td align="right">
<a href="ChucNang/F200_DanhMucTaiSanKhac.aspx"><asp:Image ID="Image4" runat="server" ImageUrl="~/Images/pager/can-truc.jpg" 
                    Width="30%" />
                    </a></td>
            <td></td>
            </tr>
        <tr><td></td>
            <td></td>
            </tr>
    </table>
</asp:Content>
