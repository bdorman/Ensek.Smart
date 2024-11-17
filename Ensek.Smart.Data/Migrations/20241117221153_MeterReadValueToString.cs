using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ensek.Smart.Data.Migrations
{
    /// <inheritdoc />
    public partial class MeterReadValueToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MeterReadValue",
                table: "MeterReading",
                type: "nchar(5)",
                fixedLength: true,
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MeterReadValue",
                table: "MeterReading",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nchar(5)",
                oldFixedLength: true,
                oldMaxLength: 5);
        }
    }
}
