using Floppy.Models.UserModels;
using Floppy.Models.WordModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Floppy.Managers.Users
{
    public interface IUserManager
    {
        Task<SignResult> RegisterAsync(RegisterViewModel model);
        Task<SignResult> SignInAsync(LoginViewModel model);
        Task SignOutAsync();

    }
}
