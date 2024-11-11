using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReviewsMicroservice.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changeapproval : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AdminApproval",
                table: "Customer_Reviews",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "UnderReview",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldDefaultValue: "UnderReview");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AdminApproval",
                table: "Customer_Reviews",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "UnderReview",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "UnderReview");
        }
    }
}
