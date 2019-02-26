using MyProject.Core.Repositorys;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;
using MyProject.Core.Entitys;
using MyProject.Core.Dependency;

namespace MyProject.Core
{
    public class UserDomain:IDomain
    {
        IUserRepository _userRepository;
        IAddressRepository _addressRepository;
        public UserDomain(IUserRepository userRepository, IAddressRepository addressRepository)
        {
            _userRepository = userRepository;
            _addressRepository = addressRepository;
        }
        public void get()
        {
            // _teacherRepository.Get(1);

            _userRepository.Add(new User { Name = "测试", Age = 22 });

        }

        public void Add(User user)
        {
            _userRepository.Insert(user);
        }

        public IList<(User user, ReportCard reportCard)> GetScore(int id)
        {
            return _userRepository.getScore(id);
        }
    }
}
