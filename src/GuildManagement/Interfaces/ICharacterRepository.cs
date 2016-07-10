using GuildManagement.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildManagement.Business
{
    public interface ICharacterRepository
    {
        IEnumerable<Character> Add(Character character);
        IEnumerable<Character> GetAllCharacters();
        IEnumerable<Character> GetCharactersByGuild(string guildKey);
        Character GetCharacter(string key);
        Character GetCharacter(string realm, string name);
        IEnumerable<Character> Delete(string key);
        IEnumerable<Character> DeleteByGuild(string guildKey);
        IEnumerable<Character> Update(string key, Character character);
    }
}
