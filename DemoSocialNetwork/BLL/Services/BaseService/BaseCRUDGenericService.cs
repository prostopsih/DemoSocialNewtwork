using AutoMapper;
using BLL.DTO;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BLL.Services.UnitOfWork;

namespace BLL.Services.BaseService
{
    public abstract class BaseGenericService<TEntityModel, TDTModel> : IService<TDTModel> where TEntityModel : class where TDTModel : IDTO
    {
        protected IRepository<TEntityModel> repository;
        protected IUnitOfWork unitOfWork;
        protected IMapper mapper;
        public BaseGenericService(IRepository<TEntityModel> repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.repository = repository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public TDTModel CreateOrUpdate(TDTModel entity)
        {
            var result = mapper.Map<TEntityModel>(entity);
            repository.CreateOrUpdate(result);
            unitOfWork.Save();
            return mapper.Map<TDTModel>(result);
        }

        public TDTModel Get(int id)
        {
            return mapper.Map<TDTModel>(repository.Get(id));
        }

        public IEnumerable<TDTModel> GetAll()
        {
            return mapper.Map<IEnumerable<TDTModel>>(repository.GetAll());
        }

        public void Remove(TDTModel entity)
        {
            var result = repository.Get(entity.Id);
            repository.Remove(result);
            unitOfWork.Save();
        }
    }
}
