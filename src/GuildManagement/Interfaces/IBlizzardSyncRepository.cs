using GuildManagement.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildManagement.Business
{
    public interface IBlizzardSyncRepository
    {
        Character RetrieveCharacter(string realm, string name);
        Guild RetrieveGuild(string realm, string name);
    }
}
