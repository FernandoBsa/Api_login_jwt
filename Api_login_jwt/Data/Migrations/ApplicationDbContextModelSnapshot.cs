﻿// <auto-generated />
using System;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entity.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("UserRole")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Domain.Entity.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Nome")
                        .IsUnique();

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Domain.Entity.UsuarioRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdRole")
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdUsuario")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("IdRole");

                    b.HasIndex("IdUsuario", "IdRole")
                        .IsUnique();

                    b.ToTable("UsuarioRoles");
                });

            modelBuilder.Entity("Domain.Entity.UsuarioRole", b =>
                {
                    b.HasOne("Domain.Entity.Role", "Role")
                        .WithMany("UsuarioRoles")
                        .HasForeignKey("IdRole")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entity.Usuario", "Usuario")
                        .WithMany("UsuarioRoles")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Domain.Entity.Role", b =>
                {
                    b.Navigation("UsuarioRoles");
                });

            modelBuilder.Entity("Domain.Entity.Usuario", b =>
                {
                    b.Navigation("UsuarioRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
