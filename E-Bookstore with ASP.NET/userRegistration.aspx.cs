using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class userRegistration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        MultiView1.ActiveViewIndex = 0;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        try
        {
            DataSet1TableAdapters.customerTableAdapter customer = new DataSet1TableAdapters.customerTableAdapter();
            customer.Insert(NameTextBox.Text, LastNameTextBox.Text, AddressTextBox.Text, PhoneTextBox.Text, UsernameTextBox.Text, PasswordTextBox.Text);
            MultiView1.ActiveViewIndex = 1;
            Literal1.Text = "Η εγγραφή ολοκληρώθηκε";
        }
        catch (Exception ex)
        {
            MultiView1.ActiveViewIndex = 1;
            Literal1.Text = "Πρόβλημα κατά την εγγραφή"+ex.Message;
        }



    }
}
