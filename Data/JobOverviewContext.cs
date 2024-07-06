using JobOverview.Model;
using Microsoft.EntityFrameworkCore;
using Version =  JobOverview.Model.Version;

namespace JobOverview.Data
{
   public class JobOverviewContext : DbContext
   {
      public JobOverviewContext(DbContextOptions<JobOverviewContext> options): base(options) { }

      public DbSet<Logiciel> Logiciel { get; set; }
      public DbSet<Module> Module { get; set; }
      public DbSet<Filiere> Filiere { get; set; }

      public DbSet<Release> Release { get; set; }

      public DbSet<Version> Version { get; set; }


      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         modelBuilder.Entity<Module>(entity =>
         {
            entity.ToTable("Modules");
            //entity.HasKey(entity => new { entity.CodeLogiciel, entity.CodeModule });
            entity.HasKey(entity => entity.CodeModule).HasName("PrimaryKey_CodeModule");
            entity.Property(entity => entity.CodeModule).HasMaxLength(20).IsUnicode(false);
            entity.Property(entity => entity.Nom).HasMaxLength(60);
            entity.Property(entity => entity.CodeLogicielParent).HasMaxLength(20).IsUnicode(false);
            entity.Property(entity => entity.CodeModuleParent).HasMaxLength(20).IsUnicode(false);
            entity.Property(entity => entity.CodeLogiciel).HasMaxLength(20).IsUnicode(false); 

            //entity.HasOne<Logiciel>().WithMany().HasForeignKey(d => d.CodeModule).OnDelete(DeleteBehavior.NoAction);
            
         });

         modelBuilder.Entity<Logiciel>(entity =>
         {
            entity.ToTable("Logiciels");
            entity.HasKey(entity => entity.CodeLogiciel).HasName("PrimaryKey_CodeLogiciel");
            entity.Property(entity => entity.CodeLogiciel).HasMaxLength(20).IsUnicode(false);
            entity.Property(entity => entity.Nom).HasMaxLength(60);
            entity.Property(entity => entity.CodeFilière).HasMaxLength(20).IsUnicode(false); 

            entity.HasOne<Filiere>().WithMany().HasForeignKey(d => d.CodeFilière).OnDelete(DeleteBehavior.NoAction);

         });

         modelBuilder.Entity<Filiere>(entity =>
         {
            entity.ToTable("Filières");
            entity.HasKey(entity => entity.CodeFilière).HasName("PrimaryKey_CodeFiliere");
            entity.Property(entity => entity.CodeFilière).HasMaxLength(20);
            entity.Property(entity => entity.Nom).HasMaxLength(60);
            

         });

         modelBuilder.Entity<Release>(entity =>
         {
            entity.ToTable("Releases");

            //entity.HasKey(entity => new { entity.CodeLogiciel, entity.NumeroRelease, entity.NumeroVersion });
            entity.HasKey(entity => entity.NumeroRelease).HasName("PrimaryKey_NumeroRelease");

            entity.Property(entity => entity.NumeroRelease).HasColumnType("smallint");
            entity.Property(entity => entity.NumeroVersion).HasColumnType("real");
            entity.Property(entity => entity.DatePublication).HasColumnType("DateTime");
            entity.Property(entity => entity.CodeLogiciel).HasMaxLength(20);

         });

         modelBuilder.Entity<Version>(entity =>
         {
            entity.ToTable("Versions");

            //entity.HasKey(entity => new { entity.CodeLogiciel, entity.NumeroVersion });
            entity.HasKey(entity => entity.NumeroVersion).HasName("PrimaryKey_NumeroVersion");

            entity.Property(entity => entity.NumeroVersion).HasColumnType("real");
            entity.Property(entity => entity.Millesime).HasColumnType("smallint");
            entity.Property(entity => entity.DateOuverture).HasColumnType("datetime");
            entity.Property(entity => entity.DateSortiePrevue).HasColumnType("datetime");
            entity.Property(entity => entity.DateSortieReelle).HasColumnType("datetime");
         });
      }

   }
}
