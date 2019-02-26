using AspectCore.DynamicProxy;
using MyProject.Core.Uow;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Application
{
    public class CustomInterceptor : AbstractInterceptor
    {
        public override Task Invoke(AspectContext context, AspectDelegate next)
        {
            var uow = context.ServiceProvider.GetService(typeof(IUnitOfWork)) as IUnitOfWork;
            try
            {
                context.Invoke(next);
            }
            finally
            {
                if (uow.Active)
                {
                    uow.Dispose();
                }
            }


            return Task.CompletedTask;
        }
    }
}
