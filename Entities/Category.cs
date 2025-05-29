using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
  public class Category
  {
    private int _id;
    private String _name;
    private String _description;
    //  private String _urlImg;
    public Category() { }

    public int Id
    {
      get{ return _id;}
      set{ _id = value;}
    }

    public String Name
    {
      get { return _name; }
      set { _name = value; }
    }
    public String Description
    {
      get { return _description; }
      set { _description = value; }
    }
  }
}

/*
    public int getId()
    {
      return _id;
    }
    public String getName()
    {
      return _name;
    } 
    public String getDescription()
    {
      return _description;
    }
    public void setId(int id)
    {
      _id = id;
    }
    public void setName(String name)
    {
      _name = name;
    }
    public void setDescription(String description)
    {
      _description = description;
    }
 */