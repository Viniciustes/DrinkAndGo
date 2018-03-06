using Microsoft.EntityFrameworkCore.Migrations;

namespace DrinkAndGo.Migrations
{
    public partial class CartItem1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ShoppingCartId",
                table: "ShoppingCartItems",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ShoppingCartId",
                table: "ShoppingCartItems",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
