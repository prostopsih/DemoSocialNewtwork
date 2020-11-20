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
    public class PostService : IPostService
    {
        protected IRepository<Post> repository;
        protected IUnitOfWork unitOfWork;
        protected IMapper mapper;
        public PostService(IRepository<Post> postRepository,
            IUnitOfWork unitOfWork)
        {
            this.repository = postRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Post, PostDTO>()
                                        .ForMember(x => x.Id, x => x.MapFrom(y => y.PostId))
                                            .ReverseMap()
                                                .ForMember(x => x.PostId, x => x.MapFrom(y => y.Id))
                                                    .ForMember(x => x.User, x => x.Ignore())
                                                        .ForMember(x => x.UserId, x => x.MapFrom(y => LoginnedUser.LoggedUser.UserId));
            }));



        }

        public PostDTO CreateOrUpdate(PostDTO entity)
        {
            var result = mapper.Map<Post>(entity);
            result.UserId = LoginnedUser.LoggedUser.UserId;
            repository.CreateOrUpdate(result);
            unitOfWork.Save();
            return mapper.Map<PostDTO>(result);
        }

        public PostDTO Get(int id)
        {
            var res = repository.Get(id);
            if(res.UserId == LoginnedUser.LoggedUser.UserId)
            {
                return mapper.Map<PostDTO>(res);
            }
            return null;
        }

        public IEnumerable<PostDTO> GetAll()
        {
            return mapper.Map<IEnumerable<PostDTO>>(repository.GetAll().Where(x => x.UserId == LoginnedUser.LoggedUser.UserId));
        }

        public void Remove(PostDTO entity)
        {
            var result = repository.Get(entity.Id);
            repository.Remove(result);
            unitOfWork.Save();
        }
    }
}
