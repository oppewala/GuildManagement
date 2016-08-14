using GuildManagement.DataLayer;
using GuildManagement.DataModel;
using GuildManagement.Framework;
using Microsoft.AspNet.DataProtection;
using Microsoft.Data.Entity;
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
        IDatabaseConnectionRepository _databaseConnectionRepository;

        public CharacterRepository(IDatabaseConnectionRepository databaseConnectionRepository)
        {
            _databaseConnectionRepository = databaseConnectionRepository;
        }

        public IEnumerable<Character> GetAllCharacters()
        {
            return _databaseConnectionRepository.GetCharacters().OrderBy(c => c.Realm).ThenBy(c => c.Name);
        }
        public IEnumerable<Character> GetCharactersByGuild(string guildKey)
        {
            return _databaseConnectionRepository.GetCharacters().Where(c => c.Guild != null && c.Guild.Key == Guid.Parse(guildKey));
        }

        public IEnumerable<Character> Add(Character character)
        {
            _databaseConnectionRepository.AddCharacter(character);

            return GetAllCharacters();
        }

        public Character GetCharacter(string key)
        {
            return _databaseConnectionRepository.GetCharacters().FirstOrDefault(g => g.Key == Guid.Parse(key));
        }
        public Character GetCharacter(string realm, string name)
        {
            return _databaseConnectionRepository.GetCharacters().FirstOrDefault(g => g.Realm == realm && g.Name == name);
        }

        public IEnumerable<Character> Delete(string key)
        {
            Character character = GetCharacter(key);
            if (character == null)
            {
                return GetAllCharacters();
            }

            _databaseConnectionRepository.DeleteCharacter(character);

            return GetAllCharacters();
        }
        public IEnumerable<Character> DeleteByGuild(string guildKey)
        {
            _databaseConnectionRepository.DeleteCharacters(GetCharactersByGuild(guildKey));

            return GetCharactersByGuild(guildKey);
        }

        public IEnumerable<Character> Update(string key, Character character)
        {
            character.Key = Guid.Parse(key);

            Delete(key);
            Add(character);

            return GetAllCharacters();
        }
    }
}
