using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ReactMVC.Migrations
{
    public partial class add_roles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "181eaf28-1738-450b-81e3-9bc5a0b57f40", "06880cc4-7dfd-4612-933e-87d118b1f11c", "User", "USER" },
                    { "c3b1a912-4b06-40db-9d72-48c7d647a543", "d6731e37-69e9-4b53-bf8a-27ddd01ef420", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "IdInteger", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UniqueUsername", "UserEmail", "UserName", "UserPassword" },
                values: new object[,]
                {
                    { "9cfef6b9-5dc9-4952-a770-6ff29247cbe1", 0, "cd5d21ea-6e13-431e-8061-d870e978674a", null, false, "john", 3, "doe", false, null, null, null, null, null, false, "0115d224-ed3e-460b-92ec-d667a453b1e1", false, "user3", "test@gmail.com", null, "123456" },
                    { "aaf54759-ce4b-47df-a3be-28de5e3f2438", 0, "f06a6039-6253-45d8-8017-36deb799568a", null, false, "abc", 1, "cba", false, null, null, null, null, null, false, "1b056576-b78f-41c6-8ad0-7fc47f81f462", false, "user1", "abc@gmail.com", null, "123456" },
                    { "d19061fd-0029-449a-b08e-8c28b5def94b", 0, "9068f50b-e338-4a47-a6f6-3c7294e2d48e", null, false, "alex", 2, "test", false, null, null, null, null, null, false, "08fc8453-2c46-4505-a7f1-29913cedd354", false, "user2", "asdasdasd@gmail.com", null, "asfdsafsfsf" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "181eaf28-1738-450b-81e3-9bc5a0b57f40");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c3b1a912-4b06-40db-9d72-48c7d647a543");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9cfef6b9-5dc9-4952-a770-6ff29247cbe1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "aaf54759-ce4b-47df-a3be-28de5e3f2438");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d19061fd-0029-449a-b08e-8c28b5def94b");

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
    }
}
