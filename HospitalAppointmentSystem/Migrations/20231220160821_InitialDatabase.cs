using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HospitalAppointmentSystem.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointments_doctors_doctorId",
                table: "appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_appointments_users_userId",
                table: "appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_doctors_branches_branchId",
                table: "doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_doctors_policlinics_policlinicId",
                table: "doctors");

            migrationBuilder.DropColumn(
                name: "isAdmin",
                table: "users");

            migrationBuilder.DropColumn(
                name: "userMail",
                table: "users");

            migrationBuilder.AlterColumn<string>(
                name: "userPassword",
                table: "users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "userName",
                table: "users",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<string>(
                name: "role",
                table: "users",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "policlinicId",
                table: "doctors",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "doctorName",
                table: "doctors",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "branchId",
                table: "doctors",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "userId",
                table: "appointments",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "doctorId",
                table: "appointments",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_doctors_doctorId",
                table: "appointments",
                column: "doctorId",
                principalTable: "doctors",
                principalColumn: "doctorId");

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_users_userId",
                table: "appointments",
                column: "userId",
                principalTable: "users",
                principalColumn: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_doctors_branches_branchId",
                table: "doctors",
                column: "branchId",
                principalTable: "branches",
                principalColumn: "branchId");

            migrationBuilder.AddForeignKey(
                name: "FK_doctors_policlinics_policlinicId",
                table: "doctors",
                column: "policlinicId",
                principalTable: "policlinics",
                principalColumn: "policlinicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_appointments_doctors_doctorId",
                table: "appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_appointments_users_userId",
                table: "appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_doctors_branches_branchId",
                table: "doctors");

            migrationBuilder.DropForeignKey(
                name: "FK_doctors_policlinics_policlinicId",
                table: "doctors");

            migrationBuilder.DropColumn(
                name: "role",
                table: "users");

            migrationBuilder.AlterColumn<string>(
                name: "userPassword",
                table: "users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "userName",
                table: "users",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "isAdmin",
                table: "users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "userMail",
                table: "users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<int>(
                name: "policlinicId",
                table: "doctors",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "doctorName",
                table: "doctors",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "branchId",
                table: "doctors",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "userId",
                table: "appointments",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "doctorId",
                table: "appointments",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_doctors_doctorId",
                table: "appointments",
                column: "doctorId",
                principalTable: "doctors",
                principalColumn: "doctorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_appointments_users_userId",
                table: "appointments",
                column: "userId",
                principalTable: "users",
                principalColumn: "userId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_doctors_branches_branchId",
                table: "doctors",
                column: "branchId",
                principalTable: "branches",
                principalColumn: "branchId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_doctors_policlinics_policlinicId",
                table: "doctors",
                column: "policlinicId",
                principalTable: "policlinics",
                principalColumn: "policlinicId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
