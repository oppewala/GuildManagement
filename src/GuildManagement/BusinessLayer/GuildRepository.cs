using GuildManagement.DataLayer;
using GuildManagement.DataModel;
using GuildManagement.Framework;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace GuildManagement.Models
{
    public class GuildRepository : IGuildRepository
    {
        IDatabaseRepository _databaseRepository;
        IBlizzardConnectionRepository _blizzardConnectionRepository;
        GuildManagementContext _guildContext;

        public GuildRepository(GuildManagementContext guildContext, IBlizzardConnectionRepository blizzardConnectionRepository)
        {
            _guildContext = guildContext;
            _databaseRepository = null;
            //_databaseRepository = databaseRepository;
            _blizzardConnectionRepository = blizzardConnectionRepository;
        }

        public IEnumerable<Guild> GetAllGuilds()
        {
            var guilds = _guildContext.Guilds.OrderBy(g => g.Key);

            return guilds;

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

        public IEnumerable<Guild> DownloadFromBlizzard(string name, string realm)
        {
            Guild guild = _blizzardConnectionRepository.GetGuild(name, realm, getMembers: true);
            return Add(guild);
        }
    }
}
