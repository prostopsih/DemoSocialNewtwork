using BLL.Services.AvatarService;
using BLL.Services.PostService;
using BLL.Services.UnitOfWork;
using BLL.Services.UserService;
using DAL.Contexts;
using DAL.Repositories;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Modules
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserService>().To<UserService>();
            Bind<IPostService>().To<PostService>();
            Bind<IAvatarService>().To<AvatarService>();

            Bind<IRepository<User>>().To<UserRepository>();
            Bind<IRepository<Avatar>>().To<AvatarRepository>();
            Bind<IRepository<Post>>().To<PostRepository>();
            Bind<IRepository<AvaSignature>>().To<AvaSignatureRepository>();

            Bind<IUnitOfWork>().To<UnitOfWork>();

            Bind<DbContext>().To<DemoSocialNetworkContext>().InSingletonScope();
        }
    }
}
