using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Orders.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CustomerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalAmount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderID);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    OrderItemID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<double>(type: "float", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: false),
                    OrderID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.OrderItemID);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderID", "CustomerName", "OrderDate", "OrderNumber", "TotalAmount" },
                values: new object[,]
                {
                    { new Guid("1be791b6-7578-4d2d-92b8-b4c9d5300dc1"), "Rosco Lowy", new DateTime(2022, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Order_2022_4", 40.799999999999997 },
                    { new Guid("4a62dddc-8fdd-4aeb-96f5-a03311348293"), "Eugenio Fieldstone", new DateTime(2023, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Order_2023_4", 1088.4000000000001 },
                    { new Guid("538b01e3-4803-4e4a-9f3c-8ffdfa6092ab"), "Romy Jakoviljevic", new DateTime(2022, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Order_2022_1", 14.0 },
                    { new Guid("7ad6b3ae-d67c-46f4-9561-f4cd129eca98"), "Berkly Sterricks", new DateTime(2023, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Order_2023_5", 637.70000000000005 },
                    { new Guid("91f3d4de-2ae6-45ec-8f46-1966407403bd"), "Lek Whellans", new DateTime(2022, 10, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Order_2022_2", 1197.0 },
                    { new Guid("a16409c9-d498-4469-b8f5-5b7348fb7034"), "Quentin Spiaggia", new DateTime(2023, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Order_2023_3", 94.5 },
                    { new Guid("c5cebf9d-8ca1-4f41-b85d-b2120f452245"), "Fiorenze Behne", new DateTime(2023, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Order_2023_1", 306.60000000000002 },
                    { new Guid("e6f372d0-a5f5-42b0-b3a8-71726f489f51"), "Dilly Grono", new DateTime(2022, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Order_2022_3", 390.0 },
                    { new Guid("f8a55368-f4f4-4ce8-a26e-4139fa9fa6bb"), "Lynea Middas", new DateTime(2023, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Order_2023_2", 1812.0 }
                });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "OrderItemID", "OrderID", "ProductName", "Quantity", "TotalPrice", "UnitPrice" },
                values: new object[,]
                {
                    { new Guid("10fcaeeb-9d0b-4078-be2e-224f08b1a62e"), new Guid("e6f372d0-a5f5-42b0-b3a8-71726f489f51"), "Syrup - Kahlua Chocolate", 9, 90.0, 10.0 },
                    { new Guid("12da5931-6b2d-40f5-8eb0-c6b568c07a7b"), new Guid("91f3d4de-2ae6-45ec-8f46-1966407403bd"), "Beef - Ground Lean Fresh", 4, 292.0, 73.0 },
                    { new Guid("1de377e6-aced-4991-9ca5-3159a50089a5"), new Guid("4a62dddc-8fdd-4aeb-96f5-a03311348293"), "Pepper - Cayenne", 7, 62.299999999999997, 8.9000000000000004 },
                    { new Guid("2aec3fc0-7ba2-4fb7-ad4c-609445e06eb1"), new Guid("f8a55368-f4f4-4ce8-a26e-4139fa9fa6bb"), "Puree - Raspberry", 4, 348.0, 87.0 },
                    { new Guid("2c809175-0472-4559-8e94-7b78bd4de652"), new Guid("f8a55368-f4f4-4ce8-a26e-4139fa9fa6bb"), "Wine - Masi Valpolocell", 5, 1390.0, 278.0 },
                    { new Guid("5170af9a-9eb9-4a11-99ce-0d346dc1fdef"), new Guid("a16409c9-d498-4469-b8f5-5b7348fb7034"), "Gelatine Leaves - Envelopes", 7, 94.5, 13.5 },
                    { new Guid("53f45ce3-08e5-4b30-bbf6-0ed736bcee80"), new Guid("7ad6b3ae-d67c-46f4-9561-f4cd129eca98"), "Blackberries", 3, 80.700000000000003, 26.899999999999999 },
                    { new Guid("58925077-d01c-4aaf-a4f8-bd574ab5f25e"), new Guid("91f3d4de-2ae6-45ec-8f46-1966407403bd"), "Beef Striploin Aaa", 4, 320.0, 80.0 },
                    { new Guid("67e8f4f0-f086-43b5-9d62-15e67a04292f"), new Guid("91f3d4de-2ae6-45ec-8f46-1966407403bd"), "Veal - Inside", 9, 585.0, 65.0 },
                    { new Guid("73fe9e15-2238-4689-8c43-11353a045ab7"), new Guid("538b01e3-4803-4e4a-9f3c-8ffdfa6092ab"), "Muffin Mix - Carrot", 7, 14.0, 2.0 },
                    { new Guid("7dfa2b06-62ae-4859-9b31-8bd328cc631f"), new Guid("c5cebf9d-8ca1-4f41-b85d-b2120f452245"), "Water - Spring 1.5lit", 10, 25.0, 2.5 },
                    { new Guid("80352826-a906-4ed7-b131-2a078cb102e6"), new Guid("c5cebf9d-8ca1-4f41-b85d-b2120f452245"), "Pork - Ham Hocks - Smoked", 8, 281.60000000000002, 35.200000000000003 },
                    { new Guid("86d99f15-4445-495d-9064-f4422caf8f7e"), new Guid("e6f372d0-a5f5-42b0-b3a8-71726f489f51"), "Myers Planters Punch", 2, 300.0, 150.0 },
                    { new Guid("88a37dbf-4c80-4aa2-aaa7-805ee8efd8e1"), new Guid("4a62dddc-8fdd-4aeb-96f5-a03311348293"), "Salmon - Atlantic, Fresh, Whole", 1, 175.0, 175.0 },
                    { new Guid("96f4866a-25c1-4a17-bbcb-96823976d1d3"), new Guid("f8a55368-f4f4-4ce8-a26e-4139fa9fa6bb"), "Rabbit - Frozen", 2, 74.0, 37.0 },
                    { new Guid("98ec3b95-7c84-4cc6-ac48-41c3ec15edba"), new Guid("7ad6b3ae-d67c-46f4-9561-f4cd129eca98"), "Potatoes - Idaho 80 Count", 18, 138.59999999999999, 7.7000000000000002 },
                    { new Guid("b6e117b2-da67-4e58-8cb3-6346b728823b"), new Guid("1be791b6-7578-4d2d-92b8-b4c9d5300dc1"), "Sprite - 355 Ml", 24, 40.799999999999997, 1.7 },
                    { new Guid("b8392c5d-65a4-4e9a-b74a-c202b996b19b"), new Guid("7ad6b3ae-d67c-46f4-9561-f4cd129eca98"), "Cheese - Havarti, Roasted Garlic", 2, 77.200000000000003, 38.600000000000001 },
                    { new Guid("b9bc4cde-9793-4ccd-b305-832cde69e720"), new Guid("4a62dddc-8fdd-4aeb-96f5-a03311348293"), "Snapple - Mango Maddness", 3, 173.09999999999999, 57.700000000000003 },
                    { new Guid("ceccc0f2-bbbc-47e0-ab96-17985290786d"), new Guid("7ad6b3ae-d67c-46f4-9561-f4cd129eca98"), "Truffle Cups - Red", 8, 289.60000000000002, 36.200000000000003 },
                    { new Guid("f31e87ab-aae4-40f0-8737-b0ed00d305f4"), new Guid("7ad6b3ae-d67c-46f4-9561-f4cd129eca98"), "Cheese - Cream Cheese", 4, 51.600000000000001, 12.9 },
                    { new Guid("f7f7814a-99bf-4ec8-a773-0115654bc2f4"), new Guid("4a62dddc-8fdd-4aeb-96f5-a03311348293"), "Tart Shells - Barquettes, Savory", 4, 678.0, 169.5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderID",
                table: "OrderItems",
                column: "OrderID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}
