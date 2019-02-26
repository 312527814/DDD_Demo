using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.Infrastructure.SqlServer
{
    public interface IConnectionString
    {
        string Master { get; }

        string Slave { get; }
    }
}
