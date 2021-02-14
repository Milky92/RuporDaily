using Raven.Client.Documents.Session;
using Rupor.DataAccess.RavenDb.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rupor.DataAccess.RavenDb.Utils
{
    interface IRavenDatabase
    {
        Task<IAsyncDocumentSession> IntializeAsync(RaveDbContext context);
    }
}
