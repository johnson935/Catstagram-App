using Microsoft.EntityFrameworkCore.Migrations;

namespace Catstagram.Server.Data.Migrations
{
    public partial class UserProfiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 40, nullable: true),
                    ProfilePhotoUrl = table.Column<string>(nullable: true),
                    WebSite = table.Column<string>(nullable: true),
                    Biography = table.Column<string>(maxLength: 150, nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    IsPrivate = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Profiles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
