using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using GuildManagement.Framework;

namespace GuildManagement.DataModel
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class GuildContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Guild> Guilds { get; set; }
        public DbSet<Character> Characters { get; set; }
    }
}
