using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class StudentAttendanceChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClassId",
                table: "StudentAttendances");

            migrationBuilder.DropColumn(
                name: "StaffId",
                table: "StudentAttendances");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "StudentAttendances",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DivisionId",
                table: "StudentAttendances",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StandardId",
                table: "StudentAttendances",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "StudentAttendances",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StandardId",
                table: "StudentAttendances");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "StudentAttendances");

            migrationBuilder.AlterColumn<int>(
                name: "StudentId",
                table: "StudentAttendances",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DivisionId",
                table: "StudentAttendances",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ClassId",
                table: "StudentAttendances",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StaffId",
                table: "StudentAttendances",
                type: "int",
                nullable: true);
        }
    }
}
