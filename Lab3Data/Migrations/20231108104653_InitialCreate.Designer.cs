﻿// <auto-generated />
using System;
using Lab3Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Lab3Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231108104653_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("Lab3Data.Entities.BookEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("author");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("created_at");

                    b.Property<string>("ISBN")
                        .HasColumnType("TEXT")
                        .HasColumnName("isbn");

                    b.Property<int>("Pages")
                        .HasColumnType("INTEGER")
                        .HasColumnName("pages");

                    b.Property<int?>("PublishYear")
                        .HasColumnType("INTEGER")
                        .HasColumnName("publish_year");

                    b.Property<string>("Publisher")
                        .HasColumnType("TEXT")
                        .HasColumnName("publisher");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("title");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Andrew Lock",
                            CreatedAt = new DateTime(2021, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Pages = 370,
                            PublishYear = 2017,
                            Title = "ASP.NET Core in Action"
                        },
                        new
                        {
                            Id = 2,
                            Author = "Christian Gammelgaard",
                            CreatedAt = new DateTime(2019, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Pages = 300,
                            PublishYear = 2020,
                            Title = "Microservices in .NET"
                        },
                        new
                        {
                            Id = 3,
                            Author = "Marinko Spasojevic",
                            CreatedAt = new DateTime(2018, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Pages = 250,
                            PublishYear = 2019,
                            Title = "Ultimate ASP.NET Core Web API"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
