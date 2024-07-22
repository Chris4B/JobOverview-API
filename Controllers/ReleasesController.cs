using JobOverview.Model;
using JobOverview.Services;
using Microsoft.AspNetCore.Mvc;


namespace JobOverview.Controllers
{
   [ApiController]
   [Route("api")]
   public class ReleasesController: ControllerBase
   {
      private readonly IServiceRelease _serviceRelease;

      public ReleasesController(IServiceRelease service)
      {
         _serviceRelease = service;
      }

      //Get: api/release
      [HttpGet]
      public async Task<ActionResult<IEnumerable<Release>>> GetAll()
      {
         var releases = await _serviceRelease.ObtenirRelease();

         return Ok(releases);
      }


      //GetId : api/release/x
      [HttpGet("{id}")]
      public async Task<ActionResult<Release>> GetById(int id)
      {
         var release = await _serviceRelease.ObtenirReleaseById(id);

         if (release == null)
         {
            return NotFound();
         }

         return Ok(release);
      }
   }
}
