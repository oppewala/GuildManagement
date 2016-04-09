using GuildManagement.Framework;
using GuildManagement.Models;
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
            return CharacterRepository.GetAll();
        }

        [HttpGet("{key}", Name = "GetByID")]
        public IActionResult GetByID(string key)
        {
            var guild = CharacterRepository.GetByKey(key);
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
            if (character == null || character.Key != key)
            {
                return HttpBadRequest();
            }

            Character storedCharacter = CharacterRepository.GetByKey(key);
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

        [HttpGet("/blizzapi/[controller]/{realm}/{name}")]
        public IActionResult BlizzardGetCharacter(string realm, string name)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(realm))
            {
                return HttpBadRequest();
            }

            IEnumerable<Character> characters = CharacterRepository.DownloadFromBlizzard(name, realm);
            Character character = characters.First(c => c.Name == name && c.Realm == realm);

            return CreatedAtRoute("GetByID", new { controller = "Character", key = character.Key }, character);
        }
    }
}
