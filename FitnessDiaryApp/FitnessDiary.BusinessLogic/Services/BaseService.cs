using System;
using FitnessDiary.DataAccess.Interfaces;

namespace FitnessDiary.BusinessLogic.Services
{
    public abstract class BaseService
    {
        protected readonly IUnitOfWork _uow;

        protected BaseService(IUnitOfWork uow)
        {
            _uow = uow ?? throw new ArgumentNullException(nameof(uow));
        }
    }
}
