﻿// <auto-generated />
using API_6._0_4.DBcontext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Repositories_4.Migrations
{
    [DbContext(typeof(EF_DBcontext))]
    [Migration("20231017064225_111")]
    partial class _111
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("API_6._0_4.DBcontext.District", b =>
                {
                    b.Property<int>("districtID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("districtID"));

                    b.Property<string>("districtDescripton")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("districtName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("provinceID")
                        .HasColumnType("integer");

                    b.HasKey("districtID");

                    b.HasIndex("provinceID");

                    b.ToTable("District");
                });

            modelBuilder.Entity("API_6._0_4.DBcontext.Province", b =>
                {
                    b.Property<int>("provinceID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("provinceID"));

                    b.Property<string>("provinceDescription")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("provinceName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("provinceID");

                    b.ToTable("Province");
                });

            modelBuilder.Entity("API_6._0_4.DBcontext.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserId"));

                    b.Property<string>("Account")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("API_6._0_4.DBcontext.Ward", b =>
                {
                    b.Property<int>("wardID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("wardID"));

                    b.Property<int>("districtID")
                        .HasColumnType("integer");

                    b.Property<string>("wardDescription")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("wardName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("wardID");

                    b.HasIndex("districtID");

                    b.ToTable("Ward");
                });

            modelBuilder.Entity("API_6._0_4.DBcontext.District", b =>
                {
                    b.HasOne("API_6._0_4.DBcontext.Province", "province")
                        .WithMany()
                        .HasForeignKey("provinceID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("province");
                });

            modelBuilder.Entity("API_6._0_4.DBcontext.Ward", b =>
                {
                    b.HasOne("API_6._0_4.DBcontext.District", "district")
                        .WithMany()
                        .HasForeignKey("districtID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("district");
                });
#pragma warning restore 612, 618
        }
    }
}
