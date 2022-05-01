using Microsoft.AspNetCore.Identity;

namespace Floppy.Models.UserModels
{
    public class User:IdentityUser
    {
        public int Money { get; set; }
    }
}
