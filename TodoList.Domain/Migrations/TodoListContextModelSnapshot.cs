﻿// <auto-generated />
using System;
using TodoList;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace TodoList.Domain.Migrations
{
    [DbContext(typeof(TodoListContext))]
    partial class TodoListContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Core.Entities.Category", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Core.Entities.City", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("CountryID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CountryID");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Core.Entities.Client", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("CityID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CityID");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Core.Entities.Country", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Core.Entities.FlyCompany", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("FlyCompanies");
                });

            modelBuilder.Entity("Core.Entities.FoodSystem", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("FoodSystems");
                });

            modelBuilder.Entity("Core.Entities.Hotel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Rating")
                        .HasColumnType("float");

                    b.HasKey("ID");

                    b.ToTable("Hotels");
                });

            modelBuilder.Entity("Core.Entities.Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("ClientID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("TourID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ClientID");

                    b.HasIndex("TourID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Core.Entities.OrderRoom", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.Property<int>("RoomID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("OrderID");

                    b.HasIndex("RoomID");

                    b.ToTable("OrderRooms");
                });

            modelBuilder.Entity("Core.Entities.PhotosHotel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HotelID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("HotelID");

                    b.ToTable("PhotosHotels");
                });

            modelBuilder.Entity("Core.Entities.PhotosRoom", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoomID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("RoomID");

                    b.ToTable("PhotosRooms");
                });

            modelBuilder.Entity("Core.Entities.Room", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("CountOfPeople")
                        .HasColumnType("int");

                    b.Property<int>("CountOfRooms")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HotelID")
                        .HasColumnType("int");

                    b.Property<int>("TypeOfRoomID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("HotelID");

                    b.HasIndex("TypeOfRoomID");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("Core.Entities.Tour", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<int>("CityID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("FlyCompanyID")
                        .HasColumnType("int");

                    b.Property<int>("FoodSystemID")
                        .HasColumnType("int");

                    b.Property<int>("HotelID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("CityID");

                    b.HasIndex("FlyCompanyID");

                    b.HasIndex("FoodSystemID");

                    b.HasIndex("HotelID");

                    b.ToTable("Tours");
                });

            modelBuilder.Entity("Core.Entities.TypeOfRoom", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("TypeOfRooms");
                });

            modelBuilder.Entity("Core.Entities.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Core.Entities.City", b =>
                {
                    b.HasOne("Core.Entities.Country", "Country")
                        .WithMany("City")
                        .HasForeignKey("CountryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Core.Entities.Client", b =>
                {
                    b.HasOne("Core.Entities.City", "City")
                        .WithMany("Clients")
                        .HasForeignKey("CityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("Core.Entities.Order", b =>
                {
                    b.HasOne("Core.Entities.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Core.Entities.Tour", "Tour")
                        .WithMany()
                        .HasForeignKey("TourID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Tour");
                });

            modelBuilder.Entity("Core.Entities.OrderRoom", b =>
                {
                    b.HasOne("Core.Entities.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Room", "Room")
                        .WithMany()
                        .HasForeignKey("RoomID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Core.Entities.PhotosHotel", b =>
                {
                    b.HasOne("Core.Entities.Hotel", "Hotel")
                        .WithMany("PhotosHotels")
                        .HasForeignKey("HotelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("Core.Entities.PhotosRoom", b =>
                {
                    b.HasOne("Core.Entities.Room", "Room")
                        .WithMany("PhotosRooms")
                        .HasForeignKey("RoomID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Core.Entities.Room", b =>
                {
                    b.HasOne("Core.Entities.Hotel", "Hotel")
                        .WithMany("Rooms")
                        .HasForeignKey("HotelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.TypeOfRoom", "TypeOfRoom")
                        .WithMany("Room")
                        .HasForeignKey("TypeOfRoomID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");

                    b.Navigation("TypeOfRoom");
                });

            modelBuilder.Entity("Core.Entities.Tour", b =>
                {
                    b.HasOne("Core.Entities.Category", "Category")
                        .WithMany("Tour")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.City", "City")
                        .WithMany("Tours")
                        .HasForeignKey("CityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.FlyCompany", "FlyCompany")
                        .WithMany("Tour")
                        .HasForeignKey("FlyCompanyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.FoodSystem", "FoodSystem")
                        .WithMany("Tour")
                        .HasForeignKey("FoodSystemID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Hotel", "Hotel")
                        .WithMany()
                        .HasForeignKey("HotelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("City");

                    b.Navigation("FlyCompany");

                    b.Navigation("FoodSystem");

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("Core.Entities.Category", b =>
                {
                    b.Navigation("Tour");
                });

            modelBuilder.Entity("Core.Entities.City", b =>
                {
                    b.Navigation("Clients");

                    b.Navigation("Tours");
                });

            modelBuilder.Entity("Core.Entities.Country", b =>
                {
                    b.Navigation("City");
                });

            modelBuilder.Entity("Core.Entities.FlyCompany", b =>
                {
                    b.Navigation("Tour");
                });

            modelBuilder.Entity("Core.Entities.FoodSystem", b =>
                {
                    b.Navigation("Tour");
                });

            modelBuilder.Entity("Core.Entities.Hotel", b =>
                {
                    b.Navigation("PhotosHotels");

                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("Core.Entities.Room", b =>
                {
                    b.Navigation("PhotosRooms");
                });

            modelBuilder.Entity("Core.Entities.TypeOfRoom", b =>
                {
                    b.Navigation("Room");
                });
#pragma warning restore 612, 618
        }
    }
}
