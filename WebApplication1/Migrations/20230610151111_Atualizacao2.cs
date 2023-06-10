using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class Atualizacao2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Luminaria",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Modelo = table.Column<string>(type: "text", nullable: false),
                    Cidade = table.Column<string>(type: "text", nullable: false),
                    Pais = table.Column<string>(type: "text", nullable: false),
                    id_cliente = table.Column<string>(type: "text", nullable: false),
                    id_grupo = table.Column<string>(type: "text", nullable: false),
                    Latitude = table.Column<string>(type: "text", nullable: false),
                    Longitude = table.Column<string>(type: "text", nullable: false),
                    Estado = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Luminaria", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Luminaria");
        }
    }
}
