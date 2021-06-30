<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Ica13_SinghRajeshwar2.aspx.cs" Inherits="Ica13_SinghRajeshwar2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label runat="server" Text="" ><H2>Ica13 - Modify Order Details</H2></asp:Label><hr />
    <h2>Part 1 - Delete Order Details</h2><hr />
    <asp:Label ID="Label1" runat="server" Text="Enter OrderID:"></asp:Label>
    <asp:TextBox ID="TextBoxOrderID" runat="server"></asp:TextBox>
    <asp:Button ID="ButtonOrderDetails" runat="server" OnClick="ButtonOrderDetails_Click" Text="Get Order Details"/><br />

    <asp:GridView ID="GridView1" runat="server" BackColor="White" CssClass="center" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" GridLines="Vertical" DataSourceID="SqlDataSource1" AllowPaging="True" AutoGenerateColumns="False" ForeColor="Black" Height="215px" Width="609px" DataKeyNames="OrderID,ProductID">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
            <asp:BoundField DataField="OrderID" HeaderText="OrderID" SortExpression="OrderID" ReadOnly="True" />
            <asp:BoundField DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName" />
            <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" SortExpression="UnitPrice" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" SortExpression="Quantity" />
            <asp:BoundField DataField="Discount" HeaderText="Discount" SortExpression="Discount" />
        </Columns>
        <FooterStyle BackColor="#CCCC99" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <RowStyle BackColor="#F7F7DE" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FBFBF2" />
        <SortedAscendingHeaderStyle BackColor="#848384" />
        <SortedDescendingCellStyle BackColor="#EAEAD3" />
        <SortedDescendingHeaderStyle BackColor="#575357" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:r25_NorthwindDropdown %>" SelectCommand="SELECT [OrderID], [ProductID], [ProductName], [UnitPrice], [Quantity], [Discount] FROM [Order Details Extended] WHERE ([OrderID] = @OrderID)">
        <SelectParameters>
            <asp:ControlParameter ControlID="TextBoxOrderID" Name="OrderID" PropertyName="Text" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:Button ID="ButtonDeleteSelected" OnClick="ButtonDeleteSelected_Click" runat="server" Text="Delete Selected" />
    <asp:Label ID="LabelStatus" runat="server" Text="Status : "></asp:Label><br />
    <h2>Part 2 - Insert Order Details</h2><hr />
    <asp:Label ID="LabelenterOr" runat="server" Text="Enter OrderID:"></asp:Label>
    <asp:TextBox ID="TextBoxEnterOrder" runat="server"></asp:TextBox><br />
    <asp:Label ID="LabelSelectProduct" runat="server" Text="Select Product:"></asp:Label>
    <asp:DropDownList ID="DropDownList1" runat="server" DataSourceID="SqlDataSource2" DataTextField="ProductName" DataValueField="ProductID"></asp:DropDownList>

    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:r25_NorthwindDropdown %>" SelectCommand="SELECT [ProductName], [ProductID] FROM [Alphabetical list of products]"></asp:SqlDataSource><br />
     <asp:Label ID="LabelEnterQuantity" runat="server" Text="Enter Quantity:"></asp:Label>
    <asp:TextBox ID="TextBoxEnterQuantity" runat="server"></asp:TextBox><br />

    <asp:Button ID="ButtonInsertRecord"  OnClick="ButtonInsertRecord_Click" runat="server" Text="Insert Record" />
    <asp:Label ID="LabelStatus2" runat="server" Text="Status:"></asp:Label>

</asp:Content>

