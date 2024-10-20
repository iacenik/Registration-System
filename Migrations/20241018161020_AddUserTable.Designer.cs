﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PersonelKayıtSistemi.Data;

#nullable disable

namespace PersonelKayıtSistemi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20241018161020_AddUserTable")]
    partial class AddUserTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.8");

            modelBuilder.Entity("PersonelKayıtSistemi.Data.Personel", b =>
                {
                    b.Property<int>("PersonelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Ad")
                        .HasColumnType("TEXT");

                    b.Property<string>("Adres")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Maas")
                        .HasColumnType("TEXT");

                    b.Property<string>("Resim")
                        .HasColumnType("TEXT");

                    b.Property<string>("Soyad")
                        .HasColumnType("TEXT");

                    b.HasKey("PersonelId");

                    b.ToTable("Personeller");
                });

            modelBuilder.Entity("PersonelKayıtSistemi.Data.PersonelKayıt", b =>
                {
                    b.Property<int>("KayitId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("KayitTarihi")
                        .HasColumnType("TEXT");

                    b.Property<int>("PersonelId")
                        .HasColumnType("INTEGER");

                    b.HasKey("KayitId");

                    b.HasIndex("PersonelId");

                    b.ToTable("PersonelKayıtları");
                });

            modelBuilder.Entity("PersonelKayıtSistemi.Data.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PersonelKayıtSistemi.Data.PersonelKayıt", b =>
                {
                    b.HasOne("PersonelKayıtSistemi.Data.Personel", "Personel")
                        .WithMany("PersonelKayıtları")
                        .HasForeignKey("PersonelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Personel");
                });

            modelBuilder.Entity("PersonelKayıtSistemi.Data.Personel", b =>
                {
                    b.Navigation("PersonelKayıtları");
                });
#pragma warning restore 612, 618
        }
    }
}
