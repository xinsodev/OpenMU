// <copyright file="CashShopOpenStateResponsePlugIn.cs" company="MUnique">
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </copyright>

namespace MUnique.OpenMU.GameServer.RemoteView.CashShop;

using System.Runtime.InteropServices;
using MUnique.OpenMU.GameLogic.Views.CashShop;
using MUnique.OpenMU.Network.Packets.ServerToClient;
using MUnique.OpenMU.PlugIns;

/// <summary>
/// The default implementation of the <see cref="ICashShopOpenStateResponsePlugIn"/> which is forwarding everything to the game client with specific data packets.
/// </summary>
[PlugIn]
[Display(Name = nameof(PlugInResources.CashShopOpenStateResponsePlugIn_Name), Description = nameof(PlugInResources.CashShopOpenStateResponsePlugIn_Description), ResourceType = typeof(PlugInResources))]
[Guid("EC942F99-99D8-42A8-8566-AE358B527F20")]
public class CashShopOpenStateResponsePlugIn : ICashShopOpenStateResponsePlugIn
{
    private readonly RemotePlayer _player;

    /// <summary>
    /// Initializes a new instance of the <see cref="CashShopOpenStateResponsePlugIn"/> class.
    /// </summary>
    /// <param name="player">The player.</param>
    public CashShopOpenStateResponsePlugIn(RemotePlayer player) => this._player = player;

    /// <inheritdoc/>
    public ValueTask CashShopOpenStateAsync(bool isOpened)
    {
        return this._player.Connection.SendCashShopOpenStateResponseAsync(isOpened);
    }
}