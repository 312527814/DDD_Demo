using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MyProject.Core.Uow
{
    /// <summary>
    /// Unit of work options
    /// </summary>
    public class UnitOfWorkOptions
    {

        /// <summary>
        /// If this UOW is transactional, this option indicated the isolation level of the transaction.
        /// Uses default value if not supplied.
        /// </summary>
        public IsolationLevel IsolationLevel { get; set; } = IsolationLevel.ReadCommitted;

        public string TransactionName { get; set; }


        /// <inheritdoc />
        public UnitOfWorkOptions()
        {
        }
    }
}
