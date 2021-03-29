using Microsoft.EntityFrameworkCore.Migrations;

namespace HurManager.Dal.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "House",
                columns: table => new
                {
                    HouseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_House", x => x.HouseId);
                });

            migrationBuilder.CreateTable(
                name: "WaterMeter",
                columns: table => new
                {
                    WaterMeterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FactoryNumber = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Reading = table.Column<int>(type: "int", nullable: false),
                    HouseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaterMeter", x => x.WaterMeterId);
                    table.ForeignKey(
                        name: "FK_WaterMeter_House_HouseId",
                        column: x => x.HouseId,
                        principalTable: "House",
                        principalColumn: "HouseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "House",
                columns: new[] { "HouseId", "Address" },
                values: new object[,]
                {
                    { 1, "2094 Arrowood Drive" },
                    { 2, "421 Oakwood Avenue" },
                    { 3, "4927 Stoneybrook Road" },
                    { 4, "2144 College View" },
                    { 5, "2568 Stone Lane" },
                    { 6, "3465 Worley Avenue" },
                    { 7, "5003 Hidden Valley Road" },
                    { 8, "2022 Karen Lane" },
                    { 9, "2905 Crestview Terrace" },
                    { 10, "567 Upton Avenue" }
                });

            migrationBuilder.InsertData(
                table: "WaterMeter",
                columns: new[] { "WaterMeterId", "FactoryNumber", "HouseId", "Reading" },
                values: new object[,]
                {
                    { 1, "A701959", 1, 2649 },
                    { 2, "B176459", 2, 6754 },
                    { 3, "C057998", 3, 4582 },
                    { 4, "A297539", 4, 4868 },
                    { 5, "N934471", 5, 8796 },
                    { 6, "Z435565", 6, 2910 },
                    { 7, "A199350", 7, 3338 },
                    { 8, "Z347827", 8, 3183 },
                    { 9, "Q481678", 9, 5930 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_House_Address",
                table: "House",
                column: "Address",
                unique: true,
                filter: "[Address] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_WaterMeter_FactoryNumber",
                table: "WaterMeter",
                column: "FactoryNumber",
                unique: true,
                filter: "[FactoryNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_WaterMeter_HouseId",
                table: "WaterMeter",
                column: "HouseId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WaterMeter");

            migrationBuilder.DropTable(
                name: "House");
        }
    }
}
