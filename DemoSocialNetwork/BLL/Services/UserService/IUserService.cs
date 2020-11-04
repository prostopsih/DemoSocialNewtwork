using BLL.DTO;
using BLL.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.UserService
{
    public interface IUserService
    {
        UserPublicInfo LogIn(UserAuthorizationInfo authorizationInfo);
        UserPublicInfo GetUserPublicInfo();
        bool IsLogged();
        void LogOut();
        bool CreateNewAccount(UserDTO user);
        bool DeleteAccount(UserAuthorizationInfo authorizationInfo);
    }
}
