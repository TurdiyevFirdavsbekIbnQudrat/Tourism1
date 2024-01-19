using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tourism.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class adminConfAddedsassd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Admin",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ism = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    familiya = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    parol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Fikr",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    foydalanuvchiFikr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    foydalanuvchiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fikr", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Foydalanuvchi",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ism = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    familiya = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    parol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    role = table.Column<int>(type: "int", nullable: false),
                    telNomer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    condition = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foydalanuvchi", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Shahar",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    rasm = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shahar", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Tolov",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tolovQiymati = table.Column<double>(type: "float", nullable: false),
                    foydalanuvchiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tolov", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "FoydalanuvchiVaShahar",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    shaharId = table.Column<int>(type: "int", nullable: false),
                    foydalanuvchiId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoydalanuvchiVaShahar", x => x.id);
                    table.ForeignKey(
                        name: "FK_FoydalanuvchiVaShahar_Foydalanuvchi_foydalanuvchiId",
                        column: x => x.foydalanuvchiId,
                        principalSchema: "dbo",
                        principalTable: "Foydalanuvchi",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoydalanuvchiVaShahar_Shahar_shaharId",
                        column: x => x.shaharId,
                        principalSchema: "dbo",
                        principalTable: "Shahar",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Xizmatlar",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    narxi = table.Column<int>(type: "int", nullable: false),
                    rasm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    boshlanishVaqti = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    tugashVaqti = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    haqida = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    kun = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    shaharId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Xizmatlar", x => x.id);
                    table.ForeignKey(
                        name: "FK_Xizmatlar_Shahar_shaharId",
                        column: x => x.shaharId,
                        principalSchema: "dbo",
                        principalTable: "Shahar",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Admin",
                columns: new[] { "id", "email", "familiya", "ism", "parol" },
                values: new object[] { 1, "admin@gmail.com", "Turdiyev", "Firdavsbek", "12345678" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Foydalanuvchi",
                columns: new[] { "id", "condition", "email", "familiya", "ism", "parol", "role", "telNomer" },
                values: new object[,]
                {
                    { 1, 0, "Firdavs@gmail.com", "Turdiyev", "Firdavs", "12345678", 0, "+998948663667" },
                    { 2, 0, "Quvvat@gmail.com", "Turdiyev", "Quvvat", "12345678", 0, "+998978683661" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FoydalanuvchiVaShahar_foydalanuvchiId",
                schema: "dbo",
                table: "FoydalanuvchiVaShahar",
                column: "foydalanuvchiId");

            migrationBuilder.CreateIndex(
                name: "IX_FoydalanuvchiVaShahar_shaharId",
                schema: "dbo",
                table: "FoydalanuvchiVaShahar",
                column: "shaharId");

            migrationBuilder.CreateIndex(
                name: "IX_Xizmatlar_shaharId",
                schema: "dbo",
                table: "Xizmatlar",
                column: "shaharId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Fikr",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "FoydalanuvchiVaShahar",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Tolov",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Xizmatlar",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Foydalanuvchi",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Shahar",
                schema: "dbo");
        }
    }
}
