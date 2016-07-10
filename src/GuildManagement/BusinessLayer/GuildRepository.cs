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
        GuildManagementContext _guildContext;

        public GuildRepository(GuildManagementContext guildContext, IBlizzardConnectionRepository blizzardConnectionRepository)
        {
            _guildContext = guildContext;
            _blizzardConnectionRepository = blizzardConnectionRepository;
        }

        public IEnumerable<Guild> GetAllGuilds()
        {
            return _guildContext.Guilds.AsNoTracking().OrderBy(g => g.Realm).ThenBy(g => g.Name);
        }

        public Guild GetGuild(string key)
        {
            return _guildContext.Guilds.AsNoTracking().FirstOrDefault(g => g.Key == Guid.Parse(key));
        }
        public Guild GetGuild(string realm, string name)
        {
            return _guildContext.Guilds.AsNoTracking().FirstOrDefault(g => g.Realm == realm && g.Name == name);
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
                _guildContext.Add(guild);
            }
            _guildContext.SaveChanges();

            return GetAllGuilds();
        }

        public IEnumerable<Guild> Delete(string key)
        {
            Guild guild = GetGuild(key);
            if (guild == null)
            {
                return GetAllGuilds();
            }

            ICharacterRepository characterRepository = new CharacterRepository(_guildContext);
            characterRepository.DeleteByGuild(key);

            _guildContext.Remove(guild);
            _guildContext.SaveChanges();

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
