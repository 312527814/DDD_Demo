using MyProject.Core;
using MyProject.Core.Core;
using MyProject.Core.Dependency;
using MyProject.Core.Repositorys;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MyProject.Infrastructure.SqlServer
{
    public abstract class Repository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey>, IScopedDependency where TEntity : IEntity<TPrimaryKey>
    {
        //public readonly ConnectionManager _connectionManager;
        protected ISqlHelper _sqlHelper;
        protected string tableName;
        protected UnitOfWork _unitOfWork;


        //public Repository(ConnectionAppSetting connectionAppSetting)
        //{
        //    tableName = typeof(TEntity).Name;
        //    _connectionManager = new ConnectionManager(connectionAppSetting);
        //}
        public Repository(UnitOfWork unitOfWork, ISqlHelper sqlHelper)
        {
            tableName = typeof(TEntity).Name;
            _unitOfWork = unitOfWork;
            _sqlHelper = sqlHelper;
        }

        #region select


        public TEntity Get(TPrimaryKey id)
        {
            var list = CommonHelper.GetProperties(default(TEntity));
            var fields = string.Join(",", list);
            var sql = $"select {fields} from {tableName} where Id=@Id";
            return _sqlHelper.FirstOrDefault<TEntity>(_unitOfWork.Connection, sql, new { Id = id });

        }

        #endregion


        #region delete
        public void Delete(TPrimaryKey id)
        {

            var sql = $"delete from {tableName} where Id = @Id";
            _sqlHelper.Execute(_unitOfWork.Connection, sql, new { Id = id });
        }

        public void Delete(IEnumerable<TPrimaryKey> ids)
        {
            var sql = $"delete from {tableName} where Id in @Ids";
            _sqlHelper.Execute(_unitOfWork.Connection, sql, new { Ids = ids });

        }


        #endregion

        #region insert

        public virtual TEntity Insert(TEntity entity)
        {
            //var sql = $"INSERT INTO [{TableName}] ({string.Join(",", list)}) VALUES (@{string.Join(",@", list)});SELECT @@IDENTITY";
            //entity.Id = BottomDapper.QueryScalar<int>(sql, parament);
            var list = CommonHelper.GetProperties(entity);
            var parament = CommonHelper.GetParament(entity);
            var sql = $"INSERT INTO [{tableName}] ({string.Join(",", list)}) VALUES (@{string.Join(",@", list)})";
            //entity.Id = default(TPrimaryKey);// (TPrimaryKey)1;
            _sqlHelper.Execute(_unitOfWork.Connection, sql, parament);
            return entity;
        }
        public virtual IEnumerable<TEntity> InsertList(IEnumerable<TEntity> list)
        {
            System.Threading.Tasks.Parallel.ForEach(list, s =>
            {
                Insert(s);
            });
            return list;
        }

        #endregion

        #region update

        public TEntity Update(TEntity entity)
        {
            var list = CommonHelper.GetProperties(entity);
            var parament = CommonHelper.GetParament(entity);
            var agg = list.Aggregate(new StringBuilder(), (x, y) =>
            {
                x.Append(y);
                x.Append("=@");
                x.Append(y);
                x.Append(",");
                return x;
            });
            var sql = $"UPDATE [{tableName}] SET {agg.ToString().TrimEnd(',')} WHERE Id = @Id";
            _sqlHelper.Execute(_unitOfWork.Connection, sql, parament);
            return entity;

        }

        public IEnumerable<TEntity> UpdateList(IEnumerable<TEntity> list)
        {
            System.Threading.Tasks.Parallel.ForEach(list, s =>
            {
                Update(s);
            });
            return list;
        }






        #endregion


    }
}
