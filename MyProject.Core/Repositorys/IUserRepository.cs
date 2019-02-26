using MyProject.Core.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.Core.Repositorys
{
    public interface IUserRepository : IRepository<User, int>
    {
        User Add(User user);
        List<(User user, ReportCard reportCard)> getScore(int id);
    }
}
