using JobOverview.Data;
using JobOverview.Model;
using Microsoft.EntityFrameworkCore;

namespace JobOverview.Services
{

   public interface IServiceModule
   {
      Task<List<Module>> ObtenirModules();

      Task<Module?> ObtenirModuleById(int id);
   }
   public class ServiceModule : IServiceModule 
   {
      private readonly JobOverviewContext _context;

      public ServiceModule(JobOverviewContext context)
      {
         _context = context;
      }

      public async Task<List<Module>> ObtenirModules()
      {
         var modules = await _context.Module.ToListAsync();
         
         return modules;
      }

      public async Task<Module?> ObtenirModuleById(int id)
      {
         var module = await _context.Module.FindAsync(id);

         return module;
      }
   }
}
