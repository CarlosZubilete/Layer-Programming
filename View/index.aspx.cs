using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Business;
using System.Data;
using Entities;

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
      DataTable tableCategorias = _business.GetAllCategories();
      gridCategorias.DataSource = tableCategorias;
      gridCategorias.DataBind();
    }

    protected void BtnAddCategorias_Click(object sender, EventArgs e)
    {
      Boolean state;

      String inputName = txtAddCategorias.Text.Trim();
      if (String.IsNullOrEmpty(inputName))
      {
        lblMessage.Text = $"Please enter a category name";
        return;
      }

      state = _business.AddCategory(inputName);
      if (state)
      {
        lblMessage.Text = $"Category added successfully.";
      }
      else
      {
        lblMessage.Text = $"Category's been in Database.";
      }
      // Reloading the gridSucursales:
      this.GridCartegorias_Load();
      txtAddCategorias.Text = string.Empty;
    }

    protected void BtnLookupCategory_Click(object sender, EventArgs e)
    {
      //Boolean state;
      String inputNumber = TxtLookupCategory.Text.Trim();

      if (String.IsNullOrEmpty(inputNumber))
      {
        lblLookupCategoryMsg.Text = $"Please enter a category Id";
        return;
      }
      if (Convert.ToInt32(inputNumber) > _business.GetMaxCategory() || Convert.ToInt32(inputNumber) < 1)
      {
        lblLookupCategoryMsg.Text = $"Category is not in DataBase";
        return;
      }

      Category category;
      category = _business.GetCategory(Convert.ToInt32(inputNumber));

      lblLookupCategoryId.Text = $"Id: {category.Id} ";
      lblLookupCategoryName.Text = $"Name: {category.Name}";
      lblLookupCategoryDescription.Text = $"Description:  {category.Description}";
    }
    protected void DeleteCategotyCategory_Click(object sender, EventArgs e)
    {
      String inputNumber = txtDeleteCategory.Text.Trim();

      if (String.IsNullOrEmpty(inputNumber))
      {
        lblShowDeleteError.Text = $"Please enter a category Id";
        return;
      }
      if (Convert.ToInt32(inputNumber) > _business.GetMaxCategory() || Convert.ToInt32(inputNumber) < 1)
      {
        lblShowDeleteError.Text = $"Category is not in DataBase";
        return;
      }

      if(_business.DeleteCategory(Convert.ToInt32(inputNumber)))
      {
        lblShowDelete.Text = $"Category deleted successfully";
        this.GridCartegorias_Load();
        txtDeleteCategory.Text = string.Empty;
      }
    }
  }
}

