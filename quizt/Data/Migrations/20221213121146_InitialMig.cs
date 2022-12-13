using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace quizt.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "onlineexam",
                columns: table => new
                {
                    Qid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    option1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    option2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    option3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    option4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correctans = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_onlineexam", x => x.Qid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "onlineexam");
        }
    }
}
