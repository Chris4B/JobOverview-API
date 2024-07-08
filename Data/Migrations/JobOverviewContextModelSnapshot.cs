﻿// <auto-generated />
using System;
using JobOverview.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JobOverview.Data.Migrations
{
    [DbContext(typeof(JobOverviewContext))]
    partial class JobOverviewContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("JobOverview.Model.Filiere", b =>
                {
                    b.Property<string>("CodeFiliere")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("CodeFiliere")
                        .HasName("PrimaryKey_CodeFiliere");

                    b.ToTable("Filières", (string)null);
                });

            modelBuilder.Entity("JobOverview.Model.Logiciel", b =>
                {
                    b.Property<string>("CodeLogiciel")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("CodeFiliere")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("CodeLogiciel")
                        .HasName("PrimaryKey_CodeLogiciel");

                    b.HasIndex("CodeFiliere");

                    b.ToTable("Logiciels", (string)null);
                });

            modelBuilder.Entity("JobOverview.Model.Module", b =>
                {
                    b.Property<string>("CodeModule")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("CodeLogiciel")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("CodeLogicielParent")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("CodeModuleParent")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("CodeModule")
                        .HasName("PrimaryKey_CodeModule");

                    b.HasIndex("CodeLogiciel");

                    b.HasIndex("CodeModuleParent", "CodeLogicielParent");

                    b.ToTable("Modules", (string)null);
                });

            modelBuilder.Entity("JobOverview.Model.Release", b =>
                {
                    b.Property<short>("NumeroRelease")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("NumeroRelease"));

                    b.Property<string>("CodeLogiciel")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("DatePublication")
                        .HasColumnType("DateTime");

                    b.Property<float>("NumeroVersion")
                        .HasColumnType("real");

                    b.HasKey("NumeroRelease")
                        .HasName("PrimaryKey_NumeroRelease");

                    b.ToTable("Releases", (string)null);
                });

            modelBuilder.Entity("JobOverview.Model.Version", b =>
                {
                    b.Property<float>("NumeroVersion")
                        .HasColumnType("real");

                    b.Property<string>("CodeLogiciel")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime>("DateOuverture")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateSortiePrevue")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateSortieReelle")
                        .HasColumnType("datetime2");

                    b.Property<short>("Millesime")
                        .HasColumnType("smallint");

                    b.HasKey("NumeroVersion")
                        .HasName("PrimaryKey_NumeroVersion");

                    b.HasIndex("CodeLogiciel");

                    b.ToTable("Versions", (string)null);
                });

            modelBuilder.Entity("JobOverview.Model.Logiciel", b =>
                {
                    b.HasOne("JobOverview.Model.Filiere", null)
                        .WithMany()
                        .HasForeignKey("CodeFiliere")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("JobOverview.Model.Module", b =>
                {
                    b.HasOne("JobOverview.Model.Logiciel", null)
                        .WithMany()
                        .HasForeignKey("CodeLogiciel")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("JobOverview.Model.Module", null)
                        .WithMany()
                        .HasForeignKey("CodeModuleParent", "CodeLogicielParent")
                        .HasPrincipalKey("CodeModule", "CodeLogiciel")
                        .OnDelete(DeleteBehavior.NoAction);
                });

            modelBuilder.Entity("JobOverview.Model.Version", b =>
                {
                    b.HasOne("JobOverview.Model.Logiciel", null)
                        .WithMany()
                        .HasForeignKey("CodeLogiciel")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
