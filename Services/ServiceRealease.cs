using JobOverview.Controllers;
using JobOverview.Data;
using JobOverview.Model;
using Microsoft.EntityFrameworkCore;


namespace JobOverview.Services
{

   public interface IServiceRelease
   {

      Task<List<Release>> ObtenirRelease();

      Task<Release?> ObtenirReleaseById(int id);

   }
   public class ServiceRealease : IServiceRelease
   {
      private JobOverviewContext _context;

      public ServiceRealease(JobOverviewContext context)
      {
         _context = context;
      }

      public async Task<List<Release>> ObtenirRelease()
      {
         return await _context.Release.ToListAsync();
      }

      public async Task<Release?> ObtenirReleaseById(int id)
      {
         return await _context.Release.FindAsync(id); 
      }
   }
}
