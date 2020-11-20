using DemoSocialNetwork.Infrastructure;
using BLL.DTO.User;
using BLL.Infrastructure;
using BLL.Services.UserService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using DemoSocialNetwork.Views;

namespace DemoSocialNetwork.ViewModels
{
    class RegistrationViewModel : BaseNotifyPropertyChanged
    {
        public UserDTO User { get; set; }
        public RegistrationViewModel()
        {
            User = new UserDTO { UserAuthorizationInfo = new UserAuthorizationInfo(), UserPublicInfo = new UserPublicInfo() };
        }
    }
}
