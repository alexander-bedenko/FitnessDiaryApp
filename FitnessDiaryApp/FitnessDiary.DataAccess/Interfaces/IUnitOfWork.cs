using System;
using System.Threading.Tasks;
using FitnessDiary.DataAccess.EF;
using FitnessDiary.DataAccess.Entities;

namespace FitnessDiary.DataAccess.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<T> Repository<T>() where T : BaseEntity;

        FitnessDiaryContext Context { get; }

        Task Commit();

        void Rollback();
    }
}