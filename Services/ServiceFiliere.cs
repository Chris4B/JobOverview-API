using JobOverview.Data;
using JobOverview.Model;
using Microsoft.EntityFrameworkCore;

namespace JobOverview.Services
{
   
   public interface IServiceFiliere
   {
      public Task<List<Filiere>> ObtenirFiliere();

      public Task<Filiere?> ObtenirFiliereById(int id);
   }
   public class ServiceFiliere : IServiceFiliere
   {
      private readonly JobOverviewContext _context;


      public ServiceFiliere(JobOverviewContext context)
      {
         _context = context;
      }

      public async Task<List<Filiere>> ObtenirFiliere()
      {
         return await _context.Filiere.ToListAsync();
      }

      public async Task<Filiere?> ObtenirFiliereById(int id)
      {
         return await _context.Filiere.FindAsync(id);
      }
   }
}
