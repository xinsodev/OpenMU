// <copyright file="ICashShopScriptResponsePlugIn.cs" company="MUnique">
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </copyright>

namespace MUnique.OpenMU.GameLogic.Views.CashShop;

/// <summary>
/// Interface of a view whose implementation informs about the set cash shop script version.
/// </summary>
public interface ICashShopScriptResponsePlugIn : IViewPlugIn
{
    /// <summary>
    /// Set cash shop script version.
    /// </summary>
    /// <param name="zone">Script zone.</param>
    /// <param name="year">Script year.</param>
    /// <param name="yearId">Script year identify.</param>
    ValueTask CashShopScriptAsync(ushort zone, ushort year, ushort yearId);
}