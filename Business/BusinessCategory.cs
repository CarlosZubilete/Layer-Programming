using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Data;
using Entities;

namespace Business
{
  public class BusinessCategory
  {
    public BusinessCategory() { }
    public int GetMaxCategory()
    {
      DaoCategory dao =new DaoCategory();
      return dao.GetMaxCategoryId();
    }
    public Category GetCategory(int id)
    {
      Category category = new Category { Id = id };
      //category.Id = id;
      DaoCategory dao = new DaoCategory();
      return dao.GetCategoryById(category);
    }
    public DataTable GetAllCategories()
    {
      DaoCategory dao = new DaoCategory();
      return dao.GetAllCategories();
    }
   
    public bool AddCategory(String nameCategory)
    {
      int cantRows = 0;
      Category category = new Category { Name = nameCategory };
      DaoCategory dao = new DaoCategory();

      if (!dao.IsCategoryDuplicate(category))
      {
        cantRows = dao.AddCategory(category);
      }

      if (cantRows == 1)
        return true;
      else
        return false;
    }

    public bool DeleteCategory(int id)
    {
      int cantRows;
      Category category = new Category { Id = id };
      DaoCategory dao = new DaoCategory();

      cantRows = dao.DeteleCategory(category);

      if (cantRows == 1)
        return true;
      else
        return false;

    }
  }
}
