using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDependencyResolvers
            (this IServiceCollection serviceColetions, ICoreModule[] modules)
        {
            foreach (var modul in modules)
            {
                modul.Load(serviceColetions);
            }

            return ServiceTool.Create(serviceColetions);
        }
    }
}
