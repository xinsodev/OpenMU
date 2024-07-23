// <copyright file="MarriageRepository.cs" company="MUnique">
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </copyright>

namespace MUnique.OpenMU.Persistence.EntityFramework;

using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MUnique.OpenMU.Persistence.EntityFramework.Json;
using MUnique.OpenMU.Persistence.EntityFramework.Model;

/// <summary>
/// Repository for marriages.
/// </summary>
internal class MarriageRepository : CachingGenericRepository<Marriage>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MarriageRepository" /> class.
    /// </summary>
    /// <param name="repositoryProvider">The repository provider.</param>
    /// <param name="loggerFactory">The logger factory.</param>
    public MarriageRepository(IContextAwareRepositoryProvider repositoryProvider, ILoggerFactory loggerFactory)
        : base(repositoryProvider, loggerFactory)
    {
    }

    /// <inheritdoc />
    public override async ValueTask<Marriage?> GetByIdAsync(Guid id)
    {
        (this.RepositoryProvider as ICacheAwareRepositoryProvider)?.EnsureCachesForCurrentGameConfiguration();

        using var context = this.GetContext();
        await context.Context.Database.OpenConnectionAsync().ConfigureAwait(false);
        try
        {
            var marriageEntry = context.Context.ChangeTracker.Entries<Marriage>().FirstOrDefault(a => a.Entity.Id == id);
            var marriage = marriageEntry?.Entity;

            if (marriage is null || marriageEntry?.References.Any(reference => !reference.IsLoaded) is true)
            {
                if (marriage is not null)
                {
                    context.Detach(marriage);
                }

                var objectLoader = new MarriageJsonObjectLoader();
                marriage = await objectLoader.LoadObjectAsync<Marriage>(id, context.Context).ConfigureAwait(false);
                if (marriage != null && !(context.Context.Entry(marriage) is { } entry && entry.State != EntityState.Detached))
                {
                    context.Context.Attach(marriage);
                }
            }

            return marriage;
        }
        finally
        {
            await context.Context.Database.CloseConnectionAsync().ConfigureAwait(false);
        }
    }

    /// <summary>
    /// Gets the marriage by character id.
    /// </summary>
    /// <param name="characterId">The character id.</param>
    /// <returns>The marriage Otherwise, null.</returns>
    internal async ValueTask<DataModel.Entities.Marriage?> GetMarriageByCharacterIdAsync(Guid characterId)
    {
        using var context = this.GetContext();

        var marriage = await context.Context.Set<Marriage>()
           .Select(a => new { a.Id, a.CharacterId, a.PartnerId, a.MarriedAt })
           .AsNoTracking()
           .FirstOrDefaultAsync(a => a.CharacterId == characterId || a.PartnerId == characterId).ConfigureAwait(false);

        if (marriage != null)
        {
            return await this.GetByIdAsync(marriage.Id).ConfigureAwait(false);
        }

        return null;
    }
}