using BLL.DTO.Avatar;
using BLL.DTO.Post;
using BLL.Infrastructure;
using BLL.Services.AvatarService;
using BLL.Services.PostService;
using BLL.Services.UserService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DemoSocialNetwork.ViewModels
{
    class MainViewModel : BaseNotifyPropertyChanged
    {
        IUserService userService;
        IAvatarService avatarService;
        IPostService postService;

        private ObservableCollection<AvatarDTO> avatars;
        private ObservableCollection<PostDTO> posts;

        public ObservableCollection<AvatarDTO> Avatars
        {
            get => avatars;
            set
            {
                avatars = value;
                Notify();
            }
        }
        public ObservableCollection<PostDTO> Posts
        {
            get => posts;
            set
            {
                posts = value;
                Notify();
            }
        }


        public MainViewModel(IUserService userService, IAvatarService avatarService, IPostService postService)
        {
            this.userService = userService;
            this.postService = postService;
            this.avatarService = avatarService;

            InitCommands();
        }
        private void InitAvatars()
        {
            Avatars = new ObservableCollection<AvatarDTO>(avatarService.GetAll());
        }
        private void InitPosts()
        {
            Posts = new ObservableCollection<PostDTO>(postService.GetAll());
        }
        private void InitCommands()
        {

        }

        
        public ICommand LogOutCommand { get; set; }
        public ICommand CreateNewAccount { get; set; }
    }
}
