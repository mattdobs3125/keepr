using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using keepr.Repositories;
using System.Collections.Generic;
using keepr.Models;
using System;

namespace keepr.Controllers
{
  [Authorize]
  [Route("api/[controller]")]
  [ApiController]
    public class VaultController : Controller
    {
    VaultRepository _repo;
        public VaultController(VaultRepository repo) => _repo = repo;
        //get all
        [HttpGet]
        public IEnumerable<Vault> Get() => _repo.GetAll();
        //get vault by id 
        [HttpGet("{id}")]
        public Vault GetVaultByID([FromRoute] int id) => _repo.GetByID(id);
        [HttpPut]
        [Authorize]
        public Vault Put([FromBody] Vault vault) => _repo.Update(vault);
        [Authorize]
        [HttpDelete("{id}")]
        public void Delete([FromRoute] int id) => _repo.Delete(id);
 public Vault Post([FromBody] Vault vault)
{
   
  if (ModelState.IsValid)
      {
        vault.UserId = HttpContext.User.Identity.Name;
        return _repo.Create(vault);
      }
      throw new Exception("INVALID KEEP");
}


    }
}