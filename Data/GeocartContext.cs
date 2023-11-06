using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;


namespace asp_mvc_webmap;

public partial class GeocartContext : IdentityDbContext<IdentityUser>
{
    public GeocartContext()
    {
    }

    public GeocartContext(DbContextOptions<GeocartContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Chaleur> Chaleurs { get; set; }

    public virtual DbSet<Secheress> Secheresses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Host=localhost; Database=geocart; Username=nathanielkwok;", x => x.UseNetTopologySuite());
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.HasPostgresExtension("postgis");

        modelBuilder.Entity<Chaleur>(entity =>
        {
            entity.HasKey(e => e.OgcFid).HasName("chaleur_pkey");

            entity.ToTable("chaleur");

            entity.HasIndex(e => e.WkbGeometry, "chaleur_wkb_geometry_geom_idx").HasMethod("gist");

            entity.Property(e => e.OgcFid).HasColumnName("ogc_fid");
            entity.Property(e => e.Chaleurcat)
                .HasColumnType("character varying")
                .HasColumnName("chaleurcat");
            entity.Property(e => e.Chaleurcl).HasColumnName("chaleurcl");
            entity.Property(e => e.Fid).HasColumnName("fid");
            entity.Property(e => e.SumShape).HasColumnName("sum_shape_");
            entity.Property(e => e.SumShape1).HasColumnName("sum_shape1");
            entity.Property(e => e.WkbGeometry)
                .HasColumnType("geometry(MultiPolygon,4326)")
                .HasColumnName("wkb_geometry");
        });

        
        modelBuilder.Entity<Secheress>(entity =>
        {
            entity.HasKey(e => e.OgcFid).HasName("secheresses_pkey");

            entity.ToTable("secheresses");

            entity.HasIndex(e => e.WkbGeometry, "secheresses_wkb_geometry_geom_idx").HasMethod("gist");

            entity.Property(e => e.OgcFid).HasColumnName("ogc_fid");
            entity.Property(e => e.Fid).HasColumnName("fid");
            entity.Property(e => e.Secherecat)
                .HasColumnType("character varying")
                .HasColumnName("secherecat");
            entity.Property(e => e.Secherescl).HasColumnName("secherescl");
            entity.Property(e => e.SumShape).HasColumnName("sum_shape_");
            entity.Property(e => e.SumShape1).HasColumnName("sum_shape1");
            entity.Property(e => e.WkbGeometry)
                .HasColumnType("geometry(MultiPolygon,4326)")
                .HasColumnName("wkb_geometry");
        });

    
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
