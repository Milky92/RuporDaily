using Microsoft.Extensions.Options;
using Rupor.DataAccess.RavenDb.Collections;
using Rupor.DataAccess.RavenDb.Context;
using Rupor.DataAccess.RavenDb.Settings;
using Rupor.DataAccess.RavenDb.Utils;
using Rupor.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rupor.DataAccess.Context
{
    public class DataContext : RavenDbContext, IDatabaseContext
    {

        public EntityCollection<Topic> Topics { get; set; }
        public EntityCollection<Article> Articles { get; set; }

        public DataContext(IServiceProvider serviceProvider, IOptions<DatabaseOptions> options)
            : base(serviceProvider, options) { }

        public DataContext(RavenTransaction ravenTransaction)
            : base(ravenTransaction) { }
    }
}
