﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RestaurantManagementApp.DbService.AppDbContextModels;

#nullable disable

namespace RestaurantManagementApp.DbService.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250606051911_update-db")]
    partial class updatedb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("RestaurantManagementApp.DbService.Tables.TblAdmin", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("TblAdmins");
                });

            modelBuilder.Entity("RestaurantManagementApp.DbService.Tables.TblBookingSlot", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateOnly>("BookingDate")
                        .HasColumnType("date");

                    b.Property<TimeOnly>("EndTime")
                        .HasColumnType("time(6)");

                    b.Property<string>("IsAvailable")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SlotNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<TimeOnly>("StartTime")
                        .HasColumnType("time(6)");

                    b.HasKey("Id");

                    b.ToTable("TblBookingSlots");
                });

            modelBuilder.Entity("RestaurantManagementApp.DbService.Tables.TblCart", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("char(36)");

                    b.Property<int>("Total")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("TblCarts");
                });

            modelBuilder.Entity("RestaurantManagementApp.DbService.Tables.TblCartItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CartId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("MenuItemId")
                        .HasColumnType("char(36)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("MenuItemId");

                    b.ToTable("TblCartItems");
                });

            modelBuilder.Entity("RestaurantManagementApp.DbService.Tables.TblCategory", b =>
                {
                    b.Property<Guid>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("CategoryId");

                    b.ToTable("TblCategories");
                });

            modelBuilder.Entity("RestaurantManagementApp.DbService.Tables.TblCustomer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("TblCustomers");
                });

            modelBuilder.Entity("RestaurantManagementApp.DbService.Tables.TblCustomizeOption", b =>
                {
                    b.Property<Guid>("CustomizeOptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("CustomizeOptionId");

                    b.ToTable("TblCustomizeOptions");
                });

            modelBuilder.Entity("RestaurantManagementApp.DbService.Tables.TblMenuItem", b =>
                {
                    b.Property<Guid>("MenuItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("longtext");

                    b.Property<string>("MenuItemName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)");

                    b.HasKey("MenuItemId");

                    b.HasIndex("CategoryId");

                    b.ToTable("TblMenuItems");
                });

            modelBuilder.Entity("RestaurantManagementApp.DbService.Tables.TblMenuItemCustomizeOption", b =>
                {
                    b.Property<Guid>("MenuItemCustomizeOptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CustomizeOptionId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("MenuItemId")
                        .HasColumnType("char(36)");

                    b.HasKey("MenuItemCustomizeOptionId");

                    b.HasIndex("CustomizeOptionId");

                    b.HasIndex("MenuItemId");

                    b.ToTable("TblMenuItemCustomizeOptions");
                });

            modelBuilder.Entity("RestaurantManagementApp.DbService.Tables.TblReservation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("BookingSlotId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("char(36)");

                    b.Property<bool>("IsConfirm")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("NumberOfPeople")
                        .HasColumnType("int");

                    b.Property<string>("SpecialRequest")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<Guid>("TableId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("BookingSlotId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("TableId");

                    b.ToTable("TblReservations");
                });

            modelBuilder.Entity("RestaurantManagementApp.DbService.Tables.TblTable", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("IsAvailable")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("TableNumber")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("TblTables");
                });

            modelBuilder.Entity("RestaurantManagementApp.DbService.Tables.TblUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("TblUsers");
                });

            modelBuilder.Entity("RestaurantManagementApp.DbService.Tables.TblAdmin", b =>
                {
                    b.HasOne("RestaurantManagementApp.DbService.Tables.TblUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("RestaurantManagementApp.DbService.Tables.TblCart", b =>
                {
                    b.HasOne("RestaurantManagementApp.DbService.Tables.TblCustomer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("RestaurantManagementApp.DbService.Tables.TblCartItem", b =>
                {
                    b.HasOne("RestaurantManagementApp.DbService.Tables.TblCart", "Cart")
                        .WithMany("CartItems")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestaurantManagementApp.DbService.Tables.TblMenuItem", "MenuItem")
                        .WithMany()
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("MenuItem");
                });

            modelBuilder.Entity("RestaurantManagementApp.DbService.Tables.TblCustomer", b =>
                {
                    b.HasOne("RestaurantManagementApp.DbService.Tables.TblUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("RestaurantManagementApp.DbService.Tables.TblMenuItem", b =>
                {
                    b.HasOne("RestaurantManagementApp.DbService.Tables.TblCategory", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("RestaurantManagementApp.DbService.Tables.TblMenuItemCustomizeOption", b =>
                {
                    b.HasOne("RestaurantManagementApp.DbService.Tables.TblCustomizeOption", "CustomizeOption")
                        .WithMany("MenuItemCustomizeOptions")
                        .HasForeignKey("CustomizeOptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestaurantManagementApp.DbService.Tables.TblMenuItem", "MenuItem")
                        .WithMany("MenuItemCustomizeOptions")
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CustomizeOption");

                    b.Navigation("MenuItem");
                });

            modelBuilder.Entity("RestaurantManagementApp.DbService.Tables.TblReservation", b =>
                {
                    b.HasOne("RestaurantManagementApp.DbService.Tables.TblBookingSlot", "BookingSlot")
                        .WithMany()
                        .HasForeignKey("BookingSlotId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestaurantManagementApp.DbService.Tables.TblCustomer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RestaurantManagementApp.DbService.Tables.TblTable", "Table")
                        .WithMany()
                        .HasForeignKey("TableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookingSlot");

                    b.Navigation("Customer");

                    b.Navigation("Table");
                });

            modelBuilder.Entity("RestaurantManagementApp.DbService.Tables.TblCart", b =>
                {
                    b.Navigation("CartItems");
                });

            modelBuilder.Entity("RestaurantManagementApp.DbService.Tables.TblCustomizeOption", b =>
                {
                    b.Navigation("MenuItemCustomizeOptions");
                });

            modelBuilder.Entity("RestaurantManagementApp.DbService.Tables.TblMenuItem", b =>
                {
                    b.Navigation("MenuItemCustomizeOptions");
                });
#pragma warning restore 612, 618
        }
    }
}
