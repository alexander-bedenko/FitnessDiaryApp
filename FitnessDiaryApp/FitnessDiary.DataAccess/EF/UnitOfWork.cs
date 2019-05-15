using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessDiary.DataAccess.Entities;
using FitnessDiary.DataAccess.Interfaces;
using FitnessDiary.DataAccess.Repositories;

namespace FitnessDiary.DataAccess.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FitnessDiaryContext _context;
        private readonly IDictionary<Type, object> _repositories;

        private bool _disposed;

        public UnitOfWork()
        {
            _repositories = new Dictionary<Type, object>();
            _context = new FitnessDiaryContext();
        }

        public IBaseRepository<T> Repository<T>() where T : BaseEntity
        {
            if (_repositories.Keys.Contains(typeof(T)))
            {
                return _repositories[typeof(T)] as IBaseRepository<T>;
            }

            IBaseRepository<T> repo = new BaseRepository<T>(_context);
            _repositories.Add(typeof(T), repo);
            return repo;
        }

        public FitnessDiaryContext Context => _context;

        public void Rollback() => _context.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync(true);
        }
    }
}
