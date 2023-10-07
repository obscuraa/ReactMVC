using Microsoft.AspNetCore.Identity;

namespace ReactMVC.Models
{
    public class APIUser : IdentityUser
    {
        public int IdInteger { get; set; }
        public string UniqueUsername { get; set; }

        public string FirstName { get; set; }
        public string LastName {  get; set; }
        public string UserEmail {  get; set; }
        public string UserPassword { get; set; }
    }
}
