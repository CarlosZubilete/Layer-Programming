using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Data;


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

  }
}
