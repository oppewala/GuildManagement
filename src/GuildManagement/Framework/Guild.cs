using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildManagement.Framework
{
    public class Guild
    {
        public string Key { get; set; }

        public string Name { get; set; }
        public string Realm { get; set; }
        public string Battlegroup { get; set; }

        public string Website { get; set; }

        public string Owner { get; set; }
    }
}
