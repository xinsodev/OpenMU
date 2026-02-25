// <copyright file="CashShopOpenStateRequestHandlerPlugIn.cs" company="MUnique">
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </copyright>

namespace MUnique.OpenMU.GameServer.MessageHandler.CashShop;

using System.Runtime.InteropServices;
using MUnique.OpenMU.GameLogic;
using MUnique.OpenMU.GameLogic.PlayerActions.CashShop;
using MUnique.OpenMU.Network.Packets.ClientToServer;
using MUnique.OpenMU.PlugIns;

/// <summary>
/// Packet handler which opens/closes the cash shop (D2 02).
/// </summary>
[PlugIn]
[Display(Name = nameof(PlugInResources.CashShopOpenStateRequestHandlerPlugIn_Name), Description = nameof(PlugInResources.CashShopOpenStateRequestHandlerPlugIn_Description), ResourceType = typeof(PlugInResources))]
[Guid("2EE11F01-9590-49A8-88FD-410404DE9AB7")]
[BelongsToGroup(CashShopGroupHandlerPlugIn.GroupKey)]
internal class CashShopOpenStateRequestHandlerPlugIn : ISubPacketHandlerPlugIn
{
    private readonly CashShopOpenStateAction _cashShopOpenStateAction = new();

    /// <inheritdoc/>
    public bool IsEncryptionExpected => false;

    /// <inheritdoc/>
    public byte Key => CashShopOpenStateRequest.SubCode;

    /// <inheritdoc/>
    public async ValueTask HandlePacketAsync(Player player, Memory<byte> packet)
    {
        CashShopOpenStateRequest request = packet;
        await this._cashShopOpenStateAction.SetCashShopOpenStateAsync(player, request.IsOpened).ConfigureAwait(false);
    }
}