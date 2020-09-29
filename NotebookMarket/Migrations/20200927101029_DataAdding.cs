using Microsoft.EntityFrameworkCore.Migrations;

namespace NotebookMarket.Migrations
{
    public partial class DataAdding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Laptops",
                columns: table => new
                {
                    LaptopId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(nullable: true),
                    ShortDescription = table.Column<string>(nullable: true),
                    LongDescription = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    OnDiscount = table.Column<bool>(nullable: false),
                    Available = table.Column<bool>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Laptops", x => x.LaptopId);
                    table.ForeignKey(
                        name: "FK_Laptops_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartItems",
                columns: table => new
                {
                    ShoppingCartItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LaptopId = table.Column<int>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    ShoppingCartId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItems", x => x.ShoppingCartItemId);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_Laptops_LaptopId",
                        column: x => x.LaptopId,
                        principalTable: "Laptops",
                        principalColumn: "LaptopId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "Description" },
                values: new object[] { 1, "Для навчання", null });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "Description" },
                values: new object[] { 2, "Ультратонкі", null });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "Description" },
                values: new object[] { 3, "Геймерські", null });

            migrationBuilder.InsertData(
                table: "Laptops",
                columns: new[] { "LaptopId", "Available", "CategoryId", "ImageUrl", "LongDescription", "Model", "OnDiscount", "Price", "ShortDescription" },
                values: new object[] { 3, true, 1, "https://brain.com.ua/static/images/prod_img/4/4/U0443644_big.jpg", "Серія (модельний ряд): ASUS Zenbook; Тип ноутбуку: Бізнеc; Діагональ дисплея: 13.3 FullHD(1920 х 1080) IPS; Процесор 10 - th generation Intel Core i5 10210U(1.6 - 4.2 ГГц); Кількість ядер: 4; Оперативна пам'ять: 8 ГБ; Об'єм SSD: 512 ГБ; No ODD; Відеокарта: NVIDIA GeForce MX250; Об'єм вбудованої відеопам'яті: 2 ГБ; Бездротові технології: Bluetooth, Wi - Fi; Інтерфейси та підключення: 1 х USB 2.0, USB 3.2 Type - C, 1 х USB 3.2, HDMI, Комбінований аудіороз'єм; Програмне забезпечення: Windows 10 Home; Особливості: підсвітка клавіатури;Фізичні характеристики: Ширина - 302 мм, Висота - 18 мм, Глибина - 189 мм, Вага - 1.19 кг, Колір - синій.", "НОУТБУК ASUS ZENBOOK UX334FLC-A3108T", true, 30999m, "Asus ZenBook UX334FLC – неперевершена краса, яка закута у корпус з фантастичною обробкою." });

            migrationBuilder.InsertData(
                table: "Laptops",
                columns: new[] { "LaptopId", "Available", "CategoryId", "ImageUrl", "LongDescription", "Model", "OnDiscount", "Price", "ShortDescription" },
                values: new object[] { 2, true, 2, "https://brain.com.ua/static/images/prod_img/7/2/U0465272_big.jpg", "Серія (модельний ряд): ThinkPad; Тип ноутбуку: Ультратонкий; Діагональ дисплея: 13.3 FullHD(1920 х 1080) IPS; Процесор 10 - th generation Intel Core i5 10210U(1.6 - 4.2 ГГц); Кількість ядер: 4; Оперативна пам'ять: 16 ГБ; Об'єм SSD: 512 ГБ; No ODD; Відеокарта: Intel UHD Graphics 620; Об'єм вбудованої відеопам'яті: 2 ГБ; Бездротові технології: Bluetooth, Wi - Fi; Інтерфейси та підключення: 1 х USB 2.0, USB 3.2 Type - C, 1 х USB 3.2, HDMI, Комбінований аудіороз'єм; Програмне забезпечення: Windows 10 Home; Особливості: підсвітка клавіатури;Фізичні характеристики: Ширина - 302 мм, Висота - 18 мм, Глибина - 189 мм, Вага - 1.25 кг, Колір - чорний.", "НОУТБУК LENOVO THINKPAD X13 YOGA", true, 60300m, "Надійність, потужність, мультирежимність притаманні Lenovo ThinkPad X13 YOGA " });

            migrationBuilder.InsertData(
                table: "Laptops",
                columns: new[] { "LaptopId", "Available", "CategoryId", "ImageUrl", "LongDescription", "Model", "OnDiscount", "Price", "ShortDescription" },
                values: new object[] { 1, true, 3, "https://brain.com.ua/static/images/prod_img/3/7/U0371137_big.jpg", "Серія (модельний ряд): L340 Gaming; Тип ноутбуку: Ігровий; Діагональ дисплея: 15.6 FullHD(1920 х 1080) IPS; Процесор 9 - th generation Intel Core i5 9300H(1.6 - 4.1 ГГц); Кількість ядер: 4; Оперативна пам'ять: 8 ГБ; Об'єм SSD: 512 ГБ; No ODD; Відеокарта: NVIDIA GeForce GTX1050; Об'єм вбудованої відеопам'яті: 3 ГБ; Бездротові технології: Bluetooth, Wi - Fi; Інтерфейси та підключення: 1 х USB 2.0, USB 3.2 Type - C, 1 х USB 3.2, HDMI, Комбінований аудіороз'єм; Програмне забезпечення: Windows 10 Home; Особливості: підсвітка клавіатури; Фізичні характеристики: Ширина - 302 мм, Висота - 18 мм, Глибина - 189 мм, Вага - 2.2 кг, Колір - синій.", "НОУТБУК LENOVO IdeaPad L340-15IRH Gaming", true, 21000m, "IdeaPad L340 Gaming - ігровий ноутбук,який поєднує в собі портативність і продуктивність для забезпечення кращого досвіду геймінгу у будь - якому місці. " });

            migrationBuilder.CreateIndex(
                name: "IX_Laptops_CategoryId",
                table: "Laptops",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_LaptopId",
                table: "ShoppingCartItems",
                column: "LaptopId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingCartItems");

            migrationBuilder.DropTable(
                name: "Laptops");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
