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

        public DatabaseRepository()
        {
            Add(new Guild() { Name = "Windburst" });
        }

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

        public IEnumerable<Guild> Delete(string key)
        {
            Guild guild;
            _guilds.TryGetValue(key, out guild);
            _guilds.TryRemove(key, out guild);

            return GetAllGuilds();
        }
    }
}
