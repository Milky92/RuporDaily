using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rupor.DataAccess;
using Rupor.DataAccess.RavenDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rupor.Business
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddBusiness(this IServiceCollection services,
            IConfiguration configuration)
        => 
            services
            .AddRavenDb(configuration)
            .AddDataAccess(configuration);

    }
}
