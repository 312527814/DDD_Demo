using MyProject.Core.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.Core.Repositorys
{
    public interface IAddressRepository : IRepository<Addresses, int>
    {
        Addresses Add(Addresses user);
    }
}
