<%@ Page Title="ica10_SinghRajeshwar" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ica10_SinghRajeshwar.aspx.cs" Inherits="ica10_SinghRajeshwar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <header ><asp:Label SkinID="Divider" runat="server" Text="" BackColor="wheat" ><H2>Ica10 - More Data - Aware Controls</H2></asp:Label></header><hr />
    <asp:SqlDataSource ID="SqlDataSourceDrop" runat="server" ConnectionString="<%$ ConnectionStrings:r25_NorthwindDropdown %>" SelectCommand="SELECT [CustomerID], [CompanyName] FROM [Customers]"></asp:SqlDataSource>
    Customer: <asp:DropDownList ID="DropDownListCompanyName" AutoPostBack="True" runat="server" DataSourceID="SqlDataSourceDrop" onselectedindexchanged="DropDownListCompanyName_SelectedIndexChanged" DataTextField="CompanyName" DataValueField="CustomerID">

              </asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSourceList" runat="server" ConnectionString="<%$ ConnectionStrings:r25_NorthwindDropdown %>" DeleteCommand="DELETE FROM [Orders] WHERE [OrderID] = @OrderID" InsertCommand="INSERT INTO [Orders] ([CustomerID], [OrderDate]) VALUES (@CustomerID, @OrderDate)" SelectCommand="SELECT [OrderID], [CustomerID], [OrderDate] FROM [Orders] WHERE ([CustomerID] = @CustomerID)" UpdateCommand="UPDATE [Orders] SET [CustomerID] = @CustomerID, [OrderDate] = @OrderDate WHERE [OrderID] = @OrderID">
        <DeleteParameters>
            <asp:Parameter Name="OrderID" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="CustomerID" Type="String" />
            <asp:Parameter Name="OrderDate" Type="DateTime" />
        </InsertParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="DropDownListCompanyName" Name="CustomerID" PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="CustomerID" Type="String" />
            <asp:Parameter Name="OrderDate" Type="DateTime" />
            <asp:Parameter Name="OrderID" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>

    <asp:SqlDataSource ID="SqlDataSourceAdd" runat="server" ConnectionString="<%$ ConnectionStrings:r25_NorthwindDropdown %>" SelectCommand="SELECT [CompanyName], [CustomerID] FROM [Customers]"></asp:SqlDataSource>

    <asp:ListView ID="ListView1" class="center" runat="server" DataKeyNames="OrderID" DataSourceID="SqlDataSourceList" InsertItemPosition="LastItem">
        <AlternatingItemTemplate>
            <tr style="background-color: #FAFAD2;color: #284775;">
                <td>
                    <asp:Button ID="SelectButton" runat="server" CommandName="Select" Text="Pick me" />
                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                    <asp:Button ID="EditButton" runat="server" Text="Edit" CommandName="Edit" />
                </td>
                <td>
                    <asp:Label ID="OrderIDLabel" runat="server" Text='<%# Eval("OrderID") %>' />
                </td>
                <td>
                    <asp:Label ID="CustomerIDLabel" runat="server" Text='<%# Eval("CustomerID") %>' />
                </td>
                <td>
                    <asp:Label ID="OrderDateLabel" runat="server" Text='<%# Eval("OrderDate") %>' />
                </td>
            </tr>
        </AlternatingItemTemplate>
        <EditItemTemplate>
            <tr style="background-color: #FFCC66;color: #000080;">
                <td>
                    <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                </td>
                <td>
                    <asp:Label ID="OrderIDLabel1" runat="server" Text='<%# Eval("OrderID") %>' />
                </td>
                <td>
                    <asp:TextBox ID="CustomerIDTextBox" runat="server" Text='<%# Bind("CustomerID") %>' />
                </td>
                <td>
                    <asp:TextBox ID="OrderDateTextBox" runat="server" Text='<%# Bind("OrderDate") %>' />
                </td>
            </tr>
        </EditItemTemplate>
        <EmptyDataTemplate>
            <table runat="server" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                <tr>
                    <td>No data was returned.</td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <InsertItemTemplate>
            <tr style="">
                <td>
                    <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                </td>
                <td>&nbsp;</td>
                <td>
                    <asp:DropDownList ID="DropDownList1" AutoPostBack="True"  DataSourceID="SqlDataSourceDrop" DataTextField="CompanyName" SelectedValue='<%# Bind("CustomerID") %>' DataValueField="CustomerID" runat="server"></asp:DropDownList>
                    <%--<asp:DropDownList ID="DropDownListCompanyName" AutoPostBack="True" runat="server" DataSourceID="SqlDataSourceDrop" DataTextField="CompanyName" DataValueField="CustomerID">--%>

              </asp:DropDownList>
                  
                    <%-- <asp:TextBox ID="CustomerIDTextBox" runat="server" Text='<%# Bind("CustomerID") %>' />--%>
                </td>
                <td>
                    <asp:Calendar ID="Calendar1" runat="server" SelectedDate='<%# Bind("OrderDate") %>'></asp:Calendar>
                    <%--<asp:TextBox ID="OrderDateTextBox" runat="server" Text='<%# Bind("OrderDate") %>' />--%>
                </td>
            </tr>
        </InsertItemTemplate>
        <ItemTemplate>
            <tr style="background-color: #FFFBD6;color: #333333;">
                <td>
                    <asp:Button ID="ButtonSelect2" runat="server" CommandName="Select" Text="Pick me" />
                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                    
                    <asp:Button ID="EditButton" runat="server" Text="Edit" CommandName="Edit" />
                </td>
                <td>
                    <asp:Label ID="OrderIDLabel" runat="server" Text='<%# Eval("OrderID") %>' />
                </td>
                <td>
                    <asp:Label ID="CustomerIDLabel" runat="server" Text='<%# Eval("CustomerID") %>' />
                </td>
                <td>
                    <asp:Label ID="OrderDateLabel" runat="server" Text='<%# Eval("OrderDate") %>' />
                </td>
            </tr>
        </ItemTemplate>
        <LayoutTemplate>
            <table runat="server">
                <tr runat="server">
                    <td runat="server">
                        <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                            <tr runat="server" style="background-color: #FFFBD6;color: #333333;">
                                <th runat="server"></th>
                                <th runat="server">OrderID</th>
                                <th runat="server">CustomerID</th>
                                <th runat="server">OrderDate</th>
                            </tr>
                            <tr id="itemPlaceholder" runat="server">
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr runat="server">
                    <td runat="server" style="text-align: center;background-color: #FFCC66;font-family: Verdana, Arial, Helvetica, sans-serif;color: #333333;">
                        <asp:DataPager ID="DataPager1" runat="server">
                            <Fields>
                                <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowLastPageButton="True" />
                            </Fields>
                        </asp:DataPager>
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
        <SelectedItemTemplate>
            <tr style="background-color: #FFCC66;font-weight: bold;color: #000080;">
                <td>
                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                </td>
                <td>
                    <asp:Label ID="OrderIDLabel" runat="server" Text='<%# Eval("OrderID") %>' />
                </td>
                <td>
                    <asp:Label ID="CustomerIDLabel" runat="server" Text='<%# Eval("CustomerID") %>' />
                </td>
                <td>
                    <asp:Label ID="OrderDateLabel" runat="server" Text='<%# Eval("OrderDate") %>' />
                </td>
            </tr>
        </SelectedItemTemplate>
    </asp:ListView>

    <asp:SqlDataSource ID="SqlDataSourceDrat" runat="server" ConnectionString="<%$ ConnectionStrings:r25_NorthwindDropdown %>" SelectCommand="SELECT [Order Details].OrderID, Categories.CategoryID, Categories.CategoryName, [Order Details].UnitPrice * [Order Details].Quantity AS 'Category Sum' FROM [Order Details] INNER JOIN Products ON [Order Details].ProductID = Products.ProductID INNER JOIN Categories ON Products.CategoryID = Categories.CategoryID WHERE [ORDER Details].OrderID = @PARAMETER">
        <SelectParameters>
            <asp:ControlParameter ControlID="ListView1" DefaultValue="0" Name="PARAMETER" PropertyName="SelectedValue" />
        </SelectParameters>
    </asp:SqlDataSource>

    <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="325px" AllowPaging="True" AutoGenerateRows="False" DataSourceID="SqlDataSourceDrat">
        <EmptyDataTemplate>
            Drat : Nothing to see here<br />
        </EmptyDataTemplate>
        <Fields>
            <asp:BoundField DataField="OrderID" HeaderText="OrderID" SortExpression="OrderID" />
            <asp:BoundField DataField="CategoryID" HeaderText="CategoryID" InsertVisible="False" ReadOnly="True" SortExpression="CategoryID" />
            <asp:BoundField DataField="CategoryName" HeaderText="CategoryName" SortExpression="CategoryName" />
            <asp:BoundField DataField="Category Sum" HeaderText="Category Sum" ReadOnly="True" SortExpression="Category Sum" />
        </Fields>
        <HeaderTemplate>
            Summary Category Details:View
        </HeaderTemplate>
    </asp:DetailsView>
</asp:Content>

