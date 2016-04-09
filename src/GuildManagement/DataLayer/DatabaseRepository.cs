using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuildManagement.Framework;
using System.Collections.Concurrent;

namespace GuildManagement.DataLayer
{
    public class DatabaseRepository : IDatabaseRepository
    {
        static ConcurrentDictionary<string, Guild> _guilds = new ConcurrentDictionary<string, Guild>();
        static ConcurrentDictionary<string, Character> _characters = new ConcurrentDictionary<string, Character>();



        public DatabaseRepository()
        {
            Add(new Guild() { Name = "Windburst" });
            Add(new Character() { Name = "TestToon" } );
        }

        #region Guilds
        public IEnumerable<Guild> GetAllGuilds()
        {
            return _guilds.Values;
        }

        public Guild GetGuild(string key)
        {
            Guild guild;
            _guilds.TryGetValue(key, out guild);

            return guild;
        }

        public IEnumerable<Guild> Add(Guild guild)
        {
            guild.Key = Guid.NewGuid().ToString();
            _guilds[guild.Key] = guild;

            return GetAllGuilds();
        }

        public IEnumerable<Guild> Update(string key, Guild guild)
        {
            _guilds[key] = guild;

            return GetAllGuilds();
        }

        public IEnumerable<Guild> DeleteGuild(string key)
        {
            Guild guild;
            _guilds.TryGetValue(key, out guild);
            _guilds.TryRemove(key, out guild);

            return GetAllGuilds();
        }
        #endregion

        #region Characters
        public IEnumerable<Character> GetAllCharacters()
        {
            return _characters.Values;
        }

        public Character GetCharacter(string key)
        {
            Character character;
            _characters.TryGetValue(key, out character);

            return character;
        }

        public IEnumerable<Character> Add(Character character)
        {
            character.Key = Guid.NewGuid().ToString();
            _characters[character.Key] = character;

            return GetAllCharacters();
        }

        public IEnumerable<Character> Update(string key, Character character)
        {
            _characters[key] = character;

            return GetAllCharacters();
        }

        public IEnumerable<Character> DeleteCharacter(string key)
        {
            Character character;
            _characters.TryGetValue(key, out character);
            _characters.TryRemove(key, out character);

            return GetAllCharacters();
        }
        #endregion
    }
}
