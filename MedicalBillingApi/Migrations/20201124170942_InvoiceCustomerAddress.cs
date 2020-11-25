using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicalBillingApi.Migrations
{
    public partial class InvoiceCustomerAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerAddress",
                table: "Invoices",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerAddress",
                table: "Invoices");
        }
    }
}
