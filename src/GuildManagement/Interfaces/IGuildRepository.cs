using System.Collections.Generic;
using GuildManagement.Framework;

namespace GuildManagement.Business
{
    public interface IGuildRepository
    {
        IEnumerable<Guild> Add(Guild guild);
        IEnumerable<Guild> GetAllGuilds();
        Guild GetGuild(string key);
        Guild GetGuild(string realm, string name);
        IEnumerable<Guild> Delete(string key);
        IEnumerable<Guild> Update(string key, Guild guild);
    }
}
