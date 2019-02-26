using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.Core.Repositorys
{

    public interface IRepository<TEntity, TPrimaryKey> where TEntity : IEntity<TPrimaryKey>
    {
        #region Select

        TEntity Get(TPrimaryKey id);

        #endregion

        #region Delete

        void Delete(TPrimaryKey id);
        void Delete(IEnumerable<TPrimaryKey> ids);


        #endregion

        #region insert
        TEntity Insert(TEntity entity);

        IEnumerable<TEntity> InsertList(IEnumerable<TEntity> list);
        #endregion

        #region update
        TEntity Update(TEntity entity);
        IEnumerable<TEntity> UpdateList(IEnumerable<TEntity> list);
        #endregion
    }
}
