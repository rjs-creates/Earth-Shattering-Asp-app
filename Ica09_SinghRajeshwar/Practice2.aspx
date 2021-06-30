<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" Theme="ADO" AutoEventWireup="true" CodeFile="Practice2.aspx.cs" Inherits="Practice2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:Label runat="server" Text="" ><H2> Practice Ica11 - ADO Part 1 - Basic Queries</H2></asp:Label><hr />
    <asp:Label ID="Label1" runat="server" Text="Pick a Supplier:"></asp:Label>
    <asp:DropDownList ID="DropDownListSupplier"  OnSelectedIndexChanged="DropDownListSupplier_SelectedIndexChanged"  runat="server"></asp:DropDownList>
    <asp:TextBox ID="TextBoxfilter" runat="server"></asp:TextBox>
    <asp:Button ID="ButtonFilter" runat="server" onclick="ButtonFilter_Click" Text="filter"  Width="85px" /><br />
    <asp:Table ID="Table1" runat="server"></asp:Table><hr />
    <asp:Label runat="server" Text="" ><H2> Practice Ica12</H2></asp:Label><hr />
    <asp:Label ID="Label2" runat="server" Text="Pick a Customer:"></asp:Label>
    <asp:DropDownList ID="DropDownList2"  runat="server"></asp:DropDownList>
    <asp:TextBox ID="TextBoxFilter2" runat="server"></asp:TextBox>
    <asp:Button ID="ButtonFilter2" onclick="ButtonFilter2_Click"  runat ="server" Text="filter"  Width="85px" /><br />
</asp:Content>

