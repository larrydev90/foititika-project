<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ProductsPerCategory.aspx.cs" Inherits="ProductsPerCategory" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetDataByCategoryID" 
        TypeName="DataSet1TableAdapters.productTableAdapter" 
        onselecting="ObjectDataSource1_Selecting">
        <SelectParameters>
            <asp:QueryStringParameter Name="catID" QueryStringField="catID" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
    CellPadding="4" DataKeyNames="ID" DataSourceID="ObjectDataSource1" 
    ForeColor="Black" GridLines="Vertical" BackColor="White" BorderColor="#DEDFDE" 
        BorderStyle="None" BorderWidth="1px" AllowPaging="True" PageSize="2">
        <RowStyle BackColor="#F7F7DE" />
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" 
                ReadOnly="True" SortExpression="ID" />
            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
            <asp:BoundField DataField="Description" HeaderText="Description" 
                SortExpression="Description" />
            <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
            <asp:BoundField DataField="CategoryID" HeaderText="CategoryID" 
                SortExpression="CategoryID" />
            <asp:BoundField DataField="CategoryName" HeaderText="CategoryName" 
                SortExpression="CategoryName" />
        </Columns>
        <FooterStyle BackColor="#CCCC99" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    <br />
</asp:Content>

