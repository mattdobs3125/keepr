using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{
    public class VaultRepository
    {
        private const string put = "UPDATE vaults SET name = @Name, description = @Description WHERE id = @Id;";
        private const string update = "INSERT INTO vaults (name, description, userid) Values (@Name, @Description, @UserId); SELECT LAST_INSERT_ID();";
        private const string GetById = "SELECT * FROM vaults WHERE id = @id;";
        private const string _GetAll = "SELECT * FROM vaults;";
        private const string _delete = "DELETE FROM vaults WHERE id = @id";
        private const string dv = "DELETE FROM vaults WHERE id = @Id";
        private IDbConnection _db;

        public VaultRepository(IDbConnection db) => _db = db;
        //get all vaults
        public IEnumerable<Vault> GetAll() => _db.Query<Vault>(_GetAll);
        public Vault GetByID(int id) => _db.Query<Vault>(GetById, new { id }).FirstOrDefault();
        //delete
        public int Delete(int id) => _db.Execute(_delete, new { id });
        // createing a vault
        public Vault Create(Vault vault)
    {
      int id = _db.ExecuteScalar<int>(update, vault);
      vault.Id = id;
      return vault;
    }
    //update vault datails

        public Vault Update(Vault vault)
    {
      _db.Execute(put, vault);
      return vault;
    }
       //delete vault
    public Vault Delete(Vault vault)
    {
      _db.Execute(dv);
      return vault;
    }
        



    }

}