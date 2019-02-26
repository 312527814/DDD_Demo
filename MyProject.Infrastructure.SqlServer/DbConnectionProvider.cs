using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace MyProject.Infrastructure.SqlServer
{
    public class DbConnectionProvider
    {
        private string _connstr;
        public DbConnectionProvider(string connstr)
        {
            _connstr = connstr;
        }

        /// <summary>
        /// Get a database
        /// </summary>
        public DbConnection Connection => new SqlConnection(_connstr);

        /// <summary>
        /// Database transaction
        /// </summary>
        public DbTransaction DbTransaction => Connection.BeginTransaction();
    }
}
