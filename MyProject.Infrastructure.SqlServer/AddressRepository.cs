using MyProject.Core.Core;
using MyProject.Core.Entitys;
using MyProject.Core.Repositorys;
using System;
using System.Collections.Generic;
//using System.Data.SqlClient;
using System.Text;

namespace MyProject.Infrastructure.SqlServer
{
    public class AddressRepository: IntRepository<Addresses>, IAddressRepository
    {
        public AddressRepository(UnitOfWork unitOfWork,ISqlHelper sqlHelper):base(unitOfWork,sqlHelper)
        {
            _unitOfWork = unitOfWork;
        }
        public Addresses Add(Addresses address)
        {
            var sql = "INSERT INTO [Address] ( UserId, Address, Area) VALUES (@UserId,@Address,@Area)";
            var parameters = new { UserId = address.Id, Address = address.Address, Area = address.Area };
            _sqlHelper.Execute(_unitOfWork.Connection, sql, parameters);
            address.Id = 2;
            return address;

        }
    }
}
