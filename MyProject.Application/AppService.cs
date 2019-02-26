using AutoMapper;
using MyProject.Core.Dependency;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.Application
{
    public abstract class AppService : IAppService, IScopedDependency
    {
        protected IMapper _mapper;
        public AppService(IMapper mapper)
        {
            _mapper = mapper;
        }
    }
}
