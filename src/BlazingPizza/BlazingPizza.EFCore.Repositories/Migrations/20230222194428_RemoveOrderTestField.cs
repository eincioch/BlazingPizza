using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazingPizza.EFCore.Repositories.Migrations
{
    /// <inheritdoc />
    public partial class RemoveOrderTestField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TestField",
                table: "Orders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TestField",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
