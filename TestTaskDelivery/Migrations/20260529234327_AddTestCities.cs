using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestTaskDelivery.Migrations
{
    /// <inheritdoc />
    public partial class AddTestCities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "NameNormalized" },
                values: new object[] { "Московский", "МОСКОВСКИЙ" });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "NameNormalized" },
                values: new object[] { "Москворечье", "МОСКВОРЕЧЬЕ" });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Name", "NameNormalized" },
                values: new object[] { "Санкт-Петербург", "САНКТ-ПЕТЕРБУРГ" });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Name", "NameNormalized" },
                values: new object[] { "Петергоф", "ПЕТЕРГОФ" });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Name", "NameNormalized" },
                values: new object[] { "Новосибирск", "НОВОСИБИРСК" });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Name", "NameNormalized" },
                values: new object[] { "Сибирский", "СИБИРСКИЙ" });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Name", "NameNormalized" },
                values: new object[] { "Казань", "КАЗАНЬ" });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Name", "NameNormalized" },
                values: new object[] { "Казанка", "КАЗАНКА" });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Name", "NameNormalized" },
                values: new object[] { "Ростов-на-Дону", "РОСТОВ-НА-ДОНУ" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "Name", "NameNormalized" },
                values: new object[,]
                {
                    { 11, "Ростов Великий", "РОСТОВ ВЕЛИКИЙ" },
                    { 12, "Краснодар", "КРАСНОДАР" },
                    { 13, "Красноярск", "КРАСНОЯРСК" },
                    { 14, "Владивосток", "ВЛАДИВОСТОК" },
                    { 15, "Владимир", "ВЛАДИМИР" },
                    { 16, "Волгоград", "ВОЛГОГРАД" },
                    { 17, "Вологда", "ВОЛОГДА" },
                    { 18, "Воронеж", "ВОРОНЕЖ" },
                    { 19, "Екатеринбург", "ЕКАТЕРИНБУРГ" },
                    { 20, "Екатериновка", "ЕКАТЕРИНОВКА" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Name", "NameNormalized" },
                values: new object[] { "Санкт-Петербург", "САНКТ-ПЕТЕРБУРГ" });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Name", "NameNormalized" },
                values: new object[] { "Новосибирск", "НОВОСИБИРСК" });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Name", "NameNormalized" },
                values: new object[] { "Екатеринбург", "ЕКАТЕРИНБУРГ" });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Name", "NameNormalized" },
                values: new object[] { "Казань", "КАЗАНЬ" });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Name", "NameNormalized" },
                values: new object[] { "Нижний Новгород", "НИЖНИЙ НОВГОРОД" });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Name", "NameNormalized" },
                values: new object[] { "Челябинск", "ЧЕЛЯБИНСК" });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Name", "NameNormalized" },
                values: new object[] { "Омск", "ОМСК" });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Name", "NameNormalized" },
                values: new object[] { "Ростов-на-Дону", "РОСТОВ-НА-ДОНУ" });

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Name", "NameNormalized" },
                values: new object[] { "Уфа", "УФА" });
        }
    }
}
