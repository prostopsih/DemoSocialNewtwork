using AutoMapper;
using BLL.DTO.Post;
using BLL.Infrastructure;
using BLL.Services.BaseService;
using BLL.Services.UnitOfWork;
using DAL.Contexts;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.PostService
{
    public class PostService : BaseCRUDGenericService<Post, PostDTO>, IPostService
    {
        public PostService(IRepository<Post> postRepository,
            IUnitOfWork unitOfWork)
            : base(postRepository,
                  unitOfWork,
                  new Mapper(new MapperConfiguration(cfg =>
                  {
                      cfg.CreateMap<Post, PostDTO>()
                                              .ForMember(x => x.Id, x => x.MapFrom(y => y.PostId))
                                                  .ReverseMap()
                                                      .ForMember(x => x.PostId, x => x.MapFrom(y => y.Id))
                                                          .ForMember(x => x.User, x => x.Ignore())
                                                              .ForMember(x => x.UserId, x => x.MapFrom(y => LoginnedUser.LoggedUser.UserId));
                  })))
        {
        }
    }
}
