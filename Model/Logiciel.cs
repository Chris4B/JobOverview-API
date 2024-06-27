
namespace JobOverview.Model
{
   public class Logiciel
   {
      public int CodeLogiciel { get; set; }
      public string Nom {  get; set; } = string.Empty;
   }

   public class Module
   {
      public int CodeModule { get; set; }
      public string Nom { get; set; } = string.Empty ;
   }

   public class Filière
   {
      public int CodeFilière { get; set; }
      public string Nom { get; set; } = string.Empty;
   }

   public class Release
   {
      public int NumeroRelease { get; set; }
      public DateTime DatePublication { get; set; }
      public int NumeroVersion { get; set; }
   }

   public class Version
   {
      public int NumeroVersion { get; set; }
      public int Millesime { get; set; }
      public DateTime DateOuverture { get; set; }
      public DateTime DateSortiePrevue { get; set; }
      public DateTime DateSortieReelle { get; set; }
   }
}
