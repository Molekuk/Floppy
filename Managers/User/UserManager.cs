using Floppy.Models.UserModels;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace Floppy.Managers.Users
{
    public class UserManager:IUserManager
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserManager(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<SignResult> RegisterAsync(RegisterViewModel model)
        {
            User user = new User { Email = model.Email, UserName = model.Login,Money = 0 };
            var userResult = new SignResult();

            if ((await _userManager.FindByEmailAsync(model.Email)) != null)
            {
                userResult.Error = "Пользователь с таким email уже существует";
                userResult.Succeeded = false;
            }
            else if ((await _userManager.FindByNameAsync(model.Login)) != null)
            {
                userResult.Error = "Пользователь с таким именем уже существует";
                userResult.Succeeded = false;
            }
            else
                userResult.Succeeded = (await _userManager.CreateAsync(user, model.Password)).Succeeded;
            return userResult;
        }

        public async Task<SignResult> SignInAsync(LoginViewModel model)
        {
            var userResult = new SignResult();
            var user = _userManager.Users.FirstOrDefault(u => u.UserName == model.Login || u.Email == model.Login);

            if(user != null)
                userResult.Succeeded = (await _signInManager.PasswordSignInAsync(user.UserName, model.Password, false, false)).Succeeded;



            if (!userResult.Succeeded)
                userResult.Error = "Неправильный логин или пароль";

            return userResult;
        }

        public async Task SignOutAsync()
        {
          await  _signInManager.SignOutAsync();
        }
    }
}
