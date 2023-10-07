using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReactMVC.Models;
using System.Reflection.Emit;

namespace ReactMVC.Configurations.Entities
{
    public class AddDataToUsersTableConfiguration : IEntityTypeConfiguration<APIUser>
    {
        public void Configure(EntityTypeBuilder<APIUser> builder)
        {
            builder.HasData(
                new APIUser
                {
                    IdInteger = 1,
                    UniqueUsername = "user1",
                    FirstName = "abc",
                    LastName = "cba",
                    UserEmail = "abc@gmail.com",
                    UserPassword = "123456"

                },
                new APIUser
                {
                    IdInteger = 2,
                    UniqueUsername = "user2",
                    FirstName = "alex",
                    LastName = "test",
                    UserEmail = "asdasdasd@gmail.com",
                    UserPassword = "asfdsafsfsf"
                },
                new APIUser
                {
                    IdInteger = 3,
                    UniqueUsername = "user3",
                    FirstName = "john",
                    LastName = "doe",
                    UserEmail = "test@gmail.com",
                    UserPassword = "123456"
                });
        }
    }
}
