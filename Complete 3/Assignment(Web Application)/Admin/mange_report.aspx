<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin-Panel.Master" AutoEventWireup="true" CodeBehind="mange_report.aspx.cs" Inherits="Assignment_Web_Application_.Admin.mange_report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 align="center">Manage Report</h1>
    <asp:Panel ID="pnlSelection" runat="server" >
        <div style=" margin: auto; width: 60%; ">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="rblSelection" Display="Dynamic" ErrorMessage="Selection Cannot Be Empty" ForeColor="Red"></asp:RequiredFieldValidator>
        <asp:RadioButtonList ID="rblSelection" runat="server" CellPadding="20" CellSpacing="20">
            <asp:ListItem Value="Summary">Summary Report</asp:ListItem>
            <asp:ListItem Value="Detail">Detail Report</asp:ListItem>
        </asp:RadioButtonList>
        <br />
        <asp:Button ID="btnSubmitSelection" runat="server" Text="Submit" OnClick="btnSubmitSelection_Click" />
            </div>
    </asp:Panel>

    <asp:Panel ID="pnlSummary" runat="server" Visible="False">
        <div style=" margin: auto; width: 60%; ">

            <table>
                <tr><td>Start Date :</td><td>
                    <asp:CustomValidator ID="cvStart" runat="server" Display="Dynamic" ErrorMessage="[Start Date] must be selected a date" ForeColor="Red" OnServerValidate="cvStart_ServerValidate"></asp:CustomValidator>
                    <asp:Calendar ID="cldstart" runat="server"></asp:Calendar>
                </td></tr>
                <tr><td>End Date:</td><td>
                    <asp:CustomValidator ID="cvEnd" runat="server" Display="Dynamic" ErrorMessage="[End Date] must be selected a date" ForeColor="Red" OnServerValidate="cvEnd_ServerValidate"></asp:CustomValidator>
                    <asp:Calendar ID="cldEnd" runat="server"></asp:Calendar> </td></tr>
            </table>

            <br />
            <asp:Button ID="btnCalender" runat="server" Text="Submit" OnClick="btnCalender_Click" />

            </div>


    </asp:Panel>


    <asp:Panel ID="pnlDetail" runat="server" Visible="False">
        <div style=" margin: auto; width: 60%; ">
            <table>
                <tr><td>Date :</td><td>
                    <asp:CustomValidator ID="cvDate" runat="server" Display="Dynamic" ErrorMessage="[Date] must be selected a date" ForeColor="Red" OnServerValidate="cvDate_ServerValidate"></asp:CustomValidator>
                    <asp:Calendar ID="cldDate" runat="server"></asp:Calendar>
                </td></tr>
            </table>

            <br />

            <asp:Button ID="btnDate" runat="server" Text="Submit" />
            </div>

    </asp:Panel>

    <asp:Panel ID="pnlSummaryResult" runat="server" Visible="False">
        
        
        <asp:Literal ID="litSummary" runat="server"></asp:Literal>

    </asp:Panel>

    <asp:Panel ID="pnlDetailResult" runat="server" Visible="False">
        
        
        <asp:Literal ID="litDetail" runat="server"></asp:Literal>

    </asp:Panel>
        
        
</asp:Content>
