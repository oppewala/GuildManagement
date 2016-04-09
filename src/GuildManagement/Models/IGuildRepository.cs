using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuildManagement.Framework;

namespace GuildManagement.Models
{
    public interface IGuildRepository
    {
        IEnumerable<Guild> Add(Guild guild);
        IEnumerable<Guild> GetAllGuilds();
        Guild GetGuild(string key);
        IEnumerable<Guild> Delete(string key);
        IEnumerable<Guild> Update(string key, Guild guild);
        string APIKey();
    }
}
