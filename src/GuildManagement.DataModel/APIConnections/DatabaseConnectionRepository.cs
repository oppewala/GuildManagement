using GuildManagement.DataModel;
using GuildManagement.Framework;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildManagement.DataLayer
{
    public class DatabaseConnectionRepository : IDatabaseConnectionRepository
    {
        private readonly GuildManagementContext _dbContext;
        public DatabaseConnectionRepository(GuildManagementContext guildManagementContext)
        {
            _dbContext = guildManagementContext;
        }

        public void AddCharacter(Character character)
        {
            _dbContext.Characters.Add(character);
            _dbContext.SaveChanges();
        }

        public void DeleteCharacter(Character character)
        {
            _dbContext.Characters.Remove(character);
            _dbContext.SaveChanges();
        }
        public void DeleteCharacters(IEnumerable<Character> characters)
        {
            _dbContext.Characters.RemoveRange(characters);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Character> GetCharacters()
        {
            return _dbContext.Characters.AsNoTracking();
        }


        public void AddGuild(Guild guild)
        {
            _dbContext.Guilds.Add(guild);
            _dbContext.SaveChanges();
        }

        public void DeleteGuild(Guild guild)
        {
            _dbContext.Guilds.Remove(guild);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Guild> GetGuilds()
        {
            return _dbContext.Guilds.AsNoTracking();
        }
    }
}
