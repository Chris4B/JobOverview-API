using JobOverview.Data;
using JobOverview.Model;
using Microsoft.EntityFrameworkCore;

namespace JobOverview.Services
{
   public interface IServiceLogiciels
   {
      Task<List<Logiciel>> ObtenirLogiciels(string codeFiliere);
      Task<Logiciel?> ObtenirLogicielId(string id);
   }

   public class ServiceLogiciel: IServiceLogiciels

   {
      private readonly JobOverviewContext _context;

      public ServiceLogiciel(JobOverviewContext context)
      {
         _context = context;
      }

      public async Task<List<Logiciel>> ObtenirLogiciels( string codeFiliere)
      {
         var req = from l in _context.Logiciel
                   where l.CodeFiliere == codeFiliere
                   select l;

         return await req.ToListAsync();
      }

      public async Task<Logiciel?> ObtenirLogicielId(string id)
      {
         var req = from r in _context.Logiciel
                   .Include(r => r.Modules).ThenInclude(m =>m.SousModules)
                   where r.CodeLogiciel == id
                   select r;

         Logiciel? logiciel = await req.FirstOrDefaultAsync();

         if(logiciel == null) return null ;

         // transforme la liste des modules à plat en arborescence

         //var req2 = from m in logiciel.Modules
         //           where m.CodeModuleParent == null
         //           select new Module
         //           {
         //              CodeModule = m.CodeModule,
         //              Nom = m.Nom,
         //              CodeLogicielParent = m.CodeLogiciel,
         //              SousModules = (from sm in m.SousModules select sm).ToList()
         //           };

         //logiciel.Modules = req2.ToList();

         var modulesDict = logiciel.Modules.ToDictionary(m => m.CodeModule);

         foreach (var module in logiciel.Modules)
         {
            if (module.CodeModuleParent != null && modulesDict.TryGetValue(module.CodeModuleParent, out var parentModule))
            {
               parentModule.SousModules.Add(module);
            }
         }

         logiciel.Modules = logiciel.Modules.Where(m => m.CodeModuleParent == null).ToList();

         return logiciel;
      }
   }
}
