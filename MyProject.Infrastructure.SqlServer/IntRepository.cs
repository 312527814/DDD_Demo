using MyProject.Core;
using MyProject.Core.Core;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace MyProject.Infrastructure.SqlServer
{
    public abstract class IntRepository<TEntity> : Repository<TEntity, int> where TEntity : Entity
    {
        public IntRepository(UnitOfWork unitOfWork, ISqlHelper sqlHelper) : base(unitOfWork, sqlHelper)
        {

        }
        public override TEntity Insert(TEntity entity)
        {
            var list = CommonHelper.GetProperties(entity);
            list.Remove("Id");
            var parament = CommonHelper.GetParament(entity);
            parament.Remove("@Id");
            var sql = $"INSERT INTO [{tableName}] ({string.Join(",", list)}) VALUES (@{string.Join(",@", list)});SELECT @@IDENTITY";
            entity.Id = _sqlHelper.Scalar<int>(_unitOfWork.Connection, sql, parament);
            return entity;
        }
        public override IEnumerable<TEntity> InsertList(IEnumerable<TEntity> list)
        {
            //System.Threading.Tasks.Parallel.ForEach(list, s =>
            //{
            //    Insert(s);
            //});
            //return list;
            System.Threading.Tasks.Parallel.ForEach(list, entity =>
            {
                var properties = CommonHelper.GetProperties(entity);
                properties.Remove("Id");
                var parament = CommonHelper.GetParament(entity);
                parament.Remove("@Id");
                var sql = $"INSERT INTO [{tableName}] ({string.Join(",", list)}) VALUES (@{string.Join(",@", list)});SELECT @@IDENTITY";
                entity.Id = _sqlHelper.Scalar<int>(_unitOfWork.Connection, sql, parament);
            });
            return list;
        }

    }
}
