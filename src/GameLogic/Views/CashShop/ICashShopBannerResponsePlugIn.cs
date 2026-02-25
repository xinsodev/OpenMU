// <copyright file="ICashShopBannerResponsePlugIn.cs" company="MUnique">
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </copyright>

namespace MUnique.OpenMU.GameLogic.Views.CashShop;

/// <summary>
/// Interface of a view whose implementation informs about the set cash shop banner version.
/// </summary>
public interface ICashShopBannerResponsePlugIn : IViewPlugIn
{
    /// <summary>
    /// Set cash shop banner version.
    /// </summary>
    /// <param name="zone">Banner zone.</param>
    /// <param name="year">Banner year.</param>
    /// <param name="yearId">Banner year identify.</param>
    ValueTask CashShopBannerAsync(ushort zone, ushort year, ushort yearId);
}