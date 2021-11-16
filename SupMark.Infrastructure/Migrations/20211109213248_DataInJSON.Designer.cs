﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SupMark.Infrastructure.DataAccess;

namespace SupMark.Infrastructure.Migrations
{
    [DbContext(typeof(SupMarkDbContext))]
    [Migration("20211109213248_DataInJSON")]
    partial class DataInJSON
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ListUser", b =>
                {
                    b.Property<int>("ListsId")
                        .HasColumnType("int");

                    b.Property<string>("UsersSupMarkUserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ListsId", "UsersSupMarkUserId");

                    b.HasIndex("UsersSupMarkUserId");

                    b.ToTable("ListUser");
                });

            modelBuilder.Entity("SupMark.Core.Entities.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AddedBySupMarkUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("ListId")
                        .HasColumnType("int");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("RemovedBySupMarkUserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("AddedBySupMarkUserId");

                    b.HasIndex("ListId");

                    b.HasIndex("ProductId");

                    b.HasIndex("RemovedBySupMarkUserId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("SupMark.Core.Entities.List", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ItemsJSON")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsersJSON")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Lists");
                });

            modelBuilder.Entity("SupMark.Core.Entities.Partials.ProductType", b =>
                {
                    b.Property<string>("Label")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Specific")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Label");

                    b.ToTable("ProductTypes");
                });

            modelBuilder.Entity("SupMark.Core.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeLabel")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("TypeLabel");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("SupMark.Core.Entities.User", b =>
                {
                    b.Property<string>("SupMarkUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ListsJSON")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SupMarkUserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ListUser", b =>
                {
                    b.HasOne("SupMark.Core.Entities.List", null)
                        .WithMany()
                        .HasForeignKey("ListsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SupMark.Core.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UsersSupMarkUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SupMark.Core.Entities.Item", b =>
                {
                    b.HasOne("SupMark.Core.Entities.User", "AddedBy")
                        .WithMany()
                        .HasForeignKey("AddedBySupMarkUserId");

                    b.HasOne("SupMark.Core.Entities.List", "List")
                        .WithMany("Items")
                        .HasForeignKey("ListId");

                    b.HasOne("SupMark.Core.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.HasOne("SupMark.Core.Entities.User", "RemovedBy")
                        .WithMany()
                        .HasForeignKey("RemovedBySupMarkUserId");

                    b.Navigation("AddedBy");

                    b.Navigation("List");

                    b.Navigation("Product");

                    b.Navigation("RemovedBy");
                });

            modelBuilder.Entity("SupMark.Core.Entities.Product", b =>
                {
                    b.HasOne("SupMark.Core.Entities.Partials.ProductType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeLabel");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("SupMark.Core.Entities.List", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
