// <copyright file="Marriage.cs" company="MUnique">
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </copyright>

namespace MUnique.OpenMU.DataModel.Entities;

/// <summary>
/// The Character Status of a player.
/// </summary>
public enum MarriageCoodinate : int
{
    /// <summary>
    /// The min x.
    /// </summary>
    MinX = 12,

    /// <summary>
    /// The max x.
    /// </summary>
    MaxX = 15,

    /// <summary>
    /// The min y.
    /// </summary>
    MinY = 23,

    /// <summary>
    /// The max y.
    /// </summary>
    MaxY = 28,
}

/// <summary>
/// The marriage.
/// </summary>
public class Marriage
{
    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the id of the character.
    /// </summary>
    public Guid CharacterId { get; set; }

    /// <summary>
    /// Gets or sets the id of the partner.
    /// </summary>
    public Guid? PartnerId { get; set; }

    /// <summary>
    /// Gets or sets a value indicating when the marriage request was accepted.
    /// </summary>
    public DateTime? MarriedAt { get; set; }
}