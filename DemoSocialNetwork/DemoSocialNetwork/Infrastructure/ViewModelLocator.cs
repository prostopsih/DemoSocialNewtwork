using BLL.Modules;
using DemoSocialNetwork.ViewModels;
using DemoSocialNetwork.ViewModels.AuthorizationViewModels;
using DemoSocialNetwork.ViewModels.UserViewModels;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSocialNetwork.Infrastructure
{
    class ViewModelLocator
    {
        IKernel kernel;
        public ViewModelLocator()
        {
            kernel = new StandardKernel(new ServiceModule());
        }
        public UserMainViewModel UserMainViewModel => kernel.Get<UserMainViewModel>();
        public RegistrationViewModel RegistrationViewModel => kernel.Get<RegistrationViewModel>();
        public LogInViewModel LogInViewModel => kernel.Get<LogInViewModel>();
        public MainViewModel MainViewModel => kernel.Get<MainViewModel>();
        public AuthorizationViewModel AuthorizationViewModel => kernel.Get<AuthorizationViewModel>();
        public PostViewModel PostViewModel => kernel.Get<PostViewModel>();
    }
}
