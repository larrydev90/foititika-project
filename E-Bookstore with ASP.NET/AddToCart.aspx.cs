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

public partial class AddToCart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Request.QueryString["pid"] != null) && (Request.QueryString["Title"] != null) && (Request.QueryString["Price"] != null))
        {
            if (Session["cart"] == null)
                Session.Add("cart", new Cart());
            ((Cart)Session["cart"]).addItem(Request.QueryString["pid"], Request.QueryString["Title"], double.Parse(Request.QueryString["Price"]));
        }
        Response.Redirect("showcart.aspx");
    }
}
