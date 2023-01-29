﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using QSIT.Models;

#nullable disable

namespace QSIT.Migrations
{
    [DbContext(typeof(QsitDBContext))]
    partial class QsitDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("QSIT.Models.Map", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<double>("Location")
                        .HasColumnType("float");

                    b.Property<int>("MapSubTypeId")
                        .HasColumnType("int");

                    b.Property<int>("MapTypeId")
                        .HasColumnType("int");

                    b.Property<double>("Raduis")
                        .HasColumnType("float");

                    b.Property<int>("Time")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MapSubTypeId");

                    b.HasIndex("MapTypeId");

                    b.ToTable("Maps");
                });

            modelBuilder.Entity("QSIT.Models.Map_Sub_Type", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("MapTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Map_Sub_Types");
                });

            modelBuilder.Entity("QSIT.Models.Map_Type", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Map_Types");
                });

            modelBuilder.Entity("QSIT.Models.Map", b =>
                {
                    b.HasOne("QSIT.Models.Map_Sub_Type", "MapSubType")
                        .WithMany()
                        .HasForeignKey("MapSubTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("QSIT.Models.Map_Type", "MapType")
                        .WithMany()
                        .HasForeignKey("MapTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MapSubType");

                    b.Navigation("MapType");
                });
#pragma warning restore 612, 618
        }
    }
}
