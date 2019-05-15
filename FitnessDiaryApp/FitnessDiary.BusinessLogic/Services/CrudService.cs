using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using FitnessDiary.BusinessLogic.Dtos;
using FitnessDiary.BusinessLogic.Interfaces;
using FitnessDiary.DataAccess.Entities;
using FitnessDiary.DataAccess.Interfaces;

namespace FitnessDiary.BusinessLogic.Services
{
    public class CrudService<TEntity, TModel> : BaseService, ICrudService<TEntity, TModel>
        where TEntity : BaseEntity
        where TModel : BaseDto, new()
    {
        protected CrudService(IUnitOfWork uow)
            : base(uow)
        {
        }

        public async Task<IEnumerable<TModel>> GetAllAsync(Expression<Func<TEntity, bool>> filter)
        {
            var entities = await _uow.Repository<TEntity>().GetAllAsync(filter);
            var dtos = Mapper.Map<IEnumerable<TEntity>, IEnumerable<TModel>>(entities);

            return dtos;
        }

        public async Task<IEnumerable<TModel>> GetAllAsync()
        {
            var entities = await _uow.Repository<TEntity>().GetAllAsync();
            var dtos = Mapper.Map<IEnumerable<TEntity>, IEnumerable<TModel>>(entities);

            return dtos;
        }


        public IEnumerable<TModel> GetAll(Expression<Func<TEntity, bool>> filter)
        {
            var entities = _uow.Repository<TEntity>().GetAll(filter);
            var dtos = Mapper.Map<IEnumerable<TEntity>, IEnumerable<TModel>>(entities);

            return dtos;
        }

        public IEnumerable<TModel> GetAll()
        {
            var entities = _uow.Repository<TEntity>().GetAll();
            var dtos = Mapper.Map<IEnumerable<TEntity>, IEnumerable<TModel>>(entities);

            return dtos;
        }

        public async Task<TModel> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            var entity = await _uow.Repository<TEntity>().GetAsync(filter);
            var dto = Mapper.Map<TModel>(entity);

            return dto;
        }

        public TModel Get(Expression<Func<TEntity, bool>> filter)
        {
            var entity = _uow.Repository<TEntity>().Get(filter);
            var dto = Mapper.Map<TModel>(entity);

            return dto;
        }

        public async Task Create(TModel model)
        {
            await _uow.Repository<TEntity>().Create(Mapper.Map<TEntity>(model));
            await _uow.Commit();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _uow.Repository<TEntity>().GetAsync(x => x.Id == id);
            await _uow.Repository<TEntity>().DeleteAsync(Mapper.Map<TEntity>(entity));
            await _uow.Commit();
        }

        public async Task<TModel> UpdateAsync(TModel model)
        {
            var entity = await _uow.Repository<TEntity>().UpdateAsync(Mapper.Map<TEntity>(model));
            await _uow.Commit();

            return Mapper.Map<TModel>(entity);
        }
    }
}
