using MyProject.Core;
using MyProject.Core.Core;
using MyProject.Core.Entitys;
using MyProject.Core.Repositorys;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Linq;

namespace MyProject.Infrastructure.SqlServer
{
    public class UserRepository : IntRepository<User>, IUserRepository
    {
        public UserRepository(UnitOfWork unitOfWork, ISqlHelper sqlHelper) : base(unitOfWork, sqlHelper)
        {

        }
        public User Add(User user)
        {
            //base.Insert(user);
            //var sql = "INSERT INTO [USER] ( Name, Age) VALUES (@Name,@Age)";
            //var parameters = new { Name = user.Name, Age = user.Age };
            //dapperHelper.Execute(sql, parameters);
            //user.Id = 2;
            var sql = "UPDATE dbo.[User] SET Name='李四' WHERE Id=1";
            _sqlHelper.Execute(_unitOfWork.Connection, sql);

            return user;
        }

        public List<(User user, ReportCard reportCard)> getScore(int id)
        {

            //          var sql = @"select  u.*, rc.*  from ReportCard rc 
            //inner join[User] u on rc.UserId = u.Id
            //where rc.UserId = @UserId";
            //          var param = new { UserId = id };
            //          using (var conn = new SqlConnection(_connectionString.Master))
            //          {
            //              return _sqlHelper.Query<User, ReportCard>(conn, sql, param).ToList();

            //          }

            var sql = @"select u.*, rc.* from ReportCard rc 
                  inner join [User] u on rc.UserId = u.Id
            where u.Name = @UserName";
            var param = new { UserName = "1' OR '1' = '1" };
            //return _sqlHelper.Query<User, ReportCard>(conn, sql, param).ToList
            var comm = new SqlCommand(sql, _unitOfWork.Connection as SqlConnection);
            comm.Parameters.Add(new SqlParameter("@UserName", "张三 ' or 1= '1"));
            SqlDataAdapter adapter = new SqlDataAdapter(comm);

            System.Data.DataSet dataset = new System.Data.DataSet();

            //如果不指定表名，则系统自动使用默认的表名

            adapter.Fill(dataset);
            return null;
        }

    }


}
