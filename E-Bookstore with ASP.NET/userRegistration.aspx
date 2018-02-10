<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="userRegistration.aspx.cs" Inherits="userRegistration" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
   
        <asp:MultiView ID="MultiView1" runat="server">
            <asp:View ID="View1" runat="server">
                <table width="600px">
                <tr>
                    <td colspan="3"><h4>Εγγραφή χρήστη</h4></td>
                </tr>
                <tr>
                    <td style="width:40%" align="right" >Όνομα : </td>
                    <td style="width:40%" >
                        <asp:TextBox ID="NameTextBox" runat="server"></asp:TextBox>
                    </td>
                    <td style="width:20%" >
                        <asp:RequiredFieldValidator ControlToValidate="NameTextBox" 
                            ID="RequiredFieldValidator1" runat="server" ErrorMessage="Υποχρεωτικό Πεδίο"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width:40%" align="right" >Eπώνυμο: </td>
                    <td style="width:40%" >
                        <asp:TextBox ID="LastNameTextBox" runat="server"></asp:TextBox>
                    </td>
                    <td style="width:20%" >
                        <asp:RequiredFieldValidator ControlToValidate="LastNameTextBox" 
                            ID="RequiredFieldValidator2" runat="server" ErrorMessage="Υποχρεωτικό Πεδίο"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width:40%" align="right" >Email : </td>
                    <td style="width:40%" >
                        <asp:TextBox ID="EmailTextBox" runat="server"></asp:TextBox>
                    </td>
                    <td style="width:20%" >
                        
                    </td>
                </tr>
                <tr>
                    <td style="width:40%" align="right" >Username : </td>
                    <td style="width:40%" >
                        <asp:TextBox ID="UsernameTextBox" runat="server"></asp:TextBox>
                    </td>
                    <td style="width:20%" >
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                            ControlToValidate="UsernameTextBox" ErrorMessage="Υποχρεωτικό Πεδίο"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width:40%" align="right" >Password : </td>
                    <td style="width:40%" >
                        <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                    <td style="width:20%" >
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width:40%" align="right" >Επιβεβαίωση Password : </td>
                    <td style="width:40%" >
                        <asp:TextBox ID="ConfirmPasswordTextBox" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                    <td style="width:20%" >
                        <asp:CompareValidator ID="CompareValidator1" runat="server" 
                            ControlToCompare="PasswordTextBox" ControlToValidate="ConfirmPasswordTextBox" 
                            ErrorMessage="Λάθος Επιβεβαίωση"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width:40%" align="right" >Διεύθυνση : </td>
                    <td style="width:40%" >
                        <asp:TextBox ID="AddressTextBox" runat="server" Rows="3" TextMode="MultiLine"></asp:TextBox>
                    </td>
                    <td style="width:20%" >
                        
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                            ControlToValidate="AddressTextBox" ErrorMessage="Υποχρεωτικό Πεδίο"></asp:RequiredFieldValidator>
                        
                    </td>
                </tr>
                <tr>
                    <td style="width:40%" align="right" >Τηλέφωνο Επικοινωνίας  : </td>
                    <td style="width:40%" >
                        <asp:TextBox ID="PhoneTextBox" runat="server" ></asp:TextBox>
                    </td>
                    <td style="width:20%" >
                        
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                            ControlToValidate="PhoneTextBox" ErrorMessage="Υποχρεωτικό Πεδίο"></asp:RequiredFieldValidator>
                        
                    </td>
                </tr>
                <tr>
                    <td style="width:40%" align="right" >ΤΚ  : </td>
                    <td style="width:40%" >
                        <asp:TextBox ID="PostalCodeTextBox" runat="server" ></asp:TextBox>
                    </td>
                    <td style="width:20%" >
                        
                    </td>
                </tr>
                <tr>
                    <td style="width:40%" align="right" >Πόλη  : </td>
                    <td style="width:40%" >
                        <asp:TextBox ID="CityTextBox" runat="server" ></asp:TextBox>
                    </td>
                    <td style="width:20%" >
                        
                    </td>
                </tr>
                <tr>
                    <td style="width:40%" align="right" >Χώρα  : </td>
                    <td style="width:40%" >
                        <asp:DropDownList ID="CountryDropDownList" runat="server">
                            <asp:ListItem Text="Ελλάδα" Value="Greece"></asp:ListItem>
                            <asp:ListItem Text="Κύπρος" Value="Cyprus"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td style="width:20%" >
                        
                    </td>
                </tr>
                <tr>
                    <td style="width:40%" align="right" >Φύλλο : </td>
                    <td style="width:40%" >
                        <asp:RadioButtonList ID="SexRadioButtonList" runat="server" 
                            RepeatDirection="Horizontal">
                            <asp:ListItem Value="M">Άνδρας</asp:ListItem>
                            <asp:ListItem Value="F">Γυναίκα</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td style="width:20%" >
                        
                    </td>
                </tr>
                    <tr>
                    <td style="width:40%" align="right" >Αποδοχή όρων: </td>
                    <td style="width:40%" >
                        <asp:CheckBox ID="CheckBox1" runat="server" />
                    </td>
                    <td style="width:20%" >
                        
                    </td>
                </tr>
                    </tr>
                <tr>
                    <td colspan="3" align="center" > 
                        <asp:Button ID="Button1" runat="server" Text="Εγγραφή" 
                            onclick="Button1_Click" />
                    </td>
                </tr>
            </table>
            </asp:View>
            <asp:View ID="View2" runat="server">
                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
            </asp:View>
        </asp:MultiView>
   
   
   </ContentTemplate>
   </asp:UpdatePanel>
</asp:Content>

