// <copyright file="ICashShopOpenStateResponsePlugIn.cs" company="MUnique">
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </copyright>

namespace MUnique.OpenMU.GameLogic.Views.CashShop;

/// <summary>
/// Interface of a view whose implementation informs about the set cash shop open state.
/// </summary>
public interface ICashShopOpenStateResponsePlugIn : IViewPlugIn
{
    /// <summary>
    /// Set cash shop open state.
    /// </summary>
    /// <param name="isOpened">Is cash shop opened.</param>
    ValueTask CashShopOpenStateAsync(bool isOpened);
}