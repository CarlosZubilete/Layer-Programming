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
    private readonly BusinessCategory _business = new BusinessCategory();
    protected void Page_Load(object sender, EventArgs e)
    {
      if (!IsPostBack)
      {
        this.GridCartegorias_Load();
      }
    }
    private void GridCartegorias_Load()
    {
      DataTable tableCategorias = _business.GetTable();
      gridCategorias.DataSource = tableCategorias;
      gridCategorias.DataBind();
    }

    protected void BtnCategorias_Click(object sender, EventArgs e)
    {
      Boolean state;

      String inputName = txtCategorias.Text.Trim();
      if (String.IsNullOrEmpty(inputName))
      {
        lblMessage.Text = $"Please enter a category name";
        return;
      }

      state = _business.AddCategory(inputName);
      if (state)
      {
        lblMessage.Text = $"Categoría agregada con exito";
      }
      else
      {
        lblMessage.Text = $"Could not add category.";
      }
      // Reloading the gridSucursales:
      this.GridCartegorias_Load();
      txtCategorias.Text = string.Empty;
    }
  }
}

// TODO: Changed the function name . All ingles
// TODO: Ask why use Object String to string