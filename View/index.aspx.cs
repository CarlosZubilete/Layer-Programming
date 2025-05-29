using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Business;
using System.Data;


namespace View
{
  public partial class WebApp_index : System.Web.UI.Page
  {
    BusinessCategory business = new BusinessCategory();
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        DataTable tableCategorias = business.GetTable();
        gridCategorias.DataSource = tableCategorias;
        gridCategorias.DataBind();
      }
    }
  }
}