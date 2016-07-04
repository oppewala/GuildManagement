using GuildManagement.DataLayer;
using GuildManagement.DataModel;
using GuildManagement.Framework;
using Microsoft.AspNet.DataProtection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildManagement.Business
{
    public class CharacterRepository : ICharacterRepository
    {
        GuildManagementContext _guildContext;
        IBlizzardConnectionRepository _blizzardConnectionRepository;

        public CharacterRepository(GuildManagementContext guildContext, IBlizzardConnectionRepository blizzardConnectionRepository)
        {
            _guildContext = guildContext;
            _blizzardConnectionRepository = blizzardConnectionRepository;
        }

        public IEnumerable<Character> GetAllCharacters()
        {
            return _guildContext.Characters.OrderBy(c => c.Realm).ThenBy(c => c.Name);
        }
        public IEnumerable<Character> GetCharactersByGuild(string guildKey)
        {
            return _guildContext.Characters.Where(c => c.Guild.Key == Guid.Parse(guildKey));
        }

        public IEnumerable<Character> Add(Character character)
        {
            _guildContext.Add(character);
            _guildContext.SaveChanges();

            return GetAllCharacters();
        }

        public Character GetCharacter(string key)
        {
            return _guildContext.Characters.FirstOrDefault(g => g.Key == Guid.Parse(key));
        }

        public IEnumerable<Character> Delete(string key)
        {
            Character character = GetCharacter(key);
            if (character == null)
            {
                return GetAllCharacters();
            }

            _guildContext.Remove(character);
            _guildContext.SaveChanges();

            return GetAllCharacters();
        }
        public IEnumerable<Character> DeleteByGuild(string guildKey)
        {
            _guildContext.RemoveRange(GetCharactersByGuild(guildKey));
            _guildContext.SaveChanges();

            return GetCharactersByGuild(guildKey);
        }

        public IEnumerable<Character> Update(string key, Character character)
        {
            Delete(key);
            Add(character);

            return GetAllCharacters();
        }

        public IEnumerable<Character> DownloadFromBlizzard(string name, string realm)
        {
            Character character = _blizzardConnectionRepository.GetCharacter(name, realm, getGuild: true);
            return Add(character);
        }
    }
}
