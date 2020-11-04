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
        private string errorMessage;
        public string ErrorMessage 
        {
            get => errorMessage;
            set
            {
                errorMessage = value;
                Notify();
            }
        }
        IUserService userService;

        public RegistrationViewModel(IUserService userService)
        {
            this.userService = userService;
            User = new UserDTO { UserAuthorizationInfo = new UserAuthorizationInfo(), UserPublicInfo = new UserPublicInfo() };


            InitCommands();
        }
        private void InitCommands()
        {
            RegisterCommand = new RelayCommand(x =>
            {
                if(userService.CreateNewAccount(User))
                {
                    MessageBox.Show($"{User.UserPublicInfo.UserName}, your account is successfully created, now you have to log in", "Info");
                    BackToLogIn(x as Window);
                }
                else
                {
                    ErrorMessage = $"Error while creating an account";
                    WaitForClearingErrorMessage();
                }
            });
            GoToLogIn = new RelayCommand(x =>
            {
                BackToLogIn(x as Window);
            });
        }
        private void BackToLogIn(Window window)
        {
            window.Close();
        }
        private async void WaitForClearingErrorMessage()
        {
            await Task.Run(() => 
            {
                Thread.Sleep(15 * 1000);
                ErrorMessage = string.Empty;
            });
        }

        public ICommand RegisterCommand { get; set; }
        public ICommand GoToLogIn { get; set; }
    }
}
