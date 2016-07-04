using System.Collections.Generic;
using GuildManagement.Framework;

namespace GuildManagement.Business
{
    public interface IGuildRepository
    {
        IEnumerable<Guild> Add(Guild guild);
        IEnumerable<Guild> GetAllGuilds();
        Guild GetGuild(string key);
        IEnumerable<Guild> Delete(string key);
        IEnumerable<Guild> Update(string key, Guild guild);

        IEnumerable<Guild> DownloadFromBlizzard(string name, string realm);
    }
}
