using Floppy.Models.UserModels;
using System.Threading.Tasks;

namespace Floppy.Managers.Users
{
    public interface IUserManager
    {
        Task<SignResult> RegisterAsync(RegisterViewModel model);
        Task<SignResult> SignInAsync(LoginViewModel model);
    }
}
