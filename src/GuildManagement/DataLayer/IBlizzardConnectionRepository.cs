using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildManagement.DataLayer
{
    public interface IBlizzardConnectionRepository
    {
        string APIKey();
    }
}
