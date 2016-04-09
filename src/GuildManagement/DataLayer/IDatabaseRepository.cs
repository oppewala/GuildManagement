using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuildManagement.Framework;

namespace GuildManagement.DataLayer
{
    public interface IDatabaseRepository
    {
        IEnumerable<Guild> GetAllGuilds();
        Guild GetGuild(string key);
        IEnumerable<Guild> Add(Guild guild);
        IEnumerable<Guild> Update(string key, Guild guild);
        IEnumerable<Guild> Delete(string key);
    }
}
