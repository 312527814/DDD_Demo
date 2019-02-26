using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Application
{
    public static class AppExtensionManager
    {
        public static Task<TResult> Run<TResult>(this IAppService service, Func<TResult> func)
        {
            return Task.Run(() =>
            {
                return func();
            });
        }

        public static Task Run(this IAppService service, Action func)
        {
            return Task.Run(() =>
            {
                func();
            });
        }
    }
}
