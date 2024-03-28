using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class staff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AlterColumn<string>(
            //    name: "description",
            //    table: "TimeTableManagement",
            //    type: "nvarchar(max)",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)");

            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "ToTime",
            //    table: "TimeTableManagement",
            //    type: "datetime2",
            //    nullable: true,
            //    oldClrType: typeof(DateTime),
            //    oldType: "datetime2");

            //migrationBuilder.AlterColumn<string>(
            //    name: "TimeTableName",
            //    table: "TimeTableManagement",
            //    type: "nvarchar(max)",
            //    nullable: true,
            //    oldClrType: typeof(string),
            //    oldType: "nvarchar(max)");

            //migrationBuilder.AlterColumn<long>(
            //    name: "TeacherId",
            //    table: "TimeTableManagement",
            //    type: "bigint",
            //    nullable: true,
            //    oldClrType: typeof(long),
            //    oldType: "bigint");

            //migrationBuilder.AlterColumn<long>(
            //    name: "SubjectId",
            //    table: "TimeTableManagement",
            //    type: "bigint",
            //    nullable: true,
            //    oldClrType: typeof(long),
            //    oldType: "bigint");

            //migrationBuilder.AlterColumn<long>(
            //    name: "StandardId",
            //    table: "TimeTableManagement",
            //    type: "bigint",
            //    nullable: true,
            //    oldClrType: typeof(long),
            //    oldType: "bigint");

            //migrationBuilder.AlterColumn<DateTime>(
            //    name: "FromTime",
            //    table: "TimeTableManagement",
            //    type: "datetime2",
            //    nullable: true,
            //    oldClrType: typeof(DateTime),
            //    oldType: "datetime2");

            //migrationBuilder.AlterColumn<int>(
            //    name: "DurationOfLecture",
            //    table: "TimeTableManagement",
            //    type: "int",
            //    nullable: true,
            //    oldClrType: typeof(int),
            //    oldType: "int");

            //migrationBuilder.AddColumn<string>(
            //    name: "Day",
            //    table: "TimeTableManagement",
            //    type: "nvarchar(max)",
            //    nullable: true);

            //migrationBuilder.AddColumn<bool>(
            //    name: "isActive",
            //    table: "TimeTableManagement",
            //    type: "bit",
            //    nullable: true);

            migrationBuilder.CreateTable(
                name: "StaffAttendance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StaffId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    Day = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isPresent = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffAttendance", x => x.Id);
                });
        }

        /// <inheritdoc />
    //    protected override void Down(MigrationBuilder migrationBuilder)
    //    {
    //        migrationBuilder.DropTable(
    //            name: "StaffAttendance");

    //        migrationBuilder.DropColumn(
    //            name: "Day",
    //            table: "TimeTableManagement");

    //        migrationBuilder.DropColumn(
    //            name: "isActive",
    //            table: "TimeTableManagement");

    //        migrationBuilder.AlterColumn<string>(
    //            name: "description",
    //            table: "TimeTableManagement",
    //            type: "nvarchar(max)",
    //            nullable: false,
    //            defaultValue: "",
    //            oldClrType: typeof(string),
    //            oldType: "nvarchar(max)",
    //            oldNullable: true);

    //        migrationBuilder.AlterColumn<DateTime>(
    //            name: "ToTime",
    //            table: "TimeTableManagement",
    //            type: "datetime2",
    //            nullable: false,
    //            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
    //            oldClrType: typeof(DateTime),
    //            oldType: "datetime2",
    //            oldNullable: true);

    //        migrationBuilder.AlterColumn<string>(
    //            name: "TimeTableName",
    //            table: "TimeTableManagement",
    //            type: "nvarchar(max)",
    //            nullable: false,
    //            defaultValue: "",
    //            oldClrType: typeof(string),
    //            oldType: "nvarchar(max)",
    //            oldNullable: true);

    //        migrationBuilder.AlterColumn<long>(
    //            name: "TeacherId",
    //            table: "TimeTableManagement",
    //            type: "bigint",
    //            nullable: false,
    //            defaultValue: 0L,
    //            oldClrType: typeof(long),
    //            oldType: "bigint",
    //            oldNullable: true);

    //        migrationBuilder.AlterColumn<long>(
    //            name: "SubjectId",
    //            table: "TimeTableManagement",
    //            type: "bigint",
    //            nullable: false,
    //            defaultValue: 0L,
    //            oldClrType: typeof(long),
    //            oldType: "bigint",
    //            oldNullable: true);

    //        migrationBuilder.AlterColumn<long>(
    //            name: "StandardId",
    //            table: "TimeTableManagement",
    //            type: "bigint",
    //            nullable: false,
    //            defaultValue: 0L,
    //            oldClrType: typeof(long),
    //            oldType: "bigint",
    //            oldNullable: true);

    //        migrationBuilder.AlterColumn<DateTime>(
    //            name: "FromTime",
    //            table: "TimeTableManagement",
    //            type: "datetime2",
    //            nullable: false,
    //            defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
    //            oldClrType: typeof(DateTime),
    //            oldType: "datetime2",
    //            oldNullable: true);

    //        migrationBuilder.AlterColumn<int>(
    //            name: "DurationOfLecture",
    //            table: "TimeTableManagement",
    //            type: "int",
    //            nullable: false,
    //            defaultValue: 0,
    //            oldClrType: typeof(int),
    //            oldType: "int",
    //            oldNullable: true);
    //    }
    }
}
