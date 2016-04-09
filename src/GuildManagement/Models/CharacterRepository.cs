using GuildManagement.DataLayer;
using GuildManagement.Framework;
using Microsoft.AspNet.DataProtection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildManagement.Models
{
    public class CharacterRepository : ICharacterRepository
    {
        IDatabaseRepository _databaseRepository;
        IBlizzardConnectionRepository _blizzardConnectionRepository;

        public CharacterRepository(IDatabaseRepository databaseRepository, IBlizzardConnectionRepository blizzardConnectionRepository)
        {
            _databaseRepository = databaseRepository;
            _blizzardConnectionRepository = blizzardConnectionRepository;
        }

        public IEnumerable<Character> GetAll()
        {
            return _databaseRepository.GetAllCharacters();
        }

        public IEnumerable<Character> Add(Character character)
        {
            return _databaseRepository.Add(character);
        }

        public Character GetByKey(string key)
        {
            return _databaseRepository.GetCharacter(key);
        }

        public IEnumerable<Character> Delete(string key)
        {

            return _databaseRepository.DeleteCharacter(key);
        }

        public IEnumerable<Character> Update(string key, Character character)
        {
            return _databaseRepository.Update(key, character);
        }

        public IEnumerable<Character> DownloadFromBlizzard(string name, string realm)
        {
            Character character = _blizzardConnectionRepository.GetCharacter(name, realm, getGuild: true);
            return Add(character);
        }
    }
}
