using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Orders.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class Price_DoubleToDecimal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderID",
                table: "OrderItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Order");

            migrationBuilder.RenameTable(
                name: "OrderItems",
                newName: "OrderItem");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_OrderNumber",
                table: "Order",
                newName: "IX_Order_OrderNumber");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItems_OrderID",
                table: "OrderItem",
                newName: "IX_OrderItem_OrderID");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalAmount",
                table: "Order",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "OrderNumber",
                table: "Order",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "UnitPrice",
                table: "OrderItem",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPrice",
                table: "OrderItem",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                table: "OrderItem",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "OrderID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItem",
                table: "OrderItem",
                column: "OrderItemID");

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderID",
                keyValue: new Guid("1be791b6-7578-4d2d-92b8-b4c9d5300dc1"),
                column: "TotalAmount",
                value: 40.80m);

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderID",
                keyValue: new Guid("4a62dddc-8fdd-4aeb-96f5-a03311348293"),
                column: "TotalAmount",
                value: 1088.40m);

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderID",
                keyValue: new Guid("538b01e3-4803-4e4a-9f3c-8ffdfa6092ab"),
                column: "TotalAmount",
                value: 14m);

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderID",
                keyValue: new Guid("7ad6b3ae-d67c-46f4-9561-f4cd129eca98"),
                column: "TotalAmount",
                value: 637.70m);

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderID",
                keyValue: new Guid("91f3d4de-2ae6-45ec-8f46-1966407403bd"),
                column: "TotalAmount",
                value: 1197m);

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderID",
                keyValue: new Guid("a16409c9-d498-4469-b8f5-5b7348fb7034"),
                column: "TotalAmount",
                value: 94.50m);

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderID",
                keyValue: new Guid("c5cebf9d-8ca1-4f41-b85d-b2120f452245"),
                column: "TotalAmount",
                value: 306.60m);

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderID",
                keyValue: new Guid("e6f372d0-a5f5-42b0-b3a8-71726f489f51"),
                column: "TotalAmount",
                value: 390m);

            migrationBuilder.UpdateData(
                table: "Order",
                keyColumn: "OrderID",
                keyValue: new Guid("f8a55368-f4f4-4ce8-a26e-4139fa9fa6bb"),
                column: "TotalAmount",
                value: 1812m);

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemID",
                keyValue: new Guid("10fcaeeb-9d0b-4078-be2e-224f08b1a62e"),
                columns: new[] { "Quantity", "TotalPrice", "UnitPrice" },
                values: new object[] { 9m, 90m, 10m });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemID",
                keyValue: new Guid("12da5931-6b2d-40f5-8eb0-c6b568c07a7b"),
                columns: new[] { "Quantity", "TotalPrice", "UnitPrice" },
                values: new object[] { 4m, 292m, 73m });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemID",
                keyValue: new Guid("1de377e6-aced-4991-9ca5-3159a50089a5"),
                columns: new[] { "Quantity", "TotalPrice", "UnitPrice" },
                values: new object[] { 7m, 62.30m, 8.90m });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemID",
                keyValue: new Guid("2aec3fc0-7ba2-4fb7-ad4c-609445e06eb1"),
                columns: new[] { "Quantity", "TotalPrice", "UnitPrice" },
                values: new object[] { 4m, 348m, 87m });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemID",
                keyValue: new Guid("2c809175-0472-4559-8e94-7b78bd4de652"),
                columns: new[] { "Quantity", "TotalPrice", "UnitPrice" },
                values: new object[] { 5m, 1390m, 278m });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemID",
                keyValue: new Guid("5170af9a-9eb9-4a11-99ce-0d346dc1fdef"),
                columns: new[] { "Quantity", "TotalPrice", "UnitPrice" },
                values: new object[] { 7m, 94.50m, 13.50m });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemID",
                keyValue: new Guid("53f45ce3-08e5-4b30-bbf6-0ed736bcee80"),
                columns: new[] { "Quantity", "TotalPrice", "UnitPrice" },
                values: new object[] { 3m, 80.70m, 26.90m });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemID",
                keyValue: new Guid("58925077-d01c-4aaf-a4f8-bd574ab5f25e"),
                columns: new[] { "Quantity", "TotalPrice", "UnitPrice" },
                values: new object[] { 4m, 320m, 80m });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemID",
                keyValue: new Guid("67e8f4f0-f086-43b5-9d62-15e67a04292f"),
                columns: new[] { "Quantity", "TotalPrice", "UnitPrice" },
                values: new object[] { 9m, 585m, 65m });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemID",
                keyValue: new Guid("73fe9e15-2238-4689-8c43-11353a045ab7"),
                columns: new[] { "Quantity", "TotalPrice", "UnitPrice" },
                values: new object[] { 7m, 14m, 2m });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemID",
                keyValue: new Guid("7dfa2b06-62ae-4859-9b31-8bd328cc631f"),
                columns: new[] { "Quantity", "TotalPrice", "UnitPrice" },
                values: new object[] { 10m, 25m, 2.50m });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemID",
                keyValue: new Guid("80352826-a906-4ed7-b131-2a078cb102e6"),
                columns: new[] { "Quantity", "TotalPrice", "UnitPrice" },
                values: new object[] { 8m, 281.60m, 35.20m });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemID",
                keyValue: new Guid("86d99f15-4445-495d-9064-f4422caf8f7e"),
                columns: new[] { "Quantity", "TotalPrice", "UnitPrice" },
                values: new object[] { 2m, 300m, 150m });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemID",
                keyValue: new Guid("88a37dbf-4c80-4aa2-aaa7-805ee8efd8e1"),
                columns: new[] { "Quantity", "TotalPrice", "UnitPrice" },
                values: new object[] { 1m, 175m, 175m });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemID",
                keyValue: new Guid("96f4866a-25c1-4a17-bbcb-96823976d1d3"),
                columns: new[] { "Quantity", "TotalPrice", "UnitPrice" },
                values: new object[] { 2m, 74m, 37m });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemID",
                keyValue: new Guid("98ec3b95-7c84-4cc6-ac48-41c3ec15edba"),
                columns: new[] { "Quantity", "TotalPrice", "UnitPrice" },
                values: new object[] { 18m, 138.60m, 7.70m });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemID",
                keyValue: new Guid("b6e117b2-da67-4e58-8cb3-6346b728823b"),
                columns: new[] { "Quantity", "TotalPrice", "UnitPrice" },
                values: new object[] { 24m, 40.80m, 1.70m });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemID",
                keyValue: new Guid("b8392c5d-65a4-4e9a-b74a-c202b996b19b"),
                columns: new[] { "Quantity", "TotalPrice", "UnitPrice" },
                values: new object[] { 2m, 77.20m, 38.60m });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemID",
                keyValue: new Guid("b9bc4cde-9793-4ccd-b305-832cde69e720"),
                columns: new[] { "Quantity", "TotalPrice", "UnitPrice" },
                values: new object[] { 3m, 173.10m, 57.70m });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemID",
                keyValue: new Guid("ceccc0f2-bbbc-47e0-ab96-17985290786d"),
                columns: new[] { "Quantity", "TotalPrice", "UnitPrice" },
                values: new object[] { 8m, 289.60m, 36.20m });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemID",
                keyValue: new Guid("f31e87ab-aae4-40f0-8737-b0ed00d305f4"),
                columns: new[] { "Quantity", "TotalPrice", "UnitPrice" },
                values: new object[] { 4m, 51.60m, 12.90m });

            migrationBuilder.UpdateData(
                table: "OrderItem",
                keyColumn: "OrderItemID",
                keyValue: new Guid("f7f7814a-99bf-4ec8-a773-0115654bc2f4"),
                columns: new[] { "Quantity", "TotalPrice", "UnitPrice" },
                values: new object[] { 4m, 678m, 169.50m });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Order_OrderID",
                table: "OrderItem",
                column: "OrderID",
                principalTable: "Order",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Order_OrderID",
                table: "OrderItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderItem",
                table: "OrderItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.RenameTable(
                name: "OrderItem",
                newName: "OrderItems");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Orders");

            migrationBuilder.RenameIndex(
                name: "IX_OrderItem_OrderID",
                table: "OrderItems",
                newName: "IX_OrderItems_OrderID");

            migrationBuilder.RenameIndex(
                name: "IX_Order_OrderNumber",
                table: "Orders",
                newName: "IX_Orders_OrderNumber");

            migrationBuilder.AlterColumn<double>(
                name: "UnitPrice",
                table: "OrderItems",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "TotalPrice",
                table: "OrderItems",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "Quantity",
                table: "OrderItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "TotalAmount",
                table: "Orders",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "OrderNumber",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderItems",
                table: "OrderItems",
                column: "OrderItemID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "OrderID");

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "OrderItemID",
                keyValue: new Guid("10fcaeeb-9d0b-4078-be2e-224f08b1a62e"),
                columns: new[] { "Quantity", "TotalPrice", "UnitPrice" },
                values: new object[] { 9, 90.0, 10.0 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "OrderItemID",
                keyValue: new Guid("12da5931-6b2d-40f5-8eb0-c6b568c07a7b"),
                columns: new[] { "Quantity", "TotalPrice", "UnitPrice" },
                values: new object[] { 4, 292.0, 73.0 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "OrderItemID",
                keyValue: new Guid("1de377e6-aced-4991-9ca5-3159a50089a5"),
                columns: new[] { "Quantity", "TotalPrice", "UnitPrice" },
                values: new object[] { 7, 62.299999999999997, 8.9000000000000004 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "OrderItemID",
                keyValue: new Guid("2aec3fc0-7ba2-4fb7-ad4c-609445e06eb1"),
                columns: new[] { "Quantity", "TotalPrice", "UnitPrice" },
                values: new object[] { 4, 348.0, 87.0 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "OrderItemID",
                keyValue: new Guid("2c809175-0472-4559-8e94-7b78bd4de652"),
                columns: new[] { "Quantity", "TotalPrice", "UnitPrice" },
                values: new object[] { 5, 1390.0, 278.0 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "OrderItemID",
                keyValue: new Guid("5170af9a-9eb9-4a11-99ce-0d346dc1fdef"),
                columns: new[] { "Quantity", "TotalPrice", "UnitPrice" },
                values: new object[] { 7, 94.5, 13.5 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "OrderItemID",
                keyValue: new Guid("53f45ce3-08e5-4b30-bbf6-0ed736bcee80"),
                columns: new[] { "Quantity", "TotalPrice", "UnitPrice" },
                values: new object[] { 3, 80.700000000000003, 26.899999999999999 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "OrderItemID",
                keyValue: new Guid("58925077-d01c-4aaf-a4f8-bd574ab5f25e"),
                columns: new[] { "Quantity", "TotalPrice", "UnitPrice" },
                values: new object[] { 4, 320.0, 80.0 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "OrderItemID",
                keyValue: new Guid("67e8f4f0-f086-43b5-9d62-15e67a04292f"),
                columns: new[] { "Quantity", "TotalPrice", "UnitPrice" },
                values: new object[] { 9, 585.0, 65.0 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "OrderItemID",
                keyValue: new Guid("73fe9e15-2238-4689-8c43-11353a045ab7"),
                columns: new[] { "Quantity", "TotalPrice", "UnitPrice" },
                values: new object[] { 7, 14.0, 2.0 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "OrderItemID",
                keyValue: new Guid("7dfa2b06-62ae-4859-9b31-8bd328cc631f"),
                columns: new[] { "Quantity", "TotalPrice", "UnitPrice" },
                values: new object[] { 10, 25.0, 2.5 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "OrderItemID",
                keyValue: new Guid("80352826-a906-4ed7-b131-2a078cb102e6"),
                columns: new[] { "Quantity", "TotalPrice", "UnitPrice" },
                values: new object[] { 8, 281.60000000000002, 35.200000000000003 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "OrderItemID",
                keyValue: new Guid("86d99f15-4445-495d-9064-f4422caf8f7e"),
                columns: new[] { "Quantity", "TotalPrice", "UnitPrice" },
                values: new object[] { 2, 300.0, 150.0 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "OrderItemID",
                keyValue: new Guid("88a37dbf-4c80-4aa2-aaa7-805ee8efd8e1"),
                columns: new[] { "Quantity", "TotalPrice", "UnitPrice" },
                values: new object[] { 1, 175.0, 175.0 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "OrderItemID",
                keyValue: new Guid("96f4866a-25c1-4a17-bbcb-96823976d1d3"),
                columns: new[] { "Quantity", "TotalPrice", "UnitPrice" },
                values: new object[] { 2, 74.0, 37.0 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "OrderItemID",
                keyValue: new Guid("98ec3b95-7c84-4cc6-ac48-41c3ec15edba"),
                columns: new[] { "Quantity", "TotalPrice", "UnitPrice" },
                values: new object[] { 18, 138.59999999999999, 7.7000000000000002 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "OrderItemID",
                keyValue: new Guid("b6e117b2-da67-4e58-8cb3-6346b728823b"),
                columns: new[] { "Quantity", "TotalPrice", "UnitPrice" },
                values: new object[] { 24, 40.799999999999997, 1.7 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "OrderItemID",
                keyValue: new Guid("b8392c5d-65a4-4e9a-b74a-c202b996b19b"),
                columns: new[] { "Quantity", "TotalPrice", "UnitPrice" },
                values: new object[] { 2, 77.200000000000003, 38.600000000000001 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "OrderItemID",
                keyValue: new Guid("b9bc4cde-9793-4ccd-b305-832cde69e720"),
                columns: new[] { "Quantity", "TotalPrice", "UnitPrice" },
                values: new object[] { 3, 173.09999999999999, 57.700000000000003 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "OrderItemID",
                keyValue: new Guid("ceccc0f2-bbbc-47e0-ab96-17985290786d"),
                columns: new[] { "Quantity", "TotalPrice", "UnitPrice" },
                values: new object[] { 8, 289.60000000000002, 36.200000000000003 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "OrderItemID",
                keyValue: new Guid("f31e87ab-aae4-40f0-8737-b0ed00d305f4"),
                columns: new[] { "Quantity", "TotalPrice", "UnitPrice" },
                values: new object[] { 4, 51.600000000000001, 12.9 });

            migrationBuilder.UpdateData(
                table: "OrderItems",
                keyColumn: "OrderItemID",
                keyValue: new Guid("f7f7814a-99bf-4ec8-a773-0115654bc2f4"),
                columns: new[] { "Quantity", "TotalPrice", "UnitPrice" },
                values: new object[] { 4, 678.0, 169.5 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: new Guid("1be791b6-7578-4d2d-92b8-b4c9d5300dc1"),
                column: "TotalAmount",
                value: 40.799999999999997);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: new Guid("4a62dddc-8fdd-4aeb-96f5-a03311348293"),
                column: "TotalAmount",
                value: 1088.4000000000001);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: new Guid("538b01e3-4803-4e4a-9f3c-8ffdfa6092ab"),
                column: "TotalAmount",
                value: 14.0);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: new Guid("7ad6b3ae-d67c-46f4-9561-f4cd129eca98"),
                column: "TotalAmount",
                value: 637.70000000000005);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: new Guid("91f3d4de-2ae6-45ec-8f46-1966407403bd"),
                column: "TotalAmount",
                value: 1197.0);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: new Guid("a16409c9-d498-4469-b8f5-5b7348fb7034"),
                column: "TotalAmount",
                value: 94.5);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: new Guid("c5cebf9d-8ca1-4f41-b85d-b2120f452245"),
                column: "TotalAmount",
                value: 306.60000000000002);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: new Guid("e6f372d0-a5f5-42b0-b3a8-71726f489f51"),
                column: "TotalAmount",
                value: 390.0);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: new Guid("f8a55368-f4f4-4ce8-a26e-4139fa9fa6bb"),
                column: "TotalAmount",
                value: 1812.0);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderID",
                table: "OrderItems",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
