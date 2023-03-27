using Microsoft.EntityFrameworkCore.Migrations;

namespace EFCorePMC.DataAnnotation.OnetoOneMapping.Migrations
{
    public partial class TablePerConcrete1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: true),
                    Gender = table.Column<int>(type: "INT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "CustomerRequisite",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "INT", nullable: false),
                    MobileNum = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false),
                    IdProofType = table.Column<int>(type: "INT", nullable: true),
                    IdProof = table.Column<string>(type: "VARCHAR(25)", maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerRequisite", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_CustomerRequisite_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GeneralCustomer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "INT", nullable: false),
                    Credits = table.Column<decimal>(type: "MONEY", nullable: false),
                    NormalCoupon = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralCustomer", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_GeneralCustomer_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RegularCustomer",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "INT", nullable: false),
                    AdvCredits = table.Column<decimal>(type: "MONEY", nullable: false),
                    Perks = table.Column<string>(type: "VARCHAR(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegularCustomer", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_RegularCustomer_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerRequisite");

            migrationBuilder.DropTable(
                name: "GeneralCustomer");

            migrationBuilder.DropTable(
                name: "RegularCustomer");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
