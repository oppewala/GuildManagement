using GuildManagement.DataLayer;
using GuildManagement.Framework;
using System.Collections.Generic;

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

        public IEnumerable<Guild> DownloadFromBlizzard(string name, string realm)
        {
            Guild guild = _blizzardConnectionRepository.GetGuild(name, realm, getMembers: true);
            return Add(guild);
        }
    }
}
