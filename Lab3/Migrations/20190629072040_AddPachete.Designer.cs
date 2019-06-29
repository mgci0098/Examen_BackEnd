﻿// <auto-generated />
using System;
using CentruMultimedia.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Lab3.Migrations
{
    [DbContext(typeof(FilmeDbContext))]
    [Migration("20190629072040_AddPachete")]
    partial class AddPachete
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CentruMultimedia.Models.Comentariu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddedById");

                    b.Property<int?>("FilmId");

                    b.Property<bool>("Important");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.HasIndex("AddedById");

                    b.HasIndex("FilmId");

                    b.ToTable("Comentarii");
                });

            modelBuilder.Entity("CentruMultimedia.Models.Film", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateAdded");

                    b.Property<string>("Description");

                    b.Property<string>("Director");

                    b.Property<int>("Duration");

                    b.Property<int>("Genre");

                    b.Property<int?>("OwnerId");

                    b.Property<int>("Rating");

                    b.Property<int>("ReleaseYear");

                    b.Property<string>("Title");

                    b.Property<int>("Watched");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Filme");
                });

            modelBuilder.Entity("Lab3.Models.Pachet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AdresaDestinatar");

                    b.Property<string>("CodTracking");

                    b.Property<double>("Cost");

                    b.Property<string>("DenumireDestinatar");

                    b.Property<string>("DenumireExpeditor");

                    b.Property<string>("TaraDestinatie");

                    b.Property<string>("TaraOrigine");

                    b.HasKey("Id");

                    b.ToTable("Pachete");
                });

            modelBuilder.Entity("Lab3.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataRegistered");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique()
                        .HasFilter("[Username] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Lab3.Models.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Lab3.Models.UserUserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("EndTime");

                    b.Property<DateTime>("StartTime");

                    b.Property<int>("UserId");

                    b.Property<int>("UserRoleId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("UserRoleId");

                    b.ToTable("UserUserRoles");
                });

            modelBuilder.Entity("CentruMultimedia.Models.Comentariu", b =>
                {
                    b.HasOne("Lab3.Models.User", "AddedBy")
                        .WithMany("Comentarii")
                        .HasForeignKey("AddedById")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CentruMultimedia.Models.Film", "Film")
                        .WithMany("Comentarii")
                        .HasForeignKey("FilmId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CentruMultimedia.Models.Film", b =>
                {
                    b.HasOne("Lab3.Models.User", "Owner")
                        .WithMany("Filme")
                        .HasForeignKey("OwnerId");
                });

            modelBuilder.Entity("Lab3.Models.UserUserRole", b =>
                {
                    b.HasOne("Lab3.Models.User", "User")
                        .WithMany("UserUserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Lab3.Models.UserRole", "UserRole")
                        .WithMany("UserUserRoles")
                        .HasForeignKey("UserRoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
