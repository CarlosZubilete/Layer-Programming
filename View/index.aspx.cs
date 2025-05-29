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
        this.gridCartegorias_Load();
      }
    }
    private void gridCartegorias_Load()
    {
      DataTable tableCategorias = business.GetTable();
      gridCategorias.DataSource = tableCategorias;
      gridCategorias.DataBind();
    }

    protected void btnCategorias_Click(object sender, EventArgs e)
    {
      Boolean state;

      string inputName = txtCategorias.Text.Trim();
      if (string.IsNullOrEmpty(inputName))
      {
        lblMessage.Text = $"Please enter a category name";
        return;
      }

      state = business.AddCategory(txtCategorias.Text);
      if (state)
      {
        lblMessage.Text = $"Categoría agregada con exito";
      }
      else
      {
        lblMessage.Text = $"Could not add category.";
      }
      // Reloading the gridSucursales:
      this.gridCartegorias_Load();
      txtCategorias.Text = string.Empty;
    }
  }
}

// TODO: Changed the function name . All ingles
// TODO: Ask why use Object String to string