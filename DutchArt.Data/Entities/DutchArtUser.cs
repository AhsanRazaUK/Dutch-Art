using Microsoft.AspNetCore.Identity;

namespace DutchArt.Data.Entities
{
    public class DutchArtUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string Surname { get; set; }
    }
}
