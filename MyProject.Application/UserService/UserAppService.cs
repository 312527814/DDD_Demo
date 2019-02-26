using AutoMapper;
using MyProject.Application.UserService.Dto;
using MyProject.Core;
using MyProject.Core.Entitys;
using MyProject.Core.Repositorys;
using MyProject.Core.Uow;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.Application.UserService
{
    public class UserAppService : AppService, IUserAppService
    {
        public static List<IUnitOfWork> List = new List<IUnitOfWork>();
        UserDomain _userDomain;
        IUnitOfWork _unitOfWork;
        IUserRepository _userRepository;
        public UserAppService(IMapper mapper, UserDomain userDomain, IUnitOfWork unitOfWork, IUserRepository userRepository) : base(mapper)
        {
            List.Add(unitOfWork);
            _userDomain = userDomain;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }
        public void Add(UserDto put)
        {
            using (_unitOfWork) {
                var user = _mapper.Map<User>(put); //映射
            }
              //  var user = _mapper.Map<User>(put); //映射
            //_userDomain.Add(user);
            //_userDomain.get();
        }

        public void GetScore(int id)
        {
            var s = _userDomain.GetScore(id);
            var sss = new List<GetScoreOutDto>();
            var ss = _mapper.Map<List<GetScoreOutDto>>(s);
            //using (_unitOfWork)
            //{
                _unitOfWork.BeginTransaction();
                _userRepository.Add(new User());
                _unitOfWork.Commit();
            //}
        }

    }

}
