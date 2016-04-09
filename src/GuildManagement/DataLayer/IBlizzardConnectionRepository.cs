using GuildManagement.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildManagement.DataLayer
{
    public interface IBlizzardConnectionRepository
    {
        Character GetCharacter(string name, string realm, bool getGuild = false);
    }
}
