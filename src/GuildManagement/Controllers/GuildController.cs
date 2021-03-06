﻿using GuildManagement.Business;
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
        [FromServices]
        public IGuildRepository GuildRepository { get; set; }

        [HttpGet]
        public IEnumerable<Guild> GetAllGuilds()
        {
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

        [HttpDelete("{key}")]
        public void Delete(string key)
        {
            GuildRepository.Delete(key);
        }
    }
}
