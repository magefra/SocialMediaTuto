﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SocialMedia.Infrastructure.src.Data;

namespace SocialMedia.Infrastructure.Migrations
{
    [DbContext(typeof(SocialMediaContext))]
    partial class SocialMediaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SocialMedia.Core.src.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("IdComentario")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnName("Fecha")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("Descripcion")
                        .HasColumnType("varchar(500)")
                        .HasMaxLength(500)
                        .IsUnicode(false);

                    b.Property<bool>("IsActive")
                        .HasColumnName("Activo")
                        .HasColumnType("bit");

                    b.Property<int>("PostId")
                        .HasColumnName("IdPublicacion")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnName("IdUsuario")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PostId");

                    b.HasIndex("UserId");

                    b.ToTable("Comentario");
                });

            modelBuilder.Entity("SocialMedia.Core.src.Entities.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IdPublicacion")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnName("Fecha")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnName("Descripcion")
                        .HasColumnType("varchar(1000)")
                        .HasMaxLength(1000)
                        .IsUnicode(false);

                    b.Property<string>("Image")
                        .HasColumnName("Imagen")
                        .HasColumnType("varchar(500)")
                        .HasMaxLength(500)
                        .IsUnicode(false);

                    b.Property<int>("UserId")
                        .HasColumnName("IdUsuario")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Publicacion");
                });

            modelBuilder.Entity("SocialMedia.Core.src.Entities.Security", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IdSeguridad")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("Contrasena")
                        .HasColumnType("varchar(200)")
                        .HasMaxLength(200)
                        .IsUnicode(false);

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnName("Rol")
                        .HasColumnType("nvarchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("User")
                        .IsRequired()
                        .HasColumnName("Usuario")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnName("NombreUsuario")
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("Seguridad");
                });

            modelBuilder.Entity("SocialMedia.Core.src.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IdUsuario")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnName("FechaNacimiento")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(30)")
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("Nombres")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<bool>("IsActive")
                        .HasColumnName("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnName("Apellidos")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Telephone")
                        .HasColumnName("Telefono")
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("SocialMedia.Core.src.Entities.Comment", b =>
                {
                    b.HasOne("SocialMedia.Core.src.Entities.Post", "Post")
                        .WithMany("Comments")
                        .HasForeignKey("PostId")
                        .HasConstraintName("FK_Comentario_Publicacion")
                        .IsRequired();

                    b.HasOne("SocialMedia.Core.src.Entities.User", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Comentario_Usuario")
                        .IsRequired();
                });

            modelBuilder.Entity("SocialMedia.Core.src.Entities.Post", b =>
                {
                    b.HasOne("SocialMedia.Core.src.Entities.User", "User")
                        .WithMany("Posts")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Publicacion_Usuario")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
