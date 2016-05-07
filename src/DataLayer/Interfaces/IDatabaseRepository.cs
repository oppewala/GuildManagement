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
        IEnumerable<Guild> DeleteGuild(string key);

        IEnumerable<Character> GetAllCharacters();
        Character GetCharacter(string key);
        IEnumerable<Character> Add(Character guild);
        IEnumerable<Character> Update(string key, Character guild);
        IEnumerable<Character> DeleteCharacter(string key);
    }
}
