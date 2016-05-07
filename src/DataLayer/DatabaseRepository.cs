using System;
using System.Collections.Generic;
using GuildManagement.Framework;
using System.Collections.Concurrent;

namespace GuildManagement.DataLayer
{
    public class DatabaseRepository : IDatabaseRepository
    {
        static ConcurrentDictionary<Guid, Guild> _guilds = new ConcurrentDictionary<Guid, Guild>();
        static ConcurrentDictionary<Guid, Character> _characters = new ConcurrentDictionary<Guid, Character>();



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
            _guilds.TryGetValue(Guid.Parse(key), out guild);

            return guild;
        }

        public IEnumerable<Guild> Add(Guild guild)
        {
            guild.Key = Guid.NewGuid();
            _guilds[guild.Key] = guild;

            return GetAllGuilds();
        }

        public IEnumerable<Guild> Update(string key, Guild guild)
        {
            Guid guid = Guid.Parse(key);
            _guilds[guid] = guild;

            return GetAllGuilds();
        }

        public IEnumerable<Guild> DeleteGuild(string key)
        {
            Guild guild;
            _guilds.TryGetValue(Guid.Parse(key), out guild);
            _guilds.TryRemove(Guid.Parse(key), out guild);

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
            _characters.TryGetValue(Guid.Parse(key), out character);

            return character;
        }

        public IEnumerable<Character> Add(Character character)
        {
            character.Key = Guid.NewGuid();
            _characters[character.Key] = character;

            return GetAllCharacters();
        }

        public IEnumerable<Character> Update(string key, Character character)
        {
            _characters[Guid.Parse(key)] = character;

            return GetAllCharacters();
        }

        public IEnumerable<Character> DeleteCharacter(string key)
        {
            Character character;
            _characters.TryGetValue(Guid.Parse(key), out character);
            _characters.TryRemove(Guid.Parse(key), out character);

            return GetAllCharacters();
        }
        #endregion
    }
}
