using BLL.Modules;
using DemoSocialNetwork.ViewModels;
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
        public MainViewModel MainViewModel => kernel.Get<MainViewModel>();
        public RegistrationViewModel RegistrationViewModel => kernel.Get<RegistrationViewModel>();
        public LogInViewModel LogInViewModel => kernel.Get<LogInViewModel>();
    }
}
