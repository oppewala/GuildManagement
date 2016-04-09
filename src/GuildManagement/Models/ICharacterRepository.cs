using GuildManagement.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildManagement.Models
{
    public interface ICharacterRepository
    {
        IEnumerable<Character> Add(Character character);
        IEnumerable<Character> GetAll();
        Character GetByKey(string key);
        IEnumerable<Character> Delete(string key);
        IEnumerable<Character> Update(string key, Character character);

        IEnumerable<Character> DownloadFromBlizzard(string name, string realm);
    }
}
