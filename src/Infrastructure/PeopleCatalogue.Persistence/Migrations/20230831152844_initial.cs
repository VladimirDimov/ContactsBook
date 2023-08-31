using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ContactsBook.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Iban = table.Column<string>(type: "nvarchar(34)", maxLength: 34, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Address", "CreatedOn", "DateOfBirth", "FirstName", "Iban", "LastName", "PhoneNumber", "UpdatedOn" },
                values: new object[,]
                {
                    { 1, "Sofia, Iztok", new DateTime(2023, 8, 31, 15, 28, 44, 198, DateTimeKind.Utc).AddTicks(1635), new DateTime(1980, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adam", "BG18RZBB91550123456789", "Baum", "555-00001", null },
                    { 2, "Plovdiv, Izgrev", new DateTime(2023, 8, 31, 15, 28, 44, 198, DateTimeKind.Utc).AddTicks(1643), new DateTime(1984, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bob", "BG18RZBB91550123456789", "Apple", "555-00002", null },
                    { 3, "Sofia, Geo Milev 123", new DateTime(2023, 8, 31, 15, 28, 44, 198, DateTimeKind.Utc).AddTicks(1645), new DateTime(1991, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dusty", "BG18RZBB91550123456789", "Carr", "777-88881", null },
                    { 4, "Sofia, Iztok", new DateTime(2023, 8, 31, 15, 28, 44, 198, DateTimeKind.Utc).AddTicks(1646), new DateTime(1972, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Chris", "BG18RZBB91550123456789", "Cross", "777-51516", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
