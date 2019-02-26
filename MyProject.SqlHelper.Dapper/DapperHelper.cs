using Dapper;
using MyProject.Infrastructure.SqlServer;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace MyProject.SqlHelper.Dapper
{
    public class DapperHelper : ISqlHelper
    {
        //public (User, Addresses) FirstOrDefault(string sql, DbConnection conn, object parament = null)
        //{
        //    return conn.Query<User, Addresses, (User, Addresses)>(sql, (teacher, address) =>
        //    {
        //        return (teacher, address);
        //    }, parament).FirstOrDefault();
        //}

        //public PageEntity<TModel> Pagination<TModel>(string sql, int currentIndex, int pageSize, string fields = "*", string orderBy = "Id", object parament = null, bool isExactCount = true)
        //{
        //    var result = new PageEntity<TModel>();
        //    var excuteSql = $"select {fields} from ( {sql} )as pag order by {orderBy} limit {pageSize * (currentIndex - 1)},{pageSize}";
        //    if (isExactCount)
        //    {
        //        excuteSql += $";select count(*) from {sql} as C";
        //    }

        //    using (var conn = new SqlConnection(SlaveConnstr))
        //    {
        //        var read = conn.QueryMultiple(sql, parament);
        //        result.List = read.Read<TModel>();
        //        if (isExactCount)
        //        {
        //            result.Count = read.Read<int>().Single();
        //        }

        //    }
        //    return result;
        //}

        //public void QueryMultiple(DbConnection conn, string sql, object parament, Action<GridReader> readResult)
        //{
        //    var read = conn.QueryMultiple(sql, parament);
        //    readResult(read);
        //}

        public T Scalar<T>(DbConnection conn, string sql, object parament = null)
        {
            return conn.ExecuteScalar<T>(sql, parament);
        }

        public int Execute(DbConnection conn, string sql, object parament = null)
        {
            return conn.Execute(sql, parament);
        }

        #region FirstQuery
        public TModel FirstOrDefault<TModel>(DbConnection conn, string sql, object parament = null)
        {
            return conn.QueryFirstOrDefault<TModel>(sql, parament);
        }
        public (T1, T2) FirstOrDefault<T1, T2>(DbConnection conn, string sql, object parament = null)
        {
            return conn.QueryFirstOrDefault<(T1, T2)>(sql, parament);
        }
        public (T1, T2, T3) FirstOrDefault<T1, T2, T3>(DbConnection conn, string sql, object parament = null)
        {
            return conn.QueryFirstOrDefault<(T1, T2, T3)>(sql, parament);
        }
        public (T1, T2, T3, T4) FirstOrDefault<T1, T2, T3, T4>(DbConnection conn, string sql, object parament = null)
        {
            return conn.QueryFirstOrDefault<(T1, T2, T3, T4)>(sql, parament);
        }
        public (T1, T2, T3, T4, T5) FirstOrDefault<T1, T2, T3, T4, T5>(DbConnection conn, string sql, object parament = null)
        {
            return conn.QueryFirstOrDefault<(T1, T2, T3, T4, T5)>(sql, parament);
        }
        #endregion

        #region Query
        public IEnumerable<TModel> Query<TModel>(DbConnection conn, string sql, object parament = null)
        {
            return conn.Query<TModel>(sql, parament);
        }
        public IEnumerable<(T1, T2)> Query<T1, T2>(DbConnection conn, string sql, object parament = null)
        {
            return conn.Query<T1, T2, (T1, T2)>(sql, (t1, t2) =>
            {
                return (t1, t2);

            }, parament);
        }
        public IEnumerable<(T1, T2, T3)> Query<T1, T2, T3>(DbConnection conn, string sql, object parament = null)
        {
            return conn.Query<T1, T2, T3, (T1, T2, T3)>(sql, (t1, t2, t3) =>
            {
                return (t1, t2, t3);

            }, parament);
        }
        public IEnumerable<(T1, T2, T3, T4)> Query<T1, T2, T3, T4>(DbConnection conn, string sql, object parament = null)
        {
            return conn.Query<T1, T2, T3, T4, (T1, T2, T3, T4)>(sql, (t1, t2, t3, t4) =>
            {
                return (t1, t2, t3, t4);

            }, parament);
        }
        public IEnumerable<(T1, T2, T3, T4, T5)> Query<T1, T2, T3, T4, T5>(DbConnection conn, string sql, object parament = null)
        {
            return conn.Query<T1, T2, T3, T4, T5, (T1, T2, T3, T4, T5)>(sql, (t1, t2, t3, t4, t5) =>
            {
                return (t1, t2, t3, t4, t5);
            }, parament);
        }
        #endregion

        #region ExeProc
        public int ExeProc(DbConnection conn, string procName, object parament = null)
        {
            return conn.Execute(procName, parament, commandType: System.Data.CommandType.StoredProcedure);
        }
        public int ExeProc(DbConnection conn, string procName, object parament, int outTimes)
        {
            return conn.Execute(procName, parament, commandTimeout: outTimes, commandType: System.Data.CommandType.StoredProcedure);
        }

        public T ExeProc<T>(DbConnection conn, string procName, object parament)
        {
            return conn.ExecuteScalar<T>(procName, parament, commandType: System.Data.CommandType.StoredProcedure);
        }
        public T ExeProc<T>(DbConnection conn, string procName, object parament, int outTimes)
        {
            return conn.ExecuteScalar<T>(procName, parament, commandTimeout: outTimes, commandType: System.Data.CommandType.StoredProcedure);
        }
        public IEnumerable<TModel> ExeProcQuery<TModel>(DbConnection conn, string procName, object parament = null)
        {
            return conn.Query<TModel>(procName, parament, commandType: System.Data.CommandType.StoredProcedure);
        }
        public IEnumerable<(T1, T2)> ExeProcQuery<T1, T2>(DbConnection conn, string procName, object parament = null)
        {
            return conn.Query<(T1, T2)>(procName, parament, commandType: System.Data.CommandType.StoredProcedure);
        }
        public IEnumerable<(T1, T2, T3)> ExeProcQuery<T1, T2, T3>(DbConnection conn, string procName, object parament = null)
        {
            return conn.Query<(T1, T2, T3)>(procName, parament, commandType: System.Data.CommandType.StoredProcedure);
        }

        public IEnumerable<TModel> ExeProcQuery<TModel>(DbConnection conn, string procName, object parament, int outTimes)
        {
            return conn.Query<TModel>(procName, parament, commandTimeout: outTimes, commandType: System.Data.CommandType.StoredProcedure);
        }
        public IEnumerable<(T1, T2)> ExeProcQuery<T1, T2>(DbConnection conn, string procName, object parament, int outTimes)
        {
            return conn.Query<(T1, T2)>(procName, parament, commandTimeout: outTimes, commandType: System.Data.CommandType.StoredProcedure);
        }
        public IEnumerable<(T1, T2, T3)> ExeProcQuery<T1, T2, T3>(DbConnection conn, string procName, object parament, int outTimes)
        {
            return conn.Query<(T1, T2, T3)>(procName, parament, commandTimeout: outTimes, commandType: System.Data.CommandType.StoredProcedure);
        }
        #endregion




    }
}
