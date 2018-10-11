using Microsoft.AspNetCore.Mvc;
using keepr.Repositories;
using System.Collections.Generic;
using keepr.Models;
using System;
using Microsoft.AspNetCore.Authorization;

namespace keepr.Controllers
{
    
[Route("api/[controller]")]
[ApiController]
    public class KeepController : Controller
{
KeepsRepository _repo;
public KeepController(KeepsRepository repo)
{
    _repo = repo;
}
[HttpGet]
public IEnumerable<Keep>Get()
{
    return _repo.GetAll();
}
//update
 [HttpPut]
 [Authorize]
    public Keep Put( [FromBody] Keep keep)
    {
        return _repo.Update(keep);
    }
//create
// [Authorize]
[HttpPost]
public Keep Post([FromBody] Keep keep)
{
   
  if (ModelState.IsValid)
      {
        keep = new Keep(keep.Name,keep.Description,keep.UserId,keep.IsPrivate,keep.Img);
        return _repo.Create(keep);
      }
      throw new Exception("INVALID KEEP");
}
//delete
    [Authorize]
    [HttpDelete("{id}")]
    public void Delete([FromRoute] int id)
    {
      _repo.Delete(id);
    }

}
}