using Microsoft.Extensions.Options;
using Raven.Client.Documents;
using Raven.Client.Documents.Conventions;
using Raven.Client.Documents.Operations.Expiration;
using Raven.Client.Documents.Session;
using Raven.Client.ServerWide;
using Raven.Client.ServerWide.Operations;
using Rupor.DataAccess.RavenDb.Collections;
using Rupor.DataAccess.RavenDb.Context;
using Rupor.DataAccess.RavenDb.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rupor.DataAccess.RavenDb.Utils
{
    public class RavenDatabase : IRavenDatabase
    {
        private readonly DatabaseOptions _options;
        private IDocumentStore _store;
        private int _initCount;

        public RavenDatabase(IOptions<DatabaseOptions> options)
        {
            _options = options.Value;
        }

        public async Task<IAsyncDocumentSession> IntializeAsync(RaveDbContext context)
        {
            if (Interlocked.Increment(ref _initCount) <= 1)
            {
                _store = CreateStore(context);
                try
                {
                    await _store.Maintenance
                        .Server
                        .SendAsync(new CreateDatabaseOperation(new DatabaseRecord(_store.Database)));

                    await _store.Maintenance.SendAsync(new ConfigureExpirationOperation(new ExpirationConfiguration
                    {
                        DeleteFrequencyInSec = null,
                        Disabled = false
                    }));
                }
                catch (Exception)
                {
                    // if try create database, ignore
                }
            }

            return _store.OpenAsyncSession(new SessionOptions
            {
                NoCaching = _options.NoCaching,
                NoTracking = _options.NoTracking
            });
        }

        public RavenTransaction BeginTransaction()
            => RavenTransaction.Create(_store);

        private IDocumentStore CreateStore(RaveDbContext context)
        {
            var collections = context.GetType().GetProperties()
                .Where(p => p.PropertyType.IsGenericType &&
                p.PropertyType.GetGenericTypeDefinition() == typeof(EntityCollection<>))
                .Select(p => new { type = p.PropertyType.GenericTypeArguments.FirstOrDefault(), p.Name });

            return new DocumentStore
            {
                Urls = _options.Urls,
                Conventions =
                {
                     MaxNumberOfRequestsPerSession = _options.MaxReqeustPerSession,
                     UseOptimisticConcurrency = _options.UseOptimisticConcurrency,
                     FindCollectionName = type=>
                     {
                         var item = collections.FirstOrDefault(c=>c.type==type);
                         return item is { } ? item.Name:DocumentConventions.DefaultGetCollectionName(type);
                     }
                },
                Database = _options.DataBase

            }.Initialize();

        }
    }
}
