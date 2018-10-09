using System.Collections.Generic;
using System.Data;
using System.Linq;
using keepr.Models;
using Dapper;

namespace burgershack.Repositories
{

  public class KeepsRepository
  {
    private IDbConnection _db;

    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    //CRUD VIA SQL

    //GET ALL BURGERS
    public IEnumerable<Keep> GetAll()
    {
      return _db.Query<Keep>("SELECT * FROM keeps;");
    }

    //GET BURGER BY ID
    public Keep GetById(int id)
    {
      return _db.Query<Keep>("SELECT * FROM keep WHERE id = @id;", new { id }).FirstOrDefault();
    }

    //CREATE Keep
    public Keep Create(Keep keep)
    {
      int id = _db.ExecuteScalar<int>(@"
    (name, description, userId, isPrivate, img)
            VALUES (@Name, @Description, @userId, @isPrivate, @img);
            SELECT LAST_INSERT_ID();", keep
      );
      keep.Id = id;
      return keep;
    }

    //UPDATE BURGER
    public Keep Update(Keep keep)
    {
      _db.Execute(@"
      UPDATE keeps SET (name, description, price) 
      VALUES (@Name, @Description, @Price)
      WHERE id = @Id
      ", keep);
      return keep;
    }

    //DELETE BURGER
    public Keep Delete(Keep keep)
    {
      _db.Execute("DELETE FROM burgers WHERE id = @Id", keep);
      return keep;
    }

    public int Delete(int id)
    {
      return _db.Execute("DELETE FROM keeps WHERE id = @id", new { id });
    }


  }

}