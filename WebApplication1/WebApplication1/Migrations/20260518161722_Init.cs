using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComponentManufacturers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Abbreviation = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    FoundationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentManufacturers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComponentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Abbreviation = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComponentTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PCs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    Warranty = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PCs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Components",
                columns: table => new
                {
                    Code = table.Column<string>(type: "char(10)", maxLength: 10, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComponentManufacturersId = table.Column<int>(type: "int", nullable: false),
                    ComponentTypesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Components", x => x.Code);
                    table.ForeignKey(
                        name: "FK_Components_ComponentManufacturers_ComponentManufacturersId",
                        column: x => x.ComponentManufacturersId,
                        principalTable: "ComponentManufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Components_ComponentTypes_ComponentTypesId",
                        column: x => x.ComponentTypesId,
                        principalTable: "ComponentTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PCComponents",
                columns: table => new
                {
                    PCId = table.Column<int>(type: "int", nullable: false),
                    ComponentCode = table.Column<string>(type: "char(10)", maxLength: 10, nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PCComponents", x => new { x.PCId, x.ComponentCode });
                    table.ForeignKey(
                        name: "FK_PCComponents_Components_ComponentCode",
                        column: x => x.ComponentCode,
                        principalTable: "Components",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PCComponents_PCs_PCId",
                        column: x => x.PCId,
                        principalTable: "PCs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ComponentManufacturers",
                columns: new[] { "Id", "Abbreviation", "FoundationDate", "FullName" },
                values: new object[,]
                {
                    { 1, "Intel", new DateTime(1968, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Intel Corporation" },
                    { 2, "AMD", new DateTime(1969, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Advanced Micro Devices" },
                    { 3, "NVDA", new DateTime(1993, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "NVIDIA Corporation" }
                });

            migrationBuilder.InsertData(
                table: "ComponentTypes",
                columns: new[] { "Id", "Abbreviation", "FullName" },
                values: new object[,]
                {
                    { 1, "CPU", "Central Processing Unit" },
                    { 2, "GPU", "Graphics Processing Unit" },
                    { 3, "RAM", "Random Access Memory" }
                });

            migrationBuilder.InsertData(
                table: "PCs",
                columns: new[] { "Id", "CreatedAt", "Name", "Stock", "Warranty", "Weight" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 5, 8, 9, 0, 0, 0, DateTimeKind.Unspecified), "Gaming Beast X", 5, 36, 12.5 },
                    { 2, new DateTime(2026, 4, 15, 13, 30, 0, 0, DateTimeKind.Unspecified), "Office Mini Pro", 12, 24, 4.1999998092651367 },
                    { 3, new DateTime(2026, 3, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), "Workstation Pro", 3, 48, 18.0 }
                });

            migrationBuilder.InsertData(
                table: "Components",
                columns: new[] { "Code", "ComponentManufacturersId", "ComponentTypesId", "Description", "Name" },
                values: new object[,]
                {
                    { "I9-14900K", 1, 1, "High-performance desktop processor with 24 cores", "Intel Core i9-14900K" },
                    { "RTX4090", 3, 2, "Top-tier NVIDIA GPU with 24GB GDDR6X", "NVIDIA GeForce RTX 4090" },
                    { "RX7900XTX", 2, 2, "Flagship AMD graphics card with 24GB GDDR6", "AMD Radeon RX 7900 XTX" }
                });

            migrationBuilder.InsertData(
                table: "PCComponents",
                columns: new[] { "ComponentCode", "PCId", "Amount" },
                values: new object[,]
                {
                    { "I9-14900K", 1, 1 },
                    { "RTX4090", 1, 1 },
                    { "I9-14900K", 2, 1 },
                    { "RX7900XTX", 2, 1 },
                    { "I9-14900K", 3, 2 },
                    { "RTX4090", 3, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Components_ComponentManufacturersId",
                table: "Components",
                column: "ComponentManufacturersId");

            migrationBuilder.CreateIndex(
                name: "IX_Components_ComponentTypesId",
                table: "Components",
                column: "ComponentTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_PCComponents_ComponentCode",
                table: "PCComponents",
                column: "ComponentCode");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PCComponents");

            migrationBuilder.DropTable(
                name: "Components");

            migrationBuilder.DropTable(
                name: "PCs");

            migrationBuilder.DropTable(
                name: "ComponentManufacturers");

            migrationBuilder.DropTable(
                name: "ComponentTypes");
        }
    }
}
