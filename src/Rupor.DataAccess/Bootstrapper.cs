using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rupor.DataAccess.Context;
using Rupor.DataAccess.RavenDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rupor.DataAccess
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddRavenDb(configuration)
                .AddTransient<IDatabaseContext,DataContext>();
                
        }
    }
}
