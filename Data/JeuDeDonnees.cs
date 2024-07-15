using Microsoft.EntityFrameworkCore;
using JobOverview.Model;
using System;
using Version = JobOverview.Model.Version;

namespace JobOverview.Data
{
   public class JeuDeDonnees
   {

      public static void Creer(ModelBuilder modelBuilder)
      {
         
            modelBuilder.Entity<Filiere>().HasData(
              new Filiere
              {
                 CodeFiliere = "BIOV",
                 Nom = "Biologie Végétale"
              },

               new Filiere
               {
                  CodeFiliere = "BIOH",
                  Nom = "Bologie Humaine"
               },

               new Filiere
               {
                  CodeFiliere = "BIOA",
                  Nom = "biologie animale"
               }


             );

            modelBuilder.Entity<Logiciel>().HasData(
               new Logiciel
               {
                  CodeLogiciel = "GENOMICA",
                  CodeFiliere = "BIOH",
                  Nom = "Génomica"
               },

               new Logiciel
               {
                  CodeLogiciel = "ANATOMIA",
                  CodeFiliere = "BIOH",
                  Nom = "Anatomia"
               }

               );

            modelBuilder.Entity<Module>().HasData(
               new Module
               {
                  CodeModule = "SEQUENCAGE",
                  Nom = "Séquencage",
                  CodeLogiciel = "GENOMICA"

               },
               new Module
               {
                  CodeModule = "MARQUAGE",
                  CodeLogiciel= "GENOMICA",
                  Nom = "Marquage",
                  CodeLogicielParent = "GENOMICA",
                  CodeModuleParent = "SEQUENCAGE"
                  
                  

               },
               new Module
               {
                  CodeModule = "SEPARATION",
                  CodeLogiciel = "GENOMICA",
                  Nom = "Séparation",
                  CodeModuleParent = "SEQUENCAGE",
                  CodeLogicielParent = "GENOMICA",
                  

               },

               new Module
               {
                  CodeModule = "ANALYSE",
                  CodeLogiciel = "GENOMICA",
                  Nom = "Analyse",
                  CodeModuleParent = "SEQUENCAGE",
                  CodeLogicielParent = "GENOMICA"

               },
               new Module
               {
                  CodeModule = "POLYMORPGYSME",
                  Nom = "Polymorphisme génétique",
                  CodeLogiciel = "GENOMICA"

               },
               new Module
               {
                  CodeModule = "VAR_ALLELE",
                  Nom = "Varaitions alletiques",
                  CodeLogiciel = "GENOMICA"

               },
             
               new Module
               {
                  CodeModule = "UTILS_ROLES",
                  Nom = "utilisateurs et rôles",
                  CodeLogiciel = "GENOMICA"

               },
               new Module
               {
                  CodeModule = "PARAMETRES",
                  Nom = "Paramètres",
                  CodeLogiciel = "GENOMICA"

               },
               new Module
               {
                  CodeModule = "MICRO",
                  Nom = "Anatomie microscopique",
                  CodeLogiciel = "GENOMICA"

               },
               new Module
               {
                  CodeModule = "PATHO",
                  Nom = "Anatomie pathologique",
                  CodeLogiciel = "GENOMICA"

               },
              
               new Module
               {
                  CodeModule = "FONC",
                  Nom = "Anatomie fonctionnelle",
                  CodeLogiciel = "GENOMICA"

               },
               new Module
               {
                  CodeModule = "RADIO",
                  Nom = "Anatomie radiologique",
                  CodeLogiciel = "GENOMICA"

               },
               new Module
               {
                  CodeModule = "TOPO",
                  Nom = "Anatomie topographique",
                  CodeLogiciel = "GENOMICA"

               }


               );

            modelBuilder.Entity<Version>().HasData(
               new Version
               {
                  NumeroVersion = 1F,
                  Millesime = 2023,
                  DateOuverture = new DateTime(2022,02, 01),
                  DateSortiePrevue = new DateTime(2023,01,08),
                  DateSortieReelle = new DateTime(2023,01,20),
                  CodeLogiciel = "GENOMICA"

               },
               new Version
               {
                  NumeroVersion = 2F,
                  Millesime = 2024,
                  DateOuverture = new DateTime(2022,12,28),
                  DateSortiePrevue = new DateTime(2024,02,28),
                  DateSortieReelle = new DateTime(2023,01,20),
                  CodeLogiciel = "GENOMICA"

               },

               new Version
               {
                  NumeroVersion = 4.5F,
                  Millesime = 2022,
                  DateOuverture = new DateTime(2021,09,01),
                  DateSortiePrevue = new DateTime(2022,07,07),
                  DateSortieReelle = new DateTime(2022,07,20),
                  CodeLogiciel = "ANATOMIA"

               },


               new Version
               {
                  NumeroVersion = 5F,
                  Millesime = 2023,
                  DateOuverture = new DateTime(2022,08,01),
                  DateSortiePrevue = new DateTime(2023,03,30),
                  DateSortieReelle = new DateTime(2023,03,25),
                  CodeLogiciel = "ANATOMIA"

               },

               new Version
               {
                  NumeroVersion = 5.5F,
                  Millesime = 2024,
                  DateOuverture = new DateTime(2023,03,30),
                  DateSortiePrevue = new DateTime(2023,11,20),

                  CodeLogiciel = "ANATOMIA"

               }



               );

         
      }

   }
}
