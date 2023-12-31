﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using asp_mvc_webmap;

#nullable disable

namespace asp_mvc_webmap.Migrations
{
    [DbContext(typeof(GeocartContext))]
    [Migration("20231022234415_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "postgis");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("asp_mvc_webmap.Chaleur", b =>
                {
                    b.Property<int>("OgcFid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("ogc_fid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OgcFid"));

                    b.Property<string>("Chaleurcat")
                        .HasColumnType("character varying")
                        .HasColumnName("chaleurcat");

                    b.Property<int?>("Chaleurcl")
                        .HasColumnType("integer")
                        .HasColumnName("chaleurcl");

                    b.Property<int?>("Fid")
                        .HasColumnType("integer")
                        .HasColumnName("fid");

                    b.Property<double?>("SumShape")
                        .HasColumnType("double precision")
                        .HasColumnName("sum_shape_");

                    b.Property<double?>("SumShape1")
                        .HasColumnType("double precision")
                        .HasColumnName("sum_shape1");

                    b.Property<MultiPolygon>("WkbGeometry")
                        .HasColumnType("geometry(MultiPolygon,4326)")
                        .HasColumnName("wkb_geometry");

                    b.HasKey("OgcFid")
                        .HasName("chaleur_pkey");

                    b.HasIndex(new[] { "WkbGeometry" }, "chaleur_wkb_geometry_geom_idx");

                    NpgsqlIndexBuilderExtensions.HasMethod(b.HasIndex(new[] { "WkbGeometry" }, "chaleur_wkb_geometry_geom_idx"), "gist");

                    b.ToTable("chaleur", (string)null);
                });

            modelBuilder.Entity("asp_mvc_webmap.Secheress", b =>
                {
                    b.Property<int>("OgcFid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("ogc_fid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("OgcFid"));

                    b.Property<int?>("Fid")
                        .HasColumnType("integer")
                        .HasColumnName("fid");

                    b.Property<string>("Secherecat")
                        .HasColumnType("character varying")
                        .HasColumnName("secherecat");

                    b.Property<int?>("Secherescl")
                        .HasColumnType("integer")
                        .HasColumnName("secherescl");

                    b.Property<double?>("SumShape")
                        .HasColumnType("double precision")
                        .HasColumnName("sum_shape_");

                    b.Property<double?>("SumShape1")
                        .HasColumnType("double precision")
                        .HasColumnName("sum_shape1");

                    b.Property<MultiPolygon>("WkbGeometry")
                        .HasColumnType("geometry(MultiPolygon,4326)")
                        .HasColumnName("wkb_geometry");

                    b.HasKey("OgcFid")
                        .HasName("secheresses_pkey");

                    b.HasIndex(new[] { "WkbGeometry" }, "secheresses_wkb_geometry_geom_idx");

                    NpgsqlIndexBuilderExtensions.HasMethod(b.HasIndex(new[] { "WkbGeometry" }, "secheresses_wkb_geometry_geom_idx"), "gist");

                    b.ToTable("secheresses", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
