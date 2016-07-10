using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using GuildManagement.Framework;
using GuildManagement.Business;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace GuildManagement.Controllers
{
    [Route("api/[controller]")]
    public class BlizzardController : Controller
    {
        [FromServices]
        public ICharacterRepository CharacterRepository { get; set; }

        [FromServices]
        public IGuildRepository GuildRepository { get; set; }

        [FromServices]
        public IBlizzardSyncRepository BlizzardSyncRepository { get; set; }

        [HttpGet("Character/{realm}/{name}")]
        public IActionResult BlizzardGetCharacter(string realm, string name)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(realm))
            {
                return HttpBadRequest();
            }

            Character character = BlizzardSyncRepository.RetrieveCharacter(realm, name);

            return CreatedAtRoute("GetByID", new { controller = "Character", key = character.Key }, character);
        }
        [HttpGet("Guild/{realm}/{name}")]
        public IActionResult BlizzardGetGuild(string realm, string name)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(realm))
            {
                return HttpBadRequest();
            }

            Guild guild = BlizzardSyncRepository.RetrieveGuild(realm, name);

            return CreatedAtRoute("GetByID", new { controller = "Guild", key = guild.Key }, guild);
        }
    }
}
