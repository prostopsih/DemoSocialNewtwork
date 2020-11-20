using BLL.DTO.Post;
using BLL.DTO.User;
using BLL.Infrastructure;
using BLL.Services.AvatarService;
using BLL.Services.PostService;
using BLL.Services.UserService;
using DemoSocialNetwork.Infrastructure;
using DemoSocialNetwork.Managers;
using DemoSocialNetwork.ViewModels.UserViewModels;
using DemoSocialNetwork.Views;
using DemoSocialNetwork.Views.AuthorizationViews;
using DemoSocialNetwork.Views.UserViews;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DemoSocialNetwork.ViewModels
{
    class MainViewModel : BaseNotifyPropertyChanged
    {
        #region Services
        IUserService userService;
        IAvatarService avatarService;
        IPostService postService;
        #endregion

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
        #endregion

        private UserControl buffUserControl;
        #region Managers
        LocalizationManager localizationManager;
        ThemeManager themeManager;
        #endregion
        public MainViewModel(IUserService userService, IAvatarService avatarService, IPostService postService)
        {
            this.userService = userService;
            this.postService = postService;
            this.avatarService = avatarService;

            localizationManager = new LocalizationManager();
            themeManager = new ThemeManager();

            currentView = new AuthorizationMainView();
            InitEvents();
            InitCommands();
        }

        
        private void ChangeLocalization(string locale)
        {
            localizationManager.Locale = locale;
        }
        private void InitTheme(string themeName)
        {
            themeManager.ThemeName = themeName;
        }
        private void InitEvents()
        {
            userService.LogInned += () => CurrentView = new UserMainView();
            userService.LogOuted += () => CurrentView = new AuthorizationMainView();
        }

        private void InitCommands()
        {
            LogOutCommand = new RelayCommand(x =>
            {
                userService.LogOut();
            },
            x =>
            {
                return userService.IsLogged();
            });

            LogInCommand = new RelayCommand(x =>
            {
                var res = userService.LogIn(x as UserAuthorizationInfo);
                if(res == null)
                {
                    MessageBox.Show("Error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });
            RegistrationCommand = new RelayCommand(x =>
            {
                bool res = userService.CreateNewAccount(x as UserDTO);
                if(!res)
                {
                    MessageBox.Show("Error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            });
            PostViewCloseCommand = new RelayCommand(x =>
            {
                CurrentView = buffUserControl;
            });
            PostViewSaveCommand = new RelayCommand(x =>
            {
                var vm = CurrentView.DataContext as PostViewModel;
                postService.CreateOrUpdate(vm.Post);
                var userMainVM = buffUserControl.DataContext as UserMainViewModel;
                userMainVM.RefreshCommand.Execute(null);
                CurrentView = buffUserControl;
            });
            AddPostCommand = new RelayCommand(x =>
            {
                buffUserControl = CurrentView;
                CurrentView = new PostView();
                var vm = CurrentView.DataContext as PostViewModel;
                vm.IsAdding = true;
                vm.Post = new PostDTO { Header = String.Empty, Text = String.Empty };
            });
            EditPostCommand = new RelayCommand(x =>
            {
                buffUserControl = CurrentView;
                CurrentView = new PostView();
                var vm = CurrentView.DataContext as PostViewModel;
                vm.IsAdding = false;
                var post = x as PostDTO;
                vm.Post = new PostDTO { Header = post.Header, Text = post.Text, Id = post.Id };
            },
            x =>
            {
                try
                {
                    var vm = CurrentView.DataContext as UserMainViewModel;
                    return vm.SelectedPost != null;
                }
                catch
                {
                    return false;
                }
            });
            ChangeThemeCommand = new RelayCommand(x =>
            {
                InitTheme(x.ToString());
            });

            ChangeLocaleCommand = new RelayCommand(x =>
            {
                ChangeLocalization(x.ToString());
            });
        }
        #region Commands
        public ICommand LogOutCommand { get; set; }
        public ICommand LogInCommand { get; set; }
        public ICommand RegistrationCommand { get; set; }
        public ICommand PostViewCloseCommand { get; set; }
        public ICommand PostViewSaveCommand { get; set; }
        public ICommand AddPostCommand { get; set; }
        public ICommand EditPostCommand { get; set; }
        public ICommand ChangeThemeCommand { get; set; }
        public ICommand ChangeLocaleCommand { get; set; }
        #endregion
    }
}
