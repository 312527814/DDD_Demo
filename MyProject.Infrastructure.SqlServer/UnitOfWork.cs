using MyProject.Core.Uow;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using MyProject.Core;
using MyProject.Core.Repositorys;
using System.Data.SqlClient;
using MyProject.Core.Dependency;

namespace MyProject.Infrastructure.SqlServer
{
    public class UnitOfWork : IUnitOfWork, IScopedDependency
    {
        private SqlConnection _connection;
        private SqlTransaction _transaction;

        public DbConnection Connection => _connection;

        public bool Active =>!string.IsNullOrEmpty(_connection.Database);

        public UnitOfWork(SqlConnection connection)
        {
            _connection = connection;
        }
        public void BeginTransaction()
        {
            _transaction = _connection.BeginTransaction();
        }

        public void Commit()
        {
            _transaction.Commit();
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _connection.Close();
            _connection.Dispose();
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public void BeginTransaction(UnitOfWorkOptions options)
        {
            _transaction = _connection.BeginTransaction(options.IsolationLevel, options.TransactionName);
        }
    }
}
