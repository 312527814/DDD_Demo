using MyProject.Core.Repositorys;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace MyProject.Core.Uow
{
    public interface IUnitOfWork : IDisposable
    {
        bool Active { get; }
        void BeginTransaction();
        void BeginTransaction(UnitOfWorkOptions options);
        void Commit();
        void Rollback();
    }
}
