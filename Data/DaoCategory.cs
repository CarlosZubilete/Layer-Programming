using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entities;

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

    // IsCategoryNameRepeat
    public Boolean IsCategoryRepeat(Category category)
    {
      //String query = "SELECT * FROM Categorías WHERE NombreCategoría = " + category.getName();
      String query = $"SELECT * FROM Categorías WHERE NombreCategoría = '{category.getName()}'";
      return dataAccess.IsExists(query);
    }

    public int AddCategory(Category category)
    {
      category.setId(dataAccess.GetMax("SELECT max(IdCategoría) FROM Categorías") + 1 );
      SqlCommand command = new SqlCommand();
      this.ArmarParametrosCategoriasAgregar(ref command, category);
      return dataAccess.ExecuteNoQuery(command, "spAgregarCategoria");
    }

    private void ArmarParametrosCategoriasAgregar(ref SqlCommand command , Category category)
    {
      SqlParameter parameter = new SqlParameter();
      
      parameter = command.Parameters.Add("@IDCATEGORIA", SqlDbType.Int);
      parameter.Value = category.getId();

      parameter = command.Parameters.Add("@NOMBRECAT", SqlDbType.VarChar);
      parameter.Value = category.getName();
    }

    /*
   public DaoCategory GetCategory(Category category)
   {
     DataTable dataTable = dataAccess.GetDataTable("Categoria", "SELECT * FROM Categoria where IdCategoria = " + category.GetIdCategory());

   }
   */
  }
}

// PROCEDURE 
/*
Use Neptuno
go 

CREATE PROCEDURE [dbo].[spAgregarCategoria](
	@IDCATEGORIA INT,
	@NOMBRECAT NVARCHAR(25)
)
AS INSERT INTO Categorías(IdCategoría,NombreCategoría) 
VALUES (@IDCATEGORIA,@NOMBRECAT)
RETURN
 
*/
/*
USE Neptuno 
GO 

CREATE PROCEDURE [dbo].[spEliminarCategoria](
@IDCATEGORIA int
)
AS
  DELETE Categorías WHERE IdCategoría = @IDCATEGORIA
	RETURN
*/