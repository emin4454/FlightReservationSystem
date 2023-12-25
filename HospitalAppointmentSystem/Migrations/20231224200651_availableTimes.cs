using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalAppointmentSystem.Migrations
{
    public partial class availableTimes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointments_AspNetUsers_userId",
                table: "appointments");

            migrationBuilder.DropColumn(
                name: "worktimeLength",
                table: "doctors");

            migrationBuilder.DropColumn(
                name: "worktimeStart",
                table: "doctors");

            migrationBuilder.AddColumn<string>(
                name: "availableAppointmentTimes",
                table: "doctors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "userId",
                table: "appointments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_AspNetUsers_userId",
                table: "appointments",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointments_AspNetUsers_userId",
                table: "appointments");

            migrationBuilder.DropColumn(
                name: "availableAppointmentTimes",
                table: "doctors");

            migrationBuilder.AddColumn<int>(
                name: "worktimeLength",
                table: "doctors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "worktimeStart",
                table: "doctors",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AlterColumn<string>(
                name: "userId",
                table: "appointments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_AspNetUsers_userId",
                table: "appointments",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
