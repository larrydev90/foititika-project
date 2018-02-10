<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="loginUser.aspx.cs" Inherits="loginUser" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <asp:MultiView ID="MultiView1" runat="server">
        <asp:View ID="View1" runat="server">
            <asp:Panel ID="Panel1" runat="server">

            <table width="600px">
        <tr>
            <td colspan="3"><h4>Είσοδος χρήστη</h4></td>
        </tr>
        <tr>
            <td style="width:40%" align="right" >Username : </td>
            <td style="width:40%" >
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </td>
            <td style="width:20%" >
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width:40%" align="right" >Password : </td>
            <td style="width:40%" >
                <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
            </td>
            <td style="width:20%" >
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="3" align="center">
                <asp:Button ID="Button1" runat="server" Text="Είσοδος" 
                    onclick="Button1_Click" />
            </td>
        
        </tr>
            <tr>
            <td colspan="3" align="center">
                <br />
                Ξεχάσατε τον Κωδικό σας; Πατήστε 
                <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">Εδώ</asp:LinkButton>
                &nbsp;για το στείλουμε στο email σας.
            </td>
        
        </tr>
        <tr>
            <td colspan="3" align="center">
                <br />
                Δεν έχετε εγγραφή; Πατήστε 
                <asp:HyperLink ID="HyperLink2" runat="server" 
                    NavigateUrl="~/userRegistration.aspx">Εδώ </asp:HyperLink>
                για εγγραφή
            </td>
        
        </tr>
    </table>
        </asp:Panel>
    
         <asp:Panel ID="Panel2" runat="server" Visible="False">

            <table width="600px">
        <tr>
            <td colspan="3"><h4>Αποστολή συνθηματικού&nbsp; χρήστη</h4></td>
        </tr>
        <tr>
            <td style="width:40%" align="right" >Email : </td>
            <td style="width:40%" >
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            </td>
            <td style="width:20%" >
               <asp:Button ID="Button2" runat="server" Text="Αποστολή" />
            </td>
        </tr>
       
     
    </table>
        </asp:Panel>
        </asp:View>
        <asp:View ID="View2" runat="server">
            <table width="600px">
                <tr>
                    <td  align="center">
                <br />
                <asp:Button ID="Button3" runat="server" Text="Αποσύνδεση" onclick="Button3_Click"/>
                </td>
        
            </tr>
            </table>
        </asp:View>
    </asp:MultiView>

</asp:Content>

