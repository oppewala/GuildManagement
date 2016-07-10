using GuildManagement.DataLayer;
using GuildManagement.DataModel;
using GuildManagement.Framework;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GuildManagement.Business
{
    public class GuildRepository : IGuildRepository
    {
        IBlizzardConnectionRepository _blizzardConnectionRepository;
        IDatabaseConnectionRepository _databaseConnectionRepository;

        public GuildRepository(IDatabaseConnectionRepository databaseConnectionRepository, IBlizzardConnectionRepository blizzardConnectionRepository)
        {
            _databaseConnectionRepository = databaseConnectionRepository;
            _blizzardConnectionRepository = blizzardConnectionRepository;
        }

        public IEnumerable<Guild> GetAllGuilds()
        {
            return _databaseConnectionRepository.GetGuilds().OrderBy(g => g.Realm).ThenBy(g => g.Name);
        }

        public Guild GetGuild(string key)
        {
            return _databaseConnectionRepository.GetGuilds().FirstOrDefault(g => g.Key == Guid.Parse(key));
        }
        public Guild GetGuild(string realm, string name)
        {
            return _databaseConnectionRepository.GetGuilds().FirstOrDefault(g => g.Realm == realm && g.Name == name);
        }

        public IEnumerable<Guild> Add(Guild guild)
        {
            Guild oldGuild = GetGuild(guild.Realm, guild.Name);
            if (oldGuild != null)
            {
                Update(oldGuild.Key.ToString(), guild);
            }
            else
            {
                _databaseConnectionRepository.AddGuild(guild);
            }

            return GetAllGuilds();
        }

        public IEnumerable<Guild> Delete(string key)
        {
            Guild guild = GetGuild(key);
            if (guild == null)
            {
                return GetAllGuilds();
            }

            ICharacterRepository characterRepository = new CharacterRepository(_databaseConnectionRepository);
            IEnumerable<Character> chars = characterRepository.DeleteByGuild(key);

            _databaseConnectionRepository.DeleteGuild(guild);

            return GetAllGuilds();
        }

        public IEnumerable<Guild> Update(string key, Guild guild)
        {
            Delete(key);
            guild.Key = Guid.Parse(key);

            Add(guild);

            return GetAllGuilds();
        }
    }
}
