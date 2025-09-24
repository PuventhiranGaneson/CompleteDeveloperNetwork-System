using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CompleteDeveloperNetwork_System.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "developers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_developers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hobbies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeveloperId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hobbies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hobbies_developers_DeveloperId",
                        column: x => x.DeveloperId,
                        principalTable: "developers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Skillsets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeveloperId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skillsets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Skillsets_developers_DeveloperId",
                        column: x => x.DeveloperId,
                        principalTable: "developers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "developers",
                columns: new[] { "Id", "Email", "PhoneNumber", "Username" },
                values: new object[,]
                {
                    { 1, "alice@example.com", "0123456789", "alice_dev" },
                    { 2, "bob@example.com", "0198765432", "bob_coder" },
                    { 3, "charlie@example.com", "0182222333", "charlie_pro" }
                });

            migrationBuilder.InsertData(
                table: "Hobbies",
                columns: new[] { "Id", "Description", "DeveloperId", "Name" },
                values: new object[,]
                {
                    { 1, "Weekend rides", 1, "Cycling" },
                    { 2, "FPS games", 1, "Gaming" },
                    { 3, "Landscape photography", 2, "Photography" },
                    { 4, "Trying new recipes", 2, "Cooking" },
                    { 5, "Exploring new places", 3, "Traveling" }
                });

            migrationBuilder.InsertData(
                table: "Skillsets",
                columns: new[] { "Id", "Description", "DeveloperId", "Name" },
                values: new object[,]
                {
                    { 1, "Backend development", 1, "C#" },
                    { 2, "Frontend development", 1, "React" },
                    { 3, "AI/ML coding", 2, "Python" },
                    { 4, "Database management", 2, "SQL" },
                    { 5, "Enterprise systems", 3, "Java" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hobbies_DeveloperId",
                table: "Hobbies",
                column: "DeveloperId");

            migrationBuilder.CreateIndex(
                name: "IX_Skillsets_DeveloperId",
                table: "Skillsets",
                column: "DeveloperId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hobbies");

            migrationBuilder.DropTable(
                name: "Skillsets");

            migrationBuilder.DropTable(
                name: "developers");
        }
    }
}
