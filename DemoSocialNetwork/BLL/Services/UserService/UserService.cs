using AutoMapper;
using BLL.DTO.User;
using BLL.Infrastructure;
using BLL.Services.UnitOfWork;
using DAL.Contexts;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BLL.Services.UserService
{
    public class UserService : IUserService
    {
        IRepository<User> userRepository;
        IUnitOfWork unitOfWork;
        IMapper mapper;
        public UserService(IRepository<User> userRepository, IUnitOfWork unitOfWork)
        {
            this.userRepository = userRepository;
            this.unitOfWork = unitOfWork;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserDTO, User>()
                                        .ForMember(x => x.Post, x => x.Ignore())
                                            .ForMember(x => x.UserId, x => x.Ignore())
                                                .ForMember(x => x.Avatar, x => x.Ignore())
                                                    .ForMember(x => x.Login, x => x.MapFrom(y => y.UserAuthorizationInfo.Login))
                                                        .ForMember(x => x.Password, x => x.MapFrom(y => y.UserAuthorizationInfo.Password))
                                                            .ForMember(x => x.UserName, x => x.MapFrom(y => y.UserPublicInfo.UserName));
                cfg.CreateMap<User, UserPublicInfo>();
            });
            mapper = new Mapper(config);
        }

        public event Action LogInned;
        public event Action LogOuted;
        public event Action Registered;

        public bool CreateNewAccount(UserDTO user)
        {
            try
            {
                User newOne = mapper.Map<User>(user);
                userRepository.CreateOrUpdate(newOne);
                unitOfWork.Save();
                Registered?.Invoke();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteAccount(UserAuthorizationInfo authorizationInfo)
        {
            User user = Verify(authorizationInfo);
            if (user != null)
            {
                userRepository.Remove(user);
                unitOfWork.Save();
                LoginnedUser.Clear();
                return true;
            }
            return false;
        }

        public UserPublicInfo GetUserPublicInfo()
        {
            if (IsLogged())
                return LoginnedUser.LoggedUser.UserPublicInfo;
            else
                return null;
        }

        public bool IsLogged()
        {
            return LoginnedUser.LoggedUser != null;
        }

        public UserPublicInfo LogIn(UserAuthorizationInfo authorizationInfo)
        {
            User user = Verify(authorizationInfo);
            if (user != null)
            {
                UserPublicInfo publicInfo = mapper.Map<UserPublicInfo>(user);
                LoginnedUser.CreateNewOne(user.UserId, publicInfo);
                LogInned?.Invoke();
                return publicInfo;
            }
            else
                return null;
        }
        public void LogOut()
        {
            LoginnedUser.Clear();
            LogOuted?.Invoke();
        }


        private User Verify(UserAuthorizationInfo authorizationInfo)
        {
            try
            {
                User user = userRepository.Get(userRepository.GetAll().ToList().Find(x => x.Login == authorizationInfo.Login).UserId);
                if (user.Password == authorizationInfo.Password)
                    return user;
                else
                    return null;
            }
            catch
            {
                return null;
            }
        }
    }
}
