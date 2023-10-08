using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Imoty.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedPropertyTags : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Garages",
                table: "Houses");

            migrationBuilder.DropColumn(
                name: "Garages",
                table: "Apartments");

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApartmentTag",
                columns: table => new
                {
                    ApartmentsId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApartmentTag", x => new { x.ApartmentsId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_ApartmentTag_Apartments_ApartmentsId",
                        column: x => x.ApartmentsId,
                        principalTable: "Apartments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApartmentTag_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BusinesStoreTag",
                columns: table => new
                {
                    BusinesStoresId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinesStoreTag", x => new { x.BusinesStoresId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_BusinesStoreTag_BusinesStores_BusinesStoresId",
                        column: x => x.BusinesStoresId,
                        principalTable: "BusinesStores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusinesStoreTag_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "FieldTag",
                columns: table => new
                {
                    FieldsId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldTag", x => new { x.FieldsId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_FieldTag_Fields_FieldsId",
                        column: x => x.FieldsId,
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FieldTag_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HouseTag",
                columns: table => new
                {
                    HousesId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseTag", x => new { x.HousesId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_HouseTag_Houses_HousesId",
                        column: x => x.HousesId,
                        principalTable: "Houses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HouseTag_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TagWarehouse",
                columns: table => new
                {
                    TagsId = table.Column<int>(type: "int", nullable: false),
                    WarehousesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagWarehouse", x => new { x.TagsId, x.WarehousesId });
                    table.ForeignKey(
                        name: "FK_TagWarehouse_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TagWarehouse_Warehouses_WarehousesId",
                        column: x => x.WarehousesId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentTag_TagsId",
                table: "ApartmentTag",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_BusinesStoreTag_TagsId",
                table: "BusinesStoreTag",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_FieldTag_TagsId",
                table: "FieldTag",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_HouseTag_TagsId",
                table: "HouseTag",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_IsDeleted",
                table: "Tags",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_TagWarehouse_WarehousesId",
                table: "TagWarehouse",
                column: "WarehousesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApartmentTag");

            migrationBuilder.DropTable(
                name: "BusinesStoreTag");

            migrationBuilder.DropTable(
                name: "FieldTag");

            migrationBuilder.DropTable(
                name: "HouseTag");

            migrationBuilder.DropTable(
                name: "TagWarehouse");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.AddColumn<int>(
                name: "Garages",
                table: "Houses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Garages",
                table: "Apartments",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
