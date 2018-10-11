using System.Collections.Generic;
using System.Data;
using System.Linq;
using keepr.Models;
using Dapper;

namespace keepr.Repositories
{

  public class KeepsRepository
  {
        private const string _put= @"
      UPDATE keeps SET (name, description, price) 
      VALUES (@Name, @Description, @Price)
      WHERE id = @Id;";
        private const string _create= @"
            INSERT INTO keeps (name, description, userId, img, isPrivate )
            VALUES (@name, @description, @userId, @img, @isPrivate);
            SELECT LAST_INSERT_ID();";
        private IDbConnection _db;

    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    //CRUD VIA SQL

    //GET ALL keeps
    public IEnumerable<Keep> GetAll()
    {
      return _db.Query<Keep>("SELECT * FROM keeps;");
    }

    //GET BY ID
    public Keep GetById(int id)
    {
      return _db.Query<Keep>("SELECT * FROM keep WHERE id = @id;", new { id }).FirstOrDefault();
    }

    //CREATE Keep
    public Keep Create(Keep keep)
    {
      int id = _db.ExecuteScalar<int>(_create, keep
      );
      keep.Id = id;
      return keep;
    }

    //UPDATE Keep
    public Keep Update(Keep keep)
    {
      _db.Execute(_put, keep);
      return keep;
    }
// delete keep by id
    public int Delete(int id)
    {
      return _db.Execute("DELETE FROM keeps WHERE id = @id", new { id });
    }
    //DELETE keep
    public Keep Delete(Keep keep)
    {
      _db.Execute("DELETE FROM keeps WHERE id = @Id", keep);
      return keep;
    }



  }

}