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

public partial class ShowCart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Cart"] != null)
        {
            Literal1.Text = "<table><tr><td>Κωδικός</td><td>Τίτλος Βιβλίου</td><td>τιμή</td></tr>";
            Cart myCart = new Cart(); 
            CartItem tempItem;
            myCart = (Cart) Session["Cart"];
            for (int i=0; i<myCart.getItems().Count;i++){
                tempItem = (CartItem) myCart.getItems()[i];
                Literal1.Text += "<tr><td>" + tempItem.ProductID+"</td>";
                Literal1.Text += "<td>" + tempItem.ProductName + "</td>";
                Literal1.Text += "<td>" + tempItem.Price.ToString() + "</td></tr>";
            }

            Literal1.Text += "</table>";



        }
            

    }
}
