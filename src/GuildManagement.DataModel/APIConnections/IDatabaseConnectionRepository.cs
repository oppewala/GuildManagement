using GuildManagement.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildManagement.DataLayer
{
    public interface IDatabaseConnectionRepository
    {
IEnumerable<Character> GetCharacters();
void AddCharacter(Character character);
void DeleteCharacter(Character character);

IEnumerable<Guild> GetGuilds();
        void AddGuild(Guild guild);
void DeleteGuild(Guild guild);
void DeleteCharacters(IEnumerable<Character> characters);
    }
}
