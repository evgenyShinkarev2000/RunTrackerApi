using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RunTrackerApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RunRecordCovers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Distance = table.Column<double>(type: "double precision", nullable: false),
                    Start = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "interval", nullable: false),
                    AverageSpeed = table.Column<double>(type: "double precision", nullable: false),
                    AveragePulse = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RunRecordCovers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RunRecordCoverMetas",
                columns: table => new
                {
                    Key = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    RunRecordCoverId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RunRecordCoverMetas", x => new { x.Key, x.UserId });
                    table.ForeignKey(
                        name: "FK_RunRecordCoverMetas_RunRecordCovers_RunRecordCoverId",
                        column: x => x.RunRecordCoverId,
                        principalTable: "RunRecordCovers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RunRecordCoverMetas_RunRecordCoverId",
                table: "RunRecordCoverMetas",
                column: "RunRecordCoverId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RunRecordCoverMetas");

            migrationBuilder.DropTable(
                name: "RunRecordCovers");
        }
    }
}
