using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GuildManagement.Framework
{
    public class User
    {
        [Key]
        public Guid Key { get; set; }

        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        //List<Character> Characters { get; set; }
        //List<Guild> Guilds { get; set; }
    }
}
