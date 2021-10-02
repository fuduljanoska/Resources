﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Resources.API.DataAccess;

namespace Resources.API.Migrations
{
    [DbContext(typeof(ResourcesDbContext))]
    partial class ResourcesDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.10");

            modelBuilder.Entity("Resources.API.Models.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BookedQuantity")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateFrom")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateTo")
                        .HasColumnType("TEXT");

                    b.Property<int>("ResourceId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("BookingDbSet");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BookedQuantity = 1,
                            DateFrom = new DateTime(2021, 10, 2, 2, 0, 0, 0, DateTimeKind.Local),
                            DateTo = new DateTime(2021, 10, 6, 2, 0, 0, 0, DateTimeKind.Local),
                            ResourceId = 1
                        },
                        new
                        {
                            Id = 2,
                            BookedQuantity = 2,
                            DateFrom = new DateTime(2021, 10, 3, 2, 0, 0, 0, DateTimeKind.Local),
                            DateTo = new DateTime(2021, 10, 8, 2, 0, 0, 0, DateTimeKind.Local),
                            ResourceId = 1
                        },
                        new
                        {
                            Id = 3,
                            BookedQuantity = 3,
                            DateFrom = new DateTime(2021, 10, 4, 2, 0, 0, 0, DateTimeKind.Local),
                            DateTo = new DateTime(2021, 10, 5, 2, 0, 0, 0, DateTimeKind.Local),
                            ResourceId = 1
                        });
                });

            modelBuilder.Entity("Resources.API.Models.Resource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("ResourcesDbSet");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Resource 1",
                            Quantity = 10
                        },
                        new
                        {
                            Id = 2,
                            Name = "Resource 2",
                            Quantity = 5
                        },
                        new
                        {
                            Id = 3,
                            Name = "Resource 3",
                            Quantity = 10
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
