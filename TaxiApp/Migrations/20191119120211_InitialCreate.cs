using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TaxiApp.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    Car = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Longitude = table.Column<double>(nullable: false),
                    Latitude = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    State = table.Column<string>(nullable: true),
                    StartLocationId = table.Column<Guid>(nullable: true),
                    EndLocationId = table.Column<Guid>(nullable: true),
                    DriverId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Location_EndLocationId",
                        column: x => x.EndLocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_Location_StartLocationId",
                        column: x => x.StartLocationId,
                        principalTable: "Location",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    Comments = table.Column<string>(nullable: true),
                    OrderId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "Comments", "FullName", "OrderId" },
                values: new object[,]
                {
                    { new Guid("3123e3ed-186e-4349-a173-c503d8cc3261"), null, "Алиса Александровна", null },
                    { new Guid("83068744-d558-45b0-ae77-cfb5af7b7c7a"), null, "Иванов Иван", null },
                    { new Guid("43d4d893-5975-45cb-a807-10c30042b356"), null, "Сергей Шмитд", null }
                });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "Id", "Car", "FullName" },
                values: new object[,]
                {
                    { new Guid("664aafc9-da7a-46e9-9315-fe205f373675"), "Nissan 203", "Петрович Петров" },
                    { new Guid("15cb449a-83f2-4060-bd0c-cdd10c9a7dd9"), "Lexus 111", "Алексей Алексеевич" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_OrderId",
                table: "Clients",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_DriverId",
                table: "Order",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_EndLocationId",
                table: "Order",
                column: "EndLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_StartLocationId",
                table: "Order",
                column: "StartLocationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "Location");
        }
    }
}
