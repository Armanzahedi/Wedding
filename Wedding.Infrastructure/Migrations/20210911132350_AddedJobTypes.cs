using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wedding.Infrastructure.Migrations
{
    public partial class AddedJobTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "432716ac-f544-4672-bf34-b75f51d60efc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "7c6ae907-f9d0-4b8f-b878-a32834b26d11");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "08d8d308-e0b5-45d7-8de5-bb31ff3a832a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7b268dee-35a7-4b11-9b22-0abf021fff88", "AQAAAAEAACcQAAAAEEdWivyP0BR8EO27jG5r6u7x6CdLbF9xCzUN469KMhIZuLaVZ8R+K1Pfpd04sVxD7A==", "3f48a765-16e3-45ea-bc04-2f1d0aec348e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1f29904e-a20e-483a-9a17-fa13f5513455", "AQAAAAEAACcQAAAAEDIv2RnIpLSGZjcUjHEwGHT44fQbz9FKQO08FfbdB0577LELfc6+t5td3Pbreqj4MA==", "df021d98-f2d3-4c74-9505-91a97a8a8a2a" });

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2021, 9, 11, 17, 53, 49, 27, DateTimeKind.Local).AddTicks(378));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "a43a5292-27cc-4b07-9f04-038744a72940");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "ce96b0cb-4986-44ba-a5b6-5a8a707b2acd");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "fc362855-1714-460d-84a2-542a52041d10");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8691aaea-419a-445b-81eb-f0cc3ffe7a0e", "AQAAAAEAACcQAAAAEF33Ev2cctxQxxsB9yY5s6PyEjo+CWABfmkbrxUCtsVdoiOXZ4ry6thjNIzdiIHZCA==", "479ec373-24d0-4b7f-a918-dee893247743" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "21160f7e-3c18-415a-9065-c0265426faa8", "AQAAAAEAACcQAAAAEIFA5F7za5rE03DzdXOCfFK1//2V+zKqeoWlu9V1k27NNSn7XylJY9QhYOfTPBDaeg==", "ec5fd715-ae69-4695-8496-1746c5a32798" });

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2021, 9, 11, 16, 36, 8, 296, DateTimeKind.Local).AddTicks(8594));
        }
    }
}
