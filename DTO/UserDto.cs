using System.ComponentModel.DataAnnotations;

namespace ReactMVC.Models
{
    public class UserDto : CreateUserDto
    {
        public int IdInteger { get; set; }

        public ICollection<string> Roles { get; set; }
    }
    public class CreateUserDto : LoginDto
    {
        public string UniqueUsername { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class UpdateUserDto : CreateUserDto 
    {

    }
}
