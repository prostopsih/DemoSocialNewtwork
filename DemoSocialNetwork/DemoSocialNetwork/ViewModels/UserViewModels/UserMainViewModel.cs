using BLL.DTO.Avatar;
using BLL.DTO.Post;
using BLL.DTO.User;
using BLL.Infrastructure;
using BLL.Services.AvatarService;
using BLL.Services.PostService;
using BLL.Services.UserService;
using DemoSocialNetwork.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DemoSocialNetwork.ViewModels
{
    class UserMainViewModel : BaseNotifyPropertyChanged
    {
        IUserService userService;
        IAvatarService avatarService;
        IPostService postService;

        public UserPublicInfo UserInfo { get; set; }
        
        

        
        
        #region Avatars
        private ObservableCollection<AvatarDTO> avatars;

        public ObservableCollection<AvatarDTO> Avatars
        {
            get => avatars;
            set
            {
                avatars = value;
                Notify();
            }
        }

        private void InitAvatars() => Avatars = new ObservableCollection<AvatarDTO>(avatarService.GetAll());
        #endregion

        #region Posts
        private ObservableCollection<PostDTO> posts;

        public ObservableCollection<PostDTO> Posts
        {
            get => posts;
            set
            {
                posts = value;
                Notify();
            }
        }

        private PostDTO selectedPost;

        public PostDTO SelectedPost
        {
            get => selectedPost;
            set
            {
                selectedPost = value;
                Notify();
            }
        }

        private string searchByHeader;

        public string SearchByHeader
        {
            get => searchByHeader;
            set
            {
                searchByHeader = value;
                SortPosts();
                Notify();
            }
        }

        private void SortPosts()
        {
            Posts = new ObservableCollection<PostDTO>(postService.GetAll().Where(x => x.Header.Contains(SearchByHeader)));
        }

        private void InitPosts() => Posts = new ObservableCollection<PostDTO>(postService.GetAll());


        private void InitPostCommands()
        {
            DeletePostCommand = new RelayCommand(x =>
            {
                postService.Remove(SelectedPost);
                Posts.Remove(SelectedPost);
            },
            x =>
            {
                return SelectedPost != null;
            });
            EditPostCommand = new RelayCommand(x =>
            {

            },
            x =>
            {
                return SelectedPost != null;
            });

        }
        public ICommand DeletePostCommand { get; set; }
        public ICommand EditPostCommand { get; set; }
        #endregion

        public UserMainViewModel(IUserService userService, IAvatarService avatarService, IPostService postService)
        {
            this.userService = userService;
            this.postService = postService;
            this.avatarService = avatarService;

            UserInfo = userService.GetUserPublicInfo();
            InitCommands();
            InitCollections();
        }
        
        
        
        
        private void InitCollections()
        {
            InitAvatars();
            InitPosts();
        }
        private void InitCommands()
        {
            RefreshCommand = new RelayCommand(x =>
            {
                InitCollections();
            });
            InitPostCommands();

        }

        public ICommand RefreshCommand { get; set; }
    }
}
