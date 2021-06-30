<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ica12_SinghRajeshwar.aspx.cs" Inherits="ica12_SinghRajeshwar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label runat="server" Text="" ><H2>Ica12 - SP's for Customers Summary</H2></asp:Label><hr />
    <asp:Label ID="Label1" runat="server" Text="Pick a Customer:"></asp:Label>
    <asp:DropDownList ID="DropDownListCustomer" OnSelectedIndexChanged="DropDownListCustomer_SelectedIndexChanged"  runat="server"></asp:DropDownList>
    <asp:TextBox ID="TextBoxfilter" runat="server"></asp:TextBox>
    <asp:Button ID="ButtonFilter" runat="server" onclick="ButtonFilter_Click" Text="filter"  Width="85px" /><br />
    <asp:GridView ID="GridViewCategory" runat="server" CssClass="center" OnRowDataBound="GridViewCategory_RowDataBound" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" Width="439px">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="Gray" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
    </asp:GridView>
    <asp:Label ID="LabelNoRows"  CssClass="center" runat="server" Text=""></asp:Label>
</asp:Content>

