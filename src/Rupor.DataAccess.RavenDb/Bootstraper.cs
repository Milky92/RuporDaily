using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rupor.DataAccess.RavenDb.Settings;
using Rupor.DataAccess.RavenDb.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rupor.DataAccess.RavenDb
{
    public static class Bootstrapper
    {
        private const string _DefaulstSection = "App:Database:RavenDb";

        public static IServiceCollection AddRavenDb
            (
            this IServiceCollection services,
            IConfiguration config,
            string section = _DefaulstSection
            )
        => services.Configure<DatabaseOptions>(opts => config.GetSection(section).Bind(opts))
            .AddSingleton<RavenDatabase>();
            
    }
}
