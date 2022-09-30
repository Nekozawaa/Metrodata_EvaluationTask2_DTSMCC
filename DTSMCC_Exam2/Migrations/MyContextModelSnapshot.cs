﻿// <auto-generated />
using DTSMCC_Exam2.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DTSMCC_Exam2.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.29")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DTSMCC_Exam2.Models.Account", b =>
                {
                    b.Property<int>("idKaryawan")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("alamat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idJK")
                        .HasColumnType("int");

                    b.Property<string>("namaLengkap")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("noTelp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("roleId")
                        .HasColumnType("int");

                    b.HasKey("idKaryawan");

                    b.HasIndex("idJK");

                    b.HasIndex("roleId");

                    b.ToTable("accounts");
                });

            modelBuilder.Entity("DTSMCC_Exam2.Models.JenisKelamin", b =>
                {
                    b.Property<int>("idJK")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("jenisKelamin")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idJK");

                    b.ToTable("jenisKelamins");
                });

            modelBuilder.Entity("DTSMCC_Exam2.Models.Pengajuan", b =>
                {
                    b.Property<int>("idPengajuan")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("alamatPerusahaan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idKaryawan")
                        .HasColumnType("int");

                    b.Property<int>("idStatusBekerja")
                        .HasColumnType("int");

                    b.Property<string>("namaPerusahaan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("statusPengajuan")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idPengajuan");

                    b.HasIndex("idKaryawan");

                    b.HasIndex("idStatusBekerja");

                    b.ToTable("pengajuans");
                });

            modelBuilder.Entity("DTSMCC_Exam2.Models.Role", b =>
                {
                    b.Property<int>("idRole")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("namaRole")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idRole");

                    b.ToTable("roles");
                });

            modelBuilder.Entity("DTSMCC_Exam2.Models.StatusBekerja", b =>
                {
                    b.Property<int>("idSB")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("idSB");

                    b.ToTable("statusBekerjas");
                });

            modelBuilder.Entity("DTSMCC_Exam2.Models.Account", b =>
                {
                    b.HasOne("DTSMCC_Exam2.Models.JenisKelamin", "JenisKelamin")
                        .WithMany()
                        .HasForeignKey("idJK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DTSMCC_Exam2.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("roleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DTSMCC_Exam2.Models.Pengajuan", b =>
                {
                    b.HasOne("DTSMCC_Exam2.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("idKaryawan")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DTSMCC_Exam2.Models.StatusBekerja", "StatusBekerja")
                        .WithMany()
                        .HasForeignKey("idStatusBekerja")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
