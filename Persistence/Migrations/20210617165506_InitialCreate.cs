using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Breeds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breeds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Farms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Farms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    EarTag = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Sex = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    FarmId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    BreedId = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "date", nullable: true),
                    BirthWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AdmissionDate = table.Column<DateTime>(type: "date", nullable: true),
                    IncomeWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DamId = table.Column<int>(type: "int", nullable: true),
                    SireId = table.Column<int>(type: "int", nullable: true),
                    Remark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animals_Animals_DamId",
                        column: x => x.DamId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Animals_Animals_SireId",
                        column: x => x.SireId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Animals_Breeds_BreedId",
                        column: x => x.BreedId,
                        principalTable: "Breeds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Animals_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Animals_Farms_FarmId",
                        column: x => x.FarmId,
                        principalTable: "Farms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Breeds",
                columns: new[] { "Id", "Created", "CreatedBy", "LastUpdated", "LastUpdatedBy", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 6, 17, 11, 55, 6, 363, DateTimeKind.Local).AddTicks(2342), null, null, null, "-No Asignado-" },
                    { 29, new DateTime(2021, 6, 17, 11, 55, 6, 363, DateTimeKind.Local).AddTicks(5235), null, null, null, "Velasquez" },
                    { 28, new DateTime(2021, 6, 17, 11, 55, 6, 363, DateTimeKind.Local).AddTicks(5234), null, null, null, "Simmental" },
                    { 27, new DateTime(2021, 6, 17, 11, 55, 6, 363, DateTimeKind.Local).AddTicks(5233), null, null, null, "Sanmartinero" },
                    { 26, new DateTime(2021, 6, 17, 11, 55, 6, 363, DateTimeKind.Local).AddTicks(5232), null, null, null, "Romosinuano" },
                    { 25, new DateTime(2021, 6, 17, 11, 55, 6, 363, DateTimeKind.Local).AddTicks(5231), null, null, null, "Pardo" },
                    { 24, new DateTime(2021, 6, 17, 11, 55, 6, 363, DateTimeKind.Local).AddTicks(5230), null, null, null, "Normando" },
                    { 23, new DateTime(2021, 6, 17, 11, 55, 6, 363, DateTimeKind.Local).AddTicks(5229), null, null, null, "Nelore" },
                    { 22, new DateTime(2021, 6, 17, 11, 55, 6, 363, DateTimeKind.Local).AddTicks(5228), null, null, null, "Lucerna" },
                    { 21, new DateTime(2021, 6, 17, 11, 55, 6, 363, DateTimeKind.Local).AddTicks(5227), null, null, null, "Limousin" },
                    { 20, new DateTime(2021, 6, 17, 11, 55, 6, 363, DateTimeKind.Local).AddTicks(5225), null, null, null, "Jersey" },
                    { 19, new DateTime(2021, 6, 17, 11, 55, 6, 363, DateTimeKind.Local).AddTicks(5224), null, null, null, "Indubrasil" },
                    { 17, new DateTime(2021, 6, 17, 11, 55, 6, 363, DateTimeKind.Local).AddTicks(5222), null, null, null, "Harton del valle" },
                    { 16, new DateTime(2021, 6, 17, 11, 55, 6, 363, DateTimeKind.Local).AddTicks(5221), null, null, null, "Gyr" },
                    { 18, new DateTime(2021, 6, 17, 11, 55, 6, 363, DateTimeKind.Local).AddTicks(5223), null, null, null, "Holstein" },
                    { 14, new DateTime(2021, 6, 17, 11, 55, 6, 363, DateTimeKind.Local).AddTicks(5219), null, null, null, "Criollo" },
                    { 2, new DateTime(2021, 6, 17, 11, 55, 6, 363, DateTimeKind.Local).AddTicks(5196), null, null, null, "Angus" },
                    { 3, new DateTime(2021, 6, 17, 11, 55, 6, 363, DateTimeKind.Local).AddTicks(5206), null, null, null, "Angus Negro" },
                    { 4, new DateTime(2021, 6, 17, 11, 55, 6, 363, DateTimeKind.Local).AddTicks(5208), null, null, null, "Angus Rojo" },
                    { 5, new DateTime(2021, 6, 17, 11, 55, 6, 363, DateTimeKind.Local).AddTicks(5209), null, null, null, "Ayrshire" },
                    { 15, new DateTime(2021, 6, 17, 11, 55, 6, 363, DateTimeKind.Local).AddTicks(5220), null, null, null, "Guzerat" },
                    { 7, new DateTime(2021, 6, 17, 11, 55, 6, 363, DateTimeKind.Local).AddTicks(5211), null, null, null, "Brahman" },
                    { 6, new DateTime(2021, 6, 17, 11, 55, 6, 363, DateTimeKind.Local).AddTicks(5210), null, null, null, "Bom" },
                    { 9, new DateTime(2021, 6, 17, 11, 55, 6, 363, DateTimeKind.Local).AddTicks(5213), null, null, null, "Casanareño" },
                    { 10, new DateTime(2021, 6, 17, 11, 55, 6, 363, DateTimeKind.Local).AddTicks(5214), null, null, null, "Cebu" },
                    { 11, new DateTime(2021, 6, 17, 11, 55, 6, 363, DateTimeKind.Local).AddTicks(5216), null, null, null, "Charolais" },
                    { 12, new DateTime(2021, 6, 17, 11, 55, 6, 363, DateTimeKind.Local).AddTicks(5217), null, null, null, "Chino Santandereano" },
                    { 13, new DateTime(2021, 6, 17, 11, 55, 6, 363, DateTimeKind.Local).AddTicks(5218), null, null, null, "Costeño con Cuernos" },
                    { 8, new DateTime(2021, 6, 17, 11, 55, 6, 363, DateTimeKind.Local).AddTicks(5212), null, null, null, "Brangus" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Created", "CreatedBy", "LastUpdated", "LastUpdatedBy", "Name" },
                values: new object[,]
                {
                    { 5, new DateTime(2021, 6, 17, 11, 55, 6, 364, DateTimeKind.Local).AddTicks(6788), "system", null, null, "Toros" },
                    { 1, new DateTime(2021, 6, 17, 11, 55, 6, 364, DateTimeKind.Local).AddTicks(6538), "system", null, null, "Crias" },
                    { 2, new DateTime(2021, 6, 17, 11, 55, 6, 364, DateTimeKind.Local).AddTicks(6781), "system", null, null, "Novillas" },
                    { 3, new DateTime(2021, 6, 17, 11, 55, 6, 364, DateTimeKind.Local).AddTicks(6785), "system", null, null, "Mautes" },
                    { 4, new DateTime(2021, 6, 17, 11, 55, 6, 364, DateTimeKind.Local).AddTicks(6786), "system", null, null, "Vacas" }
                });

            migrationBuilder.InsertData(
                table: "Farms",
                columns: new[] { "Id", "Address", "Code", "Created", "CreatedBy", "LastUpdated", "LastUpdatedBy", "Name", "Phone" },
                values: new object[] { 1, "Santa Rosa de Lima, paralelo 38", "ARZ", new DateTime(2021, 6, 17, 11, 55, 6, 365, DateTimeKind.Local).AddTicks(4107), null, null, null, "Hacienda Arizona Y Villa Monica", "3000000000" });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_BreedId",
                table: "Animals",
                column: "BreedId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_CategoryId",
                table: "Animals",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_Code",
                table: "Animals",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Animals_DamId",
                table: "Animals",
                column: "DamId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_FarmId",
                table: "Animals",
                column: "FarmId");

            migrationBuilder.CreateIndex(
                name: "IX_Animals_SireId",
                table: "Animals",
                column: "SireId");

            migrationBuilder.CreateIndex(
                name: "IX_Breeds_Name",
                table: "Breeds",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Farms_Code",
                table: "Farms",
                column: "Code",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Breeds");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Farms");
        }
    }
}
