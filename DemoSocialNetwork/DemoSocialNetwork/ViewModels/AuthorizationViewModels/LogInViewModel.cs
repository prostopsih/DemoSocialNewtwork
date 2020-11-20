using DemoSocialNetwork.Infrastructure;
using BLL.DTO.User;
using BLL.Infrastructure;
using BLL.Services.UserService;
using DemoSocialNetwork.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace DemoSocialNetwork.ViewModels
{
    class LogInViewModel : BaseNotifyPropertyChanged
    {
        public UserAuthorizationInfo UserAuthorizationInfo 
        { 
            get;
            set;
        }




        public LogInViewModel()
        {
            UserAuthorizationInfo = new UserAuthorizationInfo() { Password = String.Empty };
        }



    }
}
