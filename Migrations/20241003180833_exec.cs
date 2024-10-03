using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PeopleInterest.Migrations
{
    /// <inheritdoc />
    public partial class exec : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InterestLinks_PersonInterests_PersonInterestPersonId_PersonInterestInterestId",
                table: "InterestLinks");

            migrationBuilder.DropForeignKey(
                name: "FK_InterestLinks_Persons_PersonId",
                table: "InterestLinks");

            migrationBuilder.DropIndex(
                name: "IX_InterestLinks_PersonId",
                table: "InterestLinks");

            migrationBuilder.DropIndex(
                name: "IX_InterestLinks_PersonInterestPersonId_PersonInterestInterestId",
                table: "InterestLinks");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "InterestLinks");

            migrationBuilder.DropColumn(
                name: "PersonInterestInterestId",
                table: "InterestLinks");

            migrationBuilder.DropColumn(
                name: "PersonInterestPersonId",
                table: "InterestLinks");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "InterestLinks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonInterestInterestId",
                table: "InterestLinks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PersonInterestPersonId",
                table: "InterestLinks",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "InterestLinks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PersonId", "PersonInterestInterestId", "PersonInterestPersonId" },
                values: new object[] { 1, null, null });

            migrationBuilder.UpdateData(
                table: "InterestLinks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PersonId", "PersonInterestInterestId", "PersonInterestPersonId" },
                values: new object[] { 1, null, null });

            migrationBuilder.UpdateData(
                table: "InterestLinks",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "PersonId", "PersonInterestInterestId", "PersonInterestPersonId" },
                values: new object[] { 2, null, null });

            migrationBuilder.UpdateData(
                table: "InterestLinks",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "PersonId", "PersonInterestInterestId", "PersonInterestPersonId" },
                values: new object[] { 2, null, null });

            migrationBuilder.UpdateData(
                table: "InterestLinks",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "PersonId", "PersonInterestInterestId", "PersonInterestPersonId" },
                values: new object[] { 3, null, null });

            migrationBuilder.CreateIndex(
                name: "IX_InterestLinks_PersonId",
                table: "InterestLinks",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_InterestLinks_PersonInterestPersonId_PersonInterestInterestId",
                table: "InterestLinks",
                columns: new[] { "PersonInterestPersonId", "PersonInterestInterestId" });

            migrationBuilder.AddForeignKey(
                name: "FK_InterestLinks_PersonInterests_PersonInterestPersonId_PersonInterestInterestId",
                table: "InterestLinks",
                columns: new[] { "PersonInterestPersonId", "PersonInterestInterestId" },
                principalTable: "PersonInterests",
                principalColumns: new[] { "PersonId", "InterestId" });

            migrationBuilder.AddForeignKey(
                name: "FK_InterestLinks_Persons_PersonId",
                table: "InterestLinks",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
