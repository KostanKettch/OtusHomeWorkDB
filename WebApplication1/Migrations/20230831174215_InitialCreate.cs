using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OtusHomeWorkDB.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    login = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    is_banned = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    is_approved = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "subcategories",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    parent_category_id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subcategories", x => x.id);
                    table.ForeignKey(
                        name: "FK_subcategories_categories_parent_category_id",
                        column: x => x.parent_category_id,
                        principalTable: "categories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "goods",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    subcategory_id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    price = table.Column<float>(type: "real", nullable: false),
                    stock = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_goods", x => x.id);
                    table.ForeignKey(
                        name: "FK_goods_subcategories_subcategory_id",
                        column: x => x.subcategory_id,
                        principalTable: "subcategories",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_goods_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { new Guid("8b28655c-c935-49c4-86c5-75600284bd40"), "Видеоигры и приставки" },
                    { new Guid("ec9e49b9-2e08-410b-a5c1-7b7252d0c527"), "Игрушки и хобби" }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "id", "email", "login" },
                values: new object[,]
                {
                    { new Guid("b828ad5b-e854-4c17-b6cd-0c5896bedf84"), "romeNoMe@email.com", "romeNoMe" },
                    { new Guid("cc9efa9c-0182-42bb-a465-44be5311e0b9"), "cichatra@email.com", "cichatra" },
                    { new Guid("ccc4d935-6da2-404c-a471-b847e44bb325"), "bletrove@email.com", "bletrove" },
                    { new Guid("d0a82306-a01e-4049-93cb-7ccf225d0e96"), "sleynxic@email.com", "sleynxic" },
                    { new Guid("dc023717-32e7-49f3-b3df-f6136bb1b3ba"), "tHErSagN@email.com", "tHErSagN" }
                });

            migrationBuilder.InsertData(
                table: "subcategories",
                columns: new[] { "id", "name", "parent_category_id" },
                values: new object[,]
                {
                    { new Guid("169fc074-72a8-482a-9e59-23259affe804"), "Игрушки-конструкторы LEGO (R)", new Guid("ec9e49b9-2e08-410b-a5c1-7b7252d0c527") },
                    { new Guid("31dfad83-c6e0-48f6-bc08-8124b688c6fe"), "Товары для видеоигр", new Guid("8b28655c-c935-49c4-86c5-75600284bd40") },
                    { new Guid("56dc00e6-f8de-44fa-870c-7a3bb2b1c785"), "Игры", new Guid("ec9e49b9-2e08-410b-a5c1-7b7252d0c527") },
                    { new Guid("5f2ea570-81e9-49a1-8d83-e1a605e7b10c"), "Видеоигры", new Guid("8b28655c-c935-49c4-86c5-75600284bd40") },
                    { new Guid("6718cb33-600f-40c3-b100-35e6fcb5b1fd"), "Настольные и традиционные игры", new Guid("ec9e49b9-2e08-410b-a5c1-7b7252d0c527") },
                    { new Guid("74b3fce3-0bbb-43e8-b722-0df53773303c"), "Электронные игры", new Guid("ec9e49b9-2e08-410b-a5c1-7b7252d0c527") },
                    { new Guid("77a743c2-4ae6-4d95-91d6-bcc2ee821e99"), "Игровые приставки", new Guid("8b28655c-c935-49c4-86c5-75600284bd40") },
                    { new Guid("8c7910a7-b4ad-42b1-bf00-73ba89324f4c"), "Ролевые игры", new Guid("ec9e49b9-2e08-410b-a5c1-7b7252d0c527") },
                    { new Guid("d102abf7-f9cf-4f87-a401-783ab5e4f1a0"), "Миниатюры и военные игры", new Guid("ec9e49b9-2e08-410b-a5c1-7b7252d0c527") },
                    { new Guid("e4254a4f-c474-4f5c-9a0f-9c57866aef8e"), "Строительные игрушки", new Guid("ec9e49b9-2e08-410b-a5c1-7b7252d0c527") }
                });

            migrationBuilder.InsertData(
                table: "goods",
                columns: new[] { "id", "name", "price", "stock", "subcategory_id", "user_id" },
                values: new object[,]
                {
                    { new Guid("04caacf4-491b-4393-977b-fd4da948abaf"), "Nintendo Game Boy Advance", 200f, 10f, new Guid("77a743c2-4ae6-4d95-91d6-bcc2ee821e99"), new Guid("dc023717-32e7-49f3-b3df-f6136bb1b3ba") },
                    { new Guid("31e8f304-c0d2-40ad-b3c2-32640abf781c"), "ELEKTRONIKA 24-01 Game Nu Pogodi Eggs Soviet Nintendo USSR WORKING", 110f, 1f, new Guid("74b3fce3-0bbb-43e8-b722-0df53773303c"), new Guid("d0a82306-a01e-4049-93cb-7ccf225d0e96") },
                    { new Guid("a062143a-ff05-493c-8802-9e91511b06d5"), "Lego Western Set 6764 Sherrif Lock", 299f, 7f, new Guid("169fc074-72a8-482a-9e59-23259affe804"), new Guid("cc9efa9c-0182-42bb-a465-44be5311e0b9") },
                    { new Guid("cbf3556c-f9c6-47a7-931e-70ec5e45e6c2"), "Knight-Arcanum - Stormcast Eternals Questor Relictor - Warhammer Age Of Sigmar", 3f, 33f, new Guid("d102abf7-f9cf-4f87-a401-783ab5e4f1a0"), new Guid("cc9efa9c-0182-42bb-a465-44be5311e0b9") },
                    { new Guid("cc8ee15f-f3bc-4249-889e-71eb6fb1792f"), "DND Dice", 20f, 1f, new Guid("8c7910a7-b4ad-42b1-bf00-73ba89324f4c"), new Guid("dc023717-32e7-49f3-b3df-f6136bb1b3ba") },
                    { new Guid("dd42f1cd-ac51-4805-b132-5ad3bd12f032"), "Rubiks cube", 5f, 15f, new Guid("6718cb33-600f-40c3-b100-35e6fcb5b1fd"), new Guid("dc023717-32e7-49f3-b3df-f6136bb1b3ba") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_goods_subcategory_id",
                table: "goods",
                column: "subcategory_id");

            migrationBuilder.CreateIndex(
                name: "IX_goods_user_id",
                table: "goods",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_subcategories_parent_category_id",
                table: "subcategories",
                column: "parent_category_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "goods");

            migrationBuilder.DropTable(
                name: "subcategories");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
