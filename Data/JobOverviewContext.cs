using JobOverview.Model;
using Microsoft.EntityFrameworkCore;
using Version =  JobOverview.Model.Version;

namespace JobOverview.Data
{
   public class JobOverviewContext : DbContext
   {
      public JobOverviewContext(DbContextOptions<JobOverviewContext> options): base(options) { }

      public DbSet<Logiciel> Logiciels { get; set; }
      public DbSet<Module> Modules { get; set; }
      public DbSet<Filiere> Filieres { get; set; }

      public DbSet<Release> Releases { get; set; }

      public DbSet<Version> Versions { get; set; }


      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         modelBuilder.Entity<Module>(entity =>
         {
            entity.HasKey(entity => entity.CodeModule).HasName("PrimaryKey_CodeModule");
            entity.Property(entity => entity.CodeModule).HasMaxLength(20).IsUnicode(false);
            entity.Property(entity => entity.Nom).HasMaxLength(60);
            
         });

         modelBuilder.Entity<Logiciel>(entity =>
         {
            entity.HasKey(entity => entity.CodeLogiciel).HasName("PrimaryKey_CodeLogiciel");
            entity.Property(entity => entity.CodeLogiciel).HasMaxLength(20).IsUnicode(false);
            entity.Property(entity => entity.Nom).HasMaxLength(60);

         });

         modelBuilder.Entity<Filiere>(entity =>
         {
            entity.HasKey(entity => entity.CodeFilière).HasName("PrimaryKey_CodeFiliere");
            entity.Property(entity => entity.CodeFilière).HasMaxLength(20);
            entity.Property(entity => entity.Nom).HasMaxLength(60);

         });

         modelBuilder.Entity<Release>(entity =>
         {
            entity.HasKey(entity => entity.NumeroRelease).HasName("PrimaryKey_NumeroRelease");
            entity.Property(entity => entity.NumeroRelease).HasColumnType("smallint");
            entity.Property(entity => entity.NumeroVersion).HasColumnType("real");
            entity.Property(entity => entity.DatePublication).HasColumnType("DateTime");

         });

         modelBuilder.Entity<Version>(entity =>
         {
            entity.HasKey(entity => entity.NumeroVersion).HasName("primaryKey_NumeroVersion");
            entity.Property(entity => entity.NumeroVersion).HasColumnType("real");
            entity.Property(entity => entity.Millesime).HasColumnType("smallint");
            entity.Property(entity => entity.DateOuverture).HasColumnType("datetime");
            entity.Property(entity => entity.DateSortiePrevue).HasColumnType("datetime");
            entity.Property(entity => entity.DateSortieReelle).HasColumnType("datetime");
         });
      }

   }
}
