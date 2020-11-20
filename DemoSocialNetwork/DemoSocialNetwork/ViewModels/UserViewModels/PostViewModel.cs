using BLL.DTO.Post;
using BLL.Infrastructure;
using DemoSocialNetwork.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DemoSocialNetwork.ViewModels.UserViewModels
{
    class PostViewModel : BaseNotifyPropertyChanged
    {
        public bool IsAdding { get; set; }
        private PostDTO post;
        public PostDTO Post 
        {
            get => post;
            set
            {
                post = value;
                Notify();
            }
        }
        public PostViewModel()
        {
            Post = new PostDTO();
        }
    }
}
