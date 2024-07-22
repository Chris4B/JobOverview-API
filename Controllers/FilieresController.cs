
using Microsoft.AspNetCore.Mvc;
using JobOverview.Model;
using JobOverview.Services;

namespace JobOverview.Controllers
{
   [ApiController]
   [Route("api/[controller]")]
   public class FilieresController : ControllerBase
   {
      private IServiceFiliere _serviceFiliere;

      public FilieresController(IServiceFiliere service)
      {
         _serviceFiliere = service;
      }

      //Get: api/filiere
      [HttpGet]
      public async  Task<ActionResult<IEnumerable<Filiere>>> GetFiliere()
      {
         var Filieres = await _serviceFiliere.ObtenirFiliere();

         return Ok(Filieres);
      }


      //Get: api/filiere/x
      [HttpGet("{id}")]
      public async Task<ActionResult<Filiere>> GetFiliereById(int id)
      {
         var Filiere = await _serviceFiliere.ObtenirFiliereById(id);

         return Ok(Filiere);
      }

   }
}
