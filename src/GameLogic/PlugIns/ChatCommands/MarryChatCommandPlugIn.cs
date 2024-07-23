// <copyright file="MarryChatCommandPlugIn.cs" company="MUnique">
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
// </copyright>

namespace MUnique.OpenMU.GameLogic.PlugIns.ChatCommands;

using System.Runtime.InteropServices;
using MUnique.OpenMU.GameLogic.PlugIns.ChatCommands.Arguments;
using MUnique.OpenMU.PlugIns;

/// <summary>
/// A chat command plugin which handles marry command.
/// </summary>
[Guid("DE6A9A8B-906D-4BEF-94C3-A9F9E59ABCDE")]
[PlugIn("Marry chat command", "Handles the chat command '/marry <characterName>'. Marry a character.")]
[ChatCommandHelp(Command, "Marry a character.", typeof(MarryChatCommandArgs), CharacterStatus.Normal)]
public class MarryChatCommandPlugIn : ChatCommandPlugInBase<MarryChatCommandArgs>
{
    private const string Command = "/marry";

    /// <inheritdoc />
    public override string Key => Command;

    /// <inheritdoc />
    public override CharacterStatus MinCharacterStatusRequirement => CharacterStatus.Normal;

    /// <inheritdoc />
    protected override async ValueTask DoHandleCommandAsync(Player player, MarryChatCommandArgs arguments)
    {
        if (string.IsNullOrEmpty(arguments.CharacterName))
        {
            throw new ArgumentException("Character name is required.");
        }

        var character = player.SelectedCharacter;

        if (character is null)
        {
            throw new ArgumentException("Character not found.");
        }

        var partner = player.GameContext.GetPlayerByCharacterName(arguments.CharacterName)?.SelectedCharacter;

        if (partner is null)
        {
            throw new ArgumentException("Character not found.");
        }

        if (character.Name == partner.Name)
        {
            throw new ArgumentException("You can't marry yourself.");
        }

        var characterMarriage = await player.PersistenceContext.GetMarriageByCharacterIdAsync(character.Id).ConfigureAwait(false);

        if (characterMarriage is not null) {
            if (characterMarriage.MarriedAt is not null)
            {
                throw new ArgumentException("You are already married.");
            }

            if (characterMarriage.PartnerId is null)
            {
                throw new ArgumentException("You already has a marriage proposal.");
            }
        }

        var partnerMarriage = await player.PersistenceContext.GetMarriageByCharacterIdAsync(partner.Id).ConfigureAwait(false);

        if (partnerMarriage is not null)
        {
            if (partnerMarriage.MarriedAt is not null)
            {
                throw new ArgumentException("Partner are already married.");
            }

            if (partnerMarriage.PartnerId is null)
            {
                throw new ArgumentException("Partner already has a marriage proposal.");
            }
        }
    }
}