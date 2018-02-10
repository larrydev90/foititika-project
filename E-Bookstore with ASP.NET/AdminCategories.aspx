<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AdminCategories.aspx.cs" Inherits="AdminCategories" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="ID" DataSourceID="AccessDataSource1">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" 
                ReadOnly="True" SortExpression="ID" />
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
            <asp:CommandField ShowEditButton="True" />
        </Columns>
    </asp:GridView>
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" DataKeyNames="ID" DataSourceID="ObjectDataSource1" 
        ForeColor="#333333" GridLines="None">
        <RowStyle BackColor="#EFF3FB" />
        <Columns>
            <asp:CommandField ShowEditButton="True" />
            <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" 
                ReadOnly="True" SortExpression="ID" />
            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
        </Columns>
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#2461BF" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
        DeleteMethod="Delete" InsertMethod="Insert" 
        OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" 
        TypeName="DataSet1TableAdapters.categoryTableAdapter" UpdateMethod="Update">
        <DeleteParameters>
            <asp:Parameter Name="Original_ID" Type="Int32" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="Name" Type="String" />
            <asp:Parameter Name="Original_ID" Type="Int32" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="Name" Type="String" />
        </InsertParameters>
    </asp:ObjectDataSource>
    <asp:AccessDataSource ID="AccessDataSource1" runat="server" 
        DataFile="~/ebookstoredb.mdb" SelectCommand="SELECT * FROM [category]" 
        UpdateCommand="UPDATE category SET  Name = @Name  where ID = @ID">
        <UpdateParameters>
            <asp:ControlParameter ControlID="GridView1" Name="Name" 
                PropertyName="SelectedValue" />
            <asp:ControlParameter ControlID="GridView1" Name="ID" 
                PropertyName="SelectedValue" />
        </UpdateParameters>
    </asp:AccessDataSource>
    <br />
</asp:Content>

