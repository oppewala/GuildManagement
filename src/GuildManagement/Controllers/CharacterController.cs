﻿using GuildManagement.Framework;
using GuildManagement.Business;
using Microsoft.AspNet.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildManagement.Controllers
{
    [Route("api/[controller]")]
    public class CharacterController : Controller
    {
        [FromServices]
        public ICharacterRepository CharacterRepository { get; set; }

        [HttpGet]
        public IEnumerable<Character> GetAllGuilds()
        {
            List<Character> characters = CharacterRepository.GetAllCharacters().ToList();

            return CharacterRepository.GetAllCharacters();
        }

        [HttpGet("{key}", Name = "GetByID")]
        public IActionResult GetByID(string key)
        {
            var guild = CharacterRepository.GetCharacter(key);
            if (guild == null)
            {
                return HttpNotFound();
            }
            return new ObjectResult(guild);
        }

        [HttpPost]
        public IActionResult Add([FromBody] Character character)
        {
            if (character == null)
            {
                return HttpBadRequest();
            }

            CharacterRepository.Add(character);
            return CreatedAtRoute("GetCharacter", new { controller = "Character", key = character.Key }, character);
        }

        [HttpPut]
        public IActionResult Update(string key, [FromBody] Character character)
        {
            if (character == null || character.Key != Guid.Parse(key))
            {
                return HttpBadRequest();
            }

            Character storedCharacter = CharacterRepository.GetCharacter(key);
            if (storedCharacter == null)
            {
                return HttpNotFound();
            }

            CharacterRepository.Update(key, character);
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public void Delete(string key)
        {
            CharacterRepository.Delete(key);
        }
    }
}
