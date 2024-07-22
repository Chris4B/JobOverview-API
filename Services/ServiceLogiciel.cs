using JobOverview.Data;
using JobOverview.Model;
using Microsoft.EntityFrameworkCore;

namespace JobOverview.Services
{
   public interface IServiceLogiciels
   {
      Task<List<Logiciel>> ObtenirLogiciels();
      Task<Logiciel?> ObtenirLogicielId(int id);
   }

   public class ServiceLogiciel: IServiceLogiciels

   {
      private readonly JobOverviewContext _context;

      public ServiceLogiciel(JobOverviewContext context)
      {
         _context = context;
      }

      public async Task<List<Logiciel>> ObtenirLogiciels()
      {
         return await _context.Logiciel.ToListAsync();
      }

      public async Task<Logiciel?> ObtenirLogicielId(int id)
      {
         return await _context.Logiciel.FindAsync(id);
      }
   }
}
