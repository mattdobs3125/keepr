using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;


namespace keepr.Repositories
{
    public class VaultKeepRepository
    {
        private const string GBuID = "SELECT * FROM vaultkeeps WHERE userId=@userId;";
        private const string _create = "INSERT INTO vaultkeeps (vaultid, keepid, userid) Values (@VaultId, @KeepId, @UserId); SELECT LAST_INSERT_ID();";
        private const string _put = "UPDATE vaultkeeps SET vaultid = @VaultId, keepid = @KeepId WHERE id = @Id;";
        private const string GBID = " SELECT * FROM vaultkeeps WHERE vaultId = @id;";
        private const string _delete = "DELETE FROM vaultkeeps WHERE vaultId = @vaultId";
        private IDbConnection _db;
        public VaultKeepRepository(IDbConnection db)
        {
            _db = db;
        }
        //deletes by id
        public int Delete(int Vid) => _db.Execute(_delete, new { Vid });
        //GetAll
        public IEnumerable<VaultKeep> GetAll() => _db.Query<VaultKeep>("SELECT * FROM vaultkeeps;");
        //
        public IEnumerable<VaultKeep> GetbyId(int id) => _db.Query<VaultKeep>(GBID, new { id });

        //get the vk by userid
        public IEnumerable<Keep> GetByuId (string uId) => _db.Query<Keep>(GBuID, new { uId });
        
        public VaultKeep Create (VaultKeep vk)
        {
      int create= _db.ExecuteScalar<int>(_create, vk);
      if (create == 0)return null;
      vk.Id = create;
      return vk;
        }

    public VaultKeep Update(VaultKeep vk)
    {
      _db.Execute(_put, vk);
      return vk;
    }

    }
}

