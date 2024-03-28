using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AlterColumn<byte[]>(
            //name: "photo",
            //table: "Students",
            //type: "varbinary(max)",
            //nullable: true,
            //oldClrType: typeof(byte[]),
            //oldType: "varbinary(max)");

            //migrationBuilder.AddColumn<string>(
            //    name: "AadhaarNumber",
            //    table: "Students",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    defaultValue: "");

            //migrationBuilder.AddColumn<byte[]>(
            //    name: "AadhaarPhoto",
            //    table: "Students",
            //    type: "varbinary(max)",
            //    nullable: true);

            //migrationBuilder.AddColumn<string>(
            //    name: "FatherContact",
            //    table: "Students",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    defaultValue: "");

            //migrationBuilder.AddColumn<string>(
            //    name: "FatherEmail",
            //    table: "Students",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    defaultValue: "");

            //migrationBuilder.AddColumn<string>(
            //    name: "FatherName",
            //    table: "Students",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    defaultValue: "");

            //migrationBuilder.AddColumn<string>(
            //    name: "GuardianContact",
            //    table: "Students",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    defaultValue: "");

            //migrationBuilder.AddColumn<string>(
            //    name: "GuardianEmail",
            //    table: "Students",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    defaultValue: "");

            //migrationBuilder.AddColumn<string>(
            //    name: "GuardianName",
            //    table: "Students",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    defaultValue: "");

            //migrationBuilder.AddColumn<string>(
            //    name: "MotherContact",
            //    table: "Students",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    defaultValue: "");

            //migrationBuilder.AddColumn<string>(
            //    name: "MotherEmail",
            //    table: "Students",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    defaultValue: "");

            //migrationBuilder.AddColumn<string>(
            //    name: "MotherName",
            //    table: "Students",
            //    type: "nvarchar(max)",
            //    nullable: false,
            //    defaultValue: "");

            //migrationBuilder.CreateTable(
            //    name: "AttendanceReport",
            //    columns: table => new
            //    {
            //        StudentId = table.Column<int>(type: "int", nullable: false),
            //        ClassId = table.Column<int>(type: "int", nullable: false),
            //        DivisionId = table.Column<int>(type: "int", nullable: false),
            //        UserId = table.Column<int>(type: "int", nullable: false),
            //        Date = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        isPresent = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //    });

            migrationBuilder.CreateTable(
                name: "TimeTableManagement",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StandardId = table.Column<long>(type: "bigint", nullable: false),
                    TeacherId = table.Column<long>(type: "bigint", nullable: false),
                    SubjectId = table.Column<long>(type: "bigint", nullable: false),
                    FromTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DurationOfLecture = table.Column<int>(type: "int", nullable: false),
                    TimeTableName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeTableManagement", x => x.Id);
                });
        }

        /// <inheritdoc />
        //protected override void Down(MigrationBuilder migrationBuilder)
        //{
        //    migrationBuilder.DropTable(
        //        name: "AttendanceReport");

        //    migrationBuilder.DropTable(
        //        name: "TimeTableManagement");

        //    migrationBuilder.DropColumn(
        //        name: "AadhaarNumber",
        //        table: "Students");

        //    migrationBuilder.DropColumn(
        //        name: "AadhaarPhoto",
        //        table: "Students");

        //    migrationBuilder.DropColumn(
        //        name: "FatherContact",
        //        table: "Students");

        //    migrationBuilder.DropColumn(
        //        name: "FatherEmail",
        //        table: "Students");

        //    migrationBuilder.DropColumn(
        //        name: "FatherName",
        //        table: "Students");

        //    migrationBuilder.DropColumn(
        //        name: "GuardianContact",
        //        table: "Students");

        //    migrationBuilder.DropColumn(
        //        name: "GuardianEmail",
        //        table: "Students");

        //    migrationBuilder.DropColumn(
        //        name: "GuardianName",
        //        table: "Students");

        //    migrationBuilder.DropColumn(
        //        name: "MotherContact",
        //        table: "Students");

        //    migrationBuilder.DropColumn(
        //        name: "MotherEmail",
        //        table: "Students");

        //    migrationBuilder.DropColumn(
        //        name: "MotherName",
        //        table: "Students");

        //    migrationBuilder.AlterColumn<byte[]>(
        //        name: "photo",
        //        table: "Students",
        //        type: "varbinary(max)",
        //        nullable: false,
        //        defaultValue: new byte[0],
        //        oldClrType: typeof(byte[]),
        //        oldType: "varbinary(max)",
        //        oldNullable: true);
    }
}