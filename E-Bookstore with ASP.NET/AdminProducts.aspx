<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminProducts.aspx.cs" Inherits="AdminProducts" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        DeleteMethod="Delete" InsertMethod="Insert" 
        OldValuesParameterFormatString="original_{0}" 
        onselecting="ObjectDataSource1_Selecting" SelectMethod="GetData" 
        TypeName="DataSet1TableAdapters.productTableAdapter" UpdateMethod="Update">
        <DeleteParameters>
            <asp:Parameter Name="Original_ID" Type="Int32" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="Title" Type="String" />
            <asp:Parameter Name="Description" Type="String" />
            <asp:Parameter Name="Price" Type="Single" />
            <asp:Parameter Name="Category" Type="Int32" />
            <asp:Parameter Name="Original_ID" Type="Int32" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="Title" Type="String" />
            <asp:Parameter Name="Description" Type="String" />
            <asp:Parameter Name="Price" Type="Single" />
            <asp:Parameter Name="Category" Type="Int32" />
        </InsertParameters>
    </asp:ObjectDataSource>
    
    <asp:GridView ID="GridView1" runat="server" AllowSorting="True" 
        AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="ObjectDataSource1">
        <Columns>
            <asp:CommandField ShowEditButton="True" />
            <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" 
                ReadOnly="True" SortExpression="ID" />
            <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
            <asp:BoundField DataField="Description" HeaderText="Description" 
                SortExpression="Description" />
            <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
            <asp:BoundField DataField="CategoryID" HeaderText="CategoryID" 
                SortExpression="CategoryID" Visible="False" />
            <asp:BoundField DataField="CategoryName" HeaderText="CategoryName" 
                SortExpression="CategoryName" />
        </Columns>
    </asp:GridView>
</asp:Content>

