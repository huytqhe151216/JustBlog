﻿// <auto-generated />
using System;
using FA.JustBlock.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FA.JustBlock.Core.Migrations
{
    [DbContext(typeof(JustBlockDbContext))]
    [Migration("20240514145635_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FA.JustBlock.Core.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UrlSlug")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "ASP.NET Category",
                            Name = "ASP.NET",
                            UrlSlug = "asp-net"
                        },
                        new
                        {
                            Id = 2,
                            Description = "C# Category",
                            Name = "C#",
                            UrlSlug = "c-sharp"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Description",
                            Name = "SQL Server",
                            UrlSlug = "sql-server"
                        });
                });

            modelBuilder.Entity("FA.JustBlock.Core.Models.Post", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("PostContent")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<DateTime>("PostedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Published")
                        .HasMaxLength(50)
                        .HasColumnType("bit");

                    b.Property<string>("ShortDescription")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UrlSlug")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Posts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            PostContent = "ASP.NET MVC Post Content",
                            PostedOn = new DateTime(2024, 5, 14, 21, 56, 34, 834, DateTimeKind.Local).AddTicks(2688),
                            Published = true,
                            ShortDescription = "ASP.NET MVC Short Description",
                            Title = "ASP.NET MVC",
                            UrlSlug = "asp-net-mvc"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            PostContent = "ASP.NET API Post Content",
                            PostedOn = new DateTime(2024, 5, 14, 21, 56, 34, 834, DateTimeKind.Local).AddTicks(2705),
                            Published = true,
                            ShortDescription = "ASP.NET API Short Description",
                            Title = "ASP.NET API",
                            UrlSlug = "asp-net-api"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            PostContent = " Post Content",
                            PostedOn = new DateTime(2024, 5, 14, 21, 56, 34, 834, DateTimeKind.Local).AddTicks(2708),
                            Published = false,
                            ShortDescription = " Short Description",
                            Title = "Title",
                            UrlSlug = "asp-net"
                        });
                });

            modelBuilder.Entity("FA.JustBlock.Core.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UrlSlug")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Tags");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Count = 1,
                            Description = "ASP.NET Tag",
                            Name = "ASP.NET",
                            UrlSlug = "asp-net"
                        },
                        new
                        {
                            Id = 2,
                            Count = 2,
                            Description = "C# Tag",
                            Name = "C#",
                            UrlSlug = "c-sharp"
                        },
                        new
                        {
                            Id = 3,
                            Count = 3,
                            Description = "Description",
                            Name = "SQL Server",
                            UrlSlug = "sql-server"
                        });
                });

            modelBuilder.Entity("PostTagMap", b =>
                {
                    b.Property<int>("PostId")
                        .HasColumnType("int");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.HasKey("PostId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("PostTagMap");

                    b.HasData(
                        new
                        {
                            PostId = 1,
                            TagId = 1
                        },
                        new
                        {
                            PostId = 1,
                            TagId = 2
                        },
                        new
                        {
                            PostId = 2,
                            TagId = 1
                        });
                });

            modelBuilder.Entity("FA.JustBlock.Core.Models.Post", b =>
                {
                    b.HasOne("FA.JustBlock.Core.Models.Category", "Category")
                        .WithMany("Posts")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("PostTagMap", b =>
                {
                    b.HasOne("FA.JustBlock.Core.Models.Post", null)
                        .WithMany()
                        .HasForeignKey("PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FA.JustBlock.Core.Models.Tag", null)
                        .WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FA.JustBlock.Core.Models.Category", b =>
                {
                    b.Navigation("Posts");
                });
#pragma warning restore 612, 618
        }
    }
}
