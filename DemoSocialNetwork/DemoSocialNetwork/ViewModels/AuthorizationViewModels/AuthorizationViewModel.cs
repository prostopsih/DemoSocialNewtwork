using BLL.Infrastructure;
using BLL.Services.UserService;
using DemoSocialNetwork.Infrastructure;
using DemoSocialNetwork.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace DemoSocialNetwork.ViewModels.AuthorizationViewModels
{
    class AuthorizationViewModel : BaseNotifyPropertyChanged
    {
        IUserService userService;

        #region Properties
        private UserControl currentView;
        public UserControl CurrentView
        {
            get => currentView;
            set
            {
                currentView = value;
                Notify();
            }
        }


        #endregion

        public AuthorizationViewModel(IUserService userService)
        {
            this.userService = userService;

            CurrentView = new LogInView();
            InitEvents();
            InitCommands();
        }

        private void InitEvents()
        {
            userService.Registered += () => CurrentView = new LogInView();
        }

        private void InitCommands()
        {
            NavigateToLogInCommand = new RelayCommand(x =>
            {
                CurrentView = new LogInView();
            });
            NavigateToRegistrationCommand = new RelayCommand(x =>
            {
                CurrentView = new RegistrationView();
            });
        }

        public ICommand NavigateToLogInCommand { get; set; }
        public ICommand NavigateToRegistrationCommand { get; set; }
    }
}
