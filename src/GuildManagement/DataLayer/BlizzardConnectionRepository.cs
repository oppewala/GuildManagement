using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace GuildManagement.DataLayer
{
    public class BlizzardConnectionRepository : IBlizzardConnectionRepository
    {
        string _apiKey;

        public BlizzardConnectionRepository(IConfiguration config)
        {
            _apiKey = config["BlizzardAPIKey"];
        }

        public string APIKey()
        {
            return _apiKey;
        }
    }
}
