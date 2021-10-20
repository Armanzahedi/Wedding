using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wedding.Infrastructure.Migrations
{
    public partial class ChangedCardNumberToNotNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CardNumber",
                table: "PaymentAccounts",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "1edf5dd4-c6ca-42fd-ac01-9caed9cbe24b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "c1c13892-5be4-4c61-a02b-3e8e7475a59f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "d388a94a-a82e-409f-aeee-87df3284b058");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "288ad241-4eeb-459f-a6a0-b7d283ada879", "AQAAAAEAACcQAAAAEDWUpjxRjABOHOocNIcEU8ga0hnTL25UU9ZWejD9fbIpQFdJMJKG2LgA7yohbMwe9Q==", "8019ebf6-ed9d-4268-845a-e7665376ffe7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f4241950-77a0-48ea-baf3-6d8984f3c42f", "AQAAAAEAACcQAAAAEGbCMOHaQbAeud9pClj/nREWGY6NNJPjVKzcR3f4RV+pXyd69Vp1qskpo4SRYcLCiA==", "e5470e05-7f18-47c5-9633-bc1e0c09b2e6" });

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2021, 10, 18, 10, 30, 24, 466, DateTimeKind.Local).AddTicks(3510));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CardNumber",
                table: "PaymentAccounts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901447c18",
                column: "ConcurrencyStamp",
                value: "ccc2060e-f906-402d-b94f-2d1e71ec8d57");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "29bd76db-5835-406d-ad1d-7a0901448abd",
                column: "ConcurrencyStamp",
                value: "5b225d89-cf57-4a1c-8388-ef97b6f24b6e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d7be43da-622c-4cfe-98a9-5a5161120d24",
                column: "ConcurrencyStamp",
                value: "a614f4f2-4820-42a7-844c-e382c625263e");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211acmf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "15a226d6-26bb-4302-97a4-699803773b29", "AQAAAAEAACcQAAAAEK6TuS/GuB3QNjLyn7z2F+Ua49hN4OG/hGWYrGDKRFbwYqGdty/DjNgy0In145knqg==", "8d471233-7acf-4f59-a82d-7ac28db82686" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "75625814-138e-4831-a1ea-bf58e211adff",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "571a8c6c-ee67-4afe-a501-65f24e016279", "AQAAAAEAACcQAAAAEPQwU0/JBcON/YzYtkuhyNlTLw95czvDKRgxhKScUYlX1bhchhbtC4BR65Ul7Z0H0w==", "8f8b675a-445e-41b3-8bb0-3bbf56873c30" });

            migrationBuilder.UpdateData(
                table: "SystemParameters",
                keyColumn: "Id",
                keyValue: 1,
                column: "InsertDate",
                value: new DateTime(2021, 10, 18, 10, 5, 6, 429, DateTimeKind.Local).AddTicks(9055));
        }
    }
}
