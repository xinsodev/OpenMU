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
    /// <summary>
    /// The default map for marriage.
    /// </summary>
    private const ushort Devias = 2;

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

        var target = player.GameContext.GetPlayerByCharacterName(arguments.CharacterName)?.SelectedCharacter;

        if (target is null)
        {
            throw new ArgumentException("Character not found.");
        }

        if (character.Name == target.Name)
        {
            throw new ArgumentException("You can not marry yourself 0,0!");
        }

        var characterMarriage = await player.PersistenceContext.GetMarriageByCharacterIdAsync(character.Id).ConfigureAwait(false);

        if (characterMarriage is not null)
        {
            if (characterMarriage.PartnerId is not null)
            {
                throw new ArgumentException("You are already married!");
            }
        }

        var targetMarriage = await player.PersistenceContext.GetMarriageByCharacterIdAsync(target.Id).ConfigureAwait(false);

        if (targetMarriage is not null)
        {
            if (targetMarriage.PartnerId is not null)
            {
                throw new ArgumentException("The other character is already married!");
            }
        }

        if (player.CurrentMap?.MapId == Devias)
        {
            if (character.PositionX < (int)MarriageCoodinate.MinX ||
                character.PositionX > (int)MarriageCoodinate.MaxX ||
                character.PositionY < (int)MarriageCoodinate.MinY ||
                character.PositionY > (int)MarriageCoodinate.MaxY)
            {
                throw new ArgumentException("You need to stand on the correct position in Devias2!");
            }

            if (target.PositionX < (int)MarriageCoodinate.MinX ||
                target.PositionX > (int)MarriageCoodinate.MaxX ||
                target.PositionY < (int)MarriageCoodinate.MinY ||
                target.PositionY > (int)MarriageCoodinate.MaxY)
            {
                throw new ArgumentException("Your target need to stand on the correct position in Devias2!");
            }
        }
    }
}