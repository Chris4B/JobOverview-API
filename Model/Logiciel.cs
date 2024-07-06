
namespace JobOverview.Model
{
   /// <summary>
   /// classe représentant un logicile 
   /// </summary>
   public class Logiciel
   {
      public string CodeLogiciel { get; set; } = "";
      public string Nom {  get; set; } = "";

      // ajout de la propriété qui servira de clé étrangère
      public string CodeFilière { get; set; } = "";

      
   }

   public class Module
   {
      public string CodeModule { get; set; } = string.Empty;
      public string Nom { get; set; } = string.Empty ;

      public string? CodeModuleParent { get; set; }
      public string? CodeLogiciel { get; set; }

      public string? CodeLogicielParent { get; set; }
   }

   public class Filiere
   {
      public string CodeFilière { get; set; } = "";
      public string Nom { get; set; } = string.Empty;
   }

   public class Release
   {
      public short NumeroRelease { get; set; }
      public DateTime DatePublication { get; set; }
      
      public float NumeroVersion { get; set; }
      public string CodeLogiciel { get; set; } = "";
   }

   public class Version
   {
      public float NumeroVersion { get; set; }
      public short Millesime { get; set; }
      public DateTime DateOuverture { get; set; }
      public DateTime DateSortiePrevue { get; set; }
      public DateTime? DateSortieReelle { get; set; }

      public string CodeLogiciel { get; set; } = "";
   }
}
