using GuildManagement.DataLayer;
using GuildManagement.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildManagement.Business
{
    public class BlizzardSyncRepository : IBlizzardSyncRepository
    {
        IBlizzardConnectionRepository _blizzardConnectionRepository;
        ICharacterRepository _characterRepository;
        IGuildRepository _guildRepository;

        public BlizzardSyncRepository(IBlizzardConnectionRepository blizzardConnectionRepository, ICharacterRepository characterRepository, IGuildRepository guildRepository)
        {
            _blizzardConnectionRepository = blizzardConnectionRepository;
            _characterRepository = characterRepository;
            _guildRepository = guildRepository;
        }

        public Character RetrieveCharacter(string realm, string name)
        {
            Character character = _blizzardConnectionRepository.GetCharacter(name, realm, getGuild: true);
            Character oldCharacter = _characterRepository.GetCharacter(realm, name);

            if (character.Guild != null)
            {
                Guild guild = _guildRepository.GetGuild(character.Guild.Realm, character.Guild.Name);
                character.Guild = guild;
            }

            if (oldCharacter == null)
            {
                _characterRepository.Add(character);
            }
            else
            {
                character.Key = oldCharacter.Key;
                _characterRepository.Update(character.Key.ToString(), character);
            }

            return _characterRepository.GetCharacter(character.Key.ToString());
        }

        public Guild RetrieveGuild(string realm, string name)
        {
            Guild guild = _blizzardConnectionRepository.GetGuild(name, realm, getMembers: true);
            Guild oldGuild = _guildRepository.GetGuild(realm, name);

            if (guild.Members != null && guild.Members.Count > 0)
            {
                List<Character> existingMembers = new List<Character>();
                if (oldGuild != null)
                {
                    existingMembers = _characterRepository.GetCharactersByGuild(oldGuild.Key.ToString()).ToList();
                }

                foreach (Character character in guild.Members)
                {
                    Character existingCharacter = existingMembers.Find(c => c.Realm == character.Realm && c.Name == character.Name) ?? _characterRepository.GetCharacter(character.Realm, character.Name);
                    if (existingCharacter != null)
                    {
                        character.Key = existingCharacter.Key;
                    }
                }
            }

            if (oldGuild == null)
            {
                _guildRepository.Add(guild);
            }
            else
            {
                guild.Key = oldGuild.Key;
                _guildRepository.Update(guild.Key.ToString(), guild);
            }

            return _guildRepository.GetGuild(realm, name);
        }
    }
}
