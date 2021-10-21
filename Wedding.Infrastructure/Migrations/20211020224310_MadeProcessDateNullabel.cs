using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wedding.Infrastructure.Migrations
{
    public partial class MadeProcessDateNullabel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ProcessDate",
                table: "WithdrawalRequests",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "cd3117c1-103a-4b6d-80b0-3828f2e14f07");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "ede6686e-8882-40ed-94cb-47afac1781b9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "0a219011-dc5f-4f81-95dd-e7b43c04b6f0");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "72ae279e-4559-4c46-8852-6f8050f8f619", "AQAAAAEAACcQAAAAEBdYuNTMXCGM21eKjLpfdt8jr0A0q8V5PkwKVTx+iQREKE3J3hYz518iee7PVkHADQ==", "0d649fbc-b3f1-4e58-af27-987e887ea52b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9f042154-4a8a-4a82-b584-8bcd8add8699", "AQAAAAEAACcQAAAAEO68zUj0o2mCxwHWnUYjrb6gEbqLeJKN2urvSnehoh5emDOtt7R+YjlAvSpmqm6lhw==", "e555e1bf-1998-4c86-896f-3d9758882fb4" });

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2021, 10, 21, 2, 13, 10, 134, DateTimeKind.Local).AddTicks(8660));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ProcessDate",
                table: "WithdrawalRequests",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "fca485b4-e9d8-4c51-8ce2-5fdce4eb4ba8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "5bc630a7-67ca-4ac4-a304-8b335894d5be");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "65dcd378-03c2-4844-be58-349b2cc1815c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9003d251-87fe-4510-806f-b7067416a13a", "AQAAAAEAACcQAAAAEHkfcy+aecD+G+JZ/HVXMoqCM0/9XjbHb+I8cwClEoQXUKK+f4/e+UqL4dT27C8ORw==", "12ec94ce-953f-46ac-89f9-847c1b6c9bc7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a8a25d41-6a03-4fba-9b1d-09f2bce90109", "AQAAAAEAACcQAAAAEJhL+ZJXYyZrgDm3dwg7gjTlKq/5c2/P34J0cL3IiGW+SwP2HQSCcxh4KtyXoX9IXQ==", "8dd5b95b-8998-4d8e-8186-60fbc650b7e0" });

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2021, 10, 20, 17, 36, 33, 314, DateTimeKind.Local).AddTicks(9300));
        }
    }
}
