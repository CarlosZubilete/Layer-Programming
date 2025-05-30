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
  public class DaoCategory // D.A.O : Data Access Object
  {
    private readonly DataAccess _dataAccess = new DataAccess();
   
    public DaoCategory() { }
    public int GetMaxCategoryId( )
    {
      return _dataAccess.GetMaxCategoryId("SELECT max(IdCategoría) FROM Categorías");
    }
    public Category GetCategoryById(Category category)
    {
      DataTable dataTable = _dataAccess.GetDataTable("Categoria", "SELECT * FROM Categorías WHERE IdCategoría = " + category.Id);

      category.Id = Convert.ToInt32(dataTable.Rows[0][0].ToString());
      category.Name = dataTable.Rows[0][1].ToString();
      category.Description = dataTable.Rows[0][2].ToString();

      return category;

    }
    public DataTable GetAllCategories()
    {
      DataTable dataTable = _dataAccess.GetDataTable("Categoria", "SELECT * FROM Categorías");
      return dataTable;
    }
    public Boolean IsCategoryDuplicate(Category category)
    {
      String query = $"SELECT * FROM Categorías WHERE NombreCategoría = '{category.Name}'";
      return _dataAccess.RecordExists(query);
    }

    public int AddCategory(Category category)
    {
      category.Id = _dataAccess.GetMaxCategoryId("SELECT max(IdCategoría) FROM Categorías") + 1;
      SqlCommand command = new SqlCommand();
      this.BuildAddCategoryParameters(ref command, category);
      return _dataAccess.ExecuteStoredProcedure(command, "spAgregarCategoria");
    }
    public int DeteleCategory(Category category)
    {
      SqlCommand command = new SqlCommand();
      this.BuildDeleteCategoryParameters(ref command, category);
      return _dataAccess.ExecuteStoredProcedure(command, "spEliminarCategoria");
    }
    private void BuildAddCategoryParameters(ref SqlCommand command, Category category)
    {
      SqlParameter parameter; // = new SqlParameter();

      parameter = command.Parameters.Add("@IDCATEGORIA", SqlDbType.Int);
      parameter.Value = category.Id;

      parameter = command.Parameters.Add("@NOMBRECAT", SqlDbType.VarChar);
      parameter.Value = category.Name;
    }

    private void BuildDeleteCategoryParameters(ref SqlCommand command, Category category)
    {
      SqlParameter parameter; // = new SqlParameter();

      parameter = command.Parameters.Add("@IDCATEGORIA", SqlDbType.Int);
      parameter.Value = category.Id;
    }
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