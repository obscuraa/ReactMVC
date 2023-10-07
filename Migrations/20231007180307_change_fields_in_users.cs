using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReactMVC.Migrations
{
    public partial class change_fields_in_users : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "087a2329-0493-4462-b1d1-6c2546a0c90b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "0de0bcd0-bc37-4444-8d57-dbf6501371d9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "80c55a26-6349-4ab9-9cec-d3b701f35d7b");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "AspNetUsers",
                newName: "UserPassword");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AddColumn<string>(
                name: "UserEmail",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IdInteger", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UniqueUsername", "UserEmail", "UserName", "UserPassword" },
                values: new object[] { "7b77f351-b002-41ce-ae42-6834a6f4ebd6", 0, "1b62586a-70b0-4b5f-bb56-dfdc6c07f1c8", null, false, "alex", 2, "test", false, null, null, null, null, null, false, "29030922-0b85-4dd9-a410-e95e44a91c56", false, "user2", "asdasdasd@gmail.com", null, "asfdsafsfsf" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IdInteger", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UniqueUsername", "UserEmail", "UserName", "UserPassword" },
                values: new object[] { "af760ab0-5051-4201-81da-0548631a5337", 0, "4a31f897-aa27-4e68-a039-c1c865c56081", null, false, "abc", 1, "cba", false, null, null, null, null, null, false, "84cc9569-77ae-4c4f-a748-bde20eb6ad21", false, "user1", "abc@gmail.com", null, "123456" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IdInteger", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UniqueUsername", "UserEmail", "UserName", "UserPassword" },
                values: new object[] { "e8942a6c-9fdc-455b-8d44-2ca3dbf4868f", 0, "17979b16-e411-4299-8a9d-6e540132ae36", null, false, "john", 3, "doe", false, null, null, null, null, null, false, "249e3b46-8627-4e90-95ff-5341c3e3ccb6", false, "user3", "test@gmail.com", null, "123456" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7b77f351-b002-41ce-ae42-6834a6f4ebd6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "af760ab0-5051-4201-81da-0548631a5337");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e8942a6c-9fdc-455b-8d44-2ca3dbf4868f");

            migrationBuilder.DropColumn(
                name: "UserEmail",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "UserPassword",
                table: "AspNetUsers",
                newName: "Password");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IdInteger", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UniqueUsername", "UserName" },
                values: new object[] { "087a2329-0493-4462-b1d1-6c2546a0c90b", 0, "d71df900-c2a1-4b62-a9cc-b366c5341a10", "asdasdasd@gmail.com", false, "alex", 2, "test", false, null, null, null, "asfdsafsfsf", null, null, false, "52ded11f-bb4b-4916-a730-7a6e235fbf1c", false, "user2", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IdInteger", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UniqueUsername", "UserName" },
                values: new object[] { "0de0bcd0-bc37-4444-8d57-dbf6501371d9", 0, "bb851f70-8f37-4f48-b09a-0282ac5c584a", "test@gmail.com", false, "john", 3, "doe", false, null, null, null, "123456", null, null, false, "280a6456-798b-4ca7-8845-4d8b2d43ec0b", false, "user3", null });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IdInteger", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UniqueUsername", "UserName" },
                values: new object[] { "80c55a26-6349-4ab9-9cec-d3b701f35d7b", 0, "422b6887-b213-420d-931e-35ed9b38e819", "abc@gmail.com", false, "abc", 1, "cba", false, null, null, null, "123456", null, null, false, "252e88ce-dbf1-4def-93d5-93b972284a1d", false, "user1", null });
        }
    }
}
