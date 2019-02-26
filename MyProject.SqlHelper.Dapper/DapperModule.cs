using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyProject.SqlHelper.Dapper
{
    public class DapperModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var ass = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(ass).AsImplementedInterfaces().AsSelf().InstancePerLifetimeScope();
        }
    }
}
