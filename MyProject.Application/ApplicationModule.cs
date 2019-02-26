using Autofac;
using MyProject.Core.Dependency;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.Application
{
   public class ApplicationModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var ass = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(ass).As<IScopedDependency>().AsImplementedInterfaces().AsSelf().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(ass).As<ISingletonDependency>().AsImplementedInterfaces().AsSelf().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(ass).As<ITransientDependency>().AsImplementedInterfaces().AsSelf().InstancePerLifetimeScope();
        }
    }
}
