using GuildManagement.Models;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using GuildManagement.Framework;
using Microsoft.Extensions.Logging;

namespace GuildManagement.Controllers
{
    [Route("api/[controller]")]
    public class GuildController : Controller
    {
        private readonly ILogger<GuildController> _logger;
        [FromServices]
        public IGuildRepository GuildRepository { get; set; }

        public GuildController(ILogger<GuildController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Guild> GetAllGuilds()
        {
            _logger.LogError("TESTING");
            return GuildRepository.GetAllGuilds();
        }

        [HttpGet("{key}", Name = "GetGuild")]
        public IActionResult GetByID(string key)
        {
            var guild = GuildRepository.GetGuild(key);
            if (guild == null)
            {
                return HttpNotFound();
            }
            return new ObjectResult(guild);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Guild guild)
        {
            if (guild == null)
            {
                return HttpBadRequest();
            }

            GuildRepository.Add(guild);
            return CreatedAtRoute("GetByID", new { controller = "Guild", key = guild.Key }, guild);
        }

        [HttpPut]
        public IActionResult Update(string key, [FromBody] Guild guild)
        {
            if (guild == null || guild.Key != Guid.Parse(key))
            {
                return HttpBadRequest();
            }

            Guild storedGuild = GuildRepository.GetGuild(key);
            if (storedGuild == null)
            {
                return HttpNotFound();
            }

            GuildRepository.Update(key, guild);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public void Delete(string key)
        {
            GuildRepository.Delete(key);
        }

        [HttpGet("/blizzapi/[controller]/{realm}/{name}")]
        public IActionResult BlizzardGetGuild(string realm, string name)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(realm))
            {
                return HttpBadRequest();
            }

            IEnumerable<Guild> guilds = GuildRepository.DownloadFromBlizzard(name, realm);
            Guild guild = guilds.First(c => c.Name == name && c.Realm == realm);

            return CreatedAtRoute("GetByID", new { controller = "Guild", key = guild.Key }, guild);
        }
    }
}
