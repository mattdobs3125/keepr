using System;
using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class VKController : Controller
    {
        VaultKeepRepository _repo;
        public VKController(VaultKeepRepository repo) => _repo = repo;
        [HttpGet("{id}")]
        public IEnumerable<VaultKeep> GetKeepsForVault([FromRoute] int id) => _repo.GetbyId(id);
        [HttpGet]
        public IEnumerable<VaultKeep> Get() => _repo.GetAll();
    [HttpDelete]
    // deletes
    public void Delete([FromBody] VaultKeep vk)
    {
      if (vk.UserId == HttpContext.User.Identity.Name)
      {
        _repo.Delete(vk.VaultId);
      }
      else throw new Exception("You can't delete another users vault");
    }
  [HttpPost]
//   Creates a vk
    public VaultKeep Post([FromBody] VaultKeep vk)
    {
      if (ModelState.IsValid)
      {
        return _repo.Create(vk);
      }
      throw new Exception("Invail entry");
    }



    }
}