using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
//sing DataAccess; 

namespace Data
{
  public class DaoCategory
  {
    // D.A.O : Data Access Object
    public DaoCategory() { }

    DataAccess dataAccess = new DataAccess();

    public DataTable GetTableCategory()
    {
      DataTable dataTable = dataAccess.GetDataTable("Categoria", "SELECT * FROM Categorías");
      return dataTable;
    }
   
    /*
   public DaoCategory GetCategory(Category category)
   {
     DataTable dataTable = dataAccess.GetDataTable("Categoria", "SELECT * FROM Categoria where IdCategoria = " + category.GetIdCategory());

   }
   */
  }
}
