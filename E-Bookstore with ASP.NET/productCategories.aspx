<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="productCategories.aspx.cs" Inherits="productCategories" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
    <asp:ListView ID="ListView1" runat="server" DataKeyNames="ID" 
        DataSourceID="ObjectDataSource1">
        <EmptyItemTemplate>
            <td runat="server" />
            </EmptyItemTemplate>
            <ItemTemplate>
                <td runat="server" style="background-color:#DCDCDC;color: #000000;">
                    <a href="ProductsPerCategory.aspx?catID=<%# Eval("ID") %>"> <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' /></a>
                    <br />
                </td>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <td runat="server" style="background-color:#FFF8DC;">
                    <a href="ProductsPerCategory.aspx?catID=<%# Eval("ID") %>"> <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' /></a>
                    <br />
                </td>
            </AlternatingItemTemplate>
            <EmptyDataTemplate>
                <table runat="server" 
                    style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                    <tr>
                        <td>
                            No data was returned.</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <InsertItemTemplate>
                <td runat="server" style="">
                    Name:
                    <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
                    <br />
                    <asp:Button ID="InsertButton" runat="server" CommandName="Insert" 
                        Text="Insert" />
                    <br />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                        Text="Clear" />
                    <br />
                </td>
            </InsertItemTemplate>
            <LayoutTemplate>
                <table runat="server">
                    <tr runat="server">
                        <td runat="server">
                            <table ID="groupPlaceholderContainer" runat="server" border="1" 
                                style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                                <tr ID="groupPlaceholder" runat="server">
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server">
                        <td runat="server" 
                            style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;">
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
            <EditItemTemplate>
                <td runat="server" style="background-color:#008A8C;color: #FFFFFF;">
                    ID:
                    <asp:Label ID="IDLabel1" runat="server" Text='<%# Eval("ID") %>' />
                    <br />
                    Name:
                    <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
                    <br />
                    <asp:Button ID="UpdateButton" runat="server" CommandName="Update" 
                        Text="Update" />
                    <br />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                        Text="Cancel" />
                    <br />
                </td>
            </EditItemTemplate>
            <GroupTemplate>
                <tr ID="itemPlaceholderContainer" runat="server">
                    <td ID="itemPlaceholder" runat="server">
                    </td>
                </tr>
            </GroupTemplate>
            <SelectedItemTemplate>
                <td runat="server" 
                    style="background-color:#008A8C;font-weight: bold;color: #FFFFFF;">
                    ID:
                    <asp:Label ID="IDLabel" runat="server" Text='<%# Eval("ID") %>' />
                    <br />
                    Name:
                    <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                    <br />
                </td>
            </SelectedItemTemplate>
    </asp:ListView>
</asp:Content>

