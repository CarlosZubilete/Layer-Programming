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
    public DataTable GetTable()
    {
      DaoCategory dao = new DaoCategory();
      return dao.GetTableCategory();
    }

    public bool AddCategory(String nameCategory)
    {
      int cantRows = 0;
      Category category = new Category();
      //category.Name(nameCategory);
      category.Name = nameCategory;
      DaoCategory dao = new DaoCategory();
      
      if (!dao.IsCategoryRepeat(category))
      {
        cantRows = dao.AddCategory(category);
      }

      if (cantRows == 1)
        return true;
      else
        return false;
    }
  }
}
