using AutoMapper;
using BLL.DTO.Avatar;
using BLL.Extensions;
using BLL.Infrastructure;
using BLL.Services.UnitOfWork;
using DAL.Contexts;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.AvatarService
{
    public class AvatarService : IAvatarService
    {
        IRepository<Avatar> avatarRepository;
        IRepository<AvaSignature> avaSignatureRepository;
        IUnitOfWork unitOfWork;
        IMapper mapper;
        public AvatarService(IRepository<Avatar> avatarRepository, IRepository<AvaSignature> avaSignatureRepository, IUnitOfWork unitOfWork)
        {
            this.avatarRepository = avatarRepository;
            this.avaSignatureRepository = avaSignatureRepository;
            this.unitOfWork = unitOfWork;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<AvatarDTO, Avatar>()
                                            .ForMember(x => x.AvatarId, x => x.MapFrom(y => y.Id))
                                                .ForMember(x => x.Image, x => x.MapFrom(y => y.Image.ConvertToBytes()))
                                                    .ForMember(x => x.User, x => x.Ignore())
                                                        .ForMember(x => x.AvaSignature, x => x.Ignore())
                                                            .ForMember(x => x.UserId, x => x.MapFrom(y => LoginnedUser.LoggedUser.UserId));
                cfg.CreateMap<Avatar, AvatarDTO>()
                                             .ForMember(x => x.Id, x => x.MapFrom(y => y.AvatarId))
                                                .ForMember(x => x.Image, x => x.MapFrom(y => y.Image.ConvertToImage()))
                                                    .ForMember(x => x.Signature, x => x.MapFrom(y => y.AvaSignature == null ? y.AvaSignature.Text : null));
            });
            this.mapper = new Mapper(config);
        }
        public AvatarDTO CreateOrUpdate(AvatarDTO entity)
        {
            var resAvatar = mapper.Map<Avatar>(entity);
            avatarRepository.CreateOrUpdate(resAvatar);

            var resAvaSignature = mapper.Map<AvaSignature>(entity);
            resAvaSignature.AvatarId = resAvatar.AvatarId;
            avaSignatureRepository.CreateOrUpdate(resAvaSignature);

            unitOfWork.Save();
            return mapper.Map<AvatarDTO>(avatarRepository.Get(resAvatar.AvatarId));
        }

        public AvatarDTO Get(int id)
        {
            return mapper.Map<AvatarDTO>(avatarRepository.Get(id));
        }

        public IEnumerable<AvatarDTO> GetAll()
        {
            return mapper.Map<IEnumerable<AvatarDTO>>(avatarRepository.GetAll());
        }

        public void Remove(AvatarDTO entity)
        {
            avatarRepository.Remove(mapper.Map<Avatar>(entity));
            avaSignatureRepository.Remove(mapper.Map<AvaSignature>(entity));
            unitOfWork.Save();
        }
    }
}
