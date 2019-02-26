using MyProject.Core;
using MyProject.Core.Entitys;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace MyProject.Infrastructure.SqlServer
{
    public interface ISqlHelper
    {
        T Scalar<T>(DbConnection conn, string sql, object parament = null);

        int Execute(DbConnection conn, string sql, object parament = null);

        #region FirstQuery
        TModel FirstOrDefault<TModel>(DbConnection conn, string sql, object parament = null);
         (T1, T2) FirstOrDefault<T1, T2>(DbConnection conn, string sql, object parament = null);
         (T1, T2, T3) FirstOrDefault<T1, T2, T3>(DbConnection conn, string sql, object parament = null);
         (T1, T2, T3, T4) FirstOrDefault<T1, T2, T3, T4>(DbConnection conn, string sql, object parament = null);
         (T1, T2, T3, T4, T5) FirstOrDefault<T1, T2, T3, T4, T5>(DbConnection conn, string sql, object parament = null);
        #endregion

        #region Query
        IEnumerable<TModel> Query<TModel>(DbConnection conn, string sql, object parament = null);
        IEnumerable<(T1, T2)> Query<T1, T2>(DbConnection conn, string sql, object parament = null);
        IEnumerable<(T1, T2, T3)> Query<T1, T2, T3>(DbConnection conn, string sql, object parament = null);
        IEnumerable<(T1, T2, T3, T4)> Query<T1, T2, T3, T4>(DbConnection conn, string sql, object parament = null);
        IEnumerable<(T1, T2, T3, T4, T5)> Query<T1, T2, T3, T4, T5>(DbConnection conn, string sql, object parament = null);
        #endregion

        #region ExeProc
        int ExeProc(DbConnection conn, string procName, object parament = null);
        int ExeProc(DbConnection conn, string procName, object parament, int outTimes);

        T ExeProc<T>(DbConnection conn, string procName, object parament);
        T ExeProc<T>(DbConnection conn, string procName, object parament, int outTimes);
        IEnumerable<TModel> ExeProcQuery<TModel>(DbConnection conn, string procName, object parament = null);
        IEnumerable<(T1, T2)> ExeProcQuery<T1, T2>(DbConnection conn, string procName, object parament = null);
        IEnumerable<(T1, T2, T3)> ExeProcQuery<T1, T2, T3>(DbConnection conn, string procName, object parament = null);

        IEnumerable<TModel> ExeProcQuery<TModel>(DbConnection conn, string procName, object parament, int outTimes);
        IEnumerable<(T1, T2)> ExeProcQuery<T1, T2>(DbConnection conn, string procName, object parament, int outTimes);
        IEnumerable<(T1, T2, T3)> ExeProcQuery<T1, T2, T3>(DbConnection conn, string procName, object parament, int outTimes);
        #endregion




    }
}
