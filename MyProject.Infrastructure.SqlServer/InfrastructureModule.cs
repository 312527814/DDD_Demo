using Autofac;
using MyProject.Core.Dependency;
using MyProject.Core.Uow;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.Infrastructure.SqlServer
{
    public class InfrastructureModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var ass = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(ass).AsImplementedInterfaces().AsSelf().InstancePerLifetimeScope();
            //builder.RegisterAssemblyTypes(ass).As<IScopedDependency>().AsImplementedInterfaces().AsSelf().InstancePerLifetimeScope();
            //builder.RegisterAssemblyTypes(ass).As<ISingletonDependency>().AsImplementedInterfaces().AsSelf().InstancePerLifetimeScope();
            //builder.RegisterAssemblyTypes(ass).As<ITransientDependency>().AsImplementedInterfaces().AsSelf().InstancePerLifetimeScope();

            //builder.RegisterAssemblyTypes(ass).Where(w => w.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();
            //builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();

        }

        
    }
}
