// <auto-generated />
using System;
using CodingIoDevs.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CodingIoDevs.Persistence.Migrations
{
    [DbContext(typeof(BaseDbContext))]
    [Migration("20220909061044_mig_2")]
    partial class mig_2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CodingIoDevs.Domain.Entities.Framework", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Name");

                    b.Property<Guid>("ProgrammingLanguageId")
                        .HasColumnType("uuid")
                        .HasColumnName("ProgrammingLanguageId");

                    b.HasKey("Id");

                    b.HasIndex("ProgrammingLanguageId");

                    b.ToTable("Frameworks", (string)null);
                });

            modelBuilder.Entity("CodingIoDevs.Domain.Entities.ProgrammingLanguage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("Id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Name");

                    b.HasKey("Id");

                    b.ToTable("ProgrammingLanguages", (string)null);
                });

            modelBuilder.Entity("CodingIoDevs.Domain.Entities.Framework", b =>
                {
                    b.HasOne("CodingIoDevs.Domain.Entities.ProgrammingLanguage", "ProgrammingLanguage")
                        .WithMany("Frameworks")
                        .HasForeignKey("ProgrammingLanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProgrammingLanguage");
                });

            modelBuilder.Entity("CodingIoDevs.Domain.Entities.ProgrammingLanguage", b =>
                {
                    b.Navigation("Frameworks");
                });
#pragma warning restore 612, 618
        }
    }
}
