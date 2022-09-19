using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Account.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "COA",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccCode = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Accname = table.Column<string>(type: "nvarchar(150)", nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: false),
                    Acclevel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COA", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Voucher",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    voucherdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    voucherno = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    verified = table.Column<int>(type: "int", nullable: false),
                    crcoacode = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    crcoaname = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    cramt = table.Column<decimal>(type: "decimal (18,3)", nullable: false),
                    drcoacode = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    drcoaname = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    dramt = table.Column<decimal>(type: "decimal(18,3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voucher", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_COA_AccCode",
                table: "COA",
                column: "AccCode",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "COA");

            migrationBuilder.DropTable(
                name: "Voucher");
        }
    }
}
