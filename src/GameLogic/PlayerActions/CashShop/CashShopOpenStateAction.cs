// <copyright file="CashShopOpenStateAction.cs" company="MUnique">
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </copyright>

namespace MUnique.OpenMU.GameLogic.PlayerActions.CashShop;

using MUnique.OpenMU.GameLogic.Views.CashShop;

/// <summary>
/// Action to set cash shop open state.
/// </summary>
public class CashShopOpenStateAction
{
    /// <summary>
    /// Set cash shop open state.
    /// </summary>
    /// <param name="player">The player.</param>
    /// <param name="isOpened">Is cash shop opened.</param>
    public async ValueTask SetCashShopOpenStateAsync(Player player, bool isOpened)
    {
        if (player.IsWalking || !player.IsAtSafezone())
        {
            await player.InvokeViewPlugInAsync<ICashShopOpenStateResponsePlugIn>(p => p.CashShopOpenStateAsync(false)).ConfigureAwait(false);
            return;
        }

        await player.InvokeViewPlugInAsync<ICashShopOpenStateResponsePlugIn>(p => p.CashShopOpenStateAsync(!isOpened)).ConfigureAwait(false);
    }
}