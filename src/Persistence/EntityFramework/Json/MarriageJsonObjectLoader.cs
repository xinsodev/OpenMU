// <copyright file="MarriageJsonObjectLoader.cs" company="MUnique">
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </copyright>

namespace MUnique.OpenMU.Persistence.EntityFramework.Json;

using MUnique.OpenMU.Persistence.EntityFramework.Model;

/// <summary>
/// A json object loader for <see cref="Marriage"/>s.
/// </summary>
public class MarriageJsonObjectLoader : JsonObjectLoader
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MarriageJsonObjectLoader"/> class.
    /// </summary>
    public MarriageJsonObjectLoader()
        : base(new JsonQueryBuilder(), new JsonObjectDeserializer(), new CachingReferenceHandler())
    {
    }
}