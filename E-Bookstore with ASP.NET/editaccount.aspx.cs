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

public partial class editaccount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack){
            if (Session["customerID"] != null)
            {
                int custID = int.Parse(Session["customerID"].ToString());
                DataSet1TableAdapters.customerTableAdapter Customer = new DataSet1TableAdapters.customerTableAdapter(); 
                DataSet1.customerDataTable CustomerData = new DataSet1.customerDataTable();
                Customer.FillByID(CustomerData, custID);
                NameTextBox.Text = CustomerData.Rows[0]["FName"].ToString();
                LastNameTextBox.Text = CustomerData.Rows[0]["LName"].ToString();
                AddressTextBox.Text = CustomerData.Rows[0]["Address"].ToString();
                PhoneTextBox.Text = CustomerData.Rows[0]["Phone"].ToString();
                UsernameTextBox.Text = CustomerData.Rows[0]["uname"].ToString();
                
                
            }
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (Session["customerID"] != null)
        {
            int custID = int.Parse(Session["customerID"].ToString());
            DataSet1TableAdapters.customerTableAdapter Customer = new DataSet1TableAdapters.customerTableAdapter();
            Customer.UpdateQuery(NameTextBox.Text, LastNameTextBox.Text, AddressTextBox.Text, PhoneTextBox.Text, UsernameTextBox.Text, PasswordTextBox.Text, custID);
            Response.Redirect("home.aspx");
        }
    }
}
