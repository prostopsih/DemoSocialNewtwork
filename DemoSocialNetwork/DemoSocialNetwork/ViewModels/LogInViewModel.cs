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
        private string errorMessage;
        public UserAuthorizationInfo UserAuthorizationInfo { get; set; }
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
        public LogInViewModel(IUserService userService)
        {
            this.userService = userService;

            InitCommands();
        }

        private void InitCommands()
        {
            RegistrationCommand = new RelayCommand(x =>
            {
                var dlg = new RegistrationView();
                dlg.ShowDialog();
            });

            LogInCommand = new RelayCommand(x =>
            {
                if(userService.LogIn(UserAuthorizationInfo) != null)
                {
                    var window = x as Window;
                    window.Close();

                    var dlg = new MainView();
                    dlg.ShowDialog();
                }
                else
                {
                    ErrorMessage = "Incorrect login or password, try again";
                    WaitForClearingErrorMessage();
                }
            });
        }
        private async void WaitForClearingErrorMessage()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(15 * 1000);
                ErrorMessage = string.Empty;
            });
        }



        public ICommand RegistrationCommand { get; set; }
        public ICommand LogInCommand { get; set; }
    }
}
