﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using webApi.Dal;

#nullable disable

namespace WebShiffi.Migrations
{
    [DbContext(typeof(ChineseSaleContext))]
    [Migration("20231211160607_listNotICollection")]
    partial class listNotICollection
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("webApi.models.Donors", b =>
                {
                    b.Property<string>("DonorsId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DonorEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DonorFullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DonorPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeOfGift")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DonorsId");

                    b.ToTable("Donors");
                });

            modelBuilder.Entity("webApi.models.Gift", b =>
                {
                    b.Property<int>("GiftId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GiftId"), 1L, 1);

                    b.Property<string>("GiftCatagory")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GiftDiscription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GiftName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GiftTicketCost")
                        .HasColumnType("int");

                    b.Property<string>("GiftUrlImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GiftId");

                    b.ToTable("Gifts");
                });

            modelBuilder.Entity("webApi.models.OrderItems", b =>
                {
                    b.Property<int>("OrderItemsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderItemsId"), 1L, 1);

                    b.Property<int>("GiftId")
                        .HasColumnType("int");

                    b.Property<int>("OrdersId")
                        .HasColumnType("int");

                    b.Property<string>("usersId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("OrderItemsId");

                    b.HasIndex("GiftId");

                    b.HasIndex("OrdersId");

                    b.HasIndex("usersId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("webApi.models.Orders", b =>
                {
                    b.Property<int>("OrdersId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrdersId"), 1L, 1);

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderSum")
                        .HasColumnType("int");

                    b.HasKey("OrdersId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("webApi.models.Raffles", b =>
                {
                    b.Property<int>("RafflesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RafflesId"), 1L, 1);

                    b.Property<DateTime>("RafflesDate")
                        .HasColumnType("datetime2");

                    b.HasKey("RafflesId");

                    b.ToTable("Raffles");
                });

            modelBuilder.Entity("webApi.models.Users", b =>
                {
                    b.Property<string>("UsersId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("Role")
                        .HasColumnType("bit");

                    b.Property<string>("UserEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UsersId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("webApi.models.Winners", b =>
                {
                    b.Property<int>("WinnersId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WinnersId"), 1L, 1);

                    b.Property<int>("GiftId")
                        .HasColumnType("int");

                    b.Property<int>("RafflesId")
                        .HasColumnType("int");

                    b.Property<string>("UsersId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("WinnersId");

                    b.HasIndex("GiftId");

                    b.HasIndex("RafflesId");

                    b.HasIndex("UsersId");

                    b.ToTable("Winners");
                });

            modelBuilder.Entity("WebShiffi.models.Donation", b =>
                {
                    b.Property<int>("DonationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DonationId"), 1L, 1);

                    b.Property<string>("DonorsId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("GiftId")
                        .HasColumnType("int");

                    b.HasKey("DonationId");

                    b.HasIndex("DonorsId");

                    b.HasIndex("GiftId");

                    b.ToTable("Donation");
                });

            modelBuilder.Entity("webApi.models.OrderItems", b =>
                {
                    b.HasOne("webApi.models.Gift", "Gift")
                        .WithMany()
                        .HasForeignKey("GiftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webApi.models.Orders", "Orders")
                        .WithMany("listOrderItems")
                        .HasForeignKey("OrdersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webApi.models.Users", "users")
                        .WithMany()
                        .HasForeignKey("usersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gift");

                    b.Navigation("Orders");

                    b.Navigation("users");
                });

            modelBuilder.Entity("webApi.models.Winners", b =>
                {
                    b.HasOne("webApi.models.Gift", "Gift")
                        .WithMany()
                        .HasForeignKey("GiftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webApi.models.Raffles", "Raffles")
                        .WithMany()
                        .HasForeignKey("RafflesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webApi.models.Users", "Users")
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gift");

                    b.Navigation("Raffles");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("WebShiffi.models.Donation", b =>
                {
                    b.HasOne("webApi.models.Donors", "Donors")
                        .WithMany()
                        .HasForeignKey("DonorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("webApi.models.Gift", "Gift")
                        .WithMany()
                        .HasForeignKey("GiftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Donors");

                    b.Navigation("Gift");
                });

            modelBuilder.Entity("webApi.models.Orders", b =>
                {
                    b.Navigation("listOrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}
