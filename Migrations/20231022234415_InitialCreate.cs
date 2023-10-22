using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace asp_mvc_webmap.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:postgis", ",,");

            migrationBuilder.CreateTable(
                name: "chaleur",
                columns: table => new
                {
                    ogc_fid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fid = table.Column<int>(type: "integer", nullable: true),
                    chaleurcl = table.Column<int>(type: "integer", nullable: true),
                    sum_shape_ = table.Column<double>(type: "double precision", nullable: true),
                    sum_shape1 = table.Column<double>(type: "double precision", nullable: true),
                    chaleurcat = table.Column<string>(type: "character varying", nullable: true),
                    wkb_geometry = table.Column<MultiPolygon>(type: "geometry(MultiPolygon,4326)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("chaleur_pkey", x => x.ogc_fid);
                });

            migrationBuilder.CreateTable(
                name: "secheresses",
                columns: table => new
                {
                    ogc_fid = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fid = table.Column<int>(type: "integer", nullable: true),
                    secherescl = table.Column<int>(type: "integer", nullable: true),
                    sum_shape_ = table.Column<double>(type: "double precision", nullable: true),
                    sum_shape1 = table.Column<double>(type: "double precision", nullable: true),
                    secherecat = table.Column<string>(type: "character varying", nullable: true),
                    wkb_geometry = table.Column<MultiPolygon>(type: "geometry(MultiPolygon,4326)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("secheresses_pkey", x => x.ogc_fid);
                });

            migrationBuilder.CreateIndex(
                name: "chaleur_wkb_geometry_geom_idx",
                table: "chaleur",
                column: "wkb_geometry")
                .Annotation("Npgsql:IndexMethod", "gist");

            migrationBuilder.CreateIndex(
                name: "secheresses_wkb_geometry_geom_idx",
                table: "secheresses",
                column: "wkb_geometry")
                .Annotation("Npgsql:IndexMethod", "gist");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chaleur");

            migrationBuilder.DropTable(
                name: "secheresses");
        }
    }
}
