using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DevBloggie.Web.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class ChangeadmintoAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a0ed22a9-9311-4378-8de2-90ce364b89ff",
                column: "Name",
                value: "Admin");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "50758e37-5fef-462b-8178-c05617a81646",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ea23eae1-831c-4e31-868c-93d09d36f3f5", "AQAAAAIAAYagAAAAEADGJ1dy8hetG5VR45hgr4/R5gby3OgC3lPB7j14sW73V2q4RxDEetM8p9nzw9Aq4w==", "05832aec-2e1f-4b0d-b671-fbbb1db6ae33" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a0ed22a9-9311-4378-8de2-90ce364b89ff",
                columns: new[] { "Name", "NormalizedName" },
                values: new object[] { "admin", "admin" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "50758e37-5fef-462b-8178-c05617a81646",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1b5e5376-4b88-43f9-8e49-3e15b220f135", "AQAAAAIAAYagAAAAEBGZOkSmASxAAlbMl4eJ7mUuq495TDlPXLLvKSibgsfD6JXd96mOONwYArqrHn7NuQ==", "f7f300bb-49ac-4323-9844-cd61df87d49d" });
        }
    }
}
