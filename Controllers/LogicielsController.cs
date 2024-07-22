using Microsoft.AspNetCore.Mvc;
using JobOverview.Model;
using JobOverview.Services;

namespace JobOverview.Controllers
{
   [Route("api/[controller]")]
   [ApiController]
   public class LogicielController : ControllerBase
   {
      private readonly IServiceLogiciels  _serviceLogiciel;

      public LogicielController(IServiceLogiciels service)
      {
         _serviceLogiciel = service;
      }


      //Get: Api/Loigiciel
      [HttpGet]
      public async Task<ActionResult<IEnumerable<Logiciel>>> GetLogiciel()
      {
         var logiciels = await _serviceLogiciel.ObtenirLogiciels();

         return Ok(logiciels);
      }


      //Get: Api/Logiciel/2
      [HttpGet("{Id}")]
      public async Task<ActionResult<Logiciel>> GetLogiciel(int id)
      {
         var Logiciel = await _serviceLogiciel.ObtenirLogicielId(id);

         if (Logiciel == null)
         {
            return NotFound();
         }

         return Ok(Logiciel);
      }
   }
}
