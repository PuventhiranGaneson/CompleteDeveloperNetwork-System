using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CompleteDeveloperNetwork_System.Migrations
{
    /// <inheritdoc />
    public partial class Updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hobbies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hobbies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hobbies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Hobbies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Hobbies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Skillsets",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Skillsets",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Skillsets",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Skillsets",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Skillsets",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "developers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "developers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "developers",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
