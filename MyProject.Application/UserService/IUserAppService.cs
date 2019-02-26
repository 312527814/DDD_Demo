using AspectCore.DynamicProxy;
using MyProject.Application.UserService.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.Application.UserService
{
    //[ServiceInterceptor(typeof(CustomInterceptor))]
    public interface IUserAppService: IAppService
    {
        //[CustomInterceptor]
        void Add(UserDto put);
        [CustomInterceptor]
        void GetScore(int id);
    }
}
