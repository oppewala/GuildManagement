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
    public class GuildRepository : IGuildRepository
    {
        IDatabaseRepository _databaseRepository;
        IBlizzardConnectionRepository _blizzardConnectionRepository;

        public GuildRepository(IDatabaseRepository databaseRepository, IBlizzardConnectionRepository blizzardConnectionRepository)
        {
            _databaseRepository = databaseRepository;
            _blizzardConnectionRepository = blizzardConnectionRepository;
        }

        public IEnumerable<Guild> GetAllGuilds()
        {
            return _databaseRepository.GetAllGuilds();
        }

        public IEnumerable<Guild> Add(Guild guild)
        {
            return _databaseRepository.Add(guild);
        }

        public Guild GetGuild(string key)
        {
            return _databaseRepository.GetGuild(key);
        }

        public IEnumerable<Guild> Delete(string key)
        {
            
            return _databaseRepository.DeleteGuild(key);
        }

        public IEnumerable<Guild> Update(string key, Guild guild)
        {
            return _databaseRepository.Update(key, guild);
        }
    }
}
