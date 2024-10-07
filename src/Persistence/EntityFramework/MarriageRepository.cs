// <copyright file="MarriageRepository.cs" company="MUnique">
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </copyright>

namespace MUnique.OpenMU.Persistence.EntityFramework;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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

    /// <summary>
    /// Gets the marriage by character id.
    /// </summary>
    /// <param name="characterId">The character id.</param>
    /// <returns>The marriage, if exist. Otherwise, null.</returns>
    internal async ValueTask<DataModel.Entities.Marriage?> GetMarriageByCharacterIdAsync(Guid characterId)
    {
        using var context = this.GetContext();

        var marriage = await context.Context.Set<Marriage>()
           .AsNoTracking()
           .FirstOrDefaultAsync(a => a.CharacterId == characterId || a.PartnerId == characterId).ConfigureAwait(false);

        if (marriage != null)
        {
            return await this.GetByIdAsync(marriage.Id).ConfigureAwait(false);
        }

        return null;
    }
}