<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" Theme="ADO" CodeFile="ica11_SinghRajeshwar.aspx.cs" Inherits="ica11_SinghRajeshwar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label runat="server" Text="" ><H2>Ica11 - ADO Part 1 - Basic Queries</H2></asp:Label><hr />
    <asp:Label ID="Label1" runat="server" Text="Pick a Supplier:"></asp:Label>
    <asp:DropDownList ID="DropDownListSupplier" onSelectedindexChanged="DropDownListSupplier_SelectedIndexChanged" runat="server"></asp:DropDownList>
    <asp:TextBox ID="TextBoxfilter" runat="server"></asp:TextBox>
    <asp:Button ID="ButtonFilter" runat="server" OnClick="ButtonFilter_Click" Text="filter"  Width="85px" /><br />
    <asp:Table  SkinID="table" runat="server" ID="TableData" BorderColor="Black" BorderStyle="Solid"  GridLines="Both" Width="28px" class="center" ></asp:Table>
</asp:Content>

