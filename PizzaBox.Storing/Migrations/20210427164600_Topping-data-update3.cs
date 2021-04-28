using Microsoft.EntityFrameworkCore.Migrations;

namespace PizzaBox.Storing.Migrations
{
    public partial class Toppingdataupdate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Topping_Pizzas_APizzaEntityId",
                table: "Topping");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Topping",
                table: "Topping");

            migrationBuilder.RenameTable(
                name: "Topping",
                newName: "Toppings");

            migrationBuilder.RenameIndex(
                name: "IX_Topping_APizzaEntityId",
                table: "Toppings",
                newName: "IX_Toppings_APizzaEntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Toppings",
                table: "Toppings",
                column: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Toppings_Pizzas_APizzaEntityId",
                table: "Toppings",
                column: "APizzaEntityId",
                principalTable: "Pizzas",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Toppings_Pizzas_APizzaEntityId",
                table: "Toppings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Toppings",
                table: "Toppings");

            migrationBuilder.RenameTable(
                name: "Toppings",
                newName: "Topping");

            migrationBuilder.RenameIndex(
                name: "IX_Toppings_APizzaEntityId",
                table: "Topping",
                newName: "IX_Topping_APizzaEntityId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Topping",
                table: "Topping",
                column: "EntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Topping_Pizzas_APizzaEntityId",
                table: "Topping",
                column: "APizzaEntityId",
                principalTable: "Pizzas",
                principalColumn: "EntityId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
