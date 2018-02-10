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

public partial class ProductsPerCategory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
        ObjectDataSource1.SelectMethod = "GetDataByCategoryID";
        ObjectDataSource1.SelectParameters.Add("p_catID",Request.QueryString["catID"]);
        
        
    }
    protected void ObjectDataSource1_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
    {

    }
}
