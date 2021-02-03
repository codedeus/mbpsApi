using Microsoft.EntityFrameworkCore.Migrations;

namespace MedicalBillingApi.Migrations
{
    public partial class InvoiceCustomerPhoneNumber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CustomerPhoneNumber",
                table: "Invoices",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CustomerPhoneNumber",
                table: "Customers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CustomerPhoneNumber",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "CustomerPhoneNumber",
                table: "Customers");
        }
    }
}
