// <copyright file="MarriageContext.cs" company="MUnique">
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </copyright>

namespace MUnique.OpenMU.Persistence.EntityFramework;

using Microsoft.EntityFrameworkCore;
using MUnique.OpenMU.Persistence.EntityFramework.Model;

/// <summary>
/// Context to load instances of <see cref="Marriage"/>s.
/// </summary>
public class MarriageContext : DbContext
{
    /// <summary>
    /// Configures the model.
    /// </summary>
    /// <param name="modelBuilder">The model builder.</param>
    internal static void ConfigureModel(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Marriage>().ToTable(nameof(Marriage), SchemaNames.AccountData);
        modelBuilder.Entity<Marriage>(e =>
        {
            e.HasAlternateKey(f => new { f.CharacterId, f.PartnerId });

            e.HasOne<Character>()
                .WithOne()
                .HasForeignKey<Marriage>(f => f.CharacterId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            e.HasOne<Character>()
                .WithOne()
                .HasForeignKey<Marriage>(f => f.PartnerId)
                .OnDelete(DeleteBehavior.Cascade);
        });
    }

    /// <inheritdoc/>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        this.Configure(optionsBuilder);
    }

    /// <inheritdoc/>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ConfigureModel(modelBuilder);
        modelBuilder.Entity<CharacterName>().HasKey(f => f.Id);
    }
}