using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JobOverview.Data;
using JobOverview.Model;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using JobOverview.Services;

namespace JobOverview.Controllers
{
   [ApiController]
   [Route("api/[controller]")]
   public class ModulesController : ControllerBase
   {
      private readonly IServiceModule _serviceModule;

      public ModulesController(IServiceModule service)
      {
         _serviceModule = service;
      }

      // Get: api/module
      [HttpGet]
      public async Task<ActionResult<IEnumerable<Module>>> GetModules()
      {
         var Modules = await _serviceModule.ObtenirModules();

         return Ok(Modules);
      }


      //Get api/module/x
      [HttpGet("{id}")]
      public async Task<ActionResult<Module>> GetModuleId(int id)
      {
         var Module = await _serviceModule.ObtenirModuleById(id);

         if(Module == null)
         {
            return NotFound();
         }

         return Ok(Module);
      }
   }
}
