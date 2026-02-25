// <copyright file="CashShopBannerAction.cs" company="MUnique">
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </copyright>

namespace MUnique.OpenMU.GameLogic.PlayerActions.CashShop;

using MUnique.OpenMU.GameLogic.Views.CashShop;

/// <summary>
/// Action to set cash shop banner version.
/// </summary>
public class CashShopBannerAction
{
    /// <summary>
    /// Set cash shop banner version.
    /// </summary>
    /// <param name="player">The player.</param>
    public async ValueTask SetCashShopBannerAsync(Player player)
    {
        await player.InvokeViewPlugInAsync<ICashShopBannerResponsePlugIn>(p => p.CashShopBannerAsync(583, 2011, 001)).ConfigureAwait(false);
    }
}