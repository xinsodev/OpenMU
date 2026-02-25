// <copyright file="CashShopPointInfoRequestHandlerPlugIn.cs" company="MUnique">
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </copyright>

namespace MUnique.OpenMU.GameServer.MessageHandler.CashShop;

using System.Runtime.InteropServices;
using MUnique.OpenMU.GameLogic;
using MUnique.OpenMU.GameLogic.PlayerActions.CashShop;
using MUnique.OpenMU.Network.Packets.ClientToServer;
using MUnique.OpenMU.PlugIns;

/// <summary>
/// Packet handler which gets the cash shop point info (D2 01).
/// </summary>
[PlugIn]
[Display(Name = nameof(PlugInResources.CashShopPointInfoRequestHandlerPlugIn_Name), Description = nameof(PlugInResources.CashShopPointInfoRequestHandlerPlugIn_Description), ResourceType = typeof(PlugInResources))]
[Guid("359CFCBB-F05D-441D-92FE-6E98E38A21D3")]
[BelongsToGroup(CashShopGroupHandlerPlugIn.GroupKey)]
internal class CashShopPointInfoRequestHandlerPlugIn : ISubPacketHandlerPlugIn
{
    private readonly CashShopPointInfoAction _cashShopPointInfoAction = new();

    /// <inheritdoc/>
    public bool IsEncryptionExpected => false;

    /// <inheritdoc/>
    public byte Key => CashShopPointInfoRequest.SubCode;

    /// <inheritdoc/>
    public async ValueTask HandlePacketAsync(Player player, Memory<byte> packet)
    {
        await this._cashShopPointInfoAction.SetPointInfoAsync(player).ConfigureAwait(false);
    }
}