// <copyright file="CashShopScriptAction.cs" company="MUnique">
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </copyright>

namespace MUnique.OpenMU.GameLogic.PlayerActions.CashShop;

using MUnique.OpenMU.GameLogic.Views.CashShop;

/// <summary>
/// Action to set cash shop script version.
/// </summary>
public class CashShopScriptAction
{
    /// <summary>
    /// Set cash shop script version.
    /// </summary>
    /// <param name="player">The player.</param>
    public async ValueTask SetCashShopScriptAsync(Player player)
    {
        await player.InvokeViewPlugInAsync<ICashShopScriptResponsePlugIn>(p => p.CashShopScriptAsync(512, 2012, 084)).ConfigureAwait(false);
    }
}