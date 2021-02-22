using System;
using System.Threading;
using System.Threading.Tasks;
using Rupor.DataAccess.RavenDb.Collections;
using Rupor.Domain.Models;

namespace Rupor.DataAccess.Context
{
    public interface IDatabaseContext 
    {
        #region collections

        EntityCollection<Topic> Topics { get; set; }

        EntityCollection<Article> Articles { get; set; }

        #endregion

        Task SaveChangesAsync(CancellationToken token = default);
    }
}