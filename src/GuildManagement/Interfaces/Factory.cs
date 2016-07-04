using GuildManagement.DataLayer;
using GuildManagement.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildManagement.Business
{
    public class Factory
    {
        private static IGuildRepository _guildRepository;
        private static ICharacterRepository _characterRepository;
        private static GuildManagementContext _guildContext;
        private static IBlizzardConnectionRepository _blizzardRepository;

        public Factory(IGuildRepository guildRepository, ICharacterRepository characterRepository, GuildManagementContext guildContext, IBlizzardConnectionRepository blizzardRepository)
        {
            _guildRepository = guildRepository;
            _characterRepository = characterRepository;
            _guildContext = guildContext;
            _blizzardRepository = blizzardRepository;
        }

        //public static IGuildRepository GuildRepository()
        //{
        //    return new GuildRepository(_guildContext, _blizzardRepository);
        //}

        //public static ICharacterRepository CharacterRepository()
        //{
        //    return new CharacterRepository(_guildContext, _blizzardRepository);
        //}
    }
}
