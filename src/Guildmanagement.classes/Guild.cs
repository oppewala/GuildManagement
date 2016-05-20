using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace GuildManagement.Framework
{
    public class Guild
    {
        public Guild ConvertJSON(string json)
        {
            Guild guild = JsonConvert.DeserializeObject<Guild>(json);

            return guild;
        }

        public Guild()
        {
            Key = Guid.NewGuid();
        }

        public Guid Key { get; set; }

        public string Name { get; set; }
        public string Realm { get; set; }
        public string Battlegroup { get; set; }

        public string Website { get; set; }
        public Guid?  Owner { get; set; }

        public List<Character> Members { get; set; }
    }
}