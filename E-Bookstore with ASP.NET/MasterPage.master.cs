using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;

using System.Data.OleDb;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
    
        OleDbConnection DB = new OleDbConnection();
        OleDbCommand query = new OleDbCommand();		

        DB.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;"+
                              "data source="+Server.MapPath("~/ebookstoredb.mdb") +
	                          ";persist security info=True";
        DB.Open();
        query.Connection = DB;
        query.CommandText = "select id, name from category";
        Literal1.Text = "<ul>";
        Menu3.Visible = false;
        Menu2.Visible = false;
        if (Session["admin"] != null)
            Menu3.Visible = true;
        if (Session["customerID"] != null)
            Menu2.Visible = true;


    }
}
