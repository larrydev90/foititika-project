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
using System.Data.OleDb;

public partial class loginUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["customerID"] == null)
            MultiView1.ActiveViewIndex = 0;
        else
            MultiView1.ActiveViewIndex = 1;

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        Panel2.Visible = true;
    }
protected void  Button1_Click(object sender, EventArgs e)
{
    
    /* Χωρίς την χρήση dataset
    OleDbConnection DB = new OleDbConnection();
    OleDbCommand query = new OleDbCommand();		

    DB.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;"+
                          "data source="+Server.MapPath("~/ebookstoredb.mdb") +
	                      ";persist security info=True";
    DB.Open();
    query.Connection = DB;
    query.CommandText = "Select ID from Customer where uname = '"+TextBox1.Text+"' and passwd ='"+TextBox2.Text+"'";
    try
    {
        OleDbDataReader myReader = query.ExecuteReader();
        while (myReader.Read())
        {
            Session.Add("customerID", myReader.GetValue(0).ToString());
            if (TextBox1.Text == "admin")
                Session.Add("admin", 1);
            Response.Redirect("home.aspx");
 

        }
    }
    finally
    {
        DB.Close();
    }
    */

    // Με την χρήση dataset
    DataSet1TableAdapters.customerTableAdapter Customer = new DataSet1TableAdapters.customerTableAdapter();
    DataSet1.customerDataTable CustomerData = new DataSet1.customerDataTable();
    Customer.FillByCred(CustomerData, TextBox1.Text, TextBox2.Text);
    if (CustomerData.Rows.Count > 0)
    {
        Session.Add("customerID", CustomerData.Rows[0]["ID"].ToString());
        if (TextBox1.Text == "admin")
            Session.Add("admin", 1);
        Response.Redirect("home.aspx");
    }



}
protected void Button3_Click(object sender, EventArgs e)
{
    Session.Clear();
    Response.Redirect("home.aspx");
}
}
