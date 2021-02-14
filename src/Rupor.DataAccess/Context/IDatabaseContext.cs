using System;
using System.Threading;
using System.Threading.Tasks;
using Rupor.DataAccess.Collections;
using Rupor.Domain.Models;

namespace Rupor.DataAccess.Context
{
    public interface IDatabaseContext : IDisposable
    {
        #region collections

        IEntityCollection<Topics> Topics { get; set; }

        #endregion

        Task SaveChangesAsync(CancellationToken token = default);
    }
}