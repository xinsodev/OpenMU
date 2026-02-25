// <copyright file="CashShopPointInfoAction.cs" company="MUnique">
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </copyright>

namespace MUnique.OpenMU.GameLogic.PlayerActions.CashShop;

using MUnique.OpenMU.GameLogic.Views.CashShop;

/// <summary>
/// Action to get cash shop points.
/// </summary>
public class CashShopPointInfoAction
{
    /// <summary>
    /// Set cash shop point info.
    /// </summary>
    /// <param name="player">The player.</param>
    public async ValueTask SetPointInfoAsync(Player player)
    {
        var account = player.Account;

        if (account is not null)
        {
            await player.InvokeViewPlugInAsync<ICashShopPointInfoResponsePlugIn>(p => p.CashShopPointInfoAsync(0, account.WCoinC, account.WCoinC, account.WCoinP, account.WCoinP, account.GoblinPoints)).ConfigureAwait(false);
        }
        else
        {
            await player.InvokeViewPlugInAsync<ICashShopPointInfoResponsePlugIn>(p => p.CashShopPointInfoAsync(0, 0, 0, 0, 0, 0)).ConfigureAwait(false);
        }
    }
}