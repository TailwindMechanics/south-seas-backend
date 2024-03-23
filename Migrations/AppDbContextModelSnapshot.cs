﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SouthSeas.SchemaGen;

#nullable disable

namespace SouthSeas.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SouthSeas.Schema.Car", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("Untiled");

                    b.HasKey("Id");

                    b.ToTable("car");
                });

            modelBuilder.Entity("SouthSeas.Schema.Movement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<float>("Speed")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("real")
                        .HasDefaultValue(1f);

                    b.HasKey("Id");

                    b.ToTable("movement");
                });

            modelBuilder.Entity("SouthSeas.Schema.Player", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("Untitled");

                    b.HasKey("Id");

                    b.ToTable("player");
                });

            modelBuilder.Entity("SouthSeas.Schema.SceneRow", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<Guid?>("CarId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("MovementId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("PlayerId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("TransformId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("MovementId");

                    b.HasIndex("PlayerId");

                    b.HasIndex("TransformId");

                    b.ToTable("scene");
                });

            modelBuilder.Entity("SouthSeas.Schema.Transform", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<float[]>("Position")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("real[]")
                        .HasDefaultValue(new[] { 0f, 0f, 0f })
                        .HasColumnName("position");

                    b.Property<float[]>("Rotation")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("real[]")
                        .HasDefaultValue(new[] { 0f, 0f, 0f })
                        .HasColumnName("rotation");

                    b.Property<float[]>("Scale")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("real[]")
                        .HasDefaultValue(new[] { 1f, 1f, 1f })
                        .HasColumnName("scale");

                    b.HasKey("Id");

                    b.ToTable("transform");
                });

            modelBuilder.Entity("SouthSeas.Schema.SceneRow", b =>
                {
                    b.HasOne("SouthSeas.Schema.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId");

                    b.HasOne("SouthSeas.Schema.Movement", "Movement")
                        .WithMany()
                        .HasForeignKey("MovementId");

                    b.HasOne("SouthSeas.Schema.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId");

                    b.HasOne("SouthSeas.Schema.Transform", "Transform")
                        .WithMany()
                        .HasForeignKey("TransformId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Movement");

                    b.Navigation("Player");

                    b.Navigation("Transform");
                });
#pragma warning restore 612, 618
        }
    }
}
